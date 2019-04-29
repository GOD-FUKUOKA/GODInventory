namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("god_inventory.t_innerorders")]
    public partial class t_innerorders
    {
        [Key]
        public int id受注データ { get; set; }   

        [Column(TypeName = "date")]
        public DateTime 発注日 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? 受注日 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? 出荷日 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? 納品日 { get; set; }

        public int 店舗コード { get; set; }

        [StringLength(255)]
        public string 店舗名漢字 { get; set; }


        public int 社内伝番 { get; set; }

        public short 行数 { get; set; }

        public short 最大行数 { get; set; }

        public int 伝票番号 { get; set; }

        [Required]
        [StringLength(255)]
        public string ダブリ { get; set; }

        [StringLength(255)]
        public string 在庫状態 { get; set; }

        [Required]
        [StringLength(255)]
        public string キャンセル { get; set; }

        public DateTime? キャンセル時刻 { get; set; }

        public int ジャンル { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        [StringLength(255)]
        public string 品名漢字 { get; set; }

        [StringLength(255)]
        public string 規格名漢字 { get; set; }

        public long ＪＡＮコード { get; set; }

        public int 商品コード { get; set; }

        public int 自社コード { get; set; }
        

        public int 発注数量 { get; set; }

        public int 実際出荷数量 { get; set; }

        public int 口数 { get; set; }

        public int 納品口数 { get; set; }

        public int 重量 { get; set; }

        [StringLength(255)]
        public string 単位 { get; set; }

        [Column("原単価(税抜)")]
        public int 原単価_税抜_ { get; set; }

        [Column("原価金額(税抜)")]
        public int 原価金額_税抜_ { get; set; }

        public int 納品原価金額 { get; set; }

        [Column("売単価（税抜）")]
        public int 売単価_税抜_ { get; set; }

        public bool 一旦保留 { get; set; }

        [Required]
        [StringLength(255)]
        public string 実際配送担当 { get; set; }

        public bool 配送担当受信 { get; set; }

        public DateTime? 配送担当受信時刻 { get; set; }

        /// <summary>
        /// 客户信息， 包括法人，店铺，纳品场所
        /// </summary>
        public short 法人コード { get; set; }

        [StringLength(255)]
        public string 法人名漢字 { get; set; }


        [StringLength(255)]
        public string 納品指示 { get; set; }

        public short 納品場所コード { get; set; }

        [StringLength(255)]
        public string 納品場所名漢字 { get; set; }

        public bool 受領 { get; set; }

        [StringLength(255)]
        public string 備考 { get; set; }

        public int? 週目 { get; set; }

        public bool 受領確認 { get; set; }

        public int 受領数量 { get; set; }

        public int? 受領金額 { get; set; }

        public int? 受領差異数量 { get; set; }

        public int? 受領差異金額 { get; set; }

        public TimeSpan? 受注時刻 { get; set; }

       

        public short 伝票区分 { get; set; }

        public short 行番号 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? 納品予定日 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? 発注データ有効期限 { get; set; }

        public short? EDI発注区分 { get; set; }

        public short 発注形態区分 { get; set; }

        [StringLength(255)]
        public string 発注形態名称漢字 { get; set; }

      
        [Column("原単価(税込)")]
        public double? 原単価_税込_ { get; set; }

        [Column("原価金額(税込)")]
        public double? 原価金額_税込_ { get; set; }

        public double? 税額 { get; set; }

        public short 税区分 { get; set; }

        public double? 税率 { get; set; }

        [Column("売単価（税込）")]
        public double? 売単価_税込_ { get; set; }

        public short? 特価区分 { get; set; }

        public short? PB区分 { get; set; }

        public short? 原価区分 { get; set; }

        public short? 用度品区分 { get; set; }

        public short? 納期回答区分 { get; set; }

             
        public long 出荷No { get; set; }

        public OrderStatus Status { get; set; }

        public string 県別 { get; set; }

        public string ShipNO { get; set; }

        public short 入力区分 { get; set; }

        public int 訂正理由区分 { get; set; }

        public int 最終出荷数 { get; set; }

        public decimal 仕入原価 { get; set; }
        public decimal 仕入金額 { get; set; }
        public decimal 粗利金額 { get; set; }

        public int 社内伝番処理 { get; set; }

        public int reportState { get; set; }

        public string warehousename { get; set; }

        public int 運賃 { get; set; }

        public int warehouse_id { get; set; }
        public int transport_id { get; set; }
        
        public t_innerorders()
        {
            this.キャンセル = "no";
            this.ダブリ = "no";
            this.発注形態区分 = (int)OrderReasonEnum.補充;
            this.発注形態名称漢字 = OrderReasonEnum.補充.ToString();
            this.実際配送担当 = "丸健";
            this.配送担当受信 = false;
            this.Status = 0;
        }

        
    }
}
