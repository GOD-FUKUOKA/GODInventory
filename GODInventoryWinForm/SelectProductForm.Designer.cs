﻿namespace GODInventoryWinForm
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.manualButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton2 = new System.Windows.Forms.Button();
            this.cancelButton3 = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(16, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 354);
            this.listBox1.TabIndex = 0;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(266, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(549, 359);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "品名";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "規格名";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ロット";
            // 
            // manualButton1
            // 
            this.manualButton1.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.manualButton1.Location = new System.Drawing.Point(456, 441);
            this.manualButton1.Name = "manualButton1";
            this.manualButton1.Size = new System.Drawing.Size(106, 32);
            this.manualButton1.TabIndex = 1;
            this.manualButton1.Text = "入力";
            this.manualButton1.UseVisualStyleBackColor = true;
            this.manualButton1.Visible = false;
            this.manualButton1.Click += new System.EventHandler(this.manualButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "ジャンル名";
            // 
            // submitButton2
            // 
            this.submitButton2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.submitButton2.Location = new System.Drawing.Point(568, 441);
            this.submitButton2.Name = "submitButton2";
            this.submitButton2.Size = new System.Drawing.Size(106, 32);
            this.submitButton2.TabIndex = 2;
            this.submitButton2.Text = "確定";
            this.submitButton2.UseVisualStyleBackColor = true;
            this.submitButton2.Click += new System.EventHandler(this.submitButton2_Click);
            // 
            // cancelButton3
            // 
            this.cancelButton3.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton3.Location = new System.Drawing.Point(680, 441);
            this.cancelButton3.Name = "cancelButton3";
            this.cancelButton3.Size = new System.Drawing.Size(106, 32);
            this.cancelButton3.TabIndex = 3;
            this.cancelButton3.Text = "キャンセル";
            this.cancelButton3.UseVisualStyleBackColor = true;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "自社コード";
            this.columnHeader4.Width = 80;
            // 
            // SelectProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 492);
            this.Controls.Add(this.cancelButton3);
            this.Controls.Add(this.submitButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manualButton1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectProductForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品選択";
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}