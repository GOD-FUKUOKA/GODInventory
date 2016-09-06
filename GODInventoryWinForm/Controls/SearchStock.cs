using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;
using MySql.Data.MySqlClient;

namespace GODInventoryWinForm.Controls
{
    public partial class SearchStock : Form
    {
        private List<t_manufacturers> manufacturerList;
        //private List<MockEntity> manufacturerList;
        private BindingList<v_stockios> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;

        private List<v_stockcheck> productList = null;
        private List<t_stockrec> stockList = null;
        private List<t_stockrec> changedStockList = null;
        private List<t_stockrec> SavestockList = null;
        private List<t_stockrec> davStockSavestockList = null;
        private List<t_stockrec> davSHiRuStockSavestockList = null;

        int davx = 0;
        int davy = 0;

        public SearchStock()
        {
            InitializeComponent();

            stockiosList = new BindingList<v_stockios>();

            this.productDataGridView.AutoGenerateColumns = false;
            this.stockIoDataGridView.AutoGenerateColumns = false;
            this.qtyDataGridView.AutoGenerateColumns = false;

            this.productDataGridView.DataSource = stockiosList;

            InitializeDataSource();

            this.vScrollBar1.Visible = false;
            this.hScrollBar1.Visible = false;
            davStockSavestockList = new List<t_stockrec>();
            davSHiRuStockSavestockList = new List<t_stockrec>();
            SavestockList = new List<t_stockrec>();
            changedStockList = new List<t_stockrec>();

        }
        private void InitializeDataSource()
        {

            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.OrderBy(o => o.Position).ToList();
                manufacturerList = ctx.t_manufacturers.OrderBy(o => o.Position).ToList();
                warehouseList = ctx.t_warehouses.ToList();
            }
            this.genreComboBox.DisplayMember = "ジャンル名";
            this.genreComboBox.ValueMember = "idジャンル";
            this.genreComboBox.DataSource = genreList;
            t_manufacturers item = new t_manufacturers();
            item.Id = 0;
            item.genreId = 0;
            item.ShortName = "全部";
            item.FullName = "全部";
            manufacturerList.Insert(0, item);

            //this.manufacturerList = ManufactureRespository.ToList();
            this.manufacturerComboBox.DisplayMember = "FullName";
            this.manufacturerComboBox.ValueMember = "Id";
            this.manufacturerComboBox.DataSource = manufacturerList;

            warehouseList.Insert(0, new t_warehouses() { Id = 0, FullName = WarehouseRespository.OptionTextAll });
            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = warehouseList;

            this.manufacturerComboBox.SelectedIndex = 0;
            this.ioComboBox.SelectedIndex = 0;
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            stockiosList.Clear();
            var genre_id = GetGenreId();
            if (genre_id > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    var results = (from s in ctx.t_itemlist
                                   where s.ジャンル == (short)genre_id
                                   select new v_stockios { 自社コード = s.自社コード, 規格 = s.規格, 商品名 = s.商品名 }).ToList();
                    for (int i = 0; i < results.Count; i++)
                    {
                        results[i].Id = i + 1;
                        stockiosList.Add(results[i]);
                    }
                }
            }
        }

        private int GetGenreId()
        {

            return ((this.genreComboBox.SelectedIndex >= 0) ? (int)this.genreComboBox.SelectedValue : 0);
        }

        private void loadItemListButton_Click(object sender, EventArgs e)
        {
            this.FindDataSources();

            this.BindDataGridView();
        }

        private void btcanel_Click(object sender, EventArgs e)
        {
            this.BindDataGridView();
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            var deletedStockNumList = new List<string>();
            DataGridViewColumn col;
            string stockNum = null;

            //Save qty
            using (var ctx = new GODDbContext())
            {

                var ids = this.changedStockList.Select(s => s.id).ToArray();
                var list = (from s in ctx.t_stockrec
                            where ids.Contains(s.id)
                            select s).ToList();

                t_stockrec item;
                foreach (var changed in changedStockList)
                {
                    if (changed.id > 0)
                    {
                        item = list.Find(s => s.id == changed.id);
                        item.事由 = changed.事由;
                        item.数量 = changed.数量;
                        item.状態 = changed.状態;
                    }
                    else {
                        if (changed.数量 != 0)
                        {
                            ctx.t_stockrec.Add(changed);
                        }
                    }
                }

                ctx.SaveChanges();

                OrderSqlHelper.UpdateStockState(ctx, list);

            }

            for (int i = 0; i < stockIoDataGridView.ColumnCount; i++)
            {
                col = stockIoDataGridView.Columns[i];
                //if (!col.Visible)
                if (col.DefaultCellStyle.BackColor == System.Drawing.Color.Gray)
                {
                    stockNum = Convert.ToString(stockIoDataGridView.Rows[4].Cells[i].Value);
                    deletedStockNumList.Add(stockNum);
                }
            }
            if (deletedStockNumList.Count > 0)
            {
                int deletedCount = 0;
                using (var ctx = new GODDbContext())
                {
                    var stockrecs = (from s in ctx.t_stockrec
                                     where deletedStockNumList.Contains(s.納品書番号)
                                     select s).ToList();
                    ctx.t_stockrec.RemoveRange(stockrecs);
                    ctx.SaveChanges();

                    deletedCount = stockrecs.Count;
                    this.stockList.RemoveAll(s => deletedStockNumList.Contains(s.納品書番号));

                }
            }
            MessageBox.Show(String.Format("Congratulations, Items changed successfully!"));

            changedStockList.Clear();

            this.FindDataSources();
            this.BindDataGridView();
        }

        private void FindDataSources() {

            var startAt = this.startDateTimePicker.Value.AddDays(-1).Date;
            var endAt = this.endDateTimePicker.Value.AddDays(1).Date;
            var ioState = this.ioComboBox.Text;
            var genreId = Convert.ToInt16(this.genreComboBox.SelectedValue);
            var warehouse = this.warehouseComboBox.Text;
            var manufacturer = this.manufacturerComboBox.Text;

            var isAllManufacturerSelected = (manufacturer == ManufactureRespository.OptionTextAll);
            var isAllStockIoSelected = (ioState == StockIoEnum.全部.ToString());


            string conditions = "s.日付 > @startAt AND @endAt > s.日付";
            List<MySqlParameter> condition_params = new List<MySqlParameter>();

            #region 构建查询条件


            //            if (!isAllStockIoSelected)
            //            {
            //                conditions += " AND (s.`区分` = @ioState)";
            //            }
            //            if (!isAllManufacturerSelected)
            //            {
            //                // 所有仓库的某一生产商的出入库记录
            //                conditions += " AND (s.`工厂` = @manufacturer)";
            //            }


            //            if (warehouse != WarehouseRespository.OptionTextAll)
            //            {


            //                if (ioState == StockIoEnum.全部.ToString())
            //                {

            //                    // 某一个仓库的出入库记录
            //                    conditions += " AND ( s.先 = @warehouse OR s.元 = @warehouse )";

            //                }
            //                else if (ioState == StockIoEnum.入庫.ToString())
            //                {
            //                    // 某一个仓库的入库记录
            //                    conditions += " AND ( s.先 = @warehouse )";
            //                }
            //                else if (ioState == StockIoEnum.出庫.ToString())
            //                {

            //                    // 某一个仓库的所有生产商的出库记录, 即出库记录
            //                    conditions += " AND ( s.元 = @warehouse )";
            //                }
            //            }



            //condition_params.Add(new MySqlParameter("@genreId", genreId));
            //condition_params.Add(new MySqlParameter("@ioState", ioState));
            //condition_params.Add(new MySqlParameter("@warehouse", warehouse));
            //condition_params.Add(new MySqlParameter("@manufacturer", manufacturer));
            //condition_params.Add(new MySqlParameter("@startAt", startAt));
            //condition_params.Add(new MySqlParameter("@endAt", endAt));

            //            using (var ctx = new GODDbContext())
            //            {
            //                string productFormat = @"SELECT s.`自社コード`, i.`規格`,i.`商品名`  FROM t_stockrec s
            //INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = @genreId 
            //WHERE (s.日付 > @startAt AND @endAt > s.日付)
            //GROUP by s.`自社コード`;";
            //                string qtyFormat = @"SELECT s.* FROM t_stockrec s
            //INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = @genreId 
            //WHERE ({0});";

            //                productList = ctx.Database.SqlQuery<v_stockcheck>(productFormat, condition_params.ToArray()).ToList();
            //                string sql = String.Format(qtyFormat, conditions);
            //  stockList = ctx.Database.SqlQuery<t_stockrec>(sql, condition_params.ToArray()).ToList();

            //            }
            #endregion

            #region  new
            condition_params.Add(new MySqlParameter("@genreId", genreId));
            condition_params.Add(new MySqlParameter("@ioState", ioState));
            condition_params.Add(new MySqlParameter("@warehouse", warehouse));
            condition_params.Add(new MySqlParameter("@manufacturer", manufacturer));
            condition_params.Add(new MySqlParameter("@startAt", startAt));
            condition_params.Add(new MySqlParameter("@endAt", endAt));
            using (var ctx = new GODDbContext())
            {
                productList = (from s in ctx.t_itemlist
                               where s.ジャンル == (short)genreId
                               select new v_stockcheck { 自社コード = s.自社コード, 規格 = s.規格, 商品名 = s.商品名 }).ToList();
                string qtyFormat = @"SELECT s.* FROM t_stockrec s
            INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = @genreId 
             WHERE ({0});";
                string sql = String.Format(qtyFormat, conditions);
                stockList = ctx.Database.SqlQuery<t_stockrec>(sql, condition_params.ToArray()).ToList();

            }



            #endregion
        }

        private void BindDataGridView()
        {

            for (int i = 0; i < this.productList.Count; i++)
            {

                this.productList[i].Id = i + 1;
            }

            this.productDataGridView.DataSource = productList;

            var qtyTable = new DataTable();
            var ioTable = new DataTable();

            this.stockIoDataGridView.Columns.Clear();
            this.qtyDataGridView.Columns.Clear();
            int j = 0;

            var groupedStockList = stockList.GroupBy(s => s.納品書番号);

            #region 构建 DataTable


            // build table columns
            j = 0;
            foreach (var igrouping in groupedStockList)
            {
                // 生成 ioTable, use c{j}  instead of igrouping.Key, datagridview required
                ioTable.Columns.Add(igrouping.Key, System.Type.GetType("System.String"));
                qtyTable.Columns.Add(igrouping.Key, System.Type.GetType("System.Int32"));
            }
            // build table rows
            for (var i = 0; i < 5; i++)
            {

                ioTable.Rows.Add(ioTable.NewRow());
            }

            foreach (var k in productList)
            {
                qtyTable.Rows.Add(qtyTable.NewRow());
            }
            j = 0;
            foreach (var igrouping in groupedStockList)
            {
                var item = igrouping.First();
                //igrouping.Key cause add new column
                ioTable.Rows[0][j] = string.Format("{0:yyyyMMdd}", item.日付);
                ioTable.Rows[1][j] = item.区分;
                ioTable.Rows[2][j] = item.事由;
                ioTable.Rows[3][j] = item.状態;
                ioTable.Rows[4][j] = item.納品書番号;
                j++;
            }

            var groupedProductCodeList = stockList.GroupBy(s => s.自社コード);
            foreach (var igrouping in groupedProductCodeList)
            {
                var i = productList.FindIndex(o => o.自社コード == igrouping.Key);
                foreach (var stock in igrouping.ToList())
                {
                    qtyTable.Rows[i][stock.納品書番号] = Math.Abs( (int)stock.数量 );
                }
            }

            #endregion


            #region DataGridView 数据绑定

            qtyDataGridView.Columns.Clear();
            stockIoDataGridView.Columns.Clear();
            foreach (var igrouping in groupedStockList)
            {
                qtyDataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Width = 80, DataPropertyName = igrouping.Key });
                stockIoDataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Width = 80, DataPropertyName = igrouping.Key });
            }
            qtyDataGridView.DataSource = qtyTable;
            stockIoDataGridView.DataSource = ioTable;

            //
            if (stockIoDataGridView.RowCount > 4)
            {
                this.stockIoDataGridView.ReadOnly = false;
                this.stockIoDataGridView.Rows[4].ReadOnly = true;
                this.stockIoDataGridView.Rows[0].ReadOnly = true;
                this.stockIoDataGridView.Rows[1].ReadOnly = true;
            }

            if (stockIoDataGridView.Rows.Count == 5)
            {
                stockIoDataGridView.Rows[4].Height = 23 * 2;
            }
            #endregion

            InitializeScrollBar();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = stockIoDataGridView.CurrentCell.OwningColumn.Index;
            //stockIoDataGridView.Columns[i].Visible = false;
            this.stockIoDataGridView.Columns[i].DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.qtyDataGridView.Columns[i].DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            //qtyDataGridView.Columns[i].Visible = false;
        }

        private void stockIoDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {

                    stockIoDataGridView.ClearSelection();
                    stockIoDataGridView.Columns[e.ColumnIndex].Selected = true;
                    stockIoDataGridView.CurrentCell = stockIoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //contextMenuStrip_ListViewItemRightClick.Show（MousePosition.X， MousePosition.Y）; 
                }
            }
        }

        private void qtyDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            // http://stackoverflow.com/questions/4766409/how-do-i-programmatically-scroll-a-winforms-datagridview-control
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                productDataGridView.FirstDisplayedScrollingRowIndex = this.qtyDataGridView.FirstDisplayedScrollingRowIndex;
            }
            else
            {

                this.stockIoDataGridView.HorizontalScrollingOffset = e.NewValue;

            }
        }

        private void InitializeScrollBar()
        {

            int voverflow = (23 + 1) * this.productDataGridView.RowCount - this.productDataGridView.Height;
            int hoverflow = (80 + 1) * this.qtyDataGridView.Columns.Count - this.qtyDataGridView.Width;

            if (hoverflow > 0)
            {
                hScrollBar1.SmallChange = 20;
                hScrollBar1.Maximum = hoverflow;
            }

            if (voverflow > 0)
            {

                hScrollBar1.SmallChange = 23;
                vScrollBar1.Maximum = voverflow + 22;
            }

            hScrollBar1.Visible = (hoverflow > 0);
            vScrollBar1.Visible = (voverflow > 0);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.qtyDataGridView.HorizontalScrollingOffset = e.NewValue;
            this.stockIoDataGridView.HorizontalScrollingOffset = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            this.productDataGridView.FirstDisplayedScrollingRowIndex = e.NewValue / 23;
            if (this.qtyDataGridView.RowCount > 0)
            {
                this.qtyDataGridView.FirstDisplayedScrollingRowIndex = e.NewValue / 23;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 选择 修改状态，由“仮”改为“完了”，或者相反。
            //if (stockIoDataGridView.CurrentCell.RowIndex == 3)
            //{
            //    int j = stockIoDataGridView.CurrentCell.ColumnIndex;
            //    string stockNum = Convert.ToString(stockIoDataGridView.Rows[4].Cells[j].Value);
            //    string progress = (string)stockIoDataGridView.CurrentCell.Value;
            //    using (var ctx = new GODDbContext())
            //    {
            //        var changeList = this.stockList.FindAll(s => s.納品書番号 == stockNum);
            //        if (progress == StockIoProgressEnum.完了.ToString())
            //        {
            //            var list = (from s in ctx.t_stockrec
            //                        where s.納品書番号 == stockNum
            //                        select s).ToList();
            //            foreach (var item in list)
            //            {
            //                item.状態 = StockIoProgressEnum.仮.ToString();
            //            }
            //            stockIoDataGridView.CurrentCell.Value = StockIoProgressEnum.仮.ToString();

            //        }
            //        else if (progress == StockIoProgressEnum.仮.ToString())
            //        {
            //            var list = (from s in ctx.t_stockrec
            //                        where s.納品書番号 == stockNum
            //                        select s).ToList();
            //            foreach (var item in list)
            //            {
            //                item.状態 = StockIoProgressEnum.完了.ToString();
            //                davStockSavestockList.Add(item);

            //            }
            //            stockIoDataGridView.CurrentCell.Value = StockIoProgressEnum.完了.ToString();
            //        }
            //        //   ctx.SaveChanges();
            //    }
            //}
            //else if (stockIoDataGridView.CurrentCell.RowIndex == 2)
            //{

            //}

        }

        private void genreComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var filtered = manufacturerList.FindAll(s => s.genreId == (int)this.genreComboBox.SelectedValue || s.Id == 0);

            if (filtered.Count > 0)
            {
                //t_manufacturers item = new t_manufacturers();
                //item.Id = 0;
                //item.genreId = 0;
                //item.ShortName = "全部";
                //item.FullName = "全部";
                //filtered.Add(item);
                this.manufacturerComboBox.DataSource = filtered;
            }
            else
            {
                this.manufacturerComboBox.DataSource = manufacturerList;

            }
        }

        private void stockIoDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            // 选择 修改状态，由“仮”改为“完了”，或者相反。

            string stockNum = GetStockNumByColumnIndex(e.ColumnIndex);


            var changeList = this.stockList.FindAll(s => s.納品書番号 == stockNum);

            foreach (var item in changeList)
            {
                if (e.RowIndex == 2)//事由
                {
                    item.事由 = stockIoDataGridView.CurrentCell.Value.ToString();
                }
                else if (e.RowIndex == 3)//状態
                {
                    item.状態 = stockIoDataGridView.CurrentCell.Value.ToString();
                }

            }
            this.changedStockList.AddRange(changeList);

        }

        private void qtyDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string stockNum = GetStockNumByColumnIndex(e.ColumnIndex);

            int productNum = GetProductNumByRowIndex(e.RowIndex);

            t_stockrec stock = this.stockList.Find(o => (o.自社コード == productNum && o.納品書番号 == stockNum));
            if (stock == null) {
                var originalStock = this.stockList.Find(o => ( o.納品書番号 == stockNum));
                stock = new t_stockrec();
                stock.納品書番号 = originalStock.納品書番号;
                stock.工厂 = originalStock.工厂;
                stock.客户 = originalStock.客户;
                stock.区分 = originalStock.区分;
                stock.事由 = originalStock.事由;
                stock.元 = originalStock.元;
                stock.先 = originalStock.先;
                stock.状態 = originalStock.状態;
                stock.日付 = originalStock.日付;
                stock.自社コード = productNum;
            }
            int qty = Convert.ToInt32(qtyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            stock.数量 =  (stock.区分 == StockIoEnum.入庫.ToString() ? qty : -qty) ;
            this.changedStockList.Add(stock);
        }

        private string GetStockNumByColumnIndex(int j)
        {

            return Convert.ToString(this.stockIoDataGridView.Rows[4].Cells[j].Value);

        }

        private int GetProductNumByRowIndex(int i)
        {
            return Convert.ToInt32(this.productList[i].自社コード);

        }

        private void qtyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
