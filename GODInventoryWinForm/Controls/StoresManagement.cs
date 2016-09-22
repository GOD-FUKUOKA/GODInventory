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
    public partial class StoresManagement : Form
    {
        private string showtype;

        public StoresManagement(List<int> itemlist, string type)
        {
            InitializeComponent();

            if (type == "Update")
            {
                using (var ctx = new GODDbContext())
                {

                    t_shoplist order = ctx.t_shoplist.Find(itemlist[0]);
                    storeNamTextBox.Text = order.店番.ToString();
                    storeCodeTextBox.Text = order.店名;
                    textBox12.Text = order.店名カナ;
                    orderReceivedAtTextBox.Text = order.配送担当;
                    textBox8.Text = order.郵便番号.ToString();
                    productKanjiNameTextBox.Text = order.県別.ToString();
                    productKanjiSpecificationTextBox.Text = order.県内エリア.ToString();
                    orderQuantityTextBox11.Text = order.customerId.ToString();
                    textBox1.Text = order.住所;
                    textBox2.Text = order.電話番号.ToString();

                    this.productReceivedAtTextBox3.Text = order.FAX番号.ToString();
                }
            }
            else
                this.storeNamTextBox.Enabled = true;

            showtype = type;


        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                if (showtype == "Update")
                {
                    t_shoplist order = ctx.t_shoplist.Find(Convert.ToInt32(storeNamTextBox.Text));

                    order.店番 = Convert.ToInt32(storeCodeTextBox.Text);
                    order.店名 = storeCodeTextBox.Text;
                    order.店名カナ = textBox12.Text;
                    order.配送担当 = orderReceivedAtTextBox.Text;
                    order.郵便番号 = textBox8.Text;
                    order.県別 = productKanjiNameTextBox.Text;
                    order.県内エリア = productKanjiSpecificationTextBox.Text;
                    order.customerId = Convert.ToInt32(orderQuantityTextBox11.Text);
                    order.住所 = textBox1.Text;
                    order.電話番号 = textBox2.Text;
                    order.FAX番号 = this.productReceivedAtTextBox3.Text;
                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("Congratulations, You have item  update successfully!"));
                }
                else if (showtype == "Add")
                {

                    t_shoplist order = new t_shoplist();
                    order.店番 = Convert.ToInt32(storeNamTextBox.Text);

                    order.店名 = storeCodeTextBox.Text;

                    order.店名カナ = textBox12.Text;

                    order.配送担当 = orderReceivedAtTextBox.Text;

                    order.郵便番号 = textBox8.Text;

                    order.県別 = productKanjiSpecificationTextBox.Text;

                    order.県内エリア = productReceivedAtTextBox3.Text;
                    if (orderQuantityTextBox11.Text != "")
                        order.customerId = Convert.ToInt32(orderQuantityTextBox11.Text);
                    order.住所 = textBox1.Text;

                    order.電話番号 = textBox2.Text;

                    order.FAX番号 = this.productReceivedAtTextBox3.Text;

                    ctx.t_shoplist.Add(order);
                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("Congratulations, You have   order added successfully!"));
                    this.Close();

                }
            }
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
