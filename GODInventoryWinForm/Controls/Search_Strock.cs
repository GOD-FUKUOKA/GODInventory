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
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;

        public Search_Strock()
        {
            InitializeComponent();
            var ctx1 = entityDataSource1.DbContext as GODDbContext;
            this.t_stocklistR = ctx1.t_stockrec.Select(s => s).ToList();

            using (var ctx = new GODDbContext())
            {
                t_manufacturersR = ctx.t_manufacturers.ToList();
                t_shippersR = ctx.t_shippers.ToList();
                t_genreR = ctx.t_genre.ToList();
                //   t_stocklistR = ctx.t_stockrec.ToList();
            }


            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = t_stocklistR;

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

           InitializePager();


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
            ApplyFilter();


        }
        private void ApplyFilter()
        {
            string filter = "";
            if (this.comboBox1.Text.Length > 0)
            {
                filter += "(区分=" +"'"+ this.comboBox1.Text + "'"+")";
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


    }
}
