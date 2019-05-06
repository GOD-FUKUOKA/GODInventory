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
using GODInventory.NAFCO.EDI;

namespace GODInventoryWinForm.Controls
{
    public partial class ProductsManagement : Form
    {
        private string showtype;
        private List<t_genre> genreList;
        private List<t_customers> customerList;
        public ProductsManagement(List<int> itemlist, string type)
        {
            InitializeComponent();
            using (var ctx = new GODDbContext())
            {
                customerList = ctx.t_customers.ToList();
                genreList = ctx.t_genre.OrderBy(o => o.Position).ToList();

                this.genreComboBox.DisplayMember = "ジャンル名";
                this.genreComboBox.ValueMember = "idジャンル";
                this.genreComboBox.DataSource = genreList;

                this.customerComboBox.DisplayMember = "FullName";
                this.customerComboBox.ValueMember = "FullName";
                this.customerComboBox.DataSource = customerList;

                if (type == "Update")
                {
                    t_itemlist order = ctx.t_itemlist.Find(itemlist[0]);

                    this.innerCodeTextBox.Text = order.自社コード.ToString();

                    //this.genreComboBox.SelectedValue = order.ジャンル;
                    this.genreComboBox.SelectedItem = genreList.Find(o => o.idジャンル == order.ジャンル);

                    if (order.得意先 != null)
                    {
                        customerComboBox.Text = order.得意先;
                    }

                    if (order.商品名 != null)
                    productNameTextBox12.Text = order.商品名;
                    if (order.規格 != null)
                    specTextBox.Text = order.規格;

                    if (order.インストアコード != null)
                    {
                        instoreCodeTextBox3.Text = order.インストアコード.ToString();
                    }

                    if (order.単位 != null)
                    {
                        unitTextBox1.Text = order.単位;
                    }

                    if (order.PT単位か != null)
                    {
                        textBox2.Text = order.PT単位か.ToString();
                    }

                    if (order.商品コード != null)
                    {
                        this.productCodeTextBox.Text = order.商品コード.ToString();
                    }

                    this.janCodeTextBox.Text = order.JANコード.ToString();

                    this.unitWeightTextBox11.Text = order.単品重量.ToString();

                    this.moqTextBox8.Text = order.PT入数.ToString();

                    this.costTextBox.Text = order.仕入原価.ToString();
                    this.priceTextBox.Text = order.通常原単価.ToString();
                    this.salePriceTextBox.Text = order.売単価.ToString();

                }
                else
                {
                    this.innerCodeTextBox.Enabled = true;
                }
            }
            showtype = type;
 
            
        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                if (showtype == "Update")
                {
                    t_itemlist product = ctx.t_itemlist.Find(Convert.ToInt32(innerCodeTextBox.Text));

                    product.得意先 = customerComboBox.Text;
                    product.ジャンル = Convert.ToInt16(genreComboBox.SelectedValue);
                    product.商品名 = productNameTextBox12.Text;
                    product.規格 = specTextBox.Text;
                    product.PT入数 = Convert.ToInt32(moqTextBox8.Text);
                    product.JANコード = Convert.ToInt64(janCodeTextBox.Text);
                    if (instoreCodeTextBox3.Text != "")
                    {
                        product.インストアコード = Convert.ToInt64(instoreCodeTextBox3.Text);
                    }
                    else {
                        product.インストアコード = null;
                    }
                    product.単品重量 = Convert.ToDouble(unitWeightTextBox11.Text);
                    product.単位 = unitTextBox1.Text;

                    if (textBox2.Text != "")
                    {
                        product.PT単位か = Convert.ToSByte(textBox2.Text);
                    }
                    else {
                        product.PT単位か = null;
                    }
                    if (this.productCodeTextBox.Text.Length > 0)
                    {
                        product.商品コード = Convert.ToInt32(this.productCodeTextBox.Text);
                    }
                    if (costTextBox.Text.Length > 0)
                    {
                        product.仕入原価 = Convert.ToDecimal(this.costTextBox.Text);
                    }
                    if (priceTextBox.Text.Length > 0)
                    {
                        product.通常原単価 = Convert.ToDecimal(this.priceTextBox.Text);
                    }
                    if (salePriceTextBox.Text.Length > 0)
                    {
                        product.売単価 = Convert.ToDecimal(this.salePriceTextBox.Text);
                    }


                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("商品情報更新完了!"));
                }
                else if (showtype == "Add")
                {

                    t_itemlist product = new t_itemlist();
                    product.順番 = 0;//不能为空
                    product.自社コード = Convert.ToInt32(innerCodeTextBox.Text);

                    product.得意先 = customerComboBox.Text;
                    
                    product.ジャンル = Convert.ToInt16(genreComboBox.SelectedValue);
                    product.商品名 = productNameTextBox12.Text;
                    product.規格 = specTextBox.Text;
                    if (moqTextBox8.Text != "")
                    {
                        product.PT入数 = Convert.ToInt32(moqTextBox8.Text);
                    }
                    if (janCodeTextBox.Text != "")
                    {
                        product.JANコード = Convert.ToInt64(janCodeTextBox.Text);
                    }
                    if (instoreCodeTextBox3.Text != "")
                    {
                        product.インストアコード = Convert.ToInt64(instoreCodeTextBox3.Text);
                    }
                    if (unitWeightTextBox11.Text != "")
                    {
                        product.単品重量 = Convert.ToDouble(unitWeightTextBox11.Text);
                    }
                    product.単位 = unitTextBox1.Text;
                    if (textBox2.Text != "")
                    {
                        product.PT単位か = Convert.ToSByte(textBox2.Text);
                    }
                    if (productCodeTextBox.Text != "")
                    {
                        product.商品コード = Convert.ToInt32(this.productCodeTextBox.Text);
                    }

                    if (costTextBox.Text.Length>0)
                    {
                        product.仕入原価 = Convert.ToDecimal(this.costTextBox.Text);
                    }
                    if (priceTextBox.Text.Length > 0)
                    {
                        product.通常原単価 = Convert.ToDecimal(this.priceTextBox.Text);
                    }
                    if (salePriceTextBox.Text.Length > 0)
                    {
                        product.売単価 = Convert.ToDecimal(this.salePriceTextBox.Text);
                    }                    
                    ctx.t_itemlist.Add(product);
                    ctx.SaveChanges();

                    ModelCallback.AfterProductCreated(product);
                    MessageBox.Show(String.Format("商品登録完了!"));

                }                                    
            }
            this.Close();
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void storeNamTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (innerCodeTextBox.Text == "")
                return;

            int zisheID = Convert.ToInt32(innerCodeTextBox.Text);

            using (var ctx = new GODDbContext())
            {
                var List = (from i in ctx.t_itemlist
                            where i.自社コード == zisheID
                            select new v_itemprice { 自社コード = i.自社コード }).ToList();

                if (List.Count > 0)
                {
                    errorProvider1.SetError(innerCodeTextBox, String.Format("自社コードがすでに存在しています"));
                    return;
                }
            }

        }

        private void productNameTextBox12_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            string name = textBox.Text;

            if ( name != String.Empty)
            {
                if (!EDITxtHandler.IsAllQuanjiaoJapan(name))
                {
                    MessageBox.Show("输入数据包含半角字符！");
                }
            }
            
        }

        private void specTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            string name = textBox.Text;

            if (name != String.Empty)
            {
                if (!EDITxtHandler.IsAllQuanjiaoJapan(name))
                {
                    MessageBox.Show("输入数据包含半角字符！");
                }
            }
        }
    }
}
