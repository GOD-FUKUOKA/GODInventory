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
    public partial class StockTransfer : Form
    {
        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private BindingList<t_stockrec> stocklist;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;
        private List<t_itemlist> t_itemlistR;
        private t_itemlist itemlist;
        private BindingList<t_itemlist> Titemlist;
        public StockTransfer()
        {
            InitializeComponent();
            List<int> newcodemanufa = new List<int>();
            stocklist = new BindingList<t_stockrec>();
            t_itemlistR = new List<t_itemlist>();
            Titemlist = new BindingList<t_itemlist>();

            using (var ctx = new GODDbContext())
            {
                t_manufacturersR = ctx.t_manufacturers.ToList();
                t_shippersR = ctx.t_shippers.ToList();
                t_genreR = ctx.t_genre.ToList();
            }
            foreach (t_manufacturers item in t_manufacturersR)
            {
                this.comboBox2.Items.Add(item.FullName);
            }
            foreach (t_genre item in t_genreR)
            {
                this.comboBox3.Items.Add(item.ジャンル名);
            }
            OrderSqlHelper item12 = new OrderSqlHelper();

            string[] ll = item12.StrockReback();
            for (int j = 0; j < ll.Length; j++)
            {

                this.storeComboBox.Items.Add(ll[j]);
                this.comboBox1.Items.Add(ll[j]);
            }
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = Titemlist;

        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (t_itemlist item in Titemlist)
                {
                    stocklist = new BindingList<t_stockrec>();

                    #region 取得信息
                    if (this.storeComboBox.Text == "" || storeComboBox.Text == "")
                    {
                        MessageBox.Show("仓库", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    order.日付 = orderCreatedAtDateTimePicker.Value;
                    order.元 = storeComboBox.Text;
                    order.先 = this.comboBox1.Text;
                    order.納品書番号 = textBox4.Text;
                    //order.出庫事由 = comboBox2.Text;
                    //order.仓库 = comboBox1.Text;
                    order.区分 = "出庫";
                    order.数量 = Convert.ToInt32(item.PT入数);
                    order.自社コード = Convert.ToInt32(item.自社コード);
                    order.状態 = "確定";

                    stocklist.Add(order);

                    #endregion
                    if (stocklist.Count > 0)
                    {
                        using (var ctx = new GODDbContext())
                        {
                            ctx.t_stockrec.AddRange(stocklist);
                            ctx.SaveChanges();
                            //MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stocklist.Count));
                            stocklist.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    #region MyRegion

                    stocklist = new BindingList<t_stockrec>();

                    #region 取得信息
                    if (this.comboBox2.Text == "" || comboBox2.Text == "")
                    {
                        MessageBox.Show("工場 ", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    order.日付 = dateTimePicker1.Value;
                    order.元 = storeComboBox.Text;
                    order.先 = this.comboBox1.Text;
                    order.納品書番号 = textBox3.Text;
                    //order.出庫事由 = comboBox2.Text;
                    //order.仓库 = comboBox1.Text;
                    order.区分 = "入庫";
                    order.自社コード = Convert.ToInt32(item.自社コード);
                    order.数量 = Convert.ToInt32(item.PT入数);
                    order.状態 = "確定";

                    stocklist.Add(order);

                    #endregion
                    if (stocklist.Count > 0)
                    {
                        using (var ctx = new GODDbContext())
                        {
                            ctx.t_stockrec.AddRange(stocklist);
                            ctx.SaveChanges();
                            MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stocklist.Count));
                            stocklist.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return;

                throw;
            }
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                var results = from s in ctx.t_stockrec
                              where s.日付 == DateTime.Now
                              select s;

                count = results.Count();
            }
            var shops = this.t_genreR.Where(s => s.ジャンル名.ToString().StartsWith(comboBox3.Text.ToString())).ToList();

            this.textBox4.Text = this.storeComboBox.Text + "-" + objToDateTime1(orderCreatedAtDateTimePicker.Text.ToString()).Replace("/", "") + "-" + shops.First().idジャンル.ToString() + "-" + count + 1;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            using (var ctx = new GODDbContext())
            {
                var results = from s in ctx.t_stockrec
                              where s.日付 == DateTime.Now
                              select s;
                count = results.Count();
            }
            var shops = this.t_genreR.Where(s => s.ジャンル名.ToString().StartsWith(comboBox3.Text.ToString())).ToList();
            this.textBox3.Text = this.comboBox1.Text + "-" + objToDateTime1(dateTimePicker1.Text.ToString()).Replace("/", "") + "-" + shops.First().idジャンル.ToString() + "-" + count + 1;

        }
        public static string objToDateTime1<T>(T t)
        {
            string strResult = "";
            object obj = t;

            try
            {
                if (obj != null)
                {
                    strResult = DateTime.FromOADate((double)obj).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                try
                {
                    strResult = Convert.ToDateTime(obj.ToString()).ToString("yyyy/MM/dd");
                }
                catch
                {
                    try
                    {
                        if (obj.ToString().Length == 8)
                        {
                            strResult = DateTime.Parse(obj.ToString().Substring(4, 4) + "-" +
                                                       obj.ToString().Substring(0, 2) + "-" +
                                                       obj.ToString().Substring(2, 2)).ToString("yyyy/MM/dd");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return strResult;
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            int id = 0;

            foreach (t_genre item in t_genreR)
            {
                if (item.ジャンル名 == comboBox3.Text)
                    id = item.idジャンル;
            }
            if (Strock_CompanyCode == null)
            {
                Strock_CompanyCode = new Strock_CompanyCode(id);
                Strock_CompanyCode.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (Strock_CompanyCode == null)
            {
                Strock_CompanyCode = new Strock_CompanyCode(id);
            }


            Strock_CompanyCode.ShowDialog();

            Titemlist.Add(itemlist);

        }

        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            order = new t_stockrec();

            if (sender is Strock_CompanyCode)
            {
                itemlist = new t_itemlist();
                itemlist = Strock_CompanyCode.item;

                Strock_CompanyCode = null;
            }
        }


        private void btclearzero_Click(object sender, EventArgs e)
        {

        }

    }
}