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
        private List<t_shoplist> stores;
        //mark 20181008
        private List<t_warehouses> warehouseList;
        private List<t_transports> transportList;

        public StoresManagement(int storeId, string type)
        {
            InitializeComponent();

            using (var ctx = new GODDbContext())
            {
                this.stores = ctx.t_shoplist.ToList();
                List<t_customers> customers = ctx.t_customers.ToList();
                transportList = ctx.t_transports.ToList();


                this.cusotmerComboBox.ValueMember = "Id";
                this.cusotmerComboBox.DisplayMember = "FullName";
                this.cusotmerComboBox.DataSource = customers;

                this.storesComboBox.ValueMember = "店番";
                this.storesComboBox.DisplayMember = "店名";
                this.storesComboBox.DataSource = this.stores;


                //mark   20181009           
                warehouseList = ctx.t_warehouses.ToList();
                var shipperCo = warehouseList.Select(s => new MockEntity { Id = s.Id, ShortName = s.ShortName, FullName = s.FullName }).Distinct().ToList();
                //shipperCo.Insert(0, new MockEntity { ShortName = "その他", FullName = "その他" });

                this.warehouseNamecomboBox1.DisplayMember = "FullName";
                this.warehouseNamecomboBox1.ValueMember = "Id";
                this.warehouseNamecomboBox1.DataSource = shipperCo.ToList();


                this.transportnamecomboBox2.DisplayMember = "fullname";
                this.transportnamecomboBox2.ValueMember = "id";
                this.transportnamecomboBox2.DataSource = transportList;



                if (type == "Update")
                {
                    t_shoplist store = ctx.t_shoplist.Find(storeId);
                    storeCodeTextBox.Text = store.店番.ToString();

                    if (store.店名 != null)
                        storeNameTextBox.Text = store.店名;
                    if (store.店名カナ != null)
                        textBox12.Text = store.店名カナ;
                    
                    if (store.郵便番号 != null)
                        postalTextBox8.Text = store.郵便番号.ToString();
                    if (store.県別 != null)
                        countyTextBox.Text = store.県別.ToString();
                    if (store.県内エリア != null)
                        districtTextBox.Text = store.県内エリア.ToString();

                    var customer = customers.Find(o => o.Id == store.customerId);
                    if (customer != null)
                    {
                        cusotmerComboBox.SelectedItem = customer;
                    }

                    if (store.住所 != null)
                        addressTextBox1.Text = store.住所;
                    if (store.電話番号 != null)
                    {
                        phoneTextBox2.Text = store.電話番号.ToString();
                    }
                    if (store.営業担当 != null)
                    {
                        officerTextBox3.Text = store.営業担当.ToString();
                    }
                    if (store.FAX番号 != null)
                    {
                        faxTextBox3.Text = store.FAX番号.ToString();
                    }
                    if (store.売上ランク != null)
                    {
                        storeRankComboBox.Text = store.売上ランク;
                    }

                    warehouseNamecomboBox1.SelectedValue = store.warehouse_id;
                    transportnamecomboBox2.SelectedValue = store.transport_id;



                }
                else
                {
                    var customer = customers.FirstOrDefault();
                    if (customer != null)
                    {
                        cusotmerComboBox.SelectedItem = customer;
                    }
                    this.storeCodeTextBox.Enabled = true;
                }

            }
            showtype = type;


        }

        private void submitFormButton_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                if (countyTextBox.Text.Length == 0)
                {
                    MessageBox.Show("*県別*を入力してください");
                    return;
                }

                using (var ctx = new GODDbContext())
                {
                    if (showtype == "Update")
                    {
                        t_shoplist store = ctx.t_shoplist.Find(Convert.ToInt32(storeCodeTextBox.Text));

                        store.店番 = Convert.ToInt32(storeCodeTextBox.Text);
                        store.店名 = storeNameTextBox.Text;
                        store.店名カナ = textBox12.Text;
                        store.郵便番号 = postalTextBox8.Text;
                        store.県別 = countyTextBox.Text;
                        store.県内エリア = districtTextBox.Text;
                        store.customerId = Convert.ToInt32(cusotmerComboBox.SelectedValue);
                        store.住所 = addressTextBox1.Text;
                        store.電話番号 = phoneTextBox2.Text;
                        store.FAX番号 = this.faxTextBox3.Text;
                        store.営業担当 = this.officerTextBox3.Text;
                        store.売上ランク = this.storeRankComboBox.Text;

                        store.warehouse_id = Convert.ToInt32(this.warehouseNamecomboBox1.SelectedValue);
                        store.transport_id = Convert.ToInt32(this.transportnamecomboBox2.SelectedValue);
                        store.warehouseName = this.warehouseNamecomboBox1.Text;
                        store.配送担当 = this.transportnamecomboBox2.Text;

                        ctx.SaveChanges();
                        MessageBox.Show(String.Format("店舗情報更新完了!"));
                    }
                    else if (showtype == "Add")
                    {

                        t_shoplist store = new t_shoplist();
                        store.店番 = Convert.ToInt32(storeCodeTextBox.Text);

                        store.店名 = storeNameTextBox.Text;

                        store.店名カナ = textBox12.Text;

                        store.郵便番号 = postalTextBox8.Text;

                        store.県別 = countyTextBox.Text;

                        store.県内エリア = districtTextBox.Text;

                        store.customerId = Convert.ToInt32(cusotmerComboBox.SelectedValue);

                        store.住所 = addressTextBox1.Text;

                        store.電話番号 = phoneTextBox2.Text;

                        store.FAX番号 = this.faxTextBox3.Text;

                        store.営業担当 = this.officerTextBox3.Text;

                        store.売上ランク = this.storeRankComboBox.Text;

                        store.参考店舗 = Convert.ToInt32(this.storesComboBox.SelectedValue);

                        store.warehouse_id = Convert.ToInt32(this.warehouseNamecomboBox1.SelectedValue);
                        store.transport_id = Convert.ToInt32(this.transportnamecomboBox2.SelectedValue);
                        store.warehouseName = this.warehouseNamecomboBox1.Text;
                        store.配送担当 = this.transportnamecomboBox2.Text;


                        ctx.t_shoplist.Add(store);
                        ctx.SaveChanges();
                        ModelCallback.AfterStoreCreated(store);

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
                var exists = (from i in ctx.t_shoplist
                              where i.店番 == zisheID
                              select i).FirstOrDefault();

                if (exists != null)
                {
                    errorProvider1.SetError(storeCodeTextBox, String.Format("店番がすでに存在しています"));
                    return;
                }
            }
        }

        private void countyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (countyTextBox.Text.Length > 0)
            {
                var storesByCounty = this.stores.Where(s => s.県別 == countyTextBox.Text).ToList();
                if (storesByCounty.Count > 0)
                {
                    this.storesComboBox.DataSource = storesByCounty;
                }
            }
        }
    }
}
