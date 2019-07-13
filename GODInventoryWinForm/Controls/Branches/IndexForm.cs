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
        protected List<t_staffs> staffs;
        protected List<t_branches> branchList;
        protected List<v_staffs> staffList;

        protected List<v_shop> shopList;
        protected List<t_warehouses> warehouseList;

        string selectedTreeViewNodeText;

        public IndexForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            selectedTreeViewNodeText = String.Empty;
        }

        #region 初始化数据
        private void InitializeData() {

            using (var ctx = new GODDbContext())
            {
                this.branchList = ctx.t_branchs.ToList();
                this.staffList = (from s in ctx.t_staffs
                    join b in ctx.t_branchs on s.branch_id equals b.id
                        select new v_staffs{
                            id = s.id,
                            login = s.login,
                            fullname = s.fullname,
                            phone = s.phone,
                            role = s.role,
                            memo = s.memo,
                            password = s.password,
                            branch_id = s.branch_id,
                            branchname = b.fullname
                        }).ToList();

                this.shopList = (from bs in ctx.t_branches_stores
                            join w in ctx.t_warehouses on bs.warehouse_id equals w.Id
                            select new v_shop
                             {
                                 branch_store_id = bs.id,
                                 branch_id = bs.branch_id,
                                 warehouse_id = bs.warehouse_id,
                                 warehousename = w.FullName,
                                
                             }).ToList();

                this.warehouseList = ctx.t_warehouses.ToList(); 

            }   
        }

        #endregion


        #region 添加公司事件
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var node = treeView1.SelectedNode;

                if (node != null)
                {
                    string selectedNodeName = treeView1.SelectedNode.Name;

                    int parentid = this.branchList.Find(o => o.parent_id == 0).id;




                    AddBranchForm form = new AddBranchForm();
                    form.ParentId = parentid;
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        this.loadTreeview();
                        // 选择新添加的分公司
                        refresh_treeview(form.CurrentBranch.fullname);

                    }
                }
                else {

                    MessageBox.Show("请选择一个分公司！");

                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh_treeview(string selectedNodeText = "")
        {
            this.selectedTreeViewNodeText = selectedNodeText;
            foreach (TreeNode n in treeView1.Nodes)
            {
                ErgodicTreeView(n);
            }

         
                selectStaffs(treeView1.SelectedNode.Name);
                selectStroe(treeView1.SelectedNode.Name);
           

        }
        #endregion


        private void IndexForm_Load(object sender, EventArgs e)
        {
            loadTreeview();
            refresh_treeview(this.selectedTreeViewNodeText);

            //this.debugLabel.Text = this.dataGridView2.ReadOnly.ToString();
            this.dataGridView2.ReadOnly = false;
        }

        #region 初始化treeview
        public void loadTreeview()
        {
            try
            {
                    InitializeData();

                    treeView1.Nodes.Clear();
                    var roots = this.branchList.Where(o=>o.parent_id == 0).ToList();
                                  
                    if (roots.Count != 0)
                    {
                        foreach (t_branches bc in roots)
                        {
                            TreeNode tnc = new TreeNode();
                            tnc.Text = bc.fullname;
                            tnc.Name = bc.id.ToString();
                            treeView1.Nodes.Add(tnc);
                        }
                        var nodes  = this.branchList.Where(o => o.parent_id != 0).ToList();
                        foreach (t_branches bc in nodes)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Text = bc.fullname;
                            tn.Name = bc.id.ToString();
                            for (int i = 0; i < treeView1.Nodes.Count; i++)
                            {
                                if (treeView1.Nodes[i].Name == bc.parent_id.ToString())
                                {
                                    treeView1.Nodes[i].Nodes.Add(tn);
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(selectedTreeViewNodeText)) {
                            if (nodes.Count > 0) {
                                selectedTreeViewNodeText = nodes.First().fullname;
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误！");
            }
             
        }

        #endregion

        #region 删除公司事件
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认删除该公司吗?", "系统提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择后再删除！");
                }
                else if (treeView1.SelectedNode.Name.Equals("1") || treeView1.SelectedNode.Name.Equals("2"))
                {
                    MessageBox.Show("总公司不能删除！");
                }
                else
                {
                    if (deleteBranches() > 0)
                    {
                        MessageBox.Show("删除成功！");
                        loadTreeview();
                     
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
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
                    var query = (from t_staffs t in ctx.t_staffs
                                 where t.branch_id == delid
                                 select t).ToList();
                    if (query.Count <= 0)
                    {
                        t_branches tb = ctx.t_branchs.First(tba => tba.id == delid);
                        if (tb != null)
                        {
                            ctx.t_branchs.Remove(tb);
                            ctx.SaveChanges();
                            i = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("该公司还有员工您不能删除");
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
            //else if (e.Button == MouseButtons.Left)
            //{
            //    Point ClickPoint = new Point(e.X, e.Y);
            //    TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
            //    if (CurrentNode != null)//判断你点的是不是一个节点
            //    {
            //        treeView1.SelectedNode = CurrentNode;//选中这个节点
            //        selectStaffs(treeView1.SelectedNode.Name);
            //        selectStroe(treeView1.SelectedNode.Name);
            //    }
            //}
        }

        #endregion

 
        #region 修改公司事件
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedBranchId = int.Parse(treeView1.SelectedNode.Name);

            bool existBranch = this.branchList.Exists(o => o.id == selectedBranchId && o.parent_id != 0);

            if (existBranch)
            {
                
                {
                    AddBranchForm form = new AddBranchForm();

                    form.ModelId = selectedBranchId;
                    form.title = "修改分公司";
                    form.Text = "修改分公司";
                    form.ParentId = int.Parse(treeView1.SelectedNode.Parent.Name);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        loadTreeview();
                    }
                    refresh_treeview(form.CurrentBranch.fullname);
                }
            }
            else
            {
                MessageBox.Show("请选择一个分公司");
            }
        }

        #endregion

        private void treeView1_Click(object sender, EventArgs e)
        {

            selectedTreeViewNodeText = treeView1.SelectedNode.Text;

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
                int branchid = Int32.Parse(treeView1.SelectedNode.Name);
                var branch = this.branchList.Find(o=>o.id == branchid);
                AddStaffForm form = new AddStaffForm();
                form.title = treeView1.SelectedNode.Text + "公司添加员工信息";
                form.CurrentBranch = branch;
                form.StaffList = this.staffList;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    InitializeData();
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
                int bid = Int32.Parse(treeView1.SelectedNode.Name);

                var branch = this.branchList.Find(o => o.id == bid);
      
                var staffs = this.staffList.FindAll(o => o.branch_id == branch.id);
                            
                dataGridView1.DataSource = staffs;                          
                        
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

        #region 员工删除点击事件
        private void 删除ToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {


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

        #region 员工编辑事件
        private void 修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 查询公司所持有的店铺
        private void selectStroe(string id)
        {
            int bid = int.Parse(id);

            var wids = this.shopList.FindAll(o => o.branch_id == bid).Select(o=>o.warehouse_id).ToList();

            var results = (from w in warehouseList
                                select new v_shop
                                {
                                    warehouse_id = w.Id,
                                    ischeck = wids.Contains(w.Id),
                                    warehousename = w.FullName
                                }).ToList();

            dataGridView2.DataSource = results;            
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

                try
                {
                    int branchid = Int32.Parse(treeView1.SelectedNode.Name);
                    List<int> originalWarehouseIds = this.shopList.FindAll(o => o.branch_id == branchid).Select(o => o.warehouse_id).ToList();
                    List<int> newWarehouseIds = new List<int>();
                    int count = dataGridView2.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var row = dataGridView2.Rows[i];
                        var store = row.DataBoundItem as v_shop;
                        if (store.ischeck)
                        {
                            newWarehouseIds.Add( store.warehouse_id);
                        }
                    }

                    var addid = newWarehouseIds.Except(originalWarehouseIds).ToList();
                    var removeid = originalWarehouseIds.Except(newWarehouseIds).ToList();

                    using (var ctx = new GODDbContext())
                    {
                        var removed = ( from bs in ctx.t_branches_stores
                          where bs.branch_id==branchid && removeid.Contains(bs.warehouse_id)
                                            select bs).ToList();

                        for (int i = 0; i < addid.Count(); i++)
                        {
                             
                                t_branches_stores tbs = new t_branches_stores();
                                tbs.branch_id = branchid;
                                tbs.warehouse_id = addid[i];
                                ctx.t_branches_stores.Add(tbs);               
                            
                        }
                        ctx.t_branches_stores.RemoveRange( removed );
                        ctx.SaveChanges();
                    }

                    if (removeid.Count > 0 || addid.Count>0)
                    {
                        MessageBox.Show("保存成功");
                        InitializeData();
                        selectStroe(treeView1.SelectedNode.Name);

                         
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序有误");
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
            if (MessageBox.Show("您确定要删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                            InitializeData();
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

        private void 删除ToolStripMenuItem2_Click_2(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("您确定要删除吗？", "系统提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                #region 删除              

                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择公司后再删除！");

                }
                else if (treeView1.SelectedNode.Name.Equals("1") || treeView1.SelectedNode.Name.Equals("2"))
                {
                    MessageBox.Show("总公司不能删除！");
                }
                else
                {
                    if (delete() > 0)
                    {
                        MessageBox.Show("删除成功!");
                        InitializeData();
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

        private void 修改ToolStripMenuItem1_Click_1(object sender, EventArgs e)
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

                var selectedStaff = dataGridView1.SelectedRows[0].DataBoundItem as v_staffs;
                AddStaffForm form = new AddStaffForm();
                var staff = new t_staffs() { id = selectedStaff.id,login=selectedStaff.login, fullname = selectedStaff.fullname, password = selectedStaff.password, branch_id = selectedStaff.branch_id, role = selectedStaff.role, phone = selectedStaff.phone, memo=selectedStaff.memo };

                var branch = this.branchList.Find(o => o.id == staff.branch_id);
                form.CurrentStaff = staff;
                form.CurrentBranch = branch;
                form.StaffList = this.staffList;
                form.title = "员工信息修改";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    InitializeData();
                    selectStaffs(treeView1.SelectedNode.Name);
                }
            }
            #endregion
        }



        void ErgodicTreeView(TreeNode tn)
        {
            if (tn == null) return;
            //查找到某节点时
            if (tn.Text.Equals(selectedTreeViewNodeText))
            {
                //遍历递归获取父节点，将父节点全部展开
                prenode(tn);
                //选中某节点，并加背景颜色
                treeView1.SelectedNode = tn;
                //treeView1.SelectedNode.BackColor = System.Drawing.Color.Blue;
            }
            foreach (TreeNode n in tn.Nodes)
            {
                ErgodicTreeView(n);
            }
        }
        // 展开当前选择的节点，可能是root，也可能是node
        void prenode(TreeNode m)
        {

            if (m.Parent != null)
            {
                m.Parent.Expand();
                //不是项级节点时
                if (m.Parent.Level != 0)
                {
                    prenode(m.Parent);
                }
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine("treeView1_AfterSelect clicked{0} selected{1}", e.Node.Text, this.treeView1.SelectedNode.Text);

            selectStaffs(treeView1.SelectedNode.Name);
            selectStroe(treeView1.SelectedNode.Name);
        }


    }
}
