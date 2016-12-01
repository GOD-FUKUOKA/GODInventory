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
using ZXing.Common;
using ZXing;
using System.Drawing.Imaging;
using System.IO;


namespace GODInventoryWinForm.Controls
{
    public partial class ReceivedOrdersReportForm : Form
    {
        public List<v_pendingorder> OrderEnities { get; set; }
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

            if (OrderEnities != null)
            {
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var ctx = new GODDbContext())
                {
                    var gos = OrderEnities.GroupBy(x => x.出荷No).Select(y => y.First());

                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", gos));

                

                    var order = OrderEnities.First();

                    Create1DB(order.出荷No.ToString());

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
                var orders = OrderEnities.Where(o => o.出荷No == chuhe_no).ToList();
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
            using (var ctx = new GODDbContext())
            {
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

        private void Create1DB(string 出荷No)
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
                //
                出荷No = 出荷No.PadLeft(13, '0');
                Bitmap img = wr.Write(出荷No); // 生成图片
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\EAN_13-" + 出荷No + ".jpg";//"9787302380979"
                img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                //// 3.读取保存的图片
                //this.ImgPathTxt.Text = filePath;
                //this.barCodeImg.Image = img;
                //定位图片存放位置

                Graphics g = Graphics.FromImage(img);
                g.DrawImage(img, 270, 170, 612, 573);

                #region 向 reportViewer1 插入条形码
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "GODInventoryWinForm.Reports.ReceivedOrderDetailReport.rdlc";
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] image = new ReportParameter[1];
                string path = "file:///" + Application.StartupPath + "\\EAN_13-0000000000000.jpg";
               // path = "file:///C:/EAN_13-9787302380979.jpg";

                image[0] = new ReportParameter("image1", path);
                this.reportViewer1.LocalReport.SetParameters(image);
                return;

                ReportParameter params2;
                reportViewer1.LocalReport.EnableExternalImages = true;
                params2 = new ReportParameter("Report_Parameter_1", "file:///c:/EAN_13-9787302380979.jpg");//路径全部用”/“
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { params2 });

                return;

                //reportViewer1.LocalReport.EnableExternalImages = true;
                //ReportParameter[] param = new ReportParameter[] { new ReportParameter("LogoUrl", filePath) };
                //byte[] imgBytes = bmpToBytes(img);
                //string strB64 = Convert.ToBase64String(imgBytes);
                //ReportParameter rpTest = new ReportParameter("RPTest", strB64);
                //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpTest });

                #endregion
                File.Delete(filePath);


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
