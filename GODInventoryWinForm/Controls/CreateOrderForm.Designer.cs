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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invoiceNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialCodeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genreNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSpecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＪＡＮコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ロット = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品口数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.deliveredAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.orderReasonComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.Control;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.submitButton.Location = new System.Drawing.Point(745, 445);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 33);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "保存";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelButton.Location = new System.Drawing.Point(851, 445);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 33);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "取消す";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(784, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "発注日";
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(836, 43);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(123, 21);
            this.orderCreatedAtDateTimePicker.TabIndex = 11;
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
            this.genreNameColumn,
            this.productNameColumn,
            this.productSpecColumn,
            this.ＪＡＮコード,
            this.原単価,
            this.売単価,
            this.ロット,
            this.納品口数,
            this.受注数,
            this.deleteButtonColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(5, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1044, 316);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // invoiceNODataGridViewTextBoxColumn
            // 
            this.invoiceNODataGridViewTextBoxColumn.DataPropertyName = "伝票番号";
            dataGridViewCellStyle15.Format = "D8";
            dataGridViewCellStyle15.NullValue = null;
            this.invoiceNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.invoiceNODataGridViewTextBoxColumn.Frozen = true;
            this.invoiceNODataGridViewTextBoxColumn.HeaderText = "伝票番号";
            this.invoiceNODataGridViewTextBoxColumn.Name = "invoiceNODataGridViewTextBoxColumn";
            this.invoiceNODataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.invoiceNODataGridViewTextBoxColumn.Width = 80;
            // 
            // specialCodeColumn
            // 
            dataGridViewCellStyle16.NullValue = "NO";
            this.specialCodeColumn.DefaultCellStyle = dataGridViewCellStyle16;
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
            // genreNameColumn
            // 
            this.genreNameColumn.HeaderText = "ジャンル";
            this.genreNameColumn.Name = "genreNameColumn";
            this.genreNameColumn.ReadOnly = true;
            // 
            // productNameColumn
            // 
            this.productNameColumn.DataPropertyName = "品名漢字";
            this.productNameColumn.HeaderText = "商品名";
            this.productNameColumn.Name = "productNameColumn";
            this.productNameColumn.ReadOnly = true;
            this.productNameColumn.Width = 120;
            // 
            // productSpecColumn
            // 
            this.productSpecColumn.DataPropertyName = "規格名漢字";
            this.productSpecColumn.HeaderText = "規格";
            this.productSpecColumn.Name = "productSpecColumn";
            this.productSpecColumn.ReadOnly = true;
            // 
            // ＪＡＮコード
            // 
            this.ＪＡＮコード.DataPropertyName = "ＪＡＮコード";
            this.ＪＡＮコード.HeaderText = "ＪＡＮコード";
            this.ＪＡＮコード.Name = "ＪＡＮコード";
            this.ＪＡＮコード.ReadOnly = true;
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
            this.ロット.DataPropertyName = "口数";
            this.ロット.HeaderText = "ロット";
            this.ロット.Name = "ロット";
            this.ロット.ReadOnly = true;
            this.ロット.Width = 80;
            // 
            // 納品口数
            // 
            this.納品口数.DataPropertyName = "納品口数";
            this.納品口数.HeaderText = "口数";
            this.納品口数.Name = "納品口数";
            this.納品口数.Width = 60;
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
            this.label2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(79, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "店番";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeCodeTextBox.Location = new System.Drawing.Point(120, 43);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(58, 21);
            this.storeCodeTextBox.TabIndex = 2;
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(31, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "仕入先コード";
            // 
            // selfCodeTextBox1
            // 
            this.selfCodeTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.selfCodeTextBox1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selfCodeTextBox1.Location = new System.Drawing.Point(120, 10);
            this.selfCodeTextBox1.Name = "selfCodeTextBox1";
            this.selfCodeTextBox1.ReadOnly = true;
            this.selfCodeTextBox1.Size = new System.Drawing.Size(159, 21);
            this.selfCodeTextBox1.TabIndex = 22;
            // 
            // shipperTextBox
            // 
            this.shipperTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.shipperTextBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shipperTextBox.Location = new System.Drawing.Point(438, 10);
            this.shipperTextBox.Name = "shipperTextBox";
            this.shipperTextBox.ReadOnly = true;
            this.shipperTextBox.Size = new System.Drawing.Size(159, 21);
            this.shipperTextBox.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(293, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "出荷業務仕入先コード";
            // 
            // selfNameTextBox
            // 
            this.selfNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.selfNameTextBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selfNameTextBox.Location = new System.Drawing.Point(695, 10);
            this.selfNameTextBox.Name = "selfNameTextBox";
            this.selfNameTextBox.ReadOnly = true;
            this.selfNameTextBox.Size = new System.Drawing.Size(264, 21);
            this.selfNameTextBox.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(626, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 25;
            this.label8.Text = "仕入先名";
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(184, 41);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(95, 22);
            this.storeComboBox.TabIndex = 3;
            this.storeComboBox.SelectedIndexChanged += new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(363, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 14);
            this.label9.TabIndex = 28;
            this.label9.Text = "法人コード";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(496, 41);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(101, 22);
            this.customerComboBox.TabIndex = 5;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            // 
            // customerIdTextBox
            // 
            this.customerIdTextBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.customerIdTextBox.Location = new System.Drawing.Point(438, 43);
            this.customerIdTextBox.Name = "customerIdTextBox";
            this.customerIdTextBox.Size = new System.Drawing.Size(52, 21);
            this.customerIdTextBox.TabIndex = 4;
            this.customerIdTextBox.Text = "4";
            this.customerIdTextBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(620, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 31;
            this.label10.Text = "部門コード";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox5.Location = new System.Drawing.Point(695, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(52, 21);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "9";
            // 
            // deliveredAtDateTimePicker
            // 
            this.deliveredAtDateTimePicker.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deliveredAtDateTimePicker.Location = new System.Drawing.Point(836, 75);
            this.deliveredAtDateTimePicker.Name = "deliveredAtDateTimePicker";
            this.deliveredAtDateTimePicker.Size = new System.Drawing.Size(123, 21);
            this.deliveredAtDateTimePicker.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(760, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 33;
            this.label11.Text = "納品予定日";
            // 
            // locationComboBox
            // 
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(184, 74);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(95, 22);
            this.locationComboBox.TabIndex = 8;
            this.locationComboBox.SelectedIndexChanged += new System.EventHandler(this.locationComboBox_SelectedIndexChanged);
            // 
            // locationTextBox
            // 
            this.locationTextBox.Enabled = false;
            this.locationTextBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.locationTextBox.Location = new System.Drawing.Point(120, 75);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(58, 21);
            this.locationTextBox.TabIndex = 7;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(17, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 14);
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
            this.label3.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(369, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "発注形態";
            // 
            // orderReasonComboBox
            // 
            this.orderReasonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderReasonComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.orderReasonComboBox.FormattingEnabled = true;
            this.orderReasonComboBox.Location = new System.Drawing.Point(438, 74);
            this.orderReasonComboBox.Name = "orderReasonComboBox";
            this.orderReasonComboBox.Size = new System.Drawing.Size(159, 22);
            this.orderReasonComboBox.TabIndex = 10;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 489);
            this.Controls.Add(this.orderReasonComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.deliveredAtDateTimePicker);
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
            this.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateOrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FAX注文入力";
            this.Load += new System.EventHandler(this.NewOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
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
        private System.Windows.Forms.DateTimePicker deliveredAtDateTimePicker;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn genreNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSpecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＪＡＮコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn ロット;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品口数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注数;
        private System.Windows.Forms.DataGridViewButtonColumn deleteButtonColumn;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}