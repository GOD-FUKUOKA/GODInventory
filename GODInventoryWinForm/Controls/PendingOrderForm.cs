﻿using System;
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
    using GODInventory;
    using MySql.Data.MySqlClient;
    using System.Data.SqlClient;

    public partial class PendingOrderForm : Form
    {
        public Size ParentContainerSize { get; set; }

        //  [c1_r1_changed=> new_value,c1_r1=> original_value] ]
        private Hashtable datagrid_changes = null;
        private List<t_stockstate> stockstates;
        private List<v_shipper> shipperList;
        private List<t_itemlist> productList;
        //List<t_orderdata> Findorderdataresults;
        private BindingList<v_stockios> stockiosList;
        int RowRemark = 0;
        int cloumn = 0;

        private IBindingList pendingOrderIBindList;
        private List<v_pendingorder> pendingOrderList;
        private SortableBindingList<v_pendingorder> sortablePendingOrderList;
        private List<v_pendingorder> shipperOrderList;
        //private List<t_shoplist> shopList;
        private SortableBindingList<v_pendingorder> sortablePendingOrderList3;
        private List<t_transports> transportList;
        //mark 20181008
        private List<t_warehouses> warehouseList;
        List<t_transports> FindtransportList;



        public PendingOrderForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;

            this.datagrid_changes = new Hashtable();
            this.pendingOrderList = new List<v_pendingorder>();

            var ctx = entityDataSource1.DbContext as GODDbContext;
            this.stockstates = ctx.t_stockstate.Select(s => s).ToList();
            this.productList = ctx.t_itemlist.Select(s => s).ToList();
            this.transportList = ctx.t_transports.ToList();
            this.warehouseList = ctx.t_warehouses.ToList();



            //shipperList = (from s in ctx.t_shoplist
            //         group s by s.配送担当 into g
            //               select new v_shipper { ShortName = g.Key }).ToList();


            //InitializePager();

            this.訂正理由区分Column.ValueMember = "ID";
            this.訂正理由区分Column.DisplayMember = "FullName";
            this.訂正理由区分Column.DataSource = OrderQuantityChangeReasonRespository.ToList();
            //物流
            //
            //shopList = ctx.t_shoplist.ToList();


            //mark   20181009           
            var transports1 = transportList.Select(s => new {  fullname = s.fullname }).Distinct().ToList();
            var transports2 = transportList.Select(s => new {  fullname = s.fullname }).Distinct().ToList();


            this.transportColumn1.DisplayMember = "fullname";
            this.transportColumn1.ValueMember = "fullname";
            this.transportColumn1.DataSource = transports1;



            //右键选择担当

            for (int i = 0; i < transports2.Count; i++)
            {

                ToolStripItem item = new ToolStripMenuItem();
                item.Name = transports2[i].fullname.ToString();
                item.Text = transports2[i].fullname.ToString();
                item.Click += new EventHandler(toolStripComboBox2_SelectedIndexChanged);
                toolStripMenuItem3.DropDownItems.Add(item);

            }


            //过滤条件添加任意选项
            //shipperCo.Insert(0, new MockEntity { ShortName = "すべて", FullName = "すべて" });
            //this.DanDangComboBox.DisplayMember = "FullName";
            //this.DanDangComboBox.ValueMember = "FullName";
            //this.DanDangComboBox.DataSource = shipperCo.ToList();


            // 传票订正仓库
            var warehouse1 = warehouseList.Select(s => new {   fullname = s.FullName }).Distinct().ToList();
            this.warehousenameColumn.DisplayMember = "fullname";
            this.warehousenameColumn.ValueMember = "fullname";
            this.warehousenameColumn.DataSource = warehouse1;
            // 传送确认仓库
            //var warehouse2 = warehouseList.Select(s => new { fullname = s.FullName }).Distinct().ToList();
            //this.warehousenameColumn2.DisplayMember = "fullname";
            //this.warehousenameColumn2.ValueMember = "fullname";
            //this.warehousenameColumn2.DataSource = warehouse2;




            //右键选择仓库
            for (int i = 0; i < warehouseList.Count; i++)
            {
                //this.toolStripComboBox1.ComboBox.Items.Add(warehouse2[i].fullname);
                ToolStripItem item = new ToolStripMenuItem();
                item.Name = warehouseList[i].FullName;
                item.Text = warehouseList[i].FullName;
                item.Click += new EventHandler(toolStripComboBox1_SelectedIndexChanged);
                toolStripMenuItem1.DropDownItems.Add(item);
            }
            //this.toolStripComboBox1.ComboBox.SelectedIndex = 0;
            //
            var warehouse3 = warehouseList.Select(s => new MockEntity { ShortName = s.ShortName, FullName = s.FullName }).Distinct().OrderBy(s => s.Id).ToList();


            //var PMHZ = orders.Select(s => new MockEntity { Id = s.自社コード, TaxonId = s.ジャンル, ShortName = s.品名漢字, FullName = s.品名漢字 }).Distinct().OrderBy(s => s.Id).ToList();
            //PMHZ.Insert(0, new MockEntity { Id = 0, ShortName = "すべて", FullName = "すべて" });

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

        // 保存對訂單的修改。
        private void saveButton_Click(object sender, EventArgs e)
        {
            // 可以编辑数量的主要是2个界面，伝票訂正界面、出荷内容確認的右键编辑界面
            // 在点击保存按钮的时候，对需要保存的订单做一个检查，
            // 比较一下修改后的数量与　発注数量 字段的值，如果不一致，判断一下 訂正理由区分是否有修改（是否<>0），
            // 如果=0，则提示要求给出订正理由，并等待修改；如果<>0，再执行保存操作
            bool isValid = true;
            string errorMessage = "";
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
                        bool isQtyChanged = (order.実際出荷数量 != pendingorder.実際出荷数量);
                        bool isFeeChanged = (order.運賃 != pendingorder.運賃);
                        bool isWarehouseChanged = (order.warehousename != pendingorder.warehousename);
                        bool isTransportChanged = (order.実際配送担当 != pendingorder.実際配送担当);
                        // 影响运费的字段有 仓库，运输公司，
                        //bool isNewQtyChanged = (order.重量 != pendingorder.重量);

                        //if (isQtyChanged)
                        //{
                        //    if (pendingorder.訂正理由区分 == 0)
                        //    {
                        //        isValid = false;
                        //        errorMessage = "理由が設定されていない伝票があります。訂正してください。";
                        //        //errorMessage = "重量になっています。訂正理由区分を「訂正なし」にしてください。";
                        //        break;
                        //    }
                        //}

                        if (pendingorder.実際出荷数量 == order.発注数量 && pendingorder.訂正理由区分 != 0)
                        {
                            isValid = false;
                            errorMessage = "元の発注数量になっています。訂正理由区分を「訂正なし」にしてください。";
                            break;

                        }

                        if (isQtyChanged)
                        {

                            if (pendingorder.実際出荷数量 > order.発注数量)
                            {
                                isValid = false;
                                errorMessage = "発注数量（数值）より多くなっています。発注数量以下に修正してください。";
                                break;
                            }
                            else if (pendingorder.実際出荷数量 != order.発注数量 && pendingorder.訂正理由区分 == 0)
                            {
                                isValid = false;
                                errorMessage = "理由が設定されていない伝票があります。訂正してください。";
                                //errorMessage = "数量変更の理由をつけてください！";
                                break;
                            }
                        }


                        //需要修改的字段为: “口数” “发注数量” “担当” “形态”
                        if (isQtyChanged)
                        {

                            // 修正相应 金額
                            order.実際出荷数量 = pendingorder.実際出荷数量;
                            order.納品口数 = pendingorder.納品口数;
                            var product = productList.FirstOrDefault(i => i.自社コード == order.自社コード);

                            OrderSqlHelper.AfterOrderQtyChanged(order, product);

                        }
                        else {
                            // 重新计算运费
                            if (isWarehouseChanged || isTransportChanged) {

                                pendingorder.運賃 = OrderSqlHelper.ComputeFreight(pendingorder);
                            }
                            
                        }



                        order.訂正理由区分 = pendingorder.訂正理由区分;

                        order.発注形態名称漢字 = pendingorder.発注形態名称漢字;
                        order.備考 = pendingorder.備考;
                        order.納品指示 = pendingorder.納品指示;
                        order.運賃 = pendingorder.運賃; //保存用户直接对运费的修改
                        if (isWarehouseChanged)
                        {
                            order.warehousename = pendingorder.warehousename;
                            order.warehouse_id = pendingorder.warehouse_id;
                        }
                        if (isTransportChanged)
                        {
                            order.実際配送担当 = pendingorder.実際配送担当;
                            order.transport_id = pendingorder.transport_id;
                        }

                    }
                    if (isValid)
                    {
                        ctx.SaveChanges();
                        pager1.Bind();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
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

        #region 订单订正GridView

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
            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);
            string cellChangedKey = GetCellKey(e.RowIndex, e.ColumnIndex, true);
            var newValue = cell.Value;
            var originalValue = datagrid_changes[cellKey];
            // originalValue could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", originalValue, newValue, originalValue == newValue, originalValue.GetType(), newValue.GetType(), newValue.Equals(originalValue));
            if (newValue == null && originalValue == null)
            {
                datagrid_changes.Remove(cellChangedKey);
            }
            else if ((newValue == null && originalValue != null) || (newValue != null && originalValue == null) || !newValue.Equals(originalValue))
            {
                datagrid_changes[cellChangedKey] = newValue;
            }
            else
            {
                datagrid_changes.Remove(cellChangedKey);
            }
            //実際出荷数量修改
            if (実際出荷数量Column.Index == e.ColumnIndex)
            {
                var order = cell.OwningRow.DataBoundItem as v_pendingorder;
                //控制 実際出荷数量 <発注数量

                int new_qty = (int)cell.Value;
                if (!EditOrderQuantity(order, new_qty))
                {
                    MessageBox.Show("実際出荷数量 >発注数量,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (納品口数Column.Index == e.ColumnIndex)
            {
                var order = cell.OwningRow.DataBoundItem as v_pendingorder;
                int new_qty = (int)cell.Value * order.最小発注単位数量;

                if (!EditOrderQuantity(order, new_qty))
                {
                    MessageBox.Show("実際出荷数量 >発注数量,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


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

            if (datagrid_changes.ContainsKey(cellChangedKey) && cellChangedKey != "_changed")
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private void ordersTabPage_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 初始化数据

        private int InitializeDataSource(string shipper = "すべて", string stockState = "すべて", string genre = "すべて", string product = "すべて", string county = "すべて", string storeName = "すべて")
        {
            this.datagrid_changes.Clear();
            this.pendingOrderList.Clear();

            var cq = OrderSqlHelper.PendingOrderQuery(entityDataSource1);
            var count = cq.Count();

            if (count > 0)
            {

                
//                string sql = @" SELECT o.*, o.`原単価(税抜)` as `原単価_税抜_`, o.`原単価(税込)` as `原単価_税込_`, o.`売単価（税抜）` as `売単価_税抜_`, o.`売単価（税込）` as `売単価_税込_`,
//g.`ジャンル名` as `GenreName`, k.`在庫数` as `在庫数`, s.`売上ランク`, p.`厳しさ`, p.`欠品カウンター`
//FROM t_orderdata o
//INNER JOIN t_genre g  on o.ジャンル = g.idジャンル
//INNER JOIN t_shoplist s  on o.法人コード = s.customerId AND  o.店舗コード = s.店番 
//INNER JOIN t_pricelist p on  o.自社コード = p.自社コード AND  o.店舗コード = p.店番 
//LEFT JOIN t_stockstate k on  o.自社コード = k.自社コード AND  o.warehouse_id = k.WarehouseId 
//WHERE o.Status ={0}
//ORDER BY o.受注日 desc, o.Status, o.transport_id,o.warehouse_id, o.県別, o.店舗コード, o.ＪＡＮコード,  o.伝票番号 LIMIT {1} OFFSET {2};";


                // create BindingList (sortable/filterable)
                int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);

                pendingOrderList = OrderSqlHelper.GetPendingOrderList(entityDataSource1, pager1.PageSize, offset);

                UpdateStockState(pendingOrderList);

                sortablePendingOrderList = new SortableBindingList<v_pendingorder>(pendingOrderList);
            }
            else
            {
                pendingOrderIBindList = null;
                sortablePendingOrderList = null;
            }


            InitializeOrderData(shipper, stockState, genre, product, county, storeName);

            return count;
        }

        private int InitializeOrderData(string shipper, string stockState, string genre, string product, string county, string storeName)
        {
            // 过滤优先顺序
            // 配送担当 > 库存状态 > 产品分类 > 产品
            this.bindingSource1.DataSource = null;
            // 记录DataGridView改变数据          

            this.bindingSource1.DataSource = sortablePendingOrderList;

            dataGridView1.DataSource = this.bindingSource1;

            if (pendingOrderList.Count > 0)
            {
                // 初始化配送担当
                var shippers = pendingOrderList.Select(s => s.実際配送担当).Distinct().ToList();
                shippers.Insert(0, "すべて");

                this.DanDangComboBox.DataSource = shippers;

                // 初始化仓库
                var warehouses = pendingOrderList.Select(s => s.warehousename).Distinct().ToList();
                warehouses.Insert(0, "すべて");
                this.warehouseComboBox.DataSource = warehouses;
                this.warehouseComboBox.Text = shipper;




                // PageEvent 时, stockState 在初始化为 “”， 需设置为 “すべて”
                this.ZKZTcomboBox3.Text = (stockState.Length == 0 ? "すべて" : stockState);
                this.genreComboBox.Text = genre;
                this.productComboBox.Text = product;
                this.countyComboBox1.Text = county;
                this.storeComboBox.Text = storeName;

            }


            return 0;
        }

        private void InitializeShipperOrderList(string warhoseName = null)
        {
            shipperOrderList = new List<v_pendingorder>();

            this.shipperOrderList.Clear();
            this.bindingSource2.DataSource = null;
            // 记录DataGridView改变数据
            //this.bindingSource2.DataSource = sortablePendingOrderList3;
            //dataGridView3.DataSource = this.bindingSource2;

            //this.shipperComboBox.DisplayMember = "ShortName";
            //this.shipperComboBox.ValueMember = "ShortName";
            //this.shipperComboBox.DataSource = shipperList;

            //https://dev.mysql.com/doc/refman/5.7/en/group-by-handling.html
            //http://stackoverflow.com/questions/23921117/disable-only-full-group-by
            //handle SET SESSION sql_mode='ANSI';


            //            string sql = @"SELECT `id受注データ`,`受注日`,`店舗コード`,
            //       `店舗名漢字`,`伝票番号`,`社内伝番`,`ジャンル`,`品名漢字`,`規格名漢字`, `納品口数`, `実際出荷数量`, `重量`, `実際配送担当`,`県別`, `納品指示`, `備考`
            //     FROM t_orderdata
            //     WHERE  `Status`={0} AND ( (`ジャンル`<> 1003) OR ( `ジャンル`= 1003 AND `実際配送担当` != '丸健'))
            //     UNION ALL
            //     SELECT  min(`id受注データ`), min(`受注日`), min(`店舗コード`), min(`店舗名漢字`),`社内伝番` as `伝票番号`,`社内伝番`,`ジャンル`, '二次製品' as `品名漢字` , '' as `規格名漢字`, min(`最大行数`) as `納品口数`, sum(`重量`) as `実際出荷数量`, sum(`重量`) as `重量`, min(`実際配送担当`),min(`県別`), min(`納品指示`), min(`備考`)
            //     FROM t_orderdata
            //     WHERE `Status`={0} AND `ジャンル`= 1003 AND `社内伝番` >0 AND `実際配送担当` = '丸健'
            //     GROUP BY `社内伝番`
            //     ORDER BY `実際配送担当` ASC,`県別` ASC,`店舗コード` ASC,`受注日` ASC,`伝票番号` ASC;";

            string sql2 = @"SELECT `id受注データ`,`受注日`,`店舗コード`, `納品場所コード`, `warehousename`,
       `店舗名漢字`,`伝票番号`,`社内伝番`,`ジャンル`,`品名漢字`,`規格名漢字`, `納品口数`, `実際出荷数量`, `重量`, `実際配送担当`,`県別`, `納品指示`,`発注形態名称漢字`, `備考`, `社内伝番処理`
     FROM t_orderdata
     WHERE  `Status`={0}";
     //ORDER BY `実際配送担当` ASC,`県別` ASC,`店舗コード` ASC,`受注日` ASC,`伝票番号` ASC;";

            this.shipperOrderList = OrderSqlHelper.GetNotifiedOrderList(this.entityDataSource2);
            this.bindingSource2.DataSource = null;
            this.bindingSource2.DataSource = sortablePendingOrderList3;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.DataSource = this.bindingSource2;

            #region 初始化下拉
            // 担当
            //var transports3 = shipperOrderList.Select(s => new MockEntity { Id = s.自社コード, ShortName = s.実際配送担当, FullName = s.実際配送担当 }).Distinct().OrderBy(s => s.Id).ToList();
            //transports3.Insert(0, new MockEntity { Id = 0, ShortName = "すべて", FullName = "すべて" });
            //this.shipperComboBox2.DisplayMember = "FullName";
            //this.shipperComboBox2.ValueMember = "Id";
            //this.shipperComboBox2.DataSource = transports3;

            //仓库, 仓库过滤比较特殊，warehouseComboBox2.Text 是 仓库名称(X:这个仓库有多少订单)

            initializeWarehouseComboBoxForTransport();

            #endregion
            
            if (warhoseName == null)
            {
                warehouseComboBox2.SelectedIndex = 0;
            }
            else
            {
                // 用户退单后刷新
                this.warehouseComboBox2.SelectedValue = warhoseName;            
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

        /// <summary>
        /// 发送给运输公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show(" まず伝票を選択してください.");
            }
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var orders = GetPendingOrdersBySelectedGridCell();

            if (orders.Count() > 0)
            {
                if (MessageBox.Show("選択された伝票をキャンセル?", "確認メッセージ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var orderIds = orders.Select(o => o.id受注データ).ToList();

                    OrderSqlHelper.CancelOrders(orderIds);
                    pager1.Bind();
                }
            }
            else
            {
                MessageBox.Show("先ずは、注文リストには行を選択してください。");
            }
        }

        #endregion

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
            var form = new CreateOrderForm();
            form.ShowDialog();

            //if (form.newOrderList != null && form.newOrderList.Count()>0)
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
            return rows;
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
            string county = countyComboBox1.Text;
            string store = this.storeComboBox.Text;

            int orderCount = InitializeDataSource(shipper, stockState, genre, product, county, store);

            var direction = ListSortDirection.Ascending;
            if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
            {
                direction = ListSortDirection.Descending;
            }
            if (originalSortedColumn != null)
            {
                // 需检查是否有数据，否则排序会有异常。
                if (this.dataGridView1.RowCount > 0)
                {
                    this.dataGridView1.Sort(originalSortedColumn, direction);
                }
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


        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void btlogin_Click(object sender, EventArgs e)
        {

        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (e.TabPage == toShipperTabPage)
            {

                InitializeShipperOrderList();
            }
        }



        #region 修改键生成
        private string GetCellKey(int rowIndex, int columnIndex, bool forChanged)
        {
            return GetCellKey(rowIndex, columnIndex) + "_changed";
        }

        private string GetCellKey(int rowIndex, int columnIndex)
        {
            //if (rowIndex < 1)
            //    return "";

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
            else if (ZKZTcomboBox3.SelectedIndex != 0)
            {
                ZKZTcomboBox3.SelectedIndex = 0;
            }
            else if (genreComboBox.SelectedIndex != 0)
            {
                genreComboBox.SelectedIndex = 0;
            }
            else if (productComboBox.SelectedIndex != 0)
            {
                productComboBox.SelectedIndex = 0;
            }
            else if (countyComboBox1.SelectedIndex != 0)
            {
                countyComboBox1.SelectedIndex = 0;
            }
            else if (storeComboBox.SelectedIndex != 0)
            {
                storeComboBox.SelectedIndex = 0;
            }
            else if (warehouseComboBox.SelectedIndex != 0)
            {
                warehouseComboBox.SelectedIndex = 0;
            }

        }

        // 选择配送担当过滤条件后，重置仓库等相关过滤条件
        // 即配送担当和其它过滤条件保持独立
        private void DanDangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combox = sender as ComboBox;
            string name = combox.Text;

            ApplyFilter5(name);

        }

        //在库状态
        private void ZKZTcomboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = warehouseComboBox.Text;
            string stock = ZKZTcomboBox3.Text;

            var orders = GetOrdersByShipper(shipper, stock);

            InitializeGenreComboBox(orders);
        }



        //分类名称
        private void GenreNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = warehouseComboBox.Text;
            string genre = genreComboBox.Text;
            string stock = ZKZTcomboBox3.Text;
            var orders = GetOrdersByShipper(shipper, stock, genre);

            // 品名漢字
            InitializeProductComboBox(orders);
        }
        // 品名汉字
        private void PMHZCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = warehouseComboBox.Text;
            string stock = ZKZTcomboBox3.Text;
            string genre = genreComboBox.Text;
            string product = productComboBox.Text;
            var orders = GetOrdersByShipper(shipper, stock, genre, product);

            InitializeCountyComboBox(orders);
        }

        //县别
        private void countyComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = warehouseComboBox.Text;
            string stock = ZKZTcomboBox3.Text;
            string genre = genreComboBox.Text;
            string product = productComboBox.Text;
            string county = countyComboBox1.Text;
            var orders = GetOrdersByShipper(shipper, stock, genre, product, county);

            //联动 店名
            InitializeshopsComboBox(orders);

        }
        //店名 
        private void storeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string shipper = warehouseComboBox.Text;
            string genre = genreComboBox.Text;
            string product = productComboBox.Text;
            string stockState = ZKZTcomboBox3.Text;
            string county = countyComboBox1.Text;
            int storeId = (int)storeComboBox.SelectedValue;
            ApplyFilter4(shipper, stockState, genre, product, county, storeId);

        }

        private void InitializeStockState(List<v_pendingorder> orders)
        {
            // stockState
            var stockStates = orders.Select(s => s.在庫状態).Distinct().ToList();
            stockStates.Insert(0, "すべて");
            this.ZKZTcomboBox3.DataSource = stockStates;
        }

        private void InitializeGenreComboBox(List<v_pendingorder> orders)
        {
            // GenreName
            var GenreName = orders.Select(s => s.GenreName).Distinct().ToList();
            GenreName.Insert(0, "すべて");

            this.genreComboBox.DataSource = GenreName;
        }

        private void InitializeProductComboBox(List<v_pendingorder> orders)
        {
            // 品名漢字
            var PMHZ = orders.Select(s => new MockEntity { Id = s.自社コード, TaxonId = s.ジャンル, ShortName = s.品名漢字, FullName = s.品名漢字 }).Distinct().OrderBy(s => s.Id).ToList();
            PMHZ.Insert(0, new MockEntity { Id = 0, ShortName = "すべて", FullName = "すべて" });
            this.productComboBox.DisplayMember = "FullName";
            this.productComboBox.ValueMember = "Id";
            this.productComboBox.DataSource = PMHZ;
        }

        private void InitializeCountyComboBox(List<v_pendingorder> orders)
        {
            // County
            var counties = orders.Select(s => s.県別).Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
            counties.Insert(0, "すべて");

            this.countyComboBox1.DataSource = counties;

        }

        private void InitializeshopsComboBox(List<v_pendingorder> orders)
        {
            // 店名列表
            var shops = orders.Select(s => new MockEntity { Id = s.店舗コード, FullName = s.店舗名漢字 }).Distinct().OrderBy(s => s.FullName).ToList();
            shops.Insert(0, new MockEntity { Id = 0, FullName = "すべて" });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = shops;
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

        private void ApplyFilter4(string warehouse = "", string stock = "", string genre = "", string product = "", string county = "", int storeId = 0)
        {
            // 重置 物流公司过滤条件
            if (DanDangComboBox.SelectedIndex >= 0)
            {
                DanDangComboBox.SelectedIndex = 0;
            }

            var originalSortOrder = this.dataGridView1.SortOrder;
            var originalSortedColumn = this.dataGridView1.SortedColumn;

            bindingSource1.DataSource = null;
            var filteredOrderList = pendingOrderList;
            datagrid_changes.Clear();


            if (warehouse.Length > 0 && warehouse != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.warehousename == warehouse);
            }
            if (county.Length > 0 && county != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.県別 == county);
            }

            if (product.Length > 0 && product != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.品名漢字 == product);
            }
            if (genre.Length > 0 && genre != "すべて")
            {

                filteredOrderList = filteredOrderList.FindAll(o => o.GenreName == genre);

            }
            if (stock.Length > 0 && stock != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.在庫状態 == stock);
            }
            if (storeId > 0)
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.店舗コード == storeId);
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
        private void ApplyFilter5(string cangku = "")
        {
            // 重置 其它过滤条件
            if (warehouseComboBox.SelectedIndex >= 0)
            {
                warehouseComboBox.SelectedIndex = 0;
            }
            else if (ZKZTcomboBox3.SelectedIndex >= 0)
            {
                ZKZTcomboBox3.SelectedIndex = 0;
            }
            else if (genreComboBox.SelectedIndex >= 0)
            {
                genreComboBox.SelectedIndex = 0;
            }
            else if (productComboBox.SelectedIndex >= 0)
            {
                productComboBox.SelectedIndex = 0;
            }
            else if (countyComboBox1.SelectedIndex >= 0)
            {
                countyComboBox1.SelectedIndex = 0;
            }
            else if (storeComboBox.SelectedIndex >= 0)
            {
                storeComboBox.SelectedIndex = 0;
            }



            var originalSortOrder = this.dataGridView1.SortOrder;
            var originalSortedColumn = this.dataGridView1.SortedColumn;

            bindingSource1.DataSource = null;
            var filteredOrderList = pendingOrderList;
            datagrid_changes.Clear();

            if (cangku.Length > 0 && cangku != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.実際配送担当 == cangku);
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
            var grouped_orders = orders.GroupBy(o => new { 自社コード = o.自社コード, 実際配送担当 = o.実際配送担当 }, o => o);
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


        private List<v_pendingorder> GetOrdersByShipper(string warehouse, string stockState = "", string genre = "", string product = "", string county = "")
        {
            List<v_pendingorder> orders = pendingOrderList;
            if (warehouse != "すべて")
            {
                orders = orders.FindAll(o => o.warehousename == warehouse);
            }

            if (stockState.Length > 0 && stockState != "すべて")
            {
                orders = orders.FindAll(o => o.在庫状態 == stockState);
            }

            if (genre.Length > 0 && genre != "すべて")
            {
                orders = orders.FindAll(o => o.GenreName == genre);
            }

            if (product.Length > 0 && product != "すべて")
            {
                orders = orders.FindAll(o => o.品名漢字 == product);
            }

            if (county.Length > 0 && county != "すべて")
            {
                orders = orders.FindAll(o => o.県別 == county);
            }

            return orders;
        }

        #endregion


        #region 退单功能

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string selectedwarehouse = getSelectWarehouseNameForTransport();

            List<v_pendingorder> orders = new List<v_pendingorder>();
            for (int i = 0; i < dataGridView3.SelectedRows.Count; i++)
            {
                var order = dataGridView3.SelectedRows[i].DataBoundItem as v_pendingorder;
                orders.Add(order);
            }

            RollbackOrder(orders);

            InitializeShipperOrderList(selectedwarehouse);
            // 更新待處理訂單列表
            pager1.Bind();
        }


        private void RollbackOrder(List<v_pendingorder> pendingOrders)
        {
            using (var ctx = new GODDbContext())
            {
                var orderIds = pendingOrders.Select(o => o.id受注データ);

                var orderList = (from t_orderdata o in ctx.t_orderdata
                                 where orderIds.Contains(o.id受注データ)
                                 select o).ToList();
                var stockrecList = (from t_stockrec s in ctx.t_stockrec
                                    where orderIds.Contains(s.OrderId)
                                    select s).ToList();

                foreach (var order in orderList)
                {
                    //二次制品订单？
                    order.社内伝番 = 0;
                    order.配送担当受信 = false;
                    order.配送担当受信時刻 = null;
                    order.Status = OrderStatus.Pending;
                }

                ctx.t_stockrec.RemoveRange(stockrecList);
                ctx.SaveChanges();
                OrderSqlHelper.UpdateStockState(ctx, stockrecList);
            }
        }

        #endregion

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            int total = 0;
            int weight = 0;
            for (int i = 0; i < count; i++)
            {
                var order = dataGridView1.SelectedRows[i].DataBoundItem as v_pendingorder;
                total += order.実際出荷数量;
                weight += order.重量;
            }
            selectedRowsLabel.Text = String.Format("選択中の数量合計: {0} 重量合計: {1}", total, weight);
        }

        /// <summary>
        /// 传送处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<v_pendingorder> orders = new List<v_pendingorder>();
            string transportName = shipperComboBox2.Text;
            string warehouseName = getSelectWarehouseNameForTransport();
            for (int i = 0; i < dataGridView3.SelectedRows.Count; i++)
            {
                var order = dataGridView3.SelectedRows[i].DataBoundItem as v_pendingorder;
                orders.Add(order);
            }

            if (orders.Count() > 0)
            {

                using (var ctx = new GODDbContext())
                {
                    OrderSqlHelper.NotifyShipper(ctx, orders, transportName);
                }
                this.shipperOrderList.RemoveAll(o => orders.Contains(o));
                // this.dataGridView3.DataSource = this.shipperOrderList.FindAll(o => o.実際配送担当 == transportName); ;
                //
                this.bindingSource2.DataSource = this.shipperOrderList.FindAll(o => o.warehousename == warehouseName);

                initializeWarehouseComboBoxForTransport();

                MessageBox.Show(String.Format(" {0} 件転送処理しました!", orders.Count));
            }

        }

        //验证 新的数量是否有效， 実際出荷数量 >発注数量
        public bool EditOrderQuantity(v_pendingorder order, int new_qty)
        {
            if (order.発注数量 < new_qty) return false;

            order.実際出荷数量 = new_qty;
            if (order.最小発注単位数量 > 0)
            {
                order.納品口数 = (int)(order.実際出荷数量 / order.最小発注単位数量);
            }

            var product = productList.FirstOrDefault(i => i.自社コード == order.自社コード);
            OrderSqlHelper.AfterOrderQtyChanged(order, product);

            return true;
        }

        private void deleteFaxOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            var selectedRows = this.dataGridView1.SelectedRows;
            if (selectedRows.Count > 0)
            {
                // 是否删除FAX订单
                if (MessageBox.Show("伝票を完全に廃棄（削除）します。よろしいですか？", "伝票を廃棄", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (var i = 0; i < selectedRows.Count; i++) {

                        v_pendingorder order = selectedRows[i].DataBoundItem as v_pendingorder;
                        if (order.入力区分 == 1)
                        {
                            count = OrderSqlHelper.DeleteFaxOrder(order.id受注データ);
                        }                    
                    }

                }
            }
            if (count > 0)
            {
                pager1.Bind();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bool handle;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(DBNull.Value))
                {
                    handle = true;
                }
                else
                    handle = false;
                e.Cancel = handle;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        
        private int warehouselistBox()
        {

            var oids = GetOrderIdsBySelectedGridCell();

            return (Int32)oids[0];

        }

        private void xlsxButton1_Click(object sender, EventArgs e)
        {
            var importForm = new ImportPrendingOrderForm();
            importForm.ShowDialog();

            if (importForm.SavedOrderCount > 0) {
                pager1.Bind();
            }

        }

        // 选择了仓库菜单
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1)
                return;
            var rows = this.dataGridView1.SelectedRows;

            if (rows.Count > 0)
            {
                ToolStripItem item = (ToolStripItem)sender;
                var warehouse = this.warehouseList.Find(w => w.FullName == item.Name);

                for (var i = 0; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var rowIndex = row.Index;
                    var columnIndex = warehousenameColumn.Index;

                    var cell = row.Cells[columnIndex];

                    string cellKey = GetCellKey(rowIndex, columnIndex);
                    string cellChangedKey = GetCellKey(rowIndex, columnIndex, true);
                    var newCellValue = item.Name;
                    var originalCellValue = datagrid_changes[cellKey] != null ? datagrid_changes[cellKey] : cell.Value;

                    bool changed = isCellValueChanged(originalCellValue, newCellValue);

                    if (changed)
                    {
                        this.datagrid_changes[cellChangedKey] = newCellValue;
                        this.datagrid_changes[cellKey] = originalCellValue;
                        v_pendingorder order = row.DataBoundItem as v_pendingorder;
                        order.warehousename = newCellValue;
                        order.warehouse_id = warehouse.Id;
                    }
                }
                //// if (MessageBox.Show("選択された伝票をキャンセル?", "確認メッセージ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //{
                //    var orderIds = orders.Select(o => o.id受注データ).ToList();

                //    for (int i = 0; i < orderIds.Count; i++)
                //    {
                //        List<v_pendingorder> mlist = pendingOrderList.FindAll(o => o.id受注データ != null && o.id受注データ == orderIds[i]).ToList();

                //        mlist[0].warehousename = txname;
                //    }

                //    sortablePendingOrderList = new SortableBindingList<v_pendingorder>(pendingOrderList);
                //    this.bindingSource1.DataSource = sortablePendingOrderList;
                //    dataGridView1.DataSource = this.bindingSource1;
                //    //  pager1.Bind();
                //}
            }
            else
            {
                MessageBox.Show("先ずは、注文リストには行を選択してください。");
            }
        }

        // 选择了物流公司菜单
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1)
                return;

            var rows = this.dataGridView1.SelectedRows;

            if (rows.Count > 0)
            {

                ToolStripItem item = (ToolStripItem)sender;
                var transport = this.transportList.Find(w => w.fullname == item.Name);

                for (var i = 0; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var rowIndex = row.Index;
                    var columnIndex = transportColumn1.Index;

                    var cell = row.Cells[columnIndex];

                    string cellKey = GetCellKey(rowIndex, columnIndex);
                    string cellChangedKey = GetCellKey(rowIndex, columnIndex, true);
                    var newCellValue = item.Name;
                    var originalCellValue = datagrid_changes[cellKey] != null ? datagrid_changes[cellKey] : cell.Value;

                    bool changed = isCellValueChanged(originalCellValue, newCellValue);

                    if (changed)
                    {
                        this.datagrid_changes[cellChangedKey] = newCellValue;
                        this.datagrid_changes[cellKey] = originalCellValue;
                        v_pendingorder order = row.DataBoundItem as v_pendingorder;
                        order.実際配送担当 = newCellValue;
                        order.transport_id = transport.id;
                    }
                }
            }
            else
            {
                MessageBox.Show("先ずは、注文リストには行を選択してください。");
            }
        }

        private void 倉庫comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combox = sender as ComboBox;
            string shipper = combox.Text;
            var orders = GetOrdersByShipper(shipper);

            InitializeStockState(orders);

        }

        #region 订单传送界面条件过滤

        // 选择了物流公司
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // skip first time initialization
            var transportname = shipperComboBox2.SelectedValue != null ? shipperComboBox2.SelectedValue.ToString() : string.Empty;
            ApplyFilter6( getSelectWarehouseNameForTransport(), transportname);

        }

        // 选择了仓库
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (shipperOrderList == null || shipperOrderList.Count == 0)
            {

                return;
            }
            var combox = sender as ComboBox;
            string warehouseName = combox.SelectedValue.ToString();
            var orders = shipperOrderList.FindAll(o => o.warehousename == warehouseName);

            // 担当
            var transports3 = orders.Select(s =>  s.実際配送担当 ).Distinct().ToList();

            if (transports3.Count > 0)
            {
                this.shipperComboBox2.DataSource = transports3;
            }
            else {
                // 触发comboBox1_SelectedIndexChanged
                this.shipperComboBox2.DataSource = null;            
            }

          
        }
        
        private void ApplyFilter6(string cangku = "", string transport = "")
        {
            

            var originalSortOrder = this.dataGridView3.SortOrder;
            var originalSortedColumn = this.dataGridView3.SortedColumn;

            var filteredOrderList = shipperOrderList;

            if (cangku.Length > 0 && cangku != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.warehousename == cangku);
            }
            if (transport.Length > 0 && transport != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.実際配送担当 == transport);
            }

            sortablePendingOrderList = new SortableBindingList<v_pendingorder>(filteredOrderList);

            this.bindingSource2.DataSource = null;
            this.bindingSource2.DataSource = sortablePendingOrderList;

            var direction = ListSortDirection.Ascending;
            if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
            {
                direction = ListSortDirection.Descending;
            }
            if (originalSortedColumn != null)
            {
                this.dataGridView3.Sort(originalSortedColumn, direction);
            }



        }

        //初始化传送界面仓库的过滤条件
        private void initializeWarehouseComboBoxForTransport() {
            var warehouses = this.warehouseList.Select(s =>{  
                int i = this.shipperOrderList.Count( o=>o.warehouse_id == s.Id);

                return new { id = s.Id, name = s.FullName, title = string.Format( "{0}({1})", s.FullName, i) };
            
            }).ToList();

            this.warehouseComboBox2.DisplayMember = "title";
            this.warehouseComboBox2.ValueMember = "name";
            this.warehouseComboBox2.DataSource = warehouses;
        
        }

        private string getSelectWarehouseNameForTransport() {

            return warehouseComboBox2.SelectedValue.ToString();
        }

        #endregion

        private bool isCellValueChanged(Object originalValue, Object newValue)
        {

            return ((newValue == null && originalValue != null) || (newValue != null && originalValue == null) || !newValue.Equals(originalValue));

        }

        private void dataGridView3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

    }
}
