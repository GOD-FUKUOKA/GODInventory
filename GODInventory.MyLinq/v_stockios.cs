using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    public class v_stockios
    {
        public int Id { get; set; }
        public int 自社コード { get; set; }     
        public string 商品名 { get; set; }
        public string 規格 { get; set; }
        public int qty { get; set; }

        public int? 商品コード { get; set; }
        public int? 順番 { get; set; }
    }
}
