namespace GODInventoryWinForm.Controls
{
    partial class ProductsManagement
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
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.storeNamTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderReceivedAtTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.productKanjiSpecificationTextBox = new System.Windows.Forms.TextBox();
            this.productReceivedAtTextBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.productKanjiNameTextBox = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.invoiceNOTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.unitWeightTextBox11 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitFormButton
            // 
            this.submitFormButton.Location = new System.Drawing.Point(486, 300);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(100, 32);
            this.submitFormButton.TabIndex = 10000020;
            this.submitFormButton.Text = "Submit";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.Location = new System.Drawing.Point(592, 300);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(100, 32);
            this.cancelFormButton.TabIndex = 10000021;
            this.cancelFormButton.Text = "Cancel";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            this.cancelFormButton.Click += new System.EventHandler(this.cancelFormButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 10000013;
            this.label7.Text = "インストアコード";
            // 
            // storeNamTextBox
            // 
            this.storeNamTextBox.Enabled = false;
            this.storeNamTextBox.Location = new System.Drawing.Point(120, 34);
            this.storeNamTextBox.Name = "storeNamTextBox";
            this.storeNamTextBox.Size = new System.Drawing.Size(222, 21);
            this.storeNamTextBox.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(389, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "JANコード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "ジャンル";
            // 
            // orderReceivedAtTextBox
            // 
            this.orderReceivedAtTextBox.Location = new System.Drawing.Point(120, 106);
            this.orderReceivedAtTextBox.Name = "orderReceivedAtTextBox";
            this.orderReceivedAtTextBox.Size = new System.Drawing.Size(222, 21);
            this.orderReceivedAtTextBox.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(407, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "PT入数";
            // 
            // productKanjiSpecificationTextBox
            // 
            this.productKanjiSpecificationTextBox.Location = new System.Drawing.Point(458, 142);
            this.productKanjiSpecificationTextBox.Name = "productKanjiSpecificationTextBox";
            this.productKanjiSpecificationTextBox.Size = new System.Drawing.Size(222, 21);
            this.productKanjiSpecificationTextBox.TabIndex = 28;
            // 
            // productReceivedAtTextBox3
            // 
            this.productReceivedAtTextBox3.Location = new System.Drawing.Point(120, 215);
            this.productReceivedAtTextBox3.Name = "productReceivedAtTextBox3";
            this.productReceivedAtTextBox3.Size = new System.Drawing.Size(222, 21);
            this.productReceivedAtTextBox3.TabIndex = 10000023;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.productReceivedAtTextBox3);
            this.groupBox1.Controls.Add(this.unitWeightTextBox11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.storeNamTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.orderReceivedAtTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.productKanjiSpecificationTextBox);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.productKanjiNameTextBox);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.storeCodeTextBox);
            this.groupBox1.Controls.Add(this.invoiceNOTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 264);
            this.groupBox1.TabIndex = 10000019;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 21);
            this.textBox1.TabIndex = 10000027;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10000026;
            this.label1.Text = "単位";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(458, 215);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 21);
            this.textBox2.TabIndex = 10000029;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10000028;
            this.label5.Text = "PT単位か";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(458, 106);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(222, 21);
            this.textBox8.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "商品コード";
            // 
            // productKanjiNameTextBox
            // 
            this.productKanjiNameTextBox.Location = new System.Drawing.Point(120, 142);
            this.productKanjiNameTextBox.Name = "productKanjiNameTextBox";
            this.productKanjiNameTextBox.Size = new System.Drawing.Size(222, 21);
            this.productKanjiNameTextBox.TabIndex = 26;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(458, 70);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(222, 21);
            this.textBox12.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(407, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "商品名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "規格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "得意先";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(458, 34);
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(222, 21);
            this.storeCodeTextBox.TabIndex = 12;
            // 
            // invoiceNOTextBox
            // 
            this.invoiceNOTextBox.Location = new System.Drawing.Point(120, 70);
            this.invoiceNOTextBox.Name = "invoiceNOTextBox";
            this.invoiceNOTextBox.Size = new System.Drawing.Size(222, 21);
            this.invoiceNOTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "自社コード";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(468, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 10000016;
            this.label12.Text = "単品重量";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10000028;
            this.label8.Text = "単品重量";
            // 
            // unitWeightTextBox11
            // 
            this.unitWeightTextBox11.Location = new System.Drawing.Point(458, 179);
            this.unitWeightTextBox11.Name = "unitWeightTextBox11";
            this.unitWeightTextBox11.Size = new System.Drawing.Size(222, 21);
            this.unitWeightTextBox11.TabIndex = 10000029;
            // 
            // ProductsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 354);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductsManagement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox storeNamTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox orderReceivedAtTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox productKanjiSpecificationTextBox;
        private System.Windows.Forms.TextBox productReceivedAtTextBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox productKanjiNameTextBox;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.TextBox invoiceNOTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox unitWeightTextBox11;
        private System.Windows.Forms.Label label8;
    }
}