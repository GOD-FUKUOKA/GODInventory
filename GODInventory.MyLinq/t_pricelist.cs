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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 自社コード { get; set; }

        public int 店番 { get; set; }
        
        [StringLength(255)]
        public string 店名 { get; set; }

        [StringLength(255)]
        public string 県別 { get; set; }

        public decimal? 通常売価 { get; set; }

        public decimal? 広告売価 { get; set; }

        public decimal? 特売売価 { get; set; }


    }
}
