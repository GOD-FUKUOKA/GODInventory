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
    public partial class InputStock : Form
    {
        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private BindingList<t_stockrec> stocklist;
        private List<t_genre> t_genreR;

        public InputStock()
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

        private void btadd_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (this.storeComboBox.Text == "" || storeComboBox.Text == "")
                    {
                        MessageBox.Show("仓库", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    t_stockrec order = new t_stockrec();
                    order.日付 = orderCreatedAtDateTimePicker.Value; 
                    order.区分 = storeComboBox.Text;
                    //order.商品別 = this.comboBox1.Text;
                    //order.工場 = this.comboBox3.Text;
                    //order.入庫番号 = textBox4.Text;
                    //order.工場のコード = comboBox2.Text;
                    order.数量 = Convert.ToInt32(this.numericUpDown1.Text);
                    #region 联动
                    //foreach (t_rcvdata item in t_rcvdataR)
                    //{

                    //    if (item.商品コード == Convert.ToDouble(order.商品コード))
                    //    {
                    //        order.品名漢字 = item.品名漢字.ToString();
                    //        order.規格名漢字 = item.規格名漢字.ToString();
                    //        order.原単価_税抜_ = Convert.ToInt32(item.原単価_税抜_.ToString());
                    //        order.売単価_税抜_ = Convert.ToInt32(item.売単価_税抜_.ToString());
                    //        order.ＪＡＮコード = long.Parse(item.ＪＡＮコード.ToString());
                    //        break;

                    //    }
                    //}
                    #endregion

                    stocklist.Add(order);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex" + ex, "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    throw ex;
                }
            }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count=0;

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
    }
}
