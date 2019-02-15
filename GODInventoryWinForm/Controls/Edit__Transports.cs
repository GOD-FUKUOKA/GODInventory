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
    public partial class Edit__Transports : Form
    {
        public int tid;
        public t_transports transports { get; set; }

        public Edit__Transports()
        {
            InitializeComponent();
        }

        public void InitializeOrder()
        {
            transports = new t_transports();
            var ctx = entityDataSource1.DbContext as GODDbContext;
            transports = ctx.t_transports.Find(tid);

            //using (var ctx = new GODDbContext())
            {


                if (transports != null)
                {
                    this.fullNameTextBox12.Text = transports.fullname;
                    this.shortNameTextBox12.Text = transports.shortname;


                }

            }
        }
        private void submitFormButton_Click(object sender, EventArgs e)
        {

            transports.fullname = this.fullNameTextBox12.Text.Trim();
            transports.shortname = this.shortNameTextBox12.Text.Trim();

            this.entityDataSource1.SaveChanges();

            this.Close();


        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }
    }
}
