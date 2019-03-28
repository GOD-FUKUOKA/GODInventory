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
    public partial class CreateTransportsFee : Form
    {
        List<t_itemlist> products = null;
        private List<t_transports> transportList;
        private List<t_shoplist> shopList;
        private List<t_warehouses> warehouseList;
        List<t_genre> genres = null;

        private int orderId;
        private t_freights freights { get; set; }
        public CreateTransportsFee()
        {
            InitializeComponent();
            InitializeOrder();
        }

        private void InitializeOrder()
        {

            var ctx = entityDataSource1.DbContext as GODDbContext;

            warehouseList = ctx.t_warehouses.ToList();
            transportList = ctx.t_transports.ToList();
            this.genres = ctx.t_genre.ToList();
            this.products = ctx.t_itemlist.ToList();


            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.DataSource = warehouseList;

            // 県別
            shopList = ctx.t_shoplist.ToList();
            if (shopList.Count > 0)
            {
                var counties = shopList.Select(s => s.県別).Distinct().ToList();

                this.countyComboBox1.DataSource = counties;
            }


            this.transportComboBox.DisplayMember = "fullname";
            this.transportComboBox.ValueMember = "id";
            this.transportComboBox.DataSource = transportList;

            var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();

            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;

        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            if (!validateAttributes())
            {
                return;
            }


            using (var ctx = new GODDbContext())
            {
                    // 运费依赖于 商品、仓库、商店、物流公司
                    int warehouseId = Convert.ToInt32(warehouseComboBox.SelectedValue);
                    int storeId = Convert.ToInt32(storeComboBox.SelectedValue);
                    int transportId = Convert.ToInt32(transportComboBox.SelectedValue);
                    string unitname = unitnameTextBox.Text;

                    var freight = (from t_freights o in ctx.t_freights
                                   where warehouseId == o.warehouse_id && storeId == o.shop_id && transportId == o.transport_id && unitname == o.unitname
                                   select o).FirstOrDefault();
                    if (freight == null)
                    {
                        t_freights freights = new t_freights();
                        freights.warehousename = warehouseComboBox.Text;
                        freights.transportname = transportComboBox.Text;
                        freights.unitname = unitnameTextBox.Text;
                        freights.fee = Convert.ToDecimal(invoiceNOTextBox.Text);
                        freights.columnname = this.columnnameTextBox.Text;


                        freights.shop_id = Convert.ToInt32(storeComboBox.SelectedValue);
                        freights.transport_id = Convert.ToInt32(transportComboBox.SelectedValue);
                        freights.warehouse_id = Convert.ToInt32(warehouseComboBox.SelectedValue);

                        ctx.t_freights.Add(freights);
                        ctx.SaveChanges();

                        MessageBox.Show(String.Format("登録完了!"));

                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show(String.Format("无法添加， 已存在!"));
                    }
            }
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

        }

        private bool validateAttributes(string[] selectedAttributeNames = null)
        {
            var validated = true;
            string msg = String.Empty;

            if (this.invoiceNOTextBox.Text.Trim() == null || this.invoiceNOTextBox.Text.Trim() == "")
            {
                errorProvider1.SetError(invoiceNOTextBox, "不能为空");
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

    }
}
