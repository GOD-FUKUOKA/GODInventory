using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    public class v_stockcheck
    {
        public int Id { get; set; }
        public int 自社コード { get; set; }     
        public string 商品名 { get; set; }
        public string 規格 { get; set; }
        public int jiHuaRuCunShu { get; set; }
        public int yingYouKuCunShu { get; set; }
        public int daiFaHuoShu { get; set; }
        public int shiJiKuCunShu { get; set; }
        public int? qingDianShu { get; set; }
        public int chaZhi { get; set; }
        public int weiChuanSong { get; set; }
        public int? 数量 { get; set; }
        public int? 順番 { get; set; }

    }
}
