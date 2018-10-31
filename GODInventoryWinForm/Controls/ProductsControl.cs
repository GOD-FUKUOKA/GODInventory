using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;
using System.Linq;
using System.Collections;

namespace GODInventoryWinForm.Controls
{
    public partial class ProductsControl : UserControl
    {
        List<t_shoplist> stores = null;
        List<t_genre> genres = null;
        List<t_itemlist> products = null;
        private List<t_warehouses> warehouseList;
        public ProductsControl()
        {
            InitializeComponent();

            //shopList = ctx.t_shoplist.ToList();
            this.pricesDataGridView.AutoGenerateColumns = false;
            this.productsDataGridView.AutoGenerateColumns = false;

           

        }


        private void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as GODDbContext;

            this.stores = ctx.t_shoplist.ToList();
            this.genres = ctx.t_genre.ToList();
            this.products = ctx.t_itemlist.ToList();

            var genreList = this.genres.Select(s => new MockEntity { Id = s.idジャンル, FullName = s.ジャンル名 }).ToList();
            genreList.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.genresComboBox.ValueMember = "Id";
            this.genresComboBox.DisplayMember = "FullName";
            this.genresComboBox.DataSource = genreList;
            //
            var counties = this.stores.Select(s => new MockEntity { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();

            counties.Insert(0, new MockEntity { ShortName = "", FullName = "すべて" });

            this.countyComboBox.ValueMember = "ShortName";
            this.countyComboBox.DisplayMember = "FullName";
            this.countyComboBox.DataSource = counties;

            this.pricesDataGridView.DataSource = null;
            this.costTextBox.Text = String.Empty;
            this.priceTextBox.Text = String.Empty;
            this.promotePriceTextBox.Text = String.Empty;
            this.adPriceTextBox.Text = String.Empty;
            this.salePriceTextBox.Text = String.Empty;

            //mark 20181022
            warehouseList = ctx.t_warehouses.ToList();
            var shipperCo = warehouseList.Select(s => new MockEntity { Id = s.Id, ShortName = s.ShortName, FullName = s.FullName }).Distinct().ToList();
           
            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = shipperCo;

            this.配送担当Column2.DisplayMember = "FullName";
            this.配送担当Column2.ValueMember = "FullName";
            this.配送担当Column2.DataSource = shipperCo.ToList();


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

            if (oids.Count() == 1 )
            {
                var form = new ProductsManagement(oids,"Update");
            
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
                    
            }

        }

        private void InitializePriceListDatagridView(int productCode, string county= "", int storeId = 0)
        {
             
            var query = from t_pricelist p in this.entityDataSource1.EntitySets["t_pricelist"]
                        join t_itemlist i in entityDataSource1.EntitySets["t_itemlist"] on p.自社コード equals i.自社コード

                        select new v_itemprice { 
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
                            特売原単価 = p.特売原単価
                                    
                        };
            if( county.Length>0)
            {
                query = query.Where(o => o.県別 == county);
            }

            if (storeId > 0)
            {
                query = query.Where(o => o.店番 == storeId);
            }
            if (productCode > 0)
            {
                query = query.Where(o => o.自社コード == productCode);
            }

            this.pricesBindingSource.DataSource = this.entityDataSource1.CreateView( query);
            this.pricesDataGridView.DataSource = this.pricesBindingSource;           
                         
        }

        private void editPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pricesDataGridView.RowCount > 0)
            {
                var price = pricesDataGridView.CurrentRow.DataBoundItem as v_itemprice;

                var form = new EditPriceForm( price.Id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    price.仕入原価 = form.Price.仕入原価;
                    price.原単価 = form.Price.通常原単価;
                    price.広告原単価 = form.Price.広告原単価;
                    price.特売原単価 = form.Price.特売原単価;
                    price.売単価 = form.Price.売単価;
                    this.pricesDataGridView.Refresh();
                    //MessageBox.Show("saved");
                }
            }
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int productCode = Convert.ToInt32(this.productsComboBox.SelectedValue);
            string county = this.countyComboBox.SelectedValue.ToString();
            int storeId = Convert.ToInt32(this.storesComboBox.SelectedValue);

            if (productCode > 0 || storeId >0)
            {
                InitializePriceListDatagridView(productCode, county, storeId);
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
            else {
                productsByGenre = this.products.Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();            
            }
            productsByGenre.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.productsComboBox.ValueMember = "Id";
            this.productsComboBox.DisplayMember = "FullName";
            this.productsComboBox.DataSource = productsByGenre;
        }

        private void countyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string county = this.countyComboBox.SelectedValue.ToString();
            List<MockEntity> storesByCounty;

            if (county.Length > 0)
            {
                storesByCounty = this.stores.Where(s => s.県別 == county).Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
            }
            else {
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
            string county = Convert.ToString(this.countyComboBox.SelectedValue);
            decimal cost = -1;
            decimal price = -1;
            decimal promotePrice = -1;
            decimal adPrice = -1;
            decimal salePrice = -1;
            string warehouse = "";

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
            //
            if (this.warehouseComboBox.Text.Trim().Length > 0)
            {
                warehouse = Convert.ToString(this.warehouseComboBox.Text);
            }


            if (productCode == 0)
            {
                MessageBox.Show("Please input ");
                return;
            }

            if (cost == -1 && price == -1 && promotePrice == -1 && adPrice == -1 && salePrice==-1)
            {
                MessageBox.Show("有効な単価を入力下さい");
                return;
            }



            int count = OrderHelper.UpdateProductCost(productCode, county, storeId, cost, price, promotePrice, adPrice, salePrice, warehouse);

            if (count > 0)
            {
                //MessageBox.Show(string.Format("update {0} prices successfully", count));

                InitializePriceListDatagridView(productCode, county, storeId);
            }
        }

    }
}
