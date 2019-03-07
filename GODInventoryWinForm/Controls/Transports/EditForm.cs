using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GODInventory.MyLinq;

namespace GODInventoryWinForm.Controls.Transports
{
    public partial class EditForm : Form
    {
        public int tid;
        public t_transports transport;
        public List<t_transports> transportList;
        public DialogResult dialogResult;

        public EditForm()
        {
            this.transport = null;
            InitializeComponent();
        }

        public void InitializeData()
        {

            //using (var ctx = new GODDbContext())
            //{
            //    this.transportList = ctx.t_transports.ToList();
            //    this.transport = this.transportList.Find(c => c.id == this.tid);
            //    //this.transport = ctx.t_transports.First(c => c.id == this.tid);
            //}

            if (transport == null)
            {
                throw new Exception("can not find transport to edit");
            }

            this.fullNameTextBox.Text = transport.fullname;
            this.shortNameTextBox.Text = transport.shortname;
            this.addressTextBox.Text = transport.address;
            this.phoneTextBox.Text = transport.phone;
            this.faxTextBox.Text = transport.fax;
            this.memoTextBox.Text = transport.memo;

        }

        private void submitFormButton_Click(object sender, EventArgs e)
        {
            //保存之前需要检验属性是否正确
            if (!validateAttributes())
            {
                return;
            }
            using (var ctx = new GODDbContext())
            {
                var model = BuildModelFromControl();

                ctx.t_transports.Attach(model);
                //transport.fullname = this.fullNameTextBox.Text.Trim();
                //transport.shortname = this.shortNameTextBox.Text.Trim();
                //transport.address = this.addressTextBox.Text.Trim();
                //transport.phone = this.phoneTextBox.Text.Trim();
                //transport.fax = this.faxTextBox.Text.Trim();
                //transport.memo = this.memoTextBox.Text.Trim();

                ctx.Entry(model).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            this.dialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }


        private void fullNameTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text.Trim().Length > 0)
            {

                if (fullNameTextBox.Text.Length > 0)
                {
                    var otherWithSameName = this.transportList.Find(m => (m.fullname == fullNameTextBox.Text && m.id != transport.id));
                    if (otherWithSameName != null)
                    {
                        errorProvider1.SetError(fullNameTextBox, "已存在");
                    }
                    else
                    {
                        errorProvider1.SetError(fullNameTextBox, String.Empty);
                    }
                }
                else
                {
                    errorProvider1.SetError(fullNameTextBox, String.Format("运输公司登録されていません", fullNameTextBox.Text));
                }
            }
        }


        private void EditForm_Shown(object sender, EventArgs e)
        {
            this.InitializeData();
        }


        private t_transports BuildModelFromControl()
        {
            var model = new t_transports();
            model.id = transport.id;
            model.fullname = this.fullNameTextBox.Text.Trim();
            model.shortname = this.shortNameTextBox.Text.Trim();
            model.address = this.addressTextBox.Text.Trim();
            model.phone = this.phoneTextBox.Text.Trim();
            model.fax = this.faxTextBox.Text.Trim();
            model.memo = this.memoTextBox.Text.Trim();

            return model;
        }

        /// <summary>
        /// 检查属性格式是否正确
        /// </summary>
        /// <param name="attributeNames">数组，需要验证的属性</param>
        /// <returns></returns>

        private bool validateAttributes(string[] selectedAttributeNames = null)
        {
            var model = BuildModelFromControl();
            string msg = String.Empty;
            var validated = true;
            string[] attributeNames = selectedAttributeNames;
            if (attributeNames == null)
            {
                attributeNames = new string[] { "fullname", "shortname" };
            }
            foreach (var name in attributeNames)
            {
                if (name == "fullname")
                {
                    msg = String.Empty;
                    var otherWithSameName = this.transportList.Find(m => (m.fullname == model.fullname && m.id != model.id));
                    if (otherWithSameName != null)
                    {
                        msg = "已存在";
                    }

                    if (model.fullname.Length == 0 || model.fullname.Length > 128)
                    {
                        msg = "全称长度在1-128之间。";
                    }
                    if (msg != String.Empty)
                    {
                        validated = false;
                    }
                    errorProvider1.SetError(fullNameTextBox, msg);
                }
                if (name == "shortname")
                {
                    msg = String.Empty;
                    var otherWithSameName = this.transportList.Find(m => (m.shortname == model.shortname && m.id != model.id));
                    if (otherWithSameName != null)
                    {
                        msg = "已存在";
                    }
                    if (model.shortname.Length == 0 || model.shortname.Length > 24)
                    {
                        msg = "全称长度在1-24之间。";
                    }
                    if (msg != String.Empty)
                    {
                        validated = false;
                    }
                    errorProvider1.SetError(shortNameTextBox, msg);
                }
            }

            return validated;
        }
    }
}
