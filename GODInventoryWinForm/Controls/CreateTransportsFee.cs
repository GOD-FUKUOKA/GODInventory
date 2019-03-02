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

namespace GODInventoryWinForm
{
    public partial class CreateTransportsFee : Form
    {
        private List<t_warehouses> warehouseList;
        private int orderId;
        private t_freights freights { get; set; }
        public CreateTransportsFee()
        {
            InitializeComponent();
            InitializeOrder();
        }
       
        private void InitializeOrder()
        {

            var ctx = entityDataSource1.DbContext as GODDbContext;
    
            warehouseList = ctx.t_warehouses.ToList();

            this.whComboBox.ValueMember = "Id";
            this.whComboBox.DisplayMember = "FullName";
            this.whComboBox.DataSource = warehouseList;
       


        }
     
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                if (orderAtTextBox.Text.Length > 0)
                {
                  int zi= Convert.ToInt32( orderAtTextBox.Text);


                    var List = (from t_freights o in ctx.t_freights
                                where zi == o.自社コード
                                select o).ToList();
                    if (List.Count == 0)
                    {
                        t_freights freights = new t_freights();
                        freights.自社コード = Convert.ToInt32(orderAtTextBox.Text);
                        freights.warehousename = whComboBox.Text;
                        freights.transportname = storeNamTextBox.Text;
                        freights.unitname = storeCodeTextBox.Text;
                        freights.fee = Convert.ToInt32(invoiceNOTextBox.Text);
                        ctx.t_freights.Add(freights);
                        ctx.SaveChanges();

                        MessageBox.Show(String.Format("登録完了!"));
                    }
                    else
                    {
                        MessageBox.Show(String.Format("无法添加， 已存在!"));

                    }
                }
            }
        }



    }
}
