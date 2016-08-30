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
        public List<v_groupedorder> groupedOrderList;

        public ShippingOrderForm()
        {
            InitializeComponent();
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.shipNODataGridView.AutoGenerateColumns = false;
            
            reportForm = new ReceivedOrdersReportForm();
        }


        public void InitializeDataSource() {

            InitializeOrderData();

            InitializeEdiData();

        }

        private int InitializeOrderData()
        {

            using (var ctx = new GODDbContext())
            {
                string sql = @"SELECT o.*, sum(`原価金額(税抜)`) as TotalPrice, sum(`重量`) as TotalWeight, false as Locked  FROM  t_orderdata o WHERE o.Status = {0} GROUP BY o.ShipNO";
                groupedOrderList = ctx.Database.SqlQuery<v_groupedorder>( sql, OrderStatus.PendingShipment).ToList();
                shipNODataGridView.DataSource = groupedOrderList;
            }
            //var q = OrderSqlHelper.ShippingOrderSql(entityDataSource1);            
            //var count = q.Count();
            // create BindingList (sortable/filterable)
            //this.bindingSource1.DataSource = entityDataSource1.CreateView(q);
            // assign BindingList to grid
            


            return 0;

        }

        private void InitializeEdiData() {

            this.bindingSource2.DataSource = OrderSqlHelper.ASNEdiDataList(entityDataSource1);
            dataGridView2.DataSource = this.bindingSource2;
        
        }

        private int InitializeReceivingOrder()
        {

            var q = OrderSqlHelper.ASNOrderSql(entityDataSource1);
            
            var count = q.Count();
            
            this.bindingSource3.DataSource = entityDataSource1.CreateView(q);
            // assign BindingList to grid
            dataGridView3.DataSource = this.bindingSource3;

            return count;

        }
        

        private void uploadForEDIButton_Click(object sender, EventArgs e)
        {
            var ids = GetEdiDataIdsBySelectedGridCell();
            if (ids.Count > 0) { 
            // 上传相应ASN数据
                using (var ctx = new GODDbContext())
                {

                    var edidata = ctx.t_edidata.Find(ids.First());

                    edidata.is_sent = true;
                    edidata.sent_at = DateTime.Now;
                    ctx.SaveChanges();
                }
            }
            InitializeEdiData();

        }

        private void printForEDIButton_Click(object sender, EventArgs e)
        {
           
            var rows = dataGridView2.SelectedRows;
            if (rows.Count > 0) {

                var edidata = rows[0].DataBoundItem as t_edidata;
                var orders = OrderSqlHelper.ASNOrderDataListByMid(entityDataSource1, edidata.管理連番);
                
                reportForm.OrderEnities = orders;
                reportForm.InitializeDataSource();
                reportForm.ShowDialog();
                InitializeEdiData();
            }
            
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

        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        //private List<int> GetOrderIdsBySelectedGridCell( ) { 
        
        //    List<int> order_ids = new List<int>();
        //    var rows = GetSelectedRowsBySelectedCells( dataGridView1 );
        //    foreach(DataGridViewRow row in rows)
        //    {
        //        var pendingorder = row.DataBoundItem as v_pendingorder;
        //        order_ids.Add(pendingorder.id受注データ);
        //    }

        //    return order_ids;  
        //}

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
            reportForm.Close();
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
            int order_count = InitializeReceivingOrder();

            return order_count;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if (e.TabPage == deliveryTabPage3) {
            //    this.pager3.Bind();
            //}
        }

        private void finishOrderButton1_Click(object sender, EventArgs e)
        {
            
            var ids = GetRecievedOrderIdsBySelectedGridCell();
            if (ids.Count > 0) {

                OrderSqlHelper.FinishOrders(ids);
            }
            //pager3.Bind();
        }

        private List<int> GetRecievedOrderIdsBySelectedGridCell()
        {

            List<int> ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView3);
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
            if (order.Locked )
            {
                this.shipNODataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Green;

            }  else
            {
                this.shipNODataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = shipNODataGridView.CurrentRow.Index;
            this.groupedOrderList[i].Locked = true;
            this.shipNODataGridView.Refresh();
        }

        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = shipNODataGridView.CurrentRow.Index;
            this.groupedOrderList[i].Locked = false;
            this.shipNODataGridView.Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = shipNODataGridView.CurrentRow.Index;
            if (!groupedOrderList[i].Locked) {

                var form = new ShipOrderListForm();
                
                form.InitializeDataSource(groupedOrderList[i].ShipNO);

                form.ShowDialog();
            }
        }

    }
}
