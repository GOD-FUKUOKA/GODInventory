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

namespace GODInventoryWinForm
{
    public partial class EditTransportsFee : Form
    {
        private List<t_warehouses> warehouseList;
        private int orderId;
        private t_freights freights { get; set; }
        private List<t_transports> transportList;
        private List<t_shoplist> shopList;

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

            this.whComboBox.ValueMember = "Id";
            this.whComboBox.DisplayMember = "FullName";
            this.whComboBox.DataSource = warehouseList;
      


            // 県別
            shopList = ctx.t_shoplist.ToList();
            if (shopList.Count > 0)
            {
                var counties = shopList.Select(s => s.県別).Distinct().ToList();
                counties.Insert(0, "すべて");
                this.countyComboBox1.DataSource = counties;
            }


            //this.transcomboBox1.DisplayMember = "fullname";
            //this.transcomboBox1.ValueMember = "id";
            //this.transcomboBox1.DataSource = transportList;
            var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
            shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;


            if (freights != null)
                InitializeControls();
        }
        private void InitializeControls()
        {

            orderAtTextBox.Text = freights.id.ToString();

            whComboBox.Text = freights.warehousename;


            storeNamTextBox.Text = freights.transportname;

            storeCodeTextBox.Text = freights.unitname.ToString();

            invoiceNOTextBox.Text = freights.fee.ToString();



            storeComboBox.SelectedValue = freights.shop_id;
           

        }
        private void submitFormButton_Click(object sender, EventArgs e)
        {

            freights.id =Convert.ToInt32( orderAtTextBox.Text);


            freights.warehousename = whComboBox.Text;



            freights.transportname = storeNamTextBox.Text;


            freights.unitname  = storeCodeTextBox.Text ;


            freights.fee   =Convert.ToInt32( invoiceNOTextBox.Text);


            freights.shop_id = Convert.ToInt32(storeComboBox.SelectedValue);
                     
            this.entityDataSource1.SaveChanges();

            this.Close();
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



    }
}
