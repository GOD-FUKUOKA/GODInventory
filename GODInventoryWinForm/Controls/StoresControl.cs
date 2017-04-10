using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{

    public partial class StoresControl : UserControl
    {
        List<t_customers> customerList = new List<t_customers>();
        public StoresControl()
        {
            InitializeComponent();
            using (var ctx = new GODDbContext()) {
                customerList = ctx.t_customers.ToList();
            }
            this.CustomerColumn1.ValueMember = "Id";
            this.CustomerColumn1.DisplayMember = "FullName";
            this.CustomerColumn1.DataSource = customerList;
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            //this.entityDataSource1.DbContext.SaveChanges();

            //MessageBox.Show(String.Format("Congratulations, items changed successfully!" ));

            t_shoplist store = storesDataGridView.CurrentRow.DataBoundItem as t_shoplist;

            if (store != null)
            {
                var form = new StoresManagement(store.店番, "Update");

                if (form.ShowDialog() == DialogResult.OK)
                {

                    this.entityDataSource1.Refresh();

                }
                
            }
            else
            {

                MessageBox.Show(" まず伝票を選択してください.");
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
            var form = new StoresManagement(0, "Add");

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.entityDataSource1.Refresh();

            }
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0]; 
        }

        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(storesDataGridView);
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
            var form = new StoresManagement(0, "Add");

            if (form.ShowDialog() == DialogResult.OK)
            {

                this.entityDataSource1.Refresh();

            }
        }

        private void InitializePriceListDatagridView(int storeId)
        {
           
                var query = from t_pricelist p in this.entityDataSource1.EntitySets["t_pricelist"]
                            join t_itemlist i in entityDataSource1.EntitySets["t_itemlist"] on p.自社コード equals i.自社コード
                            where p.店番 == storeId
                            select new v_itemprice
                            {
                                Id = p.Id,
                                自社コード = i.自社コード,
                                商品名 = i.商品名,
                                規格 = i.規格,
                                店番 = p.店番,
                                店名 = p.店名,
                                県別 = p.県別,
                                売単価 = p.売単価,
                                原単価 = p.通常原単価,
                                広告原単価 = p.広告原単価,
                                特売原単価 = p.特売原単価,
                                仕入原価 = p.仕入原価

                            };

                this.pricesBindingSource.DataSource = this.entityDataSource1.CreateView(query);
 
           

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    
                    break;

            }

        }



        private void storesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int storeId = (int)this.storesComboBox.SelectedValue;
            //InitializePriceListDatagridView(storeId);

        }


    }
}
