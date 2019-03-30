
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
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using DocumentFormat.OpenXml;

    using GODInventory.MyLinq;
    using GODInventory.ViewModel;
    using GODInventory.ViewModel.EDI;
    using System.Data.Entity.Validation;
    using System.IO;


    public partial class ImportPrendingOrderForm : Form
    {

        public string formTitle = "Import HACCYU.csv";
        List<XLSXImportPrendingOrder> models;
        private SortableBindingList<XLSXImportPrendingOrder> sortablemodelsList;
        public ImportPrendingOrderForm()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
        }

        public string FormTitle
        {
            get { return this.titleLabel.Text; }
            set
            {
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
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pathTextBox.Text = openFileDialog1.FileName;
            }
            if (this.pathTextBox.Text != "")
            {
                bool success = true;

                models = new List<XLSXImportPrendingOrder>();

                try
                {

                    models = readExcel(this.pathTextBox.Text);
                    this.bindingSource1.DataSource = null;
                    dataGridView1.AutoGenerateColumns = false;

                    if (models != null)
                    {
                        // 记录DataGridView改变数据          
                        sortablemodelsList = new SortableBindingList<XLSXImportPrendingOrder>(models);
                        this.bindingSource1.DataSource = sortablemodelsList;

                        dataGridView1.DataSource = this.bindingSource1;
                    }
                }
                catch (EndOfStreamException exception)
                {
                    models.Clear();
                    success = false;
                }
                catch (Exception exception)
                {
                    models.Clear();
                    success = false;
                    MessageBox.Show(string.Format("{0}", exception.Message));

                }


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


        private bool ImportOrderTxt(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {

            WorkerArgument arg = e.Argument as WorkerArgument;

            bool success = true;


            using (var ctx = new GODDbContext())
            {

                XLSXImportPrendingOrder model = null;
                int progress = 0;
                int count = 0;
                //using (var ctxTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {

                        arg.OrderCount = models.Count;


                        List<XLSXImportPrendingOrder> we = models.FindAll(s => s.県別 != null);

                        long m = we.Count;
                        if (m > 0)
                        {
                            for (var i = 0; i < models.Count; i++)
                            {

                                if (worker.CancellationPending == true)
                                {
                                    e.Cancel = true;
                                    throw new Exception("キャンセルできました!");
                                }
                                arg.CurrentIndex = i + 1;

                                progress = Convert.ToInt16(((i + 1) * 1.0 / models.Count) * 100);
                                model = models.ElementAt(i);


                                //vba
                                //models[i].出荷No = DateTime.Now.ToString("yyMMdd") + models[i].車番;
                                string ShipNO = "";
                                int j = 0;
                                int ii = 0;

                                string sql = "";

                                t_orderdata orderdata = new t_orderdata();
                                orderdata.県別 = models[i].県別;
                                orderdata.店舗コード = Convert.ToInt32(models[i].店舗コード);
                                orderdata.店舗名漢字 = models[i].店舗名漢字;
                                orderdata.自社コード = Convert.ToInt32(models[i].自社コード);
                                orderdata.品名漢字 = models[i].品名漢字;
                                orderdata.最小発注単位数量 = Convert.ToInt32(models[i].最小発注単位数量);
                                orderdata.口数 = Convert.ToInt32(models[i].口数);
                                orderdata.発注数量 = Convert.ToInt32(models[i].発注数量);
                                orderdata.原単価_税抜_ = Convert.ToInt32(models[i].原単価税抜);
                                orderdata.原価金額_税込_ = orderdata.発注数量 * orderdata.原単価_税抜_;// Convert.ToInt32(models[i].原価金額税抜);
                                orderdata.原単価_税込_ = 0;
                                orderdata.税額 = 0;


                                
                                ctx.t_orderdata.Add(orderdata);
                                ctx.SaveChanges();

                                if (arg.CurrentIndex % 25 == 0)
                                {
                                    backgroundWorker1.ReportProgress(progress, arg);
                                }
                            }
                        }
                        backgroundWorker1.ReportProgress(100, arg);

                        //  ctxTransaction.Commit();

                        e.Result = string.Format("{0}件の受注伝票が登録できました", count);
                    }

                    catch (Exception exception)
                    {
                       // ctxTransaction.Rollback();
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
            if (this.backgroundWorker1.IsBusy)
            {

                this.backgroundWorker1.CancelAsync();
                // Disable the Cancel button.
                this.cancelButton.Enabled = false;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private List<XLSXImportPrendingOrder> readExcel(string fileName)
        {
            List<XLSXImportPrendingOrder> models = new List<XLSXImportPrendingOrder>();

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                string version = string.Empty;
                WorkbookPart wbPart = document.WorkbookPart;
                List<Sheet> sheets = wbPart.Workbook.Descendants<Sheet>().ToList();
                var versionSheet = wbPart.Workbook.Descendants<Sheet>().FirstOrDefault(c => c.Name == "Sheet1");
                WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(versionSheet.Id);

                if (versionSheet == null)
                {
                    throw new Exception(String.Format("Can not find price by sheet", "", ""));

                }

                //保存之前需要检验属性是否正确
                if (!validateAttributes(worksheetPart, wbPart))
                {
                    return null;
                }


                int indexrow = 5;
                int rocount = worksheetPart.Worksheet.Count();

                indexrow = 2;

                foreach (Row row in worksheetPart.Worksheet.Descendants<Row>())
                {
                    if (indexrow < 1)
                    {
                        indexrow++;

                        continue;
                    }
                    XLSXImportPrendingOrder item = new XLSXImportPrendingOrder();
                    #region ITEM
                    Cell theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "A" + indexrow).FirstOrDefault();
                    string type = string.Empty;
                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);

                        item.県別 = version;

                    }
                    else
                    {
                        break;

                        throw new Exception(String.Format("ploading file does not have version number!", "", ""));

                    }

                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "B" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.店舗コード = version;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "C" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.店舗名漢字 = version;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "D" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.自社コード = version;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "E" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.品名漢字 = version;
                    }

                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "F" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.最小発注単位数量 = version;
                    }


                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "G" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.口数 = version;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "H" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.発注数量 = version;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "I" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.原単価税抜 = version;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "J" + indexrow).FirstOrDefault();

                    if (theCell != null)
                    {
                        version = GetCellValue(wbPart, theCell);
                        item.原価金額税抜 = version;
                    }

                    #endregion

                    if (item.県別 == null || item.県別 == "")
                        break;

                    models.Add(item);

                    indexrow++;
                }

                return models;

            }



        }
        public static string GetCellValue(WorkbookPart wbPart, Cell theCell)
        {
            string value = theCell.InnerText;
            //  String value1 = theCell.CellValue.InnerText;
            if (theCell.DataType != null)
            {
                switch (theCell.DataType.Value)
                {
                    case CellValues.SharedString:
                        var stringTable = wbPart.
                          GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                        if (stringTable != null)
                        {
                            value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                        }
                        break;

                    case CellValues.Boolean:
                        switch (value)
                        {
                            case "0":
                                value = "FALSE";
                                break;
                            default:
                                value = "TRUE";
                                break;
                        }
                        break;
                }
            }
            return value;
        }
        public String GetValue(Cell cell, WorkbookPart wbPart)
        {
            SharedStringTablePart stringTablePart = wbPart.SharedStringTablePart;
            if (cell.ChildElements.Count == 0)
                return null;
            String value = cell.CellValue.InnerText;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            return value;
        }

        public static String GetValue(Cell cell, SharedStringTablePart stringTablePart)
        {

            if (cell.ChildElements.Count == 0)

                return null;

            //get cell value

            String value = cell.CellValue.InnerText;

            //Look up real value from shared string table

            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))

                value = stringTablePart.SharedStringTable

                .ChildElements[Int32.Parse(value)]

                .InnerText;

            return value;

        }

        private void ImportShipNumberForm_Load(object sender, EventArgs e)
        {

        }



        private bool validateAttributes(WorksheetPart worksheetPart, WorkbookPart wbPart)
        {

            string msg = String.Empty;
            var validated = true;

            Cell theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "A" + 1).FirstOrDefault();
            if (theCell != null)
            {
                string version = GetCellValue(wbPart, theCell);
                if (!version.Contains("県別"))
                    validated = false;

            }
            theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "D" + 1).FirstOrDefault();
            if (theCell != null)
            {
                string version = GetCellValue(wbPart, theCell);
                if (!version.Contains("自社コード"))
                    validated = false;

            }

            if (validated == false)
            {
                msg = "选择文件错误，请检查！";
                errorProvider1.SetError(pathTextBox, msg);
            }
            return validated;
        }


    }
}
