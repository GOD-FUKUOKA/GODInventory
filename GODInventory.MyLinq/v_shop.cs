namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // 包含location 信息
    public partial class v_shop
    {
        
        public int 店番 { get; set; }

         
        public string 店名 { get; set; }

        
        public string 店名カナ { get; set; }

        
        public string 配送担当 { get; set; }

        
        public string 郵便番号 { get; set; }

       
        public string 県別 { get; set; }

         
        public string 県内エリア { get; set; }

        
        public string 住所 { get; set; }

        
        public string 電話番号 { get; set; }

        
        public string FAX番号 { get; set; }

        
        public string 営業担当 { get; set; }

         
        public string 売上ランク { get; set; }

        public int customerId { get; set; }

        public int 参考店舗 { get; set; }

        public int warehouse_id { get; set; }

        public int transport_id { get; set; }

        public string warehousename { get; set; }

        public string 地域 { get; set; }

        // locations.納品場所コード 
        public int 納品場所コード { get; set; }
        public string 納品場所名漢字 { get; set; }
        public string 納品場所名カナ { get; set; }

        // branches.id
        public int branch_id { get; set; }
        public int branch_store_id { get; set; } // Branch/IndexForm使用

        public bool ischeck { get; set; }

    }
}
