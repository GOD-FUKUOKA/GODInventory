using GODInventory.MyLinq;
using GODInventory.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    public partial class EditOrderForm2 : Form
    {
        private int orderId;
        private t_itemlist Product { get; set; }
        private t_stockrec Stockrec { get; set; }

        private t_orderdata OriginalOrder { get; set; }
        public t_orderdata Order { get; set; }
        public int OrderId
        {
            get { return orderId; } 
            set{
                orderId = value;
                InitializeOrder();
            } 
        }

        public EditOrderForm2()
        {
            InitializeComponent();
        }

        private void InitializeOrder()
        {
            this.qtyChangeReasonComboBox.ValueMember = "ID";
            this.qtyChangeReasonComboBox.DisplayMember = "FullName";
            this.qtyChangeReasonComboBox.DataSource = OrderQuantityChangeReasonRespository.ToList();

            var ctx = entityDataSource1.DbContext as GODDbContext;
            Order = ctx.t_orderdata.Find(OrderId);            
            Stockrec = ( from s in ctx.t_stockrec
                         where s.OrderId == OrderId
                         select s).FirstOrDefault();
            Product = (from p in ctx.t_itemlist
                       where p.自社コード == Order.自社コード
                       select p).First();
            if (Order != null) {

                this.OriginalOrder = new t_orderdata { キャンセル = Order.キャンセル, Status = Order.Status, 実際出荷数量 = Order.実際出荷数量 };
                InitializeControls();            
            }
        }

        private void InitializeControls() {

            this.storeNamTextBox.Text = Order.店舗名漢字;
            this.storeCodeTextBox.Text = Order.店舗コード.ToString();
            this.invoiceNOTextBox.Text = Order.伝票番号.ToString();
            this.countyTextBox1.Text = Order.県別;
            this.finalOrderQtyTextBox2.Text = Order.最終出荷数.ToString();


            if (Order.受注日 != null)
            {
                this.orderAtTextBox.Text = Order.受注日.GetValueOrDefault().ToShortDateString();
            }
            
            this.placedAtDateTimePicker1.Value = Order.発注日;

            if (Order.納品日 != null && Order.納品日> DateTime.MinValue)
            {
                this.fullfilledAtDateTimePicker2.Value = Order.納品日.GetValueOrDefault();
            }

            if (Order.出荷日 != null)
            {
                this.shipAtTextBox.Text = Order.出荷日.GetValueOrDefault().ToShortDateString();
            }
            this.productKanjiNameTextBox.Text = Order.品名漢字;
            this.productKanjiSpecificationTextBox.Text = Order.規格名漢字;
            //this.innerNOTextBox.Text = Order.社内伝番.ToString();

            this.shipperComboBox3.Text = Order.実際配送担当;

            this.orderQuantityTextBox11.Text = Order.実際出荷数量.ToString();

            this.cancelComboBox.Text = Order.キャンセル;

            this.qtyChangeReasonComboBox.SelectedValue = Order.訂正理由区分;

            if (Order.Status == OrderStatus.Cancelled || Order.Status == OrderStatus.Pending || Order.Status == OrderStatus.WaitToShip)
            {
                this.cancelComboBox.Enabled = true;
            }
            else {

                this.cancelComboBox.Enabled = false;
            }

            if (Order.Status == OrderStatus.Shipped || Order.Status == OrderStatus.Received || Order.Status == OrderStatus.Completed)
            {
                this.finalOrderQtyTextBox2.Enabled = true;
            }
            else
            {

                this.finalOrderQtyTextBox2.Enabled = false;
            }

        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {

            if (Order.Status == OrderStatus.Pending || Order.Status == OrderStatus.Duplicated)
            {
                if (Order.キャンセル == "yes")
                {
                    Order.訂正理由区分 = (int)qtyChangeReasonComboBox.SelectedValue;
                    Order.実際出荷数量 = 0;
                    Order.Status = OrderStatus.Cancelled;
                    OrderSqlHelper.AfterOrderQtyChanged(Order, Product);
                    OrderSqlHelper.CancelOrder(entityDataSource1.DbContext as GODDbContext, Order);
                }
                else {
                    Order.訂正理由区分 = (int)qtyChangeReasonComboBox.SelectedValue;
                    entityDataSource1.SaveChanges();                
                }

            }
            else if (Order.Status == OrderStatus.Cancelled)
            {
                if (Order.キャンセル == "no")
                {
                    //Order.Status = OrderStatus.Pending;
                    //Order.キャンセル時刻 = null;
                    //Order.実際出荷数量 = Order.発注数量;
                    //Order.納品口数 = Order.口数;
                    //Order.一旦保留 = true;
                    //entityDataSource1.SaveChanges();
                    OrderSqlHelper.UncancelOrder(entityDataSource1.DbContext as GODDbContext, Order);

                }
            }
            else {

                if (Order.キャンセル == "yes")
                {
                    Order.実際出荷数量 = 0;
                    Order.納品口数 = 0;
                    Order.Status = OrderStatus.Cancelled;
                    OrderSqlHelper.AfterOrderQtyChanged(Order, Product);
                    OrderSqlHelper.CancelOrder(entityDataSource1.DbContext as GODDbContext, Order);
                }
                else
                {

                    if (Order.納品日 != null)
                    {
                        Order.納品日 = this.fullfilledAtDateTimePicker2.Value;
                    }

                    Order.品名漢字 = this.productKanjiNameTextBox.Text;
                    Order.規格名漢字 = this.productKanjiSpecificationTextBox.Text;

                    Order.発注日 = this.placedAtDateTimePicker1.Value;
                    Order.訂正理由区分 = (int)qtyChangeReasonComboBox.SelectedValue;

                    Order.最終出荷数 = Convert.ToInt32(this.finalOrderQtyTextBox2.Text);

                    bool isQtyChanged = (Order.実際出荷数量 != OriginalOrder.実際出荷数量);
                    // 历史原因，有些订单没有出货记录
                    if (isQtyChanged)
                    {
                        OrderSqlHelper.AfterOrderQtyChanged(Order, Product);

                        if (Stockrec != null)
                        {
                            isQtyChanged = (Stockrec.数量 != -Order.実際出荷数量);
                            Stockrec.数量 = -Order.実際出荷数量;
                        }
                    }
                    entityDataSource1.SaveChanges();

                    if (isQtyChanged)
                    {
                        var stockrecs = new List<t_stockrec>() { Stockrec };
                        var ctx = entityDataSource1.DbContext as GODDbContext;
                        OrderSqlHelper.UpdateStockState(ctx, stockrecs);
                    }
                }
            }
                
            this.Close();
        }

        private void receivedAtTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void shipAtTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void orderQuantityTextBox11_TextChanged(object sender, EventArgs e)
        {
            if (orderQuantityTextBox11.Text.Length > 0) {

                //控制 実際出荷数量 <発注数量
                if (Order.発注数量 < Convert.ToInt32(orderQuantityTextBox11.Text))
                {
                    MessageBox.Show("実際出荷数量 >発注数量,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Order.実際出荷数量 = Convert.ToInt32(orderQuantityTextBox11.Text);
                if (Order.最小発注単位数量 > 0)
                {
                    Order.納品口数 = Order.実際出荷数量 / Order.最小発注単位数量;
                }
                else {
                    Order.納品口数 = 0;
                }
                Order.重量 = Convert.ToInt32( Order.実際出荷数量 * Product.単品重量 ); 
            }
        }

        private void cancelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //防止第一次初始化化
            string text = cancelComboBox.Text;
            if (Order.キャンセル != text)
            {
                if (text == "yes")
                {
                    Order.キャンセル = text;
                    Order.キャンセル時刻 = DateTime.Now;
                }
                else
                {
                    Order.キャンセル = text;
                    Order.キャンセル時刻 = null;
                }
            }

        }
    }
}
