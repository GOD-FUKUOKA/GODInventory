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
    public partial class StockOrderForm : UserControl
    {

        private InputStock InputStock;
        private OutputStock OutputStock;
        private StockTransfer StockTransfer;

        private Search_Strock Search_Strock;

        public StockOrderForm()
        {
            InitializeComponent();
        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is InputStock)
            {
                InputStock = null;
            }

            if (sender is OutputStock)
            {
                OutputStock = null;
            }
            if (sender is StockTransfer)
            {
                StockTransfer = null;
            }
            if (sender is Search_Strock)
            {
                Search_Strock = null;
            }

            
        }
        private void btRuku_Click(object sender, EventArgs e)
        {

            #region MyRegion
            if (InputStock == null)
            {
                InputStock = new InputStock();
                InputStock.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (InputStock == null)
            {
                InputStock = new InputStock();
            }
            InputStock.ShowDialog();

            #endregion
        }

        private void btexitstock_Click(object sender, EventArgs e)
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
            OutputStock.ShowDialog();

            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btTransferStrock_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (StockTransfer == null)
            {
                StockTransfer = new StockTransfer();
                StockTransfer.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (StockTransfer == null)
            {
                StockTransfer = new StockTransfer();
            }
            StockTransfer.ShowDialog();
              

            
            #endregion
        }

        private void btSearchtrock_Click(object sender, EventArgs e)
        {    
            
            #region MyRegion
            if (Search_Strock == null)
            {
                Search_Strock = new Search_Strock();
                Search_Strock.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (Search_Strock == null)
            {
                Search_Strock = new Search_Strock();
            }
            Search_Strock.ShowDialog();

            #endregion

        }

    }
}
