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

namespace GODInventoryWinForm.Controls
{
    public partial class CancelConfirmForm : Form
    {
        public DateTime CHUHERI;
        public DateTime NAPINRI;
        public int QtyChangeReason;

        public CancelConfirmForm()
        {
            InitializeComponent();

            this.qtyChangeReasonComboBox.ValueMember = "ID";
            this.qtyChangeReasonComboBox.DisplayMember = "FullName";
            this.qtyChangeReasonComboBox.DataSource = OrderQuantityChangeReasonRespository.ToList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
          //  startDateTimePicker

            CHUHERI = this.startDateTimePicker.Value.Date;

            NAPINRI = this.dateTimePicker1.Value.Date;

            QtyChangeReason = (int)qtyChangeReasonComboBox.SelectedValue;
            
            this.Close();

          

        }
    }
}
