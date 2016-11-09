﻿using GODInventory.MyLinq;
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
        private List<t_itemlist> itemList = null;

        public ShipOrderListForm()
        {
            InitializeComponent();
            this.訂正理由区分Column.ValueMember = "ID";
            this.訂正理由区分Column.DisplayMember = "FullName";
            this.訂正理由区分Column.DataSource = OrderQuantityChangeReasonRespository.ToList();

            // 记录DataGridView改变数据
            this.dataGridChanges = new Hashtable();
            itemList = (from t_itemlist i in entityDataSource1.EntitySets["t_itemlist"]
                            select i).ToList();
        }


        public void InitializeDataSource( string shipNO) {
            dataGridChanges.Clear();
            this.bindingSource1.DataSource = null;
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
            if (e.RowIndex < dataGridView1.Rows.Count )
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
            string cell_key = GetCellKey(e.RowIndex, e.ColumnIndex);

            if (!dataGridChanges.ContainsKey(cell_key))
            {
                dataGridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cell_key = GetCellKey(e.RowIndex, e.ColumnIndex);
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            var new_cell_value = cell.Value;
            var original_cell_value = dataGridChanges[cell_key];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                dataGridChanges.Remove(cellChangedKey);
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                dataGridChanges[cellChangedKey] = new_cell_value;
            }
            else
            {
                dataGridChanges.Remove(cellChangedKey);
            }

            var order = row.DataBoundItem as t_orderdata;
            var item = itemList.Find(i => i.自社コード == order.自社コード);

            if (cell.OwningColumn == this.実際出荷数量Column1)
            {
                order.納品口数 = Convert.ToInt32(new_cell_value) / order.最小発注単位数量;
                order.重量 = (int) ( item.単品重量 * order.実際出荷数量 );
            }
            else
                if (cell.OwningColumn == this.納品口数Column1)
                {
                    order.実際出荷数量 = Convert.ToInt32(new_cell_value) * order.最小発注単位数量;
                    order.重量 = (int)(item.単品重量 * order.実際出荷数量);

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
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);

            if (dataGridChanges.ContainsKey(cellChangedKey))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // 可能有订单被退回了。status = WaitToShip
            entityDataSource1.SaveChanges();
            if (dataGridChanges.Count > 0)
            {
                dataGridChanges.Clear();
            }
            
            InitializeDataSource(ShipNO);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var ctx = entityDataSource1.DbContext as GODDbContext;

            // http://www.tuicool.com/articles/63uaaq7
            // remove change cache in dbcontext
            foreach(var  entry in ctx.ChangeTracker.Entries())
            {
                entry.State = System.Data.Entity.EntityState.Unchanged;
            }
            InitializeDataSource(ShipNO);
            // 手动更新一下， this.dataGridView1， 没有刷新。


        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            for (int i = 0; i < count; i++)
            {
                var order = dataGridView1.SelectedRows[i].DataBoundItem as t_orderdata;
                order.ShipNO = null;
                order.納品日 = null;
                order.出荷日 = null;
                order.Status = OrderStatus.WaitToShip;         
            }
           
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (this.dataGridChanges.Count > 0) 
            {
                
            }
        }

        #region 修改键生成
        private string GetCellKey(int rowIndex, int columnIndex, bool forChanged)
        {
            return GetCellKey(rowIndex, columnIndex) + "_changed";
        }

        private string GetCellKey(int rowIndex, int columnIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            var model = row.DataBoundItem as t_orderdata;

            return string.Format("{0}_{1}", model.id受注データ, columnIndex.ToString());
        }
        #endregion
    }
}
