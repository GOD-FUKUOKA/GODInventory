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
using System.Data.Entity.Validation;

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
                    if (order.店番!=null)
                    storeCodeTextBox.Text = order.店番.ToString();
                    if (order.店名 != null)
                    storeNameTextBox.Text = order.店名;
                    if (order.店名カナ != null)
                    textBox12.Text = order.店名カナ;
                    if (order.配送担当 != null)
                    shipperTextBox.Text = order.配送担当;
                    if (order.郵便番号 != null)
                    postalTextBox8.Text = order.郵便番号.ToString();
                    if (order.県別 != null)
                    countyTextBox.Text = order.県別.ToString();
                    if (order.県内エリア != null)
                    districtTextBox.Text = order.県内エリア.ToString();
                    if (order.customerId != null)
                    customerTextBox11.Text = order.customerId.ToString();
                    if (order.住所 != null)
                    addressTextBox1.Text = order.住所;
                    if (order.電話番号 != null)
                    phoneTextBox2.Text = order.電話番号.ToString();
                    if (order.営業担当 != null)
                    officerTextBox3.Text = order.営業担当.ToString();
                    if (order.FAX番号 != null)
                    faxTextBox3.Text = order.FAX番号.ToString();
                }
            }
            else
                this.storeCodeTextBox.Enabled = true;

            showtype = type;


        }

        private void submitFormButton_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                using (var ctx = new GODDbContext())
                {
                    if (showtype == "Update")
                    {
                        t_shoplist order = ctx.t_shoplist.Find(Convert.ToInt32(storeCodeTextBox.Text));

                        order.店番 = Convert.ToInt32(storeCodeTextBox.Text);
                        order.店名 = storeNameTextBox.Text;
                        order.店名カナ = textBox12.Text;
                        order.配送担当 = shipperTextBox.Text;
                        order.郵便番号 = postalTextBox8.Text;
                        order.県別 = countyTextBox.Text;
                        order.県内エリア = districtTextBox.Text;
                        order.customerId = Convert.ToInt32(customerTextBox11.Text);
                        order.住所 = addressTextBox1.Text;
                        order.電話番号 = phoneTextBox2.Text;
                        order.FAX番号 = this.faxTextBox3.Text;
                        order.営業担当 = this.officerTextBox3.Text;
                        ctx.SaveChanges();
                        MessageBox.Show(String.Format("店舗情報更新完了!"));
                    }
                    else if (showtype == "Add")
                    {

                        t_shoplist order = new t_shoplist();
                        order.店番 = Convert.ToInt32(storeCodeTextBox.Text);

                        order.店名 = storeNameTextBox.Text;

                        order.店名カナ = textBox12.Text;

                        order.配送担当 = shipperTextBox.Text;

                        order.郵便番号 = postalTextBox8.Text;

                        order.県別 = countyTextBox.Text;

                        order.県内エリア = districtTextBox.Text;
                        if (customerTextBox11.Text != "")
                        {
                            order.customerId = Convert.ToInt32(customerTextBox11.Text);
                        }
                        order.住所 = addressTextBox1.Text;

                        order.電話番号 = phoneTextBox2.Text;

                        order.FAX番号 = this.faxTextBox3.Text;

                        order.営業担当 = this.officerTextBox3.Text;

                        ctx.t_shoplist.Add(order);
                        ctx.SaveChanges();
                        MessageBox.Show(String.Format("店舗登録完了!"));

                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
            this.Close();

        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void storeNamTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (storeCodeTextBox.Text == "")
                return;

            int zisheID = Convert.ToInt32(storeCodeTextBox.Text);

            using (var ctx = new GODDbContext())
            {
                var List = (from i in ctx.t_shoplist
                            where i.店番 == zisheID
                            select i).FirstOrDefault();

                if (List !=null)
                {
                    errorProvider1.SetError(storeCodeTextBox, String.Format("店番がすでに存在しています"));
                    return;
                }
            }
        }
    }
}
