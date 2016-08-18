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

namespace GODInventoryWinForm.Controls
{
    public partial class Search_Strock : Form
    {
        private List<MockEntity> manufacturerList;
        private BindingList<v_stockios> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;

        private List<v_stockrec> stockrecList;


        public Search_Strock()
        {
            InitializeComponent();

            stockiosList = new BindingList<v_stockios>();

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = stockiosList;

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


            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = warehouseList;


            //BuildStockNO();
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
            stockrecList = new List<v_stockrec>();

            using (var ctx = new GODDbContext())
            {
                var results = new List<v_stockrec>();
                if (区分comboBox1.Text != "All")
                {
                    results = (from s in ctx.t_stockrec
                               where s.区分 == 区分comboBox1.Text && s.先 == manufacturerComboBox.Text && s.元 == warehouseComboBox.Text && s.日付 > this.orderCreatedAtDateTimePicker.Value && this.dateTimePicker1.Value > s.日付
                               select new v_stockrec { 自社コード = s.自社コード, 日付 = s.日付, 区分 = s.区分, 出庫事由 = s.出庫事由, 納品書番号 = s.納品書番号, 数量 = s.数量 }).ToList();
                }
                else
                    results = (from s in ctx.t_stockrec
                               where s.先 == manufacturerComboBox.Text && s.元 == warehouseComboBox.Text && s.日付 > this.orderCreatedAtDateTimePicker.Value && this.dateTimePicker1.Value > s.日付
                               select new v_stockrec { 自社コード = s.自社コード, 日付 = s.日付, 区分 = s.区分, 出庫事由 = s.出庫事由, 納品書番号 = s.納品書番号, 数量 = s.数量 }).ToList();


                //dataGridView2.RowHeadersVisible = false;
                //dataGridView2.ColumnHeadersVisible = false;
                //this.dataGridView2.DataSource = results;

                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                DataGridViewTextBoxColumn columnil = new DataGridViewTextBoxColumn();
                columnil.HeaderText = "1";
                columnil.Name = "1";
                dataGridView2.Columns.Insert(0, columnil);
                columnil.CellTemplate = new DataGridViewTextBoxCell();


                #region 显示结果对应到相应的列中
                var value = (from v in results select v.日付).Distinct().ToList();
                for (int i = 0; i < dataGridView1.RowCount + 4; i++)
                {
                    this.dataGridView2.Rows.Add();

                }

                int cloumni = 1;
                foreach (var emp in value)
                {

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string 自社コード = dataGridView1.Rows[i].Cells["自社コード"].EditedFormattedValue.ToString();
                        v_stockrec item = new v_stockrec();
                        item.数量 = 0;

                        foreach (var temp in results)
                        {
                            if (emp == temp.日付 && 自社コード == temp.自社コード.ToString())
                            {
                                item.数量 = temp.数量 + item.数量;
                                item.区分 = temp.区分;
                                item.出庫事由 = temp.出庫事由;
                                item.納品書番号 = temp.納品書番号;
                            }
                        }
                        if (i == 0)
                        {
                            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                            column.HeaderText = emp.ToString("MM/dd/yyyy");
                            column.Name = emp.ToString();

                            dataGridView2.Columns.Insert(cloumni, column);
                            column.CellTemplate = new DataGridViewTextBoxCell();
                        }
                        dataGridView2.Rows[1].Cells[cloumni].Value = emp.ToString("MM/dd/yyyy");
                        dataGridView2.Rows[2].Cells[cloumni].Value = item.区分;
                        dataGridView2.Rows[3].Cells[cloumni].Value = item.出庫事由;
                        dataGridView2.Rows[4].Cells[cloumni].Value = item.納品書番号;
                        if (i == 0)
                            dataGridView2.Rows[i + 5].Cells[cloumni].Value = item.数量;
                        item.自社コード = Convert.ToInt32(自社コード);
                        item.日付 = emp;

                        stockrecList.Add(item);
                    }
                    cloumni++;

                }
                this.dataGridView2.Rows[0].Visible = false;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                #endregion
            }
        }

        private void btcanel_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                var results = new List<v_stockrec>();
                if (区分comboBox1.Text != "All")
                {
                    results = (from s in ctx.t_stockrec
                               where s.区分 == 区分comboBox1.Text && s.先 == manufacturerComboBox.Text && s.元 == warehouseComboBox.Text && s.日付 > this.orderCreatedAtDateTimePicker.Value && this.dateTimePicker1.Value > s.日付
                               select new v_stockrec { 自社コード = s.自社コード, 日付 = s.日付, 区分 = s.区分, 出庫事由 = s.出庫事由, 納品書番号 = s.納品書番号, 数量 = s.数量 }).ToList();
                }
                else
                    results = (from s in ctx.t_stockrec
                               where s.先 == manufacturerComboBox.Text && s.元 == warehouseComboBox.Text && s.日付 > this.orderCreatedAtDateTimePicker.Value && this.dateTimePicker1.Value > s.日付
                               select new v_stockrec { 自社コード = s.自社コード, 日付 = s.日付, 区分 = s.区分, 出庫事由 = s.出庫事由, 納品書番号 = s.納品書番号, 数量 = s.数量 }).ToList();


                //dataGridView2.RowHeadersVisible = false;
                //dataGridView2.ColumnHeadersVisible = false;
                //this.dataGridView2.DataSource = results;

                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                DataGridViewTextBoxColumn columnil = new DataGridViewTextBoxColumn();
                columnil.HeaderText = "1";
                columnil.Name = "1";
                dataGridView2.Columns.Insert(0, columnil);
                columnil.CellTemplate = new DataGridViewTextBoxCell();


                #region 显示结果对应到相应的列中
                var value = (from v in results select v.日付).Distinct().ToList();
                for (int i = 0; i < dataGridView1.RowCount + 4; i++)
                {
                    this.dataGridView2.Rows.Add();

                }

                int cloumni = 1;
                foreach (var emp in value)
                {

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string 自社コード = dataGridView1.Rows[i].Cells["自社コード"].EditedFormattedValue.ToString();
                        v_stockrec item = new v_stockrec();
                        item.数量 = 0;

                        foreach (var temp in results)
                        {
                            if (emp == temp.日付 && 自社コード == temp.自社コード.ToString())
                            {
                                item.数量 = temp.数量 + item.数量;
                                item.区分 = temp.区分;
                                item.出庫事由 = temp.出庫事由;
                                item.納品書番号 = temp.納品書番号;
                            }
                        }
                        if (i == 0)
                        {
                            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                            column.HeaderText = emp.ToString("MM/dd/yyyy");
                            column.Name = emp.ToString();

                            dataGridView2.Columns.Insert(cloumni, column);
                            column.CellTemplate = new DataGridViewTextBoxCell();
                        }
                        dataGridView2.Rows[1].Cells[cloumni].Value = emp.ToString("MM/dd/yyyy");
                        dataGridView2.Rows[2].Cells[cloumni].Value = item.区分;
                        dataGridView2.Rows[3].Cells[cloumni].Value = item.出庫事由;
                        dataGridView2.Rows[4].Cells[cloumni].Value = item.納品書番号;
                        if (i == 0)
                            dataGridView2.Rows[i + 5].Cells[cloumni].Value = item.数量;


                    }
                    cloumni++;

                }
                this.dataGridView2.Rows[0].Visible = false;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                #endregion
            }
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            //stockrecList = new List<v_stockrec>();
            List<t_stockrec> receivedList = new List<t_stockrec>();

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                string 納品書番号 = dataGridView2.Rows[4].Cells[i].EditedFormattedValue.ToString();
                foreach (v_stockrec item in stockrecList)
                {
                    if (item.納品書番号 == 納品書番号)
                    {
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            t_stockrec temp = new t_stockrec();
                            string 自社コード = dataGridView1.Rows[j].Cells["自社コード"].EditedFormattedValue.ToString();

                            if (item.自社コード.ToString() == 自社コード.ToString())
                            {
                                string 数量 = dataGridView2.Rows[j + 5].Cells[i].EditedFormattedValue.ToString();

                                if (数量 != item.数量.ToString())
                                {
                                    temp.納品書番号 = item.納品書番号;
                                    temp.数量 = Convert.ToInt32(数量);
                                    temp.日付 = item.日付;

                                    temp.先 = manufacturerComboBox.Text;
                                    temp.元 = warehouseComboBox.Text;
                                    temp.自社コード = Convert.ToInt32(自社コード);
                                    temp.区分 = dataGridView2.Rows[2].Cells[i].EditedFormattedValue.ToString();
                                    temp.出庫事由 = dataGridView2.Rows[2].Cells[i].EditedFormattedValue.ToString();

                                    receivedList.Add(temp);

                                }
                            }
                        }
                    }


                }


            }
            if (receivedList.Count > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    ctx.t_stockrec.AddRange(receivedList);
                    ctx.SaveChanges();
                    this.stockiosList.Clear();
                }
                MessageBox.Show(String.Format("Congratulations, You have {0} items added successfully!", receivedList.Count));

            }
            else
            {
                MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
        //                //    dataGridView2.Rows[3].Cells[cloumnindex].Value = item.出庫事由;
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
        //                dataGridView2.Rows[3].Cells[cloumnindex].Value = temp.出庫事由;
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
