namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_freights")]
    public partial class t_freights
    {
        [Key]
        public int id { get; set; }
        public int ×ÔÉç¥³©`¥É { get; set; }
        public string transportname { get; set; }
        public string warehousename { get; set; }
        public int transport_id { get; set; }
        public int warehouse_id { get; set; }
        //ß\ÙU
        public int fee { get; set; }
        //…gÎ»
        public string unitname { get; set; }

    }
}
