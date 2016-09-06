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
            this.filterButton = new System.Windows.Forms.Button();
            this.ordersTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.キャンセル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.キャンセル時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToShipperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.id受注データDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pager1 = new GODInventoryWinForm.Controls.Pager();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.ordersTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(930, 18);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(101, 51);
            this.filterButton.TabIndex = 24;
            this.filterButton.Text = "Find";
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
            this.ordersTabPage.Size = new System.Drawing.Size(1063, 484);
            this.ordersTabPage.TabIndex = 0;
            this.ordersTabPage.Text = "订单查询";
            this.ordersTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox3.Location = new System.Drawing.Point(3, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1052, 84);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 107;
            this.label8.Text = "店番";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 106;
            this.label7.Text = "店名";
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(192, 48);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(110, 20);
            this.storeComboBox.TabIndex = 105;
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(41, 47);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(110, 21);
            this.storeCodeTextBox.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(735, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 103;
            this.label5.Text = "社内伝番";
            // 
            // innerCodeTextBox
            // 
            this.innerCodeTextBox.Location = new System.Drawing.Point(794, 47);
            this.innerCodeTextBox.Name = "innerCodeTextBox";
            this.innerCodeTextBox.Size = new System.Drawing.Size(110, 21);
            this.innerCodeTextBox.TabIndex = 102;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(536, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 100;
            this.label14.Text = "订单编号";
            // 
            // orderCodeTextBox3
            // 
            this.orderCodeTextBox3.Location = new System.Drawing.Point(595, 47);
            this.orderCodeTextBox3.Name = "orderCodeTextBox3";
            this.orderCodeTextBox3.Size = new System.Drawing.Size(110, 21);
            this.orderCodeTextBox3.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 99;
            this.label3.Text = "期限区分";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "县别";
            // 
            // dateEnumComboBox
            // 
            this.dateEnumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateEnumComboBox.FormattingEnabled = true;
            this.dateEnumComboBox.Location = new System.Drawing.Point(392, 18);
            this.dateEnumComboBox.Name = "dateEnumComboBox";
            this.dateEnumComboBox.Size = new System.Drawing.Size(110, 20);
            this.dateEnumComboBox.TabIndex = 97;
            // 
            // countyComboBox1
            // 
            this.countyComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countyComboBox1.FormattingEnabled = true;
            this.countyComboBox1.Location = new System.Drawing.Point(392, 48);
            this.countyComboBox1.Name = "countyComboBox1";
            this.countyComboBox1.Size = new System.Drawing.Size(110, 20);
            this.countyComboBox1.TabIndex = 96;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(192, 18);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(110, 21);
            this.endDateTimePicker.TabIndex = 90;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(41, 18);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(110, 21);
            this.startDateTimePicker.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 87;
            this.label4.Text = "期日";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 89;
            this.label6.Text = "～";
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
            this.キャンセル,
            this.キャンセル時刻,
            this.ジャンル,
            this.備考,
            this.StatusColumn1});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1057, 334);
            this.dataGridView1.TabIndex = 11;
            // 
            // OrderReceivedAtColumn1
            // 
            this.OrderReceivedAtColumn1.DataPropertyName = "受注日";
            this.OrderReceivedAtColumn1.HeaderText = "受注日";
            this.OrderReceivedAtColumn1.Name = "OrderReceivedAtColumn1";
            this.OrderReceivedAtColumn1.ReadOnly = true;
            // 
            // 出荷日
            // 
            this.出荷日.DataPropertyName = "出荷日";
            this.出荷日.HeaderText = "出荷日";
            this.出荷日.Name = "出荷日";
            // 
            // 納品日
            // 
            this.納品日.DataPropertyName = "納品日";
            this.納品日.HeaderText = "納品日";
            this.納品日.Name = "納品日";
            // 
            // StoreCodeColumn1
            // 
            this.StoreCodeColumn1.DataPropertyName = "店舗コード";
            this.StoreCodeColumn1.HeaderText = "店番";
            this.StoreCodeColumn1.Name = "StoreCodeColumn1";
            this.StoreCodeColumn1.ReadOnly = true;
            this.StoreCodeColumn1.Width = 60;
            // 
            // StoreNameColumn1
            // 
            this.StoreNameColumn1.DataPropertyName = "店舗名漢字";
            this.StoreNameColumn1.HeaderText = "店名";
            this.StoreNameColumn1.Name = "StoreNameColumn1";
            this.StoreNameColumn1.ReadOnly = true;
            // 
            // StoreDistrictColumn1
            // 
            this.StoreDistrictColumn1.DataPropertyName = "県別";
            this.StoreDistrictColumn1.HeaderText = "県別";
            this.StoreDistrictColumn1.Name = "StoreDistrictColumn1";
            this.StoreDistrictColumn1.ReadOnly = true;
            // 
            // 場所
            // 
            this.場所.DataPropertyName = "納品場所名漢字";
            this.場所.HeaderText = "場所";
            this.場所.Name = "場所";
            this.場所.ReadOnly = true;
            // 
            // InvoiceNOColumn1
            // 
            this.InvoiceNOColumn1.DataPropertyName = "伝票番号";
            this.InvoiceNOColumn1.HeaderText = "伝票番号";
            this.InvoiceNOColumn1.Name = "InvoiceNOColumn1";
            this.InvoiceNOColumn1.ReadOnly = true;
            // 
            // ジャンルColumn
            // 
            this.ジャンルColumn.DataPropertyName = "GenreName";
            this.ジャンルColumn.HeaderText = "ジャンル";
            this.ジャンルColumn.Name = "ジャンルColumn";
            this.ジャンルColumn.ReadOnly = true;
            this.ジャンルColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // 商品コード
            // 
            this.商品コード.DataPropertyName = "商品コード";
            this.商品コード.HeaderText = "商品コード";
            this.商品コード.Name = "商品コード";
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
            // Column2
            // 
            this.Column2.DataPropertyName = "発注形態名称漢字";
            this.Column2.HeaderText = "形態";
            this.Column2.Name = "Column2";
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
            // 実際出荷数量
            // 
            this.実際出荷数量.DataPropertyName = "実際出荷数量";
            this.実際出荷数量.HeaderText = "実際出荷数量";
            this.実際出荷数量.Name = "実際出荷数量";
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
            // 重量
            // 
            this.重量.DataPropertyName = "重量";
            this.重量.HeaderText = "重量";
            this.重量.Name = "重量";
            // 
            // 受領
            // 
            this.受領.DataPropertyName = "受領";
            this.受領.HeaderText = "受領";
            this.受領.Name = "受領";
            // 
            // 社内伝番
            // 
            this.社内伝番.DataPropertyName = "社内伝番";
            this.社内伝番.HeaderText = "社内伝番";
            this.社内伝番.Name = "社内伝番";
            // 
            // 行数
            // 
            this.行数.DataPropertyName = "行数";
            this.行数.HeaderText = "行数";
            this.行数.Name = "行数";
            // 
            // 最大行数
            // 
            this.最大行数.DataPropertyName = "最大行数";
            this.最大行数.HeaderText = "最大行数";
            this.最大行数.Name = "最大行数";
            // 
            // ダブリ
            // 
            this.ダブリ.DataPropertyName = "ダブリ";
            this.ダブリ.HeaderText = "ダブリ";
            this.ダブリ.Name = "ダブリ";
            // 
            // キャンセル
            // 
            this.キャンセル.DataPropertyName = "キャンセル";
            this.キャンセル.HeaderText = "キャンセル";
            this.キャンセル.Name = "キャンセル";
            // 
            // キャンセル時刻
            // 
            this.キャンセル時刻.DataPropertyName = "キャンセル時刻";
            this.キャンセル時刻.HeaderText = "キャンセル時刻";
            this.キャンセル時刻.Name = "キャンセル時刻";
            // 
            // ジャンル
            // 
            this.ジャンル.DataPropertyName = "ジャンル";
            this.ジャンル.HeaderText = "ジャンル";
            this.ジャンル.Name = "ジャンル";
            // 
            // 備考
            // 
            this.備考.DataPropertyName = "備考";
            this.備考.HeaderText = "備考";
            this.備考.Name = "備考";
            // 
            // StatusColumn1
            // 
            this.StatusColumn1.DataPropertyName = "Status";
            this.StatusColumn1.HeaderText = "Status";
            this.StatusColumn1.Name = "StatusColumn1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToShipperToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 26);
            // 
            // sendToShipperToolStripMenuItem
            // 
            this.sendToShipperToolStripMenuItem.Name = "sendToShipperToolStripMenuItem";
            this.sendToShipperToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sendToShipperToolStripMenuItem.Text = "SendToShipper";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ordersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1071, 510);
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
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Location = new System.Drawing.Point(3, 450);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 5000;
            this.pager1.Size = new System.Drawing.Size(1057, 31);
            this.pager1.TabIndex = 25;
            this.pager1.EventPaging += new GODInventoryWinForm.Controls.EventPagingHandler(this.pager1_EventPaging);
            // 
            // OrderHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 510);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ordersTabPage.ResumeLayout(false);
            this.ordersTabPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource3;
        private Pager pager1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TabPage ordersTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToShipperToolStripMenuItem;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンル;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox innerCodeTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox orderCodeTextBox3;
    }
}