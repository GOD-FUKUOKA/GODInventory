using GODInventory.MyLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    public partial class WarehouseTransportForm : Form
    {
        private List<t_transports> transportList;
        private List<t_warehouses> warehouseList;
        private List<t_warehouses_transports> warehouses_transportsList;
        List<t_transports> FindtransportList;
        private int wid;
        private int tid;
        //private List<v_transport> V_transportList;
        private BindingList<v_transport> V_transportList;
        private Hashtable datagridChanges = null;
        int RowRemark = 0;
        int cloumn = 0;
        int selectlistboxindex = 0;

        public WarehouseTransportForm()
        {
            InitializeComponent();
            this.datagridChanges = new Hashtable();


            transportList = new List<t_transports>();

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = transportList;

            InitializeDataSource();

        }
        public void InitializeDataSource()
        {
            datagridChanges.Clear();
            if (listBox1.Items.Count > 0)
            {
                this.listBox1.DataSource = null;
                listBox1.Items.Clear();
            }
            using (var ctx = new GODDbContext())
            {
                warehouseList = ctx.t_warehouses.ToList();
                warehouses_transportsList = ctx.t_warehouses_transports.ToList();
                transportList = ctx.t_transports.ToList();


            }

            this.listBox1.DisplayMember = "FullName";
            this.listBox1.ValueMember = "Id";
            this.listBox1.DataSource = warehouseList;


            this.listBox2.DisplayMember = "fullname";
            this.listBox2.ValueMember = "id";
            this.listBox2.DataSource = transportList;

           

            //BuildStockNO();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            v_transport item = new v_transport();



            //   transportList.Add(item);


        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var filtered = warehouseList.FindAll(s => s.Id == (int)this.ComboBox.SelectedValue);
            //if (filtered.Count > 0)
            {
                //shipperTextBox.Text = ComboBox.Text;
                //    shipperTextBox.Text = filtered[0].FullName;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var oids = GetOrderIdsBySelectedGridCell();
            string oids = listBox2.Text.ToString();
            t_transports tlist = transportList.Find(o => o.fullname != null && o.fullname == oids);

            if (tlist != null)
            {
                //var form = new Edit__Transports();
                //form.tid = tlist.id;
                //form.wid = wid;
                //form.InitializeOrder();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    //this.entityDataSource1.Refresh();
                //    InitializeDataSource();
                //}
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
            var deletedStockNumList = new List<string>();

            if (column == deleteButtonColumn)
            {


                var oids = GetOrderIdsBySelectedGridCell();
                using (var ctx = new GODDbContext())
                {
                    t_transports tlist = transportList.Find(o => o.fullname != null && o.fullname == oids[0]);
                    if (tlist != null && tlist.id != null)
                    {
                        t_warehouses_transports widlist = warehouses_transportsList.Find(o => o.wid != null && o.wid == Convert.ToInt32(wid) && o.tid == tlist.id);

                        var del = (from s in ctx.t_warehouses_transports
                                   where s.wid == wid && s.tid == widlist.tid
                                   select s).ToList();
                        ctx.t_warehouses_transports.RemoveRange(del);
                        ctx.SaveChanges();

                    }
                    // this.transportList.RemoveAll(s => deletedStockNumList.Contains(s.fullname));
                    transportList.RemoveAt(e.RowIndex);
                    V_transportList.RemoveAt(e.RowIndex);
                }

            }
        }
        private List<string> GetOrderIdsBySelectedGridCell()
        {

            List<string> order_ids = new List<string>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView1);
            foreach (DataGridViewRow row in rows)
            {
                var order = row.DataBoundItem as v_transport;
                order_ids.Add(order.Transport_name);
            }

            return order_ids;
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


        private void CreateTransportForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItems.Count > 0)
            {
                //获取选中的值
                //string selecttx = this.listBox1.SelectedItem.ToString();
                string selecttx = listBox1.Text.ToString();
                var warehouse = warehouselistBox();

                if (warehouse > 0 && selecttx != "GODInventory.MyLinq.t_warehouses")
                {
                    wid = Convert.ToInt32(warehouse);
                    //读取关系表内的所有 仓库下的 关系 运输公司
                    List<t_warehouses_transports> mlist = warehouses_transportsList.FindAll(o => o.wid != null && o.wid == Convert.ToInt32(warehouse)).ToList();
                    if (mlist != null)
                    {
                        //循环读取出运输公司下的所有子信息
                        FindtransportList = new List<t_transports>();

                        for (int i = 0; i < mlist.Count; i++)
                        {
                            List<t_transports> nlist = transportList.FindAll(o => o.id != null && o.id == Convert.ToInt32(mlist[i].tid)).ToList();
                            FindtransportList = FindtransportList.Concat(nlist).ToList();
                        }
                        //添加显示集合
                        t_warehouses widlist = warehouseList.Find(o => o.Id != null && o.Id == Convert.ToInt32(wid));
                        V_transportList = new BindingList<v_transport>();
                        foreach (t_transports item in FindtransportList)
                        {
                            v_transport temp = new v_transport();

                            temp.ShipperName = widlist.ShipperName;
                            temp.Transport_name = item.fullname;
                            V_transportList.Add(temp);
                        }

                        this.dataGridView1.DataSource = V_transportList;

                    }


                }

            }
            else
            {
                //  MessageBox.Show("未选中listbox集合的值");
            }




        }
        private int warehouselistBox()
        {

            return ((this.listBox1.SelectedIndex >= 0) ? (int)this.listBox1.SelectedValue : 0);
        }
        private int transportslistBox()
        {

            return ((this.listBox2.SelectedIndex >= 0) ? (int)this.listBox2.SelectedValue : 0);
        }

        private void addtsButton_Click(object sender, EventArgs e)
        {
            var form = new Create_Transports();
            form.wid = wid;
            if (form.ShowDialog() == DialogResult.OK)
            {

                //待确认，是否选择仓库直接添加到其名下
                //int tid = form.tid;

                //using (var ctx = new GODDbContext())
                //{

                //    t_warehouses_transports item = new t_warehouses_transports();
                //    item.wid = wid;
                //    item.tid = tid;

                //    ctx.t_warehouses_transports.Add(item);
                //    ctx.SaveChanges();

                //}
                //this.entityDataSource1.Refresh();
                InitializeDataSource();
            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dataGridView1.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   dataGridView1.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString() + "_changed";

            if (datagridChanges.ContainsKey(cell_key))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
                try
                {
                    if (datagridChanges.ContainsKey(e.RowIndex))//if (dgrSingle.Cells["列名"].Value.ToString().Contains("比较值"))
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!datagridChanges.ContainsKey(cell_key))
            {
                datagridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = datagridChanges[cell_key];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                datagridChanges.Remove(cell_key + "_changed");
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                datagridChanges[cell_key + "_changed"] = new_cell_value;
            }
            else
            {
                datagridChanges.Remove(cell_key + "_changed");
            }
        }

        private void btAddWarehouse_Click(object sender, EventArgs e)
        {
            var form = new Create_Warehouse();

            if (form.ShowDialog() == DialogResult.OK)
            {

                //this.entityDataSource1.Refresh();
                InitializeDataSource();

            }



        }

        private void bteditwh_Click(object sender, EventArgs e)
        {

            var form = new Edit_Warehouse();
            form.wid = wid;
            form.InitializeOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                InitializeDataSource();
            }
        }

        private void btloadTransport_Click(object sender, EventArgs e)
        {

            var form = new Bind__Transports();

            form.wid = wid;
            form.InitializeOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                InitializeDataSource();

            }


        }

        private void btaddtransportitem_Click(object sender, EventArgs e)
        {

            List<t_warehouses_transports> mlist = warehouses_transportsList.FindAll(o => o.wid != null && o.wid == Convert.ToInt32(wid) && o.tid == Convert.ToInt32(tid)).ToList();
            if (mlist.Count > 0)
            {

                return;

            }
            else
            {

                var ctx = entityDataSource1.DbContext as GODDbContext;
                t_warehouses_transports item = new t_warehouses_transports();
                item.wid = wid;
                item.tid = tid;
                ctx.t_warehouses_transports.Add(item);
                ctx.SaveChanges();
                selectlistboxindex = listBox1.SelectedIndex;


                InitializeDataSource();
                listBox1.SelectedIndex = selectlistboxindex;

                
            }
        }

     
        private void btremovetransportItem_Click(object sender, EventArgs e)
        {
            var oids = GetOrderIdsBySelectedGridCell();
            using (var ctx = new GODDbContext())
            {
                t_transports tlist = transportList.Find(o => o.fullname != null && o.fullname == oids[0]);
                if (tlist != null && tlist.id != null)
                {
                    t_warehouses_transports widlist = warehouses_transportsList.Find(o => o.wid != null && o.wid == Convert.ToInt32(wid) && o.tid == tlist.id);

                    var del = (from s in ctx.t_warehouses_transports
                               where s.wid == wid && s.tid == widlist.tid
                               select s).ToList();
                    ctx.t_warehouses_transports.RemoveRange(del);
                    ctx.SaveChanges();

                }
                selectlistboxindex = listBox1.SelectedIndex;


                InitializeDataSource();
                listBox1.SelectedIndex = selectlistboxindex;
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedItems.Count > 0)
            {
                //获取选中的值
                string selecttx = listBox2.Text.ToString();
                tid = transportslistBox();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowRemark = e.RowIndex;
            cloumn = e.ColumnIndex;
        }
    }
}
