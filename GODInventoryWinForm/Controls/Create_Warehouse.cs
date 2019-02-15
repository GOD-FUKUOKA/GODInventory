using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    public partial class Create_Warehouse : Form
    {

        public Create_Warehouse()
        {
            InitializeComponent();

        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                if (fullNameTextBox12.Text.Length > 0)
                {

                    var List = (from t_warehouses o in ctx.t_warehouses
                                where fullNameTextBox12.Text == o.FullName
                                select o).ToList();
                    if (List.Count == 0)
                    {
                        t_warehouses item = new t_warehouses();
                        item.FullName = this.fullNameTextBox12.Text.Trim();
                        item.ShortName = this.shortNameTextBox12.Text.Trim();
                        item.ShipperName = this.fullNameTextBox12.Text.Trim();

                        ctx.t_warehouses.Add(item);
                        ctx.SaveChanges();

                        MessageBox.Show(String.Format("登録完了!"));
                    }
                    else
                    {
                        MessageBox.Show(String.Format("无法添加，已存在!"));

                    }
                }
            }
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }
    }
}
