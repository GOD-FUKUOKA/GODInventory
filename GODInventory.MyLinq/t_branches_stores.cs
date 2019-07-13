namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_warehouses_transports")]
    public partial class t_branches_stores
    {
        [Key]
        public int id { get; set; }
        public int branch_id { get; set; }
        public int store_id { get; set; }
        public int warehouse_id { get; set; }

    }
}
