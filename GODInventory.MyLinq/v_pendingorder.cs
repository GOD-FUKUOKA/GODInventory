using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GODInventory.MyLinq
{

    public  class v_pendingorder 
    {


        public int id受注データ { get; set; }

        public DateTime? 発注日 { get; set; }

        public DateTime? 受注日 { get; set; }

        public DateTime? 出荷日 { get; set; }

        public DateTime? 納品日 { get; set; }

        public int 店舗コード { get; set; }

        public string 店舗名カナ { get; set; }

        public int 社内伝番 { get; set; }

        //RollbackOrder 檢查 社内伝番， 所以二次製品窗口使用 “社内伝番UnSaved”
        public int 社内伝番UnSaved { get; set; }

        public short? 行数 { get; set; }

        public short? 最大行数 { get; set; }

        public int ジャンル { get; set; }

        public string GenreName { get; set; }

        public int 伝票番号 { get; set; }

        public short 発注形態区分 { get; set; }

        public string 発注形態名称漢字 { get; set; }

        public int 発注数量 { get; set; }

        public int 実際出荷数量 { get; set; }

        public int 最小発注単位数量 { get; set; }

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

        public double? 原単価_税込_ { get; set; }

        [Column("原価金額(税抜)")]
        public int 原価金額_税抜_ { get; set; }

        public double? 原価金額_税込_ { get; set; }

        public int 納品原価金額 { get; set; }

        public int? 売単価_税抜_ { get; set; }
        public double? 売単価_税込_ { get; set; }

        public double? 税額 { get; set; }
        public double? 税率 { get; set; }

        public int 出荷業務仕入先コード { get; set; }

        public bool 一旦保留 { get; set; }

        public string 実際配送担当 { get; set; }

        public string warehousename { get; set; }
     

        public DateTime? 配送担当受信時刻 { get; set; }


        public short 配送担当受信 { get; set; }

        public string 店舗名漢字 { get; set; }

        public bool 受領 { get; set; }
        public bool 受領確認 { get; set; }

        public string ダブリ { get; set; }

        public string キャンセル { get; set; }

        public DateTime? キャンセル時刻 { get; set; }

        // for stockrec
        public string 法人名漢字 { get; set; }
        // 
        public int? 在庫数 { get; set; }

        public string 在庫状態 { get; set; }

        public string 納品場所名カナ { get; set; }
        
        public string 納品場所名漢字 { get; set; }

        public string 備考 { get; set; }

        public string 納品指示 { get; set; }

        //売传番号生成
        public string オプション使用欄 { get; set; }

        public string maichuanfanhao { 
            get{
                if (this.オプション使用欄 != null && this.オプション使用欄.Length >= 13)
                {
                    return this.オプション使用欄.Substring(5, 8);
                }
                else {
                    return String.Empty;
                }
            }
        }


        // shop
        public int 店番 { get; set; }

        public string 店名 { get; set; }

        public string 県別 { get; set; }

        public string 住所 { get; set; }

        public string 電話番号 { get; set; }

        public long 出荷No { get; set; }

        public string 売上ランク { get; set; }

        //`売上ランク`, p.`厳しさ`, p.`欠品カウンター`

        //price
        public int 欠品カウンター { get; set; }
        public string 厳しさ { get; set; }

        public string UnitedShopLevel
        {
            get {
                return String.Format("{0}-{1}-{2}", this.売上ランク, this.厳しさ, this.欠品カウンター);
            }
        }

        // fixed
        public string 直送区分 { get; set; }

        public int 訂正理由区分 { get; set; }

        public long ASN管理連番 { get; set; }

        public OrderStatus Status { get; set; }

        public string ShipNO { get; set; }

        public int 最終出荷数 { get; set; }

        public short 入力区分 { get; set; }

        public int 社内伝番処理 { get; set; }
       
        public decimal 運賃 { get; set; }
        
        // 打印报表时使用。
        public int SubOrderCount { get; set; }
        public string BarcodeImagePath { get; set; }
        public byte[] BarcodeImage { get; set; }
    }

}
