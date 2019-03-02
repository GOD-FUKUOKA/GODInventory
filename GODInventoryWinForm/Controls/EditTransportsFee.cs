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
    public partial class EditTransportsFee : Form
    {
        private List<t_warehouses> warehouseList;
        private int orderId;
        private t_freights freights { get; set; }
        public EditTransportsFee()
        {
            InitializeComponent();
        }
        public int OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                InitializeOrder();
            }
        }
        private void InitializeOrder()
        {

            var ctx = entityDataSource1.DbContext as GODDbContext;
            freights = ctx.t_freights.Find(OrderId);
            //freights = (from s in ctx.t_freights
            //            where s.id == OrderId
            //            select s).FirstOrDefault();
            warehouseList = ctx.t_warehouses.ToList();

            this.whComboBox.ValueMember = "Id";
            this.whComboBox.DisplayMember = "FullName";
            this.whComboBox.DataSource = warehouseList;
            if (freights != null)
                InitializeControls();


        }
        private void InitializeControls()
        {

            orderAtTextBox.Text = freights.id.ToString();

            whComboBox.Text = freights.warehousename;


            storeNamTextBox.Text = freights.transportname;

            storeCodeTextBox.Text = freights.unitname.ToString();

            invoiceNOTextBox.Text = freights.fee.ToString();



        }
        private void submitFormButton_Click(object sender, EventArgs e)
        {

            freights.id =Convert.ToInt32( orderAtTextBox.Text);


            freights.warehousename = whComboBox.Text;



            freights.transportname = storeNamTextBox.Text;


            freights.unitname  = storeCodeTextBox.Text ;


            freights.fee   =Convert.ToInt32( invoiceNOTextBox.Text);

            this.entityDataSource1.SaveChanges();

            this.Close();
        }



    }
}
