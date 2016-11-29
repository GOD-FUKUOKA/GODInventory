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
                Create1DB();


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

        private void Create1DB()
        {
            try
            {
                // 1.设置条形码规格
                EncodingOptions encodeOption = new EncodingOptions();
                encodeOption.Height = 130; // 必须制定高度、宽度
                encodeOption.Width = 240;

                // 2.生成条形码图片并保存
                ZXing.BarcodeWriter wr = new BarcodeWriter();
                wr.Options = encodeOption;
                wr.Format = BarcodeFormat.EAN_13; //  条形码规格：EAN13规格：12（无校验位）或13位数字
                Bitmap img = wr.Write("9787302380979"); // 生成图片
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\EAN_13-" + "9787302380979" + ".jpg";
                img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                //// 3.读取保存的图片
                //this.ImgPathTxt.Text = filePath;
                //this.barCodeImg.Image = img;
                //定位图片存放位置

                Graphics g = Graphics.FromImage(img);
                g.DrawImage(img, 270, 170, 612, 573);

                #region 向 reportViewer1 插入条形码

                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] param = new ReportParameter[] { new ReportParameter("LogoUrl", filePath) };
                byte[] imgBytes = bmpToBytes(img);
                string strB64 = Convert.ToBase64String(imgBytes);
                ReportParameter rpTest = new ReportParameter("RPTest", strB64);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpTest });

                #endregion
                this.reportViewer1.BackgroundImage = img;

                //  MessageBox.Show("保存成功：" + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
                return;

                throw ex;
            }
        }
        private byte[] bmpToBytes(Bitmap bitmap)
        {
            System.IO.MemoryStream ms = null;

            try
            {

                ms = new System.IO.MemoryStream();
                bitmap.Save(ms, ImageFormat.Bmp);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
    }
}
