using GODInventory.MyLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    public partial class LoginForm : Form
    {
        static v_staffs currentUser = new v_staffs();

        public DialogResult dialogResult = DialogResult.None;

        public MainForm mainForm;
        public LoginForm()
        {
            InitializeComponent();
            this.mainForm = new MainForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = this.loginTextBox.Text.Trim();
            string password = this.passwordTextBox.Text.Trim();

            this.errorProvider1.Clear();
            if (!ValidateLogin()) {             
                return;
            }
            if (!ValidatePassword()) {
                return;
            }


            // 查询用户 账户，密码，所在分公司，负责的店铺
            using (GODDbContext ctx = new GODDbContext()){

                var user = (from s in ctx.t_staffs
                            join b in ctx.t_branchs on s.branch_id equals b.id
                            where s.login.Equals(login) && s.password.Equals(password)
                            select new v_staffs
                            {
                                id = s.id,
                                login = s.login,
                                fullname = s.fullname,
                                phone = s.phone,
                                role = s.role,
                                memo = s.memo,
                                password = s.password,
                                branch_id = s.branch_id,
                                branch_is_root = b.is_root,
                                branchname = b.fullname
                            }).FirstOrDefault();
                    
                    ctx.t_staffs.First(o=>( o.login.Equals(login) && o.password.Equals(password)));

                if (user != null)
                {
                    currentUser = user;
                    

                    currentUser.IsSignedIn = true;
                    currentUser.IsRootBranch = (user.branch_is_root == 1);
                    List<int> ids = null;
                    if (!currentUser.IsRootBranch)
                    {

                        ids = (from t_branches_stores o in ctx.t_branches_stores
                                    where o.branch_id == currentUser.branch_id
                                    select o.warehouse_id).ToList();
                    }
                    currentUser.WarehouseIds = ids;

                }
                else {
                    currentUser.IsSignedIn = false;

                }
            }

            // 如果登录成功
            if (currentUser.IsSignedIn)
            {
                this.dialogResult = System.Windows.Forms.DialogResult.Yes;

                mainForm.FormClosed += mainForm_FormClosed;
                mainForm.Show();
                this.Visible = false;
            }
            else { 
            
              MessageBox.Show("用户名和密码不匹配");
            }
        }

        void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            this.loginTextBox.Focus();
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
           
        }

        private bool ValidateLogin(){
            bool valid = true;
            var login = loginTextBox.Text;
            if (string.IsNullOrWhiteSpace(login))
            {
                this.errorProvider1.SetError(loginTextBox, "请输入用户名");
                valid = false;
            }
            else {
                this.errorProvider1.SetError(loginTextBox, null);            
            }
            return valid;
        }

        private bool ValidatePassword()
        {
            bool valid = true;
            var txt = passwordTextBox.Text;
            if (string.IsNullOrWhiteSpace(txt))
            {
                this.errorProvider1.SetError(passwordTextBox, "请输入登录密码");
                valid = false;
            }
            else {
                this.errorProvider1.SetError(passwordTextBox, null);
            }
            return valid;

        }

    }
}
