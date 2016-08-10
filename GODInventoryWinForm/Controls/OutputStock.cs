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
    public partial class OutputStock : Form
    {
        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private BindingList<t_stockrec> stocklist;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;

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

                this.comboBox3.Items.Add(item.FullName);

            }
            foreach (t_genre item in t_genreR)
            {
                this.comboBox1.Items.Add(item.ジャンル名);
            }
            //foreach (t_shippers item in t_shippersR)
            {
                //this.storeComboBox.Items.Add(item.ShortName);
                OrderSqlHelper item12 = new OrderSqlHelper();

                string[] ll = item12.StrockReback();
                for (int j = 0; j < ll.Length; j++)
                {
                    // this.storeComboBox.Items.Add(item.ShortName);
                    this.storeComboBox.Items.Add(ll[j]);

                }
                string[] tt = item12.Strock_out();
                for (int j = 0; j < tt.Length; j++)
                {
                    // this.storeComboBox.Items.Add(item.ShortName);
                    this.comboBox2.Items.Add(tt[j]);
                }
            }



            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = stocklist;


        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return;

                throw;
            }
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

        private void btadd_Click_1(object sender, EventArgs e)
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
        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            order = new t_stockrec();

            if (sender is Strock_CompanyCode)
            {
                order.自社コード = Strock_CompanyCode.STATUS;

                Strock_CompanyCode = null;


            }
        }
        private void brbringStockCN_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (this.storeComboBox.Text == "" || storeComboBox.Text == "")
                    {
                        MessageBox.Show("仓库", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    order.日付 = orderCreatedAtDateTimePicker.Value;
                    order.先 = storeComboBox.Text;
                    order.元 = this.comboBox2.Text;
                    order.納品書番号 = textBox4.Text;
                    //
                    //order.出庫事由 = comboBox2.Text;
                    //order.仓库 = storeComboBox.Text;

                    order.区分 = "出庫";

                    stocklist.Add(order);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex" + ex
                        + "商品リストにつけ込み 選択", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    throw ex;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

    }
}
