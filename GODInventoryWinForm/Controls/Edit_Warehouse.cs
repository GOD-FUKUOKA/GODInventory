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
    public partial class Edit_Warehouse : Form
    {
        public int wid;
        public t_warehouses warehouses { get; set; }

        public Edit_Warehouse()
        {
            InitializeComponent();        }

        public void InitializeOrder()
        {
            warehouses = new t_warehouses();
            var ctx = entityDataSource1.DbContext as GODDbContext;
            warehouses = ctx.t_warehouses.Find(wid);

            //using (var ctx = new GODDbContext())
            {
                var List = (from t_warehouses o in ctx.t_warehouses
                            where wid == o.Id
                            select o).ToList();
                if (List.Count > 0)
                {
                    this.fullNameTextBox12.Text = List[0].FullName;
                    this.shortNameTextBox12.Text = List[0].ShortName;
               //   

                }

            }
        }
        private void submitFormButton_Click(object sender, EventArgs e)
        {

          

            warehouses.FullName = this.fullNameTextBox12.Text.Trim();
            warehouses.ShortName = this.shortNameTextBox12.Text.Trim();
            warehouses.ShipperName = this.fullNameTextBox12.Text.Trim();

            this.entityDataSource1.SaveChanges();
        
            this.Close();


        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }
    }
}
