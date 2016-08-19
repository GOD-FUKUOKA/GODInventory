using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GODInventory.MyLinq;

namespace GODInventoryWinForm
{
    public partial class testingCC : Form
    {
        //// 这里判断是否有数据被复制
        //    object clipboardData = Clipboard.GetData("userEntites");

        //    this.btnPaste.Enabled = (clipboardData != null);  
        private List<t_stockrec> t_stockrecList;
        public testingCC()
        {
            InitializeComponent();


            using (var ctx = new GODDbContext())
            {
                t_stockrecList = ctx.t_stockrec.ToList();


            }
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = t_stockrecList;
        }

        private void sendToShipperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject d = this.dataGridView1.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                       // dataGridView1.ClearSelection();
                       // dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                      //  dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }

   
    }
}
