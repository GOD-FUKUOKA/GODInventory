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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext()) { 
               //var product = new t_itemlist();
               //ctx.t_itemlist.Add( product );
               // ctx.SaveChanges();
            }

            MessageBox.Show("Add successfully");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
