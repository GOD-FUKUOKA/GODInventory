using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GODInventoryWinForm.Controls
{
    public partial class CancelConfirmForm : Form
    {
        public CancelConfirmForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
          //  startDateTimePicker

            var startAt = this.startDateTimePicker.Value.Date;

            var endAt = this.dateTimePicker1.Value.Date;

     
          

        }
    }
}
