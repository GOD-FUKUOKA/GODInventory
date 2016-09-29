using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GODInventory.MyLinq
{

    public  class v_duplicatedorder 
    {
        public int duplicatedId { get; set; }
        public int id受注データ { get; set; }

        public DateTime? 発注日 { get; set; }

        public DateTime? 受注日 { get; set; }

        public DateTime? 出荷日 { get; set; }

        public DateTime? 納品日 { get; set; }

        public int 店舗コード { get; set; }

        public string 店舗名カナ { get; set; }


        public int ジャンル { get; set; }

        public int 伝票番号 { get; set; }

        public short 発注形態区分 { get; set; }

        public string 発注形態名称漢字 { get; set; }

        public int 発注数量 { get; set; }


        public int 実際出荷数量 { get; set; }

        public int 自社コード { get; set; }

        public string 規格名漢字 { get; set; }

        public int 商品コード { get; set; }

        public long ＪＡＮコード { get; set; }


        public string 品名漢字 { get; set; }

        public int 口数 { get; set; }

        public int 納品口数 { get; set; }

        public string 単位 { get; set; }

        public int 重量 { get; set; }

        public int 原単価_税抜_ { get; set; }

        public int 原価金額_税抜_ { get; set; }

        public int 納品原価金額 { get; set; }

        public int? 売単価_税抜_ { get; set; }

        public bool 一旦保留 { get; set; }
       
        public string 店舗名漢字 { get; set; }

        public string 実際配送担当 { get; set; }      

        public string ダブリ { get; set; }


        public string キャンセル { get; set; }

        public DateTime? キャンセル時刻 { get; set; }

        public string 県別 { get; set; }
        public OrderStatus Status { get; set; }

        public string GenreName { get; set; }
    }

}
