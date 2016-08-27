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

        //  [c1_r1_changed=> new_value,c1_r1=> original_value] ]
        private Hashtable datagrid_changes = null;
        private List<t_stockstate> stockstates;
        List<t_orderdata> Findorderdataresults;
        private CreateOrderForm NewOrdersForm;
        int RowRemark = 0;
        int cloumn = 0;
        private string id受注データdemo;
        private List<t_orderdata> orders1;
        private List<t_shoplist> shopList;
        private BindingList<v_pendingorder> orderList;
        private List<t_warehouses> warehouseList;
        private List<v_pendingorder> orders11 = null;
        private List<v_pendingorder> WanJianorders11 = null;
        public PendingOrderForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            var ctx = entityDataSource1.DbContext as GODDbContext;
            this.stockstates = ctx.t_stockstate.Select(s => s).ToList();
            warehouseList = ctx.t_warehouses.ToList();
            warehouseList.Insert(0, new t_warehouses() { Id = 0, FullName = WarehouseRespository.OptionTextAll });
            this.storeComboBox.DisplayMember = "FullName";
            this.storeComboBox.ValueMember = "Id";
            this.storeComboBox.DataSource = warehouseList;


            InitializePager();

            ECRead(ctx);
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = orderList;

            //丸健
            丸健Read(ctx);
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.DataSource = WanJianorders11;



        }

        private void ECRead(GODDbContext ctx)
        {
            orders1 = new List<t_orderdata>();
            shopList = new List<t_shoplist>();
            orderList = new BindingList<v_pendingorder>();
            orders11 = new List<v_pendingorder>();

            #region 二次製品
            //            string qtyFormat = @"SELECT s.* FROM t_orderdata s
            //left JOIN t_shoplist i on i.`店番` = s.`店舗コード`
            //WHERE (s.キャンセル = 'no');";

            string qtyFormat = @"SELECT s.* FROM t_orderdata s
left JOIN t_shoplist i on i.`店番` = s.`店舗コード`
WHERE (s.キャンセル = 'no'&& s.一旦保留 = false && s.ジャンル = '6' && s.社内伝番 is null );";

            orders11 = ctx.Database.SqlQuery<v_pendingorder>(qtyFormat).ToList();

            //计算最后的ID
            int num = 1;

            var last_order = (from s in ctx.t_orderdata
                              orderby s.発注日 descending, s.社内伝番 descending
                              select s).FirstOrDefault();
            if (last_order != null)
            {
                if (last_order.社内伝番 != null && last_order.社内伝番 != 0)
                    num = Convert.ToInt32(last_order.社内伝番) + 1;
                else
                    num = 1000000 + 1;

            }
            //获取店铺的名称
            BindingList<t_orderdata> orderListname = new BindingList<t_orderdata>();

            //var Shopname = ctx.t_orderdata.Select(s => s.店舗コード).Distinct().ToList();

            var Shopname = orders11.Select(s => s.店舗コード).Distinct().ToList();
            int hangshu = 0;

            for (int i = 0; i < Shopname.Count; i++)
            {
                hangshu++;
                int amou = hangshu + num;

                foreach (v_pendingorder item in orders11)
                {
                    if (Shopname[i] == item.店舗コード)
                    {
                        item.社内伝番 = num;
                        item.行数 = (short)amou;
                        item.最大行数 = (short)amou;
                    }
                }
            }


            foreach (v_pendingorder item in orders11)
            {
                orderList.Add(item);
            }

            #region 读取集合整体


            //orders1 = ctx.t_orderdata.ToList();
            //shopList = ctx.t_shoplist.ToList();

            //foreach (t_orderdata item in orders1)
            //{
            //    foreach (t_shoplist temp in shopList)
            //    {
            //        if (item.店舗コード == temp.店番 && item.キャンセル == "no" && item.一旦保留 == false && item.社内伝番 == null && item.ジャンル == 6)
            //        {


            //            orderList.Add(item);
            //        }
            //    }
            //} 
            #endregion
            #endregion
        }
        private void 丸健Read(GODDbContext ctx)
        {
            WanJianorders11 = new List<v_pendingorder>();

            //            string qtyFormat = @"SELECT s.* FROM t_orderdata s
            //left JOIN t_shoplist i on i.`店番` = s.`店舗コード`
            //WHERE (s.キャンセル = 'no' && s.実際配送担当 ='丸健' && s.配送担当受信 = false && s.ジャンル = '6' && s.社内伝番 is null )
            //UNION ALL SELECT CONCAT(s.`店舗コード`,'a',s.`社内伝番`) AS id , CURDATE() as `受注日`,s.`店舗コード`,  s.`店舗名漢字`,s.`社内伝番`,s.`ジャンル`, '二次製品' , s.`最大行数`, sum(t_orderdata.`重量`), sum(s.`重量`), s.`実際配送担当`,  s.`納品指示`, s.`備考` FROM s s left JOIN t_shoplist i on i.`店番` = s.`店舗コード` WHERE (s.キャンセル = 'no' && s.実際配送担当 ='丸健' && s.配送担当受信 = false && s.ジャンル = '6' && s.社内伝番 is null )GROUP by s.`社内伝番`  ;";

            string qtyFormat = @"SELECT s.* FROM t_orderdata s
left JOIN t_shoplist i on i.`店番` = s.`店舗コード`
WHERE (s.キャンセル = 'no' && s.実際配送担当 ='丸健' && s.配送担当受信 = false  && s.社内伝番 is null )
   ;";///&& s.ジャンル = '6'


            WanJianorders11 = ctx.Database.SqlQuery<v_pendingorder>(qtyFormat).ToList();


            foreach (v_pendingorder item in WanJianorders11)
            {
                if (item.ジャンル == 6)
                {
                    item.品名漢字 = "二次製品";
                    item.id受注データ = Convert.ToInt32(item.社内伝番);

                }
            }



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

        private void submitButton_Click(object sender, EventArgs e)
        {
            /*
                        entityDataSource1.SaveChanges();
                        List<object> canceled_data = new List<object>();
                        foreach (t_orderdata data in bindingSource1.List)
                        {
                            if (data.キャンセル == "yes")
                            {
                                canceled_data.Add(data);
                            }
                        }
                        foreach (var data in canceled_data)
                        {
                            bindingSource1.Remove(data);
                        }
                        */
        }

        private void OrderCheckForm_Load(object sender, EventArgs e)
        {


            //this.Location = new Point(50, 25);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //if(dateTimePicker1.Text == String.Empty)
            {
                //    this.dateTimePicker1.CustomFormat =  " ";
                //    this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
            //else
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            }


        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            //string oid = orderIDTextBox.Text;
            int oid = GetSelectedOrderID();
            if (oid > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    t_orderdata order = ctx.t_orderdata.Find(oid);
                    order.品名漢字 = productKanjiNameTextBox.Text;
                    ctx.SaveChanges();
                }
                InitializeOrderData();
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                this.tabControl1.SelectTab(formTabPage);
            }
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
                var q = OrderSqlHelper.PendingOrderQueryEx(entityDataSource1);
                // 分页

                if (pager1.PageCurrent > 1)
                {
                    q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
                }
                q = q.Take(pager1.OffSet(pager1.PageCurrent));

                // create BindingList (sortable/filterable)
                var bindinglist = entityDataSource1.CreateView(q) as EntityBindingList<v_pendingorder>;

                // count 计算t_orderdata 表， list 是 orderdata join itemlist join stockstate
                // 所以有可能 bindinglist is null 
                var list = new List<v_pendingorder>();
                if (bindinglist != null)
                {
                    list = bindinglist.ToList();
                }


                IEnumerable<IGrouping<int, v_pendingorder>> grouped_orders = list.GroupBy(o => o.自社コード, o => o);
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
                this.bindingSource1.DataSource = bindinglist;
                // assign BindingList to grid

                InitializeFormDataSource();
            }
            else
            {
                this.bindingSource1.DataSource = null;
            }
            dataGridView1.DataSource = this.bindingSource1;

            return count;
        }

        private void InitializeFormDataSource()
        {
            orderIDTextBox.DataBindings.Clear();
            invoiceNOTextBox.DataBindings.Clear();
            storeNamTextBox.DataBindings.Clear();
            storeCodeTextBox.DataBindings.Clear();
            orderReceivedAtTextBox.DataBindings.Clear();
            productKanjiNameTextBox.DataBindings.Clear();
            productKanjiSpecificationTextBox.DataBindings.Clear();
            productReceivedAtTextBox3.DataBindings.Clear();

            if (this.bindingSource1.Count > 0)
            {
                //invoiceNOTextBox.DataBindings.Clear();
                orderIDTextBox.DataBindings.Add("Text", bindingSource1, "id受注データ");
                invoiceNOTextBox.DataBindings.Add("Text", bindingSource1, "伝票番号");
                storeNamTextBox.DataBindings.Add("Text", bindingSource1, "店名");
                storeCodeTextBox.DataBindings.Add("Text", bindingSource1, "店舗コード");
                orderReceivedAtTextBox.DataBindings.Add("Text", bindingSource1, "受注日");
                productKanjiNameTextBox.DataBindings.Add("Text", bindingSource1, "品名漢字");
                productKanjiSpecificationTextBox.DataBindings.Add("Text", bindingSource1, "規格名漢字");

                //dateTimePicker1.DataBindings.Add("Text", bindingSource1, "出荷日");
                productReceivedAtTextBox3.DataBindings.Add("Text", bindingSource1, "納品日");


                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }

        }

        #endregion

        private int GetSelectedOrderID()
        {

            return Convert.ToInt32(orderIDTextBox.Text);
        }

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

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = GetSelectedRowsBySelectedCells();
            if (rows.Count() > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        var pendingorder = row.DataBoundItem as v_pendingorder;
                        t_orderdata order = ctx.t_orderdata.Find(pendingorder.id受注データ);
                        order.キャンセル = "yes";
                        order.キャンセル時刻 = DateTime.Now;
                        order.備考 = "キャンセル";
                    }
                    ctx.SaveChanges();
                }
                pager1.Bind();
            }
            else
            {
                MessageBox.Show(" please select rows in the order list first.");
            }
        }

        private void uncancleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = GetSelectedRowsBySelectedCells();
            if (rows.Count() > 0)
            {
                using (var ctx = new GODDbContext())
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        var pendingorder = row.DataBoundItem as v_pendingorder;
                        t_orderdata order = ctx.t_orderdata.Find(pendingorder.id受注データ);
                        order.キャンセル = "no";
                        order.キャンセル時刻 = null;
                        order.備考 = "キャンセル解除";
                    }
                    ctx.SaveChanges();
                }
                pager1.Bind();
            }
            else
            {
                MessageBox.Show(" please select rows in the order list first.");
            }

        }

        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is CreateOrderForm)
            {
                NewOrdersForm = null;
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
            if (checkBox1.Checked == true)
            {

                List<t_orderdata> newlis = new List<t_orderdata>();

                using (var ctx = new GODDbContext())
                {
                    var results = from s in ctx.t_orderdata
                                  where s.社内伝番 > 0
                                  select s;


                    foreach (var emp in results)
                    {
                        if (emp.社内伝番.ToString().StartsWith("6"))
                        {
                            t_orderdata item = new t_orderdata();

                            item = emp;
                            newlis.Add(item);

                        }
                    }
                }
                ApplyFilter2();
            }
            else
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int s = this.tabControl1.SelectedIndex;
            if (s == 0 && RowRemark >= 0)
            {

                //    string id = dataGridView1.Rows[RowRemark].Cells["StoreCodeColumn1"].EditedFormattedValue.ToString() + "a" + dataGridView1.Rows[RowRemark].Cells["InvoiceNOColumn1"].EditedFormattedValue.ToString();

                //    CheckUserInfo_ID(id, "1", invoiceNoFilterTextBox.Text);

                //    foreach (t_orderdata item in Findorderdataresults)
                //    {
                //        if (item.受注日 != null)
                //            textBox2.Text = item.受注日.ToString();
                //        if (item.店舗コード != null)
                //            textBox3.Text = item.店舗コード.ToString();
                //        if (item.店舗名漢字 != null)
                //            textBox4.Text = item.店舗名漢字.ToString();
                //        if (item.伝票番号 != null)
                //            textBox5.Text = item.伝票番号.ToString();
                //        if (item.キャンセル != null)
                //            textBox6.Text = item.キャンセル.ToString();
                //        if (item.キャンセル時刻 != null)
                //            textBox7.Text = item.キャンセル時刻.ToString();
                //        //textBox8.Text = item.品名漢字.ToString();
                //        if (item.ジャンル != null)
                //            textBox9.Text = item.ジャンル.ToString();
                //        if (item.品名漢字 != null)
                //            textBox10.Text = item.品名漢字.ToString();
                //        if (item.規格名漢字 != null)
                //            textBox11.Text = item.規格名漢字.ToString();
                //        if (item.発注数量 != null)
                //            //textBox12.Text = item.重量.ToString();
                //            textBox13.Text = item.発注数量.ToString();
                //        if (item.口数 != null)
                //            textBox14.Text = item.口数.ToString();
                //        if (item.重量 != null)
                //            textBox15.Text = item.重量.ToString();
                //        if (item.単位 != null)
                //            textBox16.Text = item.単位.ToString();
                //        if (item.実際配送担当 != null)
                //            textBox17.Text = item.実際配送担当.ToString();
                //        if (item.県別 != null)
                //            textBox18.Text = item.県別.ToString();
                //        if (item.配送担当受信 != null)
                //            textBox19.Text = item.配送担当受信.ToString();
                //        if (item.配送担当受信時刻 != null)
                //            textBox20.Text = item.配送担当受信時刻.ToString();
                //        if (item.専務受信 != null)
                //            textBox21.Text = item.専務受信.ToString();
                //        if (item.専務受信時刻 != null)
                //            textBox22.Text = item.専務受信時刻.ToString();
                //        if (item.受注日 != null)
                //            textBox23.Text = item.受注日.ToString();
                //        if (item.納品指示 != null)
                //            textBox24.Text = item.納品指示.ToString();
                //        if (item.備考 != null)
                //            textBox25.Text = item.備考.ToString();
                //    }
            }


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
            id受注データdemo = dataGridView1.Rows[RowRemark].Cells["id受注データ"].EditedFormattedValue.ToString();

        }


        private void 二次製品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region VB 逻辑
            //         'SQL?
            //sqlStr = "SELECT t_orderdata.`id受注データ`,t_orderdata.`id`,t_orderdata.`受注日`,t_orderdata.`店舗コード`," _
            //    & " t_shoplist.`店名`,t_orderdata.`伝票番号`,t_orderdata.`品名漢字`,t_orderdata.`規格名漢字`," _
            //    & " t_orderdata.`口数`, t_orderdata.`発注数量`, t_orderdata.`重量`, t_orderdata.`実際配送担当`,t_shoplist.`県別`," _
            //    & " t_orderdata.`発注形態名称漢字`" _
            //    & " FROM t_orderdata" _
            //    & " INNER JOIN t_shoplist ON t_orderdata.`店舗コード` = t_shoplist.`店番`" _
            //    & " WHERE t_orderdata.`キャンセル` = 'no' AND t_orderdata.`一旦保留`=0 AND t_orderdata.`社内伝番` IS NULL AND t_orderdata.`ジャンル` = '6'" _
            //    & " ORDER BY t_orderdata.`実際配送担当` ASC,t_shoplist.`県別` ASC,t_orderdata.`店舗コード` ASC," _
            //    & " t_orderdata.`ＪＡＮコード` ASC,t_orderdata.`受注日` ASC,t_orderdata.`伝票番号` ASC"


            //            For i = 4 To n
            //    sqlStr = "UPDATE t_orderdata" _
            //        & " SET `社内伝番`=" & Cells(i, 15).Value & ", `行数`=" & Cells(i, 16).Value & ", `最大行数`=" & Cells(i, 17).Value _
            //        & " WHERE t_orderdata.`id受注データ` =" & Cells(i, 1).Value
            //    Set rs = con.Execute(sqlStr)
            //Next 

            #endregion
            /*
            using (var ctx = new GODDbContext())
            {
                var results = from s in ctx.t_orderdata
                              where s.社内伝番 > 0
                              select s;

                newfaxno = new List<int>();

                List<t_orderdata> newlis1 = new List<t_orderdata>();

                foreach (var emp in results)
                {

                    t_orderdata item = new t_orderdata();
                    item.社内伝番 = emp.社内伝番;

                    newfaxno.Add(Convert.ToInt32(item.社内伝番));
                    newlis1.Add(emp);


                }
                newfaxno.Sort();

                //IQueryable<t_shoplist> pages = from p in ctx.t_shoplist
                //                               where p.店番 > 0
                //                               select p;

                var resultsshoplist = from p in ctx.t_shoplist
                                      where p.店番 > 0
                                      select p;
                //var query1 = Query<t_orderdata>.Matches(c => c.TIAOXINGMA, new BsonRegularExpression(new Regex(findtext)));


                List<t_orderdata> newlis = new List<t_orderdata>();

                foreach (var emp in resultsshoplist)
                {
                    foreach (var temp in newlis1)
                    {
                        if (emp.店番 == temp.店舗コード)
                        {
                            if (temp.キャンセル == "no" && temp.一旦保留 == false && temp.社内伝番 == null && temp.ジャンル == 6)
                            {
                                newlis.Add(temp);
                            }
                        }
                    }
                }

                if (newlis.Count != 0)
                {
                    MessageBox.Show("未処理内容ありません！");
                    return;
                }
                //社内伝番
            }

            var orders1 = new List<t_orderdata>();
            //打开
            int 社内伝番index = 0;
            short index = 0;

            if (dataGridView1.RowCount != 0)
            {
                List<string> aaa = new List<string>();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells["発注日"].EditedFormattedValue.ToString() == null || dataGridView1.Rows[i].Cells["発注日"].EditedFormattedValue.ToString() == "")
                        break;
                    t_orderdata item = new t_orderdata();
                    item.発注日 = Convert.ToDateTime(dataGridView1.Rows[i].Cells["発注日"].EditedFormattedValue.ToString());
                    item.伝票番号 = Convert.ToInt32(dataGridView1.Rows[i].Cells["伝票番号"].EditedFormattedValue.ToString());
                    item.店舗コード = Convert.ToInt16(dataGridView1.Rows[i].Cells["店舗コード"].EditedFormattedValue.ToString());
                    item.商品コード = Convert.ToInt32(dataGridView1.Rows[i].Cells["商品コード"].EditedFormattedValue.ToString());
                    item.発注数量 = Convert.ToInt32(dataGridView1.Rows[i].Cells["発注数量"].EditedFormattedValue.ToString());
                    System.Globalization.DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                    dtFormat.ShortDatePattern = "yyyy-MM-dd";
                    item.受注日 = Convert.ToDateTime(item.発注日.ToString("yyyy-MM-dd", dtFormat));

                    #region 社内伝番  定义字符串的规则长度
                    if (社内伝番index != 0)
                    {
                        item.社内伝番 = 社内伝番index + 1;
                        社内伝番index = 社内伝番index + 1;
                    }
                    if (newfaxno == null || newfaxno.Count == 0)
                    {
                        //
                        item.社内伝番 = 1000000;
                        社内伝番index = Convert.ToInt32(item.社内伝番);
                    }
                    #endregion
                    index++;
                    //社内伝番最大値を調べ取り込み完了
                    item.社内伝番 = newfaxno[newfaxno.Count - 1] + 1;
                    item.行数 = index;
                    item.最大行数 = index;
                    orders1.Add(item);
                }
                #region 插入数据  二次製品データ処理後登録
                using (var ctx = new GODDbContext())
                {
                    foreach (t_orderdata item in orders1)
                    {
                        ctx.t_orderdata.Add(item);
                        ctx.SaveChanges();
                    }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             */
        }

        private void saveCodeButton_Click(object sender, EventArgs e)
        {
            orders1 = new List<t_orderdata>();

            foreach (v_pendingorder item in orderList)
            {
                t_orderdata temp = new t_orderdata();

                #region MyRegion
                temp.ASN管理連番 = item.ASN管理連番;
                //temp.EDI発注区分 = item.EDI発注区分;
                //temp.id = item.id;
                temp.id受注データ = item.id受注データ;
                temp.ＪＡＮコード = item.ＪＡＮコード;
                //temp.PB区分 = item.PB区分;
                temp.Status = item.Status;
                //temp.オプション使用欄 = item.オプション使用欄;
                temp.キャンセル = item.キャンセル;
                temp.キャンセル時刻 = item.キャンセル時刻;
                //temp.クラスコード = item.クラスコード;
                //temp.サイズ名カナ = item.サイズ名カナ;
                temp.ジャンル = item.ジャンル;
                //temp.センターコード = item.センターコード;
                //temp.センター名カナ = item.センター名カナ;
                //temp.センター名漢字 = item.センター名漢字;
                //temp.センター経由区分 = item.センター経由区分;
                temp.ダブリ = item.ダブリ;
                // temp.ラインコード = item.ラインコード;
                //temp.ロケーションコード = item.ロケーションコード;
                temp.一旦保留 = item.一旦保留;
                //temp.予備_数値_ = item.予備_数値_;
                //temp.仕入先コード = item.仕入先コード;
                //temp.仕入先名カナ = item.仕入先名カナ;
                //temp.仕入先名漢字 = item.仕入先名漢字;
                //temp.伝票出力単位 = item.伝票出力単位;
                //temp.伝票区分 = item.伝票区分;
                //temp.伝票番号 = item.伝票番号;
                //temp.便区分 = item.便区分;
                //temp.備考 = item.備考;
                temp.出荷No = item.出荷No;
                temp.出荷日 = item.出荷日;
                temp.出荷業務仕入先コード = item.出荷業務仕入先コード;
                temp.単位 = item.単位;
                //temp.原価区分 = item.原価区分;
                temp.原価金額_税抜_ = item.原価金額_税抜_;
                //temp.原価金額_税込_ = item.原価金額_税込_;
                //temp.原単価_税抜_ = item.原単価_税抜_;
                //temp.原単価_税込_ = item.原単価_税込_;
                temp.受注日 = item.受注日;
                //temp.受注時刻 = item.受注時刻;
                temp.受領 = item.受領;
                //temp.受領差異数量 = item.受領差異数量;
                //temp.受領差異金額 = item.受領差異金額;
                //temp.受領数量 = item.受領数量;
                //temp.受領確認 = item.受領確認;
                //temp.受領金額 = item.受領金額;
                temp.口数 = item.口数;
                //temp.品名カナ = item.品名カナ;
                temp.品名漢字 = item.品名漢字;
                temp.商品コード = item.商品コード;
                //temp.商品コード区分 = item.商品コード区分;
                //temp.回答納期 = item.回答納期;
                temp.在庫状態 = item.在庫状態;
                //temp.売単価_税抜_ = item.売単価_税抜_;
                //temp.売単価_税込_ = item.売単価_税込_;
                temp.実際出荷数量 = item.実際出荷数量;
                temp.実際配送担当 = item.実際配送担当;
                //temp.専務受信 = item.専務受信;
                //temp.専務受信時刻 = item.専務受信時刻;
                //temp.広告コード = item.広告コード;
                temp.店舗コード = item.店舗コード;
                temp.店舗名カナ = item.店舗名カナ;
                temp.店舗名漢字 = item.店舗名漢字;
                temp.最大行数 = item.最大行数;
                //temp.最小発注単位数量 = item.最小発注単位数量;
                //temp.本部発注区分 = item.本部発注区分;
                //temp.柄名カナ = item.柄名カナ;
                //temp.法人コード = item.法人コード;
                //temp.法人名カナ = item.法人名カナ;
                //temp.法人名漢字 = item.法人名漢字;
                //temp.特価区分 = item.特価区分;
                //temp.用度品区分 = item.用度品区分;
                //temp.発注データ有効期限 = item.発注データ有効期限;
                //temp.発注単位名称カナ = item.発注単位名称カナ;
                //temp.発注単位名称漢字 = item.発注単位名称漢字;
                temp.発注形態区分 = item.発注形態区分;
                temp.発注形態名称漢字 = item.発注形態名称漢字;
                temp.発注数量 = item.発注数量;
                //temp.発注日 = item.発注日;
                temp.県別 = item.県別;
                temp.社内伝番 = item.社内伝番;
                //temp.税区分 = item.税区分;
                //temp.税率 = item.税率;
                //temp.税額 = item.税額;
                //temp.納品予定日 = item.納品予定日;
                //temp.納品先店舗コード = item.納品先店舗コード;
                //temp.納品先店舗名カナ = item.納品先店舗名カナ;
                //temp.納品先店舗名漢字 = item.納品先店舗名漢字;
                temp.納品原価金額 = item.納品原価金額;
                temp.納品口数 = item.納品口数;
                //temp.納品場所コード = item.納品場所コード;
                temp.納品場所名カナ = item.納品場所名カナ;
                temp.納品場所名漢字 = item.納品場所名漢字;
                //temp.納品指示 = item.納品指示;
                temp.納品日 = item.納品日;
                //temp.納期回答区分 = item.納期回答区分;
                //temp.総額取引区分 = item.総額取引区分;
                temp.自社コード = item.自社コード;
                //temp.色名カナ = item.色名カナ;
                temp.行数 = item.行数;
                //temp.行番号 = item.行番号;
                //temp.規格名カナ = item.規格名カナ;
                temp.規格名漢字 = item.規格名漢字;
                //temp.週目 = item.週目;
                //temp.部門コード = item.部門コード;
                //temp.部門名カナ = item.部門名カナ;
                //temp.部門名漢字 = item.部門名漢字;
                //temp.配送担当受信 = item.配送担当受信;
                temp.配送担当受信時刻 = item.配送担当受信時刻;
                temp.重量 = item.重量;
                #endregion


            }
            using (var ctx = new GODDbContext())
            {
                ctx.t_orderdata.AddRange(orders1);
                ctx.SaveChanges();
                this.orderList.Clear();
            }

            MessageBox.Show(String.Format("Congratulations, You have {0} items added successfully!", orderList.Count));


        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

    }
}
