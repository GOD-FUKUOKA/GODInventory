
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
    using GODInventory.MyLinq;
    using GODInventory.ViewModel;
    using GODInventory.ViewModel.EDI;
    using System.Data.Entity.Validation;
    using System.IO;

    public partial class ImportOrderTextForm : Form
    {
        public ImportOrderTextForm()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮

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
            EDITxtHandler.CreateHACCYUEdidata(this.pathTextBox.Text);
            this.ProgressValue = 0;

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
            int orderCount = 0;
            int importedCount = 0;

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
                // {0}件の受注伝票が登録できました
                // 数据格式为 :orderCount/:importedCount
                var vals = e.Result.ToString().Split('/');
                if (vals.Length == 2)
                {
                    orderCount = Int32.Parse(vals[0]);
                    importedCount = Int32.Parse(vals[1]);

                    MessageBox.Show(string.Format("{0}件の受注伝票が登録できました", importedCount));
                }
                else {
                    MessageBox.Show(e.Result.ToString());

                }
            }

            // 提示重新导入
            if (orderCount != importedCount)
            {
                //订单数据5条，导入数据0条，数据不一致，是否重新导入？
                // DialogResult res = MessageBox.Show(string.Format("伝票{0}枚に対して、{1}枚導入されました。枚数は一致しませんが、再度導入しますか？", orderCount, importedCount), "誤った", MessageBoxButtons.YesNo);

                var form = new ErrorDialog();
                form.OrderCount = orderCount;
                form.ImportedCount = importedCount;
                form.DataFilePath = pathTextBox.Text;

                form.ShowDialog();

                if (form.ErrorDialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    importButton_Click(this, EventArgs.Empty);

                }
            }
            
        }


        private bool ImportOrderTxt(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string localPath = EDITxtHandler.CopyHACCYUFile(path);

            WorkerArgument arg = e.Argument as WorkerArgument;

            bool success = true;
            //File.ReadLines(path, Encoding.)
            //File.ReadAllBytes(path);

            //var lines = ConvertToUtf8Strings(path);
            List<OrderModel> models = new List<OrderModel>();
            OrderHeadModel orderHead = null;
            try
            {
                //byte[] first_line = null;
                //byte[] line = null;
                using (BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    orderHead = new OrderHeadModel(br);
                    //Console.WriteLine(" write head ={0}", order_head.DetailCount);
                    for (var i = 0; i < orderHead.DetailCount; i++)
                    {
                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            throw new Exception("キャンセルできました!");
                        }
                        int progress = Convert.ToInt16((i + 1) * 0.5 / orderHead.DetailCount * 100);
                        models.Add(new OrderModel(br));
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
                var date = DateTime.Now;
                var three_month_ago = date.AddMonths(-2);
                List<t_itemlist> items = ctx.t_itemlist.ToList();
                //List<t_pricelist> prices = ctx.t_pricelist.ToList();
                List<v_itemprice> prices = OrderSqlHelper.GetItemPriceList(ctx);

                //= ( from t_orderdata o  in ctx.t_orderdata
                //   where   o.Status == OrderStatus.Pending || o.Status == OrderStatus.WaitToShip || o.Status == OrderStatus.PendingShipment || o.Status == OrderStatus.ASN || o.Status == OrderStatus.Received
                //   group o by new { o.店舗コード, o.商品コード} into g
                //    select new v_storeorder { 店舗コード = g.Key.店舗コード, 商品コード = g.Key.商品コード }).ToList();
                 
                List<t_orderdata> orders = (from t_orderdata o in ctx.t_orderdata
                                            where o.発注日 <= date && o.発注日 > three_month_ago
                                            select o).ToList();    
                List<t_shoplist> shops = ctx.t_shoplist.ToList();

                OrderModel model = null;
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
                            var shop = shops.FirstOrDefault(s => s.店番 == model.StoreCode);
                            if (shop == null)
                            {
                                throw new Exception(String.Format("Can not find shop by shopcode {0}", model.StoreCode));
                            }
                            //if (shop.warehousename == null || shop.warehousename == string.Empty)
                            //{
                            //    throw new Exception(String.Format("Can not find shop default warehouse name for shop {0}", shop.店名));
                            //}
                            var price = prices.FirstOrDefault(s => s.店番 == shop.店番 && s.自社コード==item.自社コード);
                            if (price == null)
                            {
                                throw new Exception(String.Format("Can not find price by 自社コード {0} and 店番 {1}", item.自社コード, model.StoreCode));
                            }
                            if (price.fee < 0)
                            {
                                throw new Exception(string.Format("can not find freight by 店舗コード {0} and 自社コード {1}", model.StoreCode, item.自社コード));
                            }
                            //sql_parameters = model.ToSqlArguments(shop, item);
                            var sql = model.ToRawSql(shop, item, price, orders);
                            //Console.WriteLine("sql = #{0}", sql);

                            if (sql != null)
                            {
                                sqls.Add(sql);
                                count++;
                            }
                            else {
                                Console.WriteLine("sql is null");
                            }
                            if ((sqls.Count > 0) && ((i == models.Count - 1) || (sqls.Count % 25 == 0)))
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

                        string sql2 = string.Format("Update t_edidata set is_sent = 1, sent_at=NOW() where データID='{0}' and 管理連番={1} and レコード件数={2} and Id>0;", orderHead.SデータID, orderHead.I管理連番, count);
                        ctx.Database.ExecuteSqlCommand(sql2);

                        ctxTransaction.Commit();

                        e.Result = string.Format("{0}/{1}", orderHead.DetailCount, count);
                    }
                   
                    catch (Exception exception)
                    {
                        LogHelper.WriteLog("ImportOrder", exception);
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

        }

    }
}
