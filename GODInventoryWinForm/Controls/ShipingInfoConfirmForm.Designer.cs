namespace GODInventoryWinForm.Controls
{
    partial class ShipingInfoConfirmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productShippedAtDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.productReceivedAtDateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.orderCountTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shipping Information Confirm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "出荷日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "納品日";
            // 
            // productShippedAtDateTimePicker1
            // 
            this.productShippedAtDateTimePicker1.Location = new System.Drawing.Point(202, 129);
            this.productShippedAtDateTimePicker1.Name = "productShippedAtDateTimePicker1";
            this.productShippedAtDateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.productShippedAtDateTimePicker1.TabIndex = 3;
            // 
            // productReceivedAtDateTimePicker2
            // 
            this.productReceivedAtDateTimePicker2.Location = new System.Drawing.Point(202, 168);
            this.productReceivedAtDateTimePicker2.Name = "productReceivedAtDateTimePicker2";
            this.productReceivedAtDateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.productReceivedAtDateTimePicker2.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(237, 235);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 25);
            this.submitButton.TabIndex = 7;
            this.submitButton.Text = "提出";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(327, 235);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SelectedOrders";
            // 
            // orderCountTextBox
            // 
            this.orderCountTextBox.Location = new System.Drawing.Point(202, 90);
            this.orderCountTextBox.Name = "orderCountTextBox";
            this.orderCountTextBox.ReadOnly = true;
            this.orderCountTextBox.Size = new System.Drawing.Size(200, 20);
            this.orderCountTextBox.TabIndex = 10;
            // 
            // ShipingInfoConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 287);
            this.Controls.Add(this.orderCountTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.productReceivedAtDateTimePicker2);
            this.Controls.Add(this.productShippedAtDateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShipingInfoConfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShipingInfoConfirmForm";
            this.Load += new System.EventHandler(this.ShipingInfoConfirmForm_Load);
            this.Shown += new System.EventHandler(this.ShipingInfoConfirmForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker productShippedAtDateTimePicker1;
        private System.Windows.Forms.DateTimePicker productReceivedAtDateTimePicker2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox orderCountTextBox;
    }
}