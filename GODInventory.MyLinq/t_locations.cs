namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("god_inventory.t_locations")]
    public partial class t_locations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int 店舗コード { get; set; }

        [StringLength(64)]
        public string 納品場所コード { get; set; }

        [StringLength(64)]
        public string 納品場所名カナ { get; set; }

        [StringLength(64)]
        public string 納品場所名漢字 { get; set; }

        [StringLength(64)]
        public string 納品場所名略称 { get; set; }

 
    }
}
