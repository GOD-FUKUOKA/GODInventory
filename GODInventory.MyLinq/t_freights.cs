namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // 20190325添加， 调整运费计算方式，
    // 收到订单后，查询商品价格表，得到运费单位， 根据（运输公司，仓库，商店，运费单位）查询商品运费单价和计算运费所用订单表字段名。
    // 订单表 t_orderdata (商店，商品,运输公司，仓库)
    // 商品价格表 t_pricelist (商店，商品，价格，運賃単位)
    // 商品运费表 t_freights (运输公司，仓库，商店，運賃単位，运费单价，订单表字段名)


    //[Table("t_freights")]
    public partial class t_freights
    {
        [Key]
        public int id { get; set; }
        public int 自社コード { get; set; }

        public string transportname { get; set; }
        public string warehousename { get; set; }
        public int transport_id { get; set; }
        public int warehouse_id { get; set; }
        public int shop_id { get; set; }
        //運賃
        public decimal fee { get; set; }
        //パレット運賃
        public decimal lot_fee { get; set; }
        //運賃単位
        public string unitname { get; set; }
        //计算运费时，订单表字段名称
        public string columnname { get; set; }

 

    }
}
