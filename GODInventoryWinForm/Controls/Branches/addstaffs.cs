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
    public partial class addstaffs : Form
    {
        
        public string title;
        public string branchid;
        public string staffsid;
        DataSet ds;
        MySqlDataAdapter adapter;
        public addstaffs()
        {
            InitializeComponent();
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
            label4.Text = title;
            //如果staffsid里面有数据的话,那么当前页就是修改页,反之就是添加页
            if (staffsid != null)
            {
                using (var ctx = new GODDbContext())
                {
                    int bid = int.Parse(staffsid);
                    var query = (from ts in ctx.t_staffs
                                 where ts.id == bid
                                 select ts).ToList();
                    foreach (t_staffs ts in query)
                    {
                        txt_StaffsName.Text = ts.fullname;
                        txt_Login.Text = ts.login;
                        txt_role.Text =ts.role;
                        txt_phone.Text = ts.phone;
                        txt_memo.Text = ts.memo;
                        txt_password.Text = ts.password;
                    }
                }
            }

        }

        #endregion

        #region 保存按钮点击事件
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            if (fkpd())
            {
                if (staffsid == null)
                {
                    if (add() > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    if (update() > 0)
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
                    int stfid = int.Parse(staffsid);
                    t_staffs ts = ctx.t_staffs.First(cts => cts.id == stfid);
                    if (ts != null)
                    {
                        ts.fullname = txt_StaffsName.Text;
                        ts.login = txt_Login.Text;
                        ts.role = txt_role.Text;
                        ts.branch_id = int.Parse(branchid);
                        ts.password = txt_password.Text;
                        ts.phone = txt_phone.Text;
                        ts.memo = txt_memo.Text;
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
                bool pd = false;
                if (txt_StaffsName.Text.Equals(string.Empty))
                {
                    MessageBox.Show("请输入员工姓名");
                }
                else 
                {
                    if (txt_Login.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("请输入Login");
                    }
                    else 
                    {
                        if (txt_role.Text.Equals(string.Empty))
                        {
                            MessageBox.Show("请输入员工职位");
                        }
                        else 
                        {
                            if (txt_phone.Text.Equals(string.Empty))
                            {
                                MessageBox.Show("请输入员工电话");
                            }
                            else 
                            {
                                if (txt_memo.Text.Equals(string.Empty))
                                {
                                    MessageBox.Show("请输入备忘录");
                                }
                                else 
                                {
                                    if (txt_password.Text.Equals(string.Empty))
                                    {
                                        MessageBox.Show("请输入员工密码");
                                    }
                                    else 
                                    {
                                        pd = true;
                                    }
                                }
                            }
                        }
                    }
                }
                return pd;
            }
        #endregion

        #region 添加
            private int add() 
            {
                int i =0 ;
                try
                {
                    using (var ctx = new GODDbContext())
                    {
                        t_staffs stf = new t_staffs();
                        stf.fullname = this.txt_StaffsName.Text;
                        stf.login = txt_Login.Text;
                        stf.role = txt_role.Text;
                        stf.branch_id = int.Parse(branchid);
                        stf.password = txt_password.Text;
                        stf.phone = txt_phone.Text;
                        stf.memo = txt_memo.Text;
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
    }
}
