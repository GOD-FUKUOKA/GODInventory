using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GODInventory.MyLinq;
using GODInventory.ViewModel;
using Microsoft.Reporting.WinForms;
using GODInventory.ViewModel.EDI;


namespace GODInventoryWinForm.Controls
{
    public partial class ShippingItemsReportForm : Form
    {
        public List<t_orderdata> OrderEnities{ get; set;}
        public List<t_itemlist> ItemEnities { get; set; }

        public ShippingItemsReportForm()
        {
            InitializeComponent();
            InitializeReportEvent();           
        }

        private void InitializeReportEvent()
        {
                //this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        public void InitializeDataSource(List<t_orderdata> orders) 
        {
            OrderEnities = orders;

            if (OrderEnities != null) {
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ShippingItems", OrderEnities));
                            
            }

        }
        public void InitializeItemEnitiesDataSource()
        {
            if (ItemEnities != null)
            {
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var ctx = new GODDbContext())
                {
                    var orders = ItemEnities.GroupBy(x => x.ジャンル).Select(y => y.First());

                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", orders));
                }
            }

        }




        private void ReceivedOrdersReportForm_Load(object sender, EventArgs e)
        {   
             ReportParameter[] parameters = new ReportParameter[1];
             //parameters[0] = new ReportParameter( "orders", this.orders, false);
 
            //this.reportViewer1.LocalReport.DataSources.Add( this.orders);
            this.reportViewer1.RefreshReport();
        }

        private void ReceivedOrdersReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ReceivedOrdersReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.reportViewer1.LocalReport.Dispose();

        }

        private void ReceivedOrdersReportForm_Shown(object sender, EventArgs e)
        {
            //InitializeDataSource();
        }

        private void reportViewer1_Print(object sender, ReportPrintEventArgs e)
        {

        }
    }
}
