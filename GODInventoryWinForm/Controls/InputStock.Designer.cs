namespace GODInventoryWinForm.Controls
{
    partial class InputStock
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自社コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.loadItemListButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stockNOTextBox = new System.Windows.Forms.TextBox();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.warehouseComboBox = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.codeComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.stockStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.remarkTextBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDataGridViewTextBoxColumn,
            this.自社コード,
            this.商品名,
            this.規格,
            this.数量});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(344, 23);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(573, 384);
            this.dataGridView1.TabIndex = 45;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // IdDataGridViewTextBoxColumn
            // 
            this.IdDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.IdDataGridViewTextBoxColumn.HeaderText = "序号";
            this.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn";
            this.IdDataGridViewTextBoxColumn.ReadOnly = true;
            this.IdDataGridViewTextBoxColumn.Width = 60;
            // 
            // 自社コード
            // 
            this.自社コード.DataPropertyName = "自社コード";
            this.自社コード.HeaderText = "自社コード";
            this.自社コード.Name = "自社コード";
            this.自社コード.ReadOnly = true;
            // 
            // 商品名
            // 
            this.商品名.DataPropertyName = "商品名";
            this.商品名.HeaderText = "商品名";
            this.商品名.Name = "商品名";
            this.商品名.ReadOnly = true;
            this.商品名.Width = 200;
            // 
            // 規格
            // 
            this.規格.DataPropertyName = "規格";
            this.規格.HeaderText = "規格";
            this.規格.Name = "規格";
            this.規格.ReadOnly = true;
            this.規格.Width = 110;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "qty";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(938, 54);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(63, 23);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "清零";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.BackColor = System.Drawing.SystemColors.Control;
            this.submitButton.Location = new System.Drawing.Point(938, 21);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(63, 23);
            this.submitButton.TabIndex = 35;
            this.submitButton.Text = "登录";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // loadItemListButton
            // 
            this.loadItemListButton.Location = new System.Drawing.Point(234, 258);
            this.loadItemListButton.Name = "loadItemListButton";
            this.loadItemListButton.Size = new System.Drawing.Size(63, 23);
            this.loadItemListButton.TabIndex = 51;
            this.loadItemListButton.Text = "调出商品列表";
            this.loadItemListButton.UseVisualStyleBackColor = true;
            this.loadItemListButton.Click += new System.EventHandler(this.loadItemListButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 43;
            this.label7.Text = "数量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "商品分类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "期日";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "入库编号";
            // 
            // stockNOTextBox
            // 
            this.stockNOTextBox.Enabled = false;
            this.stockNOTextBox.Location = new System.Drawing.Point(134, 222);
            this.stockNOTextBox.Multiline = true;
            this.stockNOTextBox.Name = "stockNOTextBox";
            this.stockNOTextBox.ReadOnly = true;
            this.stockNOTextBox.Size = new System.Drawing.Size(164, 21);
            this.stockNOTextBox.TabIndex = 40;
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(134, 85);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(164, 21);
            this.orderCreatedAtDateTimePicker.TabIndex = 44;
            this.orderCreatedAtDateTimePicker.ValueChanged += new System.EventHandler(this.orderCreatedAtDateTimePicker_ValueChanged);
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(134, 113);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(164, 20);
            this.genreComboBox.TabIndex = 47;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // warehouseComboBox
            // 
            this.warehouseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseComboBox.FormattingEnabled = true;
            this.warehouseComboBox.Location = new System.Drawing.Point(134, 58);
            this.warehouseComboBox.Name = "warehouseComboBox";
            this.warehouseComboBox.Size = new System.Drawing.Size(164, 20);
            this.warehouseComboBox.TabIndex = 49;
            this.warehouseComboBox.SelectedIndexChanged += new System.EventHandler(this.warehouseComboBox_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(134, 344);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(164, 21);
            this.numericUpDown1.TabIndex = 50;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "工厂编码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "仓库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "工厂";
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(134, 140);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(164, 20);
            this.manufacturerComboBox.TabIndex = 46;
            // 
            // codeComboBox
            // 
            this.codeComboBox.FormattingEnabled = true;
            this.codeComboBox.Location = new System.Drawing.Point(134, 318);
            this.codeComboBox.Name = "codeComboBox";
            this.codeComboBox.Size = new System.Drawing.Size(164, 20);
            this.codeComboBox.TabIndex = 48;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(234, 384);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(63, 23);
            this.addButton.TabIndex = 52;
            this.addButton.Text = "添加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // stockStatusComboBox
            // 
            this.stockStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockStatusComboBox.FormattingEnabled = true;
            this.stockStatusComboBox.Items.AddRange(new object[] {
            "完了",
            "仮"});
            this.stockStatusComboBox.Location = new System.Drawing.Point(134, 195);
            this.stockStatusComboBox.Name = "stockStatusComboBox";
            this.stockStatusComboBox.Size = new System.Drawing.Size(164, 20);
            this.stockStatusComboBox.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "状態";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "入库事由";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 57;
            this.label10.Text = "客户";
            // 
            // clientComboBox
            // 
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Items.AddRange(new object[] {
            "ナフコ"});
            this.clientComboBox.Location = new System.Drawing.Point(134, 31);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(163, 20);
            this.clientComboBox.TabIndex = 58;
            // 
            // remarkTextBox1
            // 
            this.remarkTextBox1.FormattingEnabled = true;
            this.remarkTextBox1.Items.AddRange(new object[] {
            "仕入",
            "返品",
            "調整",
            "自由入力"});
            this.remarkTextBox1.Location = new System.Drawing.Point(134, 167);
            this.remarkTextBox1.Name = "remarkTextBox1";
            this.remarkTextBox1.Size = new System.Drawing.Size(164, 20);
            this.remarkTextBox1.TabIndex = 59;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(58, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(240, 1);
            this.label11.TabIndex = 60;
            // 
            // InputStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 437);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.remarkTextBox1);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.stockStatusComboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.loadItemListButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stockNOTextBox);
            this.Controls.Add(this.orderCreatedAtDateTimePicker);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.warehouseComboBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manufacturerComboBox);
            this.Controls.Add(this.codeComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库输入界面";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button loadItemListButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stockNOTextBox;
        private System.Windows.Forms.DateTimePicker orderCreatedAtDateTimePicker;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.ComboBox warehouseComboBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.ComboBox codeComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox stockStatusComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.ComboBox remarkTextBox1;
        private System.Windows.Forms.Label label11;

    }
}