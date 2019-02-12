namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_warehouses_transports")]
    public partial class t_warehouses_transports
    {
        [Key]
        public int id { get; set; }
        public int wid { get; set; }
        public int tid { get; set; }

    }
}
