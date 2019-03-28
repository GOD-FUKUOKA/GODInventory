namespace GODInventory.MyLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // 20190325��ӣ� �����˷Ѽ��㷽ʽ��
    // �յ������󣬲�ѯ��Ʒ�۸���õ��˷ѵ�λ�� ���ݣ����乫˾���ֿ⣬�̵꣬�˷ѵ�λ����ѯ��Ʒ�˷ѵ��ۺͼ����˷����ö������ֶ�����
    // ������ t_orderdata (�̵꣬��Ʒ,���乫˾���ֿ�)
    // ��Ʒ�۸�� t_pricelist (�̵꣬��Ʒ���۸��\�U�gλ)
    // ��Ʒ�˷ѱ� t_freights (���乫˾���ֿ⣬�̵꣬�\�U�gλ���˷ѵ��ۣ��������ֶ���)


    //[Table("t_freights")]
    public partial class t_freights
    {
        [Key]
        public int id { get; set; }
        public int ���祳�`�� { get; set; }

        public string transportname { get; set; }
        public string warehousename { get; set; }
        public int transport_id { get; set; }
        public int warehouse_id { get; set; }
        public int shop_id { get; set; }
        //�\�U
        public decimal fee { get; set; }
        //�ѥ�å��\�U
        public decimal lot_fee { get; set; }
        //�\�U�gλ
        public string unitname { get; set; }
        //�����˷�ʱ���������ֶ�����
        public string columnname { get; set; }

 

    }
}
