using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.ViewModel.EDI
{
    public class XLSXImportShipNumber
    {
        public int selected { get; set; }
        public string 出荷No { get; set; }
        public string 配送担当 { get; set; }
        public string 車番 { get; set; }
        public string ドライバー { get; set; }
        public string 方面 { get; set; }
        public string 出荷日 { get; set; }
        public string 納品日 { get; set; }
        public string 荷主 { get; set; }
        public string 県別 { get; set; }
        public string 卸先 { get; set; }
        public string 品名 { get; set; }
        public string 口数 { get; set; }
        public string 数量 { get; set; }
        public string 伝票番号 { get; set; }
        public string 処理済 { get; set; }
        public string 社内伝番 { get; set; }
        
        public string mark1 { get; set; }
        public string mark2 { get; set; }
        public string mark3 { get; set; }
        public string mark4 { get; set; }
        public string mark5 { get; set; }

        public string memo { get; set; }

        public XLSXImportShipNumber(){
            this.selected = 0; // 初始状态为未选择
        }

    }
}
