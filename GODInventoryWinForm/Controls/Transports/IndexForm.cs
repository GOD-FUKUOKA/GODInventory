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

namespace GODInventoryWinForm.Controls.Transports
{
    public partial class IndexForm : Form
    {
        private List<t_transports> transportList;

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

                this.transportList = ctx.t_transports.ToList();

                this.bindingSource1.DataSource = this.transportList;
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
            var selected = row.DataBoundItem as t_transports;
            var form = new EditForm();
            form.transport = selected;
            form.transportList = this.transportList;
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
            form.transportList = this.transportList;
            form.ShowDialog();

            if (form.dialogResult == DialogResult.OK)
            {
                InitializeData();
            }
        }

    }
}
