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

namespace GODInventoryWinForm.Controls
{
    public partial class NewOrdersForm : Form
    {

        private IBindingListView shops = null;
        private IBindingListView products = null;
        private DbSet<t_orderdata> orders;

        private List<t_orderdata> orders1;


        public NewOrdersForm()
        {
            InitializeComponent();
            //shops = entityDataSource1.EntitySets["t_shoplist"].List;
            //products = entityDataSource1.EntitySets["t_dataitem"].List;
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
                if (Convert.ToInt32(orderQuantityUpDown.Value) == 0)
                {
                    MessageBox.Show(" 発注数量  ゼロにできない", "誤っ", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                dataGridView1.Rows[index].Cells[0].Value = order.発注日;
                dataGridView1.Rows[index].Cells[1].Value = order.商品コード;
                dataGridView1.Rows[index].Cells[2].Value = order.店舗コード;
                dataGridView1.Rows[index].Cells[3].Value = order.伝票番号;
                dataGridView1.Rows[index].Cells[4].Value = order.発注数量;


                #region 判断所添加的订单号码
                string maxid = "Select max id form t_orderdata";
                maxid = " SELECT MAX(id) AS LargestOrderPrice FROM t_orderdata";
                string constr1 = "server=localhost;User Id=root ;Database=test";

                MySqlConnection mycon1 = new MySqlConnection(constr1);
                mycon1.Open();
                MySqlCommand mycmd1 = new MySqlCommand(maxid, mycon1);
                MySqlDataReader dr1 = mycmd1.ExecuteReader();
                int jk = 0;
                string maxidname = "";

                while (dr1.Read())
                {
                    maxidname = dr1[jk++].ToString();

                }
                string[] temp1 = System.Text.RegularExpressions.Regex.Split(maxidname, "a");
                int add_1 = Convert.ToInt32(temp1[1]) + 1;

                if (add_1 > 99999)
                {

                    if (MessageBox.Show("受注号99999を超えた 再から计算  ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                    }
                    else
                        return;
                }

                #endregion
                //   orders.Add(order);

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
                    //    SELECT MAX(column_name) FROM table_name
                    string maxid = "Select max id form t_orderdata";
                    maxid = " SELECT MAX(id) AS LargestOrderPrice FROM t_orderdata";
                    string constr1 = "server=localhost;User Id=root ;Database=test";

                    MySqlConnection mycon1 = new MySqlConnection(constr1);
                    mycon1.Open();
                    MySqlCommand mycmd1 = new MySqlCommand(maxid, mycon1);
                    MySqlDataReader dr1 = mycmd1.ExecuteReader();
                    //将结果赋值到了dr，下面开始输出                      
                    int jk = 0;

                    string maxidname = "";

                    while (dr1.Read())
                    {
                        maxidname = dr1[jk++].ToString();

                    }
                    mycon1.Close();
                    string[] temp1 = System.Text.RegularExpressions.Regex.Split(maxidname, "a");

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

                        int add_1 = Convert.ToInt32(temp1[1]) + 1;
                        if (add_1 > 99999)
                            add_1 = 00001;

                        string id = item.店舗コード + "a" + add_1.ToString();

                        #region 确认是否重复
                        #region 查询
                        mycon1.Open();
                        mycmd1 = new MySqlCommand("select * from t_orderdata  where id=" + "'" + id + "'", mycon1);

                        MySqlDataReader dr = mycmd1.ExecuteReader();
                        //将结果赋值到了dr，下面开始输出                      
                        int j = 0;
                        int aog = 0;
                        while (dr.Read())
                        {
                            aog++;
                            MessageBox.Show(dr[j++].ToString() + "--を繰り返し");
                            break;
                        }
                        mycon1.Close();
                        if (aog != 0)
                            continue;
                        #endregion
                        #endregion
                        //String sqlInsert1 = "  insert into t_maruken_trans(id,発注日,伝票番号,店舗コード,商品コード,発注数量) values( " + "'" + id + "'" + "," + "'" + item.発注日 + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.店舗コード + "'" + "," + "'" + item.商品コード + "'" + "," + "'" + item.発注数量 + "'" + ")";
                        //String sqlInsert1 = "  insert into t_orderdata(id,配送担当受信時刻,伝票番号,店舗コード,品名漢字,発注数量,受注日) values( " + "'" + id + "'" + "," + "'" + DateTime.Now + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.店舗コード + "'" + "," + "'" + item.商品コード + "'" + "," + "'" + item.発注数量 + "'" + "'" + item.受注日 + "'" + ")";
                        String sqlInsert1 = "  insert into t_orderdata(id受注データ,id,配送担当受信時刻,伝票番号,店舗コード,品名漢字,発注数量,受注日) values( " + "'" + item.伝票番号 + "'" + "," + "'" + id + "'" + "," + "'" + "2016-08-02 17:28:48" + "'" + "," + "'" + item.伝票番号 + "'" + "," + "'" + item.店舗コード + "'" + "," + "'" + item.商品コード + "'" + "," + "'" + item.発注数量 + "'" + "," + "'" + item.発注日.ToString("yyyy-MM-dd")+ "'" + ")";


                        aaa.Add(sqlInsert1);
                        MySqlCommand mySqlCommand = getSqlCommand(sqlInsert1, mysql);
                        getInsert(mySqlCommand);
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
                mysqlStr = "server=localhost;User Id=root; Database=test";

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


    }
}
