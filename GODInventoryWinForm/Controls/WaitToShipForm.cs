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
<<<<<<< HEAD

        private BindingList<v_pendingorder> orderList;
        private List<v_pendingorder> orderListRE;

=======
        IBindingList orderList = null;
        BindingList<v_pendingorder> orderListForShip = null;
>>>>>>> origin/master
        public WaitToShipForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
<<<<<<< HEAD
            InitializePager();
            //
            var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1).ToList();

            var filtered = q.FindAll(s => s.県別 != null);

            foreach (v_pendingorder item in filtered)
                this.comboBox1.Items.Add(item.県別);
            filtered = q.FindAll(s => s.店舗コード != null);
            foreach (v_pendingorder item in filtered)
                this.comboBox2.Items.Add(item.店舗コード);

            orderList = new BindingList<v_pendingorder>();
            orderListRE = new List<v_pendingorder>();

            this.dataGridView2.AutoGenerateColumns = false;

            this.dataGridView2.DataSource = orderList;


=======
            this.dataGridView2.AutoGenerateColumns = false;
            InitializeDataSource();
>>>>>>> origin/master
        }


<<<<<<< HEAD
        public void InitializePager()
        {
            this.pager1.PageCurrent = 1; //当前页为第一页              
            this.pager1.PageSize = 5000; //页数   
            this.pager1.Bind();
        }

        public void RefreshPager()
        {
            this.pager1.Bind();
        }

        #endregion

        public int InitializeOrderRelated()
        {

            var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1);
            var count = q.Count();

            q = q.Take(pager1.OffSet(pager1.PageCurrent));
            if (pager1.PageCurrent > 1)
            {
                q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
            }
            // create BindingList (sortable/filterable)
            bindingSource1.DataSource = entityDataSource1.CreateView(q);

            // assign BindingList to grid
=======
>>>>>>> origin/master

        public int  InitializeDataSource() {
            this.orderListForShip = new BindingList<v_pendingorder>();

            var q = OrderSqlHelper.WaitToShipOrderSql(this.entityDataSource1);
            this.orderList = this.entityDataSource1.CreateView( q );
            this.bindingSource1.DataSource = this.orderList;
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
<<<<<<< HEAD
                if (form.ShowDialog() == DialogResult.OK)
                {
                    pager1.Bind();
=======
                if (form.ShowDialog() == DialogResult.OK) {
                    //pager1.Bind();
>>>>>>> origin/master
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

            string filter = "";
            if (this.comboBox1.Text.Length > 0)
            {
                filter += "(県別=" + "'" + this.comboBox1.Text + "'" + ")";
            }
            if (this.comboBox2.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(店舗名漢字=" + this.comboBox2.Text + ")";
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

            //原先代码

            //if (shipperComboBox.Text == String.Empty || shipperComboBox.Text == "All")
            //{
            //    bindingSource1.Filter = "";
            //}
            //else
            //{
            //    bindingSource1.Filter = "実際配送担当='" + shipperComboBox.Text + "'";
            //    //bindingSource1.ResetBindings(true);
            //}
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
            if (dataGridView1.SelectedRows.Count > 0) {
                DataGridViewRow row = null;
                for (int i = 0 ; i < dataGridView1.SelectedRows.Count; i++) {
                    row = dataGridView1.SelectedRows[i];
                    this.orderListForShip.Add((v_pendingorder)orderList[row.Index]);
                    this.orderList.RemoveAt( row.Index );
                }            
            }
            
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            int order_count = InitializeOrderRelated();
            return order_count;
        }

        private void btFindS_Click(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox1.Text);
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox2.Text);
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox2.Text);

        }

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                List<int> orderIds = GetOrderIdsBySelectedGridCell();
                var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1).ToList();

                var filtered = q.FindAll(s => s.県別 != null);
                foreach (v_pendingorder iyte in filtered)
                {
                    orderList.Add(iyte);
                    bindingSource1.Remove(iyte);


                }
                //  InitializePager();
                //InitializeOrderRelated();
                //dataGridView1.Refresh();
                //this.dataGridView1.DataSource = null;

                //this.dataGridView1.DataSource = this.bindingSource1;

                //pager1.Bind();
            }
            else
            {
                MessageBox.Show("Please select orders first!");
            }

        }

        private void WaitToShipForm_Load(object sender, EventArgs e)
        {
            InitializeOrderRelated();

        }
=======
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow row = null;
                for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
                {
                    row = dataGridView2.SelectedRows[i];
                    this.orderList.Add(this.orderListForShip[row.Index]);
                    this.orderListForShip.RemoveAt(row.Index);
                }
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string shipNO = this.shipNOTextBox.Text.Trim();

            if (shipNO.Length > 0) {

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
            
            }
        }

>>>>>>> origin/master

    }
}
