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
    public partial class Create_Transports : Form
    {
        public int wid;
        public int tid;

        public Create_Transports()
        {
            InitializeComponent();
           
        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new GODDbContext())
            {
                if (fullNameTextBox12.Text.Length > 0)
                {
                    //  t_transports FINDitem = ctx.t_transports.Find(fullNameTextBox12.Text.Trim());

                    var List = (from t_transports o in ctx.t_transports
                                where fullNameTextBox12.Text == o.fullname
                                select o).ToList();
                    if (List.Count == 0)
                    {
                        t_transports item = new t_transports();
                        item.fullname = this.fullNameTextBox12.Text.Trim();
                        item.shortname = this.shortNameTextBox12.Text.Trim();

                        ctx.t_transports.Add(item);
                        ctx.SaveChanges();

                          List = (from t_transports o in ctx.t_transports
                                    where fullNameTextBox12.Text == o.fullname
                                    select o).ToList();
                          tid = List[0].id;

                        //ModelCallback.AfterProductCreated(item);
                        MessageBox.Show(String.Format("运输公司登録完了!"));
                    }
                    else
                    {
                        MessageBox.Show(String.Format("无法添加，运输公司已存在!"));

                    }
                }
            }
        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }
    }
}
