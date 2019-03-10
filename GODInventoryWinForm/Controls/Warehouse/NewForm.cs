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

namespace GODInventoryWinForm.Controls.Warehouse
{
    public partial class NewForm : Form
    {
        public t_warehouses warehouses;
        public List<t_warehouses> warehousesList;
        public DialogResult dialogResult;

        public NewForm()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {


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
                var warehouses = BuildModelFromControl();

                ctx.t_warehouses.Add(warehouses);
                ctx.SaveChanges();

            }
            this.dialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void fullNameTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text.Trim().Length > 0)
            {

                if (fullNameTextBox.Text.Length > 0)
                {
                    var otherWithSameName = this.warehousesList.Find(m => (m.FullName == fullNameTextBox.Text));
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
                    errorProvider1.SetError(fullNameTextBox, String.Format("仓库登録されていません", fullNameTextBox.Text));
                }
            }
        }

        private t_warehouses BuildModelFromControl()
        {
            var model = new t_warehouses();
            model.FullName = this.fullNameTextBox.Text.Trim();
            model.ShortName = this.shortNameTextBox.Text.Trim();
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
            string msg =  String.Empty;
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
                    var otherWithSameName = this.warehousesList.Find(m => (m.FullName == model.FullName && m.Id != model.Id));
                    if (otherWithSameName != null)
                    {
                        msg = "已存在";
                    }

                    if (model.FullName.Length == 0 || model.FullName.Length > 128)
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
                    var otherWithSameName = this.warehousesList.Find(m => (m.ShortName == model.ShortName && m.Id != model.Id));
                    if (otherWithSameName != null)
                    {
                        msg = "已存在";
                    }
                    if (model.ShortName.Length == 0 || model.ShortName.Length > 24)
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

        private void cancelFormButton_Click(object sender, EventArgs e)
        {

        }

    
    }
}
