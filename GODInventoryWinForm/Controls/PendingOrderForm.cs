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

            var genre = ( from g in ctx.t_genre
                          where g.ジャンル名 == "二次製品" 
                              select g).FirstOrDefault();
            ErCiZhiPinId = ( genre != null ? genre.idジャンル : 0 );

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

        private void InitializeShipperOrderList() {
            this.shipperComboBox.SelectedIndex = 0;
            //this.shipperComboBox.DisplayMember = "ShortName";
            //this.shipperComboBox.ValueMember = "ShortName";
            //this.shipperComboBox.DataSource = shipperList;
            
            string sql = @"SELECT `id受注データ`,`受注日`,`店舗コード`,
       `店舗名漢字`,`伝票番号`,`ジャンル`,`品名漢字`,`規格名漢字`, `口数`, `発注数量`, `重量`, `実際配送担当`,`県別`, `納品指示`, `備考`
     FROM t_orderdata
     WHERE  `Status`={0} AND `ジャンル`<> 6
     UNION ALL
     SELECT  `id受注データ`, `受注日`,`店舗コード`,`店舗名漢字`,`社内伝番` as `伝票番号`,`ジャンル`, '二次製品' as `品名漢字` , '' as `規格名漢字`, `最大行数` as `口数`, sum(`重量`) as `発注数量`, sum(`重量`) as `重量`, `実際配送担当`,`県別`, `納品指示`, `備考`
     FROM t_orderdata
     WHERE `Status`={0} AND `ジャンル`= 6 AND `社内伝番` IS NOT NULL
     GROUP BY `社内伝番`
     ORDER BY `実際配送担当` ASC,`県別` ASC,`店舗コード` ASC,`受注日` ASC,`伝票番号` ASC";

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
                        order.発注数量 = pendingorder.発注数量;
                        order.口数 = pendingorder.口数;
                        order.重量 = pendingorder.重量;
                        order.原価金額_税抜_ = pendingorder.原価金額_税抜_;
                        order.発注形態名称漢字 = pendingorder.発注形態名称漢字;
                        order.実際配送担当 = pendingorder.実際配送担当;
                        order.備考 = "発注形態配送担当数量変更";
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
            // 记录DataGridView改变数据
            this.datagrid_changes = new Hashtable();

            //var ctx = entityDataSource1.DbContext as GODDbContext;
            //var stockstates = ctx.t_stockstate.Select(s => s).ToList();
            var cq = OrderSqlHelper.PendingOrderQuery(entityDataSource1);
            var count = cq.Count();

            if (count > 0)
            {
                string sql = @" SELECT o.*, g.`ジャンル名` as `GenreName`, K.`在庫数` as `在庫数`  from t_orderdata o
INNER JOIN t_genre g  on o.ジャンル = g.idジャンル
LEFT JOIN t_stockstate k on  o.自社コード = k.自社コード AND  o.実際配送担当 = k.ShipperName 
WHERE o.Status ={0}
ORDER BY o.Status, o.実際配送担当, o.県別, o.店舗コード, o.ＪＡＮコード, o.受注日, o.伝票番号 LIMIT {1} OFFSET {2};";

                //var q = OrderSqlHelper.PendingOrderQueryEx(entityDataSource1);
                //// 分页
                //if (pager1.PageCurrent > 1)
                //{
                //    q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
                //}
                //q = q.Take(pager1.OffSet(pager1.PageCurrent));

                // create BindingList (sortable/filterable)
                int offset = ( pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0 );
                this.pendingOrderList = entityDataSource1.DbContext.Database.SqlQuery<v_pendingorder>(sql, OrderStatus.Pending, pager1.PageSize, offset).ToList();

                // count 计算t_orderdata 表， list 是 orderdata join itemlist join stockstate
                // 所以有可能 bindinglist is null 

                IEnumerable<IGrouping<int, v_pendingorder>> grouped_orders = pendingOrderList.GroupBy(o => o.自社コード, o => o);
                foreach (var gos in grouped_orders)
                {
                    int total = 0;

                    foreach (var o in gos)
                    {
                        total += o.発注数量;

                        if (o.在庫数 >= total)
                        {
                            o.在庫状態 = "あり";
                        }
                        else if (o.在庫数 > o.口数)
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
            }
            else
            {
                this.bindingSource1.DataSource = null;
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
            var oids = GetOrderIdsBySelectedGridCell();

            if (oids.Count() > 0)
            {
                OrderSqlHelper.SendOrderToShipper(oids);
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
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(社内伝番>" + 0 + ")";
            }
            //不读取 canel 的订单

            filter += "(キャンセル<>" + "no" + ")";

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
        private List<int> GetOrderIdsBySelectedGridCell3()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView3);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as v_pendingorder;
                order_ids.Add(pendingorder.id受注データ);
            }

            return order_ids;
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
                    temp.ジャンル = Convert.ToInt16( o.ジャンル );
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

            if (e.TabPage == toShipperTabPage) {

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

    }
}
