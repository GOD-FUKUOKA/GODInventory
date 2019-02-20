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
    public partial class Bind__Transports : Form
    {
        public int tid;
        public t_transports transports { get; set; }
        public int wid;
        public t_warehouses warehouses { get; set; }
        private List<t_transports> transportList;
        public Bind__Transports()
        {
            InitializeComponent();
        }

        public void InitializeOrder()
        {
            transports = new t_transports();
            var ctx = entityDataSource1.DbContext as GODDbContext;

            transportList = ctx.t_transports.ToList();

            
            this.tidComboBox3.DisplayMember = "fullname";
            this.tidComboBox3.ValueMember = "Id";
            this.tidComboBox3.DataSource = transportList;

        }
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            var ctx = entityDataSource1.DbContext as GODDbContext;


            t_warehouses_transports item = new t_warehouses_transports();
            item.wid = wid;
            item.tid = tid;

            ctx.t_warehouses_transports.Add(item);
            ctx.SaveChanges();

            this.Close();

        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }

        private void tidComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tidComboBox3.SelectedValue) > 0)
            {
                this.fullNameTextBox12.Text = this.tidComboBox3.Text.ToString();
            }



        }

        private void fullNameTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (fullNameTextBox12.Text.Trim().Length > 0)
            {
                //   int storeId = Convert.ToInt32(fullNameTextBox12.Text);
                int storeId = 0;
                if (fullNameTextBox12.Text.Length > 0)
                {
                    var shops = this.transportList.Where(s => s.fullname == fullNameTextBox12.Text).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();

                        this.tidComboBox3.SelectedValue = store.id;
                        this.shortNameTextBox12.Text = store.shortname;
                        tid = store.id;

                        errorProvider1.SetError(tidComboBox3, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(tidComboBox3, String.Format("仓库されていません", storeId));
                    }

                }
                else
                {
                    errorProvider1.SetError(tidComboBox3, String.Format("运输公司登録されていません", fullNameTextBox12.Text));
                }
            }
        }
    }
}
