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
using GODInventory.MyLinq;
using GODInventory;

namespace GODInventoryWinForm.Controls
{
    public partial class NewOrdersForm : Form
    {
        //SELECT o2.* FROM t_orderdata o1 inner join t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
        //where o1.`Status`=0 OR o2.`Status`=1 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品日`>NOW())
        //order by o2.店舗コード, o2.自社コード , o2.createdAt desc
        
        //o1.`id受注データ`!= o2.`id受注データ`


        private Hashtable datagrid_changes = null;
        List<v_duplicatedorder> duplicatedOrderList;
        SortableBindingList<v_duplicatedorder> duplicatedOrderBindingList;
        private List<t_itemlist> productList;

        public NewOrdersForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.AutoGenerateColumns = false;

            this.datagrid_changes = new Hashtable();
            this.InitializeOrderData();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            if (duplicatedOrderBindingList.Count > 0)
                {
                    using (var ctx = new GODDbContext())
                    {
                        for (int i = 0; i < duplicatedOrderBindingList.Count; i++)
                        {
                            var duplicated_order = duplicatedOrderBindingList[i];
                            t_orderdata order = ctx.t_orderdata.Find(duplicated_order.id受注データ);

                            if (duplicated_order.キャンセル == "yes")
                            {
                                //List<int> orderIds = new List<int> { duplicated_order.id受注データ };
                                //order.実際出荷数量 = 0;
                                //order.納品口数 = 0;
                                //order.キャンセル = "yes";
                                //order.キャンセル時刻 = DateTime.Now;
                                //order.Status = OrderStatus.Cancelled;
                                //order.備考 = "キャンセル";
                                //var product = productList.FirstOrDefault(o => o.自社コード == order.自社コード);
                                OrderSqlHelper.CancelOrder(ctx, order);

                            }
                            else if (duplicated_order.ダブリ == "no")
                            {
                                if (order.Status == OrderStatus.Duplicated) {
                                    order.実際出荷数量 = duplicated_order.実際出荷数量;
                                    order.納品口数 = duplicated_order.納品口数;
                                    //order.ダブリ = "no";
                                    //order.Status = OrderStatus.Pending;
                                    //var product = productList.FirstOrDefault(o => o.自社コード == order.自社コード);
                                    OrderSqlHelper.ChangeOrderStatusToPending(ctx, order);
                                }
                            }

                        }
                    }
                    var originalSortOrder = this.dataGridView1.SortOrder;
                    var originalSortedColumn = this.dataGridView1.SortedColumn;
                    InitializeOrderData();
                    
                    var direction = ListSortDirection.Ascending;
                    if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    if (originalSortedColumn != null)
                    {
                        if (this.dataGridView1.RowCount > 0)
                        {
                            this.dataGridView1.Sort(originalSortedColumn, direction);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ex" + "データを书いてください", "誤った", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }            
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public int InitializeOrderData()
        {
            this.datagrid_changes.Clear();

            string sql = @"SELECT o1.id受注データ as duplicatedId, o2.id受注データ, o2.`発注日`,o2.`出荷日`,o2.`納品日`,o2.`受注日`,o2.`店舗コード`, o2.`店舗名漢字`,
          o2.`納品場所名漢字`,o2.`伝票番号`,o2.`納品口数`,o2.`ジャンル`,o2.`品名漢字`,o2.`規格名漢字`, 
          o2.`実際出荷数量`,o2.`実際配送担当`,o2.`県別`, 
          o2.`発注形態名称漢字`,o2.`キャンセル`,o2.`ダブリ`, o2.Status, o3.ジャンル名 as GenreName
            FROM t_orderdata o1 
            INNER JOIN t_orderdata  o2 on o1.自社コード = o2.自社コード and o1.店舗コード=o2.店舗コード
            INNER JOIN t_genre  o3 on o1.ジャンル = o3.idジャンル 

    where o1.`Status`=22 AND (o1.id受注データ = o2.id受注データ OR  o2.`Status`=0 OR o2.`Status`=2 OR o2.`Status`=3 OR (o2.`Status`=5 AND o2.`納品予定日`>NOW()) )
    order by o2.店舗コード, o2.自社コード , o2.受注日, o1.id受注データ";

            using (var ctx = new GODDbContext())
            {
                this.productList = ctx.t_itemlist.Select(s => s).ToList();
                duplicatedOrderList = OrderSqlHelper.GetDuplicateOrderQuery(ctx).ToList();
                //duplicatedOrderList = ctx.Database.SqlQuery<v_duplicatedorder>(sql).ToList();
            }
            var shippers = duplicatedOrderList.Select(s =>  s.実際配送担当 ).Distinct().ToList();
            shippers.Insert(0, "すべて" );
            this.shipperComboBox.DataSource = shippers;

            duplicatedOrderBindingList = new SortableBindingList<v_duplicatedorder>(duplicatedOrderList);
            dataGridView1.DataSource = duplicatedOrderBindingList;

            return 0;
        }

        private void newOrderbutton_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int i = e.RowIndex;            
            var order = dataGridView1.Rows[i].DataBoundItem as v_duplicatedorder;
            if (order.キャンセル == "yes")
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                //this.dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Gray;

            }
            else if (order.ダブリ == "yes")
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //this.dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
            }
            else
            {
                this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            }
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = キャンセルColumn.Index;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) 
            {
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedOrderBindingList[rowIndex];
                var originalValue = order.キャンセル;
                order.キャンセル = "yes";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.キャンセル);
            }

            this.dataGridView1.Refresh();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = ダブリColumn.Index;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {               
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedOrderBindingList[rowIndex];
                var originalValue = order.ダブリ;
                order.ダブリ = "yes";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.ダブリ);
            }
            this.dataGridView1.Refresh();
        }

        private void uncancleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = キャンセルColumn.Index;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedOrderBindingList[rowIndex];
                var originalValue = order.キャンセル;
                order.キャンセル = "no";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.キャンセル);

            }
            this.dataGridView1.Refresh();
        }

        private void unduplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = ダブリColumn.Index;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                var rowIndex = dataGridView1.SelectedRows[i].Index;
                var order = duplicatedOrderBindingList[rowIndex];
                var originalValue = order.ダブリ;
                order.ダブリ = "no";
                UpdateChangesManually(rowIndex, columnIndex, originalValue, order.ダブリ);

            }
            //dataGridView1.ClearSelection(); 
            this.dataGridView1.Refresh();
        }

        //private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            dataGridView1.ClearSelection();
        //            dataGridView1.Rows[e.RowIndex].Selected = true;
        //            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        //        }
        //    } 
        //}

        #region DataGridView 修改历史功能

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = row.Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var col = dataGridView1.Columns[e.ColumnIndex];
            string cellKey = GetCellKey(e.RowIndex, e.ColumnIndex);
            string cellKeyForChanged = GetCellKey(e.RowIndex, e.ColumnIndex, true);

            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = datagrid_changes[cellKey];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                datagrid_changes.Remove(cellKeyForChanged);
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                datagrid_changes[cellKeyForChanged] = new_cell_value;
            }
            else
            {
                datagrid_changes.Remove(cellKeyForChanged);
            }

            if (col == this.実際出荷数量Column) 
            { 
            
            }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string cellKey = GetCellKey( e.RowIndex, e.ColumnIndex, true);

            if (datagrid_changes.ContainsKey(cellKey))
            {
                e.CellStyle.BackColor = Color.DarkRed;
                //e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

        }

        private string GetCellKey(int rowIndex, int columnIndex, bool forChanged)
        { 
        
          return  GetCellKey( rowIndex,  columnIndex) + "_changed";
        }

        private string GetCellKey(int rowIndex, int columnIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            var model = row.DataBoundItem as v_duplicatedorder;

            return string.Format( "{0}_{1}", model.id受注データ, columnIndex.ToString() );
        }

        private bool UpdateChangesManually(int rowIndex, int columnIndex, string originalValue, string newValue) 
        {
            string cellKey = GetCellKey(rowIndex, columnIndex);
            string cellKeyForChanged = GetCellKey(rowIndex, columnIndex, true);

            if (!datagrid_changes.ContainsKey(cellKey))
            {
                datagrid_changes[cellKey] = originalValue;
            }

            if( datagrid_changes[cellKey].ToString() != newValue )
            {
                datagrid_changes[cellKeyForChanged] = newValue;
            }
            else
            {
                datagrid_changes.Remove(cellKeyForChanged);
            }
            return true;
        }

        private IEnumerable<int> GetChangedRowIndexes()
        {

            List<int> rows = new List<int>();
            foreach (DictionaryEntry entry in datagrid_changes)
            {
                var key = entry.Key as string;
                if (key.EndsWith("_changed"))
                {
                    int row = Int32.Parse(key.Split('_')[0]);
                    rows.Add(row);
                }
                //                    Console.WriteLine("Key -- {0}; Value --{1}.", entry.Key, entry.Value);
            }
            return rows.Distinct();
        }

        #endregion


        #region 处理过滤条件

        private void ApplyFilter4(string shipper = "", string genre = "", string product = "", string county = "")
        {
            var originalSortOrder = this.dataGridView1.SortOrder;
            var originalSortedColumn = this.dataGridView1.SortedColumn;

            bindingSource1.DataSource = null;
            var filteredOrderList = duplicatedOrderList;
            datagrid_changes.Clear();


            if (shipper.Length > 0 && shipper != "すべて")
            {

                filteredOrderList = filteredOrderList.FindAll(o => o.実際配送担当 == shipper);

            }
            if (product.Length > 0 && product != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.品名漢字 == product);
            }
            if (genre.Length > 0 && genre != "すべて")
            {

                filteredOrderList = filteredOrderList.FindAll(o => o.GenreName == genre);

            }
            if (county.Length > 0 && county != "すべて")
            {
                filteredOrderList = filteredOrderList.FindAll(o => o.県別 == county);
            }

            duplicatedOrderBindingList = new SortableBindingList<v_duplicatedorder>(filteredOrderList);

            this.dataGridView1.DataSource = duplicatedOrderBindingList;

            var direction = ListSortDirection.Ascending;
            if (originalSortOrder == System.Windows.Forms.SortOrder.Descending)
            {
                direction = ListSortDirection.Descending;
            }
            if (originalSortedColumn != null)
            {
                if (this.dataGridView1.RowCount > 0)
                {
                    this.dataGridView1.Sort(originalSortedColumn, direction);
                }
            }
        }

        private void InitializeCountyComboBox(List<v_duplicatedorder> orders)
        {
            // GenreName
            var counties = orders.Select(s =>  s.県別 ).Distinct().ToList();
            counties.Insert(0,  "すべて" );

            this.countyComboBox.DataSource = counties;
        }

        private void InitializeGenreComboBox(List<v_duplicatedorder> orders)
        {
            // GenreName
            var GenreName = orders.Select(s => new MockEntity { Id = s.ジャンル, ShortName = s.GenreName, FullName = s.GenreName }).Distinct().ToList();
            GenreName.Insert(0, new MockEntity {Id=0, ShortName = "すべて", FullName = "すべて" });
            this.genreComboBox.DisplayMember = "FullName";
            this.genreComboBox.ValueMember = "Id";
            this.genreComboBox.DataSource = GenreName;
        }

        private void InitializeProductComboBox(List<v_duplicatedorder> orders)
        {
            // 品名漢字
            var PMHZ = orders.Select(s => new MockEntity { Id = s.自社コード, TaxonId = s.ジャンル, ShortName = s.品名漢字, FullName = s.品名漢字 }).Distinct().ToList();
            PMHZ.Insert(0, new MockEntity { Id = 0, ShortName = "すべて", FullName = "すべて" });
            this.productComboBox.DisplayMember = "FullName";
            this.productComboBox.ValueMember = "Id";
            this.productComboBox.DataSource = PMHZ;
        }

        private void clearSelectButton_Click(object sender, EventArgs e)
        {
            bindingSource1.Sort = "";
            shipperComboBox.SelectedIndex = 0;
            productComboBox.SelectedIndex = 0;
            genreComboBox.SelectedIndex = 0;
            countyComboBox.SelectedIndex = 0;
        }

        private void shipperComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combox = sender as ComboBox;
            string shipper = combox.Text;
            var orders = GetOrdersByShipper(shipper);
            InitializeCountyComboBox(orders);
        }

        private void countyComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            var orders = GetOrdersByShipper(shipper);

            var combox = sender as ComboBox;
            if (combox.Text != "すべて")
            {
                orders = orders.FindAll(o => o.県別 == combox.Text);
            }
            InitializeGenreComboBox(orders);
        }

        private void GenreNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            var orders = GetOrdersByShipper(shipper);

            var combox = sender as ComboBox;
            if (combox.Text != "すべて")
            {
                orders = orders.FindAll(o => o.GenreName == combox.Text);
            }

            // 品名漢字
            InitializeProductComboBox(orders);
        }

        private void productCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shipper = shipperComboBox.Text;
            string genre = genreComboBox.Text;
            string product = productComboBox.Text;
            string county = countyComboBox.Text;
            ApplyFilter4(shipper, genre, product, county);
        }

        private List<v_duplicatedorder> GetOrdersByShipper(string shipper)
        {
            List<v_duplicatedorder> orders = duplicatedOrderList;
            if (shipper != "すべて")
            {
                orders = orders.FindAll(o => o.実際配送担当 == shipper);
            }
            return orders;
        }


        #endregion



    }
}
