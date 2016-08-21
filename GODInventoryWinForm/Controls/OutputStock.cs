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
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class OutputStock : Form
    {
        private List<MockEntity> manufacturerList;
        private BindingList<v_stockios> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;
        public OutputStock()
        {
            InitializeComponent();


            stockiosList = new BindingList<v_stockios>();

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = stockiosList;

            InitializeDataSource();
        }
        private void InitializeDataSource()
        {

            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.ToList();
                warehouseList = ctx.t_warehouses.ToList();
            }
            this.genreComboBox.DisplayMember = "ジャンル名";
            this.genreComboBox.ValueMember = "idジャンル";
            this.genreComboBox.DataSource = genreList;


            this.manufacturerList = ManufactureRespository.ToList();
            this.manufacturerComboBox.DisplayMember = "FullName";
            this.manufacturerComboBox.ValueMember = "Id";
            this.manufacturerComboBox.DataSource = manufacturerList;


            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = warehouseList;

            this.stockStatusComboBox.SelectedIndex = 0;
            //BuildStockNO();
        }

        private void loadItemListButton_Click(object sender, EventArgs e)
        {
            stockiosList.Clear();
            var genre_id = GetGenreId();
            if (genre_id > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    var results = (from s in ctx.t_itemlist
                                   where s.ジャンル == (short)genre_id
                                   select new v_stockios { 自社コード = s.自社コード, 規格 = s.規格, 商品名 = s.商品名 }).ToList();
                    for (int i = 0; i < results.Count; i++)
                    {
                        results[i].Id = i + 1;
                        stockiosList.Add(results[i]);
                    }
                }
            }
        }
        private int GetGenreId()
        {

            return ((this.genreComboBox.SelectedIndex >= 0) ? (int)this.genreComboBox.SelectedValue : 0);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            foreach (var item in stockiosList)
            {
                item.qty = 0;
            }
            this.dataGridView1.Refresh();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<t_stockrec> receivedList = new List<t_stockrec>();
                foreach (var item in stockiosList)
                {
                    if (item.qty > 0)
                    {
                        var order = new t_stockrec();
                        order.日付 = orderCreatedAtDateTimePicker.Value;
                        order.元 = this.warehouseComboBox.Text;
                        order.先 = this.clientComboBox.Text;
                        order.納品書番号 = stockNOTextBox.Text;
                        order.数量 = item.qty;
                        order.区分 = StockIoEnum.出庫.ToString();
                        order.事由 = this.remarkTextBox1.Text;                   
                        order.自社コード = Convert.ToInt32(item.自社コード);
                        order.状態 = this.stockStatusComboBox.Text;
                        receivedList.Add(order);
                    }
                }
                if (receivedList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        ctx.t_stockrec.AddRange(receivedList);
                        ctx.SaveChanges();
                        this.stockiosList.Clear();
                    }
                    MessageBox.Show(String.Format("Congratulations, You have {0} items added successfully!", receivedList.Count));
                    // rebuild stock no, new stockrec created.
                    BuildStockNO();
                }
                else
                {
                    MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return;
            }
        }
        
        private void BuildStockNO()
        {
            var genre_id = GetGenreId();
            if (genre_id > 0)
            {


                int count = 0;
                var startAt = this.orderCreatedAtDateTimePicker.Value.Date;
                var endAt = startAt.AddDays(1).Date;
                using (var ctx = new GODDbContext())
                {
                    var results = from s in ctx.t_stockrec
                                  where s.日付 >= startAt && s.日付 < endAt
                                  group s by s.納品書番号 into g
                                  select g;

                    count = results.Count();
                }

                var stock_no = String.Format("GOD-{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);

                this.stockNOTextBox.Text = stock_no;
            }
            else
            {
                this.stockNOTextBox.Text = "";
            }
        }

        private void orderCreatedAtDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BuildStockNO();
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildStockNO();
        }

        #region MyRegion
        //public OutputStock()
        //{
        //    InitializeComponent();

        //    List<int> newcodemanufa = new List<int>();
        //    stocklist = new BindingList<t_stockrec>();
        //    Titemlist = new BindingList<t_itemlist>();

        //    using (var ctx = new GODDbContext())
        //    {
        //        t_manufacturersR = ctx.t_manufacturers.ToList();
        //        warehouseList = ctx.t_warehouses.ToList();
        //        t_genreR = ctx.t_genre.ToList();
        //    }
        //    foreach (t_manufacturers item in t_manufacturersR)
        //    {

        //        this.comboBox3.Items.Add(item.FullName);

        //    }
        //    foreach (t_genre item in t_genreR)
        //    {
        //        this.comboBox1.Items.Add(item.ジャンル名);
        //    }
        //    //foreach (t_warehouses item in warehouseList)
        //    {
        //        //this.storeComboBox.Items.Add(item.ShortName);
        //        OrderSqlHelper item12 = new OrderSqlHelper();

        //        string[] ll = item12.StrockReback();
        //        for (int j = 0; j < ll.Length; j++)
        //        {
        //            // this.storeComboBox.Items.Add(item.ShortName);
        //            this.storeComboBox.Items.Add(ll[j]);

        //        }
        //        string[] tt = item12.Strock_out();
        //        for (int j = 0; j < tt.Length; j++)
        //        {
        //            // this.storeComboBox.Items.Add(item.ShortName);
        //            this.comboBox2.Items.Add(tt[j]);
        //        }
        //    }
        //    this.dataGridView1.AutoGenerateColumns = false;
        //    this.dataGridView1.DataSource = Titemlist;
        //}

        //private void submitButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (t_itemlist item in Titemlist)
        //        {
        //            if (this.storeComboBox.Text == "" || storeComboBox.Text == "")
        //            {
        //                MessageBox.Show("仓库", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            order.日付 = orderCreatedAtDateTimePicker.Value;
        //            order.先 = storeComboBox.Text;
        //            order.元 = this.comboBox3.Text;
        //            order.納品書番号 = textBox4.Text;
        //            //
        //            order.事由 = comboBox2.Text;
        //            //order.仓库 = storeComboBox.Text;

        //            order.区分 = "出庫";
        //            order.自社コード = Convert.ToInt32(item.自社コード);
        //            order.状態 = "確定";
        //            stocklist.Add(order);
        //            if (stocklist.Count > 0)
        //            {
        //                using (var ctx = new GODDbContext())
        //                {
        //                    ctx.t_stockrec.AddRange(stocklist);
        //                    ctx.SaveChanges();
        //                    MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stocklist.Count));
        //                    stocklist.Clear();
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("" + ex);
        //        return;

        //        throw;
        //    }
        //}

        //private void btadd_Click(object sender, EventArgs e)
        //{

        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int count = 0;
        //    using (var ctx = new GODDbContext())
        //    {
        //        var results = from s in ctx.t_stockrec
        //                      where s.日付 == DateTime.Now
        //                      select s;

        //        count = results.Count();
        //    }
        //    var shops = this.t_genreR.Where(s => s.ジャンル名.ToString().StartsWith(comboBox1.Text.ToString())).ToList();

        //    this.textBox4.Text = this.storeComboBox.Text + "-" + DateTime.Now.ToString("yyyymmdd") + "-" + shops.First().idジャンル.ToString() + "-" + count + 1;
        //}

        //private void btadd_Click_1(object sender, EventArgs e)
        //{
        //    int id = 0;

        //    foreach (t_genre item in t_genreR)
        //    {
        //        if (item.ジャンル名 == comboBox1.Text)
        //            id = item.idジャンル;

        //    }
        //    if (Strock_CompanyCode == null)
        //    {
        //        Strock_CompanyCode = new Strock_CompanyCode(id);
        //        Strock_CompanyCode.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
        //    }
        //    if (Strock_CompanyCode == null)
        //    {
        //        Strock_CompanyCode = new Strock_CompanyCode(id);
        //    }
        //    Strock_CompanyCode.ShowDialog();


        //    Titemlist.Add(itemlist);
        //}
        //void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    order = new t_stockrec();

        //    if (sender is Strock_CompanyCode)
        //    {
        //        order.自社コード = Strock_CompanyCode.STATUS;
        //        itemlist = new t_itemlist();
        //        itemlist = Strock_CompanyCode.item;
        //        Strock_CompanyCode = null;


        //    }
        //}


        //private void cancelButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void OutputStock_Load(object sender, EventArgs e)
        //{

        //}

        #endregion
    }
}
