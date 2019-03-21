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

namespace GODInventoryWinForm
{
    public partial class CreateTransportsFee : Form
    {
        List<t_itemlist> products = null;
        private List<t_transports> transportList;
        private List<t_shoplist> shopList;
        private List<t_warehouses> warehouseList;
        List<t_genre> genres = null;

        private int orderId;
        private t_freights freights { get; set; }
        public CreateTransportsFee()
        {
            InitializeComponent();
            InitializeOrder();
        }
       
        private void InitializeOrder()
        {

            var ctx = entityDataSource1.DbContext as GODDbContext;
    
            warehouseList = ctx.t_warehouses.ToList();
            transportList = ctx.t_transports.ToList();
            this.genres = ctx.t_genre.ToList();
            this.products = ctx.t_itemlist.ToList();
      

            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.DataSource = warehouseList;

            // 県別
            shopList = ctx.t_shoplist.ToList();
            if (shopList.Count > 0)
            {
                var counties = shopList.Select(s => s.県別).Distinct().ToList();
            
                this.countyComboBox1.DataSource = counties;
            }


            this.transportComboBox.DisplayMember = "fullname";
            this.transportComboBox.ValueMember = "id";
            this.transportComboBox.DataSource = transportList;

            var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
      
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;



            var genreList = this.genres.Select(s => new MockEntity { Id = s.idジャンル, FullName = s.ジャンル名 }).ToList();
 
            this.genresComboBox.ValueMember = "Id";
            this.genresComboBox.DisplayMember = "FullName";
            this.genresComboBox.DataSource = genreList;



        }
     
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext()) 
            {
                if (productComboBox.Text.Length > 0)
                {
                    // 运费依赖于 商品、仓库、商店、物流公司
                    int productId = Convert.ToInt32(productComboBox.SelectedValue);
                    int warehouseId = Convert.ToInt32(warehouseComboBox.SelectedValue);
                    int storeId = Convert.ToInt32(storeComboBox.SelectedValue);
                    int transportId = Convert.ToInt32(transportComboBox.SelectedValue);

                    var freight = (from t_freights o in ctx.t_freights
                                where productId == o.自社コード && warehouseId == o.warehouse_id && storeId == o.shop_id && transportId == o.transport_id
                                select o).FirstOrDefault();
                    if (freight  == null )
                    {
                        t_freights freights = new t_freights();
                        freights.自社コード = Convert.ToInt32(productComboBox.SelectedValue);
                        freights.warehousename = warehouseComboBox.Text;
                        freights.transportname = transportComboBox.Text;
                        freights.unitname = storeCodeTextBox.Text;
                        freights.fee = Convert.ToInt32(invoiceNOTextBox.Text);


                        freights.shop_id = Convert.ToInt32(storeComboBox.SelectedValue);
                        freights.transport_id = Convert.ToInt32(transportComboBox.SelectedValue);
                        freights.warehouse_id = Convert.ToInt32(warehouseComboBox.SelectedValue); 
 
                        ctx.t_freights.Add(freights);
                        ctx.SaveChanges();

                        MessageBox.Show(String.Format("登録完了!"));
                    }
                    else
                    {
                        MessageBox.Show(String.Format("无法添加， 已存在!"));

                    }
                }
            }
        }

        private void countyComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string county = this.countyComboBox1.Text;
            var filtered = shopList.FindAll(s => s.県別 == county);
            if (filtered.Count > 0)
            {
                var shops = filtered.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
         
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                this.storeComboBox.SelectedIndex = 0;
            }
            else
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
       
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;

            }
        }

        private void genresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MockEntity> productsByGenre;
            int genreId = (int)this.genresComboBox.SelectedValue;

            if (genreId > 0)
            {
                productsByGenre = this.products.Where(o => o.ジャンル == genreId).Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            else
            {
                productsByGenre = this.products.Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            //productsByGenre.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.productComboBox.ValueMember = "Id";
            this.productComboBox.DisplayMember = "FullName";
            this.productComboBox.DataSource = productsByGenre;
        }



    }
}
