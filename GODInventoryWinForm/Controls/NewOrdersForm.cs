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
        int RowRemark = 0;
        int cloumn = 0;

        private Hashtable datagrid_changes = null;
        private BindingList<t_orderdata> orderList;
        private List<t_orderdata> orders1;
        
        public NewOrdersForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = orderList;
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
                if (e.Value == "yes")
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }





    }
}
