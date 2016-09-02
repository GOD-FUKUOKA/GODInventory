namespace GODInventoryWinForm.Controls
{
    partial class OrderHistoryForm
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
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.InvoiceNOColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCodeColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderReceivedAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterButton = new System.Windows.Forms.Button();
            this.storeCodeFilterTextBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ordersTabPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.場所 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiSpecificationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOQColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQuantityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipperColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品指示Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreDistrictColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPendingColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToShipperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.id受注データDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pager1 = new GODInventoryWinForm.Controls.Pager();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.ordersTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pager1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // InvoiceNOColumn1
            // 
            this.InvoiceNOColumn1.DataPropertyName = "伝票番号";
            this.InvoiceNOColumn1.HeaderText = "伝票番号";
            this.InvoiceNOColumn1.Name = "InvoiceNOColumn1";
            this.InvoiceNOColumn1.ReadOnly = true;
            // 
            // StoreNameColumn1
            // 
            this.StoreNameColumn1.DataPropertyName = "店名";
            this.StoreNameColumn1.HeaderText = "店名";
            this.StoreNameColumn1.Name = "StoreNameColumn1";
            this.StoreNameColumn1.ReadOnly = true;
            // 
            // StoreCodeColumn1
            // 
            this.StoreCodeColumn1.DataPropertyName = "店舗コード";
            this.StoreCodeColumn1.HeaderText = "店番";
            this.StoreCodeColumn1.Name = "StoreCodeColumn1";
            this.StoreCodeColumn1.ReadOnly = true;
            this.StoreCodeColumn1.Width = 60;
            // 
            // OrderReceivedAtColumn1
            // 
            this.OrderReceivedAtColumn1.DataPropertyName = "受注日";
            this.OrderReceivedAtColumn1.HeaderText = "受注日";
            this.OrderReceivedAtColumn1.Name = "OrderReceivedAtColumn1";
            this.OrderReceivedAtColumn1.ReadOnly = true;
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Location = new System.Drawing.Point(794, 104);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(100, 35);
            this.filterButton.TabIndex = 24;
            this.filterButton.Text = "Find";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // storeCodeFilterTextBox3
            // 
            this.storeCodeFilterTextBox3.Location = new System.Drawing.Point(143, 22);
            this.storeCodeFilterTextBox3.Name = "storeCodeFilterTextBox3";
            this.storeCodeFilterTextBox3.Size = new System.Drawing.Size(100, 20);
            this.storeCodeFilterTextBox3.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "订单编号或者社内伝番";
            // 
            // ordersTabPage
            // 
            this.ordersTabPage.Controls.Add(this.button1);
            this.ordersTabPage.Controls.Add(this.storeComboBox);
            this.ordersTabPage.Controls.Add(this.storeCodeTextBox);
            this.ordersTabPage.Controls.Add(this.label2);
            this.ordersTabPage.Controls.Add(this.panel2);
            this.ordersTabPage.Controls.Add(this.panel1);
            this.ordersTabPage.Controls.Add(this.label6);
            this.ordersTabPage.Controls.Add(this.endDateTimePicker);
            this.ordersTabPage.Controls.Add(this.label4);
            this.ordersTabPage.Controls.Add(this.startDateTimePicker);
            this.ordersTabPage.Controls.Add(this.pager1);
            this.ordersTabPage.Controls.Add(this.filterButton);
            this.ordersTabPage.Controls.Add(this.storeCodeFilterTextBox3);
            this.ordersTabPage.Controls.Add(this.label14);
            this.ordersTabPage.Controls.Add(this.dataGridView1);
            this.ordersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ordersTabPage.Name = "ordersTabPage";
            this.ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ordersTabPage.Size = new System.Drawing.Size(921, 527);
            this.ordersTabPage.TabIndex = 0;
            this.ordersTabPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 20);
            this.button1.TabIndex = 96;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(819, 16);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(95, 21);
            this.storeComboBox.TabIndex = 95;
            this.storeComboBox.SelectedIndexChanged += new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
            this.storeComboBox.SelectedValueChanged += new System.EventHandler(this.storeComboBox_SelectedValueChanged);
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(755, 16);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(58, 20);
            this.storeCodeTextBox.TabIndex = 94;
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(680, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 93;
            this.label2.Text = "店舗コード";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Location = new System.Drawing.Point(262, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 45);
            this.panel2.TabIndex = 92;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(178, 17);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "全国";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(13, 17);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(37, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "县";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(13, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 45);
            this.panel1.TabIndex = 91;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(130, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "交货日";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "发货日";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "～";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(540, 19);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.endDateTimePicker.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "期日";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(389, 21);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.startDateTimePicker.TabIndex = 88;
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
            this.OrderReceivedAtColumn1,
            this.StoreCodeColumn1,
            this.StoreNameColumn1,
            this.場所,
            this.InvoiceNOColumn1,
            this.ジャンルColumn,
            this.ProductKanjiNameColumn1,
            this.ProductKanjiSpecificationColumn1,
            this.MOQColumn1,
            this.OrderQuantityColumn1,
            this.ShipperColumn1,
            this.Column2,
            this.納品指示Column1,
            this.備考Column1,
            this.StoreDistrictColumn1,
            this.IsPendingColumn1,
            this.Column3,
            this.Column4});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(915, 326);
            this.dataGridView1.TabIndex = 11;
            // 
            // 場所
            // 
            this.場所.DataPropertyName = "納品場所名漢字";
            this.場所.HeaderText = "場所";
            this.場所.Name = "場所";
            this.場所.ReadOnly = true;
            // 
            // ジャンルColumn
            // 
            this.ジャンルColumn.DataPropertyName = "GenreName";
            this.ジャンルColumn.HeaderText = "ジャンル";
            this.ジャンルColumn.Name = "ジャンルColumn";
            this.ジャンルColumn.ReadOnly = true;
            this.ジャンルColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ProductKanjiNameColumn1
            // 
            this.ProductKanjiNameColumn1.DataPropertyName = "品名漢字";
            this.ProductKanjiNameColumn1.HeaderText = "品名漢字";
            this.ProductKanjiNameColumn1.Name = "ProductKanjiNameColumn1";
            this.ProductKanjiNameColumn1.ReadOnly = true;
            // 
            // ProductKanjiSpecificationColumn1
            // 
            this.ProductKanjiSpecificationColumn1.DataPropertyName = "規格名漢字";
            this.ProductKanjiSpecificationColumn1.HeaderText = "規格名漢字";
            this.ProductKanjiSpecificationColumn1.Name = "ProductKanjiSpecificationColumn1";
            this.ProductKanjiSpecificationColumn1.ReadOnly = true;
            // 
            // MOQColumn1
            // 
            this.MOQColumn1.DataPropertyName = "口数";
            this.MOQColumn1.HeaderText = "口数";
            this.MOQColumn1.Name = "MOQColumn1";
            this.MOQColumn1.Width = 60;
            // 
            // OrderQuantityColumn1
            // 
            this.OrderQuantityColumn1.DataPropertyName = "発注数量";
            this.OrderQuantityColumn1.HeaderText = "発注数量";
            this.OrderQuantityColumn1.Name = "OrderQuantityColumn1";
            // 
            // ShipperColumn1
            // 
            this.ShipperColumn1.DataPropertyName = "実際配送担当";
            this.ShipperColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShipperColumn1.HeaderText = "担当";
            this.ShipperColumn1.Items.AddRange(new object[] {
            "丸健",
            "MKL",
            "マツモト産業"});
            this.ShipperColumn1.Name = "ShipperColumn1";
            this.ShipperColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipperColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "発注形態名称漢字";
            this.Column2.HeaderText = "形態";
            this.Column2.Name = "Column2";
            // 
            // 納品指示Column1
            // 
            this.納品指示Column1.HeaderText = "納品指示";
            this.納品指示Column1.Name = "納品指示Column1";
            // 
            // 備考Column1
            // 
            this.備考Column1.HeaderText = "備考";
            this.備考Column1.Name = "備考Column1";
            // 
            // StoreDistrictColumn1
            // 
            this.StoreDistrictColumn1.DataPropertyName = "県別";
            this.StoreDistrictColumn1.HeaderText = "県別";
            this.StoreDistrictColumn1.Name = "StoreDistrictColumn1";
            this.StoreDistrictColumn1.ReadOnly = true;
            // 
            // IsPendingColumn1
            // 
            this.IsPendingColumn1.DataPropertyName = "一旦保留";
            this.IsPendingColumn1.HeaderText = "一旦保留";
            this.IsPendingColumn1.Name = "IsPendingColumn1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "在庫状態";
            this.Column3.HeaderText = "在庫状態";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "在庫数";
            this.Column4.HeaderText = "在庫数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToShipperToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // sendToShipperToolStripMenuItem
            // 
            this.sendToShipperToolStripMenuItem.Name = "sendToShipperToolStripMenuItem";
            this.sendToShipperToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendToShipperToolStripMenuItem.Text = "SendToShipper";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ordersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(929, 553);
            this.tabControl1.TabIndex = 2;
            // 
            // id受注データDataGridViewTextBoxColumn
            // 
            this.id受注データDataGridViewTextBoxColumn.DataPropertyName = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.HeaderText = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.Name = "id受注データDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 96;
            this.comboBox1.Visible = false;
            // 
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Controls.Add(this.bindingNavigator1);
            this.pager1.Location = new System.Drawing.Point(3, 457);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 0;
            this.pager1.PageSize = 50;
            this.pager1.Size = new System.Drawing.Size(915, 68);
            this.pager1.TabIndex = 25;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 34);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(915, 34);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // OrderHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 553);
            this.Controls.Add(this.tabControl1);
            this.Name = "OrderHistoryForm";
            this.Text = "OrderHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ordersTabPage.ResumeLayout(false);
            this.ordersTabPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pager1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNOColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCodeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderReceivedAtColumn1;
        private Pager pager1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox storeCodeFilterTextBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage ordersTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 場所;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiSpecificationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOQColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantityColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipperColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品指示Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreDistrictColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPendingColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToShipperToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id受注データDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}