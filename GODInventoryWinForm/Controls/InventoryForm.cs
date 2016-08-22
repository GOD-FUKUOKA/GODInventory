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

       
        private List<t_genre> genreList;


        //private t_itemlist itemlist;
        private List<t_itemlist> itemlist;
        private testingCC testingCC;

        public t_itemlist item;
        public ReceivedOrdersReportForm reportForm;

        private BindingList<v_stockcheck> stockcheckList;

        public InventoryForm()
        {
            InitializeComponent();

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
            this.stockcheckList.Clear();
            var warehouse = this.warehouseComboBox.Text;
            var genreId = Convert.ToInt16( this.genreComboBox.SelectedValue );
            var startDate = Properties.Settings.Default.InventoryStartAt.Date;
            var endDate = this.endDateTimePicker1.Value.AddDays(1).Date;
            using (var ctx = new GODDbContext())
            {
                int i = 0;
                string sql = @"SELECT i.`規格`,i.`商品名`, SUM(s.`数量`) as `数量`, s.`自社コード` FROM t_stockrec s
    INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = {0}
    WHERE (s.`先` = {1} and s.`状態`={2} and s.`日付`< {3} and s.`日付`> {4} )
    GROUP by s.`自社コード`;";
                var summaries = ctx.Database.SqlQuery<v_stockcheck>(sql, genreId, warehouse, StockIoProgressEnum.完了.ToString(), endDate, startDate).ToList();

                var summaries4plan = ctx.Database.SqlQuery<v_stockcheck>(sql, genreId, warehouse, StockIoProgressEnum.仮.ToString(), endDate, startDate).ToList();

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

        }


        private void btconfirm_Click(object sender, EventArgs e)
        {
            var warehouse = this.warehouseComboBox.Text;

            using (var ctx = new GODDbContext())
            {   
                List<t_stockrec> changes = new List<t_stockrec>();
                var genreId = Convert.ToInt16( this.genreComboBox.SelectedValue );
                var date = DateTime.Now;
                string stockNum = BuildStockNum(ctx, genreId, date);

                foreach (var item in stockcheckList)
                {
                    if( Convert.ToInt32( item.chaZhi ) > 0 ){

                        var s = new t_stockrec();
                        s.元 = warehouse;
                        s.先 = warehouse;
                        s.数量 = item.chaZhi;
                        s.自社コード = item.自社コード;
                        s.日付 = date;
                        s.区分 = StockIoEnum.入庫.ToString();
                        s.状態 = StockIoProgressEnum.完了.ToString();
                        s.事由 = StockIoClueEnum.清点库存.ToString();
                        s.納品書番号 = stockNum;
                        changes.Add(s);
                    }
                   
                }

                ctx.t_stockrec.AddRange(changes);
                ctx.SaveChanges();
                MessageBox.Show(String.Format("Congratulations, You have {0} items added successfully!", changes.Count));
                stockcheckList.Clear();

            }

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null)
            {
                int v = Convert.ToInt32(cell.Value);
                this.stockcheckList[e.RowIndex].qingDianShu = v;
                this.stockcheckList[e.RowIndex].chaZhi = v - this.stockcheckList[e.RowIndex].shiJiKuCunShu ;
                //this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.stockcheckList[e.RowIndex].chaZhi;

            }
            

            this.dataGridView1.Refresh();

        }

        private void btclear_zero_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < stockcheckList.Count; i++) {

                this.stockcheckList[i].qingDianShu = null;
                this.stockcheckList[i].chaZhi = null;
            }
            dataGridView1.Refresh();
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


        private string BuildStockNum(GODDbContext ctx, int genre_id, DateTime selectedDate)
        {

            var startAt = selectedDate.Date;
            var endAt = startAt.AddDays(1).Date;  

            var results = from s in ctx.t_stockrec
                          where s.日付 >= startAt && s.日付 < endAt
                          group s by s.納品書番号 into g
                          select g;

            int    count = results.Count();

            string stock_no = String.Format("GOD-{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);

           
            return stock_no;
        }

        private void btprint_Click_1(object sender, EventArgs e)
        {

        }
    }
}
