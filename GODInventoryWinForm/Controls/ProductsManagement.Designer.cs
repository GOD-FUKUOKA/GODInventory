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
            this.components = new System.ComponentModel.Container();
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.InnerCodeTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.specTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.janCodeTextBox = new System.Windows.Forms.TextBox();
            this.instoreCodeTextBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.unitTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unitWeightTextBox11 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.moqTextBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.productNameTextBox12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // submitFormButton
            // 
            this.submitFormButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitFormButton.Location = new System.Drawing.Point(486, 275);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(100, 30);
            this.submitFormButton.TabIndex = 10000020;
            this.submitFormButton.Text = "保存";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.Location = new System.Drawing.Point(592, 275);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(100, 30);
            this.cancelFormButton.TabIndex = 10000021;
            this.cancelFormButton.Text = "キャンセル";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            this.cancelFormButton.Click += new System.EventHandler(this.cancelFormButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 11);
            this.label7.TabIndex = 10000013;
            this.label7.Text = "インストアコード";
            // 
            // InnerCodeTextBox
            // 
            this.InnerCodeTextBox.Enabled = false;
            this.InnerCodeTextBox.Location = new System.Drawing.Point(120, 31);
            this.InnerCodeTextBox.Name = "InnerCodeTextBox";
            this.InnerCodeTextBox.Size = new System.Drawing.Size(222, 18);
            this.InnerCodeTextBox.TabIndex = 31;
            this.InnerCodeTextBox.MouseLeave += new System.EventHandler(this.storeNamTextBox_MouseLeave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(389, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 11);
            this.label11.TabIndex = 27;
            this.label11.Text = "JANコード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 11);
            this.label3.TabIndex = 24;
            this.label3.Text = "ジャンル";
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(120, 97);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(222, 18);
            this.specTextBox.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(407, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 11);
            this.label9.TabIndex = 23;
            this.label9.Text = "PT入数";
            // 
            // janCodeTextBox
            // 
            this.janCodeTextBox.Location = new System.Drawing.Point(458, 130);
            this.janCodeTextBox.Name = "janCodeTextBox";
            this.janCodeTextBox.Size = new System.Drawing.Size(222, 18);
            this.janCodeTextBox.TabIndex = 28;
            // 
            // instoreCodeTextBox3
            // 
            this.instoreCodeTextBox3.Location = new System.Drawing.Point(120, 197);
            this.instoreCodeTextBox3.Name = "instoreCodeTextBox3";
            this.instoreCodeTextBox3.Size = new System.Drawing.Size(222, 18);
            this.instoreCodeTextBox3.TabIndex = 10000023;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.genreComboBox);
            this.groupBox1.Controls.Add(this.unitTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.instoreCodeTextBox3);
            this.groupBox1.Controls.Add(this.unitWeightTextBox11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.InnerCodeTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.specTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.janCodeTextBox);
            this.groupBox1.Controls.Add(this.moqTextBox8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.productCodeTextBox);
            this.groupBox1.Controls.Add(this.productNameTextBox12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.customerTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 242);
            this.groupBox1.TabIndex = 10000019;
            this.groupBox1.TabStop = false;
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(120, 64);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(222, 19);
            this.genreComboBox.TabIndex = 10000030;
            // 
            // unitTextBox1
            // 
            this.unitTextBox1.Location = new System.Drawing.Point(120, 163);
            this.unitTextBox1.Name = "unitTextBox1";
            this.unitTextBox1.Size = new System.Drawing.Size(222, 18);
            this.unitTextBox1.TabIndex = 10000027;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 11);
            this.label1.TabIndex = 10000026;
            this.label1.Text = "単位";
            // 
            // unitWeightTextBox11
            // 
            this.unitWeightTextBox11.Location = new System.Drawing.Point(458, 164);
            this.unitWeightTextBox11.Name = "unitWeightTextBox11";
            this.unitWeightTextBox11.Size = new System.Drawing.Size(222, 18);
            this.unitWeightTextBox11.TabIndex = 10000029;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 11);
            this.label8.TabIndex = 10000028;
            this.label8.Text = "単品重量";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(458, 197);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 18);
            this.textBox2.TabIndex = 10000029;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 11);
            this.label5.TabIndex = 10000028;
            this.label5.Text = "PT単位か";
            // 
            // moqTextBox8
            // 
            this.moqTextBox8.Location = new System.Drawing.Point(458, 97);
            this.moqTextBox8.Name = "moqTextBox8";
            this.moqTextBox8.Size = new System.Drawing.Size(222, 18);
            this.moqTextBox8.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 11);
            this.label10.TabIndex = 25;
            this.label10.Text = "商品コード";
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Location = new System.Drawing.Point(120, 130);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.Size = new System.Drawing.Size(222, 18);
            this.productCodeTextBox.TabIndex = 26;
            // 
            // productNameTextBox12
            // 
            this.productNameTextBox12.Location = new System.Drawing.Point(458, 64);
            this.productNameTextBox12.Name = "productNameTextBox12";
            this.productNameTextBox12.Size = new System.Drawing.Size(222, 18);
            this.productNameTextBox12.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(407, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 11);
            this.label13.TabIndex = 19;
            this.label13.Text = "商品名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 11);
            this.label4.TabIndex = 27;
            this.label4.Text = "規格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 11);
            this.label6.TabIndex = 11;
            this.label6.Text = "得意先";
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(458, 31);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(222, 18);
            this.customerTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 11);
            this.label2.TabIndex = 1;
            this.label2.Text = "自社コード";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(468, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 11);
            this.label12.TabIndex = 10000016;
            this.label12.Text = "単品重量";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ProductsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 325);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductsManagement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox InnerCodeTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox specTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox janCodeTextBox;
        private System.Windows.Forms.TextBox instoreCodeTextBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox moqTextBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.TextBox productNameTextBox12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unitTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox unitWeightTextBox11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox genreComboBox;
    }
}