using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    public class v_stockrec
    {
        public DateTime 日付 { get; set; }
        public string 区分 { get; set; }
        public int 自社コード { get; set; }
        public int? 数量 { get; set; }
        public string 状態 { get; set; }
        public string 元 { get; set; }
        public string 先 { get; set; }
        public string 納品書番号 { get; set; }
        public string 客 { get; set; }
        public string 事由 { get; set; }
    }
}
