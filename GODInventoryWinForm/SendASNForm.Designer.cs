namespace GODInventoryWinForm
{
    partial class SendASNForm
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
            this.msgLabel = new System.Windows.Forms.Label();
            this.processMsgLabel2 = new System.Windows.Forms.Label();
            this.okButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgLabel
            // 
            this.msgLabel.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.msgLabel.Location = new System.Drawing.Point(0, 80);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(441, 35);
            this.msgLabel.TabIndex = 11;
            this.msgLabel.Text = "Message";
            this.msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // processMsgLabel2
            // 
            this.processMsgLabel2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.processMsgLabel2.Location = new System.Drawing.Point(0, 53);
            this.processMsgLabel2.Name = "processMsgLabel2";
            this.processMsgLabel2.Size = new System.Drawing.Size(441, 19);
            this.processMsgLabel2.TabIndex = 10;
            this.processMsgLabel2.Text = "起動中";
            this.processMsgLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton1
            // 
            this.okButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.okButton1.Location = new System.Drawing.Point(167, 128);
            this.okButton1.Name = "okButton1";
            this.okButton1.Size = new System.Drawing.Size(106, 32);
            this.okButton1.TabIndex = 8;
            this.okButton1.Text = "OK";
            this.okButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ナフコEDI受信処理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SendASNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 173);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.processMsgLabel2);
            this.Controls.Add(this.okButton1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendASNForm";
            this.Text = "SendASNForm";
            this.Shown += new System.EventHandler(this.ReceiveForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Label processMsgLabel2;
        private System.Windows.Forms.Button okButton1;
        private System.Windows.Forms.Label label1;
    }
}