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
using System.Diagnostics;


namespace GODInventoryWinForm.Controls
{
    public partial class ReceivedOrdersReportForm : Form
    {
        public List<v_pendingorder> OrderEnities{ get; set;}
        public List<t_itemlist> ItemEnities { get; set; }

        public ReceivedOrdersReportForm()
        {
            InitializeComponent();
            InitializeReportEvent();           
        }

        private void InitializeReportEvent()
        {
                this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        public void InitializeDataSource(List<v_pendingorder> orders) 
        {
            OrderEnities = orders;

            if (OrderEnities != null) {
                this.reportViewer1.LocalReport.DataSources.Clear();
                
                using (var ctx = new GODDbContext())
                {
                    var gos = OrderEnities.GroupBy(x => x.出荷No).Select(y => y.First());

                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", gos));
                }            
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


        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            var chuhe_no = Convert.ToInt64(e.Parameters["OrderChuHeNo"].Values.First());
            var s = e.ReportPath;
            e.DataSources.Clear();
            if (s == "ReceivedOrderReport" || s == "ReceivedOrderReport2")
            {
                var orders =  OrderEnities.Where(o => o.出荷No == chuhe_no).ToList();
                var orderFirst = new List<v_pendingorder>() { orders.First() };
                var orderKeZhuCount = orders.Count(o => o.発注形態区分 == (int)OrderReasonEnum.客注);
                var orderADCount = orders.Count(o => o.発注形態区分 == (int)OrderReasonEnum.広告);
                var orderYongDuCount = orders.Count(o => o.発注形態区分 == (int)OrderReasonEnum.用度品);

                var orderreason = new List<v_orderreason>() { new v_orderreason() { hasOrderAD = orderADCount, hasOrderKeZhu = orderKeZhuCount, hasOrderYongDu = orderYongDuCount } };
                e.DataSources.Add(new ReportDataSource("DataSet1", orderFirst));                
                e.DataSources.Add(new ReportDataSource("DataSet2", orderreason));                
            }
            else if (s == "ReceivedOrderDetailReport")
            {
                var orders = OrderEnities.Where(o => o.出荷No == chuhe_no);
                var order = new List<v_pendingorder>() { orders.First() };
                e.DataSources.Add(new ReportDataSource("DataSet1", orders));
                //e.DataSources.Add(new ReportDataSource("DataSet2", orders));
            }

            //e.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(reportName, ds1.Tables[0]));
            //throw new NotImplementedException();
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
            // ASN is printing.
            var order = OrderEnities.First();
            using (var ctx = new GODDbContext()) {
                var oids = OrderEnities.Select(o => o.id受注データ).ToList();

                var edidata = (from o in ctx.t_edidata
                               where o.管理連番 == order.ASN管理連番
                               select o).First();

                edidata.is_printed = true;
                edidata.printed_at = DateTime.Now;

                string sql = string.Format("UPDATE t_orderdata SET `Status`={1}  WHERE `id受注データ` in ({0})", String.Join(",", oids), (int)OrderStatus.Shipped);
                int count = ctx.Database.ExecuteSqlCommand(sql);
                Debug.Assert(count == OrderEnities.Count);
                ctx.SaveChanges();
            }
        }
    }
}
