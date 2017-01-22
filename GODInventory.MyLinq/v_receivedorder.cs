using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GODInventory.MyLinq
{

    public  class v_receivedorder 
    {

        public int id受注データ { get; set; }

        public int 店舗コード { get; set; }

        public int 伝票番号 { get; set; }

        public int 原価金額_税抜_ { get; set; }

        public int 納品原価金額 { get; set; }

        public int 実際出荷数量 { get; set; }
    }

}
