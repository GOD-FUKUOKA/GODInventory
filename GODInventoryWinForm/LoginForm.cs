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

            // 查询用户 账户，密码，所在分公司，负责的店铺
            using (GODDbContext ctx = new GODDbContext()){

                var user = ctx.t_staffs.First(o=>( o.login.Equals(login) && o.password.Equals(password)));

                currentUser.IsSignedIn = true;
                var branch = ctx.t_branchs.Find(currentUser.branch_id);
                currentUser.IsRootBranch = (branch.parent_id == 0);
                List<int> storeIds = null;
                if (!currentUser.IsRootBranch)
                {

                    storeIds = (from t_branches_stores o in ctx.t_branches_stores
                                where o.branch_id == currentUser.branch_id
                                select o.store_id).ToList();
                }
                currentUser.BranchStoreIds = storeIds;
            }

            // 如果登录成功
            if (currentUser.IsSignedIn)
            {
                this.dialogResult = System.Windows.Forms.DialogResult.Yes;
                mainForm.Show();
                this.Visible = false;
            }
        }
    }
}
