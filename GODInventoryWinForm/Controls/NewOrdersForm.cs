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
        List<v_duplicatedorder> duplicatedOrderList;
        SortableBindingList<v_duplicatedorder> duplicatedBindingList;
        public NewOrdersForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.AutoGenerateColumns = false;

            this.InitializeOrderData();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            if (duplicatedOrderList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            //  if ((int) != 0)
                            {
                                var duplicated_order = duplicatedOrderList[i];
                                t_orderdata order = ctx.t_orderdata.Find(duplicated_order.id受注データ);

                                if (duplicated_order.キャンセル == "yes")
                                {
                                    order.キャンセル = "yes";
                                    order.Status = OrderStatus.Cancelled;
                                    order.備考 = "キャンセル";
                                }
                                else if (duplicated_order.ダブリ == "no")
                                {
                                    if (order.Status == OrderStatus.Duplicated) {
                                        order.ダブリ = "no";
                                        order.Status = OrderStatus.Pending;
                                    }
                                }

                            }
                        }
                        ctx.SaveChanges();
                    }

                    InitializeOrderData();

                }
                else
                {
                    MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;
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


            duplicatedBindingList = new SortableBindingList<v_duplicatedorder>(duplicatedOrderList);
            dataGridView1.DataSource = duplicatedBindingList;

            return 0;
        }

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int i = e.RowIndex;
            var order = duplicatedOrderList[i];
            if (order.キャンセル == "yes")
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;

            }
            else if (order.ダブリ == "yes")
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.キャンセル = "yes";
            order.キャンセル時刻 = DateTime.Now;
            dataGridView1.ClearSelection();
            this.dataGridView1.Refresh();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.ダブリ = "yes";
            dataGridView1.ClearSelection(); 
            this.dataGridView1.Refresh();
        }

        private void uncancleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.キャンセル = "no";
            dataGridView1.ClearSelection(); 
            this.dataGridView1.Refresh();
        }

        private void unduplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dataGridView1.CurrentRow.Index;
            var order = duplicatedOrderList[rowIndex];
            order.ダブリ = "no";
            dataGridView1.ClearSelection(); 
            this.dataGridView1.Refresh();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            } 
        }

       

    }
}
