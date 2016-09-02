namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    //using System.Data.Entity.Spatial;

    [Table("god_inventory.t_stockstate")]
    public partial class t_stockstate
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 自社コード { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WarehouseID { get; set; }

        public int 在庫数 { get; set; }

        [StringLength(255)]
        public string 在庫状態 { get; set; }

        public string ShipperName { get; set; }
    }
}
