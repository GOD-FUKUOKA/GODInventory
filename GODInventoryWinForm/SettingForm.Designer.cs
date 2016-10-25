namespace GODInventoryWinForm
{
    partial class SettingForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserButton1 = new System.Windows.Forms.Button();
            this.installDirTextBox = new System.Windows.Forms.TextBox();
            this.cancleButton2 = new System.Windows.Forms.Button();
            this.saveButton3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inventoryStartAtDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "NFWEのインストール場所";
            // 
            // folderBrowserButton1
            // 
            this.folderBrowserButton1.Location = new System.Drawing.Point(442, 60);
            this.folderBrowserButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.folderBrowserButton1.Name = "folderBrowserButton1";
            this.folderBrowserButton1.Size = new System.Drawing.Size(37, 27);
            this.folderBrowserButton1.TabIndex = 2;
            this.folderBrowserButton1.Text = "...";
            this.folderBrowserButton1.UseVisualStyleBackColor = true;
            this.folderBrowserButton1.Click += new System.EventHandler(this.folderBrowserButton1_Click);
            // 
            // installDirTextBox
            // 
            this.installDirTextBox.Location = new System.Drawing.Point(201, 64);
            this.installDirTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.installDirTextBox.Name = "installDirTextBox";
            this.installDirTextBox.ReadOnly = true;
            this.installDirTextBox.Size = new System.Drawing.Size(235, 21);
            this.installDirTextBox.TabIndex = 3;
            // 
            // cancleButton2
            // 
            this.cancleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancleButton2.Location = new System.Drawing.Point(373, 152);
            this.cancleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancleButton2.Name = "cancleButton2";
            this.cancleButton2.Size = new System.Drawing.Size(106, 32);
            this.cancleButton2.TabIndex = 4;
            this.cancleButton2.Text = "取消";
            this.cancleButton2.UseVisualStyleBackColor = true;
            // 
            // saveButton3
            // 
            this.saveButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton3.Location = new System.Drawing.Point(241, 152);
            this.saveButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton3.Name = "saveButton3";
            this.saveButton3.Size = new System.Drawing.Size(106, 32);
            this.saveButton3.TabIndex = 5;
            this.saveButton3.Text = "保存";
            this.saveButton3.UseVisualStyleBackColor = true;
            this.saveButton3.Click += new System.EventHandler(this.saveButton3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "在庫計上開始日";
            // 
            // inventoryStartAtDateTimePicker1
            // 
            this.inventoryStartAtDateTimePicker1.Location = new System.Drawing.Point(201, 108);
            this.inventoryStartAtDateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inventoryStartAtDateTimePicker1.Name = "inventoryStartAtDateTimePicker1";
            this.inventoryStartAtDateTimePicker1.Size = new System.Drawing.Size(278, 21);
            this.inventoryStartAtDateTimePicker1.TabIndex = 8;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 209);
            this.Controls.Add(this.inventoryStartAtDateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveButton3);
            this.Controls.Add(this.cancleButton2);
            this.Controls.Add(this.installDirTextBox);
            this.Controls.Add(this.folderBrowserButton1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button folderBrowserButton1;
        private System.Windows.Forms.TextBox installDirTextBox;
        private System.Windows.Forms.Button cancleButton2;
        private System.Windows.Forms.Button saveButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker inventoryStartAtDateTimePicker1;
    }
}