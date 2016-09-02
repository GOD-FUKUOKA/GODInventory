﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class OrderHistoryForm : Form
    {

        List<v_groupedorder> OrderList;
        SortableBindingList<v_groupedorder> OrderListBindingList;
        private List<t_shoplist> shopList;

        public OrderHistoryForm()
        {
            InitializeComponent();
            InitializeOrderData();


        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            var startAt = this.startDateTimePicker.Value.AddDays(-1).Date;
            var endAt = this.endDateTimePicker.Value.AddDays(1).Date;

            string xian = comboBox1.Text;

            string sql = "";

            if (radioButton2.Checked == true)
                if (radioButton3.Checked == true)//交货日
                    sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`納品日`< {0} AND o1.`納品日`> {1}   )
    order by o1.`発注日` ";
                else if (radioButton4.Checked == true)
                    sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`納品日`< {0} AND o1.`納品日`> {1}  AND o1.`発注日`> {2})
    order by o1.`発注日` ";
            if (radioButton1.Checked == true)//发货日
                if (radioButton3.Checked == true)
                    sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`出荷日`< {0} AND o1.`出荷日`> {1}  )
    order by o1.`発注日` ";
                else if (radioButton4.Checked == true)
                    sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`納品日`< {0} AND o1.`納品日`> {1}  AND o1.`発注日`> {2})
    order by o1.`発注日` ";



            using (var ctx = new GODDbContext())
            {
                if (radioButton3.Checked == true)
                    OrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, endAt, startAt).ToList();
                else if (radioButton4.Checked == true)
                    OrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, endAt, startAt, comboBox1.Text).ToList();
            }
            ApplyFilter();


            OrderListBindingList = new SortableBindingList<v_groupedorder>(OrderList);
            dataGridView1.DataSource = OrderListBindingList;


        }

        public int InitializeOrderData()
        {

            var startAt = this.startDateTimePicker.Value.AddDays(-1).Date;
            var endAt = this.endDateTimePicker.Value.AddDays(1).Date;
            startAt = DateTime.Now.AddDays(-30).Date;

            string sql = @"SELECT * FROM t_orderdata o1 WHERE ((  o1.`発注日`< {0} AND s.`発注日`> {1} )
    order by o1.発注日 ";
            sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`発注日`> {0} )
    order by o1.`発注日` ";
            using (var ctx = new GODDbContext())
            {

                //OrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, endAt, startAt).ToList();
                OrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, startAt).ToList();
                shopList = ctx.t_shoplist.ToList();

            }
            this.storeComboBox.DisplayMember = "店名";
            this.storeComboBox.ValueMember = "店番";
            this.storeComboBox.DataSource = shopList;


            var filtered = shopList.FindAll(s => s.県別 != null).Distinct().ToList();
            //  this.comboBox1.DataSource = filtered.;





            OrderListBindingList = new SortableBindingList<v_groupedorder>(OrderList);
            dataGridView1.DataSource = OrderListBindingList;

            return 0;
        }

        private void ApplyFilter()
        {
            string filter = "";
            if (this.storeCodeFilterTextBox3.Text.Length > 0)
            {
                filter += "(社内伝番=" + this.storeCodeFilterTextBox3.Text + ")";
            }
            if (this.storeCodeFilterTextBox3.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " or ";
                }
                filter += "(伝票番号=" + this.storeCodeFilterTextBox3.Text + ")";
            }



            this.bindingSource1.Filter = filter;

        }

        private void storeCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (storeCodeTextBox.Text.Trim().Length > 0)
            {
                int storeId = Convert.ToInt32(storeCodeTextBox.Text);
                if (storeId > 0)
                {
                    var shops = this.shopList.Where(s => s.店番.ToString().StartsWith(storeId.ToString())).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();


                        #region new

                        this.storeComboBox.SelectedValue = store.店番;

                        #endregion
                    }
                    else
                    {
                        errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeId));
                    }

                }
                else
                {
                    errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeCodeTextBox.Text));
                }
            }
        }

        private void storeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.storeComboBox.SelectedValue != null)
            {
                this.storeCodeTextBox.Text = this.storeComboBox.SelectedValue.ToString();
                InitializeOrderDataDF(this.storeCodeTextBox.Text);
            }
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public int InitializeOrderDataDF(string dianfan)
        {
            var startAt = DateTime.Now.AddDays(-30).Date;

            string sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`発注日`> {0}  AND o1.`店舗コード`={1})
    order by o1.`発注日`";
            using (var ctx = new GODDbContext())
            {
                OrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, startAt, dianfan).ToList();
            }
            OrderListBindingList = new SortableBindingList<v_groupedorder>(OrderList);
            dataGridView1.DataSource = OrderListBindingList;
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM t_orderdata o1 WHERE ( o1.`社内伝番`= {0}  or o1.`店舗コード`={0})
    order by o1.`発注日`";
            using (var ctx = new GODDbContext())
            {
                OrderList = ctx.Database.SqlQuery<v_groupedorder>(sql, storeCodeFilterTextBox3.Text).ToList();
            }
            OrderListBindingList = new SortableBindingList<v_groupedorder>(OrderList);
            dataGridView1.DataSource = OrderListBindingList;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                comboBox1.Visible = true;
            else
                comboBox1.Visible = false;

        }

    }
}
