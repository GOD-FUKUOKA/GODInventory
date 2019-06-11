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
    public partial class Addbranches : Form
    {
        public string updeteid;
        public string title;
        public int zgscount;
        public Addbranches()
        {
            InitializeComponent();
        }
        #region 保存按钮点击事件
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            bool pd = Fkpd();
            if (pd == true)
            {
                if (updeteid == null)
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

                    object[] parpm = { txt_BranchesName.Text, 0, txt_address.Text, txt_phone.Text, txt_fax.Text, txt_MEMO.Text };
                    int i = updateComp(parpm);
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
            if (!txt_BranchesName.Text.Equals(string.Empty))
            {
                this.errorProvider1.Clear();
                
                    this.errorProvider1.Clear();
                    if (!txt_address.Text.Equals(string.Empty))
                    {
                        this.errorProvider1.Clear();
                        if (!txt_fax.Text.Equals(string.Empty))
                        {
                            this.errorProvider1.Clear();
                            if (!txt_phone.Text.Equals(string.Empty))
                            {
                                this.errorProvider1.Clear();
                                if (!txt_MEMO.Text.Equals(string.Empty))
                                {
                                    this.errorProvider1.Clear();
                                    return true;
                                }
                                else
                                {
                                    this.errorProvider1.SetError(txt_MEMO, "说明不能为空");
                                }
                            }
                            else
                            {
                                this.errorProvider1.SetError(txt_phone, "电话不能为空");
                            }
                        }
                        else
                        {
                            this.errorProvider1.SetError(txt_fax, "传真不能为空");
                        }
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt_address, "公司地址不能为空");
                    }
              
            }
            else
            {
                this.errorProvider1.SetError(txt_BranchesName, "分公司名称不许为空");
            }
            return false;
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
                    var barnche = (from t_branches tb in ctx.t_branchs
                                   where tb.fullname == txt_BranchesName.Text && tb.parent_id == zgscount && tb.phone == txt_phone.Text && tb.address == txt_address.Text && tb.fax == txt_fax.Text && tb.memo == txt_MEMO.Text
                                   select tb).ToList();
                    if (barnche.Count  == 0)
                    {
                        t_branches bc = new t_branches();
                        bc.fullname = txt_BranchesName.Text;
                        bc.parent_id = zgscount;
                        bc.address = txt_address.Text;
                        bc.fax = txt_fax.Text;
                        bc.memo = txt_MEMO.Text;
                        bc.phone = txt_phone.Text;
                        ctx.t_branchs.Add(bc);
                        ctx.SaveChanges();
                        i=1;
                    }
                    else 
                    {
                        MessageBox.Show("该分公司已存在！");
                    }
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
        private int updateComp(Object[] parpm)
        {
            int index = 0;
            try
            {
                using (var ctx = new GODDbContext())
                {
                    int udid = int.Parse(updeteid);
                    var query = (from t_branches t in ctx.t_branchs
                                 where  t.id == udid
                                 select t).ToList();
                    if (query.Count != 0)
                    {
                        foreach (t_branches bc in query)
                        {

                            bc.fullname = txt_BranchesName.Text;
                            bc.parent_id = zgscount;
                            bc.address = txt_address.Text;
                            bc.fax = txt_fax.Text;
                            bc.memo = txt_MEMO.Text;
                            bc.phone = txt_phone.Text;
                            ctx.SaveChanges();
                            index = 1;
                        }
                    }
                    else {
                        index = 0;
                    }
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
        private void loadupdate() 
        {
            try{
                    using (var ctx = new GODDbContext())
                    {


                        if (updeteid != null)
                        {
                            int udid = int.Parse(updeteid);
                            var query = (from t_branches t in ctx.t_branchs
                                         where t.id == udid
                                         select t).ToList();
                            foreach (t_branches bc in query)
                            {
                                txt_BranchesName.Text = bc.fullname;
                                txt_address.Text = bc.address;
                                txt_phone.Text = bc.phone;
                                txt_fax.Text = bc.fax;
                                txt_MEMO.Text = bc.memo;
                            }
                            label4.Text = title;

                        }
                    }
               
            }catch(Exception ex){
                MessageBox.Show("程序出错！");
            }
        }
        #endregion
        private void Addbranches_Load(object sender, EventArgs e)
        {
            loadupdate();
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
