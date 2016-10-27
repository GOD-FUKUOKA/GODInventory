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
        private List<t_genre> genreList;
        public ProductsManagement(List<int> itemlist, string type)
        {
            InitializeComponent();
            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.OrderBy(o => o.Position).ToList();

                this.genreComboBox.DisplayMember = "ジャンル名";
                this.genreComboBox.ValueMember = "idジャンル";
                this.genreComboBox.DataSource = genreList;


                if (type == "Update")
                {
                    t_itemlist order = ctx.t_itemlist.Find(itemlist[0]);
                    InnerCodeTextBox.Text = order.自社コード.ToString();
                    customerTextBox.Text = order.得意先;
                    genreComboBox.Text = order.ジャンル.ToString();
                    productNameTextBox12.Text = order.商品名;
                    specTextBox.Text = order.規格;
                    moqTextBox8.Text = order.PT入数.ToString();
                    janCodeTextBox.Text = order.JANコード.ToString();
                    instoreCodeTextBox3.Text = order.インストアコード.ToString();
                    unitWeightTextBox11.Text = order.単品重量.ToString();
                    unitTextBox1.Text = order.単位;
                    textBox2.Text = order.PT単位か.ToString();

                    this.productCodeTextBox.Text = order.商品コード.ToString();

                }
                else
                {
                    this.InnerCodeTextBox.Enabled = true;
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
                    t_itemlist order = ctx.t_itemlist.Find(Convert.ToInt32(InnerCodeTextBox.Text));

                    order.得意先 = customerTextBox.Text;
                    order.ジャンル = Convert.ToInt16(genreComboBox.SelectedValue);
                    order.商品名 = productNameTextBox12.Text;
                    order.規格 = specTextBox.Text;
                    order.PT入数 = Convert.ToInt32(moqTextBox8.Text);
                    order.JANコード = Convert.ToInt64(janCodeTextBox.Text);
                    if (instoreCodeTextBox3.Text != "")
                    {
                        order.インストアコード = Convert.ToInt64(instoreCodeTextBox3.Text);
                    }
                    else {
                        order.インストアコード = null;
                    }
                    order.単品重量 = Convert.ToDouble(unitWeightTextBox11.Text);
                    order.単位 = unitTextBox1.Text;

                    if (textBox2.Text != "")
                    {
                        order.PT単位か = Convert.ToSByte(textBox2.Text);
                    }
                    else {
                        order.PT単位か = null;
                    }
                    order.商品コード = Convert.ToInt32(this.productCodeTextBox.Text);
                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("商品情報更新完了!"));
                }
                else if (showtype == "Add")
                {

                    t_itemlist order = new t_itemlist();
                    order.自社コード = Convert.ToInt32(InnerCodeTextBox.Text);

                    order.得意先 = customerTextBox.Text;
                    
                    order.ジャンル = Convert.ToInt16(genreComboBox.SelectedValue);
                    order.商品名 = productNameTextBox12.Text;
                    order.規格 = specTextBox.Text;
                    if (moqTextBox8.Text != "")
                        order.PT入数 = Convert.ToInt32(moqTextBox8.Text);
                    if (janCodeTextBox.Text != "")
                        order.JANコード = Convert.ToInt64(janCodeTextBox.Text);
                    if (instoreCodeTextBox3.Text != "")
                        order.インストアコード = Convert.ToInt64(instoreCodeTextBox3.Text);
                    if (unitWeightTextBox11.Text != "")
                        order.単品重量 = Convert.ToDouble(unitWeightTextBox11.Text);
                    order.単位 = unitTextBox1.Text;
                    if (textBox2.Text != "")
                        order.PT単位か = Convert.ToSByte(textBox2.Text);
                    if (productCodeTextBox.Text != "")
                        order.商品コード = Convert.ToInt32(this.productCodeTextBox.Text);

                    ctx.t_itemlist.Add(order);
                    ctx.SaveChanges();
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
            if (InnerCodeTextBox.Text == "")
                return;

            int zisheID = Convert.ToInt32(InnerCodeTextBox.Text);

            using (var ctx = new GODDbContext())
            {
                var List = (from i in ctx.t_itemlist
                            where i.自社コード == zisheID
                            select new v_itemprice { 自社コード = i.自社コード }).ToList();

                if (List.Count > 0)
                {
                    errorProvider1.SetError(InnerCodeTextBox, String.Format("自社コードがすでに存在しています"));
                    return;
                }
            }

        }
    }
}
