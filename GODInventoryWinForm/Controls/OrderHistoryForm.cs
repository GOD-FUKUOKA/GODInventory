using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;
using MySql.Data.MySqlClient;

namespace GODInventoryWinForm.Controls
{
    public partial class OrderHistoryForm : Form
    {
        private static string NoOptionSelected = "不限";
        List<v_pendingorder> orderList;
        SortableBindingList<v_pendingorder> orderListBindingList;
        private List<t_shoplist> shopList;

        public OrderHistoryForm()
        {
            InitializeComponent();
            InitializeDataSource();
            pager1.Bind();
        }


        private void filterButton_Click(object sender, EventArgs e)
        {
            InitializeOrderData();
        }

        public int InitializeDataSource()
        {
            this.pager1.PageCurrent = 1;

            using (var ctx = new GODDbContext())
            {
                shopList = ctx.t_shoplist.ToList();
            }

            if( shopList.Count> 0)
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                shops.Insert(0, new MockEntity { Id=0,FullName="不限"});
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                // 県別
                var counties = shopList.Select(s => new MockEntity { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();
                counties.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                this.countyComboBox1.DisplayMember = "FullName";
                this.countyComboBox1.ValueMember = "ShortName";
                this.countyComboBox1.DataSource = counties;

                var dateEnums = (new OrderDateEnum[] { OrderDateEnum.不限, OrderDateEnum.出荷日, OrderDateEnum.発注日, OrderDateEnum.納品日 }).Select(o => new { FullName = o.ToString(), ShortName = o.ToString() }).ToList();
                this.dateEnumComboBox.DisplayMember = "FullName";
                this.dateEnumComboBox.ValueMember = "ShortName";
                this.dateEnumComboBox.DataSource = dateEnums;
            }

            this.dateEnumComboBox.SelectedIndex = 0;

            return 0;
        }

        private int InitializeOrderData()
        {
            var startAt = this.startDateTimePicker.Value.AddDays(-1).Date;
            var endAt = this.endDateTimePicker.Value.AddDays(1).Date;
            int storeCode = 0;
            int orderCode = 0;
            int innerCode = 0;
            string orderDateEnum  = dateEnumComboBox.Text;
            string county = countyComboBox1.Text;
            string conditions = "";

            #region  构造查询条件

            if (orderCodeTextBox3.Text.Length > 0)
            {
                orderCode = Convert.ToInt32(orderCodeTextBox3.Text);
            }

            if (innerCodeTextBox.Text.Length > 0)
            {
                innerCode = Convert.ToInt32(innerCodeTextBox.Text);
            }

            if (storeCodeTextBox.Text.Length > 0)
            {
                storeCode = Convert.ToInt32(storeCodeTextBox.Text);
            }

            if (orderDateEnum == OrderDateEnum.出荷日.ToString())
            {
                conditions += "(  `出荷日`< @startAt AND `出荷日`> @endAt )";
            }
            else if (orderDateEnum == OrderDateEnum.納品日.ToString())
            {
                conditions += "(  `納品日`< @startAt AND `納品日`> @endAt )";
            } 
            
            List<MySqlParameter> condition_params = new List<MySqlParameter>();

            if (storeCode > 0)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                conditions += "(`店舗コード`= @storeCode)";
            }
            if (county != NoOptionSelected)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                conditions += "(`県別`= @county)";
            }

            if (orderCode > 0) 
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                conditions += "(`伝票番号`= @orderCode)";
            } 
            if (innerCode > 0) 
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                conditions += "(`社内伝番`= @innerCode)";
            } 

            condition_params.Add(new MySqlParameter("@startAt", startAt));
            condition_params.Add(new MySqlParameter("@endAt", endAt));
            condition_params.Add(new MySqlParameter("@innerCode", innerCode));
            condition_params.Add(new MySqlParameter("@orderCode", orderCode));
            condition_params.Add(new MySqlParameter("@county", county));
            condition_params.Add(new MySqlParameter("@storeCode", storeCode));
            
            #endregion

            int limit = pager1.PageSize;
            int offset = ( pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0 );
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                if (conditions.Length > 0) {
                    conditions = " WHERE " + conditions;
                }
                string sqlCount = string.Format(" SELECT count(*) FROM t_orderdata {0}", conditions);
                count = ctx.Database.SqlQuery<int>(sqlCount, condition_params.ToArray()).First();
                string sql = string.Format( " SELECT * FROM t_orderdata {0} LIMIT {1} OFFSET {2}", conditions, limit, offset );
                orderList = ctx.Database.SqlQuery<v_pendingorder>(sql, condition_params.ToArray()).ToList();
            }
            orderListBindingList = new SortableBindingList<v_pendingorder>(orderList);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = orderListBindingList;

            return count;
            
        }



        private void ApplyFilter()
        {
            string filter = "";
            if (this.orderCodeTextBox3.Text.Length > 0)
            {
                filter += "(社内伝番=" + this.orderCodeTextBox3.Text + ")";
            }
            if (this.orderCodeTextBox3.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " or ";
                }
                filter += "(伝票番号=" + this.orderCodeTextBox3.Text + ")";
            }



            this.bindingSource1.Filter = filter;

        }

        private void storeCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (storeCodeTextBox.Text.Trim().Length > 0)
            {
                int storeId = Convert.ToInt32(storeCodeTextBox.Text);
                if (storeId > 0)
                {
                    var shops = this.shopList.Where(s => s.店番.ToString().StartsWith(storeId.ToString())).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();

                        #region new

                        this.storeComboBox.SelectedValue = store.店番;

                        #endregion
                    }
                    else
                    {
                        errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeId));
                    }
                }
                else
                {
                    errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeCodeTextBox.Text));
                }
            }
        }

        private void storeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.storeComboBox.SelectedValue != null)
            {
              this.storeCodeTextBox.Text = this.storeComboBox.SelectedValue.ToString();
                //  InitializeOrderDataDF(this.storeCodeTextBox.Text);
            }
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public int InitializeOrderDataDF(string dianfan)
        {
            var startAt = DateTime.Now.AddDays(-30).Date;

            string sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`発注日`> {0}  AND o1.`店舗コード`={1})
    order by o1.`発注日`";
            using (var ctx = new GODDbContext())
            {
                orderList = ctx.Database.SqlQuery<v_pendingorder>(sql, startAt, dianfan).ToList();
            }
            orderListBindingList = new SortableBindingList<v_pendingorder>(orderList);
            dataGridView1.DataSource = orderListBindingList;
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`社内伝番`= {0}  or o1.`店舗コード`={0})
    order by o1.`発注日`";
            using (var ctx = new GODDbContext())
            {
                orderList = ctx.Database.SqlQuery<v_pendingorder>(sql, orderCodeTextBox3.Text).ToList();
            }
            orderListBindingList = new SortableBindingList<v_pendingorder>(orderList);
            dataGridView1.DataSource = orderListBindingList;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {


        }


        private int pager1_EventPaging(EventPagingArg e)
        {
            int  count = InitializeOrderData();
            return count;
        }

    }
}
