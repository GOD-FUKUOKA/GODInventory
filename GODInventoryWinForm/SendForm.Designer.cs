﻿namespace GODInventoryWinForm
{
    partial class SendForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.okButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(160, 116);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(49, 14);
            this.msgLabel.TabIndex = 7;
            this.msgLabel.Text = "起動中";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // okButton1
            // 
            this.okButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton1.Location = new System.Drawing.Point(245, 176);
            this.okButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton1.Name = "okButton1";
            this.okButton1.Size = new System.Drawing.Size(87, 27);
            this.okButton1.TabIndex = 0;
            this.okButton1.Text = "OK";
            this.okButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "ナフコEDI送信処理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 248);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SendForm";
            this.Text = "SendForm";
            this.Load += new System.EventHandler(this.SendForm_Load);
            this.Shown += new System.EventHandler(this.SendForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton1;
        private System.Windows.Forms.Label label1;
    }
}