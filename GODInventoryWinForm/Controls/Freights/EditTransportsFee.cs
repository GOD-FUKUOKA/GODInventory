using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls.Freights
{
    public partial class EditTransportsFee : Form
    {
        private List<t_warehouses> warehouseList;
        private int orderId;
        private t_freights freights { get; set; }
        private List<t_transports> transportList;
        private List<t_shoplist> shopList;
        List<t_itemlist> productList = null;
        List<t_genre> genreList = null;
        public EditTransportsFee()
        {
            InitializeComponent();
        }
        public int OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                InitializeOrder();
            }
        }
        private void InitializeOrder()
        {

            var ctx = entityDataSource1.DbContext as GODDbContext;
            freights = ctx.t_freights.Find(OrderId);
            //freights = (from s in ctx.t_freights
            //            where s.id == OrderId
            //            select s).FirstOrDefault();
            warehouseList = ctx.t_warehouses.ToList();
            this.productList = ctx.t_itemlist.ToList();
            this.genreList = ctx.t_genre.ToList();
            transportList = ctx.t_transports.ToList();
         
            this.whComboBox.ValueMember = "Id";
            this.whComboBox.DisplayMember = "FullName";
            this.whComboBox.DataSource = warehouseList;
      
            // 県別
            shopList = ctx.t_shoplist.ToList();
            if (shopList.Count > 0)
            {
                var counties = shopList.Select(s => s.県別).Distinct().ToList();
                //counties.Insert(0, "すべて");
                this.countyComboBox1.DataSource = counties;
            }

            //this.transcomboBox1.DisplayMember = "fullname";
            //this.transcomboBox1.ValueMember = "id";
            //this.transcomboBox1.DataSource = transportList;
      
            this.transportnameTextBox.DisplayMember = "fullname";
            this.transportnameTextBox.ValueMember = "id";
            this.transportnameTextBox.DataSource = transportList;

            var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();

            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;

            // 产品分类， 产品
            var genres = this.genreList.Select(s => new MockEntity { Id = s.idジャンル, FullName = s.ジャンル名 }).ToList();

            this.genresComboBox.DisplayMember = "FullName";
            this.genresComboBox.ValueMember = "Id";
            this.genresComboBox.DataSource = genres;

            if (freights != null)
            {
                InitializeControls();
            }
        }
        private void InitializeControls()
        {
            whComboBox.Text = freights.warehousename;

            transportnameTextBox.Text = freights.transportname;

            unitnameTextBox.Text = freights.unitname;

            feeTextBox.Text = freights.fee.ToString();

            columnnameTextBox.Text = freights.columnname;

            storeComboBox.SelectedValue = freights.shop_id;

            var pid = freights.自社コード;

            var product = this.productList.FirstOrDefault(o => { return o.自社コード == freights.自社コード; });
            if (product != null) {
                genresComboBox.SelectedValue = Convert.ToInt32(product.ジャンル);
                productsComboBox.SelectedValue = product.自社コード;
            }

        }
        private void submitFormButton_Click(object sender, EventArgs e)
        {

            if (!validateAttributes())
            {
                return;
            }

            freights.warehousename = whComboBox.Text;

            freights.transportname = transportnameTextBox.Text;

            freights.unitname  = unitnameTextBox.Text ;

            freights.fee = Convert.ToDecimal(feeTextBox.Text);

            freights.columnname = columnnameTextBox.Text;

            freights.shop_id = Convert.ToInt32(storeComboBox.SelectedValue);
                     
            this.entityDataSource1.SaveChanges();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
         
            this.Close();
        }
        private bool validateAttributes(string[] selectedAttributeNames = null)
        {
            var validated = true;
            string msg = String.Empty;

            if (this.feeTextBox.Text.Trim() == null || this.feeTextBox.Text.Trim() == "")
            {
                errorProvider1.SetError(feeTextBox, "不能为空");
                validated = false;
            }
            if (this.unitnameTextBox.Text.Trim() == null || this.unitnameTextBox.Text.Trim() == "")
            {
                errorProvider1.SetError(unitnameTextBox, "不能为空");
                validated = false;
            }
            if (this.columnnameTextBox.Text.Trim() == null || this.columnnameTextBox.Text.Trim() == "")
            {
                errorProvider1.SetError(columnnameTextBox, "不能为空");
                validated = false;
            }
           
            return validated;

        }
        private void countyComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string county = this.countyComboBox1.Text;
            var filtered = shopList.FindAll(s => s.県別 == county);
            if (filtered.Count > 0)
            {
                var shops = filtered.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                this.storeComboBox.SelectedIndex = 0;
            }
            else
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;

            }
        }

        private void genresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MockEntity> productsByGenre;
            int genreId = Convert.ToInt32( this.genresComboBox.SelectedValue );

            if (genreId > 0)
            {
                productsByGenre = this.productList.Where(o => o.ジャンル == genreId).Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            else
            {
                productsByGenre = this.productList.Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }

            this.productsComboBox.ValueMember = "Id";
            this.productsComboBox.DisplayMember = "FullName";
            this.productsComboBox.DataSource = productsByGenre;
        }



    }
}
