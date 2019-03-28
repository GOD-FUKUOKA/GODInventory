using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;
//using Spring.Context;
//using Spring.Context.Support;
//using System.Collections;
using System.Configuration;
using GODInventory.ViewModel.EDI;
using GODInventory.ViewModel;


namespace GODInventoryWinForm.Controls
{
    public partial class CreateOrderForm : Form
    {

        List<int> newfaxno = new List<int>();
        private List<t_genre> genreList;
        private List<t_shoplist> shopList;
        private List<v_itemprice> itemPriceList;
        private List<t_locations> locationList;
        private BindingList<t_orderdata> orderList;
        private List<t_pricelist> t_pricelistR;
        private ComboBox specialColumn;
        private List<t_customers> customersList;
        private SelectProductForm selectProductForm;
        public List<t_orderdata> newOrderList;

        public CreateOrderForm()
        {
            InitializeComponent();

            orderList = new BindingList<t_orderdata>();

            shopList = new List<t_shoplist>();
            locationList = new List<t_locations>();
            customersList = new List<t_customers>();
            using (var ctx = new GODDbContext())
            {

                customersList = ctx.t_customers.ToList();
                shopList = ctx.t_shoplist.ToList();
                locationList = ctx.t_locations.ToList();
                t_pricelistR = ctx.t_pricelist.ToList();
                genreList = ctx.t_genre.ToList();

            }
            selfCodeTextBox1.Text = Properties.Settings.Default.Createorder_scc;
            shipperTextBox.Text = Properties.Settings.Default.Createorder_hsbsc;
            selfNameTextBox.Text = Properties.Settings.Default.Createorder_sog;


            this.genreNameColumn.ValueMember = "Id";
            this.genreNameColumn.DisplayMember = "FullName";
            // convert idジャンル to short,  order.ジャンル is short
            this.genreNameColumn.DataSource = genreList.Select(o => new { Id = o.idジャンル, FullName = o.ジャンル名 }).ToList();
               

            //orderReasonDataGridviewComboBox.ValueType = typeof(OrderReasonEnum);
            this.orderReasonComboBox.ValueMember = "Value";
            this.orderReasonComboBox.DisplayMember = "Display";
            this.orderReasonComboBox.DataSource = new OrderReasonEnum[] { OrderReasonEnum.補充, OrderReasonEnum.客注, OrderReasonEnum.用度品, OrderReasonEnum.広告, OrderReasonEnum.新店 }
                .Select(value => new { Display = value.ToString(), Value = (short)value })
                .ToList();
            this.orderReasonComboBox.SelectedIndex = 0;

            this.customerComboBox.DisplayMember = "FullName";
            this.customerComboBox.ValueMember = "Id";
            this.customerComboBox.DataSource = customersList;
            
            this.storeComboBox.DisplayMember = "店名";
            this.storeComboBox.ValueMember = "店番";
            this.storeComboBox.DataSource = shopList;

            //this.locationComboBox.DisplayMember = "納品場所名略称";
            //this.locationComboBox.ValueMember = "Id";

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = orderList;

            this.customerComboBox.SelectedIndex = 0;
            this.deliveredAtDateTimePicker.Value = DateTime.Now.AddDays(2);
        }

        private void NewOrdersForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        // 全角半角检查
        private bool QuanJiaoBanJiao(string o)
        {
            bool isrun = true;

            if (o != null && o.ToString() != String.Empty)
            {
                if (!EDITxtHandler.IsAllQuanjiaoJapan(o.ToString()))
                {
                    MessageBox.Show("商品名と規格名を全角で入力ください！");
                    isrun = false;


                }
            }
            return isrun;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                storeCodeTextBox.Text = "";

                //this.dataGridView1.DataSource = null;
                //this.dataGridView1.Refresh();

            }
            catch (Exception ex)
            {

                throw ex;
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
                    var shops = this.shopList.Where(s => s.店番 == storeId ).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();
                        var locations = this.locationList.Where(l => l.店舗コード == store.店番).Select(l => new { l.納品場所コード, l.納品場所名漢字 }).ToList();
                        locations.Insert(0, new { 納品場所コード = (short)-1, 納品場所名漢字 = "" });
                        this.locationComboBox.DisplayMember = "納品場所名漢字";
                        this.locationComboBox.ValueMember = "納品場所コード";
                        this.locationComboBox.DataSource = locations;
                        if (locations.Count > 1)
                        {
                            this.locationTextBox.Enabled = true;
                            this.locationComboBox.SelectedIndex = 0;
                            this.locationTextBox.Text = this.locationComboBox.SelectedValue.ToString();
                        }
                        else
                        {
                            this.locationTextBox.Enabled = false;
                        }

                        //不能限制为1， 15/150 都是 15 开头
                        //if (shops.Count == 1)
                        {
                            this.storeComboBox.SelectedValue = store.店番;
                        }
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


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (customerIdTextBox.Text.Trim().Length > 0)
            {
                int storeId = Convert.ToInt32(customerIdTextBox.Text);
                if (storeId > 0)
                {
                    var shops = this.customersList.Where(s => s.Id.ToString().Equals(storeId.ToString())).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();
                        if (shops.Count == 1)
                        {
                            this.customerComboBox.SelectedValue = store.Id;
                        }
                    }
                    else
                    {
                        errorProvider2.SetError(customerComboBox, String.Format("customer  {0}の店舗は登録されていません", storeId));
                    }

                }
                else
                {
                    errorProvider2.SetError(customerComboBox, String.Format("customer  {0}の店舗は登録されていません", customerIdTextBox.Text));
                }

            }

        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (locationTextBox.Text == "")
                return;
            if (locationTextBox.Text.Length > 5)
            {
                MessageBox.Show("超えた長さ");
                return;
            }
            var storeId = Convert.ToInt16(this.storeCodeTextBox.Text);
            var locationId = Convert.ToInt16(locationTextBox.Text);

            if ((short)locationComboBox.SelectedValue != locationId)
            {
                //Fix it later
                this.locationComboBox.SelectedValue = locationId;
            }

        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }


        private int GenerateInvoiceNo(int storeId)
        {
            int max = 1000000; //传真订单 6位，小于 1000000
            int invoiceNo = 0;
            using (var ctx = new GODDbContext())
            {
                var last_order = (from s in ctx.t_orderdata
                                  where s.店舗コード == ((short)storeId) && s.伝票番号 < max
                                  orderby s.発注日 descending, s.伝票番号 descending
                                  select s).FirstOrDefault();
                if (last_order != null)
                {
                    invoiceNo = last_order.伝票番号;
                }
            }
            return GetNextByInvoiceNO(invoiceNo);
        }


        private int GetNextByInvoiceNO(int invoiceNo)
        {
            int startAt = 40000;
            int position = invoiceNo / 10;  // remove last check number
            position %= 99999;              // max position is 99999,
            if (position < startAt)           // start from 40000
            {
                position += startAt;
            }

            position += 1;

            return (position * 10) + (position % 7);

        }

        ////  発注形態 is enum, binding is not working, we have to handle it manually
        //private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    // fix 発注形態 combobox
        //    var row = dataGridView1.Rows[e.RowIndex];

        //    var order = row.DataBoundItem as t_orderdata;

        //    row.Cells["orderReasonDataGridviewComboBox"].Value = order.発注形態区分;
        //}

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // fix 発注形態 combobox when user change it
            int i = e.RowIndex;
            var order = this.orderList[i];
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            #region 基于商品コード查找商品

            if (cell.OwningColumn == specialCodeColumn)
            {
                var row = cell.OwningRow;
                if (cell.Value != null && cell.Value.ToString() == "YES")
                {
                    //row.Cells["商品コード"].ReadOnly = false;
                    row.Cells["genreNameColumn"].ReadOnly = false;
                    row.Cells["productNameColumn"].ReadOnly = false;
                    row.Cells["productSpecColumn"].ReadOnly = false;
                    row.Cells["ＪＡＮコード"].ReadOnly = false;
                    row.Cells["原単価"].ReadOnly = false;
                    row.Cells["売単価"].ReadOnly = false;
                    row.Cells["ロット"].ReadOnly = false;

                }
                else // cell.Value is null
                {
                    row.Cells["genreNameColumn"].ReadOnly = true;
                    row.Cells["productNameColumn"].ReadOnly = true;
                    row.Cells["productSpecColumn"].ReadOnly = true;
                    row.Cells["ＪＡＮコード"].ReadOnly = true;
                    row.Cells["原単価"].ReadOnly = false;
                    row.Cells["売単価"].ReadOnly = false;
                    row.Cells["ロット"].ReadOnly = true;

                }
            }
            else
                if (cell.OwningColumn == this.productCodeColumn)
                {
                    int productCode = Convert.ToInt32(cell.Value);
                    var item = this.itemPriceList.Find(o => o.商品コード == productCode);
                    if (item != null)
                    {
                        order.自社コード = item.自社コード;
                        order.ジャンル = Convert.ToInt16(item.ジャンル);
                        order.品名漢字 = item.商品名;
                        order.規格名漢字 = item.規格;
                        order.ＪＡＮコード = item.JANコード;
                        order.原単価_税抜_ = Convert.ToInt32(item.原単価);
                        order.売単価_税抜_ = Convert.ToInt32(item.売単価);
                        order.最小発注単位数量 = item.PT入数;
                        order.納品口数 = 0;
                        //cell.OwningRow.Cells["genreNameColumn"].Value = item.ジャンル;
                    }
                }

            #endregion

            #region MyRegion


            if (cell.OwningColumn == 受注数)
            {

                if (order.商品コード > 0)
                {
                    var amount = Convert.ToDouble(cell.Value);
                    var moq = Convert.ToDouble(order.最小発注単位数量);
                    if (moq > 0 && amount > 0)
                    {
                        order.納品口数 = (int)Math.Round(amount / moq);
                    }
                }

            }
            else if (cell.OwningColumn == 納品口数)
            {
                var amount = Convert.ToInt32(cell.Value);

                order.発注数量 = Convert.ToInt32(order.最小発注単位数量) * amount;
            }
            else if (cell.OwningColumn == this.原単価)
            {
                var val = Convert.ToInt32(cell.Value);
                order.原単価_税抜_ = val;
            }
            else if (cell.OwningColumn == this.売単価)
            {
                var val = Convert.ToInt32(cell.Value);
                order.売単価_税抜_ = val;
            }


            #endregion
            this.dataGridView1.Refresh();

        }

        private void storeBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }


        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //davX = e.RowIndex;
                    //davY = e.ColumnIndex;


                    //若行已是选中状态就不再进行设置
                    //if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    //{
                    //     dataGridView1.ClearSelection();
                    //     dataGridView1.Rows[e.RowIndex].Selected = true;
                    //}
                    //只选中一行时设置活动单元格
                    //if (dataGridView1.SelectedRows.Count == 1)
                    //{
                    //    //  dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //}
                    //弹出操作菜单
                    // contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }


        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.storeCodeTextBox.Text = this.storeComboBox.SelectedValue.ToString();
            buildNewOrders(Convert.ToInt32(this.storeComboBox.SelectedValue));
        }

        private void buildNewOrders(int storeId)
        {


            this.orderList.Clear();
            using (var ctx = new GODDbContext())
            {
                this.itemPriceList = (from i in ctx.t_itemlist
                                      join p in ctx.t_pricelist on i.自社コード equals p.自社コード
                                      join g in ctx.t_genre on i.ジャンル equals g.idジャンル
                                      join f in ctx.t_freights on
                                        new { p.transport_id, p.warehouse_id, p.自社コード, shop_id= p.店番 } equals
                                        new { f.transport_id, f.warehouse_id, f.自社コード, f.shop_id  }
                                      where p.店番 == storeId
                                      select new v_itemprice { 配送担当 = p.配送担当, 自社コード = i.自社コード, ジャンル = g.idジャンル, ジャンル名 = g.ジャンル名, 商品コード = i.商品コード, JANコード = i.JANコード, 商品名 = i.商品名, 原単価 = p.通常原単価, 売単価 = p.売単価, 規格 = i.規格, PT入数 = i.PT入数, 単品重量 = i.単品重量, 単位 = i.単位, fee = f.fee, columnname=f.columnname }).ToList();
            }

            for (int i = 0; i < 10; i++)
            {
                t_orderdata order = new t_orderdata();
                order.発注日 = orderCreatedAtDateTimePicker.Value.Date;
                order.受注日 = orderCreatedAtDateTimePicker.Value.Date;
                order.納品予定日 = deliveredAtDateTimePicker.Value.Date;

                order.店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                order.仕入先コード = Convert.ToInt32(selfCodeTextBox1.Text);
                order.出荷業務仕入先コード = Convert.ToInt32(this.shipperTextBox.Text);
                order.仕入先名漢字 = this.selfNameTextBox.Text;
                order.店舗名漢字 = this.storeComboBox.Text;
                order.法人コード = Convert.ToInt16(this.customerIdTextBox.Text);
                order.法人名漢字 = this.customerComboBox.Text;
                order.部門コード = Convert.ToInt16(this.textBox5.Text);
                order.納品予定日 = this.deliveredAtDateTimePicker.Value.Date;
                if (this.locationTextBox.Enabled)
                {
                    var lid = (short)Convert.ToInt16(this.locationComboBox.SelectedValue);
                    if (lid > 0)
                    {
                        var location = this.locationList.FirstOrDefault(l => l.店舗コード == order.店舗コード && l.納品場所コード == lid);
                        order.納品場所コード = location.納品場所コード;
                        order.納品場所名漢字 = location.納品場所名漢字;
                        order.納品場所名カナ = location.納品場所名カナ;
                    }
                    else
                    {
                        order.納品場所コード = -1;
                        order.納品場所名漢字 = "";
                        order.納品場所名カナ = "";
                    }
                }
                else
                {
                    order.納品場所コード = -1;
                    order.納品場所名漢字 = "";
                    order.納品場所名カナ = "";
                }
                //order.納品先店舗名漢字 = this.locationComboBox.Text;
                order.発注形態区分 = (short)this.orderReasonComboBox.SelectedValue;
                order.発注形態名称漢字 = this.orderReasonComboBox.Text;

                if (i == 0)
                {
                    order.伝票番号 = GenerateInvoiceNo(order.店舗コード);
                }
                else
                {
                    order.伝票番号 = GetNextByInvoiceNO(this.orderList[i - 1].伝票番号);
                }

                // set default ジャンル, or get error when drawing grid
                order.ジャンル = genreList.First().idジャンル;

                order.備考 = "FAX";

                this.orderList.Add(order);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
            {
                ResetOrderByIndex(e.RowIndex);
            }


        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (selectProductForm == null)
            {
                selectProductForm = new SelectProductForm();
            }


            var result = selectProductForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int code = selectProductForm.selectedItemCode;
                AddAutoOrder(code);
            }
            else if (result == System.Windows.Forms.DialogResult.Ignore)
            {
                AddManualOrder();
            }


            #endregion

        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];


            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //handle datagridview combo box event
            //http://blog.csdn.net/suncherrydream/article/details/19153163

            var dgv = sender as DataGridView;

            if (dgv.CurrentCell.OwningColumn == specialCodeColumn)
            {

                specialColumn = e.Control as ComboBox;

                //每次注册事件的时候先移除事件，避免不断被递归调用

                specialColumn.SelectedIndexChanged -= new EventHandler(specialCodeColumn_SelectedIndexChanged);

                specialColumn.SelectedIndexChanged += new EventHandler(specialCodeColumn_SelectedIndexChanged);

            }
        }
        private void specialCodeColumn_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void ResetOrderByIndex(int i)
        {
            var order = orderList[i];
            order.商品コード = 0;
            order.発注数量 = 0;
            order.規格名漢字 = "";
            order.品名漢字 = "";
            order.ＪＡＮコード = 0;
            order.最小発注単位数量 = 0;
            order.納品口数 = 0;
            order.発注数量 = 0;
            //order.ジャンル = 0;
            order.原単価_税抜_ = 0;
            order.売単価_税抜_ = 0;

            //var row = dataGridView1.Rows[i];
            //row.Cells["genreNameColumn"].Value = null;

            this.dataGridView1.Refresh();
        }

        private void AddManualOrder()
        {
            int selectedRowIndex = this.dataGridView1.CurrentRow.Index;
            var row = dataGridView1.Rows[selectedRowIndex];

            row.Cells["productNameColumn"].ReadOnly = false;
            orderList[selectedRowIndex].規格名漢字 = "";
            orderList[selectedRowIndex].ＪＡＮコード = 0;
            orderList[selectedRowIndex].発注数量 = 0;
            orderList[selectedRowIndex].原単価_税抜_ = 0;
            orderList[selectedRowIndex].売単価_税抜_ = 0;
            orderList[selectedRowIndex].最小発注単位数量 = 0;
            this.dataGridView1.Refresh();
        }

        private void AddAutoOrder(int itemCode)
        {
            int selectedRowIndex = this.dataGridView1.CurrentRow.Index;
            var row = dataGridView1.Rows[selectedRowIndex];


            v_itemprice selectedItem = itemPriceList.Find(o => o.自社コード == itemCode);
            if (selectedItem != null)
            {
                orderList[selectedRowIndex].自社コード = itemCode;
                orderList[selectedRowIndex].商品コード = Convert.ToInt32(selectedItem.商品コード);
                orderList[selectedRowIndex].ジャンル = Convert.ToInt16(selectedItem.ジャンル);
                orderList[selectedRowIndex].品名漢字 = selectedItem.商品名;
                orderList[selectedRowIndex].規格名漢字 = selectedItem.規格;
                orderList[selectedRowIndex].ＪＡＮコード = selectedItem.JANコード;
                orderList[selectedRowIndex].最小発注単位数量 = Convert.ToInt32(selectedItem.PT入数);

                #region 从 t_pricelist 表中读取的价格

                orderList[selectedRowIndex].原単価_税抜_ = Convert.ToInt32(selectedItem.原単価);
                orderList[selectedRowIndex].売単価_税抜_ = Convert.ToInt32(selectedItem.売単価);

                #endregion
                //row.Cells["genreNameColumn"].Value = selectedItem.ジャンル名;
                this.dataGridView1.Refresh();
            }
            else
            {

                MessageBox.Show(String.Format("商品コード {0}, の商品単価は登録されていません。単価リストに登録してください.", itemCode));
            }
        }

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            locationTextBox.Text = locationComboBox.SelectedValue.ToString();
        }


        private void SetOrderBaseInfo(t_orderdata order)
        {
            order.税区分 = 1;
            order.発注日 = orderCreatedAtDateTimePicker.Value.Date;
            order.受注日 = orderCreatedAtDateTimePicker.Value.Date;
            order.法人コード = Convert.ToInt16(this.customerIdTextBox.Text);
            order.法人名漢字 = this.customerComboBox.Text;

            order.部門コード = Convert.ToInt16(this.textBox5.Text);
            order.納品予定日 = this.deliveredAtDateTimePicker.Value.Date;
            if (this.locationTextBox.Enabled)
            {
                var lid = (short)Convert.ToInt16(this.locationComboBox.SelectedValue);
                if (lid >= 0)
                {
                    var location = this.locationList.FirstOrDefault(l => l.店舗コード == order.店舗コード && l.納品場所コード == lid);
                    order.納品場所コード = location.納品場所コード;
                    order.納品場所名漢字 = location.納品場所名漢字;
                    order.納品場所名カナ = location.納品場所名カナ;
                }
                else
                {
                    order.納品場所コード = -1;
                    order.納品場所名漢字 = "";
                    order.納品場所名カナ = "";
                }
            }
            else
            {
                order.納品場所コード = -1;
                order.納品場所名漢字 = "";
                order.納品場所名カナ = "";
            }
            //order.納品先店舗名漢字 = this.locationComboBox.Text;
            order.発注形態区分 = (short)this.orderReasonComboBox.SelectedValue;
            order.発注形態名称漢字 = this.orderReasonComboBox.Text;
            order.一旦保留 = true;
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerIdTextBox.Text = customerComboBox.SelectedValue.ToString();

            int customerId = (int) customerComboBox.SelectedValue ;

            var stores = shopList.FindAll(o => o.customerId == customerId).ToList();
            this.storeComboBox.DisplayMember = "店名";
            this.storeComboBox.ValueMember = "店番";
            this.storeComboBox.DataSource = stores;
        }

        //http://blog.sina.com.cn/s/blog_463b79ca01019b46.html
        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //这种判断方法的关键是要知道EditedFormattedValue存放的是编辑的新值，而Value和FormattedValue存放的是编辑前的值。
            DataGridView dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //daGrid.CurrentCell.EditedFormattedValue.ToString
            if (cell.OwningColumn == this.productSpecColumn || cell.OwningColumn == this.productNameColumn)
            {
                if (cell.EditedFormattedValue != null && cell.EditedFormattedValue.ToString() != String.Empty)
                {
                    if (!EDITxtHandler.IsAllQuanjiaoJapan(cell.EditedFormattedValue.ToString()))
                    {
                        MessageBox.Show("商品名と規格名を全角で入力ください！");//输入数据包含半角字符
                    }
                }
            }
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            {
                try
                {
                    //BindingList<t_orderdata> newOrderList = new BindingList<t_orderdata>();
                    newOrderList = this.orderList.Where(o => o.発注数量 > 0).ToList();

                    if (newOrderList.Count > 0)
                    {
                        int storeCode = (int)this.storeComboBox.SelectedValue;
                        var store = shopList.Find(s => s.店番 == storeCode);
                        

                        using (var ctx = new GODDbContext())
                        {

                            foreach (var o in newOrderList)
                            {
                                v_itemprice selectedItem = itemPriceList.Find(i => i.自社コード == o.自社コード);

                                SetOrderBaseInfo(o);
                                o.納品先店舗コード = (short)o.店舗コード;
                                o.納品先店舗名漢字 = o.店舗名漢字;
                                o.税率 = 0.08;
                                o.特価区分 = 0;
                                o.PB区分 = 0;
                                o.原価区分 = 0;
                                o.納期回答区分 = 0;
                                o.回答納期 = "00000000";
                                o.入力区分 = 1;
                                o.実際出荷数量 = o.発注数量;
                                o.口数 = o.納品口数;

                                if (selectedItem == null)
                                {
                                    MessageBox.Show(String.Format("誤った: 単品重量, 商品コード! されていません"));
                                    return;
                                }
                                if (selectedItem.warehouseName.Length == 0 || selectedItem.配送担当.Length == 0)
                                {
                                    /// TODO
                                    MessageBox.Show(string.Format("error: please set default warehouse and 配送担当 of product {0}", selectedItem.商品名));
                                    return;
                                }

                                o.重量 = (int)(Convert.ToDecimal(selectedItem.単品重量) * o.発注数量);
                                o.単位 = selectedItem.単位;
                                o.県別 = store.県別;
                                o.発注形態区分 = Convert.ToInt16(this.orderReasonComboBox.SelectedValue);
                                o.発注形態名称漢字 = this.orderReasonComboBox.Text;
                                //o.原単価_税抜_ = (int)selectedItem.原単価;
                                o.原単価_税込_ = ((int)(o.原単価_税抜_ * (1 + o.税率) * 100)) * 1.0 / 100;

                                o.原価金額_税抜_ = o.実際出荷数量 * o.原単価_税抜_;
                                o.原価金額_税込_ = (int)(o.実際出荷数量 * o.原単価_税込_);

                                o.納品原価金額 = o.原価金額_税抜_;

                                //o.売単価_税抜_ = (int)selectedItem.売単価;
                                o.売単価_税込_ = (int)(o.売単価_税抜_ * (1 + o.税率));
                                o.税額 = (int)(o.原価金額_税抜_ * o.税率);

                                o.仕入原価 = selectedItem.仕入原価;
                                o.仕入金額 = o.実際出荷数量 * o.仕入原価;
                                o.粗利金額 = o.納品原価金額 - o.仕入金額; 

                                o.発注品名漢字 = o.品名漢字;
                                o.発注規格名漢字 = o.規格名漢字;
                                o.用度品区分 = 0;
                                o.id = String.Format("{0}a{1}", o.店舗コード, o.伝票番号);

                                //判断全角半角
                                bool isrun = true;

                               
                                if (o.発注品名漢字 != null)
                                {
                                    isrun = QuanJiaoBanJiao(o.発注品名漢字);
                                    if (isrun == false)
                                        return;
                                }

                                if (o.発注規格名漢字 != null)
                                {
                                    isrun = QuanJiaoBanJiao(o.発注規格名漢字);
                                    if (isrun == false)
                                        return;
                                }
                                o.実際配送担当 = selectedItem.配送担当;
                                o.warehouseName = selectedItem.warehouseName;

                                // 社内伝番処理使用缺省配置
                                o.社内伝番処理 = OrderSqlHelper.IsInnerCodeRequired(o.ジャンル);

                                // 
                                //if (o.実際配送担当 == "MKL" && (o.ジャンル == 1001 || o.ジャンル == 1003))
                                //{
                                //    o.実際配送担当 = "丸健";
                                //}
                                o.週目 = OrderSqlHelper.GetOrderWeekOfYear(o.受注日.Value);

                                o.運賃 = OrderSqlHelper.ComputeFreight(o, selectedItem.fee, selectedItem.columnname);

                            }
                            ctx.t_orderdata.AddRange(newOrderList);
                            ctx.SaveChanges();
                            MessageBox.Show(String.Format("{0} 枚のFAX注文登録完了!", newOrderList.Count));
                            orderList.Clear();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("誤った: 単品重量, 商品コード! されていません"));
                    return;

                    throw;
                }

            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }


    }
}
