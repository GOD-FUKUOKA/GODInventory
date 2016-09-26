using GODInventory.MyLinq;
using System;
using System.Collections;
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
    public partial class ShipOrderListForm : Form
    {
        public string ShipNO { get; set; }

        //  [c1_r1_changed=> new_value,c1_r1=> original_value] ]
        private Hashtable dataGridChanges = null;

        private IBindingList orderList;
        public ShipOrderListForm()
        {
            InitializeComponent();
            // 记录DataGridView改变数据
            this.dataGridChanges = new Hashtable();
        }


        public void InitializeDataSource( string shipNO) {
            ShipNO = shipNO;
            if (ShipNO != null) {
                this.shipNOLabel.Text = ShipNO;
                var q = (from t_orderdata o in entityDataSource1.EntitySets["t_orderdata"]
                         where o.ShipNO == this.ShipNO
                         select o);
                
                this.orderList = entityDataSource1.CreateView( q );
                this.bindingSource1.DataSource = this.orderList;
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = this.bindingSource1;
            
            }
        
        
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
                try
                {
                    var order = orderList[e.RowIndex] as t_orderdata;

                    if (order.Status == OrderStatus.WaitToShip)//if (dgrSingle.Cells["列名"].Value.ToString().Contains("比较值"))
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Gray;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //保存原始值
            DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!dataGridChanges.ContainsKey(cell_key))
            {
                dataGridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            var new_cell_value = cell.Value;
            var original_cell_value = dataGridChanges[cell_key];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                dataGridChanges[cell_key + "_changed"] = new_cell_value;
            }
            else
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }

            var order = row.DataBoundItem as t_orderdata;
            if (cell.OwningColumn == this.発注数量Column1)
            {
                order.納品口数 = Convert.ToInt32(new_cell_value) / order.口数;
            }
            else
                if (cell.OwningColumn == this.口数Column1)
                {
                    order.発注数量 = Convert.ToInt32(new_cell_value) * order.口数;
                }

        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //出荷日,納品日,受注日,店舗コード,店名,伝票番号,口数,品名漢字,規格名漢字,発注数量,実際配送担当,県別,キャンセル,ダブリ,一旦保留
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString() + "_changed";

            if (dataGridChanges.ContainsKey(cell_key))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (dataGridChanges.Count > 0)
            {
                entityDataSource1.SaveChanges();
            }
            dataGridChanges.Clear();
            InitializeDataSource(ShipNO);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (dataGridChanges.Count > 0)
            {
                entityDataSource1.CancelChanges();
            }
            dataGridChanges.Clear();
            dataGridView1.Refresh();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.CurrentRow.Index;
            if ( idx >= 0) { 
            
                var order  = orderList[idx] as t_orderdata;
                order.ShipNO = null;
                order.Status = OrderStatus.WaitToShip;            
            }
        }

    }
}
