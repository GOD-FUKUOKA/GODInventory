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
    public partial class InventoryForm : Form
    {
        private List<MockEntity> manufacturerList;
        private List<t_warehouses> warehouseList;

        private BindingList<t_stockrec> stocklist;
        private List<t_genre> genreList;

        private t_stockrec order;
        //private t_itemlist itemlist;
        private BindingList<t_itemlist> Titemlist;
        private List<t_itemlist> itemlist;
        private testingCC testingCC;

        public t_itemlist item;
        public ReceivedOrdersReportForm reportForm;

        private BindingList<v_stockcheck> stockcheckList;

        public InventoryForm()
        {
            InitializeComponent();

            stocklist = new BindingList<t_stockrec>();
            Titemlist = new BindingList<t_itemlist>();
            this.stockcheckList = new BindingList<v_stockcheck>();

            dataGridView1.AutoGenerateColumns = false;
        
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

            dataGridView1.DataSource = stockcheckList;
        }

        private void btfind_Click(object sender, EventArgs e)
        {
            var warehouse = this.warehouseComboBox.Text;
            var genreId = Convert.ToInt16( this.genreComboBox.SelectedValue );
            var endDate = this.endDateTimePicker1.Value;
            using (var ctx = new GODDbContext())
            {
                int i = 0;
                string sql = @"SELECT i.`規格`,i.`商品名`, SUM(s.`数量`) as `数量`,s.id,s.`自社コード` FROM t_stockrec s
    INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = {0}
    WHERE (s.`先` = {1} and s.`状態`={2} and s.`日付`<= {3})
    GROUP by s.`自社コード`;";
                var summaries = ctx.Database.SqlQuery<v_stockcheck>(sql, genreId, warehouse, StockIoEnum.完了.ToString(), endDate).ToList();

                var summaries4plan = ctx.Database.SqlQuery<v_stockcheck>(sql, genreId, warehouse, StockIoEnum.仮.ToString(), endDate).ToList();

                //stockcheckList = (from a in ctx.t_stockrec
                //                 where a.先 == warehouse && a.状態== StockIoEnum.完了.ToString()
                //                 group a by a.自社コード into b
                //                 select new v_stockcheck
                //         {
                //             自社コード = b.Key,
                //            数量 = b.Sum(c => c.数量),                           
                //        }).ToList();

                foreach (var item in summaries)
                {
                    i++;

                    item.Id = i;
                    item.yingYouKuCunShu = Convert.ToInt32( item.数量 ); 
                    // TODO daiFaHuoShu
                    item.daiFaHuoShu = 0;
                    item.shiJiKuCunShu = item.yingYouKuCunShu + item.daiFaHuoShu;

                    var item4plan = summaries4plan.Find(s => s.自社コード == item.自社コード);
                    if (item4plan != null)
                    {
                        item.jiHuaRuCunShu = Convert.ToInt32(item4plan.数量);
                    }
                    stockcheckList.Add(item);
                }
               
            }
           
        }
        private void ApplyFilter()
        {
        }

        private void btprint_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                var edidata = rows[0].DataBoundItem as t_itemlist;
                var orders = OrderSqlHelper.ASNstockrecDataListByMid(entityDataSource1, edidata.ジャンル);

                reportForm.ItemEnities = orders;
                reportForm.InitializeItemEnitiesDataSource();
                reportForm.ShowDialog();
                InitializeEdiData();
            }



        }
        private void InitializeEdiData()
        {
            int id = 0;

            foreach (t_genre item in this.genreList)
            {
                if (item.ジャンル名 == genreComboBox.Text)
                    id = item.idジャンル;
            }
            Titemlist = new BindingList<t_itemlist>();

            using (var ctx = new GODDbContext())
            {
                itemlist = ctx.t_itemlist.ToList();
            }
            var locations = this.itemlist.Where(l => l.ジャンル == id).ToList();
            locations = this.itemlist.Where(l => l.ジャンル == id).ToList();
            this.bindingSource2.DataSource = locations;
            dataGridView1.DataSource = this.bindingSource2;

        }

        private void btconfirm_Click(object sender, EventArgs e)
        {
            foreach (v_stockcheck item in stockcheckList)
            {

                if (stockcheckList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        ctx.t_stockrec.AddRange(stocklist);
                        ctx.SaveChanges();
                        MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", stockcheckList.Count));
                        stockcheckList.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (testingCC == null)
            {
                testingCC = new testingCC();
                testingCC.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            }
            if (testingCC == null)
            {
                testingCC = new testingCC();
            }
            testingCC.ShowDialog();

            #endregion
        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is testingCC)
            {
                testingCC = null;
            }
        }
    }
}
