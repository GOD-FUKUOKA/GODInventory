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
    public partial class AddStore : Form
    {
        public string title;
        public string compid;
        protected string storeid;
        public AddStore()
        {
            InitializeComponent();
        }
        #region text输入时的臭循环
        private void selectshoplist()
        {
            try
            {
                using (var cxt  = new GODDbContext())
                {
                    var query = (from t_shoplist tsl in cxt.t_shoplist
                                 where tsl.店名.Contains(txt_StoreName.Text)
                                 select tsl).ToList();
                    listBox1.DataSource = query;
                    listBox1.DisplayMember = "店名";
                    listBox1.ValueMember = "店番";
                    listBox1.Visible = true;
                 
                    
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("程序有误！");
            }
            
        }
        #endregion
        private void txt_StaffsName_TextChanged(object sender, EventArgs e)
        {
            selectshoplist();
        }

        private void AddStore_Load(object sender, EventArgs e)
        {
            label4.Text = title;
        }
        #region 保存按钮点击事件
        private void submitFormButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txt_StoreName.Text.Equals(string.Empty))
                {
                    if (add() > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                

                }
                else 
                {
                    MessageBox.Show("请选择店铺！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误！");
            }
        }

        #endregion

        #region 添加店铺方法
        private int add() 
        {
            int index = 0;
             using (var ctx = new GODDbContext())
            {
                 int cpid = int.Parse(compid);
                 int stid = int.Parse(storeid);
                 var query = (from t_branches_stores ttbs in ctx.t_branches_stores
                              where ttbs.branch_id == cpid && ttbs.store_id == stid
                              select ttbs).ToList();
                 if (query.Count == 0)
                 {
                     t_branches_stores tbs = new t_branches_stores();
                     tbs.branch_id = cpid;
                     tbs.store_id = stid;
                     ctx.t_branches_stores.Add(tbs);
                     ctx.SaveChanges();
                     index = 1;
                 }
                 else 
                 {
                     index = 0;
                 }
            }
            return index;
        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region listbox点击事件
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //如果点击listbox之后将点击的事件赋值到textbox里
            storeid = listBox1.SelectedValue.ToString();
            txt_StoreName.Text = listBox1.Text;
            listBox1.Visible = false;

        }

        #endregion

        private void AddStore_MouseClick(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
