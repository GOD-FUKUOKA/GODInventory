﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;
using System.Linq;
using System.Collections;

namespace GODInventoryWinForm.Controls
{
    public partial class ProductsControl : UserControl
    {


        public ProductsControl()
        {
            InitializeComponent();

            //shopList = ctx.t_shoplist.ToList();



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.entityDataSource1.DbContext.SaveChanges();

            //using (var ctx = new GODDbContext())
            //{
            //    ctx.t_orderdata.AddRange(newOrderList);
            //    ctx.SaveChanges();
            //    MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", newOrderList.Count));
            //    orderList.Clear();
            //}


            //int i = dataGridView1.CurrentCell.OwningColumn.Index;
            //int iRow = dataGridView1.CurrentCell.OwningRow.Index;
            //var oids = GetOrderIdsBySelectedGridCell();

            //if (oids.Count() > 0)
            //{
            //    OrderSqlHelper.SendOrderToShipper(oids);
            //    //pager1.Bind();
            //}
            //else
            //{
            //    MessageBox.Show(" please select rows in the order list first.");
            //}
        }
        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as t_itemlist;
                order_ids.Add(pendingorder.自社コード);
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
    }
}
