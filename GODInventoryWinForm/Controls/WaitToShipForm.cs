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

        List<v_pendingorder> pendingOrderList = null;
        List<v_pendingorder> orderListForShip = null;
        List<v_pendingorder> shippingOrderList = null;
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
            pendingOrderList = new List<v_pendingorder>();
        }



        public int InitializeDataSource(string shipper = "丸健", string county = "", string store = "", string shipNo = "")
        {

            pendingOrderList.Clear();
            var q = OrderSqlHelper.WaitToShipOrderSql(this.entityDataSource1);
            this.orderBindingList = this.entityDataSource1.CreateView(q);
            this.bindingSource1.Filter = null;
            this.bindingSource1.DataSource = this.orderBindingList;
            this.dataGridView1.DataSource = this.bindingSource1;
            // 保存新查询到的结果，作为过滤条件用
            foreach (var o in orderBindingList) 
            {
                var order = o as v_pendingorder;
                pendingOrderList.Add(order);
            }

            // 第二次 調用InitializeDataSource，顯示 WaitToShipForm shipperComboBox.SelectedIndex =0 不會觸發 change 事件,
            // 所以需要每次都要初始化數據，觸發change事件。
            if (this.orderBindingList.Count > 0)
            {
                if (shipperComboBox.Text != shipper)
                {
                    // trigger change event;
                    shipperComboBox.Text = shipper;
                }
                else
                {
                    // no change event, apply it manually
                    ApplyBindSourceFilter(shipper, county, store);
                }
            }

            InitializeShipNOComboBox(shipNo );

            

            return 0;
        }

        private void InitializeShipNOComboBox(string shipNo)
        {
            
            var q = OrderSqlHelper.ShippingOrderSql(this.entityDataSource1);
            shippingOrderList = q.ToList();

            //var shipNOs = (from o in (entityDataSource1.DbContext as GODDbContext).t_orderdata
            //               where o.Status == OrderStatus.PendingShipment
            //               group o by o.ShipNO into g
            //               select new MockEntity { ShortName = g.Key, FullName = g.Key }).ToList();

            var shipNOs = shippingOrderList.GroupBy(o => o.ShipNO).Select(g => new MockEntity { ShortName = g.Key, FullName = g.Key }).ToList();

            this.shipNOComboBox.DisplayMember = "FullName";
            this.shipNOComboBox.ValueMember = "ShortName";
            this.shipNOComboBox.DataSource = shipNOs;
            if (shipNo.Length > 0)
            {
                this.shipNOComboBox.SelectedValue = shipNo;
            }
            else
            {
                this.shipNOComboBox.SelectedItem = null;
            }

            
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
                List<int> orderIds = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    var row = dataGridView1.SelectedRows[i];                    
                    var order = row.DataBoundItem as v_pendingorder;
                    orderIds.Add(order.id受注データ);
                }
                SaveOrderForShip(orderIds);

            }

            #endregion

        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region 将数据集放入集合
            int count = dataGridView2.SelectedRows.Count;
            if (count > 0)
            {
                List<int> orderIds = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    var row = dataGridView2.SelectedRows[i];
                    var order = row.DataBoundItem as v_pendingorder;
                    orderIds.Add(order.id受注データ);
                }
                SaveOrderForShip(orderIds, true);
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

                InitializeShipNOComboBox("");

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
            //ApplyBindSourceFilter(shipper);
            //var orders = this.orderBindingList.Cast<v_pendingorder>().ToList();
            var orders = pendingOrderList.FindAll(o => o.実際配送担当 == shipper); 
            InitializeCountyComboBox(orders);
            //InitializeStoreComboBox(orders);
        }

        private void countyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;

            var orders = pendingOrderList.FindAll(o => o.実際配送担当 == shipper);
            if (county != "不限")
            {
                orders = orders.FindAll(o => o.県別 == county);
            }

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
                string filter = "";
                if (shipper.Length > 0)
                {
                    filter += " (実際配送担当='" + shipper + "')";
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

            var shops = orders.Select(s => new MockEntity { Id = s.店舗コード, FullName = s.店名 }).Distinct().ToList();
            shops.Insert(0, new MockEntity { Id = 0, FullName = "不限" });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;
            this.storeComboBox.SelectedIndex = 0;

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

        private void shipNOComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipNO = shipNOComboBox.Text;
            this.orderListForShip = shippingOrderList.FindAll(o => o.ShipNO == shipNO);

            dataGridView2.DataSource = this.orderListForShip;
        }


        private void SaveOrderForShip(List<int> orderIds, bool undo = false )
        {
            
            string shipNo = shipNOComboBox.Text;
            var ShippedAtDate = this.productShippedAtDateTimePicker1.Value;
            var ReceivedAtDate = this.productReceivedAtDateTimePicker2.Value;
            if (undo)
            {
                OrderSqlHelper.UnShippingInfoConfirm(orderIds );
            }
            else {
                OrderSqlHelper.ShippingInfoConfirm(orderIds, ShippedAtDate, ReceivedAtDate, shipNo);
            }

            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;
            string store = storeComboBox.Text;
            InitializeDataSource(shipper, county, store, shipNo);

        }


        private void shipNOComboBox_TextChanged(object sender, EventArgs e)
        {
            string shipNO = shipNOComboBox.Text;
            this.orderListForShip = shippingOrderList.FindAll(o => o.ShipNO == shipNO);

            dataGridView2.DataSource = this.orderListForShip;
        }
    }
}