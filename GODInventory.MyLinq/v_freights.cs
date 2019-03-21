using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    // join item and price
    public class v_freights
    {
        public int id { get; set; }
        public int 自社コード { get; set; }
        public string transportname { get; set; }
        public string warehousename { get; set; }
        public int transport_id { get; set; }
        public int warehouse_id { get; set; }
        public int shop_id { get; set; }
        //運賃
        public int fee { get; set; }
        public int lot_fee { get; set; }

        //単位
        public string unitname { get; set; }

        public string 商品名 { get; set; }

    }
}
