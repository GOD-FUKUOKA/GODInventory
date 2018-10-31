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
        public t_pricelist Price { get; set; }

        private int priceId;
        private t_itemlist Product { get; set; }

        //mark 20181008
        private List<t_warehouses> warehouseList;
        public EditPriceForm( int price)
        {
            InitializeComponent();
            priceId = price;
            InitializePrice();
        }

        private void InitializePrice()
        {
            var ctx = entityDataSource1.DbContext as GODDbContext;
            Price = ctx.t_pricelist.Find(priceId);

   
            Product = (from p in ctx.t_itemlist
                       where p.自社コード == Price.自社コード
                       select p).First();
            InitializeControls();            
            
        }

        private void InitializeControls() {

            this.productCodeTextBox.Text = Price.自社コード.ToString();
            this.storeComboNameTextBox.Text = string.Format("{0}({1})", Price.店名, Price.店番);
            this.storeCountyTextBox.Text = Price.県別;
            this.productNameTextBox.Text = Product.商品名;
            this.productSpecTextBox.Text = Product.規格;


            this.priceTextBox.Text = Price.通常原単価.ToString();
            this.promotePriceTextBox.Text = Price.特売原単価.ToString();
            this.adPriceTextBox.Text = Price.広告原単価.ToString();
            this.salePriceTextBox.Text = Price.売単価.ToString();
            this.costTextBox.Text = Price.仕入原価.ToString();

            var ctx = entityDataSource1.DbContext as GODDbContext;
          
            warehouseList = ctx.t_warehouses.ToList();
            var shipperCo = warehouseList.Select(s => new MockEntity { Id = s.Id, ShortName = s.ShortName, FullName = s.FullName }).Distinct().ToList();
        
            this.shipperComboBox3.DisplayMember = "FullName";
            this.shipperComboBox3.ValueMember = "FullName";
            this.shipperComboBox3.DataSource = shipperCo.ToList();
           

        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {

            Price.通常原単価 = Convert.ToDecimal(this.priceTextBox.Text);
            Price.広告原単価 = Convert.ToDecimal(this.adPriceTextBox.Text);
            Price.特売原単価 = Convert.ToDecimal(this.promotePriceTextBox.Text);
            Price.売単価 = Convert.ToDecimal(this.salePriceTextBox.Text);
            Price.仕入原価 = Convert.ToDecimal(this.costTextBox.Text);
            Price.配送担当 = Convert.ToString(this.shipperComboBox3.Text);
         
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
