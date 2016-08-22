namespace GODInventoryWinForm.Controls
{
    partial class OutputStock
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
            this.label9 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.stockStatusComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自社コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stockNOTextBox = new System.Windows.Forms.TextBox();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.loadItemListButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.warehouseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.remarkTextBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "出库事由";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 79;
            this.label8.Text = "状態";
            // 
            // stockStatusComboBox
            // 
            this.stockStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockStatusComboBox.FormattingEnabled = true;
            this.stockStatusComboBox.Items.AddRange(new object[] {
            "完了",
            "仮"});
            this.stockStatusComboBox.Location = new System.Drawing.Point(109, 235);
            this.stockStatusComboBox.Name = "stockStatusComboBox";
            this.stockStatusComboBox.Size = new System.Drawing.Size(164, 21);
            this.stockStatusComboBox.TabIndex = 78;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDataGridViewTextBoxColumn,
            this.自社コード,
            this.商品名,
            this.規格,
            this.数量});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(314, 31);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(573, 416);
            this.dataGridView1.TabIndex = 70;
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
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "qty";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.submitButton.BackColor = System.Drawing.SystemColors.Control;
            this.submitButton.Location = new System.Drawing.Point(908, 29);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(63, 25);
            this.submitButton.TabIndex = 60;
            this.submitButton.Text = "登录";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "商品分类";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "期日";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "出库编号";
            // 
            // stockNOTextBox
            // 
            this.stockNOTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.stockNOTextBox.Enabled = false;
            this.stockNOTextBox.Location = new System.Drawing.Point(109, 269);
            this.stockNOTextBox.Multiline = true;
            this.stockNOTextBox.Name = "stockNOTextBox";
            this.stockNOTextBox.ReadOnly = true;
            this.stockNOTextBox.Size = new System.Drawing.Size(164, 22);
            this.stockNOTextBox.TabIndex = 65;
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(109, 99);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(164, 20);
            this.orderCreatedAtDateTimePicker.TabIndex = 69;
            this.orderCreatedAtDateTimePicker.ValueChanged += new System.EventHandler(this.orderCreatedAtDateTimePicker_ValueChanged);
            // 
            // loadItemListButton
            // 
            this.loadItemListButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loadItemListButton.Location = new System.Drawing.Point(209, 302);
            this.loadItemListButton.Name = "loadItemListButton";
            this.loadItemListButton.Size = new System.Drawing.Size(63, 25);
            this.loadItemListButton.TabIndex = 76;
            this.loadItemListButton.Text = "调出商品列表";
            this.loadItemListButton.UseVisualStyleBackColor = true;
            this.loadItemListButton.Click += new System.EventHandler(this.loadItemListButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButton.Location = new System.Drawing.Point(908, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(63, 25);
            this.cancelButton.TabIndex = 61;
            this.cancelButton.Text = "清零";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // genreComboBox
            // 
            this.genreComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(109, 132);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(164, 21);
            this.genreComboBox.TabIndex = 72;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged);
            // 
            // warehouseComboBox
            // 
            this.warehouseComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.warehouseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseComboBox.FormattingEnabled = true;
            this.warehouseComboBox.Location = new System.Drawing.Point(109, 65);
            this.warehouseComboBox.Name = "warehouseComboBox";
            this.warehouseComboBox.Size = new System.Drawing.Size(164, 21);
            this.warehouseComboBox.TabIndex = 74;
            this.warehouseComboBox.SelectedIndexChanged += new System.EventHandler(this.warehouseComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "仓库";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "工厂";
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(109, 167);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(164, 21);
            this.manufacturerComboBox.TabIndex = 71;
            // 
            // clientComboBox
            // 
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Items.AddRange(new object[] {
            "ナフコ"});
            this.clientComboBox.Location = new System.Drawing.Point(110, 31);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(163, 21);
            this.clientComboBox.TabIndex = 83;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 82;
            this.label10.Text = "客户";
            // 
            // remarkTextBox1
            // 
            this.remarkTextBox1.FormattingEnabled = true;
            this.remarkTextBox1.Items.AddRange(new object[] {
            "通常出荷",
            "不良品交換",
            "破損",
            "小売",
            "自由入力"});
            this.remarkTextBox1.Location = new System.Drawing.Point(110, 201);
            this.remarkTextBox1.Name = "remarkTextBox1";
            this.remarkTextBox1.Size = new System.Drawing.Size(164, 21);
            this.remarkTextBox1.TabIndex = 84;
            // 
            // OutputStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 490);
            this.Controls.Add(this.remarkTextBox1);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.stockStatusComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stockNOTextBox);
            this.Controls.Add(this.orderCreatedAtDateTimePicker);
            this.Controls.Add(this.loadItemListButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.warehouseComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manufacturerComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutputStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出库输入界面";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox stockStatusComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stockNOTextBox;
        private System.Windows.Forms.DateTimePicker orderCreatedAtDateTimePicker;
        private System.Windows.Forms.Button loadItemListButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.ComboBox warehouseComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox remarkTextBox1;



    }
}