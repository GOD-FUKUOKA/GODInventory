namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_manufacturers")]
    public partial class t_manufacturers
    {
        [Key]
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
    }
}
