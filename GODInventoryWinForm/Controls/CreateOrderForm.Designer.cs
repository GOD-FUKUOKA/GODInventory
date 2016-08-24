namespace GODInventoryWinForm.Controls
{
    partial class CreateOrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selfCodeTextBox1 = new System.Windows.Forms.TextBox();
            this.shipperTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selfNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerIdTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.orderReasonComboBox = new System.Windows.Forms.ComboBox();
            this.invoiceNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialCodeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSpecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＪＡＮコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ロット = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.Control;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(779, 441);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 32);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(876, 441);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 32);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(776, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "発注日";
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(828, 42);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(123, 21);
            this.orderCreatedAtDateTimePicker.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceNODataGridViewTextBoxColumn,
            this.specialCodeColumn,
            this.productCodeColumn,
            this.ジャンル,
            this.productNameColumn,
            this.productSpecColumn,
            this.ＪＡＮコード,
            this.原単価,
            this.売単価,
            this.ロット,
            this.口数,
            this.受注数,
            this.deleteButtonColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(5, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1049, 310);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.productToolStripMenuItem.Text = "选择商品";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "店舗コード";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(112, 42);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(58, 21);
            this.storeCodeTextBox.TabIndex = 18;
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "仕入先コード";
            // 
            // selfCodeTextBox1
            // 
            this.selfCodeTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.selfCodeTextBox1.Location = new System.Drawing.Point(112, 10);
            this.selfCodeTextBox1.Name = "selfCodeTextBox1";
            this.selfCodeTextBox1.ReadOnly = true;
            this.selfCodeTextBox1.Size = new System.Drawing.Size(159, 21);
            this.selfCodeTextBox1.TabIndex = 22;
            // 
            // shipperTextBox
            // 
            this.shipperTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.shipperTextBox.Location = new System.Drawing.Point(432, 10);
            this.shipperTextBox.Name = "shipperTextBox";
            this.shipperTextBox.ReadOnly = true;
            this.shipperTextBox.Size = new System.Drawing.Size(159, 21);
            this.shipperTextBox.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(289, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "出荷業務仕入先コード";
            // 
            // selfNameTextBox
            // 
            this.selfNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.selfNameTextBox.Location = new System.Drawing.Point(687, 10);
            this.selfNameTextBox.Name = "selfNameTextBox";
            this.selfNameTextBox.ReadOnly = true;
            this.selfNameTextBox.Size = new System.Drawing.Size(264, 21);
            this.selfNameTextBox.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(620, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "仕入先名";
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(176, 42);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(95, 20);
            this.storeComboBox.TabIndex = 27;
            this.storeComboBox.SelectedIndexChanged += new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(354, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "法人コード";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(490, 42);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(101, 20);
            this.customerComboBox.TabIndex = 30;
            // 
            // customerIdTextBox
            // 
            this.customerIdTextBox.Location = new System.Drawing.Point(432, 42);
            this.customerIdTextBox.Name = "customerIdTextBox";
            this.customerIdTextBox.Size = new System.Drawing.Size(52, 21);
            this.customerIdTextBox.TabIndex = 29;
            this.customerIdTextBox.Text = "4";
            this.customerIdTextBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(607, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "部門コード";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(687, 42);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(52, 21);
            this.textBox5.TabIndex = 32;
            this.textBox5.Text = "9";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(828, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 21);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(750, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "納品予定日";
            // 
            // locationComboBox
            // 
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(176, 74);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(95, 20);
            this.locationComboBox.TabIndex = 37;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(112, 74);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(58, 21);
            this.locationTextBox.TabIndex = 36;
            this.locationTextBox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "納品場所コード";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "発注形態";
            // 
            // orderReasonComboBox
            // 
            this.orderReasonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderReasonComboBox.FormattingEnabled = true;
            this.orderReasonComboBox.Location = new System.Drawing.Point(432, 74);
            this.orderReasonComboBox.Name = "orderReasonComboBox";
            this.orderReasonComboBox.Size = new System.Drawing.Size(159, 20);
            this.orderReasonComboBox.TabIndex = 40;
            // 
            // invoiceNODataGridViewTextBoxColumn
            // 
            this.invoiceNODataGridViewTextBoxColumn.DataPropertyName = "伝票番号";
            dataGridViewCellStyle1.Format = "D8";
            dataGridViewCellStyle1.NullValue = null;
            this.invoiceNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.invoiceNODataGridViewTextBoxColumn.Frozen = true;
            this.invoiceNODataGridViewTextBoxColumn.HeaderText = "伝票番号";
            this.invoiceNODataGridViewTextBoxColumn.Name = "invoiceNODataGridViewTextBoxColumn";
            this.invoiceNODataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.invoiceNODataGridViewTextBoxColumn.Width = 80;
            // 
            // specialCodeColumn
            // 
            dataGridViewCellStyle2.NullValue = "No";
            this.specialCodeColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.specialCodeColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.specialCodeColumn.HeaderText = "雑コード";
            this.specialCodeColumn.Items.AddRange(new object[] {
            "NO",
            "YES"});
            this.specialCodeColumn.Name = "specialCodeColumn";
            this.specialCodeColumn.Width = 80;
            // 
            // productCodeColumn
            // 
            this.productCodeColumn.DataPropertyName = "商品コード";
            this.productCodeColumn.HeaderText = "商品コード";
            this.productCodeColumn.Name = "productCodeColumn";
            this.productCodeColumn.Width = 80;
            // 
            // ジャンル
            // 
            this.ジャンル.DataPropertyName = "ジャンル";
            this.ジャンル.HeaderText = "ジャンル";
            this.ジャンル.Name = "ジャンル";
            this.ジャンル.ReadOnly = true;
            // 
            // productNameColumn
            // 
            this.productNameColumn.DataPropertyName = "品名漢字";
            this.productNameColumn.HeaderText = "商品名";
            this.productNameColumn.Name = "productNameColumn";
            this.productNameColumn.Width = 120;
            // 
            // productSpecColumn
            // 
            this.productSpecColumn.DataPropertyName = "規格名漢字";
            this.productSpecColumn.HeaderText = "規格";
            this.productSpecColumn.Name = "productSpecColumn";
            // 
            // ＪＡＮコード
            // 
            this.ＪＡＮコード.DataPropertyName = "ＪＡＮコード";
            this.ＪＡＮコード.HeaderText = "ＪＡＮコード";
            this.ＪＡＮコード.Name = "ＪＡＮコード";
            this.ＪＡＮコード.Width = 80;
            // 
            // 原単価
            // 
            this.原単価.DataPropertyName = "原単価_税抜_";
            this.原単価.HeaderText = "原単価";
            this.原単価.Name = "原単価";
            this.原単価.Width = 60;
            // 
            // 売単価
            // 
            this.売単価.DataPropertyName = "売単価_税抜_";
            this.売単価.HeaderText = "売単価";
            this.売単価.Name = "売単価";
            this.売単価.Width = 60;
            // 
            // ロット
            // 
            this.ロット.DataPropertyName = "ロット";
            this.ロット.HeaderText = "ロット";
            this.ロット.Name = "ロット";
            this.ロット.Width = 80;
            // 
            // 口数
            // 
            this.口数.DataPropertyName = "口数";
            this.口数.HeaderText = "口数";
            this.口数.Name = "口数";
            this.口数.Width = 60;
            // 
            // 受注数
            // 
            this.受注数.DataPropertyName = "発注数量";
            this.受注数.HeaderText = "受注数";
            this.受注数.Name = "受注数";
            this.受注数.Width = 60;
            // 
            // deleteButtonColumn
            // 
            this.deleteButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteButtonColumn.FillWeight = 30F;
            this.deleteButtonColumn.HeaderText = "";
            this.deleteButtonColumn.Name = "deleteButtonColumn";
            this.deleteButtonColumn.Text = "クリア";
            this.deleteButtonColumn.ToolTipText = "クリア";
            this.deleteButtonColumn.UseColumnTextForButtonValue = true;
            this.deleteButtonColumn.Width = 40;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 475);
            this.Controls.Add(this.orderReasonComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.customerIdTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.storeComboBox);
            this.Controls.Add(this.selfNameTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.shipperTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selfCodeTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.storeCodeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.orderCreatedAtDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateOrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "传真订单输入界面";
            this.Load += new System.EventHandler(this.NewOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker orderCreatedAtDateTimePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox selfCodeTextBox1;
        private System.Windows.Forms.TextBox shipperTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox selfNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.TextBox customerIdTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox orderReasonComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn specialCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンル;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSpecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＪＡＮコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn ロット;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注数;
        private System.Windows.Forms.DataGridViewButtonColumn deleteButtonColumn;
    }
}