using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    public partial class ErrorDialog : Form
    {
        public DialogResult ErrorDialogResult { get; set; }
        public int OrderCount { get; set; }
        public int ImportedCount { get; set; }
        public string DataFilePath { get; set; }

        public ErrorDialog()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
            this.DataFilePath = string.Empty;

        }

        private void yesButton1_Click(object sender, EventArgs e)
        {
            ErrorDialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            ErrorDialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void ErrorDialog_Load(object sender, EventArgs e)
        {
            this.orderCountlabel.Text = this.OrderCount.ToString();
            this.importedOrderLabel.Text = this.ImportedCount.ToString();

            if (File.Exists(DataFilePath)) {

                this.updatedAtLabel.Text = File.GetLastWriteTime(DataFilePath).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
