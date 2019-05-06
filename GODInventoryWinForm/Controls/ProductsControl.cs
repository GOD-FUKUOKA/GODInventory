using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory;
using System.Linq;
using System.Collections;
using GODInventoryWinForm.Controls.Freights;

namespace GODInventoryWinForm.Controls
{
    public partial class ProductsControl : UserControl
    {
        static string anyOption = "すべて";
        List<t_shoplist> stores = null;
        List<t_genre> genres = null;
        List<t_itemlist> productList = null;
        private List<t_warehouses> warehouseList;
        EditTransportsFee EditTransportsFeeForm;
        //List<t_freights> freights = null;
        private List<t_transports> transportList;
        private List<t_shoplist> shopList;
        private List<v_itemunit> unitList;
        private List<string> unitnameList;
        private List<string> columnnameList;


        public ProductsControl()
        {
            InitializeComponent();

            //shopList = ctx.t_shoplist.ToList();
            this.pricesDataGridView.AutoGenerateColumns = false;
            this.productsDataGridView.AutoGenerateColumns = false;
            this.transportdataGridView1.AutoGenerateColumns = false;

            EditTransportsFeeForm = new EditTransportsFee();
            
        }


        private void InitializeDataSource()
        {
            //freights = new List<t_freights>();

            var ctx = this.entityDataSource1.DbContext as GODDbContext;

            this.stores = ctx.t_shoplist.ToList();
            this.genres = ctx.t_genre.ToList();
            this.productList = ctx.t_itemlist.ToList();
            this.transportList = ctx.t_transports.ToList();
            this.warehouseList = ctx.t_warehouses.ToList();

            this.unitList = (from s in ctx.t_pricelist
                             group s by s.unitname into g
                             select new v_itemunit { unitname = g.Key, total = g.Count() }).ToList();
            // 初始化分类
            var genreList = this.genres.Select(s => new MockEntity { Id = s.idジャンル, FullName = s.ジャンル名 }).ToList();
            genreList.Insert(0, new MockEntity { Id = 0, FullName = anyOption });
            this.genresComboBox.ValueMember = "Id";
            this.genresComboBox.DisplayMember = "FullName";
            this.genresComboBox.DataSource = genreList;

            // 初始化地域过滤条件
            var areas = this.stores.Select(s => s.地域).Distinct().ToList();
            areas.Insert(0, anyOption);
            this.areaComboBox2.DataSource = areas;

            //var counties = this.stores.Select(s => new { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();
            //counties.Insert(0, new { ShortName = "", FullName = "すべて" });
            //this.countyComboBox2.ValueMember = "ShortName";
            //this.countyComboBox2.DisplayMember = "FullName";
            //this.countyComboBox2.DataSource = counties;

            this.pricesDataGridView.DataSource = null;
            this.costTextBox.Text = String.Empty;
            this.priceTextBox.Text = String.Empty;
            this.promotePriceTextBox.Text = String.Empty;
            this.adPriceTextBox.Text = String.Empty;
            this.salePriceTextBox.Text = String.Empty;

            //mark 20181022
            var warehouses = warehouseList.Select(s => new MockEntity { Id = s.Id, ShortName = s.ShortName, FullName = s.FullName }).Distinct().ToList();

            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = warehouses;

            var transports = transportList.Select(s => new { id = s.id, fullname = s.fullname }).ToList();
            this.transportComboBox.DisplayMember = "fullname";
            this.transportComboBox.ValueMember = "id";
            this.transportComboBox.DataSource = transports;


            // 初始化datagridview 配送担当 数据列
            var transportsForColumn = transportList.Select(s => new { id = s.id, fullname = s.fullname }).ToList();
            transportsForColumn.Insert(0, new { id=0, fullname=""}); // transprot_id可能为0

            this.transportColumn2.DataSource = transportsForColumn;
            this.transportColumn2.DisplayMember = "fullname";
            this.transportColumn2.ValueMember = "id";
            
            // initializeTabFreights();

            //initializeUnitnames();
        }

        private void initializeTabFreights() {
            var counties = this.stores.Select(s => new { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();
            counties.Insert(0, new { ShortName = "", FullName = "すべて" });

            //
            var shipperConew = warehouseList.Select(s => new MockEntity { Id = s.Id, ShortName = s.ShortName, FullName = s.FullName }).Distinct().ToList();
            shipperConew.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            // shipperConew.Insert(0, new { ShortName = "", FullName = "すべて" });

            this.warehouseComboBox5.ValueMember = "Id";
            this.warehouseComboBox5.DisplayMember = "FullName";
            this.warehouseComboBox5.DataSource = shipperConew;
            //
            var transportListnew = transportList.Select(s => new MockEntity { Id = s.id, ShortName = s.shortname, FullName = s.fullname }).Distinct().ToList();
            transportListnew.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.transportComboBox6.DisplayMember = "FullName";
            this.transportComboBox6.ValueMember = "Id";
            this.transportComboBox6.DataSource = transportListnew;

            // 初始化地域过滤条件
            var areas = this.stores.Select(s => s.地域).Distinct().ToList();
            areas.Insert(0, anyOption);
            this.areaComboBox3.DataSource = areas;
            ////  県別
            //this.countyComboBox3.ValueMember = "ShortName";
            //this.countyComboBox3.DisplayMember = "FullName";
            //this.countyComboBox3.DataSource = counties;

            var genreList = this.genres.Select(s => new MockEntity { Id = s.idジャンル, FullName = s.ジャンル名 }).ToList();
            genreList.Insert(0, new MockEntity { Id = 0, FullName = anyOption });
   
            // 产品分类
            this.genresComboBox3.ValueMember = "Id";
            this.genresComboBox3.DisplayMember = "FullName";
            this.genresComboBox3.DataSource = genreList;
         
        }

        private void initializeUnitnames() {
            var ctx = this.entityDataSource1.DbContext as GODDbContext;

            this.unitnameList = ctx.t_freights.GroupBy(o => o.unitname).Select(o => o.Key).ToList();
            this.columnnameList = ctx.t_freights.GroupBy(o => o.columnname).Select(o => o.Key).ToList();
            // 单位选项
            this.unitnameComboBox4.DataSource = this.unitnameList;
            this.columnnameComboBox4.DataSource = this.columnnameList;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        dataGridView1.ClearSelection();
            //        dataGridView1.Columns[e.ColumnIndex].Selected = true;
            //        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);                
            //    }
            //}
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int i = productsDataGridView.CurrentCell.OwningColumn.Index;
            int iRow = productsDataGridView.CurrentCell.OwningRow.Index;
            var oids = GetOrderIdsBySelectedGridCell();

            if (oids.Count() == 1)
            {
                var form = new ProductsManagement(oids, "Update");

                if (form.ShowDialog() == DialogResult.OK)
                {

                    this.entityDataSource1.Refresh();

                }
                //OrderSqlHelper.SendOrderToShipper(oids);
                ////pager1.Bind();
            }
            else
            {
                MessageBox.Show(" まず伝票を選択してください.");
            }
        }
        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(productsDataGridView);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as t_itemlist;
                order_ids.Add(pendingorder.自社コード);
            }

            return order_ids;
        }
        private List<int> GetOrderIdsBySelectedGridCell_transportdataGridView1()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(transportdataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as v_freights;
                order_ids.Add(pendingorder.id);
            }

            return order_ids;
        }
        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductsManagement(null, "Add");

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.entityDataSource1.Refresh();

            }

            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0]; 

        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            var form = new ProductsManagement(null, "Add");

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.entityDataSource1.Refresh();

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:

                    InitializeDataSource();

                    break;
                case 2:

                    InitializeDataSource();

                    break;
            }

        }

        private void InitializePriceListDatagridView(int productCode=0, string county = "", int storeId = 0, int genresId = 0, string area="")
        {

            var query = from t_pricelist p in this.entityDataSource1.EntitySets["t_pricelist"]
                        join t_shoplist s in entityDataSource1.EntitySets["t_shoplist"] on p.店番 equals s.店番
                        join t_itemlist i in entityDataSource1.EntitySets["t_itemlist"] on p.自社コード equals i.自社コード

                        select new v_itemprice
                        {
                            Id = p.Id,
                            自社コード = i.自社コード,
                            商品名 = i.商品名,
                            規格 = i.規格,
                            店番 = p.店番,
                            店名 = p.店名,
                            県別 = p.県別,
                            仕入原価 = p.仕入原価,
                            売単価 = p.売単価,
                            原単価 = p.通常原単価,
                            広告原単価 = p.広告原単価,
                            特売原単価 = p.特売原単価,
                            ジャンル = i.ジャンル,
                            配送担当 = p.配送担当,
                            transport_id = p.transport_id,
                            warehouse_id = p.warehouse_id,
                            warehousename = p.warehousename,
                            unitname = p.unitname,
                            地域 = s.地域
                        };


            if (storeId > 0)
            {
                query = query.Where(o => o.店番 == storeId);
            }else if (county.Length > 0 && county != anyOption)
            {
                query = query.Where(o => o.県別 == county);
            }else if (area.Length > 0 && area != anyOption)
            {
                query = query.Where(o => o.地域 == area);

            }

            if (productCode > 0)
            {
                query = query.Where(o => o.自社コード == productCode);
            }
            if (genresId > 0)
            {
                query = query.Where(o => o.ジャンル == genresId);
            }
            this.pricesBindingSource.DataSource = this.entityDataSource1.CreateView(query);
            this.pricesDataGridView.DataSource = this.pricesBindingSource;

        }

        private void editPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pricesDataGridView.RowCount > 0)
            {
                var price = pricesDataGridView.CurrentRow.DataBoundItem as v_itemprice;

                var form = new EditPriceForm(price.Id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //price.仕入原価 = form.price.仕入原価;
                    //price.原単価 = form.price.通常原単価;
                    //price.広告原単価 = form.price.広告原単価;
                    //price.特売原単価 = form.price.特売原単価;
                    //price.売単価 = form.price.売単価;

                    searchButton_Click(null, EventArgs.Empty);
                    //this.pricesDataGridView.Refresh();
                    //MessageBox.Show("saved");
                }
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int productCode = Convert.ToInt32(this.productsComboBox.SelectedValue);
            int storeId = Convert.ToInt32(this.storesComboBox.SelectedValue);
            int genresId = Convert.ToInt32(this.genresComboBox.SelectedValue);

            string county = this.countyComboBox2.SelectedValue.ToString();
            string area = this.areaComboBox2.SelectedValue.ToString();
            area = (area != anyOption ? area : String.Empty);
            county = (county != anyOption ? county : String.Empty);

            if (genresId > 0 )
            {
                InitializePriceListDatagridView(productCode, county, storeId, genresId, area);
            }

        }

        private void genresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MockEntity> productsByGenre;
            int genreId = (int)this.genresComboBox.SelectedValue;

            if (genreId > 0)
            {
                productsByGenre = this.productList.Where(o => o.ジャンル == genreId).Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            else
            {
                productsByGenre = this.productList.Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            productsByGenre.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.productsComboBox.ValueMember = "Id";
            this.productsComboBox.DisplayMember = "FullName";
            this.productsComboBox.DataSource = productsByGenre;
        }

        private void countyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string county = this.countyComboBox2.SelectedValue.ToString();
            List<MockEntity> storesByCounty;

            if (county.Length > 0)
            {
                storesByCounty = this.stores.Where(s => s.県別 == county).Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
            }
            else
            {
                storesByCounty = this.stores.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();

            }
            storesByCounty.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.storesComboBox.ValueMember = "Id";
            this.storesComboBox.DisplayMember = "FullName";
            this.storesComboBox.DataSource = storesByCounty;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {


            int productCode = (int)this.productsComboBox.SelectedValue;
            int storeId = Convert.ToInt32(this.storesComboBox.SelectedValue);
            int genresId = Convert.ToInt32(this.genresComboBox.SelectedValue);

            string county = this.countyComboBox2.SelectedValue.ToString();
            string area = this.areaComboBox2.SelectedValue.ToString();
            area = (area != anyOption ? area : String.Empty);
            county = (county != anyOption ? county : String.Empty);

            decimal cost = -1;
            decimal price = -1;
            decimal promotePrice = -1;
            decimal adPrice = -1;
            decimal salePrice = -1;

            if (this.costTextBox.Text.Trim().Length > 0)
            {
                cost = Convert.ToDecimal(this.costTextBox.Text);
            }

            if (this.priceTextBox.Text.Trim().Length > 0)
            {
                price = Convert.ToDecimal(this.priceTextBox.Text);
            }

            if (this.promotePriceTextBox.Text.Trim().Length > 0)
            {
                promotePrice = Convert.ToDecimal(this.promotePriceTextBox.Text);
            }

            if (this.adPriceTextBox.Text.Trim().Length > 0)
            {
                adPrice = Convert.ToDecimal(this.adPriceTextBox.Text);
            }
            if (this.salePriceTextBox.Text.Trim().Length > 0)
            {
                salePrice = Convert.ToDecimal(this.salePriceTextBox.Text);
            }


            if (productCode == 0)
            {
                MessageBox.Show("Please select a product!");
                return;
            }

            if (cost == -1 || price == -1 || promotePrice == -1 || adPrice == -1 || salePrice == -1)
            {
                MessageBox.Show("単価を修正する際、すべての欄に入力してください。設定されていない単価は0で入力してください。");
                return;
            }



            int count = OrderHelper.UpdateProductCost(productCode, area, county, storeId, cost, price, promotePrice, adPrice, salePrice);

            if (count > 0)
            {
                //MessageBox.Show(string.Format("update {0} prices successfully", count));

                searchButton_Click(sender, e);
            }
        }

        private void saveDanButton_Click(object sender, EventArgs e)
        {
            int productCode = (int)this.productsComboBox.SelectedValue;
            int storeId = Convert.ToInt32(this.storesComboBox.SelectedValue);
            string county = this.countyComboBox2.Text;
            string area = this.areaComboBox2.Text;
            int genreId = Convert.ToInt32(this.genresComboBox.SelectedValue);

            string warehousename = this.warehouseComboBox.Text;
            string transportName = this.transportComboBox.Text;
            int warehouseId = Convert.ToInt32(this.warehouseComboBox.SelectedValue);
            int transportId = Convert.ToInt32(this.transportComboBox.SelectedValue);
            string unitname = string.Empty;

            area = (area != anyOption ? area : String.Empty);
            county = (county != anyOption ? county : String.Empty);

            String sql = String.Empty;
            //保存配送担当
            int rows = this.pricesDataGridView.RowCount;

            if (rows == 0)
            {
                MessageBox.Show("Please click search to find product!");
                return;
            }
            if( genreId == 0 )
            {
                MessageBox.Show("Please select genre !");
                return;            
            }
            if (warehousename.Length > 0 && transportName.Length > 0)
            {

                using (var ctx = new GODDbContext())
                {
                    // List<int> priceids = new List<int>();

                    //`for (var i = 0; i < transportdataGridView1.RowCount; i++) {
                    //    var row = transportdataGridView1.Rows[i];
                    //    var price = row.DataBoundItem as v_itemprice;
                    //    priceids.Add(price.Id);
                    //`}

                    //更新某一个具体产品 or 某一类产品
                    sql = String.Format("UPDATE t_pricelist SET `transport_id`={0},`配送担当`='{1}',`warehouse_id`={2},`warehousename`='{3}' ", transportId, transportName, warehouseId, warehousename);

                    if (unitname.Length > 0) {
                        sql += string.Format(", `unitname`='{0}'", unitname);
                    }

                    // 更新某一个具体产品 or 某一类产品
                    if (productCode > 0)
                    {
                        sql += string.Format("WHERE `自社コード`={0}", productCode);
                    }
                    else {
                        var productIdsByGenre = this.productList.Where(o => o.ジャンル == genreId).Select(s =>  s.自社コード).ToList();
                        sql += string.Format("WHERE `自社コード`in ({0})", string.Join(",", productIdsByGenre));
                    }
                    //else
                    //{
                    //    var productCodes = (from t_itemlist item in ctx.t_itemlist
                    //                        where item.ジャンル == genresId
                    //                        select item.自社コード).ToList();
                    //    sql = String.Format("UPDATE t_pricelist SET  `transport_id`={0},`配送担当`='{1}',`warehouse_id`={2},`warehousename`='{3}' WHERE `自社コード`in ({1})", transportId, transportName, warehouseId, warehousename, String.Join(",", productCodes));
                    //}
                    if (storeId > 0)
                    {
                        sql += string.Format(" AND `店番`={0}", storeId);
                    }else if (county.Length > 0)
                    {
                        sql += string.Format(" AND `県別`='{0}'", county);
                    }
                    else if (area.Length > 0)
                    {
                        var pids = ctx.t_shoplist.Where(o => o.地域 == area).Select(o => o.店番).ToList();
                        sql += string.Format(" AND  `店番` in ({0}) ", string.Join(",", pids));
                    }
                    ctx.Database.ExecuteSqlCommand(sql);

                }
                searchButton_Click(sender, e);

            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.transportdataGridView1.RowCount > 0)
            {
                var order = transportdataGridView1.CurrentRow.DataBoundItem as v_freights;

                EditTransportsFeeForm.OrderId = order.id;
                if (EditTransportsFeeForm.ShowDialog() == DialogResult.OK)
                {
                    InitializetransportdataGridViewBySelectedValue();
                }
            }
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CreateTransportsFee();

            if (form.ShowDialog() == DialogResult.OK)
            {
                InitializeDataSource();
            }
        }

        private void transportdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = transportdataGridView1.Columns[e.ColumnIndex];

            if (column == deleteButtonColumn)
            {

                var freight = transportdataGridView1.Rows[e.RowIndex].DataBoundItem as v_freights;

                using (var ctx = new GODDbContext())
                {
                    if (freight!=null)
                    {
                        var fid = freight.id;

                        var del = (from s in ctx.t_freights
                                   where s.id == fid
                                   select s).First();
                        ctx.t_freights.Remove(del);
                        ctx.SaveChanges();

                    }

                    InitializetransportdataGridViewBySelectedValue();
                }

            }
        }

        private void bttransportfind_Click(object sender, EventArgs e)
        {
            InitializetransportdataGridViewBySelectedValue();
           
        }

        private void InitializetransportdataGridView1(int warehouse_id = 0, int transport_id = 0, int shop_id = 0, int genre_id=0, int product_id = 0, string area="", string county = "")
        {
            using (var ctx = new GODDbContext())
            {
                var query = from t_freights p in this.entityDataSource1.EntitySets["t_freights"]
                            join t_itemlist i in this.entityDataSource1.EntitySets["t_itemlist"] on p.自社コード equals i.自社コード
                            join t_shoplist s in this.entityDataSource1.EntitySets["t_shoplist"] on p.shop_id equals s.店番

                            select new v_freights
                            {
                                id = p.id,
                                transportname = p.transportname,
                                warehousename = p.warehousename,
                                transport_id = p.transport_id,
                                warehouse_id = p.warehouse_id,
                                shop_id = p.shop_id,
                                fee = p.fee,
                                lot_fee = p.lot_fee,
                                unitname = p.unitname,
                                columnname = p.columnname,
                                shopname = s.店名,
                                商品名 = i.商品名,
                                自社コード = i.自社コード,
                                県別 = s.県別,
                                地域 = s.地域
                            };

                if (warehouse_id > 0 )
                {
                    query = query.Where(o => o.warehouse_id == warehouse_id);
                }

                if (transport_id > 0 )
                {
                    query = query.Where(o => o.transport_id == transport_id);
                }
                if (shop_id > 0)
                {
                    query = query.Where(o => o.shop_id == shop_id);
                } else if (county.Length > 0)
                {
                    // 查询某一个县
                    query = query.Where(o => o.県別 == county);
                }
                else if (area.Length > 0)
                {
                    // 查询某一个地域
                    query = query.Where(o => o.地域 == area);
                }

                if (genre_id > 0) 
                {
                    var pids = this.productList.Where(o=>{ return o.ジャンル==genre_id;}).Select(p => { return p.自社コード; }).ToList();
                    query = query.Where(o=> pids.Contains(o.自社コード));
                }
                if (product_id > 0)
                {
                    query = query.Where(o => o.自社コード == product_id);
                }


                this.transportdatabindingSource2.DataSource = this.entityDataSource1.CreateView(query);
                this.transportdataGridView1.DataSource = this.transportdatabindingSource2;
            }
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {


            string county = this.countyComboBox3.SelectedValue.ToString();
            List<MockEntity> storesByCounty;

            if (county.Length > 0)
            {
                storesByCounty = this.stores.Where(s => s.県別 == county).Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
            }
            else
            {
                storesByCounty = this.stores.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();

            }
            storesByCounty.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.shopComboBox3.ValueMember = "Id";
            this.shopComboBox3.DisplayMember = "FullName";
            this.shopComboBox3.DataSource = storesByCounty;
        }

        private void updateFeeButton_Click_1(object sender, EventArgs e)
        {
            int warehouse_id = Convert.ToInt32(this.warehouseComboBox5.SelectedValue);
            int transport_id = Convert.ToInt32(this.transportComboBox6.SelectedValue);
            int shop_id = Convert.ToInt32(this.shopComboBox3.SelectedValue);
            int genre_id = Convert.ToInt32(this.genresComboBox3.SelectedValue);
            int product_id = Convert.ToInt32(this.productsComboBox3.SelectedValue);
            string area = this.areaComboBox3.Text;
            string county = this.countyComboBox3.Text;
            area = (area != anyOption ? area : String.Empty);
            county = (county != anyOption ? county : String.Empty);


            string feestring = this.transportfeeTextBox.Text.Trim();
            string newUnitname = this.unitnameComboBox4.Text.Trim();
            string newColumnname = this.columnnameComboBox4.Text.Trim();

            if (feestring.Length > 0 || newUnitname.Length > 0 || newColumnname.Length > 0)
            {
                decimal fee = 0;
                if (feestring.Length > 0) {
                    fee = Convert.ToDecimal(feestring);
                } 

                {

                    int count = OrderHelper.Updatetransportfee(warehouse_id, transport_id, shop_id, genre_id, product_id, area, county, fee, newUnitname, newColumnname);
                    if (count > 0)
                    {
                        //InitializeDataSource();
                        //InitializetransportdataGridView1();
                        bttransportfind_Click(null, EventArgs.Empty);
                        //initializeUnitnames();
                    }
                }
            }
            else {
                MessageBox.Show(string.Format("please input valid value 運賃={0}, 単位={1}, 订单字段={2} to update", feestring, newUnitname, newColumnname));
            }
        }

        // 根据当前选择的过滤条件查询运费
        private void InitializetransportdataGridViewBySelectedValue() {
            int shopid = Convert.ToInt32(this.shopComboBox3.SelectedValue);
            int warehouseid = Convert.ToInt32(this.warehouseComboBox5.SelectedValue);
            int transportid = Convert.ToInt32(this.transportComboBox6.SelectedValue);
            int productid = Convert.ToInt32(this.productsComboBox3.SelectedValue);
            int genreid = Convert.ToInt32(this.genresComboBox3.SelectedValue);
            string area = this.areaComboBox3.Text;
            string county = this.countyComboBox3.Text;
            area = (area != anyOption ? area : String.Empty);
            county = (county != anyOption ? county : String.Empty);

            if (warehouseid > 0 && transportid > 0 && genreid > 0)
            {

                InitializetransportdataGridView1(warehouseid, transportid, shopid, genreid, productid, area, county);
            }
            else {
                MessageBox.Show("请至少选择物流公司、仓库和产品分类作为查询条件！", "Warning", MessageBoxButtons.OK);
            }
        }

        private void genresComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MockEntity> productsByGenre;
            int genreId = (int)this.genresComboBox3.SelectedValue;

            if (genreId > 0)
            {
                productsByGenre = this.productList.Where(o => o.ジャンル == genreId).Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            else
            {
                productsByGenre = this.productList.Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            productsByGenre.Insert(0, new MockEntity { Id = 0, FullName = anyOption });

            this.productsComboBox3.ValueMember = "Id";
            this.productsComboBox3.DisplayMember = "FullName";
            this.productsComboBox3.DataSource = productsByGenre;
        }

        /// <summary>
        /// 基于现有条件，查询是否存在数据，如果没有则插入基于查询条件的运费数据
        /// 运输公司，仓库，商店，产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillMissingButton3_Click(object sender, EventArgs e)
        {
            int shop_id = Convert.ToInt32(this.shopComboBox3.SelectedValue);
            int warehouseid = Convert.ToInt32(this.warehouseComboBox5.SelectedValue);
            int transportid = Convert.ToInt32(this.transportComboBox6.SelectedValue);
            int productid = Convert.ToInt32(this.productsComboBox3.SelectedValue);
        }

        private void checkButton3_Click(object sender, EventArgs e)
        {
            var form = new Prices.MissingReportForm();
            form.ShowDialog();
        }

        private void areaComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.areaComboBox3.Text;
            List<string> counties;

            if (selected != anyOption)
            {
                counties = this.stores.Where(s => s.地域 == selected).Select(s => s.県別).Distinct().ToList();
            }
            else
            {
                counties = this.stores.Select(s => s.県別).Distinct().ToList();

            }
            counties.Insert(0, anyOption);

            this.countyComboBox3.DataSource = counties;
        }

        private void areaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.areaComboBox2.Text;
            List<string> counties;

            if (selected != anyOption)
            {
                counties = this.stores.Where(s => s.地域 == selected).Select(s => s.県別).Distinct().ToList();
            }
            else
            {
                counties = this.stores.Select(s => s.県別).Distinct().ToList();

            }
            counties.Insert(0, anyOption);

            this.countyComboBox2.DataSource = counties;
        }



    }
}
