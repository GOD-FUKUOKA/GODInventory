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
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class InputStock : Form
    {
        private List<MockEntity> manufacturerList;
        private BindingList<v_stockios> stockiosList;
        private List<t_genre> genreList;
        private List<t_warehouses> warehouseList;


        public InputStock()
        {
            InitializeComponent();

            stockiosList = new BindingList<v_stockios>();
                     
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = stockiosList;

            InitializeDataSource();
        }

        private void InitializeDataSource() {

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
            this.clientComboBox.SelectedIndex = 0;
            //BuildStockNO();
        }
     
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<t_stockrec> receivedList = new List<t_stockrec>();
                foreach (var item in stockiosList)
                {
                    if (item.qty > 0) {
                        var order = new t_stockrec();

                        order.日付 = orderCreatedAtDateTimePicker.Value;
                        order.先 = manufacturerComboBox.Text;

                        order.元 = this.warehouseComboBox.Text;
                        order.納品書番号 = stockNOTextBox.Text;

                        order.数量 = item.qty;
                        order.区分 = "入庫";
                        order.事由 = this.remarkTextBox1.Text;
                        //order.仓库 = storeComboBox.Text;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            BuildStockNO();
           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BuildStockNO() {
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
            else {
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
                                   select new v_stockios { 自社コード = s.自社コード, 規格 = s.規格, 商品名 = s.商品名 }).ToList();
                    for (int i = 0;i< results.Count; i++) { 
                       results[i].Id = i+1;                       
                       stockiosList.Add(results[i]);
                    }
                }
            }
        }


        private int GetGenreId(){
            
           return ((this.genreComboBox.SelectedIndex >= 0) ? (int)this.genreComboBox.SelectedValue : 0 );
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
    }
}
