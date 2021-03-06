﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory;

namespace GODInventoryWinForm.Controls
{
    public partial class CopyofInputStock : Form
    {
        private List<t_manufacturers> manufacturerList;
        private BindingList<v_stockios> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;
        private List<t_customers> customersList;
        private List<t_itemlist> itemList;

        public CopyofInputStock()
        {
            InitializeComponent();

            stockiosList = new BindingList<v_stockios>();

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = stockiosList;

            InitializeDataSource();

            //http://stackoverflow.com/questions/2653153/c-sharp-winforms-vertical-alignment-for-textbox-etc

        }

        private void InitializeDataSource()
        {

            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.OrderBy(o => o.Position).ToList();
                warehouseList = ctx.t_warehouses.ToList();
                manufacturerList = ctx.t_manufacturers.OrderBy(o => o.Position).ToList();
                customersList = ctx.t_customers.ToList();
                itemList = ctx.t_itemlist.ToList();
            }
            this.genreComboBox.DisplayMember = "ジャンル名";
            this.genreComboBox.ValueMember = "idジャンル";

            this.genreComboBox.DataSource = genreList;

            //this.manufacturerList = ManufactureRespository.ToList();
            this.manufacturerComboBox.DisplayMember = "FullName";
            this.manufacturerComboBox.ValueMember = "Id";
            this.manufacturerComboBox.DataSource = manufacturerList;


            this.warehouseComboBox.DisplayMember = "FullName";
            this.warehouseComboBox.ValueMember = "Id";
            this.warehouseComboBox.DataSource = warehouseList;

            this.stockStatusComboBox.SelectedIndex = 0;
            this.clientComboBox.SelectedIndex = 0;
            this.remarkTextBox1.SelectedIndex = 0;

            this.clientComboBox.DisplayMember = "FullName";
            this.clientComboBox.ValueMember = "Id";
            this.clientComboBox.DataSource = customersList;

            //BuildStockNO();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            List<t_stockrec> receivedList = new List<t_stockrec>();
            foreach (var item in stockiosList)
            {
                if (item.qty > 0)
                {
                    var order = new t_stockrec();

                    order.日付 = orderCreatedAtDateTimePicker.Value;
                    order.先 = this.warehouseComboBox.Text;

                    order.元 = this.manufacturerComboBox.Text;
                    order.工場 = this.manufacturerComboBox.Text;
                    order.納品書番号 = stockNOTextBox.Text;

                    order.数量 = item.qty;
                    order.区分 = StockIoEnum.入庫.ToString();
                    order.事由 = this.remarkTextBox1.Text;
                    //order.仓库 = storeComboBox.Text;
                    order.自社コード = Convert.ToInt32(item.自社コード);
                    order.状態 = this.stockStatusComboBox.Text;
                    order.客 = this.clientComboBox.Text;

                    receivedList.Add(order);

                }


            }
            if (receivedList.Count > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    ctx.t_stockrec.AddRange(receivedList);
                    List<int> pids = new List<int>();
                    foreach (var item in receivedList)
                    {
                        pids.Add(item.自社コード);
                    }
                    // save stockrec before update stock state
                    ctx.SaveChanges();

                    OrderSqlHelper.UpdateStockState(ctx, receivedList);


                    this.stockiosList.Clear();
                }
                MessageBox.Show(String.Format(" {0}種類商品入庫登録できました", receivedList.Count));
                // rebuild stock no, new stockrec created.
                BuildStockNO();
            }
            else
            {
                MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //this.bindingSource1.Filter = String.Format( "genreId={0}", this.genreComboBox.SelectedValue);

            var filtered = manufacturerList.FindAll(s => s.genreId == Convert.ToInt32(this.genreComboBox.SelectedValue));
            if (filtered.Count > 0)
            {
                this.manufacturerComboBox.DataSource = filtered;
            }
            else
            {
                this.manufacturerComboBox.DataSource = manufacturerList;

            }
            BuildStockNO();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BuildStockNO()
        {
            var genre_id = GetGenreId();
            if (genre_id > 0)
            {

                string sn = "";
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
                    foreach (var grouped in results)
                    {
                        var s = grouped.Key.Split('-').Last();
                        var i = Int32.Parse(s);
                        if (count < i)
                        {
                            count = i;
                        }
                    }
                    var warehouse = warehouseComboBox1();
                    if (warehouse > 0)
                    {
                        var shorname = warehouseList.Find(o => o.Id == Convert.ToInt32(warehouse));
                        if (shorname != null)
                            sn = shorname.ShortName;
                    }
                }

                var stock_no = String.Format(sn + "-" + "{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);
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
                                   orderby s.順番
                                   select new v_stockios { 自社コード = s.自社コード, 規格 = s.規格, 商品名 = s.商品名, 順番 = s.順番 }).ToList();
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

            return ((this.genreComboBox.SelectedIndex >= 0) ? Convert.ToInt32(this.genreComboBox.SelectedValue) : 0);
        }
        private int warehouseComboBox1()
        {

            return ((this.warehouseComboBox.SelectedIndex >= 0) ? (int)this.warehouseComboBox.SelectedValue : 0);
        }
        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            foreach (var item in stockiosList)
            {
                item.qty = 0;
            }
            this.dataGridView1.Refresh();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.stockiosList[e.RowIndex].qty = (int)cell.Value;
        }

        private void warehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildStockNO();
        }

        private void remarkTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(qtyTextBox.Text);
            int code = Convert.ToInt32(codeTextBox.Text);
            var dd = ManufactureRespository.CodeDict.ToList();
            // factory_code : product_code
            KeyValuePair<int, int> pair = dd.FirstOrDefault(o => o.Key == code);

            if (pair.Value > 0)
            {
                for (int i = 0; i < stockiosList.Count; i++)
                {
                    if (stockiosList[i].自社コード == pair.Value)
                    {
                        stockiosList[i].qty += qty;
                        break;
                    }
                }
                codeTextBox.Text = "";
                qtyTextBox.Text = "";
                this.ActiveControl = codeTextBox;
                this.dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show(String.Format("工場コード{0}の該当商品は見つかりません。", code));
            }

            //  var isAllManufacturerSelected = (Convert.ToInt32(codeComboBox.Text) == ManufactureRespository.CodeDict);

        }
    }
}
