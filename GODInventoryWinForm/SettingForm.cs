using GODInventory.MyLinq;
using GODInventory.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GODInventoryWinForm
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            
            this.installDirTextBox.Text = Properties.Settings.Default.NFWEInstallDir;
            this.inventoryStartAtDateTimePicker1.Value = Properties.Settings.Default.InventoryStartAt;

            // 日　月　火　水　木　金　土
            var dayEnums = (new WeekDayEnum[] { WeekDayEnum.日, WeekDayEnum.月, WeekDayEnum.火, WeekDayEnum.水, WeekDayEnum.木, WeekDayEnum.金, WeekDayEnum.土 }).Select(o => new { FullName = o.ToString(), Id = (int)o }).ToList();
            this.weekEndDayComboBox.DisplayMember = "FullName";
            this.weekEndDayComboBox.ValueMember = "Id";
            this.weekEndDayComboBox.DataSource = dayEnums;

            this.weekEndDayComboBox.SelectedIndex = CustomPropertyHelper.GetOrderWeekEndDay();
        }

        private void saveButton3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NFWEInstallDir = this.installDirTextBox.Text;
            Properties.Settings.Default.InventoryStartAt = this.inventoryStartAtDateTimePicker1.Value;
            CustomPropertyHelper.SetOrderWeekEndDay( (int)this.weekEndDayComboBox.SelectedValue );
        }

        private void folderBrowserButton1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.installDirTextBox.Text = this.folderBrowserDialog1.SelectedPath; 
            };
        }
    }
}
