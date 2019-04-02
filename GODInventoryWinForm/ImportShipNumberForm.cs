
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


    public partial class ImportShipNumberForm : Form
    {

        List<XLSXImportShipNumber> models;
        private SortableBindingList<XLSXImportShipNumber> sortablemodelsList;

        List<t_orderdata> xlsxOrderList;
        List<t_orderdata> pendingOrderList;

        public int SavedOrderCount { get; set; } 

        public ImportShipNumberForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            this.ControlBox = false;   // 设置不出现关闭按钮
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

                models = new List<XLSXImportShipNumber>();

                try
                {

                    models = readExcel(this.pathTextBox.Text);
                    this.bindingSource1.DataSource = null;

                    // 记录DataGridView改变数据          
                    sortablemodelsList = new SortableBindingList<XLSXImportShipNumber>(models);
                    this.bindingSource1.DataSource = sortablemodelsList;

                    dataGridView1.DataSource = this.bindingSource1;

                }
                catch (Exception exception)
                {
                    models.Clear();
                    success = false;
                    MessageBox.Show(string.Format("{0}", exception.Message));

                }

                //根据读取到的传票番号，读取数据库中的订单，确认订单状态

                var orderNumbers = models.Where(o => { return string.IsNullOrEmpty(o.伝票番号); }).Select(o => Convert.ToInt32(o.社内伝番));
                var orderInnerNumbers = models.Where(o => { return string.IsNullOrEmpty(o.社内伝番); }).Select(o =>Convert.ToInt32( o.社内伝番));
                OrderStatus[] orderStateRequired = { OrderStatus.Pending, OrderStatus.NotifyShipper, OrderStatus.PendingShipment };

                //var shopIds = models.

                // 查询 伝票番号和社内伝番所有订单，
                using (var ctx = new GODDbContext())
                {
                    this.xlsxOrderList = (from t_orderdata o in ctx.t_orderdata
                                    where orderNumbers.Contains(o.伝票番号) || orderInnerNumbers.Contains(o.社内伝番)
                                    select o).ToList();
                    var shopIds = xlsxOrderList.Select(o => o.店舗コード).ToList();
                    this.pendingOrderList = (from t_orderdata o in ctx.t_orderdata
                                         where shopIds.Contains(o.店舗コード) && orderStateRequired.Contains(o.Status)
                                         select o).ToList();
                }
                // 查询 店铺内所有未处理订单
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            this.importButton.Enabled = false;
            this.closeButton.Enabled = false;
            bool success = ImportOrderTxt(pathTextBox.Text);

            if (this.SavedOrderCount > 0) {
                MessageBox.Show( string.Format("{0}件の受注伝票が登録できました", this.SavedOrderCount), "INFO");            
            }


            this.importButton.Enabled = true;
            this.closeButton.Enabled = true;

        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

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


        private bool ImportOrderTxt(string path)
        {

            bool success = true;


            using (var ctx = new GODDbContext())
            {

                XLSXImportShipNumber model = null;
                int progress = 0;
                int count = 0;
                using (var ctxTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {


                        for (var i = 0; i < models.Count; i++)
                        {
                            if (models[i].出荷No != "")
                            {
                                models[i].出荷No = DateTime.Now.ToString("yyMMdd") + models[i].車番;
                            }
                        }
                        List<XLSXImportShipNumber> we = models.FindAll(s => s.処理済 != null && s.処理済.Contains("未"));

                        long m = we.Count;
                        if (m > 0)
                        {
                            for (var i = 0; i < models.Count; i++)
                            {

                                progress = Convert.ToInt16(((i + 1) * 1.0 / models.Count) * 100);
                                model = models.ElementAt(i);

                                //models[i].出荷No = DateTime.Now.ToString("yyMMdd") + models[i].車番;
                                string ShipNO = "";
                                int j = 0;
                                int ii = 0;

                                string sql = "";
                                if (models[i].品名 != "二次製品" && models[i].処理済.Contains("未"))
                                {
                                    sql = "UPDATE t_orderdata  SET `出荷日` = '" + models[i].出荷日 + "', `納品日`= '" + models[i].納品日 + "', `Status` = 5, `ShipNO` = '" + models[i].出荷No + "' " + " WHERE (`伝票番号` = " + models[i].伝票番号 + " AND `店舗名漢字` = '" + models[i].卸先 + "')";
                                    models[i].処理済 = "済";
                                    ShipNO = models[i].出荷No;
                                    j = j + 1;
                                    ii = ii + 1;
                                }
                                if (j > 0 && ii < models.Count)
                                {
                                    for (int k = i; k < models.Count; k++)
                                    {
                                        if (models[i].品名 != "二次製品" && models[i].品名 == "未" && models[k].品名 == ShipNO)
                                        {
                                            sql = sql + " OR (`伝票番号` = " + models[i].伝票番号 + " AND `店舗名漢字` = '" + models[i].卸先 + "')";

                                            models[k].処理済 = "済";
                                        }
                                    }
                                }
                                if (sql != null && sql != "")
                                {
                                    ctx.Database.ExecuteSqlCommand(sql);
                                }

                                ii = 0;
                                j = 0;

                                if (models[i].品名 == "二次製品" && models[i].処理済.Contains("未"))
                                {
                                    sql = "UPDATE t_orderdata SET `出荷日` = '" + models[i].出荷日 + "', `納品日`= '" + models[i].納品日 + "', `Status` = 5, `ShipNO` = '" + models[i].出荷No + "' " + " WHERE (`社内伝番` = " + models[i].伝票番号 + " AND `店舗名漢字` = '" + models[i].卸先 + "')";
                                    models[i].処理済 = "済";
                                    ShipNO = models[i].出荷No;
                                    ii = ii + 1;
                                    j = j + 1;
                                }
                                else
                                    ii = ii + 1;

                                if (j > 0 && ii < models.Count)
                                {
                                    for (int k = i; k < models.Count; k++)
                                    {

                                        if (models[i].品名 == "二次製品" && models[i].品名 == "未" && models[k].品名 == ShipNO)
                                        {
                                            sql = sql + " OR (`社内伝番` = " + models[i].伝票番号 + " AND `店舗名漢字` = '" + models[i].卸先 + "')";
                                            models[i].処理済 = "済";
                                        }
                                    }
                                }
                                if (sql != null && sql != "")
                                {
                                    ctx.Database.ExecuteSqlCommand(sql);
                                }

                                 
                            }
                        }

                        ctxTransaction.Commit();

                    }

                    catch (Exception exception)
                    {
                        ctxTransaction.Rollback();

                        success = false;
                    }
                }

            }
            return success;
        }
       

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private List<XLSXImportShipNumber> readExcel(string fileName)
        {
            List<XLSXImportShipNumber> models = new List<XLSXImportShipNumber>();

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                string cellvalue = string.Empty;
                WorkbookPart wbPart = document.WorkbookPart;
                List<Sheet> sheets = wbPart.Workbook.Descendants<Sheet>().ToList();
                var versionSheet = wbPart.Workbook.Descendants<Sheet>().FirstOrDefault(c => c.Name == "登録用");
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


                int rowindex = 0;

                foreach (Row row in worksheetPart.Worksheet.Descendants<Row>())
                {
                    // 第5行开始是数据
                    if (rowindex < 4)
                    {
                        rowindex++;
                        continue;
                    }
                    XLSXImportShipNumber item = new XLSXImportShipNumber();


                    #region 处理每一行数据
                    foreach (Cell cell in row) {
                        //double oaDteAsDouble;
                        int cellindex = 0;
                        if (cellindex == 0)// A
                        {
                            item.出荷No = GetCellValue(wbPart, cell); ;
                        }
                        cellindex++;
                    }


                    Cell theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "A" + rowindex).FirstOrDefault();
                    string type = string.Empty;
                    double oaDteAsDouble;

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.出荷No = cellvalue;
                    }
                    else
                    {
                        throw new Exception(String.Format("xlsx does not have valid 出荷No at A5!", "", ""));
                    }

                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "B" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.配送担当 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "C" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.車番 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "D" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.ドライバー = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "E" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.方面 = cellvalue;
                    }

                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "F" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        if (double.TryParse(cellvalue, out oaDteAsDouble))
                        {
                            var date = DateTime.FromOADate(oaDteAsDouble);
                            cellvalue = date.ToShortDateString();
                        }
                        item.出荷日 = cellvalue;
                    }


                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "G" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        if (double.TryParse(cellvalue, out oaDteAsDouble))
                        {
                            var date = DateTime.FromOADate(oaDteAsDouble);
                            cellvalue = date.ToShortDateString();
                        }
            
                        item.納品日 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "H" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.荷主 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "I" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.県別 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "J" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.卸先 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "K" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.品名 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "L" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.口数 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "M" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.数量 = cellvalue;
                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "N" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        // 表格的N列存储 “伝票番号”，对于 二次制品，存储的是 “社内伝番”
                        cellvalue = GetCellValue(wbPart, theCell);
                        if (!string.IsNullOrEmpty(cellvalue)) { 
                            // 社内传番应该为8位
                            if (cellvalue.Length >= 8)
                            {
                                item.社内伝番 = cellvalue;

                            }
                            else {
                                item.伝票番号 = cellvalue;                            
                            }
                        }


                    }
                    theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "O" + rowindex).FirstOrDefault();

                    if (theCell != null)
                    {
                        cellvalue = GetCellValue(wbPart, theCell);
                        item.処理済 = cellvalue;
                    }

                    #endregion

                    if (item.配送担当 == null || item.配送担当 == "")
                        break;

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



        private bool validateAttributes(WorksheetPart worksheetPart, WorkbookPart wbPart)
        {

            string msg = String.Empty;
            var validated = true;

            Cell theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "A" + 4).FirstOrDefault();
            if (theCell != null)
            {
                string cellvalue = GetCellValue(wbPart, theCell);
                if (!cellvalue.Contains("出荷No"))
                    validated = false;

            }
            theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference.Value == "O" + 4).FirstOrDefault();
            if (theCell != null)
            {
                string cellvalue = GetCellValue(wbPart, theCell);
                if (!cellvalue.Contains("処理済"))
                    validated = false;

            }

            if (validated == false)
            {
                msg = "选择的文件表格格式不正确，请重新选择！";
                errorProvider1.SetError(pathTextBox, msg);
            }
            return validated;
        }


    }
}
