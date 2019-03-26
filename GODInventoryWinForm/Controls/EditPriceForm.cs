using GODInventory.MyLinq;
using GODInventory.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    public partial class EditPriceForm : Form
    {
        public t_pricelist price { get; set; }

        private int priceId;
        private t_itemlist Product { get; set; }

        //mark 20181008
        private List<t_warehouses> warehouseList;
        private List<t_transports> transportList;

        public EditPriceForm(int price)
        {
            InitializeComponent();
            priceId = price;
            InitializePrice();
        }

        private void InitializePrice()
        {
            var ctx = entityDataSource1.DbContext as GODDbContext;
            price = ctx.t_pricelist.Find(priceId);

   
            Product = (from p in ctx.t_itemlist
                       where p.自社コード == price.自社コード
                       select p).First();
            InitializeControls();            
            
        }

        private void InitializeControls() {

            this.productCodeTextBox.Text = price.自社コード.ToString();
            this.storeComboNameTextBox.Text = string.Format("{0}({1})", price.店名, price.店番);
            this.storeCountyTextBox.Text = price.県別;
            this.productNameTextBox.Text = Product.商品名;
            this.productSpecTextBox.Text = Product.規格;


            this.priceTextBox.Text = price.通常原単価.ToString();
            this.promotePriceTextBox.Text = price.特売原単価.ToString();
            this.adPriceTextBox.Text = price.広告原単価.ToString();
            this.salePriceTextBox.Text = price.売単価.ToString();
            this.costTextBox.Text = price.仕入原価.ToString();

            var ctx = entityDataSource1.DbContext as GODDbContext;
          
            warehouseList = ctx.t_warehouses.ToList();
            transportList = ctx.t_transports.ToList();

        
            this.transportComboBox3.DisplayMember = "fullname";
            this.transportComboBox3.ValueMember = "id";
            this.transportComboBox3.DataSource = transportList;
            this.transportComboBox3.Text = price.配送担当;
           
            this.warehouseNamecomboBox1.DisplayMember = "FullName";
            this.warehouseNamecomboBox1.ValueMember = "Id";
            this.warehouseNamecomboBox1.DataSource = warehouseList;




        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {

            price.通常原単価 = Convert.ToDecimal(this.priceTextBox.Text);
            price.広告原単価 = Convert.ToDecimal(this.adPriceTextBox.Text);
            price.特売原単価 = Convert.ToDecimal(this.promotePriceTextBox.Text);
            price.売単価 = Convert.ToDecimal(this.salePriceTextBox.Text);
            price.仕入原価 = Convert.ToDecimal(this.costTextBox.Text);

            price.warehouse_id = Convert.ToInt32(warehouseNamecomboBox1.SelectedValue);
            price.transport_id = Convert.ToInt32(transportComboBox3.SelectedValue);

            price.warehouseName = this.warehouseNamecomboBox1.Text;
            price.配送担当 = this.transportComboBox3.Text;


            this.entityDataSource1.SaveChanges();
                
            this.Close();
        }

        private void receivedAtTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void shipAtTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void orderQuantityTextBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cancelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
    }
}
