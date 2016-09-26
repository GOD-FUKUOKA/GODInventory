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

        private List<v_pendingorder> pendingOrderList;
        private SortableBindingList<v_pendingorder> sortablePendingOrderList;
        private List<t_orderdata> ecOrderList;
        private List<v_pendingorder> shipperOrderList;


        public PendingOrderForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            var ctx = entityDataSource1.DbContext as GODDbContext;
            this.stockstates = ctx.t_stockstate.Select(s => s).ToList();

            //shipperList = (from s in ctx.t_shoplist
            //         group s by s.配送担当 into g
            //               select new v_shipper { ShortName = g.Key }).ToList();

            var genre = (from g in ctx.t_genre
                         where g.ジャンル名 == "二次製品"
                         select g).FirstOrDefault();
            ErCiZhiPinId = (genre != null ? genre.idジャンル : 0);

            InitializePager();

            InitializeRCList();

            //丸健

            //物流

        }


        private void InitializeRCList()
        {

            var q = OrderSqlHelper.ECWithoutCodeOrderQuery(this.entityDataSource1, ErCiZhiPinId);
            string sql = "SELECT MAX(t_orderdata.`社内伝番`) FROM t_orderdata";
            var max = this.entityDataSource1.DbContext.Database.SqlQuery<int?>(sql).FirstOrDefault();
            max = Convert.ToInt32(max);
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
                    o.社内伝番 = max + i;
                    o.行数 = Convert.ToInt16(j);
                    o.最大行数 = Convert.ToInt16(gos.Count());

                }
            }
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = this.ecOrderList;

        }

        private void InitializeShipperOrderList()
        {
            this.shipperComboBox.SelectedIndex = 0;
            //this.shipperComboBox.DisplayMember = "ShortName";
            //this.shipperComboBox.ValueMember = "ShortName";
            //this.shipperComboBox.DataSource = shipperList;

            //https://dev.mysql.com/doc/refman/5.7/en/group-by-handling.html
            //http://stackoverflow.com/questions/23921117/disable-only-full-group-by
            //handle SET SESSION sql_mode='ANSI';

            string sql = @"SELECT `id受注データ`,`受注日`,`店舗コード`,
       `店舗名漢字`,`伝票番号`,`ジャンル`,`品名漢字`,`規格名漢字`, `納品口数`, `実際出荷数量`, `重量`, `実際配送担当`,`県別`, `納品指示`, `備考`
     FROM t_orderdata
     WHERE  `Status`={0} AND `ジャンル`<> 1003
     UNION ALL
     SELECT  min(`id受注データ`), min(`受注日`), min(`店舗コード`), min(`店舗名漢字`),`社内伝番` as `伝票番号`,`ジャンル`, '二次製品' as `品名漢字` , '' as `規格名漢字`, min(`最大行数`) as `納品口数`, sum(`重量`) as `実際出荷数量`, sum(`重量`) as `重量`, min(`実際配送担当`),min(`県別`), min(`納品指示`), min(`備考`)
     FROM t_orderdata
     WHERE `Status`={0} AND `ジャンル`= 1003 AND `社内伝番` IS NOT NULL
     GROUP BY `社内伝番`
     ORDER BY `実際配送担当` ASC,`県別` ASC,`店舗コード` ASC,`受注日` ASC,`伝票番号` ASC;";

            this.shipperOrderList = this.entityDataSource1.DbContext.Database.SqlQuery<v_pendingorder>(sql, OrderStatus.NotifyShipper).ToList();

            string shipper = this.shipperComboBox.Text;

            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.DataSource = this.shipperOrderList.FindAll(o => o.実際配送担当 == shipper);

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
                IEnumerable<int> rows = GetChangedRowIndexes();

                if (rows.Count() > 0)
                {
                    foreach (var row in rows.Distinct())
                    {
                        var pendingorder = bindingSource1.List[row] as v_pendingorder;
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
                    InitializeOrderData();
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            IEnumerable<int> rows = GetChangedRowIndexes();
            if (rows.Count() > 0)
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
                DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
                try
                {
                    if (datagrid_changes.ContainsKey(e.RowIndex))//if (dgrSingle.Cells["列名"].Value.ToString().Contains("比较值"))
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
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
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!datagrid_changes.ContainsKey(cell_key))
            {
                datagrid_changes[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = datagrid_changes[cell_key];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                datagrid_changes.Remove(cell_key + "_changed");
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                datagrid_changes[cell_key + "_changed"] = new_cell_value;
            }
            else
            {
                datagrid_changes.Remove(cell_key + "_changed");
            }
            //new

            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.sortablePendingOrderList[e.RowIndex].実際出荷数量 = (int)cell.Value;
            this.sortablePendingOrderList[e.RowIndex].納品口数 = (int)cell.Value / this.sortablePendingOrderList[e.RowIndex].最小発注単位数量;
            this.dataGridView1.Refresh();


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
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString() + "_changed";

            if (datagrid_changes.ContainsKey(cell_key))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private void ordersTabPage_Click(object sender, EventArgs e)
        {

        }

        #region InitializeOrderData

        private int InitializeOrderData()
        {
            this.bindingSource1.DataSource = null;
            // 记录DataGridView改变数据
            this.datagrid_changes = new Hashtable();

            //var ctx = entityDataSource1.DbContext as GODDbContext;
            //var stockstates = ctx.t_stockstate.Select(s => s).ToList();
            var cq = OrderSqlHelper.PendingOrderQuery(entityDataSource1);
            var count = cq.Count();

            if (count > 0)
            {
                string sql = @" SELECT o.*, g.`ジャンル名` as `GenreName`, k.`在庫数` as `在庫数`  from t_orderdata o
INNER JOIN t_genre g  on o.ジャンル = g.idジャンル
LEFT JOIN t_stockstate k on  o.自社コード = k.自社コード AND  o.実際配送担当 = k.ShipperName 
WHERE o.Status ={0}
ORDER BY o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号 LIMIT {1} OFFSET {2};";


                // create BindingList (sortable/filterable)
                int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
                this.pendingOrderList = entityDataSource1.DbContext.Database.SqlQuery<v_pendingorder>(sql, OrderStatus.Pending, pager1.PageSize, offset).ToList();

                // count 计算t_orderdata 表， list 是 orderdata join itemlist join stockstate
                // 所以有可能 bindinglist is null 

                IEnumerable<IGrouping<int, v_pendingorder>> grouped_orders = pendingOrderList.GroupBy(o => o.自社コード, o => o);
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
                sortablePendingOrderList = new SortableBindingList<v_pendingorder>(pendingOrderList);
                this.bindingSource1.DataSource = sortablePendingOrderList;
                //new 

                if (sortablePendingOrderList.Count > 0)
                {
                    //var shops = sortablePendingOrderList.Select(s => new MockEntity { Id = s.id受注データ, FullName = s.実際配送担当 }).Distinct().ToList();
                    //shops.Insert(0, new MockEntity { Id = 0, FullName = "不限" });
                    //this.DanDangComboBox.DisplayMember = "FullName";
                    //this.DanDangComboBox.ValueMember = "Id";
                    //this.DanDangComboBox.DataSource = shops;

                    // 担当
                    var counties = sortablePendingOrderList.Select(s => new MockEntity { ShortName = s.実際配送担当, FullName = s.実際配送担当 }).Distinct().ToList();
                    counties.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                    this.DanDangComboBox.DisplayMember = "FullName";
                    this.DanDangComboBox.ValueMember = "ShortName";
                    this.DanDangComboBox.DataSource = counties;

                    // 品名漢字
                    var PMHZ = sortablePendingOrderList.Select(s => new MockEntity { ShortName = s.品名漢字, FullName = s.品名漢字 }).Distinct().ToList();
                    PMHZ.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                    this.PMHZCombox.DisplayMember = "FullName";
                    this.PMHZCombox.ValueMember = "ShortName";
                    this.PMHZCombox.DataSource = PMHZ;


                    // GenreName
                    var GenreName = sortablePendingOrderList.Select(s => new MockEntity { ShortName = s.GenreName, FullName = s.GenreName }).Distinct().ToList();
                    GenreName.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                    this.GenreNamecomboBox.DisplayMember = "FullName";
                    this.GenreNamecomboBox.ValueMember = "ShortName";
                    this.GenreNamecomboBox.DataSource = GenreName;


                    // 在庫状態
                    var ZKZT = sortablePendingOrderList.Select(s => new MockEntity { ShortName = s.在庫状態, FullName = s.在庫状態 }).Distinct().ToList();
                    ZKZT.Insert(0, new MockEntity { ShortName = "不限", FullName = "不限" });
                    this.ZKZTcomboBox3.DisplayMember = "FullName";
                    this.ZKZTcomboBox3.ValueMember = "ShortName";
                    this.ZKZTcomboBox3.DataSource = ZKZT;




                }
            }
            dataGridView1.DataSource = this.bindingSource1;

            return count;
        }


        #endregion


        private IEnumerable<int> GetChangedRowIndexes()
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
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private void invoiceNoFilterTextBox_Leave(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filter = "";
            if (this.storeCodeFilterTextBox3.Text.Length > 0)
            {
                filter += "(店舗コード=" + this.storeCodeFilterTextBox3.Text + ")";
            }
            if (this.invoiceNoFilterTextBox.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(伝票番号=" + this.invoiceNoFilterTextBox.Text + ")";
            }
            this.bindingSource1.Filter = filter;

        }
        private void ApplyFilter2()
        {
            string filter = "";
            if (this.storeCodeFilterTextBox3.Text.Length > 0)
            {
                filter += "(店舗コード=" + this.storeCodeFilterTextBox3.Text + ")";
            }
            if (this.invoiceNoFilterTextBox.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(伝票番号=" + this.invoiceNoFilterTextBox.Text + ")";
            }
            if (this.DanDangComboBox.Text.Length > 0 && this.DanDangComboBox.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(実際配送担当=" + this.DanDangComboBox.Text + ")";
            }
            if (this.PMHZCombox.Text.Length > 0 && this.PMHZCombox.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(品名漢字=" + this.PMHZCombox.Text + ")";
            }
            if (this.GenreNamecomboBox.Text.Length > 0 && this.GenreNamecomboBox.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(GenreName=" + this.GenreNamecomboBox.Text + ")";
            }
            if (this.ZKZTcomboBox3.Text.Length > 0 && this.ZKZTcomboBox3.Text != "不限")
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(在庫状態=" + "'" + this.ZKZTcomboBox3.Text + "'" + ")";
            }
            //if (this.invoiceNoFilterTextBox.Text.Length > 0)
            //{
            //if (filter.Length > 0)
            //{
            //    filter += " AND ";
            //}
            //filter += "(社内伝番>" + 0 + ")";
            //    //filter += "(社内伝番=" + this.invoiceNoFilterTextBox.Text + ")";

            //}
            ////不读取 canel 的订单
            //filter += " AND ";
            //filter += "(キャンセル<>" + "'" + "no" + "'" + ")";

            this.bindingSource1.Filter = filter;

        }
        private void filterButton_Click(object sender, EventArgs e)
        {

            ApplyFilter();


            ///筛选调价
            ///
            //if (storeCodeFilterTextBox3.Text != "" && invoiceNoFilterTextBox.Text == "")
            //{

            //    CheckUserInfo(storeCodeFilterTextBox3.Text, "1", "");
            //    this.dataGridView1.AutoGenerateColumns = false;
            //    this.dataGridView1.DataSource = Findorderdataresults;
            //}
            //else if (storeCodeFilterTextBox3.Text != "" && invoiceNoFilterTextBox.Text != "")
            //{
            //    CheckUserInfo(storeCodeFilterTextBox3.Text, "2", invoiceNoFilterTextBox.Text);
            //    this.dataGridView1.AutoGenerateColumns = false;
            //    this.dataGridView1.DataSource = Findorderdataresults;
            //}


        }
        public void CheckUserInfo(string username, string tyoe, string conditon2)
        {
            string SQLStr = "";

            Findorderdataresults = new List<t_orderdata>();
            if (tyoe == "1")
                SQLStr = String.Format(" select * From t_orderdata where 店舗コード='{0}'", username);
            else if (tyoe == "2")
                SQLStr = String.Format(" select * From t_orderdata where 店舗コード='{0}',伝票番号='{1}'", username, conditon2);

            try
            {
                string constr = "server=localhost;User Id=root ;Database=test";
                CreateOrderForm SqlData = new CreateOrderForm();
                MySqlConnection mycon = new MySqlConnection(constr);
                mycon.Open();
                //MySqlCommand mycmd = new MySqlCommand("select * from t_maruken_trans  where 店舗コード='87'", mycon);
                MySqlCommand mycmd = new MySqlCommand(SQLStr, mycon);

                //SqlDataReader DataReader = mycmd.ExSQLReader( );
                MySqlDataReader DataReader = mycmd.ExecuteReader();
                while (DataReader.Read())
                {
                    t_orderdata userinfo = new t_orderdata();

                    #region 集合
                    //if (DataReader.GetValue(0).ToString() != null && DataReader.GetValue(0).ToString() != "")
                    //userinfo.id受注データ= Convert.ToInt32(DataReader.GetValue(0).ToString()); 


                    //userinfo.id = DataReader.GetValue(0).ToString();
                    //userinfo.受注日 = Convert.ToDateTime(DataReader.GetValue(1).ToString());
                    //userinfo.店舗コード = Convert.ToInt16(DataReader.GetValue(2).ToString());
                    //userinfo.店舗名漢字 = DataReader.GetValue(3).ToString();
                    //userinfo.伝票番号 = Convert.ToInt32(DataReader.GetValue(4).ToString());
                    //userinfo.キャンセル = DataReader.GetValue(5).ToString();
                    //if (DataReader.GetValue(6).ToString() != null && DataReader.GetValue(6).ToString() != "")
                    //    userinfo.キャンセル時刻 = Convert.ToDateTime(DataReader.GetValue(6).ToString());
                    //userinfo.ジャンル = Convert.ToInt16(DataReader.GetValue(7).ToString());
                    //userinfo.品名漢字 = DataReader.GetValue(8).ToString();
                    //userinfo.規格名漢字 = DataReader.GetValue(9).ToString();
                    //userinfo.発注数量 = Convert.ToInt32(DataReader.GetValue(10).ToString());
                    //userinfo.口数 = Convert.ToInt32(DataReader.GetValue(11).ToString());
                    //if (DataReader.GetValue(12).ToString() != null && DataReader.GetValue(12).ToString() != "")
                    //    userinfo.重量 = Convert.ToInt32(DataReader.GetValue(12).ToString());
                    //userinfo.単位 = DataReader.GetValue(13).ToString();
                    //userinfo.実際配送担当 = DataReader.GetValue(14).ToString();

                    //userinfo.県別 = DataReader.GetValue(15).ToString();
                    //userinfo.配送担当受信 = Convert.ToBoolean(DataReader.GetValue(16).ToString());
                    //if (DataReader.GetValue(17).ToString() != null && DataReader.GetValue(17).ToString() != "")
                    //    userinfo.配送担当受信時刻 = Convert.ToDateTime(DataReader.GetValue(17).ToString());
                    //userinfo.専務受信 = Convert.ToBoolean(DataReader.GetValue(18).ToString());
                    //if (DataReader.GetValue(19).ToString() != null && DataReader.GetValue(19).ToString() != "")
                    //    userinfo.専務受信時刻 = Convert.ToDateTime(DataReader.GetValue(19).ToString());
                    //userinfo.納品指示 = DataReader.GetValue(20).ToString();
                    //userinfo.備考 = DataReader.GetValue(21).ToString();

                    ////MessageBox.Show("服务器查找成功");
                    //Findorderdataresults.Add(userinfo);
                    #endregion
                    #region new

                    if (DataReader.GetValue(0).ToString() != null && DataReader.GetValue(0).ToString() != "")
                        userinfo.id受注データ = Convert.ToInt32(DataReader.GetValue(0).ToString());


                    userinfo.id = DataReader.GetValue(1).ToString();
                    userinfo.受注日 = Convert.ToDateTime(DataReader.GetValue(3).ToString());
                    userinfo.店舗コード = Convert.ToInt16(DataReader.GetValue(6).ToString());
                    userinfo.店舗名漢字 = DataReader.GetValue(7).ToString();
                    userinfo.伝票番号 = Convert.ToInt32(DataReader.GetValue(11).ToString());
                    userinfo.キャンセル = DataReader.GetValue(14).ToString();
                    if (DataReader.GetValue(15).ToString() != null && DataReader.GetValue(15).ToString() != "")
                        userinfo.キャンセル時刻 = Convert.ToDateTime(DataReader.GetValue(15).ToString());
                    if (DataReader.GetValue(16).ToString() != null && DataReader.GetValue(16).ToString() != "")
                        userinfo.ジャンル = Convert.ToInt16(DataReader.GetValue(16).ToString());
                    userinfo.品名漢字 = DataReader.GetValue(19).ToString();
                    userinfo.規格名漢字 = DataReader.GetValue(20).ToString();
                    userinfo.発注数量 = Convert.ToInt32(DataReader.GetValue(21).ToString());
                    if (DataReader.GetValue(23).ToString() != null && DataReader.GetValue(23).ToString() != "")
                        userinfo.口数 = Convert.ToInt32(DataReader.GetValue(23).ToString());
                    if (DataReader.GetValue(25).ToString() != null && DataReader.GetValue(25).ToString() != "")
                        userinfo.重量 = Convert.ToInt32(DataReader.GetValue(25).ToString());
                    userinfo.単位 = DataReader.GetValue(26).ToString();
                    userinfo.実際配送担当 = DataReader.GetValue(32).ToString();
                    if (DataReader.GetValue(111).ToString() != null && DataReader.GetValue(111).ToString() != "")

                        userinfo.県別 = DataReader.GetValue(111).ToString();
                    userinfo.配送担当受信 = Convert.ToBoolean(DataReader.GetValue(33).ToString());
                    if (DataReader.GetValue(34).ToString() != null && DataReader.GetValue(34).ToString() != "")
                        userinfo.配送担当受信時刻 = Convert.ToDateTime(DataReader.GetValue(34).ToString());
                    userinfo.専務受信 = Convert.ToBoolean(DataReader.GetValue(35).ToString());
                    if (DataReader.GetValue(36).ToString() != null && DataReader.GetValue(36).ToString() != "")
                        userinfo.専務受信時刻 = Convert.ToDateTime(DataReader.GetValue(36).ToString());
                    userinfo.納品指示 = DataReader.GetValue(37).ToString();
                    userinfo.備考 = DataReader.GetValue(41).ToString();

                    //MessageBox.Show("服务器查找成功");
                    Findorderdataresults.Add(userinfo);


                    #endregion
                }
                mycon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {

            }
        }
        private int pager1_EventPaging(EventPagingArg e)
        {
            int order_count = InitializeOrderData();

            return order_count;
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
                var pendingorder = row.DataBoundItem as v_pendingorder;
                orders.Add(pendingorder);
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

        public void CheckUserInfo_ID(string username, string tyoe, string conditon2)
        {
            string SQLStr = "";

            Findorderdataresults = new List<t_orderdata>();
            if (tyoe == "1")
                SQLStr = String.Format(" select * From t_orderdata where id='{0}'", username);

            try
            {
                string constr = "server=localhost;User Id=root ;Database=test";
                CreateOrderForm SqlData = new CreateOrderForm();
                MySqlConnection mycon = new MySqlConnection(constr);
                mycon.Open();
                //MySqlCommand mycmd = new MySqlCommand("select * from t_maruken_trans  where 店舗コード='87'", mycon);
                MySqlCommand mycmd = new MySqlCommand(SQLStr, mycon);

                //SqlDataReader DataReader = mycmd.ExSQLReader( );
                MySqlDataReader DataReader = mycmd.ExecuteReader();
                while (DataReader.Read())
                {
                    t_orderdata userinfo = new t_orderdata();

                    #region 集合
                    //userinfo.id = DataReader.GetValue(0).ToString();
                    //userinfo.受注日 = Convert.ToDateTime(DataReader.GetValue(1).ToString());
                    //userinfo.店舗コード = Convert.ToInt16(DataReader.GetValue(2).ToString());
                    //userinfo.店舗名漢字 = DataReader.GetValue(3).ToString();
                    //userinfo.伝票番号 = Convert.ToInt32(DataReader.GetValue(4).ToString());
                    //userinfo.キャンセル = DataReader.GetValue(5).ToString();
                    //if (DataReader.GetValue(6).ToString() != null && DataReader.GetValue(6).ToString() != "")
                    //    userinfo.キャンセル時刻 = Convert.ToDateTime(DataReader.GetValue(6).ToString());
                    //userinfo.ジャンル = Convert.ToInt16(DataReader.GetValue(7).ToString());
                    //userinfo.品名漢字 = DataReader.GetValue(8).ToString();
                    //userinfo.規格名漢字 = DataReader.GetValue(9).ToString();
                    //userinfo.発注数量 = Convert.ToInt32(DataReader.GetValue(10).ToString());
                    //userinfo.口数 = Convert.ToInt32(DataReader.GetValue(11).ToString());
                    //if (DataReader.GetValue(12).ToString() != null && DataReader.GetValue(12).ToString() != "")
                    //    userinfo.重量 = Convert.ToInt32(DataReader.GetValue(12).ToString());
                    //userinfo.単位 = DataReader.GetValue(13).ToString();
                    //userinfo.実際配送担当 = DataReader.GetValue(14).ToString();

                    //userinfo.県別 = DataReader.GetValue(15).ToString();
                    //userinfo.配送担当受信 = Convert.ToBoolean(DataReader.GetValue(16).ToString());
                    //if (DataReader.GetValue(17).ToString() != null && DataReader.GetValue(17).ToString() != "")
                    //    userinfo.配送担当受信時刻 = Convert.ToDateTime(DataReader.GetValue(17).ToString());
                    //userinfo.専務受信 = Convert.ToBoolean(DataReader.GetValue(18).ToString());
                    //if (DataReader.GetValue(19).ToString() != null && DataReader.GetValue(19).ToString() != "")
                    //    userinfo.専務受信時刻 = Convert.ToDateTime(DataReader.GetValue(19).ToString());
                    //userinfo.納品指示 = DataReader.GetValue(20).ToString();
                    //userinfo.備考 = DataReader.GetValue(21).ToString();

                    ////MessageBox.Show("服务器查找成功");
                    //Findorderdataresults.Add(userinfo);
                    #endregion
                    #region new

                    if (DataReader.GetValue(0).ToString() != null && DataReader.GetValue(0).ToString() != "")
                        userinfo.id受注データ = Convert.ToInt32(DataReader.GetValue(0).ToString());


                    userinfo.id = DataReader.GetValue(1).ToString();
                    userinfo.受注日 = Convert.ToDateTime(DataReader.GetValue(3).ToString());
                    userinfo.店舗コード = Convert.ToInt16(DataReader.GetValue(6).ToString());
                    userinfo.店舗名漢字 = DataReader.GetValue(7).ToString();
                    userinfo.伝票番号 = Convert.ToInt32(DataReader.GetValue(11).ToString());
                    userinfo.キャンセル = DataReader.GetValue(14).ToString();
                    if (DataReader.GetValue(15).ToString() != null && DataReader.GetValue(15).ToString() != "")
                        userinfo.キャンセル時刻 = Convert.ToDateTime(DataReader.GetValue(15).ToString());
                    if (DataReader.GetValue(16).ToString() != null && DataReader.GetValue(16).ToString() != "")
                        userinfo.ジャンル = Convert.ToInt16(DataReader.GetValue(16).ToString());
                    userinfo.品名漢字 = DataReader.GetValue(19).ToString();
                    userinfo.規格名漢字 = DataReader.GetValue(20).ToString();
                    userinfo.発注数量 = Convert.ToInt32(DataReader.GetValue(21).ToString());
                    if (DataReader.GetValue(23).ToString() != null && DataReader.GetValue(23).ToString() != "")
                        userinfo.口数 = Convert.ToInt32(DataReader.GetValue(23).ToString());
                    if (DataReader.GetValue(25).ToString() != null && DataReader.GetValue(25).ToString() != "")
                        userinfo.重量 = Convert.ToInt32(DataReader.GetValue(25).ToString());
                    userinfo.単位 = DataReader.GetValue(26).ToString();
                    userinfo.実際配送担当 = DataReader.GetValue(32).ToString();
                    if (DataReader.GetValue(111).ToString() != null && DataReader.GetValue(111).ToString() != "")

                        userinfo.県別 = DataReader.GetValue(111).ToString();
                    userinfo.配送担当受信 = Convert.ToBoolean(DataReader.GetValue(33).ToString());
                    if (DataReader.GetValue(34).ToString() != null && DataReader.GetValue(34).ToString() != "")
                        userinfo.配送担当受信時刻 = Convert.ToDateTime(DataReader.GetValue(34).ToString());
                    userinfo.専務受信 = Convert.ToBoolean(DataReader.GetValue(35).ToString());
                    if (DataReader.GetValue(36).ToString() != null && DataReader.GetValue(36).ToString() != "")
                        userinfo.専務受信時刻 = Convert.ToDateTime(DataReader.GetValue(36).ToString());
                    userinfo.納品指示 = DataReader.GetValue(37).ToString();
                    userinfo.備考 = DataReader.GetValue(41).ToString();

                    //MessageBox.Show("服务器查找成功");
                    Findorderdataresults.Add(userinfo);


                    #endregion
                }
                mycon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;

        }


        private void ecSaveButton_Click(object sender, EventArgs e)
        {

            this.entityDataSource1.DbContext.SaveChanges();

            //List<int> oid = new List<int>();

            //foreach (var o in ecOrderList)
            //{
            //    oid.Add(o.id受注データ);
            //}

            //using (var ctx = new GODDbContext())
            //{
            //    t_orderdata temp = new t_orderdata();
            //    ctx.t_orderdata.AddRange(orders1);
            //    ctx.SaveChanges();
            //    this.orderList.Clear();
            //}

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
                this.dataGridView3.DataSource = this.shipperOrderList.FindAll(o => o.実際配送担当 == shipperComboBox.Text);
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.ColumnIndex == 11) // 担当， 取值不是 丸健，MKL，'マツモト産業'
            //{                
            //}
            //else {
            //    e.ThrowException = true;
            //}
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView2.ClearSelection();
                    dataGridView2.Columns[e.ColumnIndex].Selected = true;
                    dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);

                }

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int page = this.tabControl1.SelectedIndex;

            if (page == 1)
            {
                int i = dataGridView1.CurrentCell.OwningColumn.Index;
                int iRow = dataGridView1.CurrentCell.OwningRow.Index;
                var oids = Sec_GetOrderIdsBySelectedGridCell();
                int 自社コード = 0;

                using (var ctx = new GODDbContext())
                {

                    //  var pendingorder = bindingSource1.List[row] as v_pendingorder;
                    var filtered = ecOrderList.FindAll(s => s.id受注データ == oids[0]);
                    t_orderdata order = this.ecOrderList.Find(o => (o.id受注データ == oids[0]));
                    if (order != null)
                    {
                        //   t_orderdata order = ecOrderList.Find(pendingorder.id受注データ);
                        //需要修改的字段为: “口数” “发注数量” “担当” “形态”
                        order.一旦保留 = true;
                        order.配送担当受信 = false;
                        order.配送担当受信時刻 = null;
                        自社コード = order.自社コード;
                        order.社内伝番 = 0;

                        var results = from s in ctx.t_stockrec
                                      where s.自社コード >= 自社コード
                                      group s by s.納品書番号 into g
                                      select g;
                        //删除Rec 
                        var stockrecs = (from s in ctx.t_stockrec
                                         where s.自社コード == 自社コード && s.状態 != "完了"
                                         select s).ToList();
                        ctx.t_stockrec.RemoveRange(stockrecs);
                        //更新t_stockstate

                        List<t_stockrec> receivedList = new List<t_stockrec>();
                        foreach (var item in filtered)
                        {
                            if (item != null)
                            {
                                #region 集合
                                var order1 = new t_stockrec();
                                //order.日付 = orderCreatedAtDateTimePicker.Value;
                                //order.先 = this.warehouseComboBox.Text;
                                //order1.元 = order.;
                                //order.工厂 = this.manufacturerComboBox.Text;
                                //order.納品書番号 = stockNOTextBox.Text;

                                order1.数量 = order.発注数量;
                                //order.区分 = StockIoEnum.入庫.ToString();
                                //order.事由 = this.remarkTextBox1.Text;
                                ////order.仓库 = storeComboBox.Text;
                                order1.自社コード = Convert.ToInt32(自社コード);
                                order1.状態 = "あり";
                                //order.客户 = this.clientComboBox.Text;
                                receivedList.Add(order1);
                                #endregion

                            }
                        }
                        if (receivedList.Count > 0)
                        {
                            {
                                OrderSqlHelper.UpdateStockState(ctx, receivedList);
                                this.stockiosList.Clear();
                                MessageBox.Show(String.Format("Congratulations, You have {0} items Return successfully!", receivedList.Count));

                            }
                        }

                        ctx.SaveChanges();

                    }
                }

                InitializeOrderData();
            }
            else if (page == 1)
            {




            }



        }

        private List<int> Sec_GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView2);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as t_orderdata;
                order_ids.Add(pendingorder.id受注データ);
            }

            return order_ids;
        }

        private void DanDangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            ApplyFilter2();


        }

        private void ClearSelect_Click(object sender, EventArgs e)
        {
            DanDangComboBox.SelectedIndex = 0;
            PMHZCombox.SelectedIndex = 0;
            GenreNamecomboBox.SelectedIndex = 0;
            ZKZTcomboBox3.SelectedIndex = 0;

        }

        private void PMHZCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter2();
        }

        private void GenreNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter2();
        }

        private void ZKZTcomboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ApplyFilter2();

            ApplyBindSourceFilter(ZKZTcomboBox3.Text);
        }


        private void ApplyBindSourceFilter(string text)
        {
            this.bindingSource1.Filter = null;
            this.bindingSource1.DataSource = this.sortablePendingOrderList;
            if (bindingSource1.Count > 0)
            {
                string filter = "";
                //  filter += "(在庫状態=" + "'" + this.ZKZTcomboBox3.Text + "'" + ")";


                if (this.ZKZTcomboBox3.Text.Length > 0 && this.ZKZTcomboBox3.Text != "不限")
                {
                    filter += "(在庫状態=" + "'" + this.ZKZTcomboBox3.Text + "'" + ")";
                }
                //if (this.storeComboBox.Text.Length > 0 && this.storeComboBox.Text != "不限")
                //{
                //    if (filter.Length > 0)
                //    {
                //        filter += " AND ";
                //    }
                //    // filter += "(店舗名漢字=" + "'" + this.storeComboBox.Text + "'" + ")";
                //    int code = (int)this.storeComboBox.SelectedValue;

                //    filter += "(店舗コード=" + "'" + code.ToString() + "'" + ")";
                //}
                //if (this.shipperComboBox.Text.Length > 0)
                //{
                //    if (filter.Length > 0)
                //    {
                //        filter += " AND ";
                //    }
                //    filter += "(実際配送担当=" + "'" + this.shipperComboBox.Text + "'" + ")";
                //}
                bindingSource1.Filter = filter;
            }
        }


    }
}
