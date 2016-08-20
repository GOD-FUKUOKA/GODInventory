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

namespace GODInventoryWinForm
{
    public partial class CreateorderForm_ShopCode : Form
    {
        private BindingList<v_itemlist> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;
        public v_itemlist v_stockiositem;
        public bool ischeckmunal;


        public CreateorderForm_ShopCode()
        {
            InitializeComponent();

            ischeckmunal = false;

            InitializeDataSource();

        }
        private void InitializeDataSource()
        {
            stockiosList = new BindingList<v_itemlist>();

            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.ToList();
                warehouseList = ctx.t_warehouses.ToList();
            }

            this.listBox1.DisplayMember = "ジャンル名";
            this.listBox1.ValueMember = "idジャンル";
            this.listBox1.DataSource = genreList;

         
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("商品名", 200, HorizontalAlignment.Left); //一步添加


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stockiosList = new BindingList<v_itemlist>();

            //  stockiosList.Clear();
            var genre_id = GetGenreId();
            if (genre_id > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    var results = (from s in ctx.t_itemlist
                                   where s.ジャンル == (short)genre_id
                                   select new v_itemlist { 商品コード = s.商品コード, 規格 = s.規格, 商品名 = s.商品名, ジャンル = s.ジャンル, JANコード = s.JANコード, ロット = s.PT入数, 自社コード = s.自社コード }).ToList();
                    for (int i = 0; i < results.Count; i++)
                    {
                        results[i].Id = i + 1;
                        stockiosList.Add(results[i]);
                    }
                }
            }
            this.listView1.Items.Clear();
            //this.listView1.BeginUpdate();

            foreach (v_itemlist item in stockiosList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.商品名;

                //lvi.SubItems.Add("第2列,第" + i + "行");

                this.listView1.Items.Add(lvi);
                //this.listView1.Items.Add(item.商品名);

            }

        }
        private int GetGenreId()
        {

            return ((this.listBox1.SelectedIndex >= 0) ? (int)this.listBox1.SelectedValue : 0);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            v_stockiositem = new v_itemlist();

            int selectCount = this.listView1.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                string textShopname = this.listView1.SelectedItems[0].SubItems[0].Text;

                foreach (v_itemlist item in stockiosList)
                {
                    if (item.商品名 == textShopname)
                        v_stockiositem = item;

                }
            }
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ischeckmunal = true;
            this.Close();

        }

    }
}
