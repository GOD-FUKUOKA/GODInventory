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
using GODInventory.ViewModel;

namespace GODInventoryWinForm.Controls
{
    public partial class Strock_Check : Form
    {
        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private BindingList<t_stockrec> stocklist;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;
        //private t_itemlist itemlist;
        private BindingList<t_itemlist> Titemlist;
        private List<t_itemlist> itemlist;
        int RowRemark = 0;
        int cloumn = 0;
        public int STATUS;
        public t_itemlist item;
        public ReceivedOrdersReportForm reportForm;
        public Strock_Check()
        {
            InitializeComponent();

            List<int> newcodemanufa = new List<int>();
            stocklist = new BindingList<t_stockrec>();
            Titemlist = new BindingList<t_itemlist>();

            using (var ctx = new GODDbContext())
            {
                t_manufacturersR = ctx.t_manufacturers.ToList();
                t_shippersR = ctx.t_shippers.ToList();
                t_genreR = ctx.t_genre.ToList();
                t_stocklistR = ctx.t_stockrec.ToList();
            }
            foreach (t_manufacturers item in t_manufacturersR)
            {
                this.comboBox1.Items.Add(item.FullName);

            }
            foreach (t_genre item in t_genreR)
            {
                this.comboBox2.Items.Add(item.ジャンル名);
            }
            {
                OrderSqlHelper item12 = new OrderSqlHelper();

                string[] ll = item12.StrockReback();
                for (int j = 0; j < ll.Length; j++)
                {

                    this.storeComboBox.Items.Add(ll[j]);

                }
            }
        }

        private void btfind_Click(object sender, EventArgs e)
        {


            List<int> noc = new List<int>();

            #region 读取StockRec 表中的信息

            foreach (t_stockrec item in t_stocklistR)
            {
                int aog = 0;

                for (int i = 0; i < noc.Count; i++)
                {
                    if (noc[i] == Convert.ToInt32(item.自社コード))
                        aog++;
                }
                if (aog == 0)
                    noc.Add(item.自社コード);
            }



            #endregion
            #region 读取详细产品信息


            //for (int i = 0; i < noc.Count; i++)
            {
                int id = 0;

                foreach (t_genre item in t_genreR)
                {
                    if (item.ジャンル名 == comboBox2.Text)
                        id = item.idジャンル;
                }
                Titemlist = new BindingList<t_itemlist>();

                using (var ctx = new GODDbContext())
                {
                    itemlist = ctx.t_itemlist.ToList();

                }
                var locations = this.itemlist.Where(l => l.ジャンル == id).ToList();

                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = locations;

            }





            #endregion



            //ApplyFilter();

        }
        private void ApplyFilter()
        {


        }

        private void btprint_Click(object sender, EventArgs e)
        {

            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                var edidata = rows[0].DataBoundItem as t_itemlist;
                //var orders = OrderSqlHelper.ASNOrderDataListByMid(entityDataSource1, edidata.ジャンル);

                //reportForm.OrderEnities = orders;
                //reportForm.InitializeDataSource();
                //reportForm.ShowDialog();
                //InitializeEdiData();
            }
        }
        private void InitializeEdiData()
        {

            this.bindingSource2.DataSource = OrderSqlHelper.ASNEdiDataList(entityDataSource1);
            dataGridView1.DataSource = this.bindingSource2;

        }
    }
}
