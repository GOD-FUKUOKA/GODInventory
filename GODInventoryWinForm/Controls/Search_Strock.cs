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
    public partial class Search_Strock : Form
    {
        private List<MockEntity> manufacturerList;
        private BindingList<v_stockios> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;

        private List<v_stockcheck> productList = null;
        private List<t_stockrec> stockList = null;

        public Search_Strock()
        {
            InitializeComponent();

            stockiosList = new BindingList<v_stockios>();

            this.productDataGridView.AutoGenerateColumns = false;
            this.stockIoDataGridView.AutoGenerateColumns = false;
            this.qtyDataGridView.AutoGenerateColumns = false;

            this.productDataGridView.DataSource = stockiosList;

            InitializeDataSource();

            #region MyRegion
            //var ctx1 = entityDataSource1.DbContext as GODDbContext;
            //this.t_stocklistR = ctx1.t_stockrec.Select(s => s).ToList();
            ////this.t_stocklistR  =( from v in ctx1.t_stockrec. Select (s => s)).Distinct();

            //var value = (from v in ctx1.t_stockrec select v.自社コード).Distinct().ToList();

            //using (var ctx = new GODDbContext())
            //{
            //    t_manufacturersR = ctx.t_manufacturers.ToList();

            //    t_genreR = ctx.t_genre.ToList();
            //    //   t_stocklistR = ctx.t_stockrec.ToList();
            //}
            //this.dataGridView1.AutoGenerateColumns = false;
            //this.dataGridView1.DataSource = value;

            //OrderSqlHelper item12 = new OrderSqlHelper();

            //string[] ll = item12.Strock_QuFenout();
            //for (int j = 0; j < ll.Length; j++)
            //{
            //    this.comboBox1.Items.Add(ll[j]);
            //}
            //string[] llp = item12.StrockReback();
            //for (int j = 0; j < llp.Length; j++)
            //{
            //    this.comboBox2.Items.Add(llp[j]);
            //}
            //foreach (t_genre item in t_genreR)
            //{
            //    this.comboBox3.Items.Add(item.ジャンル名);
            //}
            //foreach (t_manufacturers item in t_manufacturersR)
            //{
            //    this.comboBox4.Items.Add(item.FullName);
            //}

            ////   InitializePager();
            ////this.dataGridView2.AllowUserToAddRows = false;
            ////this.dataGridView2.DataSource = t_stocklistR;

            //list = new List<DateTime>();
            //納品書番号list = new List<string>();

            //foreach (t_stockrec item in t_stocklistR)
            //{
            //    int dou = 0;

            //    for (int i = 0; i < list.Count; i++)
            //        if (item.日付 == list[i])
            //            dou++;
            //    if (dou == 0)
            //        list.Add(item.日付);
            //    int doub = 0;

            //    for (int j = 0; j < 納品書番号list.Count; j++)
            //        if (item.納品書番号 == 納品書番号list[j])
            //            doub++;
            //    if (doub == 0)
            //        納品書番号list.Add(item.納品書番号);

            //} 
            #endregion

        }
        private void InitializeDataSource()
        {

            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.ToList();
                warehouseList = ctx.t_warehouses.ToList();
            }
            this.genreComboBox.DisplayMember = "ジャンル名";
            this.genreComboBox.ValueMember = "idジャンル";
            this.genreComboBox.DataSource = genreList;


            this.manufacturerList = ManufactureRespository.ToList();
            this.manufacturerComboBox.DisplayMember = "FullName";
            this.manufacturerComboBox.ValueMember = "Id";
            this.manufacturerComboBox.DataSource = manufacturerList;

            warehouseList.Add(new t_warehouses() { Id = 0, FullName = WarehouseRespository.OptionTextAll });
            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = warehouseList;


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

            var startAt = this.startDateTimePicker.Value.AddDays(-1).Date;
            var endAt = this.endDateTimePicker.Value.AddDays(1).Date;
            var ioState = this.ioComboBox.Text;
            var genreId = Convert.ToInt16(this.genreComboBox.SelectedValue);
            var warehouse = this.warehouseComboBox.Text;
            var manufacturer = this.manufacturerComboBox.Text;

            var isAllManufacturerSelected = ( manufacturer == ManufactureRespository.OptionTextAll );
            var isAllStockIoSelected = (ioState == StockIoEnum.全部.ToString());


                string conditions = "s.日付 > @startAt AND @endAt > s.日付";
                List<MySqlParameter> condition_params = new  List<MySqlParameter>();

                #region 构建查询条件


                if ( !isAllStockIoSelected )
                {
                    conditions += " AND (s.`区分` = @ioState)";
                }
                            
                if( warehouse != WarehouseRespository.OptionTextAll) {
                    
                     conditions += " AND ";
                    
                    if (ioState == StockIoEnum.全部.ToString())
                    {
                        if (isAllManufacturerSelected){
                            // 某一个仓库的所有生产商的出入库记录
                            conditions += "( s.元 = @warehouse OR s.先 = @warehouse )";
                        }else
                        {
                            // 某一个仓库的某一生产商的出入库记录
                            conditions += "((s.`元` = @manufacturer AND  s.先 = @warehouse ) OR (s.`元` = @warehouse AND  s.先 = @manufacturer ))";
                        }                            
                    }
                    else if (ioState == StockIoEnum.入庫.ToString()) {
                        if (isAllManufacturerSelected){
                            // 某一个仓库的所有生产商的入库记录
                            conditions += "( s.先 = @warehouse )";
                        }else{
                            // 某一个仓库的某一生产商的入库记录
                            conditions += "( s.`元` = @manufacturer AND  s.先 = @warehouse )";
                        }
                    }
                    else if (ioState == StockIoEnum.出庫.ToString()) { 
                        if (isAllManufacturerSelected){
                            // 某一个仓库的所有生产商的出库记录, 即出库记录
                            conditions += "( s.元 = @warehouse )";
                        }else{
                            // 某一个仓库的某一生产商的出库记录
                            conditions += "( s.元 = @warehouse AND s.`先` = @manufacturer )";
                        }
                    }
                }else{
                    if (!isAllManufacturerSelected ){
                        // 所有仓库的某一生产商的出入库记录
                        conditions += " AND (s.`元` = @manufacturer OR  s.先 = @manufacturer )";
                    }
                }


                condition_params.Add(new MySqlParameter("@genreId", genreId));
                condition_params.Add(new MySqlParameter("@ioState", ioState));
                condition_params.Add(new MySqlParameter("@warehouse", warehouse));
                condition_params.Add(new MySqlParameter("@manufacturer", manufacturer));
                condition_params.Add(new MySqlParameter("@startAt", startAt));
                condition_params.Add(new MySqlParameter("@endAt", endAt));

                using (var ctx = new GODDbContext())
                {
                    string productFormat = @"SELECT s.`自社コード`, i.`規格`,i.`商品名`  FROM t_stockrec s
INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = @genreId 
WHERE (s.日付 > @startAt AND @endAt > s.日付)
GROUP by s.`自社コード`;";
                    string qtyFormat = @"SELECT s.* FROM t_stockrec s
INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = @genreId 
WHERE ({0});";

                    productList = ctx.Database.SqlQuery<v_stockcheck>(productFormat, condition_params.ToArray()).ToList();
                    string sql = String.Format(qtyFormat,  conditions);
                    stockList = ctx.Database.SqlQuery<t_stockrec>(sql, condition_params.ToArray()).ToList();

                }
                #endregion


                this.BuildDataSources();

              
            
        }

        private void btcanel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < stockIoDataGridView.ColumnCount; i++)
            {
                stockIoDataGridView.Columns[i].Visible = true;
                qtyDataGridView.Columns[i].Visible = true;
            }
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            var deletedList = new List<t_stockrec>();
            DataGridViewColumn col ;
            string stockNum = null;
            for (int i = 0; i < stockIoDataGridView.ColumnCount; i++){
                col = stockIoDataGridView.Columns[i];
                if( !col.Visible ){
                
                    stockNum = Convert.ToString( stockIoDataGridView.Rows[4].Cells[i].Value );
                    deletedList.AddRange( this.stockList.FindAll( s=>s.納品書番号 == stockNum) );
                }
            
            }


            if (deletedList.Count > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    ctx.t_stockrec.RemoveRange(deletedList);
                    ctx.SaveChanges();
                    foreach( var stock in deletedList){
                      this.stockList.Remove(stock);
                    }
                }
                MessageBox.Show(String.Format("Congratulations, You have {0} items removed successfully!", deletedList.Count));

            }
            else
            {
                MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void BuildDataSources(){
        
            for (int i = 0; i < this.productList.Count; i++) {

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
            for (var i = 0; i < 5; i++) {

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
                ioTable.Rows[0][j] = string.Format("{0:HH:mm:ss}", item.日付);
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
                foreach (var stock in igrouping.ToList()) {
                    qtyTable.Rows[i][stock.納品書番号] = stock.数量;
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

            if( ioTable.Rows.Count>0){
                stockIoDataGridView.Rows[4].Height = 23 * 2;
            }
            #endregion

            InitializeScrollBar();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = stockIoDataGridView.CurrentCell.OwningColumn.Index;
            stockIoDataGridView.Columns[i].Visible = false;
            qtyDataGridView.Columns[i].Visible = false;
        }

        private void stockIoDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            { 
               if (e.RowIndex >= 0) 
               {
                   stockIoDataGridView.ClearSelection();
                   stockIoDataGridView.Rows[e.RowIndex].Selected = true;
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
            else {

                this.stockIoDataGridView.HorizontalScrollingOffset = e.NewValue;            
            
            }
        }

        private void InitializeScrollBar(){

            int voverflow = (23 + 1) * this.productDataGridView.RowCount - this.productDataGridView.Height;
            int hoverflow = (80+1) * this.qtyDataGridView.Columns.Count - this.qtyDataGridView.Width;
           
            if (hoverflow > 0)
            {
                hScrollBar1.SmallChange = 20;
                hScrollBar1.Maximum = hoverflow;
            }

            if (voverflow > 0) {

                hScrollBar1.SmallChange = 23;
                vScrollBar1.Maximum = voverflow ;            
            }

            hScrollBar1.Visible = (hoverflow > 0);
            hScrollBar1.Visible = (voverflow > 0);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.qtyDataGridView.HorizontalScrollingOffset = e.NewValue;
            this.stockIoDataGridView.HorizontalScrollingOffset = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            this.productDataGridView.FirstDisplayedScrollingRowIndex = e.NewValue/23;
            this.qtyDataGridView.FirstDisplayedScrollingRowIndex = e.NewValue/23;
        }

        #region MyRegion
        //#region Pager Methods

        //public void InitializePager()
        //{
        //    this.pager1.PageCurrent = 1; //当前页为第一页   
        //    this.pager1.PageSize = 5000; //页数   
        //    this.pager1.Bind();
        //}


        //#endregion
        //private void btFind_Click(object sender, EventArgs e)
        //{
        //    //ApplyFilter();

        //    //ApplyFilter2();
        //    //筛选出一个自社コード  ，一个日期，納品書番号  下的所有数量

        //    D2_t_stocklistR = new List<t_stockrec>();
        //    list = new List<DateTime>();

        //    //for (int ii = 0; ii < 納品書番号list.Count; ii++)
        //    {
        //        for (int i = 0; i < dataGridView1.RowCount; i++)
        //        {

        //            string 自社コード = dataGridView1.Rows[i].Cells["自社コード"].EditedFormattedValue.ToString();
        //            var locations = this.t_stocklistR.Where(l => l.自社コード == Convert.ToInt32(自社コード)).ToList();

        //            t_stockrec item = new t_stockrec();

        //            foreach (var emp in locations)
        //            {
        //                int dou = 0;
        //                //将日期归类

        //                for (int iindex = 0; iindex < list.Count; iindex++)
        //                    if (item.日付 == list[iindex])
        //                        dou++;
        //                if (dou == 0)
        //                    list.Add(item.日付);
        //                //if (emp.納品書番号 == 納品書番号list[ii])
        //                {
        //                    item.自社コード = emp.自社コード;
        //                    item.数量 = item.数量 + emp.数量;
        //                    item.納品書番号 = emp.納品書番号;
        //                    item.日付 = emp.日付;
        //                    item.区分 = emp.区分;
        //                }
        //            }
        //            if (item.自社コード != null && item.自社コード != 0)
        //                D2_t_stocklistR.Add(item);
        //        }

        //        //dataGridView2.Rows[i].Cells[16].Value = item.日付;
        //        //dataGridView2.Rows[i].Cells[16].Value = item.日付;
        //    }
        //    int cloumnindex = 1;

        //    for (int j = 0; j < list.Count; j++)
        //    {
        //        int introwindex = 4;
        //        if (list[j] == null)
        //            continue;
        //        int cahc = introwindex;

        //        for (int i = 0; i < dataGridView1.RowCount; i++)
        //        {

        //            string 自社コード = dataGridView1.Rows[i].Cells["自社コード"].EditedFormattedValue.ToString();
        //            var locations = this.t_stocklistR.Where(l => l.自社コード == Convert.ToInt32(自社コード)).ToList();
        //            t_stockrec temp = new t_stockrec();

        //            //foreach (t_stockrec item in D2_t_stocklistR)
        //            foreach (var emp in locations)
        //            {

        //                #region MyRegion
        //                //if (item.納品書番号 == null)
        //                //    continue;

        //                //if (item.日付 == list[j] && item.自社コード.ToString() == 自社コード)
        //                //{
        //                //    introwindex++;
        //                //    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

        //                //    //DataGridViewColumn column = new DataGridViewColumn();
        //                //    this.dataGridView2.Rows.Add();
        //                //    column.HeaderText = cloumnindex.ToString();
        //                //    column.Name = "msisndColumn";
        //                //    column.HeaderText = "Klic";
        //                //    //this.dataGridView2.Columns.Add(column);
        //                //    dataGridView2.Columns.Insert(1, column);
        //                //    column.CellTemplate = new DataGridViewTextBoxCell();

        //                //    dataGridView2.Rows[1].Cells[cloumnindex].Value = item.日付.ToString("MM/dd/yyyy");
        //                //    this.dataGridView2.Rows.Add();
        //                //    dataGridView2.Rows[2].Cells[cloumnindex].Value = item.区分;
        //                //    this.dataGridView2.Rows.Add();
        //                //    dataGridView2.Rows[3].Cells[cloumnindex].Value = item.事由;
        //                //    this.dataGridView2.Rows.Add();
        //                //    dataGridView2.Rows[4].Cells[cloumnindex].Value = item.納品書番号;
        //                //    this.dataGridView2.Rows.Add();
        //                //    dataGridView2.Rows[introwindex].Cells[cloumnindex].Value = item.数量;
        //                //} 
        //                #endregion

        //                if (emp.納品書番号 == null && list[j] != emp.日付)
        //                    continue;

        //                temp.自社コード = emp.自社コード;
        //                temp.数量 = temp.数量 + emp.数量;
        //                temp.納品書番号 = emp.納品書番号;
        //                temp.日付 = emp.日付;
        //                temp.区分 = emp.区分;
        //            }

        //            #region MyRegion


        //            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

        //            //DataGridViewColumn column = new DataGridViewColumn();
        //            this.dataGridView2.Rows.Add();
        //            column.HeaderText = cloumnindex.ToString();
        //            column.Name = "msisndColumn";
        //            column.HeaderText = "Klic";
        //            //this.dataGridView2.Columns.Add(column);
        //            dataGridView2.Columns.Insert(1, column);
        //            column.CellTemplate = new DataGridViewTextBoxCell();
        //            if (cahc == introwindex)
        //            {
        //                dataGridView2.Rows[1].Cells[cloumnindex].Value = temp.日付.ToString("MM/dd/yyyy");
        //                this.dataGridView2.Rows.Add();
        //                dataGridView2.Rows[2].Cells[cloumnindex].Value = temp.区分;
        //                this.dataGridView2.Rows.Add();
        //                dataGridView2.Rows[3].Cells[cloumnindex].Value = temp.事由;
        //                this.dataGridView2.Rows.Add();
        //                dataGridView2.Rows[4].Cells[cloumnindex].Value = temp.納品書番号;
        //            }

        //            this.dataGridView2.Rows.Add();
        //            introwindex++;
        //            dataGridView2.Rows[introwindex].Cells[cloumnindex].Value = temp.数量;

        //            #endregion
        //        }


        //    }

        //    //this.dataGridView2.AllowUserToAddRows = true;
        //    //this.dataGridView2.DataSource = D2_t_stocklistR;
        //    dataGridView2.RowHeadersVisible = false;
        //    dataGridView2.ColumnHeadersVisible = false;
        //}
        //private void ApplyFilter()
        //{
        //    string filter = "";
        //    if (this.comboBox1.Text.Length > 0)
        //    {
        //        filter += "(区分=" + "'" + this.comboBox1.Text + "'" + ")";
        //    }
        //    if (this.comboBox2.Text.Length > 0)
        //    {
        //        if (filter.Length > 0)
        //        {
        //            filter += " AND ";
        //        }
        //        filter += "(仓库=" + "'" + this.comboBox2.Text + "'" + ")";
        //    }
        //    if (this.comboBox3.Text.Length > 0)
        //    {
        //        if (filter.Length > 0)
        //        {
        //            filter += " AND ";
        //        }
        //        filter += "(商品別=" + "'" + this.comboBox3.Text + "'" + ")";
        //    }
        //    if (this.comboBox4.Text.Length > 0)
        //    {
        //        if (filter.Length > 0)
        //        {
        //            filter += " AND ";
        //        }
        //        filter += "(工場=" + "'" + this.comboBox4.Text + "'" + ")";
        //    }
        //    this.bindingSource1.Filter = filter;

        //}


        //private void ApplyFilter2()
        //{
        //    string filter = "";
        //    if (this.comboBox1.Text.Length > 0)
        //    {
        //        filter += "(区分=" + "'" + this.comboBox1.Text + "'" + ")";
        //    }
        //    if (this.comboBox2.Text.Length > 0)
        //    {
        //        if (filter.Length > 0)
        //        {
        //            filter += " AND ";
        //        }
        //        filter += "(仓库=" + "'" + this.comboBox2.Text + "'" + ")";
        //    }
        //    if (this.comboBox3.Text.Length > 0)
        //    {
        //        if (filter.Length > 0)
        //        {
        //            filter += " AND ";
        //        }
        //        filter += "(商品別=" + "'" + this.comboBox3.Text + "'" + ")";
        //    }
        //    if (this.comboBox4.Text.Length > 0)
        //    {
        //        if (filter.Length > 0)
        //        {
        //            filter += " AND ";
        //        }
        //        filter += "(工場=" + "'" + this.comboBox4.Text + "'" + ")";
        //    }
        //    this.bindingSource1.Filter = filter;

        //}



        //#region MyRegion

        //private int InitializeOrderData()
        //{
        //    // 记录DataGridView改变数据
        //    this.datagrid_changes = new Hashtable();

        //    //var ctx = entityDataSource1.DbContext as GODDbContext;
        //    //var stockstates = ctx.t_stockstate.Select(s => s).ToList();
        //    var cq = OrderSqlHelper.stockQuery(entityDataSource1);
        //    var count = cq.Count();

        //    if (count > 0)
        //    {
        //        var q = OrderSqlHelper.stockQuery(entityDataSource1);
        //        // 分页

        //        if (pager1.PageCurrent > 1)
        //        {
        //            q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
        //        }
        //        q = q.Take(pager1.OffSet(pager1.PageCurrent));

        //        // create BindingList (sortable/filterable)
        //        var bindinglist = entityDataSource1.CreateView(q) as EntityBindingList<t_stockrec>;

        //        // count 计算t_orderdata 表， list 是 orderdata join itemlist join stockstate
        //        // 所以有可能 bindinglist is null 
        //        var list = new List<t_stockrec>();
        //        if (bindinglist != null)
        //        {
        //            list = bindinglist.ToList();
        //        }


        //        IEnumerable<IGrouping<int, t_stockrec>> grouped_orders = list.GroupBy(o => o.自社コード, o => o);
        //        foreach (var gos in grouped_orders)
        //        {
        //            int total = 0;

        //            foreach (var o in gos)
        //            {
        //                //total += o.発注数量;

        //                //if (o.在庫数 >= total)
        //                //{
        //                //    o.在庫状態 = "あり";
        //                //}
        //                //else if (o.在庫数 > o.口数)
        //                //{
        //                //    o.在庫状態 = "一部不足";
        //                //}
        //                //else
        //                //{
        //                //    o.在庫状態 = "なし";
        //                //}
        //            }
        //        }
        //        this.bindingSource1.DataSource = bindinglist;
        //        // assign BindingList to grid


        //    }
        //    else
        //    {
        //        this.bindingSource1.DataSource = null;
        //    }
        //    dataGridView1.DataSource = this.bindingSource1;

        //    return count;
        //}

        //#endregion

        //private int pager1_EventPaging(EventPagingArg e)
        //{
        //    {
        //        int order_count = InitializeOrderData();

        //        return order_count;
        //    }
        //}
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ApplyBindSourceFilter(comboBox1.Text);
        //}
        //private void ApplyBindSourceFilter(string text)
        //{
        //    if (comboBox1.Text == String.Empty || comboBox1.Text == "All")
        //    {
        //        bindingSource1.Filter = "";
        //    }
        //    else
        //    {
        //        bindingSource1.Filter = "区分='" + comboBox1.Text + "'";
        //    }
        //}

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ApplyBindSourceFilter1(comboBox1.Text);
        //}
        //private void ApplyBindSourceFilter1(string text)
        //{
        //    //if (comboBox2.Text == String.Empty || comboBox2.Text == "All")
        //    //{
        //    //    bindingSource1.Filter = "";
        //    //}
        //    //else
        //    //{
        //    //    bindingSource1.Filter = "仓库='" + comboBox2.Text + "'";
        //    //}
        //}

        //private void btSave_Click(object sender, EventArgs e)
        //{
        //    if (t_stocklistR.Count > 0)
        //    {
        //        using (var ctx = new GODDbContext())
        //        {
        //            ctx.t_stockrec.AddRange(t_stocklistR);
        //            ctx.SaveChanges();
        //            MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stocklist.Count));
        //            t_stocklistR.Clear();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        //private void btcanel_Click(object sender, EventArgs e)
        //{
        //    ApplyFilter();

        //}

        //private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewColumn column = new DataGridViewColumn();
        //    this.dataGridView2.Rows.Add();
        //    dataGridView2.Columns[0].HeaderCell.Value = "编号";

        //    //dataGridView2.Columns.Add(column);
        //    dataGridView2.Rows[1].HeaderCell.Value = "编号2";

        //    //dataGridView2.Columns.Add(column);
        //    //this.dataGridView2.RepeatDirection = "Vertical";


        //}

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        #endregion

    }
}
