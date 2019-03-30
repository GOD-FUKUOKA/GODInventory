using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls.Prices
{
    public partial class MissingReportForm : Form
    {
        public class GroupedItemPrice
        {
            public int id { get; set; }
            //運賃単位
            public int total { get; set; }

            public string name { get; set; }

            public int expectTotal { get; set; }
        }

        private List<t_itemlist> itemList;
        private List<t_shoplist> shopList;
        private List<GroupedItemPrice> groupByItem;
        private List<GroupedItemPrice> groupByShop;
        private int itemListCount = 0;
        private int shopListCount = 0;

        public MissingReportForm()
        {
            InitializeComponent();
            this.groupByShopDataGridView1.AutoGenerateColumns = false;
            this.groupByProductDataGridView2.AutoGenerateColumns = false;
        }


        public void InitializeData() 
        {

            // 检查当前商店的 所有商品价格是否存在。
            using (var ctx = new GODDbContext())
            {
                this.itemList = ctx.t_itemlist.ToList();
                this.shopList = ctx.t_shoplist.ToList();
                this.itemListCount = itemList.Count();
                this.shopListCount = shopList.Count();



                string sql = string.Format("select i.自社コード as id, i.商品名 as name, count(*) as total, {0} as expectTotal  from t_itemlist i left join t_pricelist p on  i.自社コード = p.自社コード group by i.自社コード", shopListCount);
                this.groupByItem = ctx.Database.SqlQuery<GroupedItemPrice>( sql).ToList();

                string sql2 = string.Format("select s.店番 as id, s.店名 as name, count(*) as total, {0} as expectTotal  from t_shoplist s left join t_pricelist p on  s.店番 = p.店番 group by s.店番", itemListCount);
                this.groupByShop = ctx.Database.SqlQuery<GroupedItemPrice>( sql2).ToList();
                
                
            }
            var missingByProduct = this.groupByItem.FindAll(o=>{ return o.total != o.expectTotal; });
            var missingByShop = this.groupByShop.FindAll(o => { return o.total != o.expectTotal;  });
            this.groupByProductDataGridView2.DataSource = missingByProduct;
            this.groupByShopDataGridView1.DataSource = missingByShop;
        
            this.groupByShoplabel1.Text=string.Format("共有{0}个店铺缺失价格信息！", missingByShop.Count());
            this.groupProductLabel2.Text=string.Format("共有{0}个产品缺失价格信息！", missingByProduct.Count());
        }

        private void MissingReportForm_Load(object sender, EventArgs e)
        {
            InitializeData();
        }

        /// <summary>
        /// 基于shop，找到缺失的产品价格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fixButton1_Click(object sender, EventArgs e)
        {
            
            var rows = this.groupByShopDataGridView1.SelectedRows;
            if (rows.Count > 0) {
                if (MessageBox.Show(String.Format("确定要为这{0}个店铺添加商品价格信息吗？", rows.Count), "添加操作确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var ctx = new GODDbContext())
                    {
                        List<t_pricelist> newPriceList = new List<t_pricelist>();
                        for (var i = 0; i < rows.Count; i++)
                        {
                            GroupedItemPrice groupdata = rows[i].DataBoundItem as GroupedItemPrice;
                            if (groupdata.total != groupdata.expectTotal)
                            {
                                //找到缺失的数据id
                                var existPrices = (from t_pricelist p in ctx.t_pricelist
                                                   where p.店番 == groupdata.id
                                                   select p).ToList();
                                // 遍历所有的商品
                                foreach (var item in itemList)
                                {
                                    bool exist = existPrices.Exists(o => { return o.自社コード == item.自社コード; });

                                    if (!exist)
                                    {
                                        var shop = shopList.First(o => { return o.店番 == groupdata.id; });
                                        var price = new t_pricelist();

                                        price.店番 = shop.店番;
                                        price.県別 = shop.県別;
                                        price.自社コード = item.自社コード;
                                        price.店名 = shop.店名;
                                        price.売単価 = item.売単価;
                                        price.仕入原価 = item.仕入原価;
                                        price.通常原単価 = item.通常原単価;
                                        price.warehouse_id = shop.warehouse_id;
                                        price.warehousename = shop.warehousename;
                                        price.transport_id = shop.transport_id;
                                        price.配送担当 = shop.配送担当;
                                        newPriceList.Add(price);
                                    }
                                }
                            }
                        }
                 
                        ctx.t_pricelist.AddRange(newPriceList);
                        ctx.SaveChanges();
                        MessageBox.Show("数据填充成功！");
                        this.InitializeData();
                    }
                }
            
            }

        }

        /// <summary>
        /// 修正商品缺失的价格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var rows = this.groupByProductDataGridView2.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show(String.Format("确定要为这{0}个商品添加价格信息吗？", rows.Count), "添加操作确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var ctx = new GODDbContext())
                    {
                        List<t_pricelist> newPriceList = new List<t_pricelist>();
                        for (var i = 0; i < rows.Count; i++)
                        {
                            GroupedItemPrice groupdata = rows[i].DataBoundItem as GroupedItemPrice;
                            if (groupdata.total != groupdata.expectTotal)
                            {
                                //找到缺失的数据id
                                var existPrices = (from t_pricelist p in ctx.t_pricelist
                                                   where p.自社コード == groupdata.id
                                                   select p).ToList();
                                // 遍历所有的商店
                                foreach (var shop in shopList)
                                {
                                    bool exist = existPrices.Exists(o => { return o.店番 == shop.店番; });

                                    if (!exist)
                                    {
                                        var item = itemList.First(o => { return o.自社コード == groupdata.id; });
                                        var price = new t_pricelist();

                                        price.店番 = shop.店番;
                                        price.県別 = shop.県別;
                                        price.自社コード = item.自社コード;
                                        price.店名 = shop.店名;
                                        price.売単価 = item.売単価;
                                        price.仕入原価 = item.仕入原価;
                                        price.通常原単価 = item.通常原単価;
                                        price.warehouse_id = shop.warehouse_id;
                                        price.warehousename = shop.warehousename;
                                        price.transport_id = shop.transport_id;
                                        price.配送担当 = shop.配送担当;
                                        newPriceList.Add(price);
                                    }
                                }
                            }
                        }

                        ctx.t_pricelist.AddRange(newPriceList);
                        ctx.SaveChanges();
                        MessageBox.Show("数据填充成功！");
                        this.InitializeData();
                    }
                }

            }
        }
    }
}
