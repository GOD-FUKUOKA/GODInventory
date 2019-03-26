using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GODInventory.MyLinq;

namespace GODInventoryWinForm.Controls.Transports
{
    // 更新t_pricelist表 单位
    // update t_pricelist t1 inner join t_itemlist t2 on t1.自社コード = t2.自社コード  set t1.unitname = t2.单位
    // udpate  t_pricelist 单位 = s.单位 from ( select * from t_pricelist t1 left join t_itemlist t2 on t1.自社コード = t2.自社コード)


    public partial class ReportForm : Form
    {
        public class itemunit
        {
            //運賃単位
            public string unitname { get; set; }
            public int total { get; set; }
        }

        private List<t_transports> transportList;
        private List<t_warehouses> warehouseList;
        private List<t_shoplist> shopList;
        private List<itemunit> itemunitList;

        public ReportForm()
        {
            InitializeComponent();
        }

        public void InitializeData(){
            using (var ctx = new GODDbContext())
            {
                this.transportList = ctx.t_transports.ToList();
                this.warehouseList = ctx.t_warehouses.ToList();
                this.shopList = ctx.t_shoplist.ToList();
                this.itemunitList = (from s in ctx.t_pricelist
                                    group s by s.unitname into g
                                    select new itemunit { unitname = g.Key, total = g.Count() }).ToList();
                //this.transport = ctx.t_transports.First(c => c.id == this.tid);

                //this.groupedFreight = (from s in ctx.t_freights
                //                       group s by s.unitname into g
                //                       select new itemunit { unitname = g.Key, total = g.Count() }).ToList();
            }        
        }
    }
}
