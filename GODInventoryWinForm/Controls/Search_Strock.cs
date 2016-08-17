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
        private BindingList<t_stockrec> stocklist;
        private Hashtable datagrid_changes = null;
        private List<t_manufacturers> t_manufacturersR;
        private List<t_warehouses> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;
        List<DateTime> list;
        List<string> 納品書番号list;
        private List<t_stockrec> D2_t_stocklistR;
        public Search_Strock()
        {
            InitializeComponent();
            var ctx1 = entityDataSource1.DbContext as GODDbContext;
            this.t_stocklistR = ctx1.t_stockrec.Select(s => s).ToList();
            //this.t_stocklistR  =( from v in ctx1.t_stockrec. Select (s => s)).Distinct();

            var value = (from v in ctx1.t_stockrec select v.自社コード).Distinct().ToList();

            using (var ctx = new GODDbContext())
            {
                t_manufacturersR = ctx.t_manufacturers.ToList();

                t_genreR = ctx.t_genre.ToList();
                //   t_stocklistR = ctx.t_stockrec.ToList();
            }
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = value;

            OrderSqlHelper item12 = new OrderSqlHelper();

            string[] ll = item12.Strock_QuFenout();
            for (int j = 0; j < ll.Length; j++)
            {
                this.comboBox1.Items.Add(ll[j]);
            }
            string[] llp = item12.StrockReback();
            for (int j = 0; j < llp.Length; j++)
            {
                this.comboBox2.Items.Add(llp[j]);
            }
            foreach (t_genre item in t_genreR)
            {
                this.comboBox3.Items.Add(item.ジャンル名);
            }
            foreach (t_manufacturers item in t_manufacturersR)
            {
                this.comboBox4.Items.Add(item.FullName);
            }

            //   InitializePager();
            //this.dataGridView2.AllowUserToAddRows = false;
            //this.dataGridView2.DataSource = t_stocklistR;

            list = new List<DateTime>();
            納品書番号list = new List<string>();

            foreach (t_stockrec item in t_stocklistR)
            {
                int dou = 0;

                for (int i = 0; i < list.Count; i++)
                    if (item.日付 == list[i])
                        dou++;
                if (dou == 0)
                    list.Add(item.日付);
                int doub = 0;

                for (int j = 0; j < 納品書番号list.Count; j++)
                    if (item.納品書番号 == 納品書番号list[j])
                        doub++;
                if (doub == 0)
                    納品書番号list.Add(item.納品書番号);

            }

        }
        #region Pager Methods

        public void InitializePager()
        {
            this.pager1.PageCurrent = 1; //当前页为第一页   
            this.pager1.PageSize = 5000; //页数   
            this.pager1.Bind();
        }


        #endregion
        private void btFind_Click(object sender, EventArgs e)
        {
            //ApplyFilter();

            //ApplyFilter2();
            //筛选出一个自社コード  ，一个日期，納品書番号  下的所有数量

            D2_t_stocklistR = new List<t_stockrec>();
            list = new List<DateTime>();

            //for (int ii = 0; ii < 納品書番号list.Count; ii++)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    string 自社コード = dataGridView1.Rows[i].Cells["自社コード"].EditedFormattedValue.ToString();
                    var locations = this.t_stocklistR.Where(l => l.自社コード == Convert.ToInt32(自社コード)).ToList();

                    t_stockrec item = new t_stockrec();

                    foreach (var emp in locations)
                    {
                        int dou = 0;
                        //将日期归类

                        for (int iindex = 0; iindex < list.Count; iindex++)
                            if (item.日付 == list[iindex])
                                dou++;
                        if (dou == 0)
                            list.Add(item.日付);
                        //if (emp.納品書番号 == 納品書番号list[ii])
                        {
                            item.自社コード = emp.自社コード;
                            item.数量 = item.数量 + emp.数量;
                            item.納品書番号 = emp.納品書番号;
                            item.日付 = emp.日付;
                            item.区分 = emp.区分;
                        }
                    }
                    if (item.自社コード != null && item.自社コード != 0)
                        D2_t_stocklistR.Add(item);
                }

                //dataGridView2.Rows[i].Cells[16].Value = item.日付;
                //dataGridView2.Rows[i].Cells[16].Value = item.日付;
            }
            int cloumnindex = 1;

            for (int j = 0; j < list.Count; j++)
            {
                int introwindex = 4;
                if (list[j] == null)
                    continue;
                int cahc = introwindex;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    string 自社コード = dataGridView1.Rows[i].Cells["自社コード"].EditedFormattedValue.ToString();
                    var locations = this.t_stocklistR.Where(l => l.自社コード == Convert.ToInt32(自社コード)).ToList();
                    t_stockrec temp = new t_stockrec();

                    //foreach (t_stockrec item in D2_t_stocklistR)
                    foreach (var emp in locations)
                    {

                        #region MyRegion
                        //if (item.納品書番号 == null)
                        //    continue;

                        //if (item.日付 == list[j] && item.自社コード.ToString() == 自社コード)
                        //{
                        //    introwindex++;
                        //    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

                        //    //DataGridViewColumn column = new DataGridViewColumn();
                        //    this.dataGridView2.Rows.Add();
                        //    column.HeaderText = cloumnindex.ToString();
                        //    column.Name = "msisndColumn";
                        //    column.HeaderText = "Klic";
                        //    //this.dataGridView2.Columns.Add(column);
                        //    dataGridView2.Columns.Insert(1, column);
                        //    column.CellTemplate = new DataGridViewTextBoxCell();

                        //    dataGridView2.Rows[1].Cells[cloumnindex].Value = item.日付.ToString("MM/dd/yyyy");
                        //    this.dataGridView2.Rows.Add();
                        //    dataGridView2.Rows[2].Cells[cloumnindex].Value = item.区分;
                        //    this.dataGridView2.Rows.Add();
                        //    dataGridView2.Rows[3].Cells[cloumnindex].Value = item.出庫事由;
                        //    this.dataGridView2.Rows.Add();
                        //    dataGridView2.Rows[4].Cells[cloumnindex].Value = item.納品書番号;
                        //    this.dataGridView2.Rows.Add();
                        //    dataGridView2.Rows[introwindex].Cells[cloumnindex].Value = item.数量;
                        //} 
                        #endregion

                        if (emp.納品書番号 == null && list[j] != emp.日付)
                            continue;

                        temp.自社コード = emp.自社コード;
                        temp.数量 = temp.数量 + emp.数量;
                        temp.納品書番号 = emp.納品書番号;
                        temp.日付 = emp.日付;
                        temp.区分 = emp.区分;
                    }

                    #region MyRegion


                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

                    //DataGridViewColumn column = new DataGridViewColumn();
                    this.dataGridView2.Rows.Add();
                    column.HeaderText = cloumnindex.ToString();
                    column.Name = "msisndColumn";
                    column.HeaderText = "Klic";
                    //this.dataGridView2.Columns.Add(column);
                    dataGridView2.Columns.Insert(1, column);
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    if (cahc == introwindex)
                    {
                        dataGridView2.Rows[1].Cells[cloumnindex].Value = temp.日付.ToString("MM/dd/yyyy");
                        this.dataGridView2.Rows.Add();
                        dataGridView2.Rows[2].Cells[cloumnindex].Value = temp.区分;
                        this.dataGridView2.Rows.Add();
                        dataGridView2.Rows[3].Cells[cloumnindex].Value = temp.出庫事由;
                        this.dataGridView2.Rows.Add();
                        dataGridView2.Rows[4].Cells[cloumnindex].Value = temp.納品書番号;
                    }

                    this.dataGridView2.Rows.Add();
                    introwindex++;
                    dataGridView2.Rows[introwindex].Cells[cloumnindex].Value = temp.数量;

                    #endregion
                }


            }

            //this.dataGridView2.AllowUserToAddRows = true;
            //this.dataGridView2.DataSource = D2_t_stocklistR;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;
        }
        private void ApplyFilter()
        {
            string filter = "";
            if (this.comboBox1.Text.Length > 0)
            {
                filter += "(区分=" + "'" + this.comboBox1.Text + "'" + ")";
            }
            if (this.comboBox2.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(仓库=" + "'" + this.comboBox2.Text + "'" + ")";
            }
            if (this.comboBox3.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(商品別=" + "'" + this.comboBox3.Text + "'" + ")";
            }
            if (this.comboBox4.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(工場=" + "'" + this.comboBox4.Text + "'" + ")";
            }
            this.bindingSource1.Filter = filter;

        }


        private void ApplyFilter2()
        {
            string filter = "";
            if (this.comboBox1.Text.Length > 0)
            {
                filter += "(区分=" + "'" + this.comboBox1.Text + "'" + ")";
            }
            if (this.comboBox2.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(仓库=" + "'" + this.comboBox2.Text + "'" + ")";
            }
            if (this.comboBox3.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(商品別=" + "'" + this.comboBox3.Text + "'" + ")";
            }
            if (this.comboBox4.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(工場=" + "'" + this.comboBox4.Text + "'" + ")";
            }
            this.bindingSource1.Filter = filter;

        }



        #region MyRegion

        private int InitializeOrderData()
        {
            // 记录DataGridView改变数据
            this.datagrid_changes = new Hashtable();

            //var ctx = entityDataSource1.DbContext as GODDbContext;
            //var stockstates = ctx.t_stockstate.Select(s => s).ToList();
            var cq = OrderSqlHelper.stockQuery(entityDataSource1);
            var count = cq.Count();

            if (count > 0)
            {
                var q = OrderSqlHelper.stockQuery(entityDataSource1);
                // 分页

                if (pager1.PageCurrent > 1)
                {
                    q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
                }
                q = q.Take(pager1.OffSet(pager1.PageCurrent));

                // create BindingList (sortable/filterable)
                var bindinglist = entityDataSource1.CreateView(q) as EntityBindingList<t_stockrec>;

                // count 计算t_orderdata 表， list 是 orderdata join itemlist join stockstate
                // 所以有可能 bindinglist is null 
                var list = new List<t_stockrec>();
                if (bindinglist != null)
                {
                    list = bindinglist.ToList();
                }


                IEnumerable<IGrouping<int, t_stockrec>> grouped_orders = list.GroupBy(o => o.自社コード, o => o);
                foreach (var gos in grouped_orders)
                {
                    int total = 0;

                    foreach (var o in gos)
                    {
                        //total += o.発注数量;

                        //if (o.在庫数 >= total)
                        //{
                        //    o.在庫状態 = "あり";
                        //}
                        //else if (o.在庫数 > o.口数)
                        //{
                        //    o.在庫状態 = "一部不足";
                        //}
                        //else
                        //{
                        //    o.在庫状態 = "なし";
                        //}
                    }
                }
                this.bindingSource1.DataSource = bindinglist;
                // assign BindingList to grid


            }
            else
            {
                this.bindingSource1.DataSource = null;
            }
            dataGridView1.DataSource = this.bindingSource1;

            return count;
        }

        #endregion

        private int pager1_EventPaging(EventPagingArg e)
        {
            {
                int order_count = InitializeOrderData();

                return order_count;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox1.Text);
        }
        private void ApplyBindSourceFilter(string text)
        {
            if (comboBox1.Text == String.Empty || comboBox1.Text == "All")
            {
                bindingSource1.Filter = "";
            }
            else
            {
                bindingSource1.Filter = "区分='" + comboBox1.Text + "'";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter1(comboBox1.Text);
        }
        private void ApplyBindSourceFilter1(string text)
        {
            //if (comboBox2.Text == String.Empty || comboBox2.Text == "All")
            //{
            //    bindingSource1.Filter = "";
            //}
            //else
            //{
            //    bindingSource1.Filter = "仓库='" + comboBox2.Text + "'";
            //}
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (t_stocklistR.Count > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    ctx.t_stockrec.AddRange(t_stocklistR);
                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stocklist.Count));
                    t_stocklistR.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btcanel_Click(object sender, EventArgs e)
        {
            ApplyFilter();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            this.dataGridView2.Rows.Add();
            dataGridView2.Columns[0].HeaderCell.Value = "编号";

            //dataGridView2.Columns.Add(column);
            dataGridView2.Rows[1].HeaderCell.Value = "编号2";
           
            //dataGridView2.Columns.Add(column);
            //this.dataGridView2.RepeatDirection = "Vertical";


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
