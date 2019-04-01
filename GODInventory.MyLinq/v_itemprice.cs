using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    // join item and price 和缺省物流公司和缺省仓库的freight
    public class v_itemprice
    {
        public int Id { get; set; }
        public int 自社コード { get; set; }
        public string ジャンル名 { get; set; }

        public int ジャンル { get; set; }
        public string 商品名 { get; set; }
        public string 規格 { get; set; }
        public long JANコード { get; set; }
        //public int? ロット { get; set; }
        public int 商品コード { get; set; }

        public int PT入数 { get; set; }
        
        public double 単品重量 { get; set; }     
        public string 単位 { get; set; }

        public decimal 原単価 { get; set; }
        public decimal 売単価 { get; set; }
        public decimal 広告原単価 { get; set; }
        public decimal 特売原単価 { get; set; }
        public decimal 仕入原価 { get; set; }

        public int 店番 { get; set; }
        public string 店名 { get; set; }
        public string 県別 { get; set; }
        public string 地域 { get; set; }
        
        public string 配送担当 { get; set; }

        public int warehouse_id { get; set; }
        public int transport_id { get; set; }
        public string warehousename { get; set; }
        // 運賃単位
        public string unitname { get; set; }

        // 商品缺省运费信息
        public decimal fee { get; set; }
        // 计算运费时，订单表字段名称
        public string columnname { get; set; }

        //产品分类中 社内伝番処理, initialize_order 中使用
        public int 社内伝番処理 { get; set; }
    }
}
