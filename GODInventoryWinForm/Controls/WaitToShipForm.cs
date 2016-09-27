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
            //InitializeDataSource();

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

            this.orderListForShip = new BindingList<v_pendingorder>();

            var q = OrderSqlHelper.WaitToShipOrderSql(this.entityDataSource1);
            this.orderBindingList = this.entityDataSource1.CreateView(q);
            this.bindingSource1.Filter = null;
            this.bindingSource1.DataSource = this.orderBindingList;
            this.dataGridView1.DataSource = this.bindingSource1;
            // 第二次 調用InitializeDataSource，顯示 WaitToShipForm shipperComboBox.SelectedIndex =0 不會觸發 change 事件,
            // 所以需要每次都要初始化數據，觸發change事件。
            if (this.orderBindingList.Count > 0)
            {
                shipperComboBox.Items.Clear();
                shipperComboBox.Items.AddRange(new object[] { "丸健", "MKL", "マツモト産業"});
                shipperComboBox.SelectedIndex = 0;
            }

            InitializeShipNOComboBox();

            dataGridView2.DataSource = this.orderListForShip;

            return 0;
        }

        private void InitializeShipNOComboBox()
        {
            var shipNOs = (from o in (entityDataSource1.DbContext as GODDbContext).t_orderdata
                           where o.Status == OrderStatus.PendingShipment
                           group o by o.ShipNO into g
                           select new MockEntity { ShortName = g.Key, FullName = g.Key }).ToList();

            this.shipNOComboBox.DisplayMember = "FullName";
            this.shipNOComboBox.ValueMember = "ShortName";
            this.shipNOComboBox.DataSource = shipNOs;
            this.shipNOComboBox.SelectedItem = null;
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
            if (!ValidateShipNo())
            {
                MessageBox.Show("请输入 *配车单单号*");
                return;
            }

            #region 将数据集放入集合

            string shipNo = shipNOComboBox.Text;
            int count = dataGridView1.SelectedRows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var row = dataGridView1.SelectedRows[0];
                    var order2 = orderBindingList[row.Index] as v_pendingorder;
                    var order = row.DataBoundItem as v_pendingorder;
                    order.ShipNO = shipNo;
                    this.orderListForShip.Add(order);
                    this.orderBindingList.RemoveAt(row.Index);
                }
            }

            #endregion

        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region 将数据集放入集合
            int count = dataGridView2.SelectedRows.Count;
            if (count > 0)
            {

                for (int i = 0; i < count; i++)
                {
                    var row = dataGridView2.SelectedRows[0];
                    var order = row.DataBoundItem as v_pendingorder;
                    order.ShipNO = null;
                    this.orderBindingList.Add(order);
                    this.orderListForShip.RemoveAt(row.Index);
                }
            }
            #endregion

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (shipNOComboBox.Text == null || shipNOComboBox.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(shipNOComboBox, String.Format("配车单内容不能为空的"));
                //MessageBox.Show("请输入 *配车单单号*");
                return;


            }
            string shipNO = this.shipNOComboBox.Text.Trim();

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

                InitializeShipNOComboBox();

            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            first = e.RowIndex;

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
                    order.納品口数 = editOrderForm.Order.納品口数;
                    order.重量 = editOrderForm.Order.重量;
                    dataGridView1.Refresh();
                }
            }

        }

        private bool ValidateShipNo()
        {
            if (this.shipNOComboBox.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        #region 條件過濾

        private void shipperComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            ApplyBindSourceFilter(shipper);
            var orders = this.orderBindingList.Cast<v_pendingorder>().ToList();
            InitializeCountyComboBox(orders);
            InitializeStoreComboBox(orders);
        }

        private void countyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;
            ApplyBindSourceFilter(shipper, county);
            
            var orders = this.orderBindingList.Cast<v_pendingorder>().ToList();

            InitializeStoreComboBox(orders);
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;
            string store = storeComboBox.Text;

            ApplyBindSourceFilter(shipper, county, store);
        }


        private void ApplyBindSourceFilter(string shipper, string county ="", string store ="")
        {
            
            //if (bindingSource1.Count > 0)
            {
                string filter = "(ShipNO is null)";
                if (shipper.Length > 0)
                {
                    filter += " AND (実際配送担当='" + shipper + "')";
                }

                if (county.Length > 0 && county  != "不限")
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }
                    filter += "(県別=" + "'" + county + "'" + ")";
                }
                if (store.Length > 0 && store != "不限")
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }

                    filter += "(店名=" + "'" + store + "'" + ")";
                }
                Console.WriteLine("filter:" + filter);
                bindingSource1.Filter = filter;
            }
        }

        private void InitializeCountyComboBox( List<v_pendingorder> orders )
        {
            var counties = orders.Select(s => new MockEntity { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();
            counties.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
            this.countyComboBox1.DisplayMember = "FullName";
            this.countyComboBox1.ValueMember = "ShortName";
            this.countyComboBox1.DataSource = counties;

            this.countyComboBox1.SelectedIndex = 0;
        }

        private void InitializeStoreComboBox(List<v_pendingorder> orders)
        {
            var shops = orders.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).Distinct().ToList();
            shops.Insert(0, new MockEntity { Id = 0, FullName = "不限" });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;
            this.storeComboBox.SelectedIndex = 0;
        }

        public int De_InitializeDataSource()
        {

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

                shops.Insert(0, new MockEntity { Id = 0, FullName = "不限" });

                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;


                //var counties = orders.Select(o => new MockEntity { Id = o.店舗コード, FullName = o.県別 }).Distinct().ToList();
                //counties.Insert(0, new MockEntity { Id = 0, FullName = "不限" });
                //this.countyComboBox1.DisplayMember = "FullName";
                //this.countyComboBox1.ValueMember = "Id";
                //this.countyComboBox1.DataSource = counties;


                // GenreName
                var counties = orders.Select(s => new MockEntity { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();
                counties.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                this.countyComboBox1.DisplayMember = "FullName";
                this.countyComboBox1.ValueMember = "ShortName";


                this.countyComboBox1.DataSource = counties;
            }

            InitializeShipNOComboBox();
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridView2.DataSource = this.orderListForShip;

            return 0;


        }


        private List<v_pendingorder> GetDataGridViewBoundOrders()
        {
            List<v_pendingorder> orders = new List<v_pendingorder>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                orders.Add(dataGridView1.Rows[i].DataBoundItem as v_pendingorder);
            }

            return orders;
        }

        #endregion
    }
}