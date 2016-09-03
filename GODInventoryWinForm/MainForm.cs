using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    using GODInventoryWinForm.Controls;

    public partial class MainForm : Form
    {
        private ProductsControl products_control;
        private MainControl mainControl;
        private StoresControl storesControl;
        // initialize it on running, it is time consuming.
        private WarehouseControl warehouseControl;
        private OrdersControl orders_control;

        public MainForm()
        {
            InitializeComponent();
            InitUserControls();
        }

        private void InitUserControls() {
            LogHelper.WriteLog("Start initialize main control");
            mainControl = new MainControl();
            mainControl.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(mainControl);

            LogHelper.WriteLog("Start initialize ProductsControl");
            products_control = new ProductsControl();
            products_control.Dock = DockStyle.Fill;


            LogHelper.WriteLog("Start initialize StoresControl");
            storesControl = new StoresControl();
            storesControl.Dock = DockStyle.Fill;
            LogHelper.WriteLog("End initialize main control");

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (orders_control == null) {
                LogHelper.WriteLog("Start initialize OrdersControl");
                orders_control = new OrdersControl();
                orders_control.Dock = DockStyle.Fill;
            }
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(orders_control );
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(products_control);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(mainControl);
        }

        private void warehouseToolStripButton_Click(object sender, EventArgs e)
        {
            if( warehouseControl== null){
              warehouseControl = new WarehouseControl();
              warehouseControl.Dock = DockStyle.Fill;
            }
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(warehouseControl);
        }

        private void customerToolStripButton_Click(object sender, EventArgs e)
        {
         

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(storesControl);
            //this.panel1.Controls.Add(StockOrderForm);
        }

        private void settingToolStripButton_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
            
        }

        private void importOrderTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ImportOrderTextForm().ShowDialog();
        }

        private void exportASNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GenerateASNTextForm().ShowDialog();
        }

        private void importReceivedOrderTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ImportReceivedTextForm().ShowDialog();
        }

        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ImportOrderCSVForm().ShowDialog();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
