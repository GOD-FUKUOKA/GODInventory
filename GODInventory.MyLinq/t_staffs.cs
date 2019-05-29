namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("t_warehouses")]
    public partial class t_staffs
    {
        [Key]
        public int id { get; set; }
        public int branch_id { get; set; }

        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public string fullname { get; set; }
        public string phone { get; set; }
        public string memo { get; set; }


        public int failed_attempts { get; set; }
        public DateTime? locked_at { get; set; }
        public DateTime? current_sign_in_at { get; set; }
        public DateTime? last_sign_in_at { get; set; }


    }
}
