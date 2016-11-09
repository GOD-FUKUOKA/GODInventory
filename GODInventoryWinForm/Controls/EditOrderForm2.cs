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
        private int originalOrderQty;
        private t_itemlist Product { get; set; }
        private t_stockrec Stockrec { get; set; }

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
            var ctx = entityDataSource1.DbContext as GODDbContext;
            Order = ctx.t_orderdata.Find(OrderId);            
            Stockrec = ( from s in ctx.t_stockrec
                         where s.OrderId == OrderId
                         select s).FirstOrDefault();
            Product = (from p in ctx.t_itemlist
                       where p.自社コード == Order.自社コード
                       select p).First();
            if (Order != null) {
                InitializeControls();            
            }
        }

        private void InitializeControls() {
            originalOrderQty = Order.実際出荷数量;

            this.storeNamTextBox.Text = Order.店舗名漢字;
            this.storeCodeTextBox.Text = Order.店舗コード.ToString();
            this.invoiceNOTextBox.Text = Order.伝票番号.ToString();
            this.countyTextBox1.Text = Order.県別;
            if (Order.納品日 != null)
            {
                //this.deliveredAtTextBox.Text = Order.納品日.GetValueOrDefault().ToShortDateString();
            }
            if (Order.受注日 != null)
            {
                this.orderAtTextBox.Text = Order.受注日.GetValueOrDefault().ToShortDateString();
            }
            this.shipAtTextBox.Text = Order.発注日.ToShortDateString();
            this.productKanjiNameTextBox.Text = Order.品名漢字;
            this.productKanjiSpecificationTextBox.Text = Order.規格名漢字;
            //this.innerNOTextBox.Text = Order.社内伝番.ToString();

            this.shipperComboBox3.Text = Order.実際配送担当;

            this.orderQuantityTextBox11.Text = Order.実際出荷数量.ToString();

            this.cancelComboBox.Text = Order.キャンセル;

            if (Order.Status == OrderStatus.Cancelled || Order.Status == OrderStatus.WaitToShip)
            {
                this.cancelComboBox.Enabled = true;
            }
            else {

                this.cancelComboBox.Enabled = false;
            }
        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            if (Order.Status == OrderStatus.WaitToShip)
            {
                if (Order.キャンセル == "yes")
                {
                    Order.実際出荷数量 = 0;
                    Order.Status = OrderStatus.Cancelled;
                }

                Stockrec.数量 = -Order.実際出荷数量;
                entityDataSource1.SaveChanges();

                var stockrecs = new List<t_stockrec>() { Stockrec };
                var ctx = entityDataSource1.DbContext as GODDbContext;
                OrderSqlHelper.UpdateStockState(ctx, stockrecs);

            }
            else if (Order.Status == OrderStatus.Cancelled)
            {
                if (Order.キャンセル == "no")
                {
                    Order.Status = OrderStatus.Pending;
                    Order.キャンセル時刻 = null;
                    Order.実際出荷数量 = Order.発注数量;
                    Order.一旦保留 = true;
                    entityDataSource1.SaveChanges();
                }
            }
            else { 
            
            
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
