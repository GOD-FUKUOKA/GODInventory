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
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invoiceNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderReasonDataGridviewComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ＪＡＮコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品場所コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品予定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteDataGridViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.orderQuantityTextBox = new System.Windows.Forms.TextBox();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.Control;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(779, 478);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 35);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(876, 478);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 35);
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
            this.label1.Location = new System.Drawing.Point(776, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "発注日";
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(828, 46);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(123, 20);
            this.orderCreatedAtDateTimePicker.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceNODataGridViewTextBoxColumn,
            this.orderReasonDataGridviewComboBox,
            this.ＪＡＮコード,
            this.商品コード,
            this.品名漢字,
            this.規格名漢字,
            this.原単価,
            this.売単価,
            this.店舗コード,
            this.店舗名漢字,
            this.発注数量,
            this.納品場所コード,
            this.納品予定日,
            this.deleteDataGridViewButtonColumn});
            this.dataGridView1.Location = new System.Drawing.Point(5, 155);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(960, 306);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
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
            // 
            // orderReasonDataGridviewComboBox
            // 
            this.orderReasonDataGridviewComboBox.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.orderReasonDataGridviewComboBox.Frozen = true;
            this.orderReasonDataGridviewComboBox.HeaderText = "発注形態";
            this.orderReasonDataGridviewComboBox.Items.AddRange(new object[] {
            "補充",
            "用度品",
            "広告",
            "客注",
            "新店"});
            this.orderReasonDataGridviewComboBox.Name = "orderReasonDataGridviewComboBox";
            this.orderReasonDataGridviewComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.orderReasonDataGridviewComboBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ＪＡＮコード
            // 
            this.ＪＡＮコード.DataPropertyName = "ＪＡＮコード";
            this.ＪＡＮコード.HeaderText = "ＪＡＮコード";
            this.ＪＡＮコード.Name = "ＪＡＮコード";
            // 
            // 商品コード
            // 
            this.商品コード.DataPropertyName = "商品コード";
            this.商品コード.HeaderText = "商品コード";
            this.商品コード.Name = "商品コード";
            // 
            // 品名漢字
            // 
            this.品名漢字.DataPropertyName = "品名漢字";
            this.品名漢字.HeaderText = "品名漢字";
            this.品名漢字.Name = "品名漢字";
            // 
            // 規格名漢字
            // 
            this.規格名漢字.DataPropertyName = "規格名漢字";
            this.規格名漢字.HeaderText = "規格名漢字";
            this.規格名漢字.Name = "規格名漢字";
            // 
            // 原単価
            // 
            this.原単価.DataPropertyName = "原単価";
            this.原単価.HeaderText = "原単価";
            this.原単価.Name = "原単価";
            this.原単価.Visible = false;
            // 
            // 売単価
            // 
            this.売単価.DataPropertyName = "売単価";
            this.売単価.HeaderText = "売単価";
            this.売単価.Name = "売単価";
            this.売単価.Visible = false;
            // 
            // 店舗コード
            // 
            this.店舗コード.DataPropertyName = "店舗コード";
            this.店舗コード.HeaderText = "店舗コード";
            this.店舗コード.Name = "店舗コード";
            // 
            // 店舗名漢字
            // 
            this.店舗名漢字.DataPropertyName = "店舗名漢字";
            this.店舗名漢字.HeaderText = "店舗名漢字";
            this.店舗名漢字.Name = "店舗名漢字";
            // 
            // 発注数量
            // 
            this.発注数量.DataPropertyName = "発注数量";
            this.発注数量.HeaderText = "発注数量";
            this.発注数量.Name = "発注数量";
            // 
            // 納品場所コード
            // 
            this.納品場所コード.DataPropertyName = "納品場所コード";
            this.納品場所コード.HeaderText = "納品場所コード";
            this.納品場所コード.Name = "納品場所コード";
            // 
            // 納品予定日
            // 
            this.納品予定日.DataPropertyName = "納品予定日";
            this.納品予定日.HeaderText = "納品予定日";
            this.納品予定日.Name = "納品予定日";
            // 
            // deleteDataGridViewButtonColumn
            // 
            this.deleteDataGridViewButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteDataGridViewButtonColumn.FillWeight = 30F;
            this.deleteDataGridViewButtonColumn.HeaderText = "";
            this.deleteDataGridViewButtonColumn.Name = "deleteDataGridViewButtonColumn";
            this.deleteDataGridViewButtonColumn.Text = "クリア";
            this.deleteDataGridViewButtonColumn.ToolTipText = "クリア";
            this.deleteDataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            this.deleteDataGridViewButtonColumn.Width = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "店舗コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(354, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "商品コード";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(620, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "発注数量";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(112, 46);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(58, 20);
            this.storeCodeTextBox.TabIndex = 18;
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Location = new System.Drawing.Point(432, 80);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.Size = new System.Drawing.Size(160, 20);
            this.productCodeTextBox.TabIndex = 19;
            this.productCodeTextBox.Tag = "すべてが数字";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "仕入先コード";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(112, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(432, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(159, 20);
            this.textBox2.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(289, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "出荷業務仕入先コード";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(687, 11);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(264, 20);
            this.textBox3.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(620, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "仕入先名";
            // 
            // storeComboBox
            // 
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(176, 46);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(95, 21);
            this.storeComboBox.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(354, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "法人コード";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(490, 46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 21);
            this.comboBox2.TabIndex = 30;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(432, 46);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(52, 20);
            this.textBox4.TabIndex = 29;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(607, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "部門コード";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(687, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(52, 20);
            this.textBox5.TabIndex = 32;
            this.textBox5.Text = "9";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(828, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 20);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(750, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "納品予定日";
            // 
            // locationComboBox
            // 
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(176, 80);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(95, 21);
            this.locationComboBox.TabIndex = 37;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(112, 80);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(58, 20);
            this.locationTextBox.TabIndex = 36;
            this.locationTextBox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "納品場所コード";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(828, 114);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(123, 35);
            this.addButton.TabIndex = 38;
            this.addButton.Text = "Add to list";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // orderQuantityTextBox
            // 
            this.orderQuantityTextBox.Location = new System.Drawing.Point(687, 80);
            this.orderQuantityTextBox.Name = "orderQuantityTextBox";
            this.orderQuantityTextBox.Size = new System.Drawing.Size(52, 20);
            this.orderQuantityTextBox.TabIndex = 39;
            this.orderQuantityTextBox.Text = "1";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.AllowNew = false;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 515);
            this.Controls.Add(this.orderQuantityTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.storeComboBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.productCodeTextBox);
            this.Controls.Add(this.storeCodeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
            this.Text = "CreateOrderForm";
            this.Load += new System.EventHandler(this.NewOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox orderQuantityTextBox;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn orderReasonDataGridviewComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＪＡＮコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品場所コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品予定日;
        private System.Windows.Forms.DataGridViewButtonColumn deleteDataGridViewButtonColumn;
    }
}