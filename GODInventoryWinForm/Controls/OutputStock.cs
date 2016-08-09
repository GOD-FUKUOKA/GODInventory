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
    public partial class OutputStock : Form
    {
        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private BindingList<t_stockrec> stocklist;
        private List<t_genre> t_genreR;

        public OutputStock()
        {
            InitializeComponent();

            List<int> newcodemanufa = new List<int>();
            stocklist = new BindingList<t_stockrec>();

            using (var ctx = new GODDbContext())
            {
                t_manufacturersR = ctx.t_manufacturers.ToList();
                t_shippersR = ctx.t_shippers.ToList();
                t_genreR = ctx.t_genre.ToList();
            }
            foreach (t_manufacturers item in t_manufacturersR)
            {
                this.comboBox2.Items.Add(item.Id);
                this.comboBox3.Items.Add(item.FullName);

            }
            foreach (t_genre item in t_genreR)
            {
                this.comboBox1.Items.Add(item.ジャンル名);
            }
            foreach (t_shippers item in t_shippersR)
            {
                this.storeComboBox.Items.Add(item.ShortName);
            }
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = stocklist;


        }

        private void submitButton_Click(object sender, EventArgs e)
        {

        }

        private void btadd_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;

            using (var ctx = new GODDbContext())
            {
                var results = from s in ctx.t_stockrec
                              where s.日付 == DateTime.Now
                              select s;

                count = results.Count();
            }
            var shops = this.t_genreR.Where(s => s.ジャンル名.ToString().StartsWith(comboBox1.Text.ToString())).ToList();

            this.textBox4.Text = this.storeComboBox.Text + "-" + DateTime.Now.ToString("yyyymmdd") + "-" + shops.First().idジャンル.ToString() + "-" + count + 1;
        }
    }
}
