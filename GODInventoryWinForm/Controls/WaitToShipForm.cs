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
    using GODInventory;
    using MySql.Data.MySqlClient;
    using System.Text.RegularExpressions;

    public partial class WaitToShipForm : Form
    {
        //private List<t_shoplist> shopList;
        EditOrderForm2 editOrderForm;
        IBindingList orderBindingList = null;
        List<t_shoplist> shopList = null;
        List<v_pendingorder> pendingOrderList = null;
        List<v_pendingorder> orderListForShip = null;
        List<v_pendingorder> shippingOrderList = null;
        public List<v_groupedorder> groupedOrderList;

        string lastShipper = "";
        string lastCounty = "";
        string lastStore = "";

        public WaitToShipForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;

            //var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1).ToList();

            //var filtered = q.FindAll(s => s.県別 != null);

            //foreach (v_pendingorder item in filtered)
            //    this.comboBox1.Items.Add(item.県別);
            //filtered = q.FindAll(s => s.店舗コード != null);
            //foreach (v_pendingorder item in filtered)
            //    this.comboBox2.Items.Add(item.店舗コード);
            shopList = (entityDataSource1.DbContext as GODDbContext).t_shoplist.OrderBy(s => s.店名カナ).ToList();
            editOrderForm = new EditOrderForm2();
            pendingOrderList = new List<v_pendingorder>();
        }



        public int InitializeDataSource(string shipper = "丸健", string county = "", string store = "", string shipNO = "")
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

            // 
            lastShipper = shipper;
            lastCounty = county;
            lastStore = store;

            // 担当
            var shippers = pendingOrderList.Select(s =>  s.実際配送担当 ).Distinct().ToList();
            //shippers.Insert(0, new MockEntity { FullName = "すべて" });
            //this.shipperComboBox.DisplayMember = "FullName";
            //this.shipperComboBox.ValueMember = "FullName";
            this.shipperComboBox.DataSource = shippers;

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

            InitializeShipNOComboBox(shipNO);



            return 0;
        }

        private void InitializeShipNOComboBox(string shipNO)
        {
            // 先设置为-1，触发select_change事件，更新列表。否则，如果下面设置datasource为空时，SelectedIndex =-1,无法触发事件。
            this.shipNOComboBox.SelectedIndex = -1;

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
            if (shipNO.Length > 0 && shipNOs.Count() > 0)
            {
                // 检查 shipNOs 中是否存在 shipNO， 可能不存在了。
                if (shipNOs.Exists(o => o.FullName == shipNO))
                {
                    this.shipNOComboBox.SelectedValue = shipNO;
                }
                else
                {
                    //this.shipNOComboBox.Text = String.Empty;
                    shipNOComboBox.SelectedIndex = -1;
                }
            }
            else
            {
                //设置为“”时，数据列表为空，但是Text 还是第一条数据
                //this.shipNOComboBox.Text = String.Empty;
                this.shipNOComboBox.SelectedIndex = -1;
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //if (this.dataGridView1.SelectedCells.Count > 0)
            //{
            //    var form = new ShipingInfoConfirmForm();
            //    List<int> orderIds = GetOrderIdsBySelectedGridCell();

            //    form.SelectedOrderIds = orderIds;
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        //pager1.Bind();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("先に伝票を選択してください!");
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
            if (!ValidateShipNo())
            {
                MessageBox.Show("*出荷指示書番号*を入力してください");
                return;
            }

            #region 将订单移入配车表

            string shipNO = shipNOComboBox.Text;
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

            #region 将订单移出配车表
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
                errorProvider1.SetError(shipNOComboBox, String.Format("出荷内容がありません！"));
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

                var ShippedAtDate = this.shippedAtDateTimePicker1.Value;
                var ReceivedAtDate = this.deliveredAtDateTimePicker2.Value;
                int count = OrderSqlHelper.ShippingInfoConfirm(orderIds, ShippedAtDate, ReceivedAtDate, shipNO);

                //MessageBox.Show();

                this.orderListForShip.Clear();

                InitializeShipNOComboBox("");

            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    if (editOrderForm.Order.Status != OrderStatus.Cancelled)
                    {
                        order.実際出荷数量 = editOrderForm.Order.実際出荷数量;
                        order.納品口数 = editOrderForm.Order.納品口数;
                        order.重量 = editOrderForm.Order.重量;
                        // 修正库存
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        InitializeDataSourceBySelectedFilters();

                    }
                }
            }

        }

        private void InitializeDataSourceBySelectedFilters() {

            string shipNO = shipNOComboBox.Text;
            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;
            string store = storeComboBox.Text;
            InitializeDataSource(shipper, county, store, shipNO);
        }

        private bool ValidateShipNo()
        {
            if (this.shipNOComboBox.Text.Length == 0)
            {
                return false;
            }

            if (errorProvider1.GetError(this.shipNOComboBox).Length > 0)
            {
                return false;
            }
            return true;
        }

        #region 條件過濾

        private void shipperComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            var orders = pendingOrderList.FindAll(o => o.実際配送担当 == shipper);
            InitializeCountyComboBox(orders);
        }

        private void countyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;

            var orders = pendingOrderList.FindAll(o => o.実際配送担当 == shipper);
            if (county != "すべて")
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
            if (Convert.ToInt32(storeComboBox.SelectedValue) > 0)
            {
                this.storeCodeTextBox.Text = this.storeComboBox.SelectedValue.ToString();
            }
            else
            {
                this.storeCodeTextBox.Text = String.Empty;
            }
            ApplyBindSourceFilter(shipper, county, store);
        }


        private void ApplyBindSourceFilter(string shipper, string county = "", string store = "")
        {

            //if (bindingSource1.Count > 0)
            {
                string filter = "";
                if (shipper.Length > 0)
                {
                    filter += " (実際配送担当='" + shipper + "')";
                }

                if (county.Length > 0 && county != "すべて")
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }
                    filter += "(県別=" + "'" + county + "'" + ")";
                }
                if (store.Length > 0 && store != "すべて")
                {
                    if (filter.Length > 0)
                    {
                        filter += " AND ";
                    }

                    filter += "(店名=" + "'" + store + "'" + ")";
                }
                // 检查查询结果是否为空
                if (pendingOrderList.Count > 0)
                {
                    bindingSource1.Filter = filter;
                }
            }
        }

        private void InitializeCountyComboBox(List<v_pendingorder> orders)
        {
            //var counties = orders.Select(s => new MockEntity { FullName = s.県別 }).Distinct().ToList();
            //counties.Insert(0, new MockEntity {  FullName = "すべて" });
            //this.countyComboBox1.DisplayMember = "FullName";
            //this.countyComboBox1.ValueMember = "FullName";
            //this.countyComboBox1.DataSource = counties;

            var counties = orders.Select(s =>  s.県別 ).Distinct().ToList();
            counties.Insert(0, "すべて" );
            //this.countyComboBox1.DisplayMember = "FullName";
            //this.countyComboBox1.ValueMember = "FullName";
            this.countyComboBox1.DataSource = counties;

            Boolean exist = counties.Exists((string a) => a == lastCounty);
            if (exist)
            {
                this.countyComboBox1.Text = lastCounty;
            }
            else {
                this.countyComboBox1.SelectedIndex = 0;
            
            }

        }

        private void InitializeStoreComboBox(List<v_pendingorder> orders)
        {
            var shopIds = orders.Select(o => o.店舗コード);
            var shops = shopList.FindAll(s => shopIds.Contains(s.店番));

            var shopMockEntities = shops.Select(s => new MockEntity { Id = s.店番, ShortName = s.店名カナ, FullName = s.店名 }).ToList();
            shopMockEntities.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shopMockEntities;


            Boolean exist = shopMockEntities.Exists((MockEntity a) => a.FullName == lastStore);
            if (exist)
            {
                this.storeComboBox.Text = lastStore;
            }
            else
            {
                this.storeComboBox.SelectedIndex = 0;
            }

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
            orderListForShip = shippingOrderList.FindAll(o => o.ShipNO == shipNO);
            if (orderListForShip.Count > 0)
            {
                var order = orderListForShip.First();
                shippedAtDateTimePicker1.Value = Convert.ToDateTime(order.出荷日);
                deliveredAtDateTimePicker2.Value = Convert.ToDateTime(order.納品日);
            }
            dataGridView2.DataSource = orderListForShip;
            sum_ZL();
        }


        private void SaveOrderForShip(List<int> orderIds, bool undo = false)
        {

            string shipNO = shipNOComboBox.Text;
            var ShippedAtDate = this.shippedAtDateTimePicker1.Value;
            var ReceivedAtDate = this.deliveredAtDateTimePicker2.Value;
            if (undo)
            {
                OrderSqlHelper.UnShippingInfoConfirm(orderIds);
            }
            else
            {
                OrderSqlHelper.ShippingInfoConfirm(orderIds, ShippedAtDate, ReceivedAtDate, shipNO);
            }

            string shipper = shipperComboBox.Text;
            string county = countyComboBox1.Text;
            string store = storeComboBox.Text;
            InitializeDataSource(shipper, county, store, shipNO);

        }

        // 当用户输入新的配车单号，需检查是否存在
        // 如果重复了，在生成ASN时，导致其他状态订单上传，即上传数据出错。
        private void shipNOComboBox_TextChanged(object sender, EventArgs e)
        {
            //配车单号原则上是不会重复，但是有时候比如上周出了点情况，也有可能输入一个已经存在的配车单号
            //1. 检查 配车单号在是否存在，Status == OrderStatus.PendingShipment
            //2. 检查 配车单号在是否存在，Status != OrderStatus.Completed
            string shipNO = shipNOComboBox.Text;
            this.orderListForShip = shippingOrderList.FindAll(o => o.ShipNO == shipNO);

            dataGridView2.DataSource = this.orderListForShip;
            errorProvider1.SetError(shipNOComboBox, String.Empty);
            sum_ZL();
        }

        private void shippedAtDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string shipNO = shipNOComboBox.Text;
            var ShippedAtDate = this.shippedAtDateTimePicker1.Value;
            var ReceivedAtDate = this.deliveredAtDateTimePicker2.Value;
            int count = dataGridView2.RowCount;
            if (count > 0)
            {
                var rowItem = dataGridView2.Rows[0].DataBoundItem as v_pendingorder;
                // skip initialize trigger by shipNOComboBox_SelectedIndexChanged
                if (rowItem.出荷日 != ShippedAtDate)
                {
                    List<int> orderIds = new List<int>();

                    for (int i = 0; i < count; i++)
                    {
                        var row = dataGridView2.Rows[i];
                        var order = row.DataBoundItem as v_pendingorder;
                        orderIds.Add(order.id受注データ);
                    }
                    OrderSqlHelper.ShippingInfoConfirm(orderIds, ShippedAtDate, ReceivedAtDate, shipNO);
                    InitializeShipNOComboBox(shipNO);
                }
            }

        }

        private void deliveredAtDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string shipNO = shipNOComboBox.Text;
            var ShippedAtDate = this.shippedAtDateTimePicker1.Value;
            var ReceivedAtDate = this.deliveredAtDateTimePicker2.Value;
            int count = dataGridView2.RowCount;
            if (count > 0)
            {
                var rowItem = dataGridView2.Rows[0].DataBoundItem as v_pendingorder;
                // skip initialize trigger by shipNOComboBox_SelectedIndexChanged
                if (rowItem.納品日 != ReceivedAtDate)
                {
                    List<int> orderIds = new List<int>();

                    for (int i = 0; i < count; i++)
                    {
                        var row = dataGridView2.Rows[i];
                        var order = row.DataBoundItem as v_pendingorder;
                        orderIds.Add(order.id受注データ);
                    }
                    OrderSqlHelper.ShippingInfoConfirm(orderIds, ShippedAtDate, ReceivedAtDate, shipNO);
                    InitializeShipNOComboBox(shipNO);
                }
            }
        }

        //退单功能
        private void rollbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            List<v_pendingorder> pendingOrders = new List<v_pendingorder>();
            for (int i = 0; i < count; i++)
            {
                var row = dataGridView1.SelectedRows[i];
                var order = row.DataBoundItem as v_pendingorder;
                pendingOrders.Add(order);
            }

            if (pendingOrders.Count > 0)
            {
                RollbackOrder(pendingOrders);
                InitializeDataSourceBySelectedFilters();
            }

        }

        private void RollbackOrder(List<v_pendingorder> pendingOrders)
        {
            using (var ctx = new GODDbContext())
            {
                var orderIds = pendingOrders.Select(o => o.id受注データ);

                var orderList = (from t_orderdata o in ctx.t_orderdata
                                 where orderIds.Contains(o.id受注データ)
                                 select o).ToList();
                var stockrecList = (from t_stockrec s in ctx.t_stockrec
                                    where orderIds.Contains(s.OrderId)
                                    select s).ToList();
                var marukenTransList = (from t_maruken_trans s in ctx.t_maruken_trans
                                        where orderIds.Contains(s.OrderId)
                                        select s).ToList();

                foreach (var order in orderList)
                {
                    //二次制品订单？
                    order.社内伝番 = 0;
                    order.配送担当受信 = false;
                    order.配送担当受信時刻 = null;
                    order.Status = OrderStatus.Pending;
                }

                ctx.t_stockrec.RemoveRange(stockrecList);
                ctx.t_maruken_trans.RemoveRange(marukenTransList);
                ctx.SaveChanges();
                OrderSqlHelper.UpdateStockState(ctx, stockrecList);
            }
        }

        private void storeCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (storeCodeTextBox.Text.Trim().Length > 0)
            {
                int storeId = Convert.ToInt32(storeCodeTextBox.Text);
                if (storeId > 0)
                {
                    //var shops = this.shopList.Where(s => s.店番.ToString().StartsWith(storeId.ToString())).ToList();
                    var shops = this.shopList.Where(s => s.店番 == storeId).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();

                        this.storeComboBox.SelectedValue = store.店番;

                        errorProvider1.SetError(storeComboBox, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(storeComboBox, String.Format("店番  {0}の店舗は登録されていません", storeId));
                    }

                }
                else
                {
                    errorProvider1.SetError(storeComboBox, String.Format("店番  {0}の店舗は登録されていません", storeCodeTextBox.Text));
                }
            }
        }

        private void shipNOComboBox_Leave(object sender, EventArgs e)
        {
            string shipNO = shipNOComboBox.Text;
            if (shipNO.Length > 0)
            {
                GODDbContext ctx = this.entityDataSource1.DbContext as GODDbContext;
                t_orderdata order = ctx.t_orderdata.FirstOrDefault(o => o.ShipNO == shipNO && o.Status != OrderStatus.PendingShipment);
                if (order != null)
                {
                    errorProvider1.SetError(shipNOComboBox, "この出荷指示書番号はすでに送信されたものです。新しい番号で作成してください。");
                }
                else
                {
                    errorProvider1.SetError(shipNOComboBox, String.Empty);
                }
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {



        }

        private void sum_ZL()
        {
            int showtotal = 0;
 
            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                var order = row.DataBoundItem as v_pendingorder;
                showtotal += order.重量;
            }

            this.label8.Text = showtotal.ToString()+" kg";
        }

        private void btImportShipNumberForm_Click(object sender, EventArgs e)
        {
            var form = new ImportShipNumberForm();
            form.ShowDialog();
            if (form.SavedOrderCount > 0) {

                InitializeDataSourceBySelectedFilters();
            }

        }
    }
}