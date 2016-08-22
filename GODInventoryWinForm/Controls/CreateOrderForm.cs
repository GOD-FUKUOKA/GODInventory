using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;
//using Spring.Context;
//using Spring.Context.Support;
//using System.Collections;
using System.Configuration;


namespace GODInventoryWinForm.Controls
{
    public partial class CreateOrderForm : Form
    {

        List<int> newfaxno = new List<int>();
        private List<t_orderdata> orders1;
        private List<t_shoplist> shopList;
        private List<t_rcvdata> t_rcvdataR;
        private List<t_locations> locationList;
        private BindingList<t_orderdata> orderList;
        private List<t_pricelist> t_pricelistR;
        int cloumn = 0;
        private CreateorderForm_ShopCode CreateorderForm_ShopCode;
        int davX = 0;
        int davY = 0;

        public CreateOrderForm()
        {
            InitializeComponent();

            orderList = new BindingList<t_orderdata>();

            shopList = new List<t_shoplist>();
            t_rcvdataR = new List<t_rcvdata>();
            locationList = new List<t_locations>();

            using (var ctx = new GODDbContext())
            {

                shopList = ctx.t_shoplist.ToList();
                t_rcvdataR = ctx.t_rcvdata.ToList();
                locationList = ctx.t_locations.ToList();
                t_pricelistR = ctx.t_pricelist.ToList();

            }

            this.storeComboBox.DisplayMember = "店名";
            this.storeComboBox.ValueMember = "店番";
            //this.storeComboBox.DataSource = null;

            this.locationComboBox.DisplayMember = "納品場所名略称";
            this.locationComboBox.ValueMember = "Id";

            textBox1.Text = Properties.Settings.Default.Createorder_scc;
            textBox2.Text = Properties.Settings.Default.Createorder_hsbsc;
            textBox3.Text = Properties.Settings.Default.Createorder_sog;

            #region 直接读取 config

            ////Configuration config = ConfigurationManager.OpenExeConfiguration("app.config");
            ////String str = ConfigurationManager.AppSettings["orderformnew"];
            //var execonfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var db = execonfig.ConnectionStrings.ConnectionStrings["orderformnew"];
            //string aa = db.ConnectionString.ToString();
            //string[] temp1 = System.Text.RegularExpressions.Regex.Split(aa, "=");
            //string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp1[1], ";");
            //textBox1.Text = temp2[0];
            //temp2 = System.Text.RegularExpressions.Regex.Split(temp1[2], ";");
            //textBox2.Text = temp2[0];
            //textBox3.Text = temp1[3]; 
            #endregion


            orderReasonDataGridviewComboBox.ValueType = typeof(OrderReasonEnum);
            orderReasonDataGridviewComboBox.ValueMember = "Value";
            orderReasonDataGridviewComboBox.DisplayMember = "Display";
            orderReasonDataGridviewComboBox.DataSource = new OrderReasonEnum[] { OrderReasonEnum.補充, OrderReasonEnum.客注, OrderReasonEnum.用度品, OrderReasonEnum.広告, OrderReasonEnum.新店 }
                .Select(value => new { Display = value.ToString(), Value = (short)value })
                .ToList();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = orderList;
        }

        private void NewOrdersForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {


                if (storeCodeTextBox.Text == "" || productCodeTextBox.Text == "")
                {

                    MessageBox.Show("内容を书いてください", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                if (Convert.ToInt32(orderQuantityTextBox.Text) == 0)
                {
                    MessageBox.Show(" 発注数量  ゼロにできない", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                //if (invoiceNOTextBox.Text.Length != 8)
                //{
                //    if (MessageBox.Show("伝票番号  キャラクタ丈正しくない, 引き続き?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //    {
                //    }
                //    else
                //        return;
                //}
                //受注日, 伝票番号, 発注日, 店舗コード, 店舗名漢字, JANコード, 商品コード, 品名漢字, 規格名漢字,  発注数量
                //原単価(税抜),原価金額(税抜), 売単価(税抜),納品先店舗コード, 納品先店舗名漢字, 納品場所名漢字

                t_orderdata order = new t_orderdata();
                order.受注日 = DateTime.Now;
                order.発注日 = orderCreatedAtDateTimePicker.Value;

                order.店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                order.商品コード = Convert.ToInt32(productCodeTextBox.Text);
                order.発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);

                order.仕入先コード = Convert.ToInt32(textBox1.Text);
                order.出荷業務仕入先コード = Convert.ToInt32(this.textBox2.Text);
                order.仕入先名カナ = this.textBox3.Text;
                order.店舗名漢字 = this.storeComboBox.Text;
                order.法人コード = Convert.ToInt16(this.textBox4.Text);
                order.法人名漢字 = this.comboBox2.Text;
                order.部門コード = Convert.ToInt16(this.textBox5.Text);
                order.納品予定日 = this.dateTimePicker1.Value;
                order.納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                order.納品先店舗名漢字 = this.locationComboBox.Text;

                order.伝票番号 = GenerateInvoiceNo(order.店舗コード);

                #region 联动
                foreach (t_rcvdata item in t_rcvdataR)
                {

                    if (item.商品コード == Convert.ToDouble(order.商品コード))
                    {
                        order.品名漢字 = item.品名漢字.ToString();
                        order.規格名漢字 = item.規格名漢字.ToString();
                        order.原単価_税抜_ = Convert.ToInt32(item.原単価_税抜_.ToString());
                        order.売単価_税抜_ = Convert.ToInt32(item.売単価_税抜_.ToString());
                        order.ＪＡＮコード = long.Parse(item.ＪＡＮコード.ToString());
                        break;

                    }




                }
                #endregion

                orderList.Add(order);


                #region MyRegion
                /* 
                int index = this.dataGridView1.Rows.Add();
                if (order.発注日 != null)
                    dataGridView1.Rows[index].Cells["発注日"].Value = order.発注日;
                if (order.商品コード != null)
                    dataGridView1.Rows[index].Cells["商品コード"].Value = order.商品コード;
                if (order.店舗コード != null)
                    dataGridView1.Rows[index].Cells["店舗コード"].Value = order.店舗コード;
                if (order.伝票番号 != null)
                    dataGridView1.Rows[index].Cells["伝票番号"].Value = order.伝票番号;
                if (order.発注数量 != null)
                    dataGridView1.Rows[index].Cells["発注数量"].Value = order.発注数量;
                if (order.仕入先コード != null)
                    dataGridView1.Rows[index].Cells["仕入先コード"].Value = order.仕入先コード;
                if (order.出荷業務仕入先コード != null)
                    dataGridView1.Rows[index].Cells["出荷業務仕入先コード"].Value = order.出荷業務仕入先コード;
                if (order.仕入先名漢字 != null)
                    dataGridView1.Rows[index].Cells["仕入先名漢字"].Value = order.仕入先名漢字;
                if (order.法人コード != null)
                    dataGridView1.Rows[index].Cells["法人コード"].Value = order.法人コード;
                if (order.部門コード != null)
                    dataGridView1.Rows[index].Cells["部門コード"].Value = order.部門コード;
                if (order.納品場所コード != null)
                    dataGridView1.Rows[index].Cells["納品場所コード"].Value = order.納品場所コード;
                if (order.納品予定日 != null)
                    dataGridView1.Rows[index].Cells["納品予定日"].Value = order.納品予定日;

                if (order.納品先店舗名漢字 != null)
                    dataGridView1.Rows[index].Cells["納品先店舗名漢字"].Value = order.納品先店舗名漢字;
                if (order.納品場所コード != null)
                    dataGridView1.Rows[index].Cells["納品場所コード"].Value = order.納品場所コード;
                if (order.納品予定日 != null)
                    dataGridView1.Rows[index].Cells["納品予定日"].Value = order.納品予定日;
                if (order.部門コード != null)
                    dataGridView1.Rows[index].Cells["部門コード"].Value = order.部門コード;
                if (order.法人名漢字 != null)
                    dataGridView1.Rows[index].Cells["法人名漢字"].Value = order.法人名漢字;
                if (order.店舗名漢字 != null)
                    dataGridView1.Rows[index].Cells["店舗名漢字"].Value = order.店舗名漢字;
                if (order.仕入先名カナ != null)
                    dataGridView1.Rows[index].Cells["仕入先名カナ"].Value = order.仕入先名カナ;
                if (order.出荷業務仕入先コード != null)
                    dataGridView1.Rows[index].Cells["出荷業務仕入先コード"].Value = order.出荷業務仕入先コード;
                */

                #endregion

                #region 判断所添加的订单号码
                //string maxid = "Select max id form t_orderdata";
                //maxid = " SELECT MAX(id) AS LargestOrderPrice FROM t_orderdata";
                //maxid = " SELECT MAX(id) AS id受注データ FROM t_orderdata";

                //string constr1 = "server=localhost;User Id=root ;Database=test";

                //MySqlConnection mycon1 = new MySqlConnection(constr1);
                //mycon1.Open();
                //MySqlCommand mycmd1 = new MySqlCommand(maxid, mycon1);
                //MySqlDataReader dr1 = mycmd1.ExecuteReader();




                //int jk = 0;
                //string maxidname = "";

                //while (dr1.Read())
                //{
                //    maxidname = dr1[jk++].ToString();

                //}
                //string[] temp1 = System.Text.RegularExpressions.Regex.Split(maxidname, "a");
                //int add_1 = Convert.ToInt32(temp1[1]) + 1;

                //if (add_1 > 99999)
                //{

                //    //if (MessageBox.Show("受注号99999を超えた 再から计算  ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //    //{

                //    //}
                //    //else
                //    //    return;
                //}

                #endregion
                //orders.Add(order);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ex" + ex, "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw ex;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {


            try
            {
                //BindingList<t_orderdata> NeworderList = new BindingList<t_orderdata>();
                var NeworderList = this.orderList.Where(l => l.発注数量 > 0).ToList();


                if (orderList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        ctx.t_orderdata.AddRange(NeworderList);
                        ctx.SaveChanges();
                        MessageBox.Show(String.Format("Congratulations, You have {0} fax order added successfully!", orderList.Count));
                        orderList.Clear();
                    }



                }
                else
                {
                    MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return;

                throw;
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                storeCodeTextBox.Text = "";
                productCodeTextBox.Text = "";

                //this.dataGridView1.DataSource = null;
                //this.dataGridView1.Refresh();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void storeCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (storeCodeTextBox.Text.Trim().Length > 0)
            {
                int storeId = Convert.ToInt32(storeCodeTextBox.Text);
                if (storeId > 0)
                {
                    //this.storeComboBox.SelectedValue = storeId;
                    var shops = this.shopList.Where(s => s.店番.ToString().StartsWith(storeId.ToString())).ToList();
                    if (shops.Count > 0)
                    {
                        var store = shops.First();
                        this.storeComboBox.DataSource = shops;
                        //this.storeBindingSource.DataSource = list;
                        var locations = this.locationList.Where(l => l.店舗コード == store.店番).ToList();
                        this.locationComboBox.DataSource = locations;
                        if (locations.Count > 0)
                        {
                            this.locationTextBox.Text = locations.First().納品場所コード.ToString();
                        }
                        else
                        {
                            this.locationTextBox.Text = "";
                        }

                        #region new

                        //dataGridView1.Rows.Clear();
                        //dataGridView1.Columns.Clear();
                        orderList = new BindingList<t_orderdata>();

                        for (int i = 0; i < 10; i++)
                        {
                            t_orderdata order = new t_orderdata();
                            //order.受注日 = DateTime.Now;
                            //order.発注日 = orderCreatedAtDateTimePicker.Value;

                            //order.店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                            //order.商品コード = Convert.ToInt32(productCodeTextBox.Text);
                            //order.発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);

                            //order.仕入先コード = Convert.ToInt32(textBox1.Text);
                            //order.出荷業務仕入先コード = Convert.ToInt32(this.textBox2.Text);
                            //order.仕入先名カナ = this.textBox3.Text;
                            //order.店舗名漢字 = this.storeComboBox.Text;
                            //order.法人コード = Convert.ToInt16(this.textBox4.Text);
                            //order.法人名漢字 = this.comboBox2.Text;
                            //order.部門コード = Convert.ToInt16(this.textBox5.Text);
                            //order.納品予定日 = this.dateTimePicker1.Value;
                            //order.納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                            //order.納品先店舗名漢字 = this.locationComboBox.Text;
                            // order.発注形態名称漢字 = "補充";


                            order.伝票番号 = GenerateInvoiceNo(order.店舗コード);

                            #region 联动
                            foreach (t_rcvdata item in t_rcvdataR)
                            {

                                if (item.商品コード == Convert.ToDouble(order.商品コード))
                                {
                                    order.品名漢字 = item.品名漢字.ToString();
                                    order.規格名漢字 = item.規格名漢字.ToString();
                                    order.原単価_税抜_ = Convert.ToInt32(item.原単価_税抜_.ToString());
                                    order.売単価_税抜_ = Convert.ToInt32(item.売単価_税抜_.ToString());
                                    order.ＪＡＮコード = long.Parse(item.ＪＡＮコード.ToString());
                                    break;

                                }
                            }
                            #endregion
                            orderList.Add(order);
                        }
                        this.dataGridView1.AutoGenerateColumns = false;
                        this.dataGridView1.DataSource = orderList;
                        #endregion
                    }
                    else
                    {
                        this.storeComboBox.DataSource = null;
                        this.locationComboBox.DataSource = null;
                        errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeId));
                    }

                }
                else
                {
                    errorProvider1.SetError(storeComboBox, String.Format("Can not find store by ID {0}", storeCodeTextBox.Text));
                }
            }

        }

        private void storeCodeTextBox_Click(object sender, EventArgs e)
        {
            newfaxno = new List<int>();
            List<string> datenewfaxno = new List<string>();

            #region new connect
            using (var ctx = new GODDbContext())
            {
                var results = from s in ctx.t_orderdata
                              where s.id受注データ > 0
                              select s;

                List<t_orderdata> newlis = new List<t_orderdata>();

                foreach (var emp in results)
                {
                    t_orderdata item = new t_orderdata();
                    item.id受注データ = emp.id受注データ;
                    item.伝票番号 = emp.伝票番号;
                    item.受注日 = emp.受注日;
                    item.受注時刻 = emp.受注時刻;
                    newlis.Add(item);
                    newfaxno.Add(Convert.ToInt32(item.伝票番号));
                    datenewfaxno.Add(DateTime.Parse(item.受注日.ToString()).ToString("yyyy-MM-dd").Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "") + item.受注時刻.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", ""));

                }
            }
            #endregion
            newfaxno.Sort();
            datenewfaxno.Sort();
            int datare = 0;
            if (newfaxno[datenewfaxno.Count - 1] != null && newfaxno[datenewfaxno.Count - 1].ToString().Length == 6)
            {
                string jiequ = newfaxno[datenewfaxno.Count - 1].ToString().Substring(0, 5);

                int Add_1 = Convert.ToInt32(jiequ) + 1;

                string fax = "00" + Add_1.ToString();

                //this.invoiceNOTextBox.Text = fax.Trim();
                if (fax.Length == 8)
                {
                    double dataamout = Convert.ToDouble(fax.Substring(0, 1)) + Convert.ToDouble(fax.Substring(1, 1)) + Convert.ToDouble(fax.Substring(2, 1)) + Convert.ToDouble(fax.Substring(3, 1)) + Convert.ToDouble(fax.Substring(4, 1)) + Convert.ToDouble(fax.Substring(5, 1)) + Convert.ToDouble(fax.Substring(6, 1)) + Convert.ToDouble(fax.Substring(7, 1));
                    datare = Convert.ToInt32(dataamout) % 7;

                    //double sishewuru = Math.Round(datare, MidpointRounding.AwayFromZero);


                }
                else if (fax.Length < 8)
                {
                    int add_0 = 7 - fax.Length;
                    for (int i = 0; i < add_0; i++)
                    {
                        //if (i == 0)
                        //    fax = "0" + Add_1;
                        //else
                        fax = "0" + fax;
                    }
                    double dataamout = Convert.ToDouble(fax.Substring(0, 1)) + Convert.ToDouble(fax.Substring(1, 1)) + Convert.ToDouble(fax.Substring(2, 1)) + Convert.ToDouble(fax.Substring(3, 1)) + Convert.ToDouble(fax.Substring(4, 1)) + Convert.ToDouble(fax.Substring(5, 1)) + Convert.ToDouble(fax.Substring(6, 1));
                    //double datare = dataamout / 7;

                    //double sishewuru = Math.Round(datare, MidpointRounding.AwayFromZero);

                    datare = Convert.ToInt32(dataamout) % 7;

                }

                //this.invoiceNOTextBox.Text = fax + datare.ToString();

            }

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

            orders1 = new List<t_orderdata>();
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
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


            try
            {
                if (textBox4.Text != "")
                {

                    var locations = this.t_rcvdataR.Where(l => l.法人コード == Convert.ToInt32(textBox4.Text)).Distinct().ToList();
                    var value = (from v in locations select v.法人名漢字).Distinct().ToList();
                    this.comboBox2.DisplayMember = "法人名漢字";
                    this.comboBox2.ValueMember = "id受領データ";
                    this.comboBox2.DataSource = value;

                }
            }
            catch (Exception ex)
            {
                return;

                throw;
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (locationTextBox.Text != "")
                {
                    foreach (t_locations item in locationList)
                    {
                        if (item.Id == Convert.ToInt32(locationTextBox.Text))
                            this.locationComboBox.Text = item.納品場所名漢字;

                    }
                }
            }
            catch (Exception ex)
            {
                return;

                throw;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // remove proper row when click delete.
            cloumn = e.ColumnIndex;

            if (cloumn == dataGridView1.ColumnCount - 1)
            {
                this.orderList.RemoveAt(e.RowIndex);
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    if (dataGridView1.Rows[e.RowIndex].Cells["発注日"].EditedFormattedValue.ToString() == null || dataGridView1.Rows[e.RowIndex].Cells["発注日"].EditedFormattedValue.ToString() == "")
            //    { }
            //    else
            //        dataGridView1.Rows[e.RowIndex].Cells[0].Value = "クリア";
            //}
            var cell1 = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell1.OwningColumn == 受注数)
            {

                orderList[davX].受注日 = DateTime.Now;
                orderList[davX].発注日 = orderCreatedAtDateTimePicker.Value;
                if (storeCodeTextBox.Text != "")
                    orderList[davX].店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                if (productCodeTextBox.Text != "")
                    orderList[davX].商品コード = Convert.ToInt32(productCodeTextBox.Text);
                if (orderQuantityTextBox.Text != "")
                    orderList[davX].発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);
                if (textBox1.Text != "")
                    orderList[davX].仕入先コード = Convert.ToInt32(textBox1.Text);
                if (textBox2.Text != "")
                    orderList[davX].出荷業務仕入先コード = Convert.ToInt32(this.textBox2.Text);
                orderList[davX].仕入先名カナ = this.textBox3.Text;
                orderList[davX].店舗名漢字 = this.storeComboBox.Text;
                if (textBox4.Text != "")
                    orderList[davX].法人コード = Convert.ToInt16(this.textBox4.Text);
                orderList[davX].法人名漢字 = this.comboBox2.Text;
                if (textBox5.Text != "")
                    orderList[davX].部門コード = Convert.ToInt16(this.textBox5.Text);
                orderList[davX].納品予定日 = this.dateTimePicker1.Value;
                if (locationTextBox.Text != "")
                    orderList[davX].納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                orderList[davX].納品先店舗名漢字 = this.locationComboBox.Text;


            }

        }

        private int GenerateInvoiceNumber(int store_id)
        {

            int num = 1;
            using (var ctx = new GODDbContext())
            {
                var last_order = (from s in ctx.t_orderdata
                                  where s.店舗コード == ((short)store_id)
                                  orderby s.発注日 descending, s.伝票番号 descending
                                  select s).FirstOrDefault();
                if (last_order != null)
                {

                    num = last_order.伝票番号 + 1;
                }
            }
            return num;
        }


        private int GenerateInvoiceNo(int storeId)
        {
            int invoiceNo = lastInvoiceNOByStoreId(storeId);

            int position = GetPositionByInvoiceNO(invoiceNo);
            position %= 99999; // max position is 99999,
            position += (1 + orderList.Count);

            return (position * 10) + (position % 7);

        }

        private int lastInvoiceNOByStoreId(int storeId)
        {


            int invoiceNo = 0;
            using (var ctx = new GODDbContext())
            {
                var last_order = (from s in ctx.t_orderdata
                                  where s.店舗コード == ((short)storeId)
                                  orderby s.発注日 descending, s.伝票番号 descending
                                  select s).FirstOrDefault();
                if (last_order != null)
                {

                    invoiceNo = last_order.伝票番号;
                }
            }
            return invoiceNo;


        }

        private int GetPositionByInvoiceNO(int invoiceNo)
        {

            return invoiceNo / 10;
        }

        //  発注形態 is enum, binding is not working, we have to handle it manually
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // fix 発注形態 combobox
            var row = dataGridView1.Rows[e.RowIndex];

            var order = row.DataBoundItem as t_orderdata;

            row.Cells["orderReasonDataGridviewComboBox"].Value = order.発注形態区分;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // fix 発注形態 combobox when user change it

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn == orderReasonDataGridviewComboBox)
            {
                if (cell.Value != null)
                {
                    orderList[e.RowIndex].発注形態区分 = (short)cell.Value;
                    orderList[e.RowIndex].発注形態名称漢字 = (string)cell.FormattedValue;
                }
            }
            #region MyRegion
            try
            {
                if (dataGridView1.RowCount < 1)
                    return;
                {
                    foreach (t_rcvdata item in t_rcvdataR)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells["ＪＡＮコード"].EditedFormattedValue != null && dataGridView1.Rows[e.RowIndex].Cells["ＪＡＮコード"].EditedFormattedValue != "" && item.ＪＡＮコード == Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["ＪＡＮコード"].EditedFormattedValue))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["品名漢字"].Value = item.品名漢字.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["規格名漢字"].Value = item.規格名漢字.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["原単価"].Value = item.原単価_税抜_.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["売単価"].Value = item.売単価_税抜_.ToString();
                            break;

                        }
                        if (item.商品コード == Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["商品コード"].EditedFormattedValue))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["品名漢字"].Value = item.品名漢字.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["規格名漢字"].Value = item.規格名漢字.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["原単価"].Value = item.原単価_税抜_.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["売単価"].Value = item.売単価_税抜_.ToString();
                            //dataGridView1.Rows[e.RowIndex].Cells["ＪＡＮコード"].Value = item.ＪＡＮコード.ToString();    
                            break;

                        }


                    }

                }
            }
            catch (Exception ex)
            {
                return;

                throw;


            }


            #endregion

            #region MyRegion
            if (e.RowIndex >= 0)
            {
                var cell1 = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell1.OwningColumn == 雑コード)
                {
                    if (cell1.Value != null && cell1.Value.ToString() == "No")
                    {
                        // fix 発注形態 combobox
                        var row = dataGridView1.Rows[e.RowIndex];
                        //row.Cells["商品コード"].ReadOnly = true;
                        row.Cells["ジャンル"].ReadOnly = true;
                        row.Cells["品名漢字"].ReadOnly = true;
                        row.Cells["規格名漢字"].ReadOnly = true;
                        row.Cells["ＪＡＮコード"].ReadOnly = true;
                        row.Cells["原単価"].ReadOnly = true;
                        row.Cells["売単価"].ReadOnly = true;
                        row.Cells["ロット"].ReadOnly = true;

                    }
                    else if (cell1.Value != null && cell1.Value.ToString() == "Yes")
                    {
                        // fix 発注形態 combobox
                        var row = dataGridView1.Rows[e.RowIndex];
                        //row.Cells["商品コード"].ReadOnly = true;
                        row.Cells["ジャンル"].ReadOnly = true;
                        row.Cells["品名漢字"].ReadOnly = true;
                        row.Cells["規格名漢字"].ReadOnly = true;
                        row.Cells["ＪＡＮコード"].ReadOnly = true;
                        row.Cells["原単価"].ReadOnly = true;
                        row.Cells["売単価"].ReadOnly = true;
                        row.Cells["ロット"].ReadOnly = true;

                    }

                }
                else if (cell1.OwningColumn == 受注数)
                {

                    orderList[davX].受注日 = DateTime.Now;
                    orderList[davX].発注日 = orderCreatedAtDateTimePicker.Value;
                    orderList[davX].店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                    if (productCodeTextBox.Text != "")
                        orderList[davX].商品コード = Convert.ToInt32(productCodeTextBox.Text);
                    orderList[davX].発注数量 = Convert.ToInt32(orderQuantityTextBox.Text);
                    orderList[davX].仕入先コード = Convert.ToInt32(textBox1.Text);
                    orderList[davX].出荷業務仕入先コード = Convert.ToInt32(this.textBox2.Text);
                    orderList[davX].仕入先名カナ = this.textBox3.Text;
                    orderList[davX].店舗名漢字 = this.storeComboBox.Text;
                    if (this.textBox4.Text != null)
                        orderList[davX].法人コード = Convert.ToInt16(this.textBox4.Text);
                    orderList[davX].法人名漢字 = this.comboBox2.Text;
                    orderList[davX].部門コード = Convert.ToInt16(this.textBox5.Text);
                    orderList[davX].納品予定日 = this.dateTimePicker1.Value;
                    orderList[davX].納品場所コード = Convert.ToInt16(this.locationTextBox.Text);
                    orderList[davX].納品先店舗名漢字 = this.locationComboBox.Text;
                }


            }

            #endregion

        }

        private void storeBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {


        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    davX = e.RowIndex;
                    davY = e.ColumnIndex;

                    #region MyRegion
                    if (CreateorderForm_ShopCode == null)
                    {
                        CreateorderForm_ShopCode = new CreateorderForm_ShopCode();
                        CreateorderForm_ShopCode.FormClosed += new FormClosedEventHandler(FrmOMS_FormClosed);
                    }
                    if (CreateorderForm_ShopCode == null)
                    {
                        CreateorderForm_ShopCode = new CreateorderForm_ShopCode();
                    }
                    CreateorderForm_ShopCode.ShowDialog();

                    #endregion


                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        // dataGridView1.ClearSelection();
                        // dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        //  dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    // contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }
        void FrmOMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is CreateorderForm_ShopCode)
            {
                if (CreateorderForm_ShopCode.ischeckmunal == false)
                {
                    v_itemlist v_stockiositem = CreateorderForm_ShopCode.v_stockiositem;
                    int inr = 0;
                    if (v_stockiositem != null)
                    {
                        orderList[davX].商品コード = Convert.ToInt32(v_stockiositem.商品コード);
                        orderList[davX].ジャンル = v_stockiositem.ジャンル;
                        orderList[davX].品名漢字 = v_stockiositem.商品名;
                        orderList[davX].規格名漢字 = v_stockiositem.規格;
                        orderList[davX].ＪＡＮコード = v_stockiositem.JANコード;
                        orderList[davX].発注数量 = Convert.ToInt32(v_stockiositem.ロット);

                        #region 从 t_pricelist 表中读取的价格
                        //var pricelist = this.t_pricelistR.Where(s => s.自社コード == v_stockiositem.自社コード && s.店番 == Convert.ToInt32(orderList[davX].ジャンル)).ToList();

                        //if (pricelist.Count > 0)
                        //{
                        //    orderList[davX].原単価_税抜_ = Convert.ToInt32(pricelist[0].通常売価);
                        //    orderList[davX].売単価_税抜_ = Convert.ToInt32(pricelist[0].特売売価);
                        //}
                        #endregion
                        #region 从t_rcvdata 中读取的价格

                        var pricelist1 = this.t_rcvdataR.Where(s => s.商品コード == v_stockiositem.商品コード).ToList();
                        if (pricelist1.Count > 0)
                        {
                            orderList[davX].原単価_税抜_ = Convert.ToInt32(pricelist1[0].原単価_税抜_);
                            orderList[davX].売単価_税抜_ = Convert.ToInt32(pricelist1[0].売単価_税抜_);
                        }
                        #endregion
                    }
                    #region 联动
                    //foreach (t_rcvdata item in t_rcvdataR)
                    //{

                    //    if (item.商品コード == Convert.ToDouble(v_stockiositem.商品コード))
                    //    {


                    //        orderList[davX].原単価_税抜_ = Convert.ToInt32(item.原単価_税抜_.ToString());
                    //        orderList[davX].売単価_税抜_ = Convert.ToInt32(item.売単価_税抜_.ToString());                        
                    //        break;
                    //    }
                    //}
                    #endregion
                }
                else
                {
                    var row = dataGridView1.Rows[davX];

                    row.Cells["品名漢字"].ReadOnly = true;
                    orderList[davX].規格名漢字 = "";
                    orderList[davX].ＪＡＮコード = 0;
                    orderList[davX].発注数量 = 0;
                    orderList[davX].原単価_税抜_ = 0;
                    orderList[davX].売単価_税抜_ = 0;
                    orderList[davX].口数 = 0;
                }
                this.dataGridView1.Refresh();

                CreateorderForm_ShopCode = null;
            }
        }

    }
}
