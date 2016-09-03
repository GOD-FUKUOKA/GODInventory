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
    public partial class StoresControl : UserControl
    {
        public StoresControl()
        {
            InitializeComponent();
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            this.entityDataSource1.DbContext.SaveChanges();

            MessageBox.Show(String.Format("Congratulations, items changed successfully!" ));

         
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Columns[e.ColumnIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0]; 
        }
    }
}
