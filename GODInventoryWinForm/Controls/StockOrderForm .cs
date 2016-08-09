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

    }
}
