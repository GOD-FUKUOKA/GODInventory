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
using GODInventory;

namespace GODInventoryWinForm.Controls
{
    public partial class InventoryForm : Form
    {
        private List<t_warehouses> warehouseList;
        private List<t_manufacturers> manufacturerList;


        private List<t_genre> genreList;


        private List<t_itemlist> itemList;

        public t_itemlist item;
        public ReceivedOrdersReportForm reportForm;
        private List<v_stockcheck> NewstockcheckList = null;

        private BindingList<v_stockcheck> stockcheckList;

        public InventoryForm()
        {
            InitializeComponent();

            this.stockcheckList = new BindingList<v_stockcheck>();

            dataGridView1.AutoGenerateColumns = false;

            InitializeDataSource();
        }

        private void InitializeDataSource()
        {

            using (var ctx = new GODDbContext())
            {
                genreList = ctx.t_genre.OrderBy(o => o.Position).ToList();
                manufacturerList = ctx.t_manufacturers.OrderBy(o => o.Position).ToList();
                warehouseList = ctx.t_warehouses.ToList();

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

            dataGridView1.DataSource = stockcheckList;
        }

        private void btfind_Click(object sender, EventArgs e)
        {
            this.stockcheckList.Clear();
            string warehousename = this.warehouseComboBox.Text;
            var warehouse = warehouseList.Find( w=> w.FullName == warehousename );
            var genreId = Convert.ToInt16(this.genreComboBox.SelectedValue);
            var startDate = Properties.Settings.Default.InventoryStartAt.Date;
            var endDate = this.endDateTimePicker1.Value.AddDays(1).Date;
            using (var ctx = new GODDbContext())
            {
                int i = 0;
                #region 取得待处理订单

                string sql = @"SELECT i.`規格`,i.`商品名`, SUM(s.`数量`) as `数量`, s.`自社コード` FROM t_stockrec s
                    INNER JOIN t_itemlist i on i.`自社コード` = s.`自社コード` and i.ジャンル = {0}
                    WHERE (((s.`元` = {1} AND s.`区分` = '出庫') OR (s.`先` = {1} AND s.`区分` = '入庫')  ) AND s.`状態`={2} AND s.`日付`< {3} AND s.`日付`> {4} )
                    GROUP by s.`自社コード`;";
                //未転送

                //string sql2 = String.Format( "SELECT `自社コード`, SUM(o.`実際出荷数量`) FROM t_orderdata o WHERE o.`Status`={0} GROUP by o.`自社コード`;", (int)OrderStatus.Pending);
                var pendingOrders = (from o in ctx.t_orderdata
                                      where o.Status == OrderStatus.Pending
                                     group o by new { 自社コード = o.自社コード, warehousename = o.warehousename } into g
                                     select new { 自社コード = g.Key.自社コード, warehousename = g.Key.warehousename, 数量 = g.Sum(o => o.実際出荷数量) }).ToList();

                
                var notifiedOrders = (from o in ctx.t_orderdata
                                     where o.Status == OrderStatus.NotifyShipper ||  o.Status == OrderStatus.WaitToShip
                                      group o by new { 自社コード = o.自社コード, warehousename = o.warehousename } into g
                                      select new { 自社コード = g.Key.自社コード, warehousename = g.Key.warehousename, 数量 = g.Sum(o => o.実際出荷数量) }).ToList();

                var summaries = ctx.Database.SqlQuery<v_stockcheck>(sql, genreId, warehousename, StockIoProgressEnum.完了.ToString(), endDate, startDate).ToList();

                var summaries4plan = ctx.Database.SqlQuery<v_stockcheck>(sql, genreId, warehousename, StockIoProgressEnum.仮.ToString(), endDate, startDate).ToList();

                #endregion


                //itemList = ctx.t_itemlist.ToList();
                
                NewstockcheckList = (from p in ctx.t_itemlist
                                     where p.ジャンル == genreId
                                     select new v_stockcheck
                             {
                                 規格 = p.規格,
                                 自社コード = p.自社コード,
                                 商品名 = p.商品名,
                                 順番 = p.順番,
                             }).ToList();
                //mark 20181024
                NewstockcheckList = NewstockcheckList.OrderBy(o => o.順番).ToList();
                foreach (var stockcheck in NewstockcheckList)
                {

                    stockcheck.Id = ++i;

                    var summary = summaries.Find(s => s.自社コード == stockcheck.自社コード);
                    if (summary != null)
                    {
                        //应有库存数
                        stockcheck.yingYouKuCunShu = Convert.ToInt32(summary.数量);
                    }

                    var item4plan1 = summaries4plan.Find(s => s.自社コード == stockcheck.自社コード);
                    if (item4plan1 != null)
                    {
                        //计划在库数
                        stockcheck.jiHuaRuCunShu = Convert.ToInt32(item4plan1.数量);
                    }

                    var order = notifiedOrders.Find(s => s.自社コード == stockcheck.自社コード && s.warehousename == warehouse.FullName);
                    if (order != null) 
                    {
                        //待出库数
                        stockcheck.daiFaHuoShu = order.数量;                    
                    }

                    var order2 = pendingOrders.Find(s => s.自社コード == stockcheck.自社コード && s.warehousename == warehouse.FullName);
                    if (order2 != null)
                    {
                        //未転送
                        stockcheck.weiChuanSong = order2.数量;
                    }

                    // 实际在库数
                    stockcheck.shiJiKuCunShu = stockcheck.yingYouKuCunShu + stockcheck.daiFaHuoShu;                
                    stockcheckList.Add(stockcheck);
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
                var genreId = Convert.ToInt16(this.genreComboBox.SelectedValue);
                var warehousename = GetWarehouseShortName();
                var date = this.endDateTimePicker1.Value;
                string stockNum = BuildStockNum(ctx, genreId, warehousename, date);

                foreach (var item in stockcheckList)
                {
                    if (Convert.ToInt32(item.chaZhi) != 0)
                    {

                        var s = new t_stockrec();
                        s.元 = warehouse;
                        s.先 = warehouse;
                        s.数量 = item.chaZhi;
                        s.自社コード = item.自社コード;
                        s.日付 = date;
                        s.区分 = StockIoEnum.入庫.ToString();
                        s.状態 = StockIoProgressEnum.完了.ToString();
                        s.事由 = StockIoClueEnum.棚卸.ToString();
                        s.納品書番号 = stockNum;
                        s.工場 = manufacturerComboBox.Text;
                        changes.Add(s);
                    }

                }

                ctx.t_stockrec.AddRange(changes);
                ctx.SaveChanges();
                OrderSqlHelper.UpdateStockState(ctx, changes);

                MessageBox.Show(String.Format("{0} 件在庫合わせしました!", changes.Count));
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
                this.stockcheckList[e.RowIndex].chaZhi = v - this.stockcheckList[e.RowIndex].shiJiKuCunShu;
                //this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.stockcheckList[e.RowIndex].chaZhi;

            }


            this.dataGridView1.Refresh();

        }

        private void btclear_zero_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < stockcheckList.Count; i++)
            {

                this.stockcheckList[i].qingDianShu = null;
                this.stockcheckList[i].chaZhi = 0;
            }
            dataGridView1.Refresh();
        }

       

        private string BuildStockNum(GODDbContext ctx, int genre_id, string warehousename, DateTime selectedDate)
        {

            var startAt = selectedDate.Date;
            var endAt = startAt.AddDays(1).Date;

            var results = from s in ctx.t_stockrec
                          where s.日付 >= startAt && s.日付 < endAt
                          group s by s.納品書番号 into g
                          select g;
            int count = results.Count();

            string stock_no = String.Format(warehousename + "-" + "{0:yyyyMMdd}-{1:D2}-{2:D2}", startAt, genre_id, count + 1);

            return stock_no;
        }

        private string GetWarehouseShortName()
        {
            string shortName = "GOD";
            int warehouseId = ((this.warehouseComboBox.SelectedIndex >= 0) ? (int)this.warehouseComboBox.SelectedValue : 0);

            if (warehouseId > 0)
            {
                var wharehouse = warehouseList.Find(o => o.Id == warehouseId);                
                shortName = wharehouse.ShortName;
            }
            return shortName;
        }

        private void btprint_Click_1(object sender, EventArgs e)
        {

        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtered = manufacturerList.FindAll(s => s.genreId == (int)this.genreComboBox.SelectedValue);
            if (filtered.Count > 0)
            {
                this.manufacturerComboBox.DataSource = filtered;
            }
            else
            {
                this.manufacturerComboBox.DataSource = manufacturerList;

            }
        }

        private void manufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
