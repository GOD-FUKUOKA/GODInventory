namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("god_inventory.t_shoplist")]
    public partial class t_shoplist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 店番 { get; set; }

        [Required]
        [StringLength(255)]
        public string 店名 { get; set; }

        [StringLength(255)]
        public string 店名カナ { get; set; }

        [StringLength(255)]
        public string 配送担当 { get; set; }

        [StringLength(255)]
        public string 郵便番号 { get; set; }

        [Required]
        [StringLength(255)]
        public string 県別 { get; set; }

        [StringLength(255)]
        public string 県内エリア { get; set; }

        [StringLength(255)]
        public string 住所 { get; set; }

        [StringLength(255)]
        public string 電話番号 { get; set; }

        [StringLength(255)]
        public string FAX番号 { get; set; }

        [StringLength(255)]
        public string 営業担当 { get; set; }

        [StringLength(12)]
        public string 売上ランク { get; set; }

        public int customerId { get; set; }

        public int 参考店舗 { get; set; }

        public int warehouse_id { get; set; }

        public int transport_id { get; set; }

        public string warehousename { get; set; }

        public string 地域 { get; set; }

    }
}
