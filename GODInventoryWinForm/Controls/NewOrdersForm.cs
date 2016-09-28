﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class NewOrdersForm : Form
    {
        //SELECT o2.* FROM t_orderdata o1 inner join t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
        //where o1.`Status`=0 OR o2.`Status`=1 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品日`>NOW())
        //order by o2.店舗コード, o2.自社コード , o2.createdAt desc
        
        //o1.`id受注データ`!= o2.`id受注データ`


        private Hashtable datagrid_changes = null;
        List<v_duplicatedorder> duplicatedOrderList;
        SortableBindingList<v_duplicatedorder> duplicatedBindingList;
        public NewOrdersForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.AutoGenerateColumns = false;

            this.datagrid_changes = new Hashtable();
            this.InitializeOrderData();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            if (duplicatedBindingList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        for (int i = 0; i < duplicatedBindingList.Count; i++)
                        {
                            //  if ((int) != 0)
                            {
                                var duplicated_order = duplicatedBindingList[i];
                                t_orderdata order = ctx.t_orderdata.Find(duplicated_order.id受注データ);

                                if (duplicated_order.キャンセル == "yes")
                                {
                                    order.キャンセル = "yes";
                                    order.キャンセル時刻 = DateTime.Now;
                                    order.Status = OrderStatus.Cancelled;
                                    order.備考 = "キャンセル";
                                }
                                else if (duplicated_order.ダブリ == "no")
                                {
                                    if (order.Status == OrderStatus.Duplicated) {
                                        order.実際出荷数量 = duplicated_order.実際出荷数量;
                                        order.納品口数 = duplicated_order.納品口数;
                                        order.ダブリ = "no";
                                        order.Status = OrderStatus.Pending;
                                    }
                                }

                            }
                        }
                        ctx.SaveChanges();
                    }
                    var originalSortOrder = this.dataGridView1.SortOrder;
                    var originalSortedColumn = this.dataGridView1.SortedColumn;
                    InitializeOrderData();
                    
                    var direction = ListSortDirection.Ascending;
                    if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    if (originalSortedColumn != null)
                    {
                        this.dataGridView1.Sort(originalSortedColumn, direction);
                    }
                }
                else
                {
                    MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    RowRemark = e.RowIndex;
        //    cloumn = e.ColumnIndex;
        //}





        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        public int InitializeOrderData()
        {
            this.datagrid_changes.Clear();

            string sql = @"SELECT o1.id受注データ as duplicatedId, o2.id受注データ, o2.`出荷日`,o2.`納品日`,o2.`受注日`,o2.`店舗コード`, o2.`店舗名漢字`,
          o2.`伝票番号`,o2.`納品口数`,o2.`ジャンル`,o2.`品名漢字`,o2.`規格名漢字`, 
          o2.`実際出荷数量`,o2.`実際配送担当`,o2.`県別`, 
          o2.`発注形態名称漢字`,o2.`キャンセル`,o2.`ダブリ`, o2.Status
            FROM t_orderdata o1 inner join t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
    where o1.`Status`=22 AND (o1.id受注データ = o2.id受注データ or  o2.`Status`=0 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品予定日`>NOW()) )
    order by o2.店舗コード, o2.自社コード , o2.受注日, o1.id受注データ";

            using (var ctx = new GODDbContext())
            {

                duplicatedOrderList = ctx.Database.SqlQuery<v_duplicatedorder>(sql).ToList();
            }


            duplicatedBindingList = new SortableBindingList<v_duplicatedorder>(duplicatedOrderList);
            dataGridView1.DataSource = duplicatedBindingList;

            return 0;
        }

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int i = e.RowIndex;
            var order = duplicatedBindingList[i];
            if (order.キャンセル == "yes")
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                //this.dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Gray;

            }
            else if (order.ダブリ == "yes")
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //this.dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
            }
            else
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            }
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = キャンセルColumn.Index;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) 
            {
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedBindingList[rowIndex];
                var originalValue = order.キャンセル;
                order.キャンセル = "yes";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.キャンセル);
            }

            this.dataGridView1.Refresh();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = ダブリColumn.Index;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {               
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedBindingList[rowIndex];
                var originalValue = order.ダブリ;
                order.ダブリ = "yes";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.ダブリ);
            }
            this.dataGridView1.Refresh();
        }

        private void uncancleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = キャンセルColumn.Index;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedBindingList[rowIndex];
                var originalValue = order.キャンセル;
                order.キャンセル = "no";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.キャンセル);

            }
            this.dataGridView1.Refresh();
        }

        private void unduplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = ダブリColumn.Index;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedBindingList[rowIndex];
                var originalValue = order.ダブリ;
                order.ダブリ = "no";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.ダブリ);

            }
            //dataGridView1.ClearSelection(); 
            this.dataGridView1.Refresh();
        }

        //private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            dataGridView1.ClearSelection();
        //            dataGridView1.Rows[e.RowIndex].Selected = true;
        //            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        //        }
        //    } 
        //}


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = row.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var col = dataGridView1.Columns[e.ColumnIndex];
            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);
            string cellKeyForChanged = GetCellKey(e.RowIndex, e.ColumnIndex, true);

            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = datagrid_changes[cellKey];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                datagrid_changes.Remove(cellKeyForChanged);
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                datagrid_changes[cellKeyForChanged] = new_cell_value;
            }
            else
            {
                datagrid_changes.Remove(cellKeyForChanged);
            }

            if (col == this.実際出荷数量Column) 
            { 
            
            }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string cellKey = GetCellKey( e.RowIndex, e.ColumnIndex, true);

            if (datagrid_changes.ContainsKey(cellKey))
            {
                e.CellStyle.BackColor = Color.DarkRed;
                //e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private string GetCellKey(int rowIndex, int columnIndex, bool forChanged)
        { 
        
          return  GetCellKey( rowIndex,  columnIndex) + "_changed";
        }

        private string GetCellKey(int rowIndex, int columnIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            var model = row.DataBoundItem as v_duplicatedorder;

            return string.Format( "{0}_{1}", model.id受注データ, columnIndex.ToString() );
        }

        private bool UpdateChangesManually(int rowIndex, int columnIndex, string originalValue, string newValue) 
        {
            string cellKey = GetCellKey(rowIndex, columnIndex);
            string cellKeyForChanged = GetCellKey(rowIndex, columnIndex, true);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = originalValue;
            }

            if( datagrid_changes[cellKey].ToString() != newValue )
            {
                datagrid_changes[cellKeyForChanged] = newValue;
            }
            else
            {
                datagrid_changes.Remove(cellKeyForChanged);
            }
            return true;
        }

        private IEnumerable<int> GetChangedRowIndexes()
        {

            List<int> rows = new List<int>();
            foreach (DictionaryEntry entry in datagrid_changes)
            {
                var key = entry.Key as string;
                if (key.EndsWith("_changed"))
                {
                    int row = Int32.Parse(key.Split('_')[0]);
                    rows.Add(row);
                }
                //                    Console.WriteLine("Key -- {0}; Value --{1}.", entry.Key, entry.Value);
            }
            return rows.Distinct();
        }

    }
}
