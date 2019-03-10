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

namespace GODInventoryWinForm.Controls.Warehouse
{
    public partial class IndexForm : Form
    {
        private List<t_warehouses> warehousesList;

        public IndexForm()
        {
            InitializeComponent();
        }

        private void IndexForm_Shown(object sender, EventArgs e)
        {
            Console.WriteLine("IndexForm_Shown {0}", DateTime.Now.ToString());
            this.InitializeData();
        }
        private void InitializeData()
        {
            using (var ctx = new GODDbContext())
            {

                this.warehousesList = ctx.t_warehouses.ToList();

                this.bindingSource1.DataSource = this.warehousesList;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showEditForm();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showEditForm();
        }

        private void showEditForm() {
            var row = this.dataGridView1.CurrentRow;
            var selected = row.DataBoundItem as t_warehouses;
            var form = new EditForm();
            form.warehouses = selected;
            form.warehousesList = this.warehousesList;
            form.ShowDialog();
            if ( form.dialogResult == DialogResult.OK)
            {
                InitializeData();
            }
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            var form = new NewForm();
            // 检查是否和现有的名称有冲突
            form.warehousesList = this.warehousesList;
            form.ShowDialog();

            if (form.dialogResult == DialogResult.OK)
            {
                InitializeData();
            }
        }

    }
}
