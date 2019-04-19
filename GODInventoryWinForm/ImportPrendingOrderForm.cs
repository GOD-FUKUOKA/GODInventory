
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

        List<XLSXImportPrendingOrder> models;
        private SortableBindingList<XLSXImportPrendingOrder> sortablemodelsList;

        public int SavedOrderCount {get; set;}

        private string totalRecordFormat = "合計 {0} 行";

        public ImportPrendingOrderForm()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
            this.SavedOrderCount = 0;
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
                        this.totalRecordLabel.Text = string.Format(totalRecordFormat, models.Count);
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
                this.SavedOrderCount = 0;


            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            this.importButton.Enabled = false;
            this.closeButton.Enabled = false;
            
            bool success = ImportOrderTxt(pathTextBox.Text);
            this.closeButton.Enabled = true;
            if (this.SavedOrderCount == 0) {
                this.importButton.Enabled = true;            
            }


        }

                

        private bool ImportOrderTxt(string path )
        {

 
            bool success = true;


            using (var ctx = new GODDbContext())
            {
                var shopids = models.Select(o => Convert.ToInt32(o.店舗コード)).ToList();
                var productids = models.Select(o => Convert.ToInt32(o.自社コード)).ToList();
                var products = ctx.t_itemlist.Where(o => productids.Contains(o.自社コード)).ToList();

                var itemprices = OrderSqlHelper.GetItemPriceList(ctx, productids);
                var shops = OrderSqlHelper.GetShopList(ctx, shopids);


                XLSXImportPrendingOrder model = null;
                int progress = 0;
                int count = 0;
                using (var ctxTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
 
                        count = models.Count;
                        if (count > 0)
                        {
                            List<int> validModelIndexes = new List<int>();
                             
                            for (var i = 0; i < models.Count; i++)
                            {
 
 
                                progress = Convert.ToInt16(((i + 1) * 1.0 / models.Count) * 100);
                                model = models.ElementAt(i);

                                t_orderdata orderdata = new t_orderdata();
                                orderdata.県別 = model.県別;
                                orderdata.店舗コード = Convert.ToInt32(model.店舗コード);
                                orderdata.店舗名漢字 = model.店舗名漢字;
                                orderdata.自社コード = Convert.ToInt32(model.自社コード);
                                orderdata.品名漢字 = model.品名漢字;
                                orderdata.最小発注単位数量 = Convert.ToInt32(model.最小発注単位数量);
                                orderdata.口数 = Convert.ToInt32(model.口数);
                                orderdata.発注数量 = Convert.ToInt32(model.発注数量);
                                orderdata.原単価_税抜_ = Convert.ToInt32(model.原単価税抜);

                                var shop = shops.FirstOrDefault(o => o.店番 == orderdata.店舗コード);
                                var price = itemprices.FirstOrDefault(o =>  o.店番 == orderdata.店舗コード && o.自社コード == orderdata.自社コード);
                                if (shop == null) {
                                    throw new Exception(string.Format("店番 {0} の店舗は登録されていません", model.店舗コード));
                                }
                                if (price == null)
                                {
                                    //can not find pricelist by 自社コード {0}
                                    throw new Exception(string.Format("自社コード{0}の価格データが不足しています", model.自社コード));
                                }
                                if (price.fee < 0) {
                                    //can not find freight by 店舗コード {0} and 自社コード {1}
                                    throw new Exception(string.Format("店舗コード{0}と自社コード{1}との組合せの価格データが不足しています", model.店舗コード, model.自社コード));                                
                                }

                                orderdata.伝票番号 = OrderHelper.GenerateOrderNumber(orderdata.店舗コード);

                                bool valid = OrderHelper.InitializeOrderByXlsxOrder(orderdata, shop, price);
                                if (valid) {
                                    validModelIndexes.Add(i);
                                    ctx.t_orderdata.Add(orderdata);
                                    var saved = ctx.SaveChanges();
                                    if (saved > 0) { 
                                        SavedOrderCount++;
                                    }
                                }

                               
                            }
                            MessageBox.Show(string.Format("{0}件の受注伝票が登録できました", SavedOrderCount));
                        }

                          ctxTransaction.Commit();

                    }

                    catch (Exception exception)
                    {
                        ctxTransaction.Rollback();

                        MessageBox.Show( exception.Message );
                        success = false;
                    }
                }// transaction

            }// ctx
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
                var versionSheet = wbPart.Workbook.Descendants<Sheet>().FirstOrDefault( );
                WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(versionSheet.Id);

                if (versionSheet == null)
                {
                    throw new Exception(String.Format("Can not find sheet！" ));

                }

                //保存之前需要检验属性是否正确
                if (!validateAttributes(worksheetPart, wbPart))
                {
                    return null;
                }


                int rocount = worksheetPart.Worksheet.Count();
                int rowindex = 0;

                foreach (Row row in worksheetPart.Worksheet.Descendants<Row>())
                {
                    if (rowindex < 1)// 数据在第二行开始
                    {
                        rowindex++;

                        continue;
                    }
                    XLSXImportPrendingOrder item = new XLSXImportPrendingOrder();

                    #region 处理每一行数据
                    int cellindex = 0;
                    foreach (Cell cell in row) {
                        // Console.WriteLine("cell = {0}", cell);
                        string val = GetCellValue(wbPart, cell);
                        string rev = cell.CellReference.Value;

                        if (rev.StartsWith("A"))// A
                        {                            
                            item.県別 = val; 
                        }
                        if (rev.StartsWith("B"))
                        {
                            item.店舗コード = val; 
                        }
                        if (rev.StartsWith("C"))
                        {
                            item.店舗名漢字 = val;
                        }
                        if (rev.StartsWith("D"))
                        {
                            item.自社コード = val;
                        }
                        if (rev.StartsWith("E"))
                        {
                            item.品名漢字 = val;
                        }
                        if (rev.StartsWith("F"))
                        {
                            item.最小発注単位数量 = val;
                        }
                        if (rev.StartsWith("G"))
                        {
                            item.口数 = val;
                        }
                        if (rev.StartsWith("H"))
                        {
                            item.発注数量 = val;
                        }
                        if (rev.StartsWith("I"))
                        {
                            item.原単価税抜 = val;
                        }
                        if (rev.StartsWith("J"))
                        {
                            item.原価金額税抜 = val;
                        }
                        cellindex++;
                    }
                    

                    #endregion

                    if (string.IsNullOrEmpty(item.県別))
                    {
                        break;
                    }

                    models.Add(item);

                    rowindex++;
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


        /// <summary>
        /// 检查文件格式是否正确
        /// </summary>
        /// <param name="worksheetPart"></param>
        /// <param name="wbPart"></param>
        /// <returns></returns>
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
                msg = "选择的文件格式错误，请重新选择！";
                errorProvider1.SetError(pathTextBox, msg);
            }
            return validated;
        }


    }
}
