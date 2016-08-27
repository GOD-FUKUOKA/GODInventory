using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GODInventory.MyLinq;
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class NewOrdersForm : Form
    {
        //SELECT o2.* FROM t_orderdata o1 inner join t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
        //where o1.`Status`=0 OR o2.`Status`=1 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品日`>NOW())
        //order by o2.店舗コード, o2.自社コード , o2.createdAt desc
        
        //o1.`id受注データ`!= o2.`id受注データ`
        int RowRemark = 0;
        int cloumn = 0;

        private Hashtable datagrid_changes = null;
        private BindingList<t_orderdata> orderList;
        private List<t_orderdata> orders1;
        List<v_duplicatedorder> duplicatedOrderList;
        
        public NewOrdersForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.AutoGenerateColumns = false;

            this.InitializeOrderData();
        }




        private void detailButton_Click_1(object sender, EventArgs e)
        {
            orderList = new BindingList<t_orderdata>();


            using (var ctx = new GODDbContext())
            {

                orders1 = ctx.t_orderdata.ToList();
                foreach (t_orderdata item in orders1)
                {
                    int doubleie = 0;

                    foreach (t_orderdata temp in orders1)
                    {
                        if (item.店舗コード == temp.店舗コード && item.商品コード == temp.商品コード)
                            doubleie++;
                    }
                    if (doubleie > 1)
                    {
                        item.ダブリ = "yes";
                        orderList.Add(item);
                        ctx.SaveChanges();
                    }
                }
            }
            //this.dataGridView1.DataSource = null;
            //this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = orderList;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            //  if ((int) != 0)
                            {

                                t_orderdata order = ctx.t_orderdata.Find(Convert.ToInt32(dataGridView1.Rows[i].Cells["id受注データ"].EditedFormattedValue));
                                order.ダブリ = dataGridView1.Rows[i].Cells["ダブリ"].EditedFormattedValue.ToString();
                                ctx.SaveChanges();

                            }
                        }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (orderList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            {

                                t_orderdata order = ctx.t_orderdata.Find(Convert.ToInt32(dataGridView1.Rows[i].Cells["id受注データ"].EditedFormattedValue));
                                order.ダブリ = "no";
                                ctx.SaveChanges();

                            }
                        }
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                
                //    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        public int InitializeOrderData()
        {
            string sql = @"SELECT o1.id受注データ as duplicatedId, o2.id受注データ, o2.`出荷日`,o2.`納品日`,o2.`受注日`,o2.`店舗コード`, o2.`店舗名漢字`,
          o2.`伝票番号`,o2.`口数`,o2.`ジャンル`,o2.`品名漢字`,o2.`規格名漢字`, 
          o2.`発注数量`,o2.`実際配送担当`,o2.`県別`, 
          o2.`発注形態名称漢字`,o2.`キャンセル`,o2.`ダブリ`, o2.Status
            FROM t_orderdata o1 inner join t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
    where o1.`Status`=22 AND (o1.id受注データ = o2.id受注データ or  o2.`Status`=0 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品予定日`>NOW()) )
    order by o2.店舗コード, o2.自社コード , o2.受注日, o1.id受注データ";

            using (var ctx = new GODDbContext())
            {
                duplicatedOrderList = ctx.Database.SqlQuery<v_duplicatedorder>(sql).ToList();
            }

               

            this.bindingSource1.DataSource = duplicatedOrderList;

         
          
            dataGridView1.DataSource = this.bindingSource1;

            return 0;
        }

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.Status = OrderStatus.Cancelled;
            this.dataGridView1.Refresh();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int i = e.RowIndex;
            var order = duplicatedOrderList[i];
            if (order.Status == OrderStatus.Duplicated)
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;

            }
            else if (order.Status == OrderStatus.Cancelled)
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
            }
            else
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.Status = OrderStatus.Duplicated;
            this.dataGridView1.Refresh();
        }

        private void uncancleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.Status = OrderStatus.Pending;
            this.dataGridView1.Refresh();
        }

        private void unduplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.Status = OrderStatus.Pending;
            this.dataGridView1.Refresh();
        }

       

    }
}
