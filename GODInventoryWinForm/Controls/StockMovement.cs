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
    public partial class StockMovement : Form
    {
        private List<MockEntity> manufacturerList;
        private List<t_warehouses> warehouseList;

        private BindingList<t_stockrec> stocklist;
        private List<t_genre> genreList;
        private BindingList<v_stockios> stockiosList;


        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;
        private t_itemlist itemlist;
        private BindingList<t_itemlist> Titemlist;
        public StockMovement()
        {
            InitializeComponent();
            stockiosList = new BindingList<v_stockios>();

            stocklist = new BindingList<t_stockrec>();
            Titemlist = new BindingList<t_itemlist>();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = stockiosList;
            InitializeDataSource();
        }

        private void InitializeDataSource() {

            using (var ctx = new GODDbContext())
            {                
                warehouseList = ctx.t_warehouses.ToList();
                genreList = ctx.t_genre.ToList();
            }

            this.genreComboBox.DisplayMember = "ジャンル名";
            this.genreComboBox.ValueMember = "idジャンル";
            this.genreComboBox.DataSource = genreList;

            this.manufacturerList = ManufactureRespository.ToList();
            this.manufacturerComboBox.DisplayMember = "FullName";
            this.manufacturerComboBox.ValueMember = "Id";
            this.manufacturerComboBox.DataSource = manufacturerList;

            this.fromBindingSource.DataSource = warehouseList;
            this.fromWarehouseComboBox.DisplayMember = "FullName";
            this.fromWarehouseComboBox.ValueMember = "Id";
            this.fromWarehouseComboBox.DataSource = fromBindingSource;

            this.toBindingSource.DataSource = warehouseList;
            this.toWarehouseComboBox1.DisplayMember = "FullName";
            this.toWarehouseComboBox1.ValueMember = "Id";
            this.toWarehouseComboBox1.DataSource = toBindingSource;

            this.fromStatusComboBox4.SelectedIndex = 0;
            this.toStatusComboBox.SelectedIndex = 0;
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            try
            {
                List<t_stockrec> changeList = new List<t_stockrec>();
                using (var ctx = new GODDbContext())
                {
                    var to_warehouse = this.toWarehouseComboBox1.Text;

                    foreach (var item in stockiosList)
                    {
                        stocklist = new BindingList<t_stockrec>();
                        if (item.qty > 0) { 
                            #region stockout 信息
                            var order = new t_stockrec();

                            order.日付 = this.stockOutDateTimePicker.Value;
                            order.元 = this.fromWarehouseComboBox.Text;
                            order.先 = this.toWarehouseComboBox1.Text;
                            order.納品書番号 = stockOutNumTextBox.Text;
                            order.事由 = this.toWarehouseComboBox1.Text+"へ移動";
                            //order.仓库 = comboBox1.Text;
                            order.区分 = StockIoEnum.出庫.ToString();
                            order.数量 = item.qty;
                            order.自社コード = item.自社コード;
                            order.状態 = this.fromStatusComboBox4.Text;
                            //order.客户 = item.客户;

                            changeList.Add(order);

                            #endregion


                            #region stockin 信息
                            order = new t_stockrec();
                            order.日付 = this.stockInDateTimePicker1.Value;
                            order.元 = this.fromWarehouseComboBox.Text;
                            order.先 = this.toWarehouseComboBox1.Text;
                            order.納品書番号 = stockInNumTextBox.Text;
                            order.事由 = this.fromWarehouseComboBox.Text + "から";
                            order.区分 = StockIoEnum.入庫.ToString();
                            order.自社コード = item.自社コード;
                           

                            order.数量 = item.qty;
                            order.状態 = this.toStatusComboBox.Text;
                            //order.客户 = item.客户;

                            changeList.Add(order);

                            #endregion

                        }    
                    }
                    if (changeList.Count > 0)
                    {

                        ctx.t_stockrec.AddRange(changeList);
                        
                        List<int> pids = new  List<int>();
                        foreach( var item in changeList){
                            pids.Add(item.自社コード);
                        }

                        OrderSqlHelper.UpdateStockState(ctx, pids);

                        ctx.SaveChanges();
                        this.stockiosList.Clear();
                       


                        MessageBox.Show(String.Format("Congratulations, You have {0} items added successfully!", changeList.Count));
                        BuildStockOutNum();
                        BuildStockInNum();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                
            }
        }


        private void btadd_Click(object sender, EventArgs e)
        {
            stockiosList.Clear();
            var genre_id = GetGenreId();
            var from_warehouse = this.fromWarehouseComboBox.Text;
            if (genre_id > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    var results = (from s in ctx.t_itemlist
                                   where s.ジャンル == (short)genre_id 
                                   select new v_stockios {商品コード=s.商品コード, 自社コード = s.自社コード, 規格 = s.規格, 商品名 = s.商品名 }).ToList();
                    for (int i = 0; i < results.Count; i++)
                    {
                        results[i].Id = i + 1;
                        stockiosList.Add(results[i]);
                    }
                }
            }

        }



        private void btclearzero_Click(object sender, EventArgs e)
        {
            foreach (var item in stockiosList)
            {
                item.qty = 0;
            }
            this.dataGridView1.Refresh();
        }

        private void StockMovement_Load(object sender, EventArgs e)
        {

        }

        private void BuildStockOutNum()
        {
            var selected_date = this.stockOutDateTimePicker.Value;
            var genre_id = GetGenreId();
            var stock_no = outBuildStockNum(genre_id, selected_date);
            this.stockOutNumTextBox.Text = stock_no;

        }

        private void BuildStockInNum() 
        {
            var selected_date = this.stockInDateTimePicker1.Value;
            var genre_id = GetGenreId();
            var stock_no = BuildStockNum(genre_id, selected_date);
            this.stockInNumTextBox.Text = stock_no;

        }

        private string BuildStockNum( int genre_id, DateTime selected_date)
        {
            string stock_no = "";
            if (genre_id > 0)
            {
                string sn = "";
                int count = 0;
                var startAt = selected_date.Date;
                var endAt = startAt.AddDays(1).Date;              
                using (var ctx = new GODDbContext())
                {
                    var results = from s in ctx.t_stockrec
                                  where s.日付 >= startAt && s.日付 < endAt
                                  group s by s.納品書番号 into g
                                  select g;
                    count = results.Count();
                    var warehouse = warehouseComboBox1();
                    if (warehouse > 0)
                    {
                        var shorname = warehouseList.Find(o => o.Id == Convert.ToInt32(warehouse));
                        if (shorname != null)
                            sn = shorname.ShortName;
                    }
                }

                stock_no = String.Format(sn + "-" + "{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);
               
            }
            return stock_no;
        }
        private string outBuildStockNum(int genre_id, DateTime selected_date)
        {
            string stock_no = "";
            if (genre_id > 0)
            {
                string sn = "";
                int count = 0;
                var startAt = selected_date.Date;
                var endAt = startAt.AddDays(1).Date;
                using (var ctx = new GODDbContext())
                {
                    var results = from s in ctx.t_stockrec
                                  where s.日付 >= startAt && s.日付 < endAt
                                  group s by s.納品書番号 into g
                                  select g;
                    count = results.Count();
                    var warehouse = warehouseComboBox2();
                    if (warehouse > 0)
                    {
                        var shorname = warehouseList.Find(o => o.Id == Convert.ToInt32(warehouse));
                        if (shorname != null)
                            sn = shorname.ShortName;
                    }
                }

                stock_no = String.Format(sn + "-" + "{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);

            }
            return stock_no;
        }

        private int warehouseComboBox1()
        {

            return ((this.toWarehouseComboBox1.SelectedIndex >= 0) ? (int)this.toWarehouseComboBox1.SelectedValue : 0);
        }
        private int warehouseComboBox2()
        {

            return ((this.fromWarehouseComboBox.SelectedIndex >= 0) ? (int)this.fromWarehouseComboBox.SelectedValue : 0);
        }
        private int GetGenreId()
        {

            return ((this.genreComboBox.SelectedIndex >= 0) ? (int)this.genreComboBox.SelectedValue : 0);
        }

        private void genreComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BuildStockOutNum();
            BuildStockInNum();
        }

        private void stockOutDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BuildStockOutNum();
        }

        private void stockInDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BuildStockInNum();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.stockiosList[e.RowIndex].qty = (int)cell.Value;
        }

        private void toWarehouseComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildStockInNum();
        }

        private void fromWarehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildStockOutNum();
            
        }

    }
}
