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
        private List<t_stocklist> t_stocklistR;
        private BindingList<t_stocklist> stocklist;
    

        public InputStock()
        {
            InitializeComponent();


            using (var ctx = new GODDbContext())
            {

                //t_manufacturersR = ctx.t_s.ToList();
              
            }


            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = stocklist;
        }

        private void btadd_Click(object sender, EventArgs e)
        {
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("仓库", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt32(textBox4.Text) == 0)
                {
                    MessageBox.Show("入庫番号", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                t_stocklist order = new t_stocklist();                
                order.期日 = orderCreatedAtDateTimePicker.Value;
                order.仓库 =  textBox1.Text ;
                order.商品別 = textBox5.Text  ;
                order.工場 = textBox3.Text ;
                order.入庫番号 = textBox4.Text ;
                 order.工場のコード = textBox6.Text ;
                 order.数量 = Convert.ToInt32(this.textBox7.Text);
              

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
                        ctx.t_stocklist.AddRange(stocklist);
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
    }
}
