﻿namespace GODInventoryWinForm.Controls
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
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.filterButton = new System.Windows.Forms.Button();
            this.ordersTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btclear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.innerCodeTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.orderCodeTextBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEnumComboBox = new System.Windows.Forms.ComboBox();
            this.countyComboBox1 = new System.Windows.Forms.ComboBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pager1 = new GODInventoryWinForm.Controls.Pager();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.キャンセル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.キャンセル時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderReceivedAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCodeColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreDistrictColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.場所 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNOColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiSpecificationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOQColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQuantityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際出荷数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipperColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.重量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.社内伝番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最大行数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ダブリ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.searchEdiDataByStoreButton2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.storeNameComboBox2 = new System.Windows.Forms.ComboBox();
            this.storeCodeTextBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadASNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id受注データDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.出荷NoColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際配送担当Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品口数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際出荷数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.ordersTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(905, 15);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(100, 50);
            this.filterButton.TabIndex = 8;
            this.filterButton.Text = "検索";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // ordersTabPage
            // 
            this.ordersTabPage.Controls.Add(this.groupBox3);
            this.ordersTabPage.Controls.Add(this.pager1);
            this.ordersTabPage.Controls.Add(this.dataGridView1);
            this.ordersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ordersTabPage.Name = "ordersTabPage";
            this.ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ordersTabPage.Size = new System.Drawing.Size(1362, 517);
            this.ordersTabPage.TabIndex = 0;
            this.ordersTabPage.Text = "伝票検索";
            this.ordersTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btclear);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.storeComboBox);
            this.groupBox3.Controls.Add(this.storeCodeTextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.innerCodeTextBox);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.orderCodeTextBox3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateEnumComboBox);
            this.groupBox3.Controls.Add(this.countyComboBox1);
            this.groupBox3.Controls.Add(this.endDateTimePicker);
            this.groupBox3.Controls.Add(this.startDateTimePicker);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.filterButton);
            this.groupBox3.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(3, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1351, 77);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btclear
            // 
            this.btclear.Location = new System.Drawing.Point(1011, 15);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(100, 50);
            this.btclear.TabIndex = 9;
            this.btclear.Text = "クリア";
            this.btclear.UseVisualStyleBackColor = true;
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 107;
            this.label8.Text = "店番";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 106;
            this.label7.Text = "店名";
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(200, 43);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(110, 22);
            this.storeComboBox.TabIndex = 4;
            this.storeComboBox.TextChanged += new System.EventHandler(this.storeComboBox_TextChanged);
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(45, 44);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(110, 21);
            this.storeCodeTextBox.TabIndex = 3;
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            this.storeCodeTextBox.MouseLeave += new System.EventHandler(this.storeCodeTextBox_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(722, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 103;
            this.label5.Text = "社内伝番";
            // 
            // innerCodeTextBox
            // 
            this.innerCodeTextBox.Location = new System.Drawing.Point(790, 44);
            this.innerCodeTextBox.Name = "innerCodeTextBox";
            this.innerCodeTextBox.Size = new System.Drawing.Size(110, 21);
            this.innerCodeTextBox.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(522, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 100;
            this.label14.Text = "伝票番号";
            // 
            // orderCodeTextBox3
            // 
            this.orderCodeTextBox3.Location = new System.Drawing.Point(589, 44);
            this.orderCodeTextBox3.Name = "orderCodeTextBox3";
            this.orderCodeTextBox3.Size = new System.Drawing.Size(110, 21);
            this.orderCodeTextBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 99;
            this.label3.Text = "期限区分";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 98;
            this.label1.Text = "县别";
            // 
            // dateEnumComboBox
            // 
            this.dateEnumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateEnumComboBox.FormattingEnabled = true;
            this.dateEnumComboBox.Location = new System.Drawing.Point(394, 15);
            this.dateEnumComboBox.Name = "dateEnumComboBox";
            this.dateEnumComboBox.Size = new System.Drawing.Size(110, 22);
            this.dateEnumComboBox.TabIndex = 2;
            // 
            // countyComboBox1
            // 
            this.countyComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countyComboBox1.FormattingEnabled = true;
            this.countyComboBox1.Location = new System.Drawing.Point(394, 43);
            this.countyComboBox1.Name = "countyComboBox1";
            this.countyComboBox1.Size = new System.Drawing.Size(110, 22);
            this.countyComboBox1.TabIndex = 5;
            this.countyComboBox1.SelectedIndexChanged += new System.EventHandler(this.countyComboBox1_SelectedIndexChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(200, 16);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(110, 21);
            this.endDateTimePicker.TabIndex = 1;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(45, 16);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(110, 21);
            this.startDateTimePicker.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 87;
            this.label4.Text = "日付";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 89;
            this.label6.Text = "～";
            // 
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Location = new System.Drawing.Point(3, 484);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 5000;
            this.pager1.Size = new System.Drawing.Size(1356, 34);
            this.pager1.TabIndex = 25;
            this.pager1.EventPaging += new GODInventoryWinForm.Controls.EventPagingHandler(this.pager1_EventPaging);
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
            this.キャンセル,
            this.キャンセル時刻,
            this.OrderReceivedAtColumn1,
            this.出荷日,
            this.納品日,
            this.StoreCodeColumn1,
            this.StoreNameColumn1,
            this.StoreDistrictColumn1,
            this.場所,
            this.InvoiceNOColumn1,
            this.ジャンルColumn,
            this.商品コード,
            this.ProductKanjiNameColumn1,
            this.ProductKanjiSpecificationColumn1,
            this.Column2,
            this.MOQColumn1,
            this.OrderQuantityColumn1,
            this.実際出荷数量,
            this.ShipperColumn1,
            this.重量,
            this.受領,
            this.社内伝番,
            this.行数,
            this.最大行数,
            this.ダブリ,
            this.備考,
            this.StatusColumn1});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1356, 382);
            this.dataGridView1.TabIndex = 2;
            // 
            // キャンセル
            // 
            this.キャンセル.DataPropertyName = "キャンセル";
            this.キャンセル.HeaderText = "キャンセル";
            this.キャンセル.Name = "キャンセル";
            this.キャンセル.ReadOnly = true;
            this.キャンセル.Width = 90;
            // 
            // キャンセル時刻
            // 
            this.キャンセル時刻.DataPropertyName = "キャンセル時刻";
            this.キャンセル時刻.HeaderText = "キャンセル時刻";
            this.キャンセル時刻.Name = "キャンセル時刻";
            this.キャンセル時刻.ReadOnly = true;
            this.キャンセル時刻.Width = 60;
            // 
            // OrderReceivedAtColumn1
            // 
            this.OrderReceivedAtColumn1.DataPropertyName = "受注日";
            this.OrderReceivedAtColumn1.HeaderText = "受注日";
            this.OrderReceivedAtColumn1.Name = "OrderReceivedAtColumn1";
            this.OrderReceivedAtColumn1.ReadOnly = true;
            this.OrderReceivedAtColumn1.Width = 70;
            // 
            // 出荷日
            // 
            this.出荷日.DataPropertyName = "出荷日";
            this.出荷日.HeaderText = "出荷日";
            this.出荷日.Name = "出荷日";
            this.出荷日.ReadOnly = true;
            this.出荷日.Width = 70;
            // 
            // 納品日
            // 
            this.納品日.DataPropertyName = "納品日";
            this.納品日.HeaderText = "納品日";
            this.納品日.Name = "納品日";
            this.納品日.ReadOnly = true;
            this.納品日.Width = 70;
            // 
            // StoreCodeColumn1
            // 
            this.StoreCodeColumn1.DataPropertyName = "店舗コード";
            this.StoreCodeColumn1.HeaderText = "店番";
            this.StoreCodeColumn1.Name = "StoreCodeColumn1";
            this.StoreCodeColumn1.ReadOnly = true;
            this.StoreCodeColumn1.Width = 30;
            // 
            // StoreNameColumn1
            // 
            this.StoreNameColumn1.DataPropertyName = "店舗名漢字";
            this.StoreNameColumn1.HeaderText = "店名";
            this.StoreNameColumn1.Name = "StoreNameColumn1";
            this.StoreNameColumn1.ReadOnly = true;
            this.StoreNameColumn1.Width = 70;
            // 
            // StoreDistrictColumn1
            // 
            this.StoreDistrictColumn1.DataPropertyName = "県別";
            this.StoreDistrictColumn1.HeaderText = "県別";
            this.StoreDistrictColumn1.Name = "StoreDistrictColumn1";
            this.StoreDistrictColumn1.ReadOnly = true;
            this.StoreDistrictColumn1.Width = 30;
            // 
            // 場所
            // 
            this.場所.DataPropertyName = "納品場所名漢字";
            this.場所.HeaderText = "場所";
            this.場所.Name = "場所";
            this.場所.ReadOnly = true;
            this.場所.Width = 60;
            // 
            // InvoiceNOColumn1
            // 
            this.InvoiceNOColumn1.DataPropertyName = "伝票番号";
            this.InvoiceNOColumn1.HeaderText = "伝票番号";
            this.InvoiceNOColumn1.Name = "InvoiceNOColumn1";
            this.InvoiceNOColumn1.ReadOnly = true;
            this.InvoiceNOColumn1.Width = 80;
            // 
            // ジャンルColumn
            // 
            this.ジャンルColumn.DataPropertyName = "ジャンル";
            this.ジャンルColumn.HeaderText = "ジャンル";
            this.ジャンルColumn.Name = "ジャンルColumn";
            this.ジャンルColumn.ReadOnly = true;
            this.ジャンルColumn.Width = 60;
            // 
            // 商品コード
            // 
            this.商品コード.DataPropertyName = "商品コード";
            this.商品コード.HeaderText = "商品コード";
            this.商品コード.Name = "商品コード";
            this.商品コード.ReadOnly = true;
            this.商品コード.Width = 70;
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
            this.ProductKanjiSpecificationColumn1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "発注形態名称漢字";
            this.Column2.HeaderText = "形態";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // MOQColumn1
            // 
            this.MOQColumn1.DataPropertyName = "口数";
            this.MOQColumn1.HeaderText = "口数";
            this.MOQColumn1.Name = "MOQColumn1";
            this.MOQColumn1.ReadOnly = true;
            this.MOQColumn1.Width = 60;
            // 
            // OrderQuantityColumn1
            // 
            this.OrderQuantityColumn1.DataPropertyName = "発注数量";
            this.OrderQuantityColumn1.HeaderText = "発注数量";
            this.OrderQuantityColumn1.Name = "OrderQuantityColumn1";
            this.OrderQuantityColumn1.ReadOnly = true;
            this.OrderQuantityColumn1.Width = 65;
            // 
            // 実際出荷数量
            // 
            this.実際出荷数量.DataPropertyName = "実際出荷数量";
            this.実際出荷数量.HeaderText = "実際出荷数量";
            this.実際出荷数量.Name = "実際出荷数量";
            this.実際出荷数量.ReadOnly = true;
            this.実際出荷数量.Width = 60;
            // 
            // ShipperColumn1
            // 
            this.ShipperColumn1.DataPropertyName = "実際配送担当";
            this.ShipperColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShipperColumn1.HeaderText = "担当";
            this.ShipperColumn1.Items.AddRange(new object[] {
            "丸健",
            "MKL",
            "マツモト産業",
            "石川住宅管理",
            "その他"});
            this.ShipperColumn1.Name = "ShipperColumn1";
            this.ShipperColumn1.ReadOnly = true;
            this.ShipperColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipperColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ShipperColumn1.Width = 60;
            // 
            // 重量
            // 
            this.重量.DataPropertyName = "重量";
            this.重量.HeaderText = "重量";
            this.重量.Name = "重量";
            this.重量.ReadOnly = true;
            this.重量.Width = 50;
            // 
            // 受領
            // 
            this.受領.DataPropertyName = "受領";
            this.受領.HeaderText = "受領";
            this.受領.Name = "受領";
            this.受領.ReadOnly = true;
            this.受領.Width = 60;
            // 
            // 社内伝番
            // 
            this.社内伝番.DataPropertyName = "社内伝番";
            this.社内伝番.HeaderText = "社内伝番";
            this.社内伝番.Name = "社内伝番";
            this.社内伝番.ReadOnly = true;
            this.社内伝番.Width = 70;
            // 
            // 行数
            // 
            this.行数.DataPropertyName = "行数";
            this.行数.HeaderText = "行数";
            this.行数.Name = "行数";
            this.行数.ReadOnly = true;
            this.行数.Width = 55;
            // 
            // 最大行数
            // 
            this.最大行数.DataPropertyName = "最大行数";
            this.最大行数.HeaderText = "最大行数";
            this.最大行数.Name = "最大行数";
            this.最大行数.ReadOnly = true;
            this.最大行数.Width = 70;
            // 
            // ダブリ
            // 
            this.ダブリ.DataPropertyName = "ダブリ";
            this.ダブリ.HeaderText = "ダブリ";
            this.ダブリ.Name = "ダブリ";
            this.ダブリ.ReadOnly = true;
            this.ダブリ.Width = 30;
            // 
            // 備考
            // 
            this.備考.DataPropertyName = "備考";
            this.備考.HeaderText = "備考";
            this.備考.Name = "備考";
            this.備考.ReadOnly = true;
            this.備考.Width = 70;
            // 
            // StatusColumn1
            // 
            this.StatusColumn1.DataPropertyName = "Status";
            this.StatusColumn1.HeaderText = "Status";
            this.StatusColumn1.Name = "StatusColumn1";
            this.StatusColumn1.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editToolStripMenuItem.Text = "編集";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ordersTabPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1370, 543);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.searchEdiDataByStoreButton2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.storeNameComboBox2);
            this.tabPage1.Controls.Add(this.storeCodeTextBox2);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1362, 517);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "納品書検索";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // searchEdiDataByStoreButton2
            // 
            this.searchEdiDataByStoreButton2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchEdiDataByStoreButton2.Location = new System.Drawing.Point(329, 17);
            this.searchEdiDataByStoreButton2.Name = "searchEdiDataByStoreButton2";
            this.searchEdiDataByStoreButton2.Size = new System.Drawing.Size(106, 32);
            this.searchEdiDataByStoreButton2.TabIndex = 112;
            this.searchEdiDataByStoreButton2.Text = "検索";
            this.searchEdiDataByStoreButton2.UseVisualStyleBackColor = true;
            this.searchEdiDataByStoreButton2.Click += new System.EventHandler(this.searchEdiDataByStoreButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 111;
            this.label2.Text = "店番";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(164, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 110;
            this.label9.Text = "店名";
            // 
            // storeNameComboBox2
            // 
            this.storeNameComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeNameComboBox2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeNameComboBox2.FormattingEnabled = true;
            this.storeNameComboBox2.Location = new System.Drawing.Point(202, 17);
            this.storeNameComboBox2.Name = "storeNameComboBox2";
            this.storeNameComboBox2.Size = new System.Drawing.Size(110, 22);
            this.storeNameComboBox2.TabIndex = 109;
            this.storeNameComboBox2.SelectedIndexChanged += new System.EventHandler(this.storeNameComboBox2_SelectedIndexChanged);
            this.storeNameComboBox2.TextChanged += new System.EventHandler(this.storeNameComboBox2_TextChanged);
            // 
            // storeCodeTextBox2
            // 
            this.storeCodeTextBox2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeCodeTextBox2.Location = new System.Drawing.Point(47, 18);
            this.storeCodeTextBox2.MaxLength = 8;
            this.storeCodeTextBox2.Name = "storeCodeTextBox2";
            this.storeCodeTextBox2.Size = new System.Drawing.Size(110, 21);
            this.storeCodeTextBox2.TabIndex = 108;
            this.storeCodeTextBox2.TextChanged += new System.EventHandler(this.storeIdTextBox2_TextChanged);
            this.storeCodeTextBox2.MouseLeave += new System.EventHandler(this.storeCodeTextBox2_MouseLeave);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.出荷NoColumn1,
            this.出荷日Column1,
            this.納品日Column1,
            this.発注日Column1,
            this.県別Column1,
            this.店舗名漢字Column1,
            this.実際配送担当Column1,
            this.品名漢字Column1,
            this.規格名漢字Column1,
            this.納品口数Column1,
            this.重量Column1,
            this.実際出荷数量Column1,
            this.原価金額Column1});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView2.Location = new System.Drawing.Point(3, 66);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1356, 448);
            this.dataGridView2.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem2,
            this.uploadASNToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(145, 48);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(144, 22);
            this.editToolStripMenuItem2.Text = "編集";
            this.editToolStripMenuItem2.Click += new System.EventHandler(this.editToolStripMenuItem2_Click);
            // 
            // uploadASNToolStripMenuItem
            // 
            this.uploadASNToolStripMenuItem.Name = "uploadASNToolStripMenuItem";
            this.uploadASNToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.uploadASNToolStripMenuItem.Text = "UploadASN";
            this.uploadASNToolStripMenuItem.Click += new System.EventHandler(this.uploadASNToolStripMenuItem_Click);
            // 
            // id受注データDataGridViewTextBoxColumn
            // 
            this.id受注データDataGridViewTextBoxColumn.DataPropertyName = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.HeaderText = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.Name = "id受注データDataGridViewTextBoxColumn";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // 出荷NoColumn1
            // 
            this.出荷NoColumn1.DataPropertyName = "出荷No";
            this.出荷NoColumn1.HeaderText = "出荷No";
            this.出荷NoColumn1.Name = "出荷NoColumn1";
            this.出荷NoColumn1.ReadOnly = true;
            this.出荷NoColumn1.Width = 160;
            // 
            // 出荷日Column1
            // 
            this.出荷日Column1.DataPropertyName = "出荷日";
            this.出荷日Column1.HeaderText = "出荷日";
            this.出荷日Column1.Name = "出荷日Column1";
            this.出荷日Column1.ReadOnly = true;
            // 
            // 納品日Column1
            // 
            this.納品日Column1.DataPropertyName = "納品日";
            this.納品日Column1.HeaderText = "納品日";
            this.納品日Column1.Name = "納品日Column1";
            this.納品日Column1.ReadOnly = true;
            // 
            // 発注日Column1
            // 
            this.発注日Column1.DataPropertyName = "発注日";
            this.発注日Column1.HeaderText = "発注日";
            this.発注日Column1.Name = "発注日Column1";
            this.発注日Column1.ReadOnly = true;
            // 
            // 県別Column1
            // 
            this.県別Column1.DataPropertyName = "県別";
            this.県別Column1.HeaderText = "県別";
            this.県別Column1.Name = "県別Column1";
            this.県別Column1.ReadOnly = true;
            // 
            // 店舗名漢字Column1
            // 
            this.店舗名漢字Column1.DataPropertyName = "店舗名漢字";
            this.店舗名漢字Column1.HeaderText = "店舗名";
            this.店舗名漢字Column1.Name = "店舗名漢字Column1";
            this.店舗名漢字Column1.ReadOnly = true;
            // 
            // 実際配送担当Column1
            // 
            this.実際配送担当Column1.DataPropertyName = "実際配送担当";
            this.実際配送担当Column1.HeaderText = "実際配送担当";
            this.実際配送担当Column1.Name = "実際配送担当Column1";
            this.実際配送担当Column1.ReadOnly = true;
            this.実際配送担当Column1.Width = 120;
            // 
            // 品名漢字Column1
            // 
            this.品名漢字Column1.DataPropertyName = "品名漢字";
            this.品名漢字Column1.HeaderText = "品名";
            this.品名漢字Column1.Name = "品名漢字Column1";
            this.品名漢字Column1.ReadOnly = true;
            this.品名漢字Column1.Width = 160;
            // 
            // 規格名漢字Column1
            // 
            this.規格名漢字Column1.DataPropertyName = "規格名漢字";
            this.規格名漢字Column1.HeaderText = "規格名";
            this.規格名漢字Column1.Name = "規格名漢字Column1";
            this.規格名漢字Column1.ReadOnly = true;
            this.規格名漢字Column1.Width = 120;
            // 
            // 納品口数Column1
            // 
            this.納品口数Column1.DataPropertyName = "納品口数";
            this.納品口数Column1.HeaderText = "納品口数";
            this.納品口数Column1.Name = "納品口数Column1";
            this.納品口数Column1.ReadOnly = true;
            // 
            // 重量Column1
            // 
            this.重量Column1.DataPropertyName = "重量";
            this.重量Column1.HeaderText = "重量";
            this.重量Column1.Name = "重量Column1";
            this.重量Column1.ReadOnly = true;
            // 
            // 実際出荷数量Column1
            // 
            this.実際出荷数量Column1.DataPropertyName = "実際出荷数量";
            this.実際出荷数量Column1.HeaderText = "実際出荷数量";
            this.実際出荷数量Column1.Name = "実際出荷数量Column1";
            this.実際出荷数量Column1.ReadOnly = true;
            // 
            // 原価金額Column1
            // 
            this.原価金額Column1.DataPropertyName = "原価金額_税抜_";
            this.原価金額Column1.HeaderText = "原価金額";
            this.原価金額Column1.Name = "原価金額Column1";
            this.原価金額Column1.ReadOnly = true;
            // 
            // OrderHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 543);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "伝票検索";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ordersTabPage.ResumeLayout(false);
            this.ordersTabPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TabPage ordersTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id受注データDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox countyComboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dateEnumComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox innerCodeTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox orderCodeTextBox3;
        private System.Windows.Forms.Button btclear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        public Pager pager1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox storeNameComboBox2;
        private System.Windows.Forms.TextBox storeCodeTextBox2;
        private System.Windows.Forms.Button searchEdiDataByStoreButton2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem uploadASNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderReceivedAtColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCodeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreDistrictColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 場所;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNOColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiSpecificationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOQColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantityColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際出荷数量;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipperColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領;
        private System.Windows.Forms.DataGridViewTextBoxColumn 社内伝番;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最大行数;
        private System.Windows.Forms.DataGridViewTextBoxColumn ダブリ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷NoColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際配送担当Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品口数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際出荷数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額Column1;
    }
}