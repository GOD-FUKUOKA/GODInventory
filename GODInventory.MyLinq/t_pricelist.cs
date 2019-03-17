namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("god_inventory.t_pricelist")]
    public partial class t_pricelist
    {
        [Key]
        public int Id { get; set; }

        public int 自社コード { get; set; }

        public int 店番 { get; set; }
        
        [StringLength(255)]
        public string 店名 { get; set; }

        [StringLength(255)]
        public string 県別 { get; set; }

        [StringLength(12)]
        public string 厳しさ { get; set; }

        public int 欠品カウンター { get; set; }

        public decimal 売単価 { get; set; }

        public decimal 通常原単価 { get; set; }
        public decimal 広告原単価 { get; set; }
        public decimal 特売原単価 { get; set; }
        public decimal 仕入原価 { get; set; }

        [StringLength(64)]
        public string 配送担当 { get; set; }

        public decimal 運賃 { get; set; }  // 重量运费
        public decimal パレット運賃 { get; set; }  // 口数运费
    }
}
