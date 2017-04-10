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
    public partial class OrderCostSettingForm : Form
    {
        List<t_genre> genres = new List<t_genre>();
        List<t_itemlist> products = new List<t_itemlist>();
        List<t_shoplist> stores = new List<t_shoplist>();

        public OrderCostSettingForm()
        {
            InitializeComponent();
            this.ordersDataGridView.AutoGenerateColumns = false;

            InitializeDataSource();
        }

        private void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as GODDbContext;
            {
                this.genres = ctx.t_genre.ToList();
                this.products = ctx.t_itemlist.ToList();
                this.stores = ctx.t_shoplist.ToList();
                var counties = this.stores.Select(s => new MockEntity { ShortName = s.県別, FullName = s.県別 }).Distinct().ToList();

                counties.Insert(0, new MockEntity { ShortName = "", FullName = "すべて" });

                this.genresComboBox.ValueMember = "idジャンル";
                this.genresComboBox.DisplayMember = "ジャンル名";
                this.genresComboBox.DataSource = genres;

                this.countyComboBox.ValueMember = "ShortName";
                this.countyComboBox.DisplayMember = "FullName";
                this.countyComboBox.DataSource = counties;

            }


        }

        private void OrderCostSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (this.costTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please input ");
                return;
            }


            var startAt = this.startAtDateTimePicker.Value;
            var endAt = this.endAtDateTimePicker.Value;
            int productCode = (int)this.productsComboBox.SelectedValue;
            decimal cost = Convert.ToDecimal(this.costTextBox.Text);
            string county = Convert.ToString( this.countyComboBox.SelectedValue );

            int count = OrderHelper.ChangeOrderCost(productCode, cost, startAt, endAt, county);

            if (count > 0)
            {
                MessageBox.Show(string.Format("update {0} orders successfully", count));
                pager1.Bind();
                //this.entityDataSource1.Refresh();
                //this.ordersDataGridView.Refresh();

            }
        }

        private void genresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int genreId = (int)this.genresComboBox.SelectedValue;
            var genreProducts = products.Where(o => o.ジャンル == genreId).ToList();

            this.productsComboBox.ValueMember = "自社コード";
            this.productsComboBox.DisplayMember = "商品名";
            this.productsComboBox.DataSource = genreProducts;
        }

        private void searchButton1_Click(object sender, EventArgs e)
        {
            pager1.Bind();
        }

        // return total orders count
        private int  InitializeOrderDataSource()
        {
            
            DateTime startAt = this.startAtDateTimePicker.Value;
            DateTime endAt = this.endAtDateTimePicker.Value;
            int productCode = (int)this.productsComboBox.SelectedValue;
            string county = Convert.ToString(this.countyComboBox.SelectedValue);

            int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
            int count = 0;
            // 由于未知原因 entityDatasource.createView(query),总是取得更新之前的数据，所以使用 GODDbContext
            using (var ctx = new GODDbContext())
            {
                var query = ctx.t_orderdata.Where(o => (o.発注日 >= startAt) && (o.発注日 <= endAt) && (o.自社コード == productCode));
                if (county.Length > 0)
                {
                    query = query.Where(o => o.県別 == county);
                }
                count = query.Count();
                query = query.OrderBy(o => o.発注日).Skip(offset).Take(5000);

                var list = query.ToList();

                this.bindingSource1.DataSource = new SortableBindingList<t_orderdata>(list);
                this.ordersDataGridView.DataSource = this.bindingSource1;
            }
            return count;
        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            int count = InitializeOrderDataSource();
            return count;
        }
    }
}
