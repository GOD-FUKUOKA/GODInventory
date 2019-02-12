using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    public partial class CreateTransportForm : Form
    {
        private BindingList<v_transport> transportList;
        private List<t_warehouses> warehouseList;



        public CreateTransportForm()
        {
            InitializeComponent();


            transportList = new BindingList<v_transport>();

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = transportList;

            InitializeDataSource();

        }
        public void InitializeDataSource()
        {

            using (var ctx = new GODDbContext())
            {
                warehouseList = ctx.t_warehouses.ToList();
            }

            this.ComboBox.DisplayMember = "FullName";
            this.ComboBox.ValueMember = "Id";
            this.ComboBox.DataSource = warehouseList;



            //BuildStockNO();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            v_transport item = new v_transport();

            item.Transport_name = selfCodeTextBox1.Text;

            item.ShipperName = shipperTextBox.Text;


            transportList.Add(item);


        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtered = warehouseList.FindAll(s => s.Id == (int)this.ComboBox.SelectedValue);
            if (filtered.Count > 0)
            {
                //shipperTextBox.Text = ComboBox.Text;
                shipperTextBox.Text = filtered[0].FullName;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (transportList.Count > 0)
                using (var ctx = new GODDbContext())
                {

                    //  ctx.v.AddRange(transportList);
                    ctx.SaveChanges();
                    MessageBox.Show(String.Format("{0} 枚のFAX注文登録完了!", transportList.Count));
                    transportList.Clear();


                }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

            if (column == deleteButtonColumn)
            {

                transportList.RemoveAt(e.RowIndex);

            }
        }

        private void CreateTransportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
