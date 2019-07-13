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
    public partial class AddStaffForm : Form
    {

        public string title;
        public List<v_staffs> StaffList;
        public t_staffs CurrentStaff { get; set; }
        public t_branches CurrentBranch { get; set; }
        public bool isUpdate;


        public AddStaffForm()
        {
            this.CurrentStaff = new t_staffs();
            this.StaffList = null;
            this.isUpdate = false;
            InitializeComponent();
            InitializeData();

        }


        private void InitializeData()
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region 窗体加载事件
        private void addstaffs_Load(object sender, EventArgs e)
        {
            isUpdate = CurrentStaff.id > 0;

            label4.Text = title;
            List<string> roles = new List<string> { "sale" };

            if (this.CurrentBranch.is_root == 1)
            {
                roles = new List<string> { "sale", "office" };
            }
            this.roleComboBox1.DataSource = roles;

            //如果staffsid里面有数据的话,那么当前页就是修改页,反之就是添加页
            if (this.isUpdate)
            {
                txt_StaffsName.Text = CurrentStaff.fullname;
                txt_Login.Text = CurrentStaff.login;
                txt_password.Text = CurrentStaff.password;
                txtPhone.Text = CurrentStaff.phone;
                txtMemo.Text = CurrentStaff.memo;
                roleComboBox1.Text = CurrentStaff.role;                 
            }


        }

        #endregion

        #region 保存按钮点击事件
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            if (fkpd())
            {
                if (this.isUpdate)
                {
                    if (update() > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                   
                }
                else
                {
                    if (add() > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
            }
        }

        #endregion

        #region 修改
        private int update()
        {
            int index = 0;
            try
            {
                using (var ctx = new GODDbContext())
                {
                    t_staffs ts = ctx.t_staffs.First(cts => cts.id == CurrentStaff.id);
                    if (ts != null)
                    {
                        ts.fullname = txt_StaffsName.Text;
                        ts.login = txt_Login.Text;
                        ts.role = roleComboBox1.Text;
                        ts.password = txt_password.Text;
                        ts.phone = txtPhone.Text;
                        ts.memo = txtMemo.Text;
                        ctx.SaveChanges();
                        index = 1;
                    }
                    else
                    {
                        index = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误！");
            }
            return index;
        }
        #endregion

        #region 非空判断
        private bool fkpd()
        {
            this.errorProvider1.Clear();
            bool pd = false;
            if (txt_StaffsName.Text.Equals(string.Empty))
            {

                this.errorProvider1.SetError(txt_StaffsName, "请输入员工姓名");
            }
            else
            {
                if (txt_Login.Text.Equals(string.Empty))
                {

                    this.errorProvider1.SetError(txt_Login, "请输入Login");
                }
                else
                {
                    
                    if (txt_password.Text.Equals(string.Empty))
                    {

                        this.errorProvider1.SetError(txt_password, "请输入员工密码");
                    }
                    else
                    {
                        pd = true;
                    }
                }
            }
            return pd;
        }
        #endregion

        #region 添加
        private int add()
        {
            int i = 0;
            try
            {
                using (var ctx = new GODDbContext())
                {
                    t_staffs stf = new t_staffs();
                    stf.fullname = this.txt_StaffsName.Text;
                    stf.login = txt_Login.Text;
                    stf.role = roleComboBox1.Text;
                    stf.branch_id = CurrentBranch.id;
                    stf.password = txt_password.Text;
                    ctx.t_staffs.Add(stf);
                    ctx.SaveChanges();
                    i = 1;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误！");
            }
            return i;
        }
        #endregion

        private void txt_Login_TextChanged(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            var login = txt_Login.Text;
            if (!string.IsNullOrWhiteSpace(login))
            {
                var existSameStaff = StaffList.Exists(o => o.login == login && o.id != CurrentStaff.id);
                if (existSameStaff)
                {                
                    this.errorProvider1.SetError(txt_Login, "登录名已存在");
                }
            }
            
        }


    }
}
