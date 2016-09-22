﻿namespace GODInventoryWinForm.Controls
{
    partial class EditOrderForm2
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
            this.components = new System.ComponentModel.Container();
            this.orderIDTextBox = new System.Windows.Forms.TextBox();
            this.shipperComboBox3 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.orderQuantityTextBox11 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shipAtTextBox = new System.Windows.Forms.TextBox();
            this.storeNamTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderAtTextBox = new System.Windows.Forms.TextBox();
            this.productKanjiSpecificationTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.productKanjiNameTextBox = new System.Windows.Forms.TextBox();
            this.countyTextBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.invoiceNOTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderIDTextBox
            // 
            this.orderIDTextBox.Location = new System.Drawing.Point(23, 282);
            this.orderIDTextBox.Name = "orderIDTextBox";
            this.orderIDTextBox.Size = new System.Drawing.Size(100, 21);
            this.orderIDTextBox.TabIndex = 10000012;
            this.orderIDTextBox.TabStop = false;
            this.orderIDTextBox.Text = "orderid";
            this.orderIDTextBox.Visible = false;
            // 
            // shipperComboBox3
            // 
            this.shipperComboBox3.FormattingEnabled = true;
            this.shipperComboBox3.Items.AddRange(new object[] {
            "丸健",
            "MKL",
            "マツモト産業"});
            this.shipperComboBox3.Location = new System.Drawing.Point(111, 190);
            this.shipperComboBox3.Name = "shipperComboBox3";
            this.shipperComboBox3.Size = new System.Drawing.Size(166, 20);
            this.shipperComboBox3.TabIndex = 10000009;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(340, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 10000003;
            this.label12.Text = "実際出荷数量";
            // 
            // orderQuantityTextBox11
            // 
            this.orderQuantityTextBox11.Location = new System.Drawing.Point(433, 190);
            this.orderQuantityTextBox11.Name = "orderQuantityTextBox11";
            this.orderQuantityTextBox11.Size = new System.Drawing.Size(166, 21);
            this.orderQuantityTextBox11.TabIndex = 10000005;
            this.orderQuantityTextBox11.TextChanged += new System.EventHandler(this.orderQuantityTextBox11_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 10000004;
            this.label8.Text = "実際配送担当";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10000002;
            this.label5.Text = "出荷日";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shipperComboBox3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.shipAtTextBox);
            this.groupBox1.Controls.Add(this.orderQuantityTextBox11);
            this.groupBox1.Controls.Add(this.storeNamTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.orderAtTextBox);
            this.groupBox1.Controls.Add(this.productKanjiSpecificationTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.productKanjiNameTextBox);
            this.groupBox1.Controls.Add(this.countyTextBox1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.storeCodeTextBox);
            this.groupBox1.Controls.Add(this.invoiceNOTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 241);
            this.groupBox1.TabIndex = 10000006;
            this.groupBox1.TabStop = false;
            // 
            // shipAtTextBox
            // 
            this.shipAtTextBox.Location = new System.Drawing.Point(433, 38);
            this.shipAtTextBox.Name = "shipAtTextBox";
            this.shipAtTextBox.ReadOnly = true;
            this.shipAtTextBox.Size = new System.Drawing.Size(166, 21);
            this.shipAtTextBox.TabIndex = 10000013;
            this.shipAtTextBox.TextChanged += new System.EventHandler(this.shipAtTextBox_TextChanged);
            // 
            // storeNamTextBox
            // 
            this.storeNamTextBox.Location = new System.Drawing.Point(111, 76);
            this.storeNamTextBox.Name = "storeNamTextBox";
            this.storeNamTextBox.ReadOnly = true;
            this.storeNamTextBox.Size = new System.Drawing.Size(166, 21);
            this.storeNamTextBox.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "規格名漢字";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "伝票番号";
            // 
            // orderAtTextBox
            // 
            this.orderAtTextBox.Location = new System.Drawing.Point(111, 38);
            this.orderAtTextBox.Name = "orderAtTextBox";
            this.orderAtTextBox.ReadOnly = true;
            this.orderAtTextBox.Size = new System.Drawing.Size(166, 21);
            this.orderAtTextBox.TabIndex = 28;
            // 
            // productKanjiSpecificationTextBox
            // 
            this.productKanjiSpecificationTextBox.Location = new System.Drawing.Point(433, 149);
            this.productKanjiSpecificationTextBox.Name = "productKanjiSpecificationTextBox";
            this.productKanjiSpecificationTextBox.ReadOnly = true;
            this.productKanjiSpecificationTextBox.Size = new System.Drawing.Size(166, 21);
            this.productKanjiSpecificationTextBox.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "品名漢字";
            // 
            // productKanjiNameTextBox
            // 
            this.productKanjiNameTextBox.Location = new System.Drawing.Point(111, 149);
            this.productKanjiNameTextBox.Name = "productKanjiNameTextBox";
            this.productKanjiNameTextBox.ReadOnly = true;
            this.productKanjiNameTextBox.Size = new System.Drawing.Size(166, 21);
            this.productKanjiNameTextBox.TabIndex = 26;
            // 
            // countyTextBox1
            // 
            this.countyTextBox1.Location = new System.Drawing.Point(433, 114);
            this.countyTextBox1.Name = "countyTextBox1";
            this.countyTextBox1.ReadOnly = true;
            this.countyTextBox1.Size = new System.Drawing.Size(166, 21);
            this.countyTextBox1.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(388, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "県別";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "受注日";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "店舗コード";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(433, 76);
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.ReadOnly = true;
            this.storeCodeTextBox.Size = new System.Drawing.Size(166, 21);
            this.storeCodeTextBox.TabIndex = 12;
            // 
            // invoiceNOTextBox
            // 
            this.invoiceNOTextBox.Location = new System.Drawing.Point(111, 114);
            this.invoiceNOTextBox.Name = "invoiceNOTextBox";
            this.invoiceNOTextBox.ReadOnly = true;
            this.invoiceNOTextBox.Size = new System.Drawing.Size(166, 21);
            this.invoiceNOTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "店名";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 21);
            this.textBox1.TabIndex = 10000001;
            // 
            // submitFormButton
            // 
            this.submitFormButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitFormButton.Location = new System.Drawing.Point(451, 275);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(100, 32);
            this.submitFormButton.TabIndex = 10000007;
            this.submitFormButton.Text = "Submit";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelFormButton.Location = new System.Drawing.Point(557, 275);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(100, 32);
            this.cancelFormButton.TabIndex = 10000008;
            this.cancelFormButton.Text = "Cancel";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // EditOrderForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 337);
            this.Controls.Add(this.orderIDTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOrderForm2";
            this.Text = "EditOrderForm2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox orderIDTextBox;
        private System.Windows.Forms.ComboBox shipperComboBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox orderQuantityTextBox11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox storeNamTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox orderAtTextBox;
        private System.Windows.Forms.TextBox productKanjiSpecificationTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox productKanjiNameTextBox;
        private System.Windows.Forms.TextBox countyTextBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.TextBox invoiceNOTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private System.Windows.Forms.TextBox shipAtTextBox;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
    }
}