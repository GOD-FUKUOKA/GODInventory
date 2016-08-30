using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    using GODInventory.MyLinq;
    using GODInventory.ViewModel;

    public partial class WaitToShipForm : Form
    {

        private BindingList<v_pendingorder> orderList;
        private List<v_pendingorder> orderListRE;

        public WaitToShipForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            InitializePager();
            //
            var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1).ToList();

            var filtered = q.FindAll(s => s.県別 != null);

            foreach (v_pendingorder item in filtered)
                this.comboBox1.Items.Add(item.県別);
            filtered = q.FindAll(s => s.店舗コード != null);
            foreach (v_pendingorder item in filtered)
                this.comboBox2.Items.Add(item.店舗コード);

            orderList = new BindingList<v_pendingorder>();
            orderListRE = new List<v_pendingorder>();

            this.dataGridView2.AutoGenerateColumns = false;

            this.dataGridView2.DataSource = orderList;


        }

        #region Pager Methods

        public void InitializePager()
        {
            this.pager1.PageCurrent = 1; //当前页为第一页              
            this.pager1.PageSize = 5000; //页数   
            this.pager1.Bind();
        }

        public void RefreshPager()
        {
            this.pager1.Bind();
        }

        #endregion

        public int InitializeOrderRelated()
        {

            var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1);
            var count = q.Count();

            q = q.Take(pager1.OffSet(pager1.PageCurrent));
            if (pager1.PageCurrent > 1)
            {
                q = q.Skip(pager1.OffSet(pager1.PageCurrent - 1));
            }
            // create BindingList (sortable/filterable)
            bindingSource1.DataSource = entityDataSource1.CreateView(q);

            // assign BindingList to grid

            dataGridView1.DataSource = this.bindingSource1;

            return count;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                var form = new ShipingInfoConfirmForm();
                List<int> orderIds = GetOrderIdsBySelectedGridCell();


                form.SelectedOrderIds = orderIds;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    pager1.Bind();
                }
            }
            else
            {
                MessageBox.Show("Please select orders first!");
            }


            //.ShowDialog();
        }

        private void shipperComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }

        private void shipperComboBox_TextUpdate(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }
        private void ApplyBindSourceFilter(string text)
        {

            string filter = "";
            if (this.comboBox1.Text.Length > 0)
            {
                filter += "(県別=" + "'" + this.comboBox1.Text + "'" + ")";
            }
            if (this.comboBox2.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(店舗名漢字=" + this.comboBox2.Text + ")";
            }
            if (this.shipperComboBox.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                filter += "(実際配送担当=" + "'" + this.shipperComboBox.Text + "'" + ")";
            }
            bindingSource1.Filter = filter;

            //原先代码

            //if (shipperComboBox.Text == String.Empty || shipperComboBox.Text == "All")
            //{
            //    bindingSource1.Filter = "";
            //}
            //else
            //{
            //    bindingSource1.Filter = "実際配送担当='" + shipperComboBox.Text + "'";
            //    //bindingSource1.ResetBindings(true);
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private List<int> GetOrderIdsBySelectedGridCell()
        {

            List<int> order_ids = new List<int>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var pendingorder = row.DataBoundItem as v_pendingorder;
                order_ids.Add(pendingorder.id受注データ);
            }

            return order_ids;
        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            int order_count = InitializeOrderRelated();
            return order_count;
        }

        private void btFindS_Click(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(shipperComboBox.Text);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox1.Text);
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox2.Text);
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            ApplyBindSourceFilter(comboBox2.Text);

        }

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                List<int> orderIds = GetOrderIdsBySelectedGridCell();
                var q = OrderSqlHelper.WaitToShipOrderSql(entityDataSource1).ToList();

                var filtered = q.FindAll(s => s.県別 != null);
                foreach (v_pendingorder iyte in filtered)
                {
                    orderList.Add(iyte);
                    bindingSource1.Remove(iyte);


                }
                //  InitializePager();
                //InitializeOrderRelated();
                //dataGridView1.Refresh();
                //this.dataGridView1.DataSource = null;

                //this.dataGridView1.DataSource = this.bindingSource1;

                //pager1.Bind();
            }
            else
            {
                MessageBox.Show("Please select orders first!");
            }

        }

        private void WaitToShipForm_Load(object sender, EventArgs e)
        {
            InitializeOrderRelated();

        }

    }
}
