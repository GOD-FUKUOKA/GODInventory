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
        List<t_itemlist> products = null;
        List<t_genre> genres = null;
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
            this.products = ctx.t_itemlist.ToList();
            this.genres = ctx.t_genre.ToList();
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
                shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;
                this.storeComboBox.SelectedIndex = 0;
            }
            else
            {
                var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
                shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
                this.storeComboBox.DisplayMember = "FullName";
                this.storeComboBox.ValueMember = "Id";
                this.storeComboBox.DataSource = shops;

            }
        }

        private void genresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
