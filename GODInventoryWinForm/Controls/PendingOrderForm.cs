using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    using GODInventory.MyLinq;
    using GODInventory.ViewModel;
    using MySql.Data.MySqlClient;
    using System.Data.SqlClient;

    public partial class PendingOrderForm : Form
    {
        public Size ParentContainerSize { get; set; }
        int ErCiZhiPinId { get; set; }

        //  [c1_r1_changed=> new_value,c1_r1=> original_value] ]
        private Hashtable datagrid_changes = null;
        private List<t_stockstate> stockstates;
        private List<v_shipper> shipperList;
        List<t_orderdata> Findorderdataresults;
        private BindingList<v_stockios> stockiosList;
        int RowRemark = 0;
        int cloumn = 0;

        private IBindingList pendingOrderIBindList;
        private List<v_pendingorder> pendingOrderList;
        private SortableBindingList<v_pendingorder> sortablePendingOrderList;
        private List<v_pendingorder> ecOrderList;
        private List<v_pendingorder> shipperOrderList;


        public PendingOrderForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            this.datagrid_changes = new Hashtable();
            this.pendingOrderList = new List<v_pendingorder>();


            var ctx = entityDataSource1.DbContext as GODDbContext;
            this.stockstates = ctx.t_stockstate.Select(s => s).ToList();

            //shipperList = (from s in ctx.t_shoplist
            //         group s by s.配送担当 into g
            //               select new v_shipper { ShortName = g.Key }).ToList();

            var genre = (from g in ctx.t_genre
                         where g.ジャンル名 == "二次製品"
                         select g).FirstOrDefault();
            ErCiZhiPinId = (genre != null ? genre.idジャンル : 0);

            //InitializePager();

            InitializeRCList();

            //丸健

            //物流

        }

 

        #region Pager Methods

        public void InitializePager()
        {
            this.pager1.PageCurrent = 1; //当前页为第一页   
            this.pager1.PageSize = 5000; //页数   
            this.pager1.Bind();
        }

        #endregion

        private void redundantButton_Click(object sender, EventArgs e)
        {


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                IEnumerable<int> orderIds = GetChangedOrderIds();
                List<v_pendingorder> orders = GetDataGridViewBoundOrders();

                if (orderIds.Count() > 0)
                {
                    foreach (var id in orderIds.Distinct())
                    {
                        var pendingorder = orders.Find(o => o.id受注データ == id);
                        t_orderdata order = ctx.t_orderdata.Find(pendingorder.id受注データ);
                        //需要修改的字段为: “口数” “发注数量” “担当” “形态”
                        order.実際出荷数量 = pendingorder.実際出荷数量;
                        order.納品口数 = pendingorder.納品口数;
                        order.重量 = pendingorder.重量;
                        order.発注形態名称漢字 = pendingorder.発注形態名称漢字;
                        order.実際配送担当 = pendingorder.実際配送担当;
                        order.備考 = pendingorder.備考;
                        order.納品指示 = pendingorder.納品指示;

                    }
                    ctx.SaveChanges();
                    pager1.Bind();
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            IEnumerable<int> ids = GetChangedOrderIds();
            if (ids.Count() > 0)
            {
                pager1.Bind();
            }

        }


        private void dataGridView1_Layout(object sender, LayoutEventArgs e)
        {
            //Console.WriteLine(" yes, Layout is called...");
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Console.WriteLine(" yes, DataBindingComplete is called...");
        }


        private int GetDatagridRowCount()
        {
            return dataGridView1.RowCount;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                try
                {
                    if (datagrid_changes.ContainsKey(e.RowIndex))//if (dgrSingle.Cells["列名"].Value.ToString().Contains("比较值"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
            string cellKey = GetCellKey( e.RowIndex, e.ColumnIndex);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            string cellKey = GetCellKey( e.RowIndex, e.ColumnIndex);
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);
            var new_cell_value = cell.Value;
            var original_cell_value = datagrid_changes[cellKey];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                datagrid_changes.Remove(cellChangedKey);
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                datagrid_changes[cellChangedKey] = new_cell_value;
            }
            else
            {
                datagrid_changes.Remove(cellChangedKey);
            }
            //実際出荷数量修改
            if (実際出荷数量Column.Index == e.ColumnIndex)
            {
                var order = cell.OwningRow.DataBoundItem as v_pendingorder;
                order.実際出荷数量 = (int)cell.Value;
                order.納品口数 = (int)order.実際出荷数量 / order.最小発注単位数量;
            }


            if (納品口数Column.Index == e.ColumnIndex)
            {
                var order = cell.OwningRow.DataBoundItem as v_pendingorder;
                order.納品口数 = (int)cell.Value;
                order.実際出荷数量 = (int)order.納品口数 * order.最小発注単位数量;
            }

        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //出荷日,納品日,受注日,店舗コード,店名,伝票番号,口数,品名漢字,規格名漢字,発注数量,実際配送担当,県別,キャンセル,ダブリ,一旦保留
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);

            if (datagrid_changes.ContainsKey(cellChangedKey))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private void ordersTabPage_Click(object sender, EventArgs e)
        {

        }

        #region 初始化数据

        private int InitializeDataSource(string shipper = "不限", string genre = "不限", string product = "不限", string stockState = "不限")
        {
            this.datagrid_changes.Clear();
            this.pendingOrderList.Clear();

            var cq = OrderSqlHelper.PendingOrderQuery(entityDataSource1);
            var count = cq.Count();

            if (count > 0)
            {

                //var q = OrderSqlHelper.PendingOrderQueryEx(entityDataSource1);
                //// 分页

                //if (pager1.PageCurrent > 1)
                //{
                //    q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
                //}
                //q = q.Take(pager1.OffSet(pager1.PageCurrent));

                //// create BindingList (sortable/filterable)
                // pendingOrderIBindList = entityDataSource1.CreateView(q);
                ////拷贝 pendingOrderIBindList 中所有数据 到 pendingOrderList， pendingOrderIBindList 会因过滤条件不同，产生不同结果集
                //foreach (var o in pendingOrderIBindList)
                //{
                //    pendingOrderList.Add(o as v_pendingorder);
                //}
                string sql = @" SELECT o.*, g.`ジャンル名` as `GenreName`, k.`在庫数` as `在庫数`  from t_orderdata o
INNER JOIN t_genre g  on o.ジャンル = g.idジャンル
LEFT JOIN t_stockstate k on  o.自社コード = k.自社コード AND  o.実際配送担当 = k.ShipperName 
WHERE o.Status ={0}
ORDER BY o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号 LIMIT {1} OFFSET {2};";


                // create BindingList (sortable/filterable)
                int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
                pendingOrderList = entityDataSource1.DbContext.Database.SqlQuery<v_pendingorder>(sql, OrderStatus.Pending, pager1.PageSize, offset).ToList();

                UpdateStockState(pendingOrderList);

                sortablePendingOrderList = new SortableBindingList<v_pendingorder>(pendingOrderList);
            }
            else {
                pendingOrderIBindList = null;
                sortablePendingOrderList = null;
            }


            InitializeOrderData(shipper, genre, product, stockState);

            return count;
        }

        private int InitializeOrderData(string shipper, string genre, string product, string stockState)
        {
            this.bindingSource1.DataSource = null;
            // 记录DataGridView改变数据          
            //sortablePendingOrderList = new SortableBindingList<v_pendingorder>( orders );

            this.bindingSource1.DataSource = sortablePendingOrderList;

            dataGridView1.DataSource = this.bindingSource1;

            if (pendingOrderList.Count > 0)
            {
                //var shops = pendingOrderList.Select(s => new MockEntity { Id = s.id受注データ, FullName = s.実際配送担当 }).Distinct().ToList();
                //shops.Insert(0, new MockEntity { Id = 0, FullName = "不限" });
                //this.DanDangComboBox.DisplayMember = "FullName";
                //this.DanDangComboBox.ValueMember = "Id";
                //this.DanDangComboBox.DataSource = shops;

                // 担当
                var counties = pendingOrderList.Select(s => new MockEntity { ShortName = s.実際配送担当, FullName = s.実際配送担当 }).Distinct().ToList();
                counties.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                this.DanDangComboBox.DisplayMember = "FullName";
                this.DanDangComboBox.ValueMember = "ShortName";
                this.DanDangComboBox.DataSource = counties;

                this.DanDangComboBox.Text = shipper;
                this.genreComboBox.Text = genre;
                this.productComboBox.Text = product;
                // PageEvent 时, stockState 在初始化为 “”， 需设置为 “不限”
                this.ZKZTcomboBox3.Text = (stockState.Length ==0 ? "不限" : stockState);
                //// 品名漢字
                //var PMHZ = pendingOrderList.Select(s => new MockEntity {Id = s.自社コード, TaxonId = s.ジャンル, ShortName = s.品名漢字, FullName = s.品名漢字 }).Distinct().ToList();
                //PMHZ.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                //this.PMHZCombox.DisplayMember = "FullName";
                //this.PMHZCombox.ValueMember = "Id";
                //this.PMHZCombox.DataSource = PMHZ;

                //// GenreName
                //var GenreName = pendingOrderList.Select(s => new MockEntity { Id = s.ジャンル, ShortName = s.GenreName, FullName = s.GenreName }).Distinct().ToList();
                //GenreName.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                //this.GenreNamecomboBox.DisplayMember = "FullName";
                //this.GenreNamecomboBox.ValueMember = "Id";
                //this.GenreNamecomboBox.DataSource = GenreName;

                // 在庫状態
                //var ZKZT = pendingOrderList.Select(s => new MockEntity { ShortName = s.在庫状態, FullName = s.在庫状態 }).Distinct().ToList();
                //ZKZT.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                //this.ZKZTcomboBox3.DisplayMember = "FullName";
                //this.ZKZTcomboBox3.ValueMember = "ShortName";
                //this.ZKZTcomboBox3.DataSource = ZKZT;
            }
           

            return 0;
        }


        private void InitializeRCList()
        {
            // 為了兼容 RollbackOrder， ecOrderList is v_penddingorder
            var q = OrderSqlHelper.ECWithoutCodeOrderQuery(this.entityDataSource1, ErCiZhiPinId);
            string sql = "SELECT MAX(t_orderdata.`社内伝番`) FROM t_orderdata";
            int max = Convert.ToInt32(this.entityDataSource1.DbContext.Database.SqlQuery<int?>(sql).FirstOrDefault());
            //max = Convert.ToInt32(max);

            //社内传番应该为8位，我们现在排到了10009837
            if (max < 10002000)
            {
                max += 10002000;
            }

            this.ecOrderList = q.ToList();
            var groupedOrders = ecOrderList.GroupBy(o => o.店舗コード);
            int i = 0;
            foreach (var gos in groupedOrders)
            {
                i++;

                int j = 0;

                foreach (var o in gos)
                {

                    j++;
                    o.社内伝番UnSaved = max + i;
                    o.行数 = Convert.ToInt16(j);
                    o.最大行数 = Convert.ToInt16(gos.Count());

                }
            }
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = this.ecOrderList;

        }

        private void InitializeShipperOrderList( string shipperName = null)
        {

            //this.shipperComboBox.DisplayMember = "ShortName";
            //this.shipperComboBox.ValueMember = "ShortName";
            //this.shipperComboBox.DataSource = shipperList;

            //https://dev.mysql.com/doc/refman/5.7/en/group-by-handling.html
            //http://stackoverflow.com/questions/23921117/disable-only-full-group-by
            //handle SET SESSION sql_mode='ANSI';

            string sql = @"SELECT `id受注データ`,`受注日`,`店舗コード`,
       `店舗名漢字`,`伝票番号`,`社内伝番`,`ジャンル`,`品名漢字`,`規格名漢字`, `納品口数`, `実際出荷数量`, `重量`, `実際配送担当`,`県別`, `納品指示`, `備考`
     FROM t_orderdata
     WHERE  `Status`={0} AND ( (`ジャンル`<> 1003) OR ( `ジャンル`= 1003 AND `実際配送担当` != '丸健'))
     UNION ALL
     SELECT  min(`id受注データ`), min(`受注日`), min(`店舗コード`), min(`店舗名漢字`),`社内伝番` as `伝票番号`,`社内伝番`,`ジャンル`, '二次製品' as `品名漢字` , '' as `規格名漢字`, min(`最大行数`) as `納品口数`, sum(`重量`) as `実際出荷数量`, sum(`重量`) as `重量`, min(`実際配送担当`),min(`県別`), min(`納品指示`), min(`備考`)
     FROM t_orderdata
     WHERE `Status`={0} AND `ジャンル`= 1003 AND `社内伝番` >0 AND `実際配送担当` = '丸健'
     GROUP BY `社内伝番`
     ORDER BY `実際配送担当` ASC,`県別` ASC,`店舗コード` ASC,`受注日` ASC,`伝票番号` ASC;";

            this.shipperOrderList = this.entityDataSource1.DbContext.Database.SqlQuery<v_pendingorder>(sql, OrderStatus.NotifyShipper).ToList();

           

            // 第一次初始化情况
            if (shipperName == null)
            {
                // 触发 change 事件
                shipperComboBox.SelectedIndex = 0;
            }
            else
            {
                // 用户退单后刷新
                this.shipperComboBox.Text = shipperName;
                this.dataGridView3.AutoGenerateColumns = false;
                this.dataGridView3.DataSource = this.shipperOrderList.FindAll(o => o.実際配送担当 == shipperName);
            }
        }

        #endregion


        private IEnumerable<int> GetChangedOrderIds()
        {

            List<int> rows = new List<int>();
            foreach (DictionaryEntry entry in datagrid_changes)
            {
                var key = entry.Key as string;
                if (key.EndsWith("_changed"))
                {
                    int row = Int32.Parse(key.Split('_')[0]);
                    rows.Add(row);
                }
                //                    Console.WriteLine("Key -- {0}; Value --{1}.", entry.Key, entry.Value);
            }
            return rows.Distinct();
        }

        #region 订单修订上下文菜单事件
        private void sendToShipperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var orders = GetPendingOrdersBySelectedGridCell();

            if (orders.Count() > 0)
            {
                OrderSqlHelper.SendOrderToShipper(orders);
                pager1.Bind();
            }
            else
            {
                MessageBox.Show(" please select rows in the order list first.");
            }
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var orders = GetPendingOrdersBySelectedGridCell();

            if (orders.Count() > 0)
            {
                if (MessageBox.Show("Cancel these orders?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    OrderSqlHelper.CancelOrders(orders);
                    pager1.Bind();
                }
            }
            else
            {
                MessageBox.Show(" please select rows in the order list first.");
            }
        }

        #endregion

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
            var form = new CreateOrderForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                pager1.Bind();
            }
            #region MyRegion
            //if (NewOrdersForm == null)
            //{
            //    NewOrdersForm = new NewOrdersForm();
            //    NewOrdersForm.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
            //}
            //if (NewOrdersForm == null)
            //{
            //    NewOrdersForm = new NewOrdersForm();
            //}
            //NewOrdersForm.ShowDialog();

            //#region 直接刷新

            //DataSet dsSource = new DataSet(); //这是源数据库记录集，先获取源数据库所有数据在此记录集
            //string Conn = "server=localhost;User Id=root ;Database=test";

            //MySqlConnection mycn = new MySqlConnection(Conn);
            //mycn.Open();
            //string sql = "select *from t_maruken_trans";
            //MySqlCommand cmd = new MySqlCommand(sql, mycn);
            //cmd.Connection = mycn;
            //MySqlDataAdapter Da = new MySqlDataAdapter(sql, mycn);
            //Da.Fill(dsSource, "t_maruken_trans");
            ////dataGridView1.DataSource = dsSource;
            //// dataGridView1.DataSource = DataBindings;

            //dataGridView1.DataSource = dsSource.Tables[0];
            //mycn.Close(); 
            //#endregion
            #endregion
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                rows.Add(row);
            }
            return rows ;
        }





        private int pager1_EventPaging(EventPagingArg e)
        {
            // 即使 ApplyFilter4,备份了过滤条件， 这里需要恢复排序条件， 如处理传送事件。
            var originalSortOrder = this.dataGridView1.SortOrder;
            var originalSortedColumn = this.dataGridView1.SortedColumn;

            string shipper = this.DanDangComboBox.Text;
            string genre = this.genreComboBox.Text;
            string product = this.productComboBox.Text;
            string stockState = this.ZKZTcomboBox3.Text;

            int orderCount = InitializeDataSource(shipper, genre, product, stockState);

            var direction = ListSortDirection.Ascending;
            if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
            {
                direction = ListSortDirection.Descending;
            }
            if (originalSortedColumn != null)
            {
                this.dataGridView1.Sort(originalSortedColumn, direction);
            }
            return orderCount;
        }

        /// <summary>   
        /// GridViw数据绑定   
        /// </summary>   
        /// <returns></returns>   
        private int BindDgv()
        {
            //传入要取的第一条和最后一条   
            //string start = (pager1.PageSize * (pager1.PageCurrent - 1) + 1).ToString();
            //string end = (pager1.PageSize * pager1.PageCurrent).ToString();

            //数据源   
            //dtPage = achieve.GetAll(Keyword, start, end);
            //绑定分页控件   
            //pager1.bindingSource1.DataSource = dtPage;
            //pager1.bindingNavigator1.BindingSource = pager1.bindingSource1;
            //讲分页控件绑定DataGridView   
            //dgvClients.DataSource = pager1.bindingSource1;
            //返回总记录数   
            return 0;// achieve.GetToalCount(Keyword);
        }

        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as v_pendingorder;
                order_ids.Add(pendingorder.id受注データ);
            }

            return order_ids;
        }
        private List<v_pendingorder> GetPendingOrdersBySelectedGridCell()
        {

            List<v_pendingorder> orders = new List<v_pendingorder>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                if (row.Visible)
                {
                    var pendingorder = row.DataBoundItem as v_pendingorder;
                    orders.Add(pendingorder);
                }
            }

            return orders;
        }

        private void PendingOrderForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void detailButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;

        }


        private void ecSaveButton_Click(object sender, EventArgs e)
        {

            //this.entityDataSource1.DbContext.SaveChanges();

            List<int> ids = ecOrderList.Select(o => o.id受注データ).ToList();

            using (var ctx = new GODDbContext())
            {
                var orders = (from t_orderdata o in ctx.t_orderdata
                              where ids.Contains(o.id受注データ)
                              select o).ToList();
                foreach (var order in orders)
                {
                    var pendingOrder = ecOrderList.Find(o => o.id受注データ == order.id受注データ);
                    order.社内伝番 = pendingOrder.社内伝番UnSaved;
                    order.行数 = pendingOrder.行数;
                    order.最大行数 = pendingOrder.最大行数;
                }
                    
                ctx.SaveChanges();
            }

            MessageBox.Show(String.Format("Congratulations, {0} items changed successfully!", ecOrderList.Count));

            this.dataGridView2.DataSource = null;
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void btlogin_Click(object sender, EventArgs e)
        {
            var orders = this.dataGridView3.DataSource as List<v_pendingorder>;
            if (orders.Count() > 0)
            {
                string shipperName = shipperComboBox.Text;
                List<t_maruken_trans> trans = new List<t_maruken_trans>();

                foreach (var o in orders)
                {

                    t_maruken_trans temp = new t_maruken_trans();

                    temp.OrderId = o.id受注データ;

                    temp.受注日 = o.受注日;
                    temp.店舗コード = o.店舗コード;
                    temp.店舗名漢字 = o.店舗名漢字;
                    temp.伝票番号 = o.伝票番号;
                    temp.ジャンル = Convert.ToInt16(o.ジャンル);
                    temp.品名漢字 = o.品名漢字;
                    temp.規格名漢字 = o.規格名漢字;
                    temp.口数 = o.口数;
                    temp.発注数量 = o.発注数量;
                    temp.重量 = o.重量;
                    temp.実際配送担当 = o.実際配送担当;
                    temp.県別 = o.県別;
                    temp.納品指示 = o.納品指示;
                    temp.備考 = o.備考;
                    trans.Add(temp);

                }

                using (var ctx = new GODDbContext())
                {

                    ctx.t_maruken_trans.AddRange(trans);

                    OrderSqlHelper.NotifyShipper(ctx, shipperName);
                    ctx.SaveChanges();
                }
                this.shipperOrderList.RemoveAll(o => orders.Contains(o));
                this.dataGridView3.DataSource = null;
                MessageBox.Show(String.Format("Congratulations, You have {0} items added successfully!", trans.Count));
            }

        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == ecTabPage)
            {
                InitializeRCList();
            }

            if (e.TabPage == toShipperTabPage)
            {

                InitializeShipperOrderList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // skip first time initialization
            if (shipperOrderList != null)
            {
                this.dataGridView3.AutoGenerateColumns = false;
                this.dataGridView3.DataSource = this.shipperOrderList.FindAll(o => o.実際配送担当 == shipperComboBox.Text);
            }

        }




        #region 修改键生成
        private string GetCellKey(int rowIndex, int columnIndex, bool forChanged)
        {
            return GetCellKey(rowIndex, columnIndex) + "_changed";
        }

        private string GetCellKey(int rowIndex, int columnIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            var model = row.DataBoundItem as v_pendingorder;

            return string.Format("{0}_{1}", model.id受注データ, columnIndex.ToString());
        }
        #endregion


        #region 订单过滤功能

        private void ClearSelect_Click(object sender, EventArgs e)
        {
            var originalSortedColumn = this.dataGridView1.SortedColumn;

            if (originalSortedColumn != null)
            {
                originalSortedColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                originalSortedColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            if (DanDangComboBox.SelectedIndex != 0)
            {
                DanDangComboBox.SelectedIndex = 0;
            }
            else if (genreComboBox.SelectedIndex != 0)
            {
                genreComboBox.SelectedIndex = 0;
            }
            else if (productComboBox.SelectedIndex != 0)
            {
                productComboBox.SelectedIndex = 0;
            }
            
            if (ZKZTcomboBox3.SelectedIndex != 0)
            {
                ZKZTcomboBox3.SelectedIndex = 0;
            }


        }

        
        //分类名称
        private void GenreNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = DanDangComboBox.Text;
            var orders = GetOrdersByShipper(shipper);

            var combox = sender as ComboBox;
            if (combox.Text != "不限")
            {
                orders = orders.FindAll(o => o.GenreName == combox.Text);
            }

            // 品名漢字
            InitializeProductComboBox(orders);
        }
        // 品名汉字
        private void PMHZCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = DanDangComboBox.Text;
            string genre = genreComboBox.Text;
            string product = productComboBox.Text;
            string stock = ZKZTcomboBox3.Text;
            ApplyFilter4(shipper, genre, product, stock);

        }
        //在库状态
        private void ZKZTcomboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = DanDangComboBox.Text;
            string genre = genreComboBox.Text;
            string product = productComboBox.Text;
            string stock = ZKZTcomboBox3.Text;
            ApplyFilter4(shipper, genre, product, stock);
        }
        // 配送担当
        private void DanDangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var combox = sender as ComboBox;
            string shipper = combox.Text;
            var orders = GetOrdersByShipper(shipper);                        
            InitializeGenreComboBox(orders);
            //InitializeProductComboBox(orders);
        }
        private void InitializeGenreComboBox(List<v_pendingorder> orders)
        {
            // GenreName
            var GenreName = orders.Select(s => new MockEntity { Id = s.ジャンル, ShortName = s.GenreName, FullName = s.GenreName }).Distinct().ToList();
            GenreName.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
            this.genreComboBox.DisplayMember = "FullName";
            this.genreComboBox.ValueMember = "Id";
            this.genreComboBox.DataSource = GenreName;
        }

        private void InitializeProductComboBox(List<v_pendingorder> orders)
        {
            // 品名漢字
            var PMHZ = orders.Select(s => new MockEntity { Id = s.自社コード, TaxonId = s.ジャンル, ShortName = s.品名漢字, FullName = s.品名漢字 }).Distinct().ToList();
            PMHZ.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
            this.productComboBox.DisplayMember = "FullName";
            this.productComboBox.ValueMember = "Id";
            this.productComboBox.DataSource = PMHZ;
        }

        private List<v_pendingorder> GetDataGridViewBoundOrders()
        {
            List<v_pendingorder> orders = new List<v_pendingorder>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                orders.Add(dataGridView1.Rows[i].DataBoundItem as v_pendingorder);
            }

            return orders;
        }

        private void ApplyFilter4(string shipper = "", string genre = "", string product = "", string stock = "")
        {
            var originalSortOrder = this.dataGridView1.SortOrder;
            var originalSortedColumn = this.dataGridView1.SortedColumn;

            bindingSource1.DataSource = null;
            var filteredOrderList = pendingOrderList;
            datagrid_changes.Clear();


            if (shipper.Length > 0 && shipper != "不限")
            {

                filteredOrderList = filteredOrderList.FindAll(o => o.実際配送担当 == shipper);

            }
            if (product.Length > 0 && product != "不限")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.品名漢字 == product);
            }
            if (genre.Length > 0 && genre != "不限")
            {

                filteredOrderList = filteredOrderList.FindAll(o => o.GenreName == genre);

            }
            if (stock.Length > 0 && stock != "不限")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.在庫状態 == stock);                
            }

            sortablePendingOrderList = new SortableBindingList<v_pendingorder>(filteredOrderList);

            this.bindingSource1.DataSource = sortablePendingOrderList;

            var direction = ListSortDirection.Ascending;
            if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
            {
                direction = ListSortDirection.Descending;
            }
            if (originalSortedColumn != null)
            {
                this.dataGridView1.Sort(originalSortedColumn, direction);
            }
        }

        private void UpdateStockState(List<v_pendingorder> orders)
        {
            // 每次应用过滤条件时，都会生成新的结果集，根据新的结果集更新“在庫状態”
            var grouped_orders = orders.GroupBy(o => new {自社コード=o.自社コード, 実際配送担当=o.実際配送担当}, o => o);
            foreach (var gos in grouped_orders)
            {
                int total = gos.Sum(o => o.実際出荷数量);
                int min = gos.Min(o => o.実際出荷数量);

                foreach (var o in gos)
                {

                    if (o.在庫数 >= total)
                    {
                        o.在庫状態 = "あり";
                    }
                    else if (o.在庫数 > min)
                    {
                        o.在庫状態 = "一部不足";
                    }
                    else
                    {
                        o.在庫状態 = "なし";
                    }
                }
            }
        
        }

        private void ApplyFilter2()
        {
            datagrid_changes.Clear();
            string filter = "";


            if (this.DanDangComboBox.Text.Length > 0 && this.DanDangComboBox.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(実際配送担当='" + this.DanDangComboBox.Text + "')";

            }
            if (this.productComboBox.Text.Length > 0 && this.productComboBox.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(品名漢字='" + this.productComboBox.Text + "')";

            }
            if (this.genreComboBox.Text.Length > 0 && this.genreComboBox.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(GenreName='" + this.genreComboBox.Text + "')";

            }
            if (false && this.ZKZTcomboBox3.Text.Length > 0 && this.ZKZTcomboBox3.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(在庫状態='" + this.ZKZTcomboBox3.Text + "')";
            }


            this.bindingSource1.Filter = filter;
            // 每次应用过滤条件时，都会生成新的结果集，根据新的结果集更新“在庫状態”
            var orders = this.bindingSource1.List.Cast<v_pendingorder>().ToList();
            IEnumerable<IGrouping<int, v_pendingorder>> grouped_orders = orders.GroupBy(o => o.自社コード, o => o);
            foreach (var gos in grouped_orders)
            {
                int total = gos.Sum(o => o.実際出荷数量);
                int min = gos.Min(o => o.実際出荷数量);

                foreach (var o in gos)
                {

                    if (o.在庫数 >= total)
                    {
                        o.在庫状態 = "あり";
                    }
                    else if (o.在庫数 > min)
                    {
                        o.在庫状態 = "一部不足";
                    }
                    else
                    {
                        o.在庫状態 = "なし";
                    }
                }
            }

            string zkzt = ZKZTcomboBox3.Text;

            // 在库状态 过滤条件 检查, 因为在库状态是动态值，所以需要使用 visible 来过滤
            
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                cm.SuspendBinding();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var row = dataGridView1.Rows[i];
                    var order = row.DataBoundItem as v_pendingorder;

                    row.Visible = (zkzt == "不限" ? true : order.在庫状態 == zkzt);
                }
                cm.ResumeBinding();
            }
        }

        private List<v_pendingorder> GetOrdersByShipper(string shipper)
        {
            List<v_pendingorder> orders = pendingOrderList;
            if (shipper != "不限")
            {
                orders = orders.FindAll(o => o.実際配送担当 == shipper);
            }
            return orders;
        }

        #endregion


        #region 退单功能
        
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string selectedShipperName = this.shipperComboBox.Text;
            List<v_pendingorder> orders = new List<v_pendingorder>();
            for (int i = 0; i < dataGridView3.SelectedRows.Count; i++)
            {
                var order = dataGridView3.SelectedRows[i].DataBoundItem as v_pendingorder;
                orders.Add(order);
            }

            RollbackOrder(orders);

            InitializeShipperOrderList(selectedShipperName);
            // 更新待處理訂單列表
            pager1.Bind();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<v_pendingorder> orders = new List<v_pendingorder>();
            for( int i =0; i< dataGridView2.SelectedRows.Count; i++)
            {
                var order = dataGridView2.SelectedRows[i].DataBoundItem as v_pendingorder;
                orders.Add( order );
            }

            RollbackOrder(orders);
            // 更新二次製品列表
            InitializeRCList();
            // 更新待處理訂單列表
            pager1.Bind();

        }

        private void RollbackOrder( List<v_pendingorder> pendingOrders ) 
        {
            using (var ctx = new GODDbContext())
            {
                var orderIds = pendingOrders.FindAll(o => o.社内伝番 == 0).Select(o => o.id受注データ);

                var innerIds = pendingOrders.FindAll(o => o.社内伝番 > 0).Select(o => o.社内伝番);

                var orderList = (from t_orderdata o in ctx.t_orderdata
                    where orderIds.Contains(o.id受注データ) || innerIds.Contains(o.社内伝番)
                    select o).ToList();
                orderIds = orderList.Select( o=> o.id受注データ);
                var stockrecList = (from t_stockrec s in ctx.t_stockrec
                                    where orderIds.Contains(s.OrderId)
                                    select s).ToList();

                foreach (var order in orderList) 
                {
                    //二次制品订单？
                    order.社内伝番 = 0;
                    order.一旦保留 = true;
                    order.配送担当受信 = false;
                    order.配送担当受信時刻 = null;
                    order.Status = OrderStatus.Pending;
                    //var stockrec = stockrecList.Find(s => s.OrderId = order.id受注データ);
                
                }

                var marukenTransList = (from t_maruken_trans m in ctx.t_maruken_trans
                                        where orderIds.Contains(m.OrderId)
                                        select m).ToList();

                ctx.t_maruken_trans.RemoveRange(marukenTransList);
                ctx.t_stockrec.RemoveRange(stockrecList);
                ctx.SaveChanges();
                OrderSqlHelper.UpdateStockState(ctx, stockrecList);

            }


        }

        #endregion




    }
}
