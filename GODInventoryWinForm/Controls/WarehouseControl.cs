﻿using System;
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
        private InputStock InputStock;
        private OutputStock OutputStock;
        private StockMovement StockTransfer;
        private InventoryForm Strock_Check;


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
                Strock_Check = null;
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
            StockTransfer.ShowDialog();



            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (Strock_Check == null)
            {
                Strock_Check = new InventoryForm();
                Strock_Check.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (Strock_Check == null)
            {
                Strock_Check = new InventoryForm();
            }
            Strock_Check.ShowDialog();

            #endregion
        }

    }
}
