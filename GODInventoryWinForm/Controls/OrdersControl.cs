using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    public partial class OrdersControl : UserControl
    {
        private NewOrdersForm newOrdersForm;
        private PendingOrderForm pendingOrderForm;
        private WaitToShipForm waitToShipOrderForm;
        private ShippingOrderForm shippingOrderForm;

        public OrdersControl()
        {
            InitializeComponent();
           
            this.Disposed += new EventHandler(OrdersControl_Disposed);
            
        }


        private void pendingButton_Click(object sender, EventArgs e)
        {
            if (pendingOrderForm == null) {
                pendingOrderForm = new PendingOrderForm();
            }
            AdjustSubformSize(pendingOrderForm);
            pendingOrderForm.InitializePager();
            pendingOrderForm.ShowDialog(  );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (waitToShipOrderForm == null)
            {
                waitToShipOrderForm = new WaitToShipForm();
            }
            AdjustSubformSize(waitToShipOrderForm);
            // 显示之前重新加载数据，订单数据可能已更新。
            waitToShipOrderForm.RefreshPager();
            waitToShipOrderForm.ShowDialog();

        }

        private void shippedOrderButton_Click(object sender, EventArgs e)
        {
            if (shippingOrderForm == null)
            {
                shippingOrderForm = new ShippingOrderForm();
            } 
            AdjustSubformSize(shippingOrderForm);
            shippingOrderForm.RefreshPager();
            shippingOrderForm.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void OrdersControl_Load(object sender, EventArgs e)
        {
//            Console.WriteLine(" orders control demension {0}, {1}", this.Width, this.Height);
//            contentPanel.Left = (this.Width - contentPanel.Width) / 2;
//            contentPanel.Top = (this.Height - contentPanel.Height) / 2;
//            Console.WriteLine(" orders control demension {0}, {1}", contentPanel.Left, contentPanel.Top );
        }

        private void OrdersControl_Paint(object sender, PaintEventArgs e)
        {
            contentPanel.Left = (this.Width - contentPanel.Width) / 2;
            contentPanel.Top = (this.Height - contentPanel.Height) / 2;

        }


        private void receiveOrderButton_Click(object sender, EventArgs e)
        {
            new ReceiveForm().ShowDialog();
        }



        private void AdjustSubformSize(Form form) {
            var size = this.Parent.Size;
            size.Height = size.Height - 100;
            size.Width = size.Width - 50;
            form.Size = size;
        }

        private void OrdersControl_ControlRemoved(object sender, ControlEventArgs e)
        {
        }


        //Fix error 卸载 Appdomain 时出错
        void OrdersControl_Disposed(object sender, EventArgs e)
        {
            //this.pendingOrderForm.Dispose();
            //this.waitToShipOrderForm.Dispose();
            //this.shippingOrderForm.Dispose();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (newOrdersForm == null)
            {
                newOrdersForm = new NewOrdersForm();
            }
            AdjustSubformSize(newOrdersForm);
            // 显示之前重新加载数据，订单数据可能已更新。
            newOrdersForm.InitializeOrderData();
            newOrdersForm.ShowDialog();

        }
    }
}
