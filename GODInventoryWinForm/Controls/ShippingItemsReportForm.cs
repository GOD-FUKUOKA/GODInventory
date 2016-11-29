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
using System.Drawing.Printing;
using System.Drawing.Imaging;
using ZXing.Common;
using ZXing;


namespace GODInventoryWinForm.Controls
{
    public partial class ShippingItemsReportForm : Form
    {
        public List<t_orderdata> OrderEnities { get; set; }
        public List<t_itemlist> ItemEnities { get; set; }
        // Bitmap img;
        public ShippingItemsReportForm()
        {
            InitializeComponent();
            InitializeReportEvent();
        }

        private void InitializeReportEvent()
        {
            //this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;


            //this.reportViewer1.Width = 29;
            //this.reportViewer1.Height = 21;
            PageSettings pageset = new PageSettings();
            pageset.Landscape = true;
            //var pageSettings = this.reportViewer1.GetPageSettings();
            pageset.PaperSize = new PaperSize()
            {
                //Width = 210,
                //Height = 297
                Width = 827,
                Height = 1169
            };
            pageset.Margins = new Margins() { Left = 10, Top = 10, Bottom = 10, Right = 10 };
            reportViewer1.SetPageSettings(pageset);

        }
        private void Print(string printerName)
        {
            PrintDocument printDoc = new PrintDocument();
            if (printerName.Length > 0)
            {
                printDoc.PrinterSettings.PrinterName = printerName;
            }
            foreach (PaperSize ps in printDoc.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName == "A4")
                {
                    printDoc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                    printDoc.DefaultPageSettings.PaperSize = ps;
                    // printDoc.PrinterSettings.IsDefaultPrinter;//知道是否是预设定的打印机
                }
            }
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer " + printerName);
                System.Diagnostics.Debug.WriteLine(msg);
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            int ass = 0;
            using (var ctx = new GODDbContext())
            {
                // var m_streams = ItemEnities.GroupBy(x => x.ジャンル).Select(y => y.First());

                Metafile pageImage = new Metafile("234");
                ev.Graphics.DrawImage(pageImage, 0, 0, 827, 1169);//設置打印尺寸 单位是像素
                ass++;
                ev.HasMorePages = (ass < 6);
            }
        }





        public void InitializeDataSource(List<t_orderdata> orders)
        {


            OrderEnities = orders;

            if (OrderEnities != null)
            {
                var orders1 = OrderEnities.Where(o => o.ジャンル != 1003).ToList();
                var orders2 = OrderEnities.Where(o => o.ジャンル == 1003).ToList();
                // 分别使用不同报表解决出现空白页问题
                if (orders1.Count == 0 && orders2.Count > 0)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "GODInventoryWinForm.Reports.ShippingRCItemsReport.rdlc";
                }
                else
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "GODInventoryWinForm.Reports.ShippingItemsReport.rdlc";
                }
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ShippingItems", orders1));
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ShippingRCItems", orders2));
              


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
