namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("god_inventory.t_stocklist")]
    public partial class t_stocklist
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime 期日 { get; set; }

        [Required]
        [StringLength(255)]
        public string 仓库 { get; set; }

        public string 商品別 { get; set; }

        public string 工場 { get; set; }

        [StringLength(255)]
        public string 入庫番号 { get; set; }

        [StringLength(255)]
        public string 工場のコード { get; set; }

       
        public int 数量 { get; set; }
 
    }
}
