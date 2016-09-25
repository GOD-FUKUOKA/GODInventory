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
                if (type == "Update")
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
                else
                    this.storeNamTextBox.Enabled = true;
                genreList = ctx.t_genre.OrderBy(o => o.Position).ToList();
            }
            showtype = type;
 
            t_genre item = new t_genre();         
            item.Position = 0;
            item.idジャンル = 0;
            item.ジャンル名 = "";
            genreList.Insert(0, item);

           // genreList.Insert(0, new MockEntity { idジャンル = "不限", ジャンル名 = "不限" });
            this.invoiceNOTextBox.DisplayMember = "ジャンル名";
            this.invoiceNOTextBox.ValueMember = "idジャンル";
            this.invoiceNOTextBox.DataSource = genreList;


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

        private void storeNamTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (storeNamTextBox.Text == "")
                return;

            int zisheID = Convert.ToInt32(storeNamTextBox.Text);

            using (var ctx = new GODDbContext())
            {
                var List = (from i in ctx.t_itemlist
                            where i.自社コード == zisheID
                            select new v_itemprice { 自社コード = i.自社コード }).ToList();

                if (List.Count > 0)
                {
                    errorProvider1.SetError(storeNamTextBox, String.Format("自社コード 已存在"));
                    return;
                }
            }

        }
    }
}
