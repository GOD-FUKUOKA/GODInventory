namespace GODInventoryWinForm
{
    partial class SelectProductForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.manualButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton2 = new System.Windows.Forms.Button();
            this.cancelButton3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(23, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 304);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(237, 53);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(462, 309);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // manualButton1
            // 
            this.manualButton1.Location = new System.Drawing.Point(406, 383);
            this.manualButton1.Name = "manualButton1";
            this.manualButton1.Size = new System.Drawing.Size(75, 21);
            this.manualButton1.TabIndex = 2;
            this.manualButton1.Text = "入力";
            this.manualButton1.UseVisualStyleBackColor = true;
            this.manualButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "ジャンル名";
            // 
            // submitButton2
            // 
            this.submitButton2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.submitButton2.Location = new System.Drawing.Point(499, 382);
            this.submitButton2.Name = "submitButton2";
            this.submitButton2.Size = new System.Drawing.Size(75, 23);
            this.submitButton2.TabIndex = 5;
            this.submitButton2.Text = "确定";
            this.submitButton2.UseVisualStyleBackColor = true;
            // 
            // cancelButton3
            // 
            this.cancelButton3.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton3.Location = new System.Drawing.Point(589, 382);
            this.cancelButton3.Name = "cancelButton3";
            this.cancelButton3.Size = new System.Drawing.Size(75, 23);
            this.cancelButton3.TabIndex = 6;
            this.cancelButton3.Text = "取消";
            this.cancelButton3.UseVisualStyleBackColor = true;
            // 
            // SelectProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 437);
            this.Controls.Add(this.cancelButton3);
            this.Controls.Add(this.submitButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manualButton1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectProductForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择商品界面";
            this.Load += new System.EventHandler(this.SelectProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button manualButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButton2;
        private System.Windows.Forms.Button cancelButton3;
    }
}