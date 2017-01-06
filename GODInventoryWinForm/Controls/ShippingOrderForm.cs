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
        }


        public void InitializeDataSource()
        {

            InitializeOrderData();

            InitializeEdiData();

            InitializeShippedOrders();

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

                //orderList = (from t_orderdata o in ctx.t_orderdata
                //             where o.Status == OrderStatus.PendingShipment || o.Status == OrderStatus.Locked
                //             select o).ToList();
                //new
                orderList = (from t_orderdata o in ctx.t_orderdata
                             where o.Status == OrderStatus.PendingShipment || o.Status == OrderStatus.Locked
                             orderby o.実際配送担当, o.県別, o.出荷No
                             select o).ToList();

                var groupedOrders = orderList.GroupBy(o => new { Status = o.Status, ShipNO = o.ShipNO, 出荷日 = o.出荷日, 納品日 = o.納品日, 実際配送担当 = o.実際配送担当 });
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
                        TotalPrice = gos.Sum(o => o.原価金額_税抜_),
                        TotalWeight = gos.Sum(o => o.重量)
                    };
                    groupedOrderList.Add(v_groupedorder);
                }
         
                shipNODataGridView.DataSource = groupedOrderList;
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

                string sql = @"SELECT o.`ShipNO`, o.`出荷日`, o.`納品日`,
 min(o.`県別`) as `県別`, o.`実際配送担当`, 
sum(`原価金額(税抜)`) as TotalPrice, sum(`重量`) as TotalWeight  
FROM  t_orderdata o WHERE o.`受注管理連番`=0 AND o.Status = {0} GROUP BY  o.`実際配送担当`, o.`ShipNO`, o.`出荷日`, o.`納品日`ORDER BY o.伝票番号";
                groupedAsnOrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, OrderStatus.ASN).ToList();

                //this.bindingSource2.DataSource = OrderSqlHelper.ASNEdiDataList(entityDataSource1);
                ediDataGridView.DataSource = groupedAsnOrderList;
                //new 
                //groupedAsnOrderList = groupedAsnOrderList.GroupBy(o => new { Status = o.Status, ShipNO = o.ShipNO, 出荷日 = o.出荷日, 納品日 = o.納品日, 実際配送担当 = o.実際配送担当 });

                ediDataGridView.DataSource = groupedAsnOrderList;

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
            canceledDataGridView.DataSource = this.canceledOrderList;
            return 0;
        }

        private void uploadForEDIButton_Click(object sender, EventArgs e)
        {

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

                // 上传ASN
                //sendForm.Mid = mid;
                //sendForm.IsCanceledOrder = false;
                //sendForm.ShowDialog();

                //
                OrderSqlHelper.UpdateOrderStatusShipped(shipNOs);
            }



            InitializeEdiData();
            pager3.Bind();
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
            int i = shipNODataGridView.CurrentRow.Index;
            if (groupedOrderList[i].Status == OrderStatus.PendingShipment)
            {

                var form = new ShipOrderListForm();

                form.InitializeDataSource(groupedOrderList[i].ShipNO);

                if (form.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {

                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //if (e.TabPage == shippedTabPage) {
            //    pager3.Bind();                        
            //}else if (e.TabPage == asnTabPage) { 
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

                    // 上传ASN,
                    // 联调暂停 上传ASN， 
                    //sendForm.Mid = mid;
                    //sendForm.IsCanceledOrder = true;
                    //sendForm.ShowDialog();
                    sql = String.Format("UPDATE t_orderdata SET `Status`={1} WHERE `id受注データ` in( {0} )", string.Join(",", oids), (int)OrderStatus.Completed);
                    ctx.Database.ExecuteSqlCommand(sql);


                }
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
                    using (var ctx = new GODDbContext())
                    {

                        for (int i = 0; i < orders.Count; i++)
                        {
                            t_orderdata order = ctx.t_orderdata.Find(orders[i].id受注データ);
                            order.出荷日 = CHUHERI;
                            order.納品日 = NAPINRI;
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





    }
}
