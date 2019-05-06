using GODInventory.MyLinq;
using GODInventory.NAFCO.EDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    public partial class ImportReceivedCSVForm : Form
    {
        public ImportReceivedCSVForm()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
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

        public int ProgressValue
        {
            get { return this.progressBar1.Value; }
            set { progressBar1.Value = value; }
        }


        private void openFileBtton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool success = ImportJuryouTxt(pathTextBox.Text, worker, e);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkerArgument arg = e.UserState as WorkerArgument;
            if (!arg.HasError)
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

        private bool ImportJuryouTxt(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            bool success = true;
            WorkerArgument arg = e.Argument as WorkerArgument;
            ReceivedCSVOrderHeadModel orderHead = null;
            List<ReceivedCSVOrderModel> models;
            try
            {
                //byte[] first_line = null;
                //byte[] line = null;
                using (var br = new StreamReader(path, Encoding.GetEncoding("shift_jis")))
                {
                    orderHead = new ReceivedCSVOrderHeadModel(br);
                    //Console.WriteLine(" write head ={0}", order_head.DetailCount);
                    
                }
            }
            catch (EndOfStreamException exception)
            {                
                success = false;
            }
            catch (Exception exception)
            {                
                success = false;
            }

            using (var ctx = new GODDbContext())
            {
                int progress = 0;
                
                using (var ctxTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        List<string> sqls = new List<string>(100);
                        
                        arg.OrderCount = orderHead.DetailCount;
                        models = orderHead.Models;
                        for (var i = 0; i < models.Count; i++)
                        {
                            if (worker.CancellationPending == true)
                            {
                                e.Cancel = true;
                                throw new Exception("キャンセルできました!");
                            }
                            var model = models.ElementAt(i);
                            progress = Convert.ToInt16(((i + 1) * 1.0 / models.Count) * 100);
                            // use sql instead of orm
                            int count = 0;
                            
                                //sql_parameters = model.ToSqlArguments(shop, item);
                                var sql = model.ToRawSql();
                                //Console.WriteLine("sql = #{0}", sql);
                                
                                if( ctx.Database.ExecuteSqlCommand(sql) ==0 ){
                                    throw new Exception(String.Format("過去3か月の記録に店番 {0}({1}) で伝票番号  {2} in  の伝票は見つかりません.", model.StoreName, model.StoreCode, model.InvoiceCode));
                                }
                                
                                arg.CurrentIndex = i + 1;
                                if (i % 25 == 0)
                                {
                                    backgroundWorker1.ReportProgress(progress, arg);
                                }
                           
                            
                        }
                        backgroundWorker1.ReportProgress(100, arg);
                        ctxTransaction.Commit();
                        e.Result = string.Format("{0}件の受注伝票が登録できました", models.Count);

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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker1.IsBusy)
            {

                this.backgroundWorker1.CancelAsync();
                // Disable the Cancel button.
                this.cancelButton.Enabled = false;
            }
        }

    }
}
