using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    /// 连接 商品，商店，运费 freight
    public class v_freights
    {
        public int id { get; set; }
        public int 自社コード { get; set; }

        public string transportname { get; set; }
        public string warehousename { get; set; }
        public int transport_id { get; set; }
        public int warehouse_id { get; set; }
        public int shop_id { get; set; }
        public string shopname { get; set; }
        //運賃
        public decimal fee { get; set; }
        public decimal lot_fee { get; set; }

        //運賃単位
        public string unitname { get; set; }
        public string columnname { get; set; }

        public string 商品名 { get; set; }

    }
}
