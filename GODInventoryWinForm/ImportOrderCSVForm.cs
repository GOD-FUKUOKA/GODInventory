﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    using GODInventory;
    using GODInventory.MyLinq;
    using GODInventory;
    using GODInventory.NAFCO.EDI;
    using System.Data.Entity.Validation;
    using System.IO;

    public partial class ImportOrderCSVForm : Form
    {

        public string formTitle = "Import HACCYU.csv";

        public ImportOrderCSVForm()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
        }

        public string FormTitle 
        {
            get { return this.titleLabel.Text; }
            set {
                this.Text = value;
                this.titleLabel.Text = value;  
            }
        }

        public int ProgressValue 
         {
             get { return this.progressBar1.Value; }
             set { progressBar1.Value = value; }
         }
 

        private void openFileBtton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK) {
                this.pathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            this.importButton.Enabled = false;
            this.cancelButton.Enabled = true;
            this.closeButton.Enabled = false;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new WorkerArgument { OrderCount = 0, CurrentIndex = 0 });

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
           
            bool success = ImportOrderTxt(pathTextBox.Text, worker, e);
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkerArgument arg = e.UserState as WorkerArgument;
            if(!arg.HasError)
            {
                this.progressMsgLabel.Text = String.Format("{0}/{1}", arg.CurrentIndex, arg.OrderCount);
                this.ProgressValue = e.ProgressPercentage;
            }
            else
            {
                this.progressMsgLabel.Text = arg.ErrorMessage;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            this.cancelButton.Enabled = false;
            this.closeButton.Enabled = true;
            this.importButton.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show(string.Format("キャンセルできました!"));
            }
            else
            {
                MessageBox.Show(string.Format("{0}", e.Result));
                //this.progressMsgLabel.Text = "Great, it is done!";
            }
            
        }


        private bool ImportOrderTxt(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            
            WorkerArgument arg = e.Argument as WorkerArgument;

            bool success = true;
            //File.ReadLines(path, Encoding.)
            //File.ReadAllBytes(path);

            //var lines = ConvertToUtf8Strings(path);
            List<CSVOrderModel> models = new List<CSVOrderModel>();

            try
            {
                //byte[] first_line = null;
                //byte[] line = null;
                
                using (var br = new StreamReader(path, Encoding.GetEncoding("shift_jis")))
                {
                    CSVOrderHeadModel orderHead = new CSVOrderHeadModel(br);
                    //Console.WriteLine(" write head ={0}", order_head.DetailCount);

                    string line;
                    int i = 0;
                    while( (line = br.ReadLine()) != null && line != String.Empty)
                    {
                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            throw new Exception("キャンセルできました!");
                        }
                        var model = new CSVOrderModel(orderHead, line);
                        if (model.IsValid) 
                        {
                            models.Add(model);
                        }

                        i++;
                        //if (progress != last)
                        //
                        //    backgroundWorker1.ReportProgress(progress);
                        //    last = progress;
                        //}
                    }

                }
            }
            catch (EndOfStreamException exception)
            {
                models.Clear();
                success = false;
            }
            catch (Exception exception) {
                models.Clear();
                success = false;
            }

            using (var ctx = new GODDbContext())
            {
                var date = DateTime.Now.Date;
                var three_month_ago = date.AddMonths(-2);
                List<t_itemlist> items = ctx.t_itemlist.ToList();
                List<NafcoOrder> orders = (from NafcoOrder o in ctx.t_nafco_orders
                                            where o.発注日 <= date && o.発注日 > three_month_ago
                                            select o).ToList();
                //= ( from t_orderdata o  in ctx.t_orderdata
                //   where   o.Status == OrderStatus.Pending || o.Status == OrderStatus.WaitToShip || o.Status == OrderStatus.PendingShipment || o.Status == OrderStatus.ASN || o.Status == OrderStatus.Received
                //   group o by new { o.店舗コード, o.商品コード} into g
                //    select new v_storeorder { 店舗コード = g.Key.店舗コード, 商品コード = g.Key.商品コード }).ToList();
                    
                var shops = ctx.t_shoplist.ToList();
                var locations = ctx.t_locations.ToList();
                //var prices = ctx.t_pricelist.ToList();
                List<v_itemprice> prices = OrderSqlHelper.GetItemPriceList(ctx);

                CSVOrderModel model = null;
                int progress = 0;
                int count = 0;
                using (var ctxTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        List<string> sqls = new List<string>(100);
                        arg.OrderCount = models.Count;
                      
                        for (var i = 0; i < models.Count; i++)
                        {
                         
                            if (worker.CancellationPending == true)
                            {
                                e.Cancel = true;
                                throw new Exception("キャンセルできました!");
                            }
                            arg.CurrentIndex = i + 1;

                            progress = Convert.ToInt16( ( (i+1)*1.0 / models.Count )* 100);
                            model = models.ElementAt(i);
                            var item = items.FirstOrDefault(s => s.JANコード == model.JanCode);
                            if(item == null)
                            {
                                throw new Exception(String.Format("JANコード {0} の商品登録されていません", model.JanCode));
                            }
                            var shop = shops.FirstOrDefault(s => (s.店番 == model.StoreCode || s.店名 == model.StoreName));
                            if (shop == null)
                            {
                                throw new Exception(String.Format("Can not find shop by shopcode {0}", model.StoreCode));
                            }

                            var price = prices.FirstOrDefault(s => s.店番 == shop.店番 && s.自社コード == item.自社コード);
                            if (price == null)
                            {
                                throw new Exception(String.Format("Can not find price by 自社コード {0} and 店番 {1}", item.自社コード, model.StoreCode));
                            }

                            if (price.fee < 0)
                            {
                                throw new Exception(string.Format("can not find freight by 店舗コード {0} and 自社コード {1}", model.StoreCode, item.自社コード));
                            }

                            var location = locations.FirstOrDefault(s => s.納品場所名漢字 == model.LocationName);
                            //sql_parameters = model.ToSqlArguments(shop, item);
                            var sql = model.ToRawSql(shop, item, price, location, orders);
                            //Console.WriteLine("sql = #{0}", sql);
                            if (sql != null)
                            {
                                sqls.Add(sql);
                                count++;
                            }
                            if ( (sqls.Count >0 ) && ( (i == models.Count - 1) || (sqls.Count % 25 == 0)) )
                            {
                                
                                var multisql = String.Join("", sqls.ToArray());
                                ctx.Database.ExecuteSqlCommand(multisql);
                                sqls.Clear();
                            }
                            //ctx.Database.ExecuteSqlCommand(sql_parameters.SqlString, sql_parameters.Parameters);
                            // use sql instead of orm
                            if (arg.CurrentIndex % 25 == 0)
                            {
                                backgroundWorker1.ReportProgress(progress, arg);
                            }
                          

                        }
                        backgroundWorker1.ReportProgress(100, arg);

                        ctxTransaction.Commit();

                        e.Result = string.Format("{0}件の受注伝票が登録できました", count);
                    }
                   
                    catch (Exception exception)
                    {
                        ctxTransaction.Rollback();
                        if (!e.Cancel)
                        {
                            //arg.HasError = true;
                            //arg.ErrorMessage = exception.Message;
                            e.Result = exception.Message;
                        }
                        
                        success = false;
                    }
                }

            }
            return success;
        }
        private string[] ConvertToUtf8Strings(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string text_in_utf8 = EncodingUtility.ConvertShiftJisToUtf8(bytes);
            return text_in_utf8.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker1.IsBusy) {

                this.backgroundWorker1.CancelAsync();
                // Disable the Cancel button.
                this.cancelButton.Enabled = false;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
