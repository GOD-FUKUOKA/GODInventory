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
    public partial class NewOrdersForm : Form
    {
        private Thread GetDataforOutlookThread;
        private IBindingListView shops = null;
        private IBindingListView products = null;
        private DbSet<t_orderdata> orders;
        List<int> newfaxno = new List<int>();
        private cfgList cfgListInfo;
        private List<t_orderdata> orders1;
        public enum OrderStatusEnum { Pending = 0, WaitToShip = 1, PendingShipment = 2, ASN = 3, Received = 4, Completed = 5 };
        private List<t_shoplist> t_shoplistR;
        //private List<> t_shoplistR;
        private List<t_rcvdata> t_rcvdataR;
        private List<t_locations> t_locationsR;
        int RowRemark = 0;
        int cloumn = 0;
        public NewOrdersForm()
        {
            InitializeComponent();

            //shops = entityDataSource1.EntitySets["t_shoplist"].List;
            //products = entityDataSource1.EntitySets["t_dataitem"].List;
            t_shoplistR = new List<t_shoplist>();
            t_rcvdataR = new List<t_rcvdata>();
            t_locationsR = new List<t_locations>();

            using (var ctx = new GODDbContext())
            {

                t_shoplistR = ctx.t_shoplist.ToList();
                t_rcvdataR = ctx.t_rcvdata.ToList();
                t_locationsR = ctx.t_locations.ToList();
            }
            //Configuration config = ConfigurationManager.OpenExeConfiguration("app.config");
            //String str = ConfigurationManager.AppSettings["orderformnew"];
            var execonfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var db = execonfig.ConnectionStrings.ConnectionStrings["orderformnew"];
            string aa = db.ConnectionString.ToString();
            string[] temp1 = System.Text.RegularExpressions.Regex.Split(aa, "=");
            string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp1[1], ";");
            textBox1.Text = temp2[0];
            temp2 = System.Text.RegularExpressions.Regex.Split(temp1[2], ";");
            textBox2.Text = temp2[0];
            textBox3.Text = temp1[3];


        }

        private void NewOrdersForm_Load(object sender, EventArgs e)
        {
            if (cfgListInfo != null)
            {
                if (cfgListInfo._仕入先コード != null)
                    this.textBox1.Text = cfgListInfo._仕入先コード;
                if (cfgListInfo._仕入先名カナ != null)
                    this.textBox2.Text = cfgListInfo._仕入先名カナ;
                if (cfgListInfo._出荷業務仕入先コード != null)
                    this.textBox3.Text = cfgListInfo._出荷業務仕入先コード;
            }
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
                if (Convert.ToInt32(orderQuantityUpDown.Value) == 0)
                {
                    MessageBox.Show(" 発注数量  ゼロにできない", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                if (invoiceNOTextBox.Text.Length != 7)
                {
                    if (MessageBox.Show("伝票番号  キャラクタ丈正しくない, 引き続き?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                    }
                    else
                        return;
                }
                //受注日, 伝票番号, 発注日, 店舗コード, 店舗名漢字, JANコード, 商品コード, 品名漢字, 規格名漢字,  発注数量
                //原単価(税抜),原価金額(税抜), 売単価(税抜),納品先店舗コード, 納品先店舗名漢字, 納品場所名漢字

                t_orderdata order = new t_orderdata();
                order.受注日 = DateTime.Now;
                order.発注日 = orderCreatedAtDateTimePicker.Value;
                order.伝票番号 = Convert.ToInt32(invoiceNOTextBox.Text);
                order.店舗コード = Convert.ToInt16(storeCodeTextBox.Text);
                order.商品コード = Convert.ToInt32(productCodeTextBox.Text);
                order.発注数量 = Convert.ToInt32(orderQuantityUpDown.Value);

                //int row_index = shops.Find(order.店舗コード);
                //if ( row)
                //order.店舗名漢字 =
                int index = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["発注日"].Value = order.発注日;
                dataGridView1.Rows[index].Cells["商品コード"].Value = order.商品コード;
                dataGridView1.Rows[index].Cells["店舗コード"].Value = order.店舗コード;
                dataGridView1.Rows[index].Cells["伝票番号"].Value = order.伝票番号;
                dataGridView1.Rows[index].Cells["発注数量"].Value = order.発注数量;
                dataGridView1.Rows[index].Cells["仕入先コード"].Value = order.仕入先コード;
                dataGridView1.Rows[index].Cells["出荷業務仕入先コード"].Value = order.出荷業務仕入先コード;
                dataGridView1.Rows[index].Cells["仕入先名漢字"].Value = order.仕入先名漢字;
                dataGridView1.Rows[index].Cells["法人コード"].Value = order.法人コード;
                dataGridView1.Rows[index].Cells["部門コード"].Value = order.部門コード;
                dataGridView1.Rows[index].Cells["納品場所コード"].Value = order.納品場所コード;
                dataGridView1.Rows[index].Cells["納品予定日"].Value = order.納品予定日;



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
                orders1 = new List<t_orderdata>();
                //打开
                MySqlConnection mysql = getMySqlCon();
                mysql.Open();
                if (dataGridView1.RowCount != 0)
                {
                    List<string> aaa = new List<string>();

                    #region    //读取当前商户订单中的最大订单号
                    ////    SELECT MAX(column_name) FROM table_name
                    //string maxid = "Select max id form t_orderdata";
                    //maxid = " SELECT MAX(id) AS LargestOrderPrice FROM t_orderdata";
                    //string constr1 = "server=localhost;User Id=root ;Database=test";

                    //MySqlConnection mycon1 = new MySqlConnection(constr1);
                    //mycon1.Open();
                    //MySqlCommand mycmd1 = new MySqlCommand(maxid, mycon1);
                    //MySqlDataReader dr1 = mycmd1.ExecuteReader();
                    ////将结果赋值到了dr，下面开始输出                      
                    //int jk = 0;

                    //string maxidname = "";

                    //while (dr1.Read())
                    //{
                    //    maxidname = dr1[jk++].ToString();

                    //}
                    //mycon1.Close();
                    //string[] temp1 = System.Text.RegularExpressions.Regex.Split(maxidname, "a");

                    #endregion

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["発注日"].EditedFormattedValue.ToString() == null || dataGridView1.Rows[i].Cells["発注日"].EditedFormattedValue.ToString() == "")
                            break;

                        t_orderdata item = new t_orderdata();
                        item.発注日 = Convert.ToDateTime(dataGridView1.Rows[i].Cells["発注日"].EditedFormattedValue.ToString());
                        item.伝票番号 = Convert.ToInt32(dataGridView1.Rows[i].Cells["伝票番号"].EditedFormattedValue.ToString());
                        item.店舗コード = Convert.ToInt16(dataGridView1.Rows[i].Cells["店舗コード"].EditedFormattedValue.ToString());// Convert.ToInt32(dataGridView1.Rows[i].Cells["店舗コード"].EditedFormattedValue.ToString());
                        item.商品コード = Convert.ToInt32(dataGridView1.Rows[i].Cells["商品コード"].EditedFormattedValue.ToString());
                        item.発注数量 = Convert.ToInt32(dataGridView1.Rows[i].Cells["発注数量"].EditedFormattedValue.ToString());

                        System.Globalization.DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();

                        dtFormat.ShortDatePattern = "yyyy-MM-dd";
                        item.受注日 = Convert.ToDateTime(item.発注日.ToString("yyyy-MM-dd", dtFormat));

                        orders1.Add(item);

                        //int add_1 = Convert.ToInt32(temp1[1]) + 1;
                        //if (add_1 > 99999)
                        //    add_1 = 00001;

                        //string id = item.店舗コード + "a" + add_1.ToString();

                        #region 确认是否重复
                        #region 查询
                        //mycon1.Open();
                        //mycmd1 = new MySqlCommand("select * from t_orderdata  where id=" + "'" + id + "'", mycon1);

                        //MySqlDataReader dr = mycmd1.ExecuteReader();
                        ////将结果赋值到了dr，下面开始输出                      
                        //int j = 0;
                        //int aog = 0;
                        //while (dr.Read())
                        //{
                        //    aog++;
                        //    MessageBox.Show(dr[j++].ToString() + "--を繰り返し");
                        //    break;
                        //}
                        //mycon1.Close();
                        //if (aog != 0)
                        //    continue;
                        #endregion
                        #endregion
                        //String sqlInsert1 = "  insert into t_maruken_trans(id,発注日,伝票番号,店舗コード,商品コード,発注数量) values( " + "'" + id + "'" + "," + "'" + item.発注日 + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.店舗コード + "'" + "," + "'" + item.商品コード + "'" + "," + "'" + item.発注数量 + "'" + ")";

                        //String sqlInsert1 = "  insert into t_orderdata(id受注データ,id,配送担当受信時刻,伝票番号,店舗コード,品名漢字,発注数量,受注日) values( " + "'" + item.伝票番号 + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.発注日.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.店舗コード + "'" + "," + "'" + item.商品コード + "'" + "," + "'" + item.発注数量 + "'" + "," + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'" + ")";
                        String sqlInsert1 = "  insert into t_orderdata(id受注データ,id,配送担当受信時刻,伝票番号,店舗コード,商品コード,品名漢字,発注数量,受注日,ダブリ,キャンセル,ＪＡＮコード,実際出荷数量,原単価(税抜),納品原価金額,一旦保留,実際配送担当,配送担当受信,専務受信,受領,受領確認,受領数量,ASN管理連番,出荷No,自社コード,Status) values( " + "'" + item.伝票番号 + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.発注日.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.店舗コード + "'" + "," + "'" + item.商品コード + "'" + "'" + "t" + "'" + "," + "'" + item.発注数量 + "'" + "," + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'" + "'" + "12" + "'" + "'" + "34" + "'" + "'" + "'" + "2100000008888" + "'" + "'" + "56" + "'" + "'" + "78" + "'" + "'" + "910" + "'" + "'" + "1" + "'" + "'" + "1213" + "'" + "'" + "1" + "'" + "'" + "1" + "'" + "'" + "1" + "'" + "'" + "1" + "'" + "'" + "1415" + "'" + "'" + "2016080200001" + "'" + "'" + "2016080200001" + "'" + "'" + "20160802000" + "'" + "'" + "02000" + "'" + ")";

                        //  item.品名漢字
                        aaa.Add(sqlInsert1);


                        #region old
                        //sqlInsert1 = "  insert into t_orderdata(id受注データ) values( " + "'" + 10086 + "'"+ ")";
                        //MySqlCommand mySqlCommand = getSqlCommand(sqlInsert1, mysql);
                        //getInsert(mySqlCommand);
                        #endregion
                        #region 插入数据
                        using (var ctx = new GODDbContext())
                        {
                            ctx.t_orderdata.Add(item);
                            ctx.SaveChanges();

                        }
                        #endregion
                    }
                    mysql.Close();
                    #region Read

                    // MySqlConnection mysql = getMySqlCon();
                    // String sqlInsert = "  insert into list1 (name1,name2) values('pengchao','19')";
                    // MySqlCommand mySqlCommand = getSqlCommand(sqlInsert, mysql);
                    // mysql.Open();
                    // MySqlCommand mycmd = new MySqlCommand(
                    //"insert into lsit1(name1,name2) values('pengchao','19')",
                    // mysql);
                    // aaa.Add(sqlInsert);
                    // ExecuteSqlTran(aaa);
                    // getInsert(mySqlCommand);

                    #endregion
                    //MySqlConnection mysql = getMySqlCon();
                    //String sqlInsert = "  insert into t_maruken_trans (単位,県別,id) values('pengchao','19','101a100000')";
                    //MySqlCommand mySqlCommand = getSqlCommand(sqlInsert, mysql);
                    //mysql.Open();
                    //getInsert(mySqlCommand);
                    // CheckUserInfo("888a00001");
                    #region 查询
                    //string constr = "server=localhost;User Id=root ;Database=test";

                    //MySqlConnection mycon = new MySqlConnection(constr);
                    //mycon.Open();
                    //MySqlCommand mycmd = new MySqlCommand("select * from t_maruken_trans  where id='888a00001'", mycon);
                    //MySqlDataReader dr = mycmd.ExecuteReader();
                    ////将结果赋值到了dr，下面开始输出                      
                    //int j = 0;
                    //while (dr.Read())
                    //{
                    //    MessageBox.Show(dr[j++].ToString());
                    //}
                    //mycon.Close();
                    #endregion

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
        public static void ExecuteSqlTran(List<string> SQLStringList)
        {
            string constr = "server=localhost;User Id=root ;Database=test";

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                        //后来加上的  
                        if (n > 0 && (n % 500 == 0 || n == SQLStringList.Count - 1))
                        {
                            tx.Commit();
                            tx = conn.BeginTransaction();
                        }
                    }
                    //tx.Commit();//原来一次性提交  
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        #region 查询代码

        public SqlDataReader ExSQLReader(string SQLStr)//执行SQL语句，返回一个SqlDataReader
        {
            try
            {
                string connString = @"Data Source=test;Initial Catalog=t_maruken_trans;Integrated Security=false;Pooling=False";

                SqlConnection connection = new SqlConnection(connString);
                SqlCommand command = new SqlCommand(SQLStr, connection);
                connection.Open();
                SqlDataReader dr;
                dr = command.ExecuteReader();
                return dr;
            }
            catch { return null; }
        }


        public void CheckUserInfo(string username)
        {
            string SQLStr = String.Format(" select * From [t_maruken_trans] where id='{0}'", username);
            try
            {
                NewOrdersForm SqlData = new NewOrdersForm();
                SqlDataReader DataReader = SqlData.ExSQLReader(SQLStr);
                t_orderdata userinfo = new t_orderdata();
                while (DataReader.Read())
                {
                    userinfo.id = DataReader.GetValue(0).ToString();
                    //userinfo.PassWord = DataReader.GetValue(1).ToString();
                    //userinfo.UserAge = Convert.ToInt32(DataReader.GetValue(2).ToString());
                    //userinfo.UserSex = DataReader.GetValue(3).ToString();
                    //userinfo.NickName = DataReader.GetValue(4).ToString();
                    //userinfo.RealName = DataReader.GetValue(5).ToString();
                    //userinfo.UserStar = DataReader.GetValue(6).ToString();
                    //userinfo.UserBlood = DataReader.GetValue(7).ToString();
                    //userinfo.UserId = Convert.ToInt32(DataReader.GetValue(8).ToString());
                    MessageBox.Show("服务器查找成功");
                }
                SqlData.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {

            }
        }
        #endregion

        public static MySqlConnection getMySqlCon()
        {
            try
            {
                // <add name="GODDbContext" connectionString="server=127.0.0.1;user id=root;database=demo1;allowuservariables=True;characterset=utf8" providerName="MySql.Data.MySqlClient" />



                String mysqlStr = "server=localhost_3306;Database=test;Data Source=127.0.0.1;User Id=root;allowuservariables=True;pooling=false;CharSet=utf8;port=3306;;  ";//Password=root;
                // String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;
                mysqlStr = "server=localhost;User Id=root; Database=demo1";

                MySqlConnection mysql = new MySqlConnection(mysqlStr);
                return mysql;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            //  MySqlCommand mySqlCommand = new MySqlCommand(sql);
            // mySqlCommand.Connection = mysql;
            return mySqlCommand;
        }

        public static void getInsert(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("插入数据失败了！" + message);
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
                invoiceNOTextBox.Text = "";

                storeCodeTextBox.Text = "";
                productCodeTextBox.Text = "";
                orderQuantityUpDown.Value = 0;

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
            try
            {
                if (storeCodeTextBox.Text != "")
                {

                    foreach (t_shoplist item in t_shoplistR)
                    {
                        if (item.店番 == Convert.ToInt32(storeCodeTextBox.Text))
                            comboBox1.Text = item.店名;

                    }
                }
            }
            catch (Exception ex)
            {
                return;
                throw;
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

                this.invoiceNOTextBox.Text = fax.Trim();
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

                this.invoiceNOTextBox.Text = fax + datare.ToString();

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

                    foreach (t_rcvdata item in t_rcvdataR)
                    {
                        if (item.法人コード == Convert.ToInt32(textBox4.Text))
                            comboBox2.Text = item.法人名漢字;

                    }



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
                if (textBox6.Text != "")
                {
                    foreach (t_locations item in t_locationsR)
                    {
                        if (item.Id == Convert.ToInt32(textBox6.Text))
                            this.comboBox3.Text = item.納品場所名漢字;

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
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;
            if (RowRemark < 0)
                return;
            if (cloumn == 1)
            {


            }

        }



    }
}
