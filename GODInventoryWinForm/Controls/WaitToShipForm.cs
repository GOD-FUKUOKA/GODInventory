using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    using GODInventory.MyLinq;
    using GODInventory.ViewModel;
    using MySql.Data.MySqlClient;

    public partial class WaitToShipForm : Form
    {
        //private List<t_shoplist> shopList;
        EditOrderForm2 editOrderForm;
        IBindingList orderBindingList = null;
        BindingList<v_pendingorder> orderListForShip = null;
        int first = 0;
        public List<v_groupedorder> groupedOrderList;

        
        public WaitToShipForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            InitializeDataSource();

            //var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1).ToList();

            //var filtered = q.FindAll(s => s.県別 != null);

            //foreach (v_pendingorder item in filtered)
            //    this.comboBox1.Items.Add(item.県別);
            //filtered = q.FindAll(s => s.店舗コード != null);
            //foreach (v_pendingorder item in filtered)
            //    this.comboBox2.Items.Add(item.店舗コード);

            editOrderForm = new EditOrderForm2();
        }


        public int InitializeDataSource()
        {
            shipperComboBox.SelectedIndex = 0;

            this.orderListForShip = new BindingList<v_pendingorder>();

            var q = OrderSqlHelper.WaitToShipOrderSql(this.entityDataSource1);
            this.orderBindingList = this.entityDataSource1.CreateView(q);
            this.bindingSource1.Filter = null;
            this.bindingSource1.DataSource = this.orderBindingList;
            if (this.orderBindingList.Count > 0)
            {
                this.bindingSource1.Filter = String.Format("実際配送担当='{0}'", shipperComboBox.Text);

                var orders = this.orderBindingList.Cast<v_pendingorder>().ToList();

                var shops = orders.Select(o => new MockEntity { Id = o.店舗コード, FullName = o.店名 }).Distinct().ToList();
               
                shops.Insert(0, new MockEntity { Id = 0, FullName = "不限" } );

                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;


                var counties = orders.Select(o => new MockEntity { Id = o.店舗コード, FullName = o.県別 }).Distinct().ToList();
                counties.Insert(0, new MockEntity { Id = 0, FullName = "不限" });
                this.countyComboBox1.DisplayMember = "FullName";
                this.countyComboBox1.ValueMember = "Id";
                this.countyComboBox1.DataSource = counties;

            }

            var shipNOs = (from o in (entityDataSource1.DbContext as GODDbContext).t_orderdata
                           where o.Status == OrderStatus.PendingShipment
                           group o by o.ShipNO into g
                           select new MockEntity { ShortName = g.Key, FullName = g.Key }).ToList();

            this.shipNOTextBox.DisplayMember = "FullName";
            this.shipNOTextBox.ValueMember = "ShortName";
            this.shipNOTextBox.DataSource = shipNOs;
            this.shipNOTextBox.SelectedItem = null;
            

            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridView2.DataSource = this.orderListForShip;

            return 0;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                var form = new ShipingInfoConfirmForm();
                List<int> orderIds = GetOrderIdsBySelectedGridCell();


                form.SelectedOrderIds = orderIds;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //pager1.Bind();
                }
            }
            else
            {
                MessageBox.Show("Please select orders first!");
            }


            //.ShowDialog();
        }

        private void shipperComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }

        private void shipperComboBox_TextUpdate(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }


        private void ApplyBindSourceFilter(string text)
        {
            this.bindingSource1.Filter = null;
            this.bindingSource1.DataSource = this.orderBindingList;
            if (bindingSource1.Count > 0)
            {
                string filter = "";
                if (this.countyComboBox1.Text.Length > 0 && this.countyComboBox1.Text != "不限")
                {
                    filter += "(県別=" + "'" + this.countyComboBox1.Text + "'" + ")";
                }
                if (this.storeComboBox.Text.Length > 0 && this.storeComboBox.Text != "不限")
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }
                    // filter += "(店舗名漢字=" + "'" + this.storeComboBox.Text + "'" + ")";
                    int code = (int)this.storeComboBox.SelectedValue;

                    filter += "(店舗コード=" + "'" + code.ToString() + "'" + ")";
                }
                if (this.shipperComboBox.Text.Length > 0)
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }
                    filter += "(実際配送担当=" + "'" + this.shipperComboBox.Text + "'" + ")";
                }
                bindingSource1.Filter = filter;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as v_pendingorder;
                order_ids.Add(pendingorder.id受注データ);
            }

            return order_ids;
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region 将数据集放入集合
       
            if (dataGridView1.SelectedRows.Count > 0)
            {
                first = dataGridView1.SelectedRows.Count;

                DataGridViewRow row = null;
                for (int i = 0; i < first; i++)
                {
                    row = dataGridView1.SelectedRows[0];
                    this.orderListForShip.Add((v_pendingorder)orderBindingList[row.Index]);
                    this.orderBindingList.RemoveAt(row.Index);
                }
            }

            #endregion

            #region old
            //if (dataGridView1.SelectedRows.Count > 0)
            //{

            //    DataGridViewRow row = null;
            //    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            //    {
            //        row = dataGridView1.SelectedRows[i];
            //        this.orderListForShip.Add((v_pendingorder)orderList[row.Index]);
            //        this.orderList.RemoveAt(row.Index);
            //    }
            //}
            #endregion

        }



        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region 将数据集放入集合
            if (dataGridView2.SelectedRows.Count > 0)
            {
                first = dataGridView2.SelectedRows.Count;

                DataGridViewRow row = null;
                for (int i = 0; i < first; i++)
                {
                    row = dataGridView2.SelectedRows[0];
                    this.orderBindingList.Add(this.orderListForShip[row.Index]);
                    this.orderListForShip.RemoveAt(row.Index);
                }
            }
            #endregion


            #region old
            //if (dataGridView2.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = null;
            //    for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            //    {
            //        row = dataGridView2.SelectedRows[i];
            //        this.orderList.Add(this.orderListForShip[row.Index]);
            //        this.orderListForShip.RemoveAt(row.Index);
            //    }
            //}


            #endregion

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (shipNOTextBox.Text == null || shipNOTextBox.Text == "")
            {
                MessageBox.Show("请维护 *配车单单号*");
                return;

            
            }
            string shipNO = this.shipNOTextBox.Text.Trim();

            if (shipNO.Length > 0)
            {

                List<int> orderIds = new List<int>();
                foreach (var order in this.orderListForShip)
                {

                    orderIds.Add(order.id受注データ);
                }

                var ShippedAtDate = this.productShippedAtDateTimePicker1.Value;
                var ReceivedAtDate = this.productReceivedAtDateTimePicker2.Value;
                int count = OrderSqlHelper.ShippingInfoConfirm(orderIds, ShippedAtDate, ReceivedAtDate, shipNO);

                //MessageBox.Show();

                this.orderListForShip.Clear();
                this.shipNOTextBox.SelectedIndex = 0;

            }
        }

        private void shipperComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(countyComboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int code = (int)storeComboBox.SelectedValue;

            ApplyBindSourceFilter(storeComboBox.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            first = e.RowIndex;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if( row != null ){
                var order = row.DataBoundItem as v_pendingorder;
                editOrderForm.OrderId = order.id受注データ;
                if (editOrderForm.ShowDialog() == DialogResult.OK) 
                {
                    order.実際出荷数量 = editOrderForm.Order.実際出荷数量;
                    order.納品口数 = editOrderForm.Order.納品口数;
                    order.重量 = editOrderForm.Order.重量;
                    dataGridView1.Refresh();
                }
            }
            
        }




    }
}