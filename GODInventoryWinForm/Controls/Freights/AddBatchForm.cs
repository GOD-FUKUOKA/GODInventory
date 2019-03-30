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

namespace GODInventoryWinForm.Controls.Freights
{
    public partial class AddBatchForm : Form
    {
        public List<t_transports> transportList;
        public List<t_warehouses> warehouseList;
        public List<t_itemlist> productList;
        public List<t_genre> generList;

        public AddBatchForm()
        {
            InitializeComponent();
        }

        private void AddBatchForm_Load(object sender, EventArgs e)
        {

        }


        private void InitializeData() {

            // 检查当前商店的 所有商品价格是否存在。
            using (var ctx = new GODDbContext())
            {
                this.transportList = ctx.t_transports.ToList();
                this.warehouseList = ctx.t_warehouses.ToList();
                this.generList = ctx.t_genre.ToList();
                this.productList = ctx.t_itemlist.ToList();

            }
        }
    }
}
