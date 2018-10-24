using GODInventory.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel.EDI;
using System.IO;
using ZXing.Common;
using ZXing;
using System.Collections;


namespace GODInventoryWinForm.Controls
{
    public partial class ShippingOrderForm : Form
    {
        public ReceivedOrdersReportForm reportForm;
        public ShippingItemsReportForm shippingItemsReportForm;
        public List<v_groupedorder> groupedOrderList;
        public List<v_groupedorder> groupedAsnOrderList;
        public List<t_orderdata> orderList;
        public List<t_orderdata> canceledOrderList;
        public SendASNForm sendForm;
        private SortableBindingList<v_groupedorder> sortablePendingOrderList;
        private Hashtable datagrid_changes = null;
        private SortableBindingList<v_groupedorder> sortablegroupedAsnOrderList;
        private Hashtable ediDataGridView_datagrid_changes = null;
        public ShippingOrderForm()
        {
            InitializeComponent();
            this.ediDataGridView.AutoGenerateColumns = false;
            this.receivedDataGridView.AutoGenerateColumns = false;
            this.shipNODataGridView.AutoGenerateColumns = false;
            this.canceledDataGridView.AutoGenerateColumns = false;

            reportForm = new ReceivedOrdersReportForm();
            shippingItemsReportForm = new ShippingItemsReportForm();
            sendForm = new SendASNForm();


            this.訂正理由区分Column1.ValueMember = "ID";
            this.訂正理由区分Column1.DisplayMember = "FullName";
            this.訂正理由区分Column1.DataSource = OrderQuantityChangeReasonRespository.ToList();

            this.datagrid_changes = new Hashtable();
            this.ediDataGridView_datagrid_changes = new Hashtable();

        }


        public void InitializeDataSource()
        {

            InitializeOrderData();

            InitializeEdiData();

            //InitializeShippedOrders();
            this.pager3.Bind();

            InitializeCanceledOrder();

            InitializeReceivedOrder();
        }

        private int InitializeOrderData()
        {
            groupedOrderList = new List<v_groupedorder>();
            using (var ctx = new GODDbContext())
            {
                //                string sql = @"SELECT o.`ShipNO`, o.`Status`, o.`出荷日`, o.`納品日`,
                //min(o.`店舗名漢字`) as `店名`, min(o.`県別`) as `県別`, o.`実際配送担当`, 
                //sum(`原価金額(税抜)`) as TotalPrice, sum(`重量`) as TotalWeight, false as Locked  
                //FROM  t_orderdata o WHERE o.Status = {0} OR o.Status = {1} GROUP BY o.`Status`, o.`実際配送担当`, o.`ShipNO`, o.`出荷日`, o.`納品日`";
                //                groupedOrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, OrderStatus.PendingShipment, OrderStatus.Locked).ToList();

                orderList = (from t_orderdata o in ctx.t_orderdata
                             where o.Status == OrderStatus.PendingShipment || o.Status == OrderStatus.Locked
                             select o).ToList();
                //new 担当-県別-出荷指示書番号 的顺序
                //orderList = (from t_orderdata o in ctx.t_orderdata
                //             where o.Status == OrderStatus.PendingShipment || o.Status == OrderStatus.Locked
                //             orderby o.実際配送担当, o.県別, o.出荷No
                //             select o).ToList();     

                //原始代码 留用
                // var groupedOrders = orderList.GroupBy(o => new { Status = o.Status, ShipNO = o.ShipNO, 出荷日 = o.出荷日, 納品日 = o.納品日, 実際配送担当 = o.実際配送担当 });
                // 品名漢字
                List<t_orderdata> orderList1 = new List<t_orderdata>();
                SortableBindingList<v_groupedorder> sortablePendingOrderList1;
                var groupedOrders = orderList.OrderBy(c => c.実際配送担当).ThenBy(c => c.県別).ThenBy(c => c.出荷No).GroupBy(o => new { Status = o.Status, ShipNO = o.ShipNO, 出荷日 = o.出荷日, 納品日 = o.納品日, 実際配送担当 = o.実際配送担当 }).ToList();


                foreach (var gos in groupedOrders)
                {
                    var v_groupedorder = new v_groupedorder
                    {
                        Status = gos.Key.Status,
                        ShipNO = gos.Key.ShipNO,
                        出荷日 = gos.Key.出荷日,
                        納品日 = gos.Key.納品日,
                        実際配送担当 = gos.Key.実際配送担当,
                        店名 = gos.First().店舗名漢字,
                        県別 = gos.First().県別,
                        TotalPrice = gos.Sum(o => o.納品原価金額),
                        TotalWeight = gos.Sum(o => o.重量)
                    };
                    groupedOrderList.Add(v_groupedorder);
                }

                sortablePendingOrderList1 = new SortableBindingList<v_groupedorder>(groupedOrderList);
                //var dd = sortablePendingOrderList1.ToList().OrderBy(c => c.実際配送担当).ThenBy(c => c.県別).ThenBy(c => c.出荷No).ToList();

                this.bindingSource5.DataSource = null;
                this.bindingSource5.DataSource = sortablePendingOrderList1;
                shipNODataGridView.DataSource = this.bindingSource5;

                // shipNODataGridView.DataSource = groupedOrderList;
            }
            //var q = OrderSqlHelper.ShippingOrderSql(entityDataSource1);            
            //var count = q.Count();
            // create BindingList (sortable/filterable)
            //this.bindingSource1.DataSource = entityDataSource1.CreateView(q);
            // assign BindingList to grid
            return 0;

        }

        private void InitializeEdiData()
        {
            using (var ctx = new GODDbContext())
            {

                //这个界面下各条记录的排序方式是按照后来的在最下面
                string sql = @"SELECT o.`ShipNO`, o.`出荷日`, o.`納品日`,
 min(o.`県別`) as `県別`, o.`実際配送担当`, o.`reportState`,  
sum(`納品原価金額`) as TotalPrice, sum(`重量`) as TotalWeight  
FROM  t_orderdata o WHERE o.`受注管理連番`=0 AND o.Status = {0} GROUP BY  o.`実際配送担当`, o.`ShipNO`, o.`出荷日`, o.`納品日`ORDER BY o.出荷日 desc";
                groupedAsnOrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, OrderStatus.ASN).ToList();

                //this.bindingSource2.DataSource = OrderSqlHelper.ASNEdiDataList(entityDataSource1);
                //ediDataGridView.DataSource = groupedAsnOrderList;
                //new 
                //groupedAsnOrderList = groupedAsnOrderList.GroupBy(o => new { Status = o.Status, ShipNO = o.ShipNO, 出荷日 = o.出荷日, 納品日 = o.納品日, 実際配送担当 = o.実際配送担当 });
                var newlist = groupedAsnOrderList.OrderBy(s => s.発注日).ToList();



                //var dd = sortablePendingOrderList1.ToList().OrderBy(c => c.実際配送担当).ThenBy(c => c.県別).ThenBy(c => c.出荷No).ToList();
                //mark  20181009  注销
                //ediDataGridView.DataSource = groupedAsnOrderList;

                //mark  20181009 add
                sortablegroupedAsnOrderList = new SortableBindingList<v_groupedorder>(groupedAsnOrderList);
                this.bindingSource6.DataSource = null;
                this.bindingSource6.DataSource = sortablegroupedAsnOrderList;
                ediDataGridView.DataSource = this.bindingSource6;




            }
        }

        private int InitializeShippedOrders()
        {

            var q = OrderSqlHelper.ShippedOrderSql(entityDataSource1);
            var count = q.Count();
            if (count > 0)
            {

                if (pager3.PageCurrent > 1)
                {
                    q = q.Skip(pager3.OffSet(pager3.PageCurrent - 1));
                }
                q = q.Take(pager3.OffSet(pager3.PageCurrent));

                this.bindingSource3.DataSource = entityDataSource1.CreateView(q);
                // assign BindingList to grid
                shippedDataGridView.AutoGenerateColumns = false;
                shippedDataGridView.DataSource = this.bindingSource3;

            }
            return count;
        }

        private int InitializeReceivedOrder()
        {
            var q = OrderSqlHelper.ReceivedOrderSql(entityDataSource1);
            this.bindingSource4.DataSource = entityDataSource1.CreateView(q);
            // assign BindingList to grid
            receivedDataGridView.DataSource = this.bindingSource4;
            return 0;
        }

        private int InitializeCanceledOrder()
        {
            this.canceledOrderList = OrderSqlHelper.CanceledOrderSql(entityDataSource1).ToList();
            // assign BindingList to grid
            SortableBindingList<t_orderdata> sortableCanceledOrderList = new SortableBindingList<t_orderdata>(canceledOrderList);
            canceledDataGridView.DataSource = sortableCanceledOrderList;
            return 0;
        }

        private void uploadForEDIButton_Click(object sender, EventArgs e)
        {
            //mark 20181008
            bool isValid = true;
            string errorMessage = "";

            if (ediDataGridView.SelectedRows.Count > 0)
            {
                List<string> shipNOs = new List<string>();

                foreach (DataGridViewRow row in ediDataGridView.SelectedRows)
                {
                    var gorder = row.DataBoundItem as v_groupedorder;
                    shipNOs.Add(gorder.ShipNO);
                }



                // 数据上传送信, 上传相应ASN数据
                // 更新数据，上传成功
                long mid = 0;
                using (var ctx = new GODDbContext())
                {
                    // 生成ASN
                    mid = OrderSqlHelper.GenerateASNByShipNOs(ctx, shipNOs);

                }

                var path = EDITxtHandler.BuildASNFilePath(mid);
                var newPath = Path.Combine(Properties.Settings.Default.NFWEInstallDir, @"NYOTEI\NYOTEI.txt");

                // copy for later send
                File.Copy(path, newPath, true);

                // update order state first, then call upload. in case state right
                OrderSqlHelper.UpdateOrderStatusShipped(shipNOs);
                //标记未经打印mark 20181008
                OrderSqlHelper.UpdateOrderreportState(shipNOs, 0);

                // 上传ASN，ASN上传确认
                // 文件已生成，是否即刻上传asn文件
                if (MessageBox.Show("ASNデータを作成します。このまま送信しますか？", "送信確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    sendForm.Mid = mid;
                    sendForm.IsCanceledOrder = false;
                    sendForm.ShowDialog();
                }


            }
            // mark 20181008
            this.ediDataGridView_datagrid_changes.Clear();

            InitializeEdiData();
            pager3.Bind();
        }

        private void mark_ReportState(string shipNOs, int status)
        {
            #region   mark   20181008 标记已打印


            string errorMessage = "";
            using (var ctx = new GODDbContext())
            {
                List<v_groupedorder> orders = GetDataGridViewBoundOrders2();

                if (shipNOs != null && shipNOs != null && shipNOs.Length > 0)
                {

                    string sql = String.Format("UPDATE t_orderdata SET `reportState`={0} WHERE `ShipNO`={1}", status, shipNOs);
                    int count = ctx.Database.ExecuteSqlCommand(sql);


                    if (count == 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }

            }

            #endregion
        }

        private void printForEDIButton_Click(object sender, EventArgs e)
        {
        }

        private void generateASNButton_Click(object sender, EventArgs e)
        {
            var shipNOList = this.groupedOrderList.Where(o => o.Status == OrderStatus.Locked).Select(o1 => o1.ShipNO).ToList();

            if (shipNOList.Count() > 0)
            {
                // FIXME
                OrderSqlHelper.GenerateOrderChuHeNO(shipNOList);
                InitializeOrderData();
                InitializeEdiData();
                //pager3.Bind();
            }
            else
            {
                MessageBox.Show(" まず伝票を選択してください.");
            }

        }

        private void moveToASNButton_Click(object sender, EventArgs e)
        {
            var shipNOList = this.groupedOrderList.Where(o => o.Status == OrderStatus.Locked).Select(o1 => o1.ShipNO).ToList();


            if (shipNOList.Count() > 0)
            {
                // FIXME
                OrderSqlHelper.GenerateOrderChuHeNO(shipNOList);
                InitializeOrderData();
                InitializeEdiData();
                //pager3.Bind();
            }
            else
            {
                MessageBox.Show(" まず伝票を選択してください.");
            }
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


        private void ShippingOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // trigger rdlc.dispose
            //reportForm.Close();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            int order_count = InitializeOrderData();

            return order_count;
        }

        private int pager3_EventPaging(EventPagingArg e)
        {
            int order_count = InitializeShippedOrders();

            return order_count;
        }


        private void finishOrderButton1_Click(object sender, EventArgs e)
        {

            var ids = GetRecievedOrderIdsBySelectedGridCell();
            if (ids.Count > 0)
            {

                OrderSqlHelper.FinishOrders(ids);
            }
            //pager3.Bind();
        }

        private List<int> GetRecievedOrderIdsBySelectedGridCell()
        {

            List<int> ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(receivedDataGridView);
            foreach (DataGridViewRow row in rows)
            {
                var t_orderdata = row.DataBoundItem as t_orderdata;
                ids.Add(t_orderdata.id受注データ);
            }

            return ids;
        }

        private void shipNODataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            int i = e.RowIndex;
            var order = groupedOrderList[i];
            if (order.Status == OrderStatus.Locked)
            {
                this.shipNODataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Green;

            }
            else
            {
                this.shipNODataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //int i = shipNODataGridView.CurrentRow.Index;
            //this.groupedOrderList[i].Locked = true;

            //shipNODataGridView.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Green;
            //this.shipNODataGridView.Refresh();
            var groupedOrder = shipNODataGridView.CurrentRow.DataBoundItem as v_groupedorder;
            OrderSqlHelper.LockOrdersByShipNO(groupedOrder.ShipNO);
            InitializeOrderData();
        }

        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int i = shipNODataGridView.CurrentRow.Index;
            //this.groupedOrderList[i].Locked = false;
            //shipNODataGridView.CurrentRow.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            //this.shipNODataGridView.Refresh();
            var groupedOrder = shipNODataGridView.CurrentRow.DataBoundItem as v_groupedorder;
            OrderSqlHelper.UnlockOrdersByShipNO(groupedOrder.ShipNO);
            InitializeOrderData();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var groupedOrder = shipNODataGridView.CurrentRow.DataBoundItem as v_groupedorder;
            if (groupedOrder.Status == OrderStatus.PendingShipment)
            {

                var form = new ShipOrderListForm();

                form.InitializeDataSource(groupedOrder.ShipNO);

                if (form.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {

                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == shippedTabPage)
            {
                pager3.Bind();
            }
            //else if (e.TabPage == asnTabPage) { 
            //}
        }

        private void printForEDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintReportForEDI();
        }


        private void PrintReportForEDI()
        {

            var row = ediDataGridView.CurrentRow;
            var gorder = row.DataBoundItem as v_groupedorder;
            var orders = OrderSqlHelper.ASNOrderDataListByShipNo(entityDataSource1, gorder.ShipNO);

            reportForm.InitializeDataSource(orders);
            reportForm.ShowDialog();

            //标记已经打印
            mark_ReportState(gorder.ShipNO, 1);
            InitializeEdiData();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = ediDataGridView.CurrentRow;
            var gorder = row.DataBoundItem as v_groupedorder;
            var orders = OrderSqlHelper.OrderListByShipNO(entityDataSource1, gorder.ShipNO);

            shippingItemsReportForm.InitializeDataSource(orders);
            shippingItemsReportForm.ShowDialog();
        }


        private void shipNODataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

            }
        }

        private void shipNODataGridView_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void canceledButton1_Click(object sender, EventArgs e)
        {
            //mark 20181008
            bool isValid = true;
            string errorMessage = "";

            List<t_orderdata> orders = new List<t_orderdata>();
            foreach (DataGridViewRow row in canceledDataGridView.SelectedRows)
            {
                var order = row.DataBoundItem as t_orderdata;
                orders.Add(order);
            }
            if (orders.Count > 0)
            {
                var oids = orders.Select(o => o.id受注データ).ToList();
                using (var ctx = new GODDbContext())
                {
                    //mark 20181008
                    foreach (var id in oids.Distinct())
                    {
                        var pendingorder = orders.Find(o => o.id受注データ == id);
                        t_orderdata order = ctx.t_orderdata.Find(pendingorder.id受注データ);
                        bool isQtyChanged = (order.発注数量 != pendingorder.発注数量);
                        bool isdingzhengliyouChanged = (order.訂正理由区分 != pendingorder.訂正理由区分);


                        if (isQtyChanged)
                        {
                            if (pendingorder.訂正理由区分 == order.訂正理由区分)
                            {
                                isValid = false;
                                errorMessage = "数量変更の理由をつけてください！";
                                break;
                            }
                        }
                        if (isdingzhengliyouChanged)
                        {
                            if (pendingorder.発注数量 == order.発注数量)
                            {
                                isValid = false;
                                errorMessage = "訂正理由区分変更の理由をつけてください！";
                                break;
                            }
                        }

                    }
                    if (isValid)
                    {

                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                        return;

                    }

                    string shipNo = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string sql = String.Format("UPDATE t_orderdata SET `shipNO`='{1}' WHERE `id受注データ` in( {0} )", string.Join(",", oids), shipNo);

                    List<string> shipNOs = new List<string>() { shipNo };
                    ctx.Database.ExecuteSqlCommand(sql);

                    OrderSqlHelper.GenerateOrderChuHeNO(shipNOs);

                    // 生成ASN
                    long mid = OrderSqlHelper.GenerateASNByShipNOs(ctx, shipNOs);

                    var path = EDITxtHandler.BuildASNFilePath(mid);
                    var newPath = Path.Combine(Properties.Settings.Default.NFWEInstallDir, @"NYOTEI\NYOTEI.txt");

                    // copy for later send
                    File.Copy(path, newPath, true);

                    //sql = String.Format("UPDATE t_orderdata SET `Status`={1} WHERE `id受注データ` in( {0} )", string.Join(",", oids), (int)OrderStatus.Completed);
                    //ctx.Database.ExecuteSqlCommand(sql);
                    OrderSqlHelper.UpdateOrderStatusShipped(shipNOs);

                    if (MessageBox.Show("ASNデータを作成します。このまま送信しますか？", "送信確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // 上传ASN,
                        // 联调暂停 上传ASN， 
                        sendForm.Mid = mid;
                        sendForm.IsCanceledOrder = true;
                        sendForm.ShowDialog();
                    }



                }
                this.datagrid_changes.Clear();
                InitializeCanceledOrder();
            }
        }

        private void printForShipperToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var row = shipNODataGridView.CurrentRow;
            var gorder = row.DataBoundItem as v_groupedorder;
            var orders = OrderSqlHelper.OrderListByShipNO(entityDataSource1, gorder.ShipNO);

            shippingItemsReportForm.InitializeDataSource(orders);
            shippingItemsReportForm.ShowDialog();
        }

        private void cancelConfirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<t_orderdata> orders = new List<t_orderdata>();
            foreach (DataGridViewRow row in canceledDataGridView.SelectedRows)
            {
                var order = row.DataBoundItem as t_orderdata;
                orders.Add(order);
            }

            var form = new CancelConfirmForm();
            if (orders.Count() > 0)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DateTime CHUHERI = form.CHUHERI;
                    DateTime NAPINRI = form.NAPINRI;
                    int QtyChangeReason = form.QtyChangeReason;
                    using (var ctx = new GODDbContext())
                    {

                        for (int i = 0; i < orders.Count; i++)
                        {
                            t_orderdata order = ctx.t_orderdata.Find(orders[i].id受注データ);
                            order.出荷日 = CHUHERI;
                            order.納品日 = NAPINRI;
                            order.訂正理由区分 = QtyChangeReason;
                        }
                        ctx.SaveChanges();
                    }

                    InitializeCanceledOrder();
                }
            }

        }
        private List<t_orderdata> GetPendingOrdersBySelectedGridCell()
        {

            List<t_orderdata> orders = new List<t_orderdata>();
            var rows = GetSelectedRowsBySelectedCells(canceledDataGridView);
            foreach (DataGridViewRow row in rows)
            {
                if (row.Visible)
                {
                    var pendingorder = row.DataBoundItem as t_orderdata;
                    orders.Add(pendingorder);
                }
            }

            return orders;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            string errorMessage = "";
            using (var ctx = new GODDbContext())
            {
                IEnumerable<int> orderIds = GetChangedOrderIds();
                List<t_orderdata> orders = GetDataGridViewBoundOrders();

                if (orderIds.Count() > 0)
                {
                    foreach (var id in orderIds.Distinct())
                    {
                        var pendingorder = orders.Find(o => o.id受注データ == id);
                        t_orderdata order = ctx.t_orderdata.Find(pendingorder.id受注データ);


                        order.備考 = pendingorder.備考;
                    }
                    if (isValid)
                    {
                        ctx.SaveChanges();
                        this.datagrid_changes.Clear();
                        canceledDataGridView.Refresh();

                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }

            }

        }
        private IEnumerable<int> GetChangedOrderIds()
        {

            List<int> rows = new List<int>();
            foreach (DictionaryEntry entry in datagrid_changes)
            {
                var key = entry.Key as string;
                if (key.EndsWith("_changed"))
                {
                    int row = Int32.Parse(key.Split('_')[0]);
                    rows.Add(row);
                }

            }
            return rows.Distinct();
        }


        private List<t_orderdata> GetDataGridViewBoundOrders()
        {
            List<t_orderdata> orders = new List<t_orderdata>();
            for (int i = 0; i < canceledDataGridView.Rows.Count; i++)
            {
                orders.Add(canceledDataGridView.Rows[i].DataBoundItem as t_orderdata);
            }

            return orders;
        }

        private void canceledDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < canceledDataGridView.Rows.Count - 1)
            {
                DataGridViewRow row = canceledDataGridView.Rows[e.RowIndex];
                try
                {
                    if (datagrid_changes.ContainsKey(e.RowIndex))//if (dgrSingle.Cells["列名"].Value.ToString().Contains("比较值"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void canceledDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = canceledDataGridView.Rows[e.RowIndex];
            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }
        #region 修改键生成
        private string GetCellKey(int rowIndex, int columnIndex, bool forChanged)
        {
            return GetCellKey(rowIndex, columnIndex) + "_changed";
        }

        private string GetCellKey(int rowIndex, int columnIndex)
        {
            var row = canceledDataGridView.Rows[rowIndex];
            var model = row.DataBoundItem as t_orderdata;

            return string.Format("{0}_{1}", model.id受注データ, columnIndex.ToString());
        }
        #endregion

        private void canceledDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.canceledDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);
            var new_cell_value = cell.Value;
            var original_cell_value = datagrid_changes[cellKey];
            if (new_cell_value == null && original_cell_value == null)
            {
                datagrid_changes.Remove(cellChangedKey);
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                datagrid_changes[cellChangedKey] = new_cell_value;
            }
            else
            {
                datagrid_changes.Remove(cellChangedKey);
            }

        }

        private void canceledDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);

            if (datagrid_changes.ContainsKey(cellChangedKey))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.datagrid_changes.Clear();

            //IEnumerable<int> ids = GetChangedOrderIds();
            //if (ids.Count() > 0)
            //{
            //  //  pager1.Bind();
            //}
            InitializeCanceledOrder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            string errorMessage = "";
            using (var ctx = new GODDbContext())
            {
                IEnumerable<string> orderIds = GetChangedOrderIds2();
                List<v_groupedorder> orders = GetDataGridViewBoundOrders2();

                if (orderIds.Count() > 0)
                {
                    foreach (var id in orderIds.Distinct())
                    {
                        var pendingorder = orders.Find(o => orderIds.Contains(o.ShipNO));
                        // t_orderdata order = ctx.t_orderdata.Find(pendingorder.ShipNO);
                        List<t_orderdata> orderList = (from t_orderdata o in ctx.t_orderdata
                                                       where o.ShipNO == pendingorder.ShipNO
                                                       select o).ToList();

                        foreach (t_orderdata item in orderList)
                        {
                            item.出荷日 = pendingorder.出荷日;
                            item.納品日 = pendingorder.納品日;

                        }
                        mark_ReportState(pendingorder.ShipNO, 1);
                    }




                    if (isValid)
                    {
                        ctx.SaveChanges();
                        this.ediDataGridView_datagrid_changes.Clear();
                        ediDataGridView.Refresh();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }

            }
        }

        private void ediDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < ediDataGridView.Rows.Count - 1)
            {
                DataGridViewRow row = ediDataGridView.Rows[e.RowIndex];
                try
                {
                    if (ediDataGridView_datagrid_changes.ContainsKey(e.RowIndex))//if (dgrSingle.Cells["列名"].Value.ToString().Contains("比较值"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ediDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = ediDataGridView.Rows[e.RowIndex];
            string cellKey = GetCellKey2(e.RowIndex, e.ColumnIndex);

            if (!ediDataGridView_datagrid_changes.ContainsKey(cellKey))
            {
                ediDataGridView_datagrid_changes[cellKey] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void ediDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.ediDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            string cellKey = GetCellKey2(e.RowIndex, e.ColumnIndex);
            string cellChangedKey = GetCellKey2(e.RowIndex, e.ColumnIndex, true);
            var new_cell_value = cell.Value;
            var original_cell_value = ediDataGridView_datagrid_changes[cellKey];
            if (new_cell_value == null && original_cell_value == null)
            {
                ediDataGridView_datagrid_changes.Remove(cellChangedKey);
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                ediDataGridView_datagrid_changes[cellChangedKey] = new_cell_value;
            }
            else
            {
                ediDataGridView_datagrid_changes.Remove(cellChangedKey);
            }
        }
        private IEnumerable<string> GetChangedOrderIds2()
        {

            List<string> rows = new List<string>();
            foreach (DictionaryEntry entry in ediDataGridView_datagrid_changes)
            {
                var key = entry.Key as string;
                if (key.EndsWith("_changed"))
                {

                    var row = key.Split('_')[0];
                    rows.Add(row);
                }

            }
            return rows.Distinct();
        }
        private string GetCellKey2(int rowIndex, int columnIndex, bool forChanged)
        {
            return GetCellKey2(rowIndex, columnIndex) + "_changed";
        }
        private string GetCellKey2(int rowIndex, int columnIndex)
        {
            var row = ediDataGridView.Rows[rowIndex];
            var model = row.DataBoundItem as v_groupedorder;

            return string.Format("{0}_{1}", model.ShipNO, columnIndex.ToString());
        }
        private List<v_groupedorder> GetDataGridViewBoundOrders2()
        {
            List<v_groupedorder> orders = new List<v_groupedorder>();
            for (int i = 0; i < ediDataGridView.Rows.Count; i++)
            {
                orders.Add(ediDataGridView.Rows[i].DataBoundItem as v_groupedorder);
            }

            return orders;
        }

        private void ediDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string cellChangedKey = GetCellKey2(e.RowIndex, e.ColumnIndex, true);

            if (ediDataGridView_datagrid_changes.ContainsKey(cellChangedKey))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ediDataGridView_datagrid_changes.Clear();

            //InitializeEdiData();
            this.ediDataGridView.Refresh();
        }

        private void pendingTabPage_Click(object sender, EventArgs e)
        {

        }
    }
}
