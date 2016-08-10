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

namespace GODInventoryWinForm.Controls
{
    public partial class Strock_CompanyCode : Form
    {

        int RowRemark = 0;
        int cloumn = 0;
        private BindingList<t_itemlist> t_itemlistR;
        private List<t_itemlist> itemlist;
        public int STATUS;


        public Strock_CompanyCode(int text)
        {
            InitializeComponent();
            t_itemlistR = new BindingList<t_itemlist>();

            using (var ctx = new GODDbContext())
            {
                itemlist = ctx.t_itemlist.ToList();

            }
            var locations = this.itemlist.Where(l => l.ジャンル == text).ToList();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = locations;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            STATUS = Convert.ToInt32(dataGridView1.Rows[RowRemark].Cells[1].EditedFormattedValue.ToString());
            this.Close();

        }
    }
}
