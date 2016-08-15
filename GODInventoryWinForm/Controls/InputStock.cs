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
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class InputStock : Form
    {
        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private BindingList<t_stockrec> stocklist;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;
        private t_itemlist itemlist;
        private BindingList<t_itemlist> Titemlist;
        public InputStock()
        {
            InitializeComponent();
            List<int> newcodemanufa = new List<int>();
            stocklist = new BindingList<t_stockrec>();
            Titemlist = new BindingList<t_itemlist>();

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
            //foreach (t_shippers item in t_shippersR)
            {
                OrderSqlHelper item12 = new OrderSqlHelper();

                string[] ll = item12.StrockReback();
                for (int j = 0; j < ll.Length; j++)
                {
                    // this.storeComboBox.Items.Add(item.ShortName);
                    this.storeComboBox.Items.Add(ll[j]);

                }
            }


            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = Titemlist;
        }

     
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (t_itemlist item in Titemlist)
                {
                    if (this.storeComboBox.Text == "" || storeComboBox.Text == "")
                    {
                        MessageBox.Show("仓库", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    order.日付 = orderCreatedAtDateTimePicker.Value;
                    order.先 = storeComboBox.Text;

                    order.元 = this.comboBox3.Text;
                    order.納品書番号 = textBox4.Text;

                    order.数量 = Convert.ToInt32(this.numericUpDown1.Text);
                    order.区分 = "入庫";
                    //order.出庫事由 = comboBox2.Text;
                    //order.仓库 = storeComboBox.Text;
                    order.自社コード = Convert.ToInt32(item.自社コード);
                    order.状態 = "確定";

                    stocklist.Add(order);
                    if (stocklist.Count > 0)
                    {
                        using (var ctx = new GODDbContext())
                        {
                            ctx.t_stockrec.AddRange(stocklist);
                            ctx.SaveChanges();
                            MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stocklist.Count));
                            stocklist.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return;

                throw;
            }
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btbringupcompanycode_Click(object sender, EventArgs e)
        {

            int id = 0;

            foreach (t_genre item in t_genreR)
            {
                if (item.ジャンル名 == comboBox1.Text)
                    id = item.idジャンル;

            }
            if (Strock_CompanyCode == null)
            {
                Strock_CompanyCode = new Strock_CompanyCode(id);
                Strock_CompanyCode.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (Strock_CompanyCode == null)
            {
                Strock_CompanyCode = new Strock_CompanyCode(id);
            }
            Strock_CompanyCode.ShowDialog();
            Titemlist.Add(itemlist);



        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            order = new t_stockrec();

            if (sender is Strock_CompanyCode)
            {
                order.自社コード = Strock_CompanyCode.STATUS;
                //int lll = Strock_CompanyCode.STATUS;
                itemlist = new t_itemlist();
                itemlist = Strock_CompanyCode.item;
                Strock_CompanyCode = null;


            }
        }
    }
}
