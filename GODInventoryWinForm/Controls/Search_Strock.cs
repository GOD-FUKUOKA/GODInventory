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
    public partial class Search_Strock : Form
    {
        private BindingList<t_stockrec> stocklist;

        private List<t_manufacturers> t_manufacturersR;
        private List<t_shippers> t_shippersR;
        private List<t_stockrec> t_stocklistR;
        private List<t_genre> t_genreR;
        private Strock_CompanyCode Strock_CompanyCode;
        private t_stockrec order;

        public Search_Strock()
        {
            InitializeComponent();
            using (var ctx = new GODDbContext())
            {
                t_manufacturersR = ctx.t_manufacturers.ToList();
                t_shippersR = ctx.t_shippers.ToList();
                t_genreR = ctx.t_genre.ToList();
                t_stocklistR = ctx.t_stockrec.ToList();
            }


            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = stocklist;

            OrderSqlHelper item12 = new OrderSqlHelper();

            string[] ll = item12.Strock_QuFenout();
            for (int j = 0; j < ll.Length; j++)
            {
                this.comboBox1.Items.Add(ll[j]);
            }
            string[] llp = item12.StrockReback();
            for (int j = 0; j < llp.Length; j++)
            {
                this.comboBox2.Items.Add(llp[j]);
            }

            foreach (t_genre item in t_genreR)
            {
                this.comboBox3.Items.Add(item.ジャンル名);
            }
            foreach (t_manufacturers item in t_manufacturersR)
            {

                this.comboBox4.Items.Add(item.FullName);

            }
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            ApplyFilter();


        }
        private void ApplyFilter()
        {
            string filter = "";
            if (this.comboBox1.Text.Length > 0)
            {
                filter += "(区分=" + this.comboBox1.Text + ")";
            }
            if (this.comboBox2.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(仓库=" + this.comboBox2.Text + ")";
            }
            if (this.comboBox3.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(商品別=" + this.comboBox3.Text + ")";
            }
            if (this.comboBox4.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(工場=" + this.comboBox4.Text + ")";
            }

            this.bindingSource1.Filter = filter;

        }

    }
}
