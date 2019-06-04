using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using GODInventory.MyLinq;
using GODInventory;
namespace GODInventoryWinForm.Controls.Branches
{
    public partial class IndexForm : Form
    {
   
        protected List<t_branches> branches;
        protected List<t_staffs> stf;
        protected List<t_shoplist> store;
        public IndexForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addbranches adb = new Addbranches();
            adb.ShowDialog();
            if (adb.DialogResult == DialogResult.OK)
            {
                this.loadTreeview();
            }

        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            loadTreeview();

        }

        #region 初始化treeview
        public void loadTreeview()
        {
            try
            {
                treeView1.Nodes[0].Nodes.Clear();
                using (var cxsk = new GODDbContext())
                {
                    branches = cxsk.t_branchs.ToList();
                    if (branches != null)
                    {
                        foreach (t_branches bc in branches)
                        {

                            TreeNode tn = new TreeNode();
                            tn.Text = bc.fullname;
                            tn.Name = bc.id.ToString();
                            treeView1.Nodes[0].Nodes.Add(tn);


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误！");
            }
            finally
            {
            }
        }

        #endregion

        #region 删除公司事件
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择后再删除");
            }
            else if (treeView1.SelectedNode.Name.Equals("0"))
            {
                MessageBox.Show("请选择后再删除！");
            }
            else
            {
                if (deleteBranches() > 0)
                {
                    MessageBox.Show("删除成功!");
                    loadTreeview();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        #endregion

        #region 公司删除方法
        private int deleteBranches()
        {
            int i = 0;
            string deleteid = treeView1.SelectedNode.Name;
            try
            {
                using (var ctx = new GODDbContext())
                {
                    int delid = int.Parse(deleteid);
                    t_branches tb = ctx.t_branchs.First(tba => tba.id == delid);
                    if (tb != null)
                    {
                        ctx.t_branchs.Remove(tb);
                        ctx.SaveChanges();
                        i = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出错");
            }
            return i;
        }

        #endregion

        #region treeview1的右键事件
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//判断你点的是不是右键
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    switch (CurrentNode.Name)//根据不同节点显示不同的右键菜单，当然你可以让它显示一样的菜单
                    {
                        case "errorUrl":
                            CurrentNode.ContextMenuStrip = ct_TreeviewDelete;
                            break;
                    }
                    treeView1.SelectedNode = CurrentNode;//选中这个节点
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {

                    treeView1.SelectedNode = CurrentNode;//选中这个节点
                    if (!treeView1.SelectedNode.Text.Equals("总公司"))
                    {
                        selectStaffs(treeView1.SelectedNode.Name);
                        selectStroe(treeView1.SelectedNode.Name);
                    }
                    else
                    {
                        stf = new List<t_staffs>();
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = stf;
                        store = new List<t_shoplist>();
                        dataGridView2.AutoGenerateColumns = false;
                        dataGridView2.DataSource = store;
                    }
                }
            }
        }

        #endregion

        #region 修改公司事件
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择后再修改");
            }
            else if (treeView1.SelectedNode.Name.Equals("0"))
            {
                MessageBox.Show("请选择后再修改！");
            }
            else
            {
                Addbranches adb = new Addbranches();
                adb.updeteid = treeView1.SelectedNode.Name;
                adb.title = "修改分公司";
                adb.Text = "修改分公司";
                adb.ShowDialog();
                if (adb.DialogResult == DialogResult.OK)
                {
                    loadTreeview();
                }
            }
        }

        #endregion

        private void treeView1_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region 添加员工按钮事件
        private void newButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择公司后再添加！");

            }
            else if (treeView1.SelectedNode.Name.Equals("0"))
            {
                MessageBox.Show("请选择公司后再添加！");
            }
            else
            {
                addstaffs ads = new addstaffs();
                ads.title = treeView1.SelectedNode.Text + "公司添加员工信息";
                ads.branchid = treeView1.SelectedNode.Name;
                ads.ShowDialog();
                if (ads.DialogResult == DialogResult.OK)
                {
                    selectStaffs(treeView1.SelectedNode.Name);
                }

            }

        }

        #endregion

        #region 查询员工方法
        private void selectStaffs(string branchesid)
        {
            try
            {
                if (!branchesid.Equals(string.Empty) && branchesid != null)
                    using (var cxt = new GODDbContext())
                    {
                        int brid = int.Parse(branchesid);
                        var q = (from t_staffs t in cxt.t_staffs
                                 where t.branch_id == brid
                                 select t).ToList();
                        stf = q;
                        if (stf.Count != 0)
                        {
                            if (dataGridView1.Columns["btndelete"] != null)
                            {
                                dataGridView1.Columns["btndelete"].Visible = true;
                            }

                            if (dataGridView1.Columns["btnBj"] != null)
                            {
                                dataGridView1.Columns["btnBj"].Visible = true;
                            }
                            dataGridView1.AutoGenerateColumns = false;
                            DataGridViewButtonColumn dgbc = new DataGridViewButtonColumn();
                            dgbc.Name = "btnBj";
                            dgbc.HeaderText = "编辑";
                            dgbc.DefaultCellStyle.NullValue = "编辑";
                            DataGridViewButtonColumn dgbcDel = new DataGridViewButtonColumn();
                            dgbcDel.Name = "btndelete";
                            dgbcDel.HeaderText = "删除";
                            dgbcDel.DefaultCellStyle.NullValue = "删除";
                            if (dataGridView1.Columns["btndelete"] == null)
                            {
                                dataGridView1.Columns.Add(dgbcDel);
                            }

                            if (dataGridView1.Columns["btnBj"] == null)
                            {
                                dataGridView1.Columns.Add(dgbc);
                            }
                            dataGridView1.DataSource = stf;
                        }
                        else
                        {
                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = stf;
                            if (dataGridView1.Columns["btndelete"] != null)
                            {

                                dataGridView1.Columns["btndelete"].Visible = false;
                            }

                            if (dataGridView1.Columns["btnBj"] != null)
                            {
                                dataGridView1.Columns["btnBj"].Visible = false;
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序报错error");
            }
        }

        #endregion

        #region 员工datagridview点击事件
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();

                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }


            }
        }

        #endregion

        #region 员工删除方法
        private int delete()
        {
            int indexa = 0;
            try
            {
                using (var ctx = new GODDbContext())
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = int.Parse(dataGridView1.Rows[index].Cells["Id"].Value.ToString());
                    t_staffs stf = ctx.t_staffs.First(ts => ts.id == id);
                    ctx.t_staffs.Remove(stf);
                    ctx.SaveChanges();
                    indexa = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误！");
            }
            return indexa;

        }
        #endregion


        #region 查询公司所持有的店铺
        private void selectStroe(string id)
        {
            store = new List<t_shoplist>();
            using (var ctx = new GODDbContext())
            {
                int bid = int.Parse(id);
                var query = (from ts in ctx.t_branches_stores
                             join tf in ctx.t_shoplist on ts.store_id equals tf.店番
                             where ts.branch_id == bid && tf.店番 == ts.store_id
                             select new
                             {
                                 ts.id,
                                 tf.店名,
                                 tf.県別,
                                 tf.県内エリア
                             }).ToList();

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = query;
            }
        }
        #endregion

        #region 店铺添加事件
        private void button1_Click(object sender, EventArgs e)
        {

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择公司后再添加！");

            }
            else if (treeView1.SelectedNode.Name.Equals("0"))
            {
                MessageBox.Show("请选择公司后再添加！");
            }
            else
            {
                AddStore ads = new AddStore();
                ads.title = treeView1.SelectedNode.Text + "公司添加店铺信息";
                ads.compid = treeView1.SelectedNode.Name;
                ads.ShowDialog();
                if (ads.DialogResult == DialogResult.OK)
                {
                    selectStroe(treeView1.SelectedNode.Name);
                }
            }
        }
        #endregion

        #region 店铺datagridview点击事件
        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                    contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                }

            }
        }
        #endregion

        #region 删除店铺事件
        private void 删除ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择公司后再删除！");

            }
            else if (treeView1.SelectedNode.Name.Equals("0"))
            {
                MessageBox.Show("请选择公司后再删除！");
            }
            else
            {
                try
                {
                    if (deleteStore() > 0)
                    {
                        MessageBox.Show("删除成功");
                        selectStroe(treeView1.SelectedNode.Name);
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序有误");
                }
            }
        }

        #endregion

        #region 删除店铺方法
        private int deleteStore()
        {
            int index = 0;
            using (var ctx = new GODDbContext())
            {
                int dtindex = dataGridView2.SelectedRows[0].Index;
                int dpid = int.Parse(dataGridView2.Rows[dtindex].Cells["storeid"].Value.ToString());
                t_branches_stores tbs = ctx.t_branches_stores.First(tbsa => tbsa.id == dpid);
                ctx.t_branches_stores.Remove(tbs);
                ctx.SaveChanges();
                index = 1;
            }
            return index;
        }

        #endregion


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("btnBj"))
                {
                    #region 编辑
                    if (treeView1.SelectedNode == null)
                    {
                        MessageBox.Show("请选择公司后再编辑！");

                    }
                    else if (treeView1.SelectedNode.Name.Equals("0"))
                    {
                        MessageBox.Show("请选择公司后再编辑！");
                    }
                    else
                    {
                        int index = dataGridView1.SelectedRows[0].Index;
                        addstaffs adsf = new addstaffs();
                        adsf.staffsid = dataGridView1.Rows[index].Cells["Id"].Value.ToString();
                        adsf.title = dataGridView1.Rows[index].Cells["fullname"].Value.ToString() + "员工的信息修改";
                        adsf.branchid = treeView1.SelectedNode.Name;
                        adsf.ShowDialog();
                        if (adsf.DialogResult == DialogResult.OK)
                        {
                            selectStaffs(treeView1.SelectedNode.Name);
                        }
                    }
                    #endregion

                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("btndelete"))
                {
                    #region 删除
                    if (treeView1.SelectedNode == null)
                    {
                        MessageBox.Show("请选择公司后再删除！");

                    }
                    else if (treeView1.SelectedNode.Name.Equals("0"))
                    {
                        MessageBox.Show("请选择公司后再删除！");
                    }
                    else
                    {
                        if (delete() > 0)
                        {
                            MessageBox.Show("删除成功!");
                            selectStaffs(treeView1.SelectedNode.Name);
                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }
                    #endregion
                }
            }
        }



    }
}
