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
        public AddStore()
        {
            InitializeComponent();
        }
      
        private void txt_StaffsName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void AddStore_Load(object sender, EventArgs e)
        {
            try
            {
                selectAllxb();
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序有误");
            }
            label4.Text = title;

        }
       

        #region 添加店铺方法
        private int add(List<string> no) 
        {
            int index = 0;
             using (var ctx = new GODDbContext())
            {
                 int cpid = int.Parse(compid);
                 for (int i = 0; i < no.Count; i++)
                 {
                     int noid = int.Parse(no[i]);
                     var query = (from t_branches_stores ttbs in ctx.t_branches_stores
                                  where ttbs.branch_id == cpid && ttbs.store_id == noid
                                  select ttbs).ToList();
                     if (query.Count == 0)
                     {
                         t_branches_stores tbs = new t_branches_stores();
                         tbs.branch_id = cpid;
                         tbs.store_id = noid;
                         ctx.t_branches_stores.Add(tbs);
                         ctx.SaveChanges();
                         index = 1;
                     }
                     else
                     {
                         MessageBox.Show("您选择的店铺有重复！");
                         index = 0;
                         break;
                     }
                 }
            }
            return index;
        }
        #endregion

        #region 查找所有县别
        private void selectAllxb() 
        {
            using(var ctx = new GODDbContext())
            {
              var shopxb = ctx.t_shoplist.Select(t => t.県別).Distinct().ToList();
              comboBox1.ValueMember = "県別";
              comboBox1.DisplayMember = "県別";
              comboBox1.DataSource = shopxb;
            }
            
        }
        #endregion


        #region 查找所有区域
        private void selectAllqy(string name)
        {
            using (var ctx = new GODDbContext())
            {
                var query = (from t_shoplist ts in ctx.t_shoplist
                             where ts.県別 == name
                             select ts).ToList();
                var shopxb = query.Select(t => t.県内エリア).Distinct().ToList();
                comboBox2.ValueMember = "県内エリア";
                comboBox2.DisplayMember = "県内エリア";
                comboBox2.DataSource = shopxb;
            }

        }
        #endregion
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(string.Empty))
            {
                selectAllqy(comboBox1.Text);
            }
            else 
            {
                MessageBox.Show("请选择県別");
            }
        }
        #region 检索点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                selectWhere();
            }
            catch (Exception ex)
            {
            
            }
        }
        #endregion
        #region 检索方法
        private void selectWhere() 
        {
            using(var ctx = new GODDbContext())
            {
                dataGridView1.AutoGenerateColumns = false;
                if (comboBox2.Text.Equals(string.Empty))
                {
                    var query = (from t_shoplist ts in ctx.t_shoplist
                                 where ts.県別 == comboBox1.Text
                                 select ts).ToList();
                    dataGridView1.DataSource = query;
                }
                else
                {
                    var query = (from t_shoplist ts in ctx.t_shoplist
                                 where ts.県別 == comboBox1.Text && ts.県内エリア == comboBox2.Text
                                 select ts).ToList();
                    dataGridView1.DataSource = query;
                }
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region 保存按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> no = new List<string>();
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkcell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean pd = Convert.ToBoolean(checkcell.Value);
                    if (pd == true)
                    {
                        no.Add(dataGridView1.Rows[i].Cells["店番"].Value.ToString());
                    }
                }
                if (add(no)!=0) 
                {
                    MessageBox.Show("添加成功");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("程序有误");
            }
            
        }

        #endregion


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }



    }
}
