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
        private NewOrdersForm NewOrdersForm;
        int RowRemark = 0;
        int cloumn = 0;
        private string id受注データdemo;


        public PendingOrderForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            var ctx = entityDataSource1.DbContext as GODDbContext;
            this.stockstates = ctx.t_stockstate.Select(s => s).ToList();

            InitializePager();

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
            if (sender is NewOrdersForm)
            {
                NewOrdersForm = null;
            }


        }

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
            var form = new NewOrdersForm();
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
                NewOrdersForm SqlData = new NewOrdersForm();
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

                string id = dataGridView1.Rows[RowRemark].Cells["StoreCodeColumn1"].EditedFormattedValue.ToString() + "a" + dataGridView1.Rows[RowRemark].Cells["InvoiceNOColumn1"].EditedFormattedValue.ToString();

                CheckUserInfo_ID(id, "1", invoiceNoFilterTextBox.Text);

                foreach (t_orderdata item in Findorderdataresults)
                {
                    if (item.受注日 != null)
                        textBox2.Text = item.受注日.ToString();
                    if (item.店舗コード != null)
                        textBox3.Text = item.店舗コード.ToString();
                    if (item.店舗名漢字 != null)
                        textBox4.Text = item.店舗名漢字.ToString();
                    if (item.伝票番号 != null)
                        textBox5.Text = item.伝票番号.ToString();
                    if (item.キャンセル != null)
                        textBox6.Text = item.キャンセル.ToString();
                    if (item.キャンセル時刻 != null)
                        textBox7.Text = item.キャンセル時刻.ToString();
                    //textBox8.Text = item.品名漢字.ToString();
                    if (item.ジャンル != null)
                        textBox9.Text = item.ジャンル.ToString();
                    if (item.品名漢字 != null)
                        textBox10.Text = item.品名漢字.ToString();
                    if (item.規格名漢字 != null)
                        textBox11.Text = item.規格名漢字.ToString();
                    if (item.発注数量 != null)
                        //textBox12.Text = item.重量.ToString();
                        textBox13.Text = item.発注数量.ToString();
                    if (item.口数 != null)
                        textBox14.Text = item.口数.ToString();
                    if (item.重量 != null)
                        textBox15.Text = item.重量.ToString();
                    if (item.単位 != null)
                        textBox16.Text = item.単位.ToString();
                    if (item.実際配送担当 != null)
                        textBox17.Text = item.実際配送担当.ToString();
                    if (item.県別 != null)
                        textBox18.Text = item.県別.ToString();
                    if (item.配送担当受信 != null)
                        textBox19.Text = item.配送担当受信.ToString();
                    if (item.配送担当受信時刻 != null)
                        textBox20.Text = item.配送担当受信時刻.ToString();
                    if (item.専務受信 != null)
                        textBox21.Text = item.専務受信.ToString();
                    if (item.専務受信時刻 != null)
                        textBox22.Text = item.専務受信時刻.ToString();
                    if (item.受注日 != null)
                        textBox23.Text = item.受注日.ToString();
                    if (item.納品指示 != null)
                        textBox24.Text = item.納品指示.ToString();
                    if (item.備考 != null)
                        textBox25.Text = item.備考.ToString();
                }
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
                NewOrdersForm SqlData = new NewOrdersForm();
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

    }
}
