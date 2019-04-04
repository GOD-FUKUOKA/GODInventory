
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

        List<XLSXImportShipNumber> modelList;
        private SortableBindingList<XLSXImportShipNumber> sortablemodelsList;

        List<t_orderdata> xlsxOrderList;
        List<t_orderdata> pendingOrderList;

        public int SavedOrderCount { get; set; }
        private string totalRecordFormat = "合計 {0} 行";

        public ImportShipNumberForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            this.ControlBox = false;   // 设置不出现关闭按钮
        }

        private void openFileBtton_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pathTextBox.Text = openFileDialog1.FileName;
            }
            if (this.pathTextBox.Text != "")
            {
                // 
                modelList = new List<XLSXImportShipNumber>();

                try
                {

                    modelList = readExcel(this.pathTextBox.Text);
                    this.bindingSource1.DataSource = null;

                    // 记录DataGridView改变数据          
                    // sortablemodelsList = new SortableBindingList<XLSXImportShipNumber>(modelList);
                    //this.bindingSource1.DataSource = modelList;

                    dataGridView1.DataSource = modelList;
                    this.totalRecordLabel.Text = string.Format(totalRecordFormat, modelList.Count);

                }
                catch (Exception exception)
                {
                    success = false;
                    MessageBox.Show(string.Format("{0}", exception.Message));

                }

                //根据读取到的传票番号，读取数据库中的订单，确认订单状态

                var orderNumbers = modelList.Where(o => { return !string.IsNullOrEmpty(o.伝票番号); }).Select(o => Convert.ToInt32(o.伝票番号));
                var orderInnerNumbers = modelList.Where(o => { return !string.IsNullOrEmpty(o.社内伝番); }).Select(o => Convert.ToInt32(o.社内伝番));
                OrderStatus[] orderStateRequired = { OrderStatus.Pending, OrderStatus.NotifyShipper, OrderStatus.PendingShipment };

                //var shopIds = models.

                // 查询 伝票番号和社内伝番所有订单，
                using (var ctx = new GODDbContext())
                {
                    this.xlsxOrderList = (from t_orderdata o in ctx.t_orderdata
                                          where orderStateRequired.Contains(o.Status) && (orderNumbers.Contains(o.伝票番号) || orderInnerNumbers.Contains(o.社内伝番))
                                          select o).ToList();
                    var shopIds = xlsxOrderList.Select(o => o.店舗コード).Distinct().ToList();
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

            if (this.SavedOrderCount > 0)
            {
                MessageBox.Show(string.Format("{0}件の受注伝票が登録できました", this.SavedOrderCount), "INFO");
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



                        List<XLSXImportShipNumber> we = modelList.FindAll(s => s.処理済 != null && s.処理済.Contains("未"));

                        long m = we.Count;
                        if (m > 0)
                        {
                            for (var i = 0; i < modelList.Count; i++)
                            {

                                model = modelList.ElementAt(i);
                                if (string.IsNullOrEmpty(model.出荷No))
                                {
                                    model.出荷No = DateTime.Now.ToString("yyMMdd") + model.車番;
                                }
                                string ShipNO = "";
                                int j = 0;
                                int ii = 0;

                                string sql = "";
                                if (model.品名 != "二次製品" && model.処理済.Contains("未"))
                                {
                                    sql = "UPDATE t_orderdata  SET `出荷日` = '" + model.出荷日 + "', `納品日`= '" + model.納品日 + "', `Status` = 5, `ShipNO` = '" + model.出荷No + "' " + " WHERE (`伝票番号` = " + model.伝票番号 + " AND `店舗名漢字` = '" + model.卸先 + "')";
                                    model.処理済 = "済";
                                    ShipNO = model.出荷No;
                                    j = j + 1;
                                    ii = ii + 1;
                                }
                                if (j > 0 && ii < modelList.Count)
                                {
                                    for (int k = i; k < modelList.Count; k++)
                                    {
                                        if (model.品名 != "二次製品" && model.品名 == "未" && modelList[k].品名 == ShipNO)
                                        {
                                            sql = sql + " OR (`伝票番号` = " + model.伝票番号 + " AND `店舗名漢字` = '" + model.卸先 + "')";

                                            modelList[k].処理済 = "済";
                                        }
                                    }
                                }
                                if (sql != null && sql != "")
                                {
                                    ctx.Database.ExecuteSqlCommand(sql);
                                }

                                ii = 0;
                                j = 0;

                                if (model.品名 == "二次製品" && model.処理済.Contains("未"))
                                {
                                    sql = "UPDATE t_orderdata SET `出荷日` = '" + model.出荷日 + "', `納品日`= '" + model.納品日 + "', `Status` = 5, `ShipNO` = '" + model.出荷No + "' " + " WHERE (`社内伝番` = " + model.伝票番号 + " AND `店舗名漢字` = '" + model.卸先 + "')";
                                    model.処理済 = "済";
                                    ShipNO = model.出荷No;
                                    ii = ii + 1;
                                    j = j + 1;
                                }
                                else
                                    ii = ii + 1;

                                if (j > 0 && ii < modelList.Count)
                                {
                                    for (int k = i; k < modelList.Count; k++)
                                    {

                                        if (model.品名 == "二次製品" && model.品名 == "未" && modelList[k].品名 == ShipNO)
                                        {
                                            sql = sql + " OR (`社内伝番` = " + model.伝票番号 + " AND `店舗名漢字` = '" + model.卸先 + "')";
                                            model.処理済 = "済";
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
                    double oaDteAsDouble;
                    int cellindex = 0;

                    foreach (Cell cell in row)
                    {
                        //double oaDteAsDouble;
                        //if (cellindex == 0)// A
                        //{
                        //    item.出荷No =val; 
                        //    if( string.IsNullOrEmpty( item.出荷No ))
                        //    {
                        //       throw new Exception(String.Format("xlsx does not have valid 出荷No at A{0}!",rowindex ));
                        //    }                            
                        //}
                        string val = GetCellValue(wbPart, cell);


                        if (cellindex == 1)// B
                        {
                            item.配送担当 = val;
                        }

                        if (cellindex == 2)// C
                        {
                            item.車番 = val;
                        }

                        if (cellindex == 3)// D
                        {
                            item.ドライバー = val;
                        }

                        if (cellindex == 4)// E
                        {
                            item.方面 = val;
                        }

                        if (cellindex == 5)// F
                        {
                            cellvalue = val;
                            if (double.TryParse(cellvalue, out oaDteAsDouble))
                            {
                                var date = DateTime.FromOADate(oaDteAsDouble);
                                cellvalue = date.ToShortDateString();
                            }
                            item.出荷日 = cellvalue;
                        }

                        if (cellindex == 6)// G
                        {
                            cellvalue = val;
                            if (double.TryParse(cellvalue, out oaDteAsDouble))
                            {
                                var date = DateTime.FromOADate(oaDteAsDouble);
                                cellvalue = date.ToShortDateString();
                            }
                            item.納品日 = cellvalue;
                        }

                        if (cellindex == 7)// H
                        {
                            item.荷主 = val;
                        }
                        if (cellindex == 8)// I
                        {
                            item.県別 = val;
                        }

                        if (cellindex == 9)// J
                        {
                            item.卸先 = val;
                        }

                        if (cellindex == 10)// K
                        {
                            item.品名 = val;
                        }

                        if (cellindex == 11)// L
                        {
                            item.口数 = val;
                        }

                        if (cellindex == 12)// M
                        {
                            item.数量 = val;
                        }

                        if (cellindex == 13)// N
                        {
                            // 表格的N列存储 “伝票番号”，对于 二次制品，存储的是 “社内伝番”
                            cellvalue = val;
                            if (!string.IsNullOrEmpty(cellvalue))
                            {
                                // 社内传番应该为8位
                                if (cellvalue.Length >= 8)
                                {
                                    item.社内伝番 = cellvalue;

                                }
                                else
                                {
                                    item.伝票番号 = cellvalue;
                                }
                            }
                        }

                        if (cellindex == 14)// O
                        {
                            item.処理済 = val;
                        }

                        cellindex++;
                    }


                    #endregion

                    if (string.IsNullOrEmpty(item.配送担当))
                    {
                        break;
                    }

                    models.Add(item);

                    rowindex++;
                }


            }

            return models;


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var row = this.dataGridView1.Rows[e.RowIndex];
                var data = row.DataBoundItem as XLSXImportShipNumber;
                //DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells["selectedColumn1"];
                if (data.selected == 1)
                {
                    data.selected = 0;
                }
                else
                {
                    data.selected = 1;
                }
            }
        }


    }
}
