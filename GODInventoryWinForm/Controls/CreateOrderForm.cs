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


namespace GODInventoryWinForm.Controls
{
    public partial class CreateOrderForm : Form
    {

        List<int> newfaxno = new List<int>();
        private List<t_orderdata> orders1;
        private List<t_shoplist> shopList;
        private List<v_itemprice> itemPriceList;
        private List<t_locations> locationList;
        private BindingList<t_orderdata> orderList;
        private List<t_pricelist> t_pricelistR;
        private ComboBox specialColumn; 

        private SelectProductForm selectProductForm;
        int davX = 0;
        int davY = 0;

        public CreateOrderForm()
        {
            InitializeComponent();

            orderList = new BindingList<t_orderdata>();

            shopList = new List<t_shoplist>();
            locationList = new List<t_locations>();

            using (var ctx = new GODDbContext())
            {

                shopList = ctx.t_shoplist.ToList();

                locationList = ctx.t_locations.ToList();
                t_pricelistR = ctx.t_pricelist.ToList();

            }
            selfCodeTextBox1.Text = Properties.Settings.Default.Createorder_scc;
            shipperTextBox.Text = Properties.Settings.Default.Createorder_hsbsc;
            selfNameTextBox.Text = Properties.Settings.Default.Createorder_sog;

            //orderReasonDataGridviewComboBox.ValueType = typeof(OrderReasonEnum);
            this.orderReasonComboBox.ValueMember = "Value";
            this.orderReasonComboBox.DisplayMember = "Display";
            this.orderReasonComboBox.DataSource = new OrderReasonEnum[] { OrderReasonEnum.補充, OrderReasonEnum.客注, OrderReasonEnum.用度品, OrderReasonEnum.広告, OrderReasonEnum.新店 }
                .Select(value => new { Display = value.ToString(), Value = (short)value })
                .ToList();
            this.orderReasonComboBox.SelectedIndex = 0;

            this.storeComboBox.DisplayMember = "店名";
            this.storeComboBox.ValueMember = "店番";
            this.storeComboBox.DataSource = shopList;

            this.locationComboBox.DisplayMember = "納品場所名略称";
            this.locationComboBox.ValueMember = "Id";


            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = orderList;
        }

        private void NewOrdersForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //try
            //{


                //if (storeCodeTextBox.Text == "" || productCodeTextBox.Text == "")
                //{
                //    MessageBox.Show("内容を书いてください", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //if (Convert.ToInt32(orderQuantityTextBox.Text) == 0)
                //{
                //    MessageBox.Show(" 発注数量  ゼロにできない", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //if (invoiceNOTextBox.Text.Length != 8)
                //{
                //    if (MessageBox.Show("伝票番号  キャラクタ丈正しくない, 引き続き?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //    {
                //    }
                //    else
                //        return;
                //}
                //受注日, 伝票番号, 発注日, 店舗コード, 店舗名漢字, JANコード, 商品コード, 品名漢字, 規格名漢字,  発注数量
                //原単価(税抜),原価金額(税抜), 売単価(税抜),納品先店舗コード, 納品先店舗名漢字, 納品場所名漢字

            //    t_orderdata order = new t_orderdata();
            //    order.受注日 = DateTime.Now;
            //    order.発注日 = orderCreatedAtDateTimePicker.Value;

            //    order.店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
            //    //order.商品コード = Convert.ToInt32(productCodeTextBox.Text);
            //    //order.発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);

            //    order.仕入先コード = Convert.ToInt32(selfCodeTextBox1.Text);
            //    order.出荷業務仕入先コード = Convert.ToInt32(this.shipperTextBox.Text);
            //    order.仕入先名カナ = this.selfNameTextBox.Text;
            //    order.店舗名漢字 = this.storeComboBox.Text;
            //    order.法人コード = Convert.ToInt16(this.customerIdTextBox.Text);
            //    order.法人名漢字 = this.customerComboBox.Text;
            //    order.部門コード = Convert.ToInt16(this.textBox5.Text);
            //    order.納品予定日 = this.dateTimePicker1.Value;
            //    order.納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
            //    order.納品先店舗名漢字 = this.locationComboBox.Text;

            //    order.伝票番号 = GenerateInvoiceNo(order.店舗コード);

            //    #region 联动
            //    foreach (t_rcvdata item in t_rcvdataR)
            //    {

            //        if (item.商品コード == Convert.ToDouble(order.商品コード))
            //        {
            //            order.品名漢字 = item.品名漢字.ToString();
            //            order.規格名漢字 = item.規格名漢字.ToString();
            //            order.原単価_税抜_ = Convert.ToInt32(item.原単価_税抜_.ToString());
            //            order.売単価_税抜_ = Convert.ToInt32(item.売単価_税抜_.ToString());
            //            order.ＪＡＮコード = long.Parse(item.ＪＡＮコード.ToString());
            //            break;

            //        }

            //    }
            //    #endregion

            //    orderList.Add(order);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ex" + ex, "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            
                //BindingList<t_orderdata> newOrderList = new BindingList<t_orderdata>();
                var newOrderList = this.orderList.Where(o => o.発注数量 > 0).ToList();

                if (newOrderList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        ctx.t_orderdata.AddRange(newOrderList);
                        ctx.SaveChanges();
                        MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", newOrderList.Count));
                        orderList.Clear();
                    }

                }
                     
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
                    var shops = this.shopList.Where(s => s.店番.ToString().StartsWith(storeId.ToString())).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();
                        var locations = this.locationList.Where(l => l.店舗コード == store.店番).ToList();
                        this.locationComboBox.DataSource = locations;
                        if (locations.Count > 0)
                        {
                            this.locationComboBox.SelectedIndex = 0;
                            this.locationTextBox.Text = this.locationComboBox.SelectedValue.ToString();
                        }
                        else
                        {
                            this.locationTextBox.Text = "0";
                        }

                        #region new

                        this.storeComboBox.SelectedValue = store.店番;
  
                        #endregion
                    }
                    else
                    {
                        errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeId));
                    }

                }
                else
                {
                    errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeCodeTextBox.Text));
                }
            }

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            var locationId = Convert.ToInt16( locationTextBox.Text );
            var locations = this.locationComboBox.DataSource as List<t_locations>;
            if (locations != null) {
                if( locations.Exists( i=> i.納品場所コード == locationId)) {
                    this.locationComboBox.SelectedValue = locationId;     
                }
                
            }
                   

        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn == 受注数)
            {

                //orderList[davX].受注日 = DateTime.Now;
                //orderList[davX].発注日 = orderCreatedAtDateTimePicker.Value;
                //if (storeCodeTextBox.Text != "")
                //    orderList[davX].店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                ////if (productCodeTextBox.Text != "")
                ////    orderList[davX].商品コード = Convert.ToInt32(productCodeTextBox.Text);
                ////if (orderQuantityTextBox.Text != "")
                ////    orderList[davX].発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);
                //if (selfCodeTextBox1.Text != "")
                //    orderList[davX].仕入先コード = Convert.ToInt32(selfCodeTextBox1.Text);
                //if (shipperTextBox.Text != "")
                //    orderList[davX].出荷業務仕入先コード = Convert.ToInt32(this.shipperTextBox.Text);
                //orderList[davX].仕入先名カナ = this.selfNameTextBox.Text;
                //orderList[davX].店舗名漢字 = this.storeComboBox.Text;
                //if (customerIdTextBox.Text != "")
                //    orderList[davX].法人コード = Convert.ToInt16(this.customerIdTextBox.Text);
                //orderList[davX].法人名漢字 = this.customerComboBox.Text;
                //if (textBox5.Text != "")
                //    orderList[davX].部門コード = Convert.ToInt16(this.textBox5.Text);
                //orderList[davX].納品予定日 = this.dateTimePicker1.Value;
                //if (locationTextBox.Text != "")
                //    orderList[davX].納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                //orderList[davX].納品先店舗名漢字 = this.locationComboBox.Text;


            }

        }

        private int GenerateInvoiceNumber(int store_id)
        {

            int num = 1;
            using (var ctx = new GODDbContext())
            {
                var last_order = (from s in ctx.t_orderdata
                                  where s.店舗コード == ((short)store_id)
                                  orderby s.発注日 descending, s.伝票番号 descending
                                  select s).FirstOrDefault();
                if (last_order != null)
                {

                    num = last_order.伝票番号 + 1;
                }
            }
            return num;
        }


        private int GenerateInvoiceNo(int storeId)
        {
            int invoiceNo = lastInvoiceNOByStoreId(storeId);

            int position = GetPositionByInvoiceNO(invoiceNo);
            position %= 99999; // max position is 99999,
            position += (1 + orderList.Count);

            return (position * 10) + (position % 7);

        }

        private int lastInvoiceNOByStoreId(int storeId)
        {


            int invoiceNo = 0;
            using (var ctx = new GODDbContext())
            {
                var last_order = (from s in ctx.t_orderdata
                                  where s.店舗コード == ((short)storeId)
                                  orderby s.発注日 descending, s.伝票番号 descending
                                  select s).FirstOrDefault();
                if (last_order != null)
                {

                    invoiceNo = last_order.伝票番号;
                }
            }
            return invoiceNo;


        }

        private int GetPositionByInvoiceNO(int invoiceNo)
        {

            return invoiceNo / 10;
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

            if (cell.OwningColumn == this.productCodeColumn)
            {
                int productCode = Convert.ToInt32( cell.Value);
                var item = this.itemPriceList.Find( o => o.商品コード == productCode);
                if (item != null) {
                    order.ジャンル = item.ジャンル;
                    order.品名漢字 = item.商品名;
                    order.規格名漢字 = item.規格;
                    order.ＪＡＮコード = item.JANコード;
                    order.原単価_税抜_ = Convert.ToInt32( item.原単価 );
                    order.売単価_税抜_ = Convert.ToInt32( item.原単価 );
                    order.口数 = item.PT入数;
                    order.納品口数 = 0;
                    cell.OwningRow.Cells["genreNameColumn"].Value = item.ジャンル名;
                }
            }  

            #endregion

            #region MyRegion
            

            if (cell.OwningColumn == 受注数)
            {

                if (order.商品コード > 0)
                {
                    var amount = Convert.ToDouble(cell.Value);
                    var moq = Convert.ToDouble(order.口数);
                    if( moq>0 && amount>0){
                        order.納品口数 = (int)Math.Round(amount / moq);
                    }
                }
                
                //orderList[i].受注日 = DateTime.Now;
                //orderList[i].発注日 = orderCreatedAtDateTimePicker.Value;
                //orderList[i].店舗コード = Convert.ToInt16(storeCodeTextBox.Text);                    
                //orderList[i].仕入先コード = Convert.ToInt32(selfCodeTextBox1.Text);
                //orderList[i].出荷業務仕入先コード = Convert.ToInt32(this.shipperTextBox.Text);
                //orderList[i].仕入先名カナ = this.selfNameTextBox.Text;
                //orderList[i].店舗名漢字 = this.storeComboBox.Text;
                //orderList[i].法人コード = Convert.ToInt16(this.customerIdTextBox.Text);
                //orderList[i].法人名漢字 = this.customerComboBox.Text;
                //orderList[i].部門コード = Convert.ToInt16(this.textBox5.Text);
                //orderList[i].納品予定日 = this.dateTimePicker1.Value;
                //orderList[i].納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                //orderList[i].納品先店舗名漢字 = this.locationComboBox.Text;
            }
            else if (cell.OwningColumn == 納品口数)
            { 
                var amount = Convert.ToInt32(cell.Value);

                order.発注数量 = Convert.ToInt32(order.口数) * amount;
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

        private void buildNewOrders(int  storeId ){

              
                  this.orderList.Clear();
                  using (var ctx = new GODDbContext())
                  {
                      this.itemPriceList = (from i in ctx.t_itemlist
                                            join p in ctx.t_pricelist on i.自社コード equals p.自社コード
                                            join g in ctx.t_genre on i.ジャンル equals g.idジャンル
                                            where p.店番 == storeId
                                            select new v_itemprice { 自社コード = i.自社コード, ジャンル名 = g.ジャンル名, 商品コード = i.商品コード, JANコード = i.JANコード, 商品名 = i.商品名, 原単価 = p.通常売価, 規格 = i.規格, PT入数 = i.PT入数 }).ToList();
                  }

                  for (int i = 0; i < 10; i++)
                  {
                      t_orderdata order = new t_orderdata();
                      order.受注日 = DateTime.Now;
                      order.発注日 = orderCreatedAtDateTimePicker.Value.Date;

                      order.店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                      //order.商品コード = Convert.ToInt32(productCodeTextBox.Text);
                      //order.発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);

                      order.仕入先コード = Convert.ToInt32(selfCodeTextBox1.Text);
                      order.出荷業務仕入先コード = Convert.ToInt32(this.shipperTextBox.Text);
                      order.仕入先名カナ = this.selfNameTextBox.Text;
                      order.店舗名漢字 = this.storeComboBox.Text;
                      order.法人コード = Convert.ToInt16(this.customerIdTextBox.Text);
                      order.法人名漢字 = this.customerComboBox.Text;
                      order.部門コード = Convert.ToInt16(this.textBox5.Text);
                      order.納品予定日 = this.dateTimePicker1.Value.Date;
                      order.納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                      //order.納品先店舗名漢字 = this.locationComboBox.Text;
                      order.発注形態区分 = (short)this.orderReasonComboBox.SelectedValue;
                      order.発注形態名称漢字 = this.orderReasonComboBox.Text;

                      if (i == 0)
                      {
                          order.伝票番号 = GenerateInvoiceNo(order.店舗コード);
                      }
                      else {

                          order.伝票番号 = this.orderList[i-1].伝票番号 + 1;
                      }

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
            else if (result == System.Windows.Forms.DialogResult.Ignore) {
                AddManualOrder();
            }
           

            #endregion

        }

        //void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        //{
            
        //    if (sender is SelectProductForm)
        //    {
        //        int selectedRowIndex = this.dataGridView1.CurrentRow.Index;
        //        var row = dataGridView1.Rows[selectedRowIndex];

        //        if (selectProductForm.ischeckmunal == false)
        //        {
        //            v_itemprice selectedItem = itemPriceList.Find( o=> o.自社コード==selectProductForm.selectedItemCode);
        //            if (selectedItem != null)
        //            {
        //                orderList[selectedRowIndex].商品コード = Convert.ToInt32(selectedItem.商品コード);
        //                orderList[selectedRowIndex].ジャンル = selectedItem.ジャンル;
        //                orderList[selectedRowIndex].品名漢字 = selectedItem.商品名;
        //                orderList[selectedRowIndex].規格名漢字 = selectedItem.規格;
        //                orderList[selectedRowIndex].ＪＡＮコード = selectedItem.JANコード;
        //                orderList[selectedRowIndex].発注数量 = Convert.ToInt32(selectedItem.ロット);

        //                #region 从 t_pricelist 表中读取的价格

        //                orderList[selectedRowIndex].原単価_税抜_ = Convert.ToInt32(selectedItem.原単価);
        //                orderList[selectedRowIndex].売単価_税抜_ = Convert.ToInt32(selectedItem.原単価);

        //                #endregion
        //                row.Cells["genreNameColumn"].Value = selectedItem.ジャンル名;
        //            }
        //            else { 
                    
        //               MessageBox.Show( String.Format( "Sorry, can not find item price by code {0}, please add it into t_pricelist.", selectProductForm.selectedItemCode ));
        //            }
                    
        //        }
        //        else
        //        {

        //            row.Cells["productNameColumn"].ReadOnly = false;
        //            orderList[selectedRowIndex].規格名漢字 = "";
        //            orderList[selectedRowIndex].ＪＡＮコード = 0;
        //            orderList[selectedRowIndex].発注数量 = 0;
        //            orderList[selectedRowIndex].原単価_税抜_ = 0;
        //            orderList[selectedRowIndex].売単価_税抜_ = 0;
        //            orderList[selectedRowIndex].口数 = 0;
        //        }
        //        this.dataGridView1.Refresh();

        //        selectProductForm = null;
        //    }
        //}

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) { 
            
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.OwningColumn == specialCodeColumn)
                {
                    var row = cell.OwningRow;
                    if (cell.Value != null && cell.Value.ToString() == "YES")
                    {
                        //row.Cells["ジャンル"].ReadOnly = false;
                        row.Cells["productNameColumn"].ReadOnly = false;
                        row.Cells["productSpecColumn"].ReadOnly = false;
                        row.Cells["ＪＡＮコード"].ReadOnly = false;
                        row.Cells["原単価"].ReadOnly = false;
                        row.Cells["売単価"].ReadOnly = false;
                        row.Cells["ロット"].ReadOnly = false;

                    }else // cell.Value is null
                    {
                        //row.Cells["ジャンル"].ReadOnly = true;
                        row.Cells["productNameColumn"].ReadOnly = true;
                        row.Cells["productSpecColumn"].ReadOnly = true;
                        row.Cells["ＪＡＮコード"].ReadOnly = true;
                        row.Cells["原単価"].ReadOnly = true;
                        row.Cells["売単価"].ReadOnly = true;
                        row.Cells["ロット"].ReadOnly = true;

                    }
                     

                }
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
            order.口数 = 0;
            order.納品口数 = 0;
            order.発注数量 = 0;
            order.ジャンル = 0;
            order.原単価_税抜_ = 0;
            order.売単価_税抜_ = 0;

            var row = dataGridView1.Rows[i];
            row.Cells["genreNameColumn"].Value = null;

            this.dataGridView1.Refresh();
        }

        private void AddManualOrder() {
            int selectedRowIndex = this.dataGridView1.CurrentRow.Index;
            var row = dataGridView1.Rows[selectedRowIndex];

            row.Cells["productNameColumn"].ReadOnly = false;
            orderList[selectedRowIndex].規格名漢字 = "";
            orderList[selectedRowIndex].ＪＡＮコード = 0;
            orderList[selectedRowIndex].発注数量 = 0;
            orderList[selectedRowIndex].原単価_税抜_ = 0;
            orderList[selectedRowIndex].売単価_税抜_ = 0;
            orderList[selectedRowIndex].口数 = 0;
            this.dataGridView1.Refresh();
        }

        private void AddAutoOrder( int itemCode) { 
            int selectedRowIndex = this.dataGridView1.CurrentRow.Index;
            var row = dataGridView1.Rows[selectedRowIndex];


            v_itemprice selectedItem = itemPriceList.Find(o => o.自社コード == itemCode);
            if (selectedItem != null)
            {
                orderList[selectedRowIndex].商品コード = Convert.ToInt32(selectedItem.商品コード);
                orderList[selectedRowIndex].ジャンル = selectedItem.ジャンル;
                orderList[selectedRowIndex].品名漢字 = selectedItem.商品名;
                orderList[selectedRowIndex].規格名漢字 = selectedItem.規格;
                orderList[selectedRowIndex].ＪＡＮコード = selectedItem.JANコード;
                orderList[selectedRowIndex].発注数量 = Convert.ToInt32(selectedItem.ロット);

                #region 从 t_pricelist 表中读取的价格

                orderList[selectedRowIndex].原単価_税抜_ = Convert.ToInt32(selectedItem.原単価);
                orderList[selectedRowIndex].売単価_税抜_ = Convert.ToInt32(selectedItem.原単価);

                #endregion
                row.Cells["genreNameColumn"].Value = selectedItem.ジャンル名;
                this.dataGridView1.Refresh();
            }
            else { 
                    
                MessageBox.Show( String.Format( "Sorry, can not find item price by code {0}, please add it into t_pricelist.", itemCode ));
            }
        }
    }
}
