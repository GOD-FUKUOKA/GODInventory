using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using GODInventory.MyLinq;
namespace GODInventoryWinForm.Controls.Branches
{
    public partial class AddBranchForm : Form
    {
        public int ModelId;
        public string title;
        public int ParentId { get; set; }
        public t_branches CurrentBranch { get; set; }
       public string treeViewtx;

        public AddBranchForm()
        {
            InitializeComponent();
            CurrentBranch = new t_branches();
            ModelId = 0;
        }
        #region 保存按钮点击事件
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            bool pd = Fkpd();
            if (pd == true)
            {
                if (ModelId == 0)
                {
                    #region 添加
                    int i = insertBranches();
                    if (i > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                   


                    #endregion
                }
                else
                {
                    #region 修改

                    int i = updateComp();
                    if (i > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    #endregion
                }
            }
        }

        #endregion

        private void txt_BranchesName_TextChanged(object sender, EventArgs e)
        {

        }

        #region 非空验证判断
        private bool Fkpd() {
            this.errorProvider1.Clear();

            if ( string.IsNullOrWhiteSpace(txt_BranchesName.Text))
            {
                this.errorProvider1.SetError(txt_BranchesName, "分公司名称不许为空");
                return false;
            }

            if (  string.IsNullOrWhiteSpace(txt_address.Text))
            {
                this.errorProvider1.SetError(txt_address, "公司地址不能为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                this.errorProvider1.SetError(txt_phone, "电话不能为空");
                return false;
            }
            return true;

        }
        #endregion

        #region 添加分公司
        public int insertBranches()
        {
            int i = 0;
            try
            {
               
                using (var ctx = new GODDbContext())
                {
                    FillModel();
                          
                    ctx.t_branchs.Add(this.CurrentBranch);
                    ctx.SaveChanges();
                    i=1;
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }

            return i;
        }

        #endregion

        #region 修改公司
        private int updateComp()
        {
            int index = 0;
            try
            {
                using (var ctx = new GODDbContext())
                {
                    this.CurrentBranch = (from t_branches t in ctx.t_branchs
                                          where t.id == ModelId
                                          select t).First<t_branches>();
                    FillModel();                        
                    ctx.SaveChanges();
                    index = 1;
                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序报错！");
            }
            return index;
        }

        #endregion

        #region Addbranches窗体加载方法
        private void LoadModel() 
        {

            if (ModelId > 0)
            {
                try
                {
                    using (var ctx = new GODDbContext())
                    {

                        this.CurrentBranch = (from t_branches t in ctx.t_branchs
                                      where t.id == ModelId
                                      select t).First<t_branches>();
                        FillControls();
                        label4.Text = title;


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序出错！");
                }
            }
        }
        #endregion

        private void FillControls() {
            txt_BranchesName.Text = CurrentBranch.fullname;
            txt_address.Text = CurrentBranch.address;
            txt_phone.Text = CurrentBranch.phone;
            txt_fax.Text = CurrentBranch.fax;
            txt_MEMO.Text = CurrentBranch.memo;
        }

        private void FillModel() {

            CurrentBranch.fullname = txt_BranchesName.Text;
            CurrentBranch.parent_id = ParentId;
            CurrentBranch.address = txt_address.Text;
            CurrentBranch.fax = txt_fax.Text;
            CurrentBranch.memo = txt_MEMO.Text;
            CurrentBranch.phone = txt_phone.Text;
        
        }

        private void Addbranches_Load(object sender, EventArgs e)
        {
            LoadModel();
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
