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
    public partial class WarehouseControl : UserControl
    {
        //private InputStock InputStock;
        private OutputStock OutputStock;
        private StockMovement StockTransfer;
        private InventoryForm StockCheckForm;
        private CopyofInputStock CopyofInputStock;
        private Transports.IndexForm transportsIndexForm;
        private Warehouse.IndexForm warehouseIndexForm;

        
        private SearchStock Search_Strock;

        public WarehouseControl()
        {
            InitializeComponent();
        }

        private void WarehouseControl_Paint(object sender, PaintEventArgs e)
        {
            contentPanel.Left = (this.Width - contentPanel.Width) / 2;
            contentPanel.Top = (this.Height - contentPanel.Height) / 2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //if (InputStock == null)
            //{
            //    InputStock = new InputStock();
            //    InputStock.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            //}
            //if (InputStock == null)
            //{
            //    InputStock = new InputStock();
            //}
            //AdjustSubformSize(InputStock);

            //InputStock.ShowDialog();

            #endregion
              #region MyRegion
            if (CopyofInputStock == null)
            {
                CopyofInputStock = new CopyofInputStock();
                CopyofInputStock.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (CopyofInputStock == null)
            {
                CopyofInputStock = new CopyofInputStock();
            }
            AdjustSubformSize(CopyofInputStock);

            CopyofInputStock.ShowDialog();

            #endregion
            

        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            

            if (sender is OutputStock)
            {
                OutputStock = null;
            }
            if (sender is StockMovement)
            {
                StockTransfer = null;
            }
            if (sender is SearchStock)
            {
                Search_Strock = null;
            }
            if (sender is InventoryForm)
            {
                StockCheckForm = null;
            }
            if (sender is CopyofInputStock)
            {
                CopyofInputStock = null;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (OutputStock == null)
            {
                OutputStock = new OutputStock();
                OutputStock.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (OutputStock == null)
            {
                OutputStock = new OutputStock();
            }
            AdjustSubformSize(OutputStock);
            OutputStock.ShowDialog();

            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (Search_Strock == null)
            {
                Search_Strock = new SearchStock();
                Search_Strock.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (Search_Strock == null)
            {
                Search_Strock = new SearchStock();
            }
            AdjustSubformSize(Search_Strock);

            Search_Strock.ShowDialog();

            #endregion

        }

        private void button4_Click(object sender, EventArgs e)
        {

            #region MyRegion
            if (StockTransfer == null)
            {
                StockTransfer = new StockMovement();
                StockTransfer.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (StockTransfer == null)
            {
                StockTransfer = new StockMovement();
            }
            AdjustSubformSize(StockTransfer);
            StockTransfer.ShowDialog();



            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (StockCheckForm == null)
            {
                StockCheckForm = new InventoryForm();
                StockCheckForm.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (StockCheckForm == null)
            {
                StockCheckForm = new InventoryForm();
            }
            AdjustSubformSize(StockCheckForm);
            StockCheckForm.ShowDialog();

            #endregion
        }

        private void AdjustSubformSize(Form form)
        {
            var size = this.Parent.Size;
            size.Height = size.Height - 100;
            size.Width = size.Width - 50;
            form.Size = size;
        }

        private void warehouseButton_Click(object sender, EventArgs e)
        {
            if (warehouseIndexForm == null)
            {
                warehouseIndexForm = new Warehouse.IndexForm();
            }
            //  AdjustSubformSize(CreateTransportForm);
            // 显示之前重新加载数据，订单数据可能已更新。
            warehouseIndexForm.ShowDialog(); 
            
        }

        private void transportButton_Click(object sender, EventArgs e)
        {
            if (transportsIndexForm == null)
            {
                transportsIndexForm = new Transports.IndexForm();
            }
            //  AdjustSubformSize(CreateTransportForm);
            // 显示之前重新加载数据，订单数据可能已更新。
            transportsIndexForm.ShowDialog();

        }
    }
}
