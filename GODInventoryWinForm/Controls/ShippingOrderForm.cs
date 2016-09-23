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

namespace GODInventoryWinForm.Controls
{
    public partial class ShippingOrderForm : Form
    {
        public ReceivedOrdersReportForm reportForm;
        public ShippingItemsReportForm shippingItemsReportForm;
        public List<v_groupedorder> groupedOrderList;

        public ShippingOrderForm()
        {
            InitializeComponent();
            this.dataGridView2.AutoGenerateColumns = false;
            this.receivedDataGridView.AutoGenerateColumns = false;
            this.shipNODataGridView.AutoGenerateColumns = false;

            reportForm = new ReceivedOrdersReportForm();
            shippingItemsReportForm = new ShippingItemsReportForm();
        }


        public void InitializeDataSource()
        {

            InitializeOrderData();

            InitializeEdiData();

            InitializeShippedOrders();
        }

        private int InitializeOrderData()
        {

            using (var ctx = new GODDbContext())
            {
                string sql = @"SELECT o.ShipNO, min(o.`出荷日`) as `出荷日`, min(o.`納品日`) as `納品日`,
min(o.`店舗名漢字`) as `店名`, min(o.`県別`) as `県別`, min(o.`実際配送担当`) as `実際配送担当`, 
sum(`原価金額(税抜)`) as TotalPrice, sum(`重量`) as TotalWeight, false as Locked  
FROM  t_orderdata o WHERE o.Status = {0} GROUP BY o.ShipNO";
                groupedOrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, OrderStatus.PendingShipment).ToList();
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

            this.bindingSource2.DataSource = OrderSqlHelper.ASNEdiDataList(entityDataSource1);
            dataGridView2.DataSource = this.bindingSource2;

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

        private void uploadForEDIButton_Click(object sender, EventArgs e)
        {
            var ids = GetEdiDataIdsBySelectedGridCell();
            if (ids.Count > 0)
            {
                // TODO 数据上传
                // 上传相应ASN数据
                using (var ctx = new GODDbContext())
                {
                    var edidata = ctx.t_edidata.Find(ids.First());
                    string sql = String.Format("UPDATE t_orderdata SET `Status`= {1}  WHERE `ASN管理連番` = ({0})", edidata.管理連番, (int)OrderStatus.Shipped);
                    ctx.Database.ExecuteSqlCommand(sql);
                    edidata.is_sent = true;
                    edidata.sent_at = DateTime.Now;
                    ctx.SaveChanges();
                }
            }
            InitializeEdiData();

        }

        private void printForEDIButton_Click(object sender, EventArgs e)
        {



        }

        private void generateASNButton_Click(object sender, EventArgs e)
        {
            var shipNOList = this.groupedOrderList.Where(o => o.Locked).Select(o1 => o1.ShipNO).ToList();


            if (shipNOList.Count() > 0)
            {
                // FIXME
                OrderSqlHelper.GenerateASN(shipNOList);
                InitializeOrderData();
                InitializeEdiData();
                //pager3.Bind();
            }
            else
            {
                MessageBox.Show(" please select rows in the order list first.");
            }

        }

        private void moveToASNButton_Click(object sender, EventArgs e)
        {
            var shipNOList = this.groupedOrderList.Where(o => o.Locked).Select(o1 => o1.ShipNO).ToList();


            if (shipNOList.Count() > 0)
            {
                // FIXME
                OrderSqlHelper.GenerateASN(shipNOList);
                InitializeOrderData();
                InitializeEdiData();
                //pager3.Bind();
            }
            else
            {
                MessageBox.Show(" please select rows in the order list first.");
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


        private List<int> GetEdiDataIdsBySelectedGridCell()
        {

            List<int> ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView2);
            foreach (DataGridViewRow row in rows)
            {
                var t_edidata = row.DataBoundItem as t_edidata;
                ids.Add(t_edidata.Id);
            }

            return ids;
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
            if (order.Locked)
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
            object a = shipNODataGridView.DefaultCellStyle.SelectionBackColor;
            string RemarkColor = a.ToString();

            int i = shipNODataGridView.CurrentRow.Index;
            this.groupedOrderList[i].Locked = true;
            this.shipNODataGridView.Refresh();
            for (int i1 = 0; i1 < groupedOrderList.Count; i1++)
                if (this.groupedOrderList[i1].Locked == true)
                {
                    if (i == i1)
                        shipNODataGridView.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else
                {
                    if (i == i1)
                        shipNODataGridView.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                }
        }

        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = shipNODataGridView.CurrentRow.Index;
            this.groupedOrderList[i].Locked = false;
            this.shipNODataGridView.Refresh();
            for (int i1 = 0; i1 < groupedOrderList.Count; i1++)
                if (this.groupedOrderList[i1].Locked == true)
                {
                    if (i == i1)
                        shipNODataGridView.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else
                {
                    if (i == i1)
                        shipNODataGridView.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = shipNODataGridView.CurrentRow.Index;
            if (!groupedOrderList[i].Locked)
            {

                var form = new ShipOrderListForm();

                form.InitializeDataSource(groupedOrderList[i].ShipNO);

                form.ShowDialog();
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

            var row = dataGridView2.CurrentRow;
            var edidata = row.DataBoundItem as t_edidata;
            var orders = OrderSqlHelper.ASNOrderDataListByMid(entityDataSource1, edidata.管理連番);

            reportForm.InitializeDataSource(orders);
            reportForm.ShowDialog();
            InitializeEdiData();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = shipNODataGridView.CurrentRow;
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

    }
}
