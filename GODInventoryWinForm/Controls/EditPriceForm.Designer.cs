namespace GODInventoryWinForm.Controls
{
    partial class EditPriceForm
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
            this.priceIdTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.promotePriceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.storeCountyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.adPriceTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.storeComboNameTextBox = new System.Windows.Forms.TextBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.salePriceTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productSpecTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // priceIdTextBox
            // 
            this.priceIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.priceIdTextBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.priceIdTextBox.Location = new System.Drawing.Point(23, 309);
            this.priceIdTextBox.Name = "priceIdTextBox";
            this.priceIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.priceIdTextBox.TabIndex = 10000012;
            this.priceIdTextBox.TabStop = false;
            this.priceIdTextBox.Text = "orderid";
            this.priceIdTextBox.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(343, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 10000003;
            this.label12.Text = "特売原単価";
            // 
            // promotePriceTextBox
            // 
            this.promotePriceTextBox.Location = new System.Drawing.Point(426, 218);
            this.promotePriceTextBox.Name = "promotePriceTextBox";
            this.promotePriceTextBox.Size = new System.Drawing.Size(190, 21);
            this.promotePriceTextBox.TabIndex = 1;
            this.promotePriceTextBox.TextChanged += new System.EventHandler(this.orderQuantityTextBox11_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 10000002;
            this.label5.Text = "店名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.costTextBox);
            this.groupBox1.Controls.Add(this.storeCountyTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.adPriceTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.storeComboNameTextBox);
            this.groupBox1.Controls.Add(this.promotePriceTextBox);
            this.groupBox1.Controls.Add(this.productNameTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.productCodeTextBox);
            this.groupBox1.Controls.Add(this.salePriceTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.priceTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.productSpecTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(23, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 262);
            this.groupBox1.TabIndex = 10000006;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 10000022;
            this.label6.Text = "仕入原価";
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(109, 152);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(190, 21);
            this.costTextBox.TabIndex = 10000023;
            // 
            // storeCountyTextBox
            // 
            this.storeCountyTextBox.Location = new System.Drawing.Point(426, 62);
            this.storeCountyTextBox.Name = "storeCountyTextBox";
            this.storeCountyTextBox.ReadOnly = true;
            this.storeCountyTextBox.Size = new System.Drawing.Size(190, 21);
            this.storeCountyTextBox.TabIndex = 10000021;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 10000020;
            this.label1.Text = "県別";
            // 
            // adPriceTextBox
            // 
            this.adPriceTextBox.Location = new System.Drawing.Point(109, 218);
            this.adPriceTextBox.Name = "adPriceTextBox";
            this.adPriceTextBox.Size = new System.Drawing.Size(190, 21);
            this.adPriceTextBox.TabIndex = 10000019;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 10000018;
            this.label9.Text = "広告原単価";
            // 
            // storeComboNameTextBox
            // 
            this.storeComboNameTextBox.Location = new System.Drawing.Point(109, 59);
            this.storeComboNameTextBox.Name = "storeComboNameTextBox";
            this.storeComboNameTextBox.ReadOnly = true;
            this.storeComboNameTextBox.Size = new System.Drawing.Size(190, 21);
            this.storeComboNameTextBox.TabIndex = 10000013;
            this.storeComboNameTextBox.TextChanged += new System.EventHandler(this.shipAtTextBox_TextChanged);
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(109, 90);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.ReadOnly = true;
            this.productNameTextBox.Size = new System.Drawing.Size(507, 21);
            this.productNameTextBox.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(371, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 27;
            this.label11.Text = "売単価";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "規格名";
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Location = new System.Drawing.Point(109, 28);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.ReadOnly = true;
            this.productCodeTextBox.Size = new System.Drawing.Size(190, 21);
            this.productCodeTextBox.TabIndex = 28;
            // 
            // salePriceTextBox
            // 
            this.salePriceTextBox.Location = new System.Drawing.Point(426, 186);
            this.salePriceTextBox.Name = "salePriceTextBox";
            this.salePriceTextBox.Size = new System.Drawing.Size(190, 21);
            this.salePriceTextBox.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "通常原単価";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(109, 186);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(190, 21);
            this.priceTextBox.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "自社コード";
            // 
            // productSpecTextBox
            // 
            this.productSpecTextBox.Location = new System.Drawing.Point(109, 119);
            this.productSpecTextBox.Name = "productSpecTextBox";
            this.productSpecTextBox.ReadOnly = true;
            this.productSpecTextBox.Size = new System.Drawing.Size(507, 21);
            this.productSpecTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品名";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(134, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 21);
            this.textBox1.TabIndex = 10000001;
            // 
            // submitFormButton
            // 
            this.submitFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitFormButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.submitFormButton.Location = new System.Drawing.Point(443, 309);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(108, 30);
            this.submitFormButton.TabIndex = 0;
            this.submitFormButton.Text = "保存";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelFormButton.Location = new System.Drawing.Point(557, 309);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(108, 30);
            this.cancelFormButton.TabIndex = 1;
            this.cancelFormButton.Text = "閉じる";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // EditPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 357);
            this.Controls.Add(this.priceIdTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPriceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "単価編集";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox priceIdTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox promotePriceTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.TextBox salePriceTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private System.Windows.Forms.TextBox storeComboNameTextBox;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox productSpecTextBox;
        private System.Windows.Forms.TextBox adPriceTextBox;
        private System.Windows.Forms.TextBox storeCountyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox costTextBox;
    }
}