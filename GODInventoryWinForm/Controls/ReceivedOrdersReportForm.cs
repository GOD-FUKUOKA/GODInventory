using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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
        public Hashtable BarcodeHashTable { get; set; }

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
            BarcodeHashTable = new Hashtable();
            OrderEnities = orders;

            if (OrderEnities != null)
            {
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var ctx = new GODDbContext())
                {
                    var gos = OrderEnities.GroupBy(x => x.出荷No).Select(y => y.First());

                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReportOrders", gos));

                    //ReportParameter p = new ReportParameter("OrderCount", orders.Count.ToString());
                    //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });

                    foreach (var go in gos)
                    {
                        var bitmap = GenerateBarCodeBitmap(go.出荷No.ToString("D18"));
                        BarcodeHashTable[go.出荷No] = BmpToBytes(bitmap);
                        //go.BarcodeImagePath = GenerateBarCodeImage(go.出荷No.ToString());
                        go.SubOrderCount = OrderEnities.Count(o => o.出荷No == go.出荷No);
                    }
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReportOrders", gos));

                }
            }

        }


        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            var chuhe_no = Convert.ToInt64(e.Parameters["OrderChuHeNo"].Values.First());
            var s = e.ReportPath;
            Console.WriteLine(" ---- ReportPath:" + s);
            e.DataSources.Clear();
            if (s == "ReceivedOrderReport" || s == "ReceivedOrderReport2")
            {
                var orders = OrderEnities.Where(o => o.出荷No == chuhe_no).ToList();

                var orderFirst = orders.First();

                orderFirst.BarcodeImage = (byte[])BarcodeHashTable[orderFirst.出荷No];

                var orderKeZhuCount = orders.Count(o => o.発注形態区分 == (int)OrderReasonEnum.客注);
                var orderADCount = orders.Count(o => o.発注形態区分 == (int)OrderReasonEnum.広告);
                var orderYongDuCount = orders.Count(o => o.発注形態区分 == (int)OrderReasonEnum.用度品);

                var orderreason = new List<v_orderreason>() { new v_orderreason() { hasOrderAD = orderADCount, hasOrderKeZhu = orderKeZhuCount, hasOrderYongDu = orderYongDuCount } };
                e.DataSources.Add(new ReportDataSource("DataSet1", new List<v_pendingorder>() { orderFirst }));
                e.DataSources.Add(new ReportDataSource("DataSet2", orderreason));

                if (s == "ReceivedOrderReport")
                {
                    var orderQuery = OrderEnities.Where(o => o.出荷No == chuhe_no);
                    //page1 左侧数据
                    var leftOrders = orderQuery.Take(10).ToList();
                    e.DataSources.Add(new ReportDataSource("DataSet3", leftOrders));
                    var rightOrders = orderQuery.Skip(10).Take(10).ToList();
                    e.DataSources.Add(new ReportDataSource("DataSet4", rightOrders));
                }


            }
            else if (s == "ReceivedOrderDetailReport")
            {
                var orders = OrderEnities.Where(o => o.出荷No == chuhe_no);
                e.DataSources.Add(new ReportDataSource("DataSet1", orders));
            }
            else if (s == "SubReceivedOrderReport")
            {
                var order_count = Convert.ToInt64(e.Parameters["OrderCount"].Values.First());
                // 如果数据超出 20 条则显示到本 RDLc 中
                var orderQuery = OrderEnities.Where(o => o.出荷No == chuhe_no);
                var orderFirst = orderQuery.First();
                orderFirst.BarcodeImage = (byte[])BarcodeHashTable[orderFirst.出荷No];

                e.DataSources.Add(new ReportDataSource("DataSet1", new List<v_pendingorder>() { orderFirst }));

                var leftOrders = orderQuery.Skip(20).Take(20).ToList();
                //var leftOrders = orderQuery.Skip(5).Take(20).ToList();
                e.DataSources.Add(new ReportDataSource("DataSet3", leftOrders));
                var rightOrders = orderQuery.Skip(40).Take(20).ToList();
                //var rightOrders = orderQuery.Skip(8).Take(20).ToList();
                e.DataSources.Add(new ReportDataSource("DataSet4", rightOrders));

            }

        }

        private void ReceivedOrdersReportForm_Load(object sender, EventArgs e)
        {
            //ReportParameter[] parameters = new ReportParameter[1];
            //parameters[0] = new ReportParameter( "orders", this.orders, false);

            //this.reportViewer1.LocalReport.DataSources.Add( this.orders);

            this.reportViewer1.RefreshReport();
            //按照单子数量判断是否显示page2 
  
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
            //using (var ctx = new GODDbContext())
            //{
            //    var oids = OrderEnities.Select(o => o.id受注データ).ToList();
            //    var edidata = (from o in ctx.t_edidata
            //                   where o.管理連番 == order.ASN管理連番
            //                   select o).First();

            //    edidata.is_printed = true;
            //    edidata.printed_at = DateTime.Now;
            //    string sql = string.Format("UPDATE t_orderdata SET `Status`={1}  WHERE `id受注データ` in ({0})", String.Join(",", oids), (int)OrderStatus.Shipped);
            //    int count = ctx.Database.ExecuteSqlCommand(sql);
            //    Debug.Assert(count == OrderEnities.Count);
            //    ctx.SaveChanges();
            //}
        }


        private Bitmap GenerateBarCodeBitmap(string chuHeNo)
        {
            // 1.设置条形码规格
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 80; // 必须制定高度、宽度
            encodeOption.Width = 500;
            encodeOption.PureBarcode = true;
            // 2.生成条形码图片并保存
            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128; //  条形码规格：EAN13规格：12（无校验位）或13位数字

            Bitmap img = wr.Write(chuHeNo); // 生成图片

            return img;
        }

        private string GenerateBarCodeImage(string 出荷No)
        {
            string filePath = BuildBarCodeFilePath(出荷No);
            try
            {
                // 1.设置条形码规格
                EncodingOptions encodeOption = new EncodingOptions();
                encodeOption.Height = 130; // 必须制定高度、宽度
                encodeOption.Width = 240;

                // 2.生成条形码图片并保存
                ZXing.BarcodeWriter wr = new BarcodeWriter();
                wr.Options = encodeOption;
                wr.Format = BarcodeFormat.CODE_128; //  条形码规格：EAN13规格：12（无校验位）或13位数字

                Bitmap img = wr.Write(出荷No); // 生成图片

                img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                //// 3.读取保存的图片
                //this.ImgPathTxt.Text = filePath;
                //this.barCodeImg.Image = img;
                //定位图片存放位置

                Graphics g = Graphics.FromImage(img);
                g.DrawImage(img, 270, 170, 612, 573);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
                return null;

            }
            return filePath;
        }

        private string BuildBarCodeFilePath(string 出荷No)
        {
            string barcode = "CODE_128-" + 出荷No + ".jpg";

            string filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, barcode);

            return filePath;
        }

        private byte[] BmpToBytes(Bitmap bitmap)
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
