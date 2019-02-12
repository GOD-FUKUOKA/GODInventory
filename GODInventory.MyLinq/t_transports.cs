namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_transports")]
    public partial class t_transports
    {
        [Key]
        public int id { get; set; }
        public string shortname { get; set; }
        public string fullname { get; set; }

    }
}
