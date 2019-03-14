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


            this.storeNamTextBox.DisplayMember = "fullname";
            this.storeNamTextBox.ValueMember = "id";
            this.storeNamTextBox.DataSource = transportList;

            var shops = shopList.Select(s => new MockEntity { Id = s.店番, FullName = s.店名 }).ToList();
            shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;



            var genreList = this.genres.Select(s => new MockEntity { Id = s.idジャンル, FullName = s.ジャンル名 }).ToList();
            genreList.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.genresComboBox.ValueMember = "Id";
            this.genresComboBox.DisplayMember = "FullName";
            this.genresComboBox.DataSource = genreList;



        }
     
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext()) 
            {
                if (orderAtTextBox.Text.Length > 0)
                {
                  int zi= Convert.ToInt32( orderAtTextBox.SelectedValue);


                    var List = (from t_freights o in ctx.t_freights
                                where zi == o.自社コード
                                select o).ToList();
                    if (List.Count == 0)
                    {
                        t_freights freights = new t_freights();
                        freights.自社コード = Convert.ToInt32(orderAtTextBox.SelectedValue);
                        freights.warehousename = whComboBox.Text;
                        freights.transportname = storeNamTextBox.Text;
                        freights.unitname = storeCodeTextBox.Text;
                        freights.fee = Convert.ToInt32(invoiceNOTextBox.Text);


                        freights.shop_id = Convert.ToInt32(storeComboBox.SelectedValue);
                        //freights.transport_id = Convert.ToInt32(transcomboBox1.SelectedValue);
                        freights.warehouse_id = Convert.ToInt32(whComboBox.SelectedValue); 
 
                        ctx.t_freights.Add(freights);
                        ctx.SaveChanges();

                        MessageBox.Show(String.Format("登録完了!"));
                    }
                    else
                    {
                        MessageBox.Show(String.Format("无法添加， 已存在!"));

                    }
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
            List<MockEntity> productsByGenre;
            int genreId = (int)this.genresComboBox.SelectedValue;

            if (genreId > 0)
            {
                productsByGenre = this.products.Where(o => o.ジャンル == genreId).Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            else
            {
                productsByGenre = this.products.Select(s => new MockEntity { Id = s.自社コード, FullName = s.商品名 }).ToList();
            }
            productsByGenre.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });

            this.orderAtTextBox.ValueMember = "Id";
            this.orderAtTextBox.DisplayMember = "FullName";
            this.orderAtTextBox.DataSource = productsByGenre;
        }



    }
}
