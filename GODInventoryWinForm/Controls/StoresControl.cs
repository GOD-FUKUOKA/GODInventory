using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;

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
            //this.entityDataSource1.DbContext.SaveChanges();

            //MessageBox.Show(String.Format("Congratulations, items changed successfully!" ));

            int i = dataGridView1.CurrentCell.OwningColumn.Index;
            int iRow = dataGridView1.CurrentCell.OwningRow.Index;
            var oids = GetOrderIdsBySelectedGridCell();

            if (oids.Count() > 0)
            {
                var form = new StoresManagement(oids, "Update");

                if (form.ShowDialog() == DialogResult.OK)
                {

                    this.entityDataSource1.Refresh();

                }
                
            }
            else
            {
                MessageBox.Show("Please select a store first.");
            }
         
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        dataGridView1.ClearSelection();
            //        dataGridView1.Columns[e.ColumnIndex].Selected = true;
            //        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            //    }
            //}
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new StoresManagement(null, "Add");

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.entityDataSource1.Refresh();

            }
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0]; 
        }

        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as t_shoplist;
                order_ids.Add(pendingorder.店番);
            }

            return order_ids;
        }
        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            var form = new StoresManagement(null, "Add");

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.entityDataSource1.Refresh();

            }
        }


    }
}
