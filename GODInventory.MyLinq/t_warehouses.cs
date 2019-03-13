namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_warehouses")]
    public partial class t_warehouses
    {
        [Key]
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        //public string ShipperName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string memo { get; set; }

    }
}
