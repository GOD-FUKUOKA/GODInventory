using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory;
using MySql.Data.MySqlClient;
using GODInventory.NAFCO.EDI;
using System.IO;

namespace GODInventoryWinForm.Controls
{
    public partial class OrderHistoryForm : Form
    {
        public ReceivedOrdersReportForm reportForm;

        EditOrderForm2 editOrderForm;
        private static string NoOptionSelected = "すべて";
        List<v_pendingorder> orderList;
        List<t_orderdata> shippedOrderList;
        List<v_groupedorder> groupedOrderList;
        List<int> orderShopIdsInThreeMonth;
        SortableBindingList<v_pendingorder> orderListBindingList;
        private List<t_shoplist> shopList;
        private SortableBindingList<v_pendingorder> sortableOrderList;
        public OrderHistoryForm()
        {
            InitializeComponent();
           
            editOrderForm = new EditOrderForm2();
            reportForm = new ReceivedOrdersReportForm();

            InitializeDataSource();
            startDateTimePicker.Select();
            this.ActiveControl = startDateTimePicker;

            InitializeEdiDataDataSource();
            
        }


        private void filterButton_Click(object sender, EventArgs e)
        {
            this.pager1.PageCurrent = 1;
            pager1.Bind();
        }

        public int InitializeDataSource()
        {
            this.pager1.PageCurrent = 1;

            using (var ctx = new GODDbContext())
            {
                DateTime threeMonthAgo = DateTime.Now.AddMonths(-3);

                orderShopIdsInThreeMonth = (from t_orderdata o in ctx.t_orderdata
                                 where o.出荷No > 0 && o.受注日 > threeMonthAgo
                                 select o.店舗コード).ToList();
                    
                shopList = ctx.t_shoplist.ToList();
            }

            if (shopList.Count > 0)
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                // 県別
                var counties = shopList.Select(s =>  s.県別 ).Distinct().ToList();
                counties.Insert(0,  "すべて");
                this.countyComboBox1.DataSource = counties;

                var dateEnums = (new OrderDateEnum[] { OrderDateEnum.すべて, OrderDateEnum.出荷日, OrderDateEnum.受注日, OrderDateEnum.納品日 }).Select(o => new { FullName = o.ToString(), ShortName = o.ToString() }).ToList();
                this.dateEnumComboBox.DisplayMember = "FullName";
                this.dateEnumComboBox.ValueMember = "ShortName";
                this.dateEnumComboBox.DataSource = dateEnums;
            }

            this.dateEnumComboBox.SelectedIndex = 0;
            // Pending = 0,	未確認  NotifyShipper = 2,	引当済   WaitToShip = 3,	転送済   PendingShipment = 5,	出荷待ち
            // ASN = 6,	送信待ち   Shipped = 7,	送信済   Received = 8,	受領済   Completed = 10,	完結  Cancelled = 14,	キャンセル   Duplicated = 22,  Locked = 33,	 Existed = 44 }	

            MockNamedEntity[] statusSet = new MockNamedEntity[] { new MockNamedEntity { OStatus = OrderStatus.Pending, FullName = "未確認" } ,
                new MockNamedEntity { OStatus = OrderStatus.NotifyShipper, FullName = "引当済" } ,
                new MockNamedEntity { OStatus = OrderStatus.WaitToShip, FullName = "転送済" } ,
                new MockNamedEntity { OStatus = OrderStatus.PendingShipment, FullName = "出荷待ち" } ,
                new MockNamedEntity { OStatus = OrderStatus.ASN, FullName = "送信待ち" } ,
                new MockNamedEntity { OStatus = OrderStatus.Shipped, FullName = "送信済" } ,
                new MockNamedEntity { OStatus = OrderStatus.Received, FullName = "受領済" } ,
                new MockNamedEntity { OStatus = OrderStatus.Completed, FullName = "完結" } ,
                new MockNamedEntity { OStatus = OrderStatus.Cancelled, FullName = "キャンセル" } ,
                new MockNamedEntity { OStatus = OrderStatus.Duplicated, FullName = "Duplicated" } ,
                new MockNamedEntity { OStatus = OrderStatus.Locked, FullName = "Locked" } ,
                new MockNamedEntity { OStatus = OrderStatus.Existed, FullName = "Existed" } ,
              };
            this.StatusColumn1.DisplayMember = "FullName";
            this.StatusColumn1.ValueMember = "OStatus";
            this.StatusColumn1.DataSource = statusSet;

            //  受領	          FALSE	未        TRUE	済
            MockNamedEntity[] receivedSet = new MockNamedEntity[] { new MockNamedEntity { BStatus = true, FullName = "済" } ,
                 new MockNamedEntity { BStatus = false, FullName = "未" } 
              };
            this.receivedColumn.DisplayMember = "FullName";
            this.receivedColumn.ValueMember = "BStatus";
            this.receivedColumn.DataSource = receivedSet;            
            return 0;
        }

        private int InitializeOrderData()
        {
            var startAt = this.startDateTimePicker.Value.Date;
            var endAt = this.endDateTimePicker.Value.Date;
            int storeCode = 0;
            int orderCode = 0;
            int innerCode = 0;
            string orderDateEnum = dateEnumComboBox.Text;
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
                conditions += "(  `出荷日`>= @startAt AND `出荷日`<= @endAt )";
            }
            else if (orderDateEnum == OrderDateEnum.納品日.ToString())
            {
                conditions += "(  `納品日`>= @startAt AND `納品日`<= @endAt )";
            }
            else if (orderDateEnum == OrderDateEnum.受注日.ToString())
            {
                conditions += "(  `受注日`>= @startAt AND `受注日`<= @endAt )";
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
            int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                if (conditions.Length > 0)
                {
                    conditions = " WHERE " + conditions;
                }
                string sqlCount = string.Format(" SELECT count(*) FROM t_orderdata {0}", conditions);
                count = ctx.Database.SqlQuery<int>(sqlCount, condition_params.ToArray()).First();
                //string sql = string.Format(" SELECT * FROM t_orderdata {0} LIMIT {1} OFFSET {2}", conditions, limit, offset);
                string sql = string.Format(" SELECT * FROM t_orderdata {0} ORDER BY `受注日` DESC LIMIT {1} OFFSET {2}", conditions, limit, offset);
                orderList = ctx.Database.SqlQuery<v_pendingorder>(sql, condition_params.ToArray()).ToList();
                //new 
                //orderList = orderList.Distinct().OrderBy(s => s.受注日).ToList();
                //orderList = orderList.Distinct().OrderByDescending(s => s.受注日).ToList();
                //sortableOrderList = new SortableBindingList<v_pendingorder>(orderList);


               // orderList = sortableOrderList.Distinct().OrderByDescending(s => s.受注日).ToList();
                
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
            //if (storeCodeTextBox.Text.Trim().Length > 0)
            //{
            //    int storeId = Convert.ToInt32(storeCodeTextBox.Text);
            //    if (storeId > 0)
            //    {
            //        var shops = this.shopList.Where(s => s.店番.ToString().StartsWith(storeId.ToString())).ToList();
            //        if (shops.Count > 0)
            //        {
            //            var store = shops.First();

            //            #region new

            //            this.storeComboBox.SelectedValue = store.店番;

            //            #endregion
            //        }
            //        else
            //        {
            //            errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeId));
            //        }
            //    }
            //    else
            //    {
            //        errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeCodeTextBox.Text));
            //    }
            //}
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
            int count = InitializeOrderData();
            return count;
        }

        private void storeComboBox_TextChanged(object sender, EventArgs e)
        {
            int code = (int)storeComboBox.SelectedValue;
            if (code > 0)
            {
                this.storeCodeTextBox.Text = code.ToString();
            }
            else
            {
                this.storeCodeTextBox.Text = "";
            }

        }

        private void storeCodeTextBox_MouseLeave(object sender, EventArgs e)
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

        private void btclear_Click(object sender, EventArgs e)
        {
            if (shopList.Count > 0)
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                // 県別
                var counties = shopList.Select(s => s.県別 ).Distinct().ToList();
                counties.Insert(0,  "すべて" );
                this.countyComboBox1.DataSource = counties;

                var dateEnums = (new OrderDateEnum[] { OrderDateEnum.すべて, OrderDateEnum.出荷日, OrderDateEnum.受注日, OrderDateEnum.納品日 }).Select(o => new { FullName = o.ToString(), ShortName = o.ToString() }).ToList();
                this.dateEnumComboBox.DisplayMember = "FullName";
                this.dateEnumComboBox.ValueMember = "ShortName";
                this.dateEnumComboBox.DataSource = dateEnums;
            }
            this.dateEnumComboBox.SelectedIndex = 0;
            storeCodeTextBox.Text = "";
            orderCodeTextBox3.Text = "";
            innerCodeTextBox.Text = "";
            startDateTimePicker.Value = DateTime.Today;
            endDateTimePicker.Value = DateTime.Today;


        }

        private void countyComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int code = (int)countyComboBox1.SelectedValue;
            //if (code > 0)
            //{
            //    this.storeCodeTextBox.Text = code.ToString();
            //}
            //else
            //{
            //    this.storeCodeTextBox.Text = "";
            //}

            string county = this.countyComboBox1.Text;
            var filtered = shopList.FindAll(s => s.県別 == county);
            if (filtered.Count > 0)
            {
                var shops = filtered.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                this.storeComboBox.SelectedIndex =0;
            }
            else
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;

            }



        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row != null)
            {
                var order = row.DataBoundItem as v_pendingorder;
                editOrderForm.OrderId = order.id受注データ;
                if (editOrderForm.ShowDialog() == DialogResult.OK)
                {
                    order.実際出荷数量 = editOrderForm.Order.実際出荷数量;
                    order.最終出荷数 = editOrderForm.Order.最終出荷数;
                    order.納品口数 = editOrderForm.Order.納品口数;
                    order.重量 = editOrderForm.Order.重量;
                    order.キャンセル = editOrderForm.Order.キャンセル;
                    order.キャンセル時刻 = editOrderForm.Order.キャンセル時刻;
                    order.Status = editOrderForm.Order.Status;
                    order.発注日 = editOrderForm.Order.発注日;
                    dataGridView1.Refresh();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var order = dataGridView1.CurrentRow.DataBoundItem as v_pendingorder;
                if (order.Status == OrderStatus.Shipped)
                {
                    //this.contextMenuStrip1.Items["uploadASNToolStripMenuItem"].Enabled = true;
                }
                else {
                    //this.contextMenuStrip1.Items["uploadASNToolStripMenuItem"].Enabled = false;
                }
            }
        }

        private void uploadASNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendASNForm sendForm = new SendASNForm();

            var order = dataGridView2.CurrentRow.DataBoundItem as t_orderdata;
            if (order != null)
            {
               
                var orders = this.shippedOrderList.Where(o => o.出荷No == order.出荷No).ToList();

                var orderIds = orders.Select(o => o.id受注データ).ToList();
                long mid = 0;

                using (GODDbContext ctx = new GODDbContext())
                {
                    mid = OrderSqlHelper.GenerateASNByOrderIds(ctx, orderIds);
                }


                var path = EDITxtHandler.BuildASNFilePath(mid);
                var newPath = Path.Combine(Properties.Settings.Default.NFWEInstallDir, @"NYOTEI\NYOTEI.txt");

                // copy for later send
                File.Copy(path, newPath, true);

                if (MessageBox.Show("ASNデータを作成します。このまま送信しますか？", "送信確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // 上传ASN
                    sendForm.Mid = order.ASN管理連番;
                    sendForm.IsCanceledOrder = false;
                    sendForm.ShowDialog();
                    //MessageBox.Show("ASNデータ作成");
                }

            }
        }

        private void InitializeEdiDataDataSource() {
            var shops = shopList.Where(s=>orderShopIdsInThreeMonth.Contains(s.店番)).Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
            shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.storeNameComboBox2.DisplayMember = "FullName";
            this.storeNameComboBox2.ValueMember = "Id";
            this.storeNameComboBox2.DataSource = shops;
            this.dataGridView2.AutoGenerateColumns = false;
        }

        private void InitializeEdiDataByStore()
        {

            int storeId = Convert.ToInt32( this.storeNameComboBox2.SelectedValue );
            if (storeId > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    DateTime threeMonthAgo = DateTime.Now.AddMonths(-3);
                    string sql = @"SELECT o.`出荷No`, o.`出荷日`, o.`納品日`, o.`県別`, o.`実際配送担当`, o.`原価金額(税抜)`, o.`重量`
                        FROM  t_orderdata o WHERE o.`出荷No`> 0  ORDER BY  o.`実際配送担当`, o.`出荷No`, o.`出荷日`, o.`納品日`";

//                  string sql = @"SELECT o.`出荷No`, o.`出荷日`, o.`納品日`,
//     min(o.`県別`) as `県別`, o.`実際配送担当`, 
//    sum(`原価金額(税抜)`) as TotalPrice, sum(`重量`) as TotalWeight  
//    FROM  t_orderdata o WHERE o.`出荷No`>0 GROUP BY  o.`実際配送担当`, o.`出荷No`, o.`出荷日`, o.`納品日`";
//                  groupedOrderList = ctx.Database.SqlQuery<v_groupedorder>(sql).ToList();
                    shippedOrderList = (from t_orderdata o in ctx.t_orderdata
                                        where o.店舗コード==storeId && o.出荷No > 0 && o.受注日 > threeMonthAgo
                                     orderby  o.実際配送担当, o.出荷No, o.出荷日, o.納品日
                                     select o).ToList();
 

                    dataGridView2.DataSource = new SortableBindingList<t_orderdata>(shippedOrderList);
             
                }
            }
        }

        private void searchEdiDataByStoreButton2_Click(object sender, EventArgs e)
        {
            InitializeEdiDataByStore();
        }

        private void storeNameComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 跳过 0
            if (this.storeNameComboBox2.SelectedValue!=null && ((int)this.storeNameComboBox2.SelectedValue > 0))
            {
                this.storeCodeTextBox2.Text = this.storeNameComboBox2.SelectedValue.ToString();
            }
        }

        private void storeIdTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (storeCodeTextBox2.Text.Trim().Length > 0)
            {
                int storeId = Convert.ToInt32(storeCodeTextBox2.Text);
                if (storeId > 0)
                {
                    var shops = this.shopList.Where(s => s.店番 == storeId).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();
                        this.storeNameComboBox2.SelectedValue = store.店番;
                        errorProvider2.SetError(storeCodeTextBox2, "");
                    }
                    else
                    {
                        errorProvider2.SetError(storeCodeTextBox2, String.Format("Can not find store by ID {0}", storeId));
                    }
                }
                else
                {
                    errorProvider2.SetError(storeCodeTextBox2, String.Format("Can not find store by ID {0}", storeCodeTextBox2.Text));
                }
            }
        }

        private void storeNameComboBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void storeCodeTextBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var row = dataGridView2.CurrentRow;
            if (row != null)
            {
                var order = row.DataBoundItem as t_orderdata;
                editOrderForm.OrderId = order.id受注データ;
                if (editOrderForm.ShowDialog() == DialogResult.OK)
                {
                    order.実際出荷数量 = editOrderForm.Order.実際出荷数量;
                    order.納品口数 = editOrderForm.Order.納品口数;
                    order.重量 = editOrderForm.Order.重量;
                    order.品名漢字 = editOrderForm.Order.品名漢字;
                    order.規格名漢字 = editOrderForm.Order.規格名漢字;
                    order.納品日 = editOrderForm.Order.納品日;

                    order.発注日 = editOrderForm.Order.発注日;
                    order.キャンセル = editOrderForm.Order.キャンセル;
                    order.キャンセル時刻 = editOrderForm.Order.キャンセル時刻;
                    order.Status = editOrderForm.Order.Status;
                    dataGridView2.Refresh();
                }
            }
        }

        private void printForEDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dataGridView2.CurrentRow;
            var order = row.DataBoundItem as t_orderdata;
            if (order != null)
            {
                var orders = OrderSqlHelper.ASNOrderDataListByChuHeNo(entityDataSource1, order.出荷No);

                reportForm.InitializeDataSource(orders);
                reportForm.ShowDialog();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this.shippedTabPage)
            {
                this.storeCodeTextBox2.SelectAll();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ; ;
        }
    }
}
