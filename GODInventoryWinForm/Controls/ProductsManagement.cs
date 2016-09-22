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
    public partial class ProductsManagement : Form
    {
        private string showtype;

        public ProductsManagement(List<int> itemlist, string type)
        {
            InitializeComponent();
            if (type == "Update")
            {
                using (var ctx = new GODDbContext())
                {

                    t_itemlist order = ctx.t_itemlist.Find(itemlist[0]);
                    storeNamTextBox.Text = order.自社コード.ToString();
                    storeCodeTextBox.Text = order.得意先;
                    invoiceNOTextBox.Text = order.ジャンル.ToString();
                    textBox12.Text = order.商品名;
                    orderReceivedAtTextBox.Text = order.規格;
                    textBox8.Text = order.PT入数.ToString();
                    productKanjiSpecificationTextBox.Text = order.JANコード.ToString();
                    productReceivedAtTextBox3.Text = order.インストアコード.ToString();
                    unitWeightTextBox11.Text = order.単品重量.ToString();
                    textBox1.Text = order.単位;
                    textBox2.Text = order.PT単位か.ToString();

                    this.productKanjiNameTextBox.Text = order.商品コード.ToString();
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
                    t_itemlist order = ctx.t_itemlist.Find(Convert.ToInt32(storeNamTextBox.Text));
        
                    order.得意先 = storeCodeTextBox.Text;
                    order.ジャンル = Convert.ToInt16(invoiceNOTextBox.Text);
                    order.商品名 = textBox12.Text;
                    order.規格 = orderReceivedAtTextBox.Text;
                    order.PT入数 = Convert.ToInt32(textBox8.Text);
                    order.JANコード = Convert.ToInt64(productKanjiSpecificationTextBox.Text);
                    order.インストアコード = Convert.ToDouble(productReceivedAtTextBox3.Text);
                    order.単品重量 = Convert.ToDouble(unitWeightTextBox11.Text);
                    order.単位 = textBox1.Text;
                    order.PT単位か = Convert.ToSByte(textBox2.Text);
                    order.商品コード = Convert.ToInt32(this.productKanjiNameTextBox.Text);
                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("Congratulations, You have item  update successfully!"));
                }
                else if (showtype == "Add")
                {

                    t_itemlist order = new t_itemlist();
                    order.自社コード = Convert.ToInt32(storeNamTextBox.Text);

                    order.得意先 = storeCodeTextBox.Text;
                    if (invoiceNOTextBox.Text != "")
                        order.ジャンル = Convert.ToInt16(invoiceNOTextBox.Text);
                    order.商品名 = textBox12.Text;
                    order.規格 = orderReceivedAtTextBox.Text;
                    if (textBox8.Text != "")
                        order.PT入数 = Convert.ToInt32(textBox8.Text);
                    if (productKanjiSpecificationTextBox.Text != "")
                        order.JANコード = Convert.ToInt64(productKanjiSpecificationTextBox.Text);
                    if (productReceivedAtTextBox3.Text != "")
                        order.インストアコード = Convert.ToDouble(productReceivedAtTextBox3.Text);
                    if (unitWeightTextBox11.Text != "")
                        order.単品重量 = Convert.ToDouble(unitWeightTextBox11.Text);
                    order.単位 = textBox1.Text;
                    if (textBox2.Text != "")
                        order.PT単位か = Convert.ToSByte(textBox2.Text);
                    if (productKanjiNameTextBox.Text != "")
                        order.商品コード = Convert.ToInt32(this.productKanjiNameTextBox.Text);

                    ctx.t_itemlist.Add(order);
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
    }
}
