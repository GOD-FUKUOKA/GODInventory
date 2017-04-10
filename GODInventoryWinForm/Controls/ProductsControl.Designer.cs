namespace GODInventoryWinForm.Controls
{
    partial class ProductsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.自社コードColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.得意先Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PT入数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コードColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JANコードColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.インストアコードColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単品重量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単位Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PT単位かColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAddItem = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pricesDataGridView = new System.Windows.Forms.DataGridView();
            this.自社コードColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店番Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入原価Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.通常原単価Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.広告原単価Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.特売原単価Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pricesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.storesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.countyComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.genresComboBox = new System.Windows.Forms.ComboBox();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.自社コードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.得意先DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pT入数DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jANコードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.インストアコードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.通常原単価DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単品重量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単位DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pT単位かDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.productContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pricesDataGridView)).BeginInit();
            this.priceContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // productContextMenuStrip
            // 
            this.productContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeToolStripMenuItem,
            this.addItemToolStripMenuItem});
            this.productContextMenuStrip.Name = "contextMenuStrip1";
            this.productContextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // ChangeToolStripMenuItem
            // 
            this.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            this.ChangeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ChangeToolStripMenuItem.Text = "編集";
            this.ChangeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItem_Click);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.addItemToolStripMenuItem.Text = "新規";
            this.addItemToolStripMenuItem.Visible = false;
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.AllowUserToAddRows = false;
            this.productsDataGridView.AllowUserToDeleteRows = false;
            this.productsDataGridView.AllowUserToResizeRows = false;
            this.productsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsDataGridView.AutoGenerateColumns = false;
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.自社コードColumn1,
            this.得意先Column1,
            this.ジャンルColumn1,
            this.商品名Column1,
            this.規格Column1,
            this.PT入数Column1,
            this.商品コードColumn1,
            this.JANコードColumn1,
            this.インストアコードColumn1,
            this.単品重量Column1,
            this.単位Column1,
            this.PT単位かColumn1,
            this.自社コードDataGridViewTextBoxColumn,
            this.得意先DataGridViewTextBoxColumn,
            this.ジャンルDataGridViewTextBoxColumn,
            this.商品名DataGridViewTextBoxColumn,
            this.規格DataGridViewTextBoxColumn,
            this.pT入数DataGridViewTextBoxColumn,
            this.商品コードDataGridViewTextBoxColumn,
            this.jANコードDataGridViewTextBoxColumn,
            this.インストアコードDataGridViewTextBoxColumn,
            this.通常原単価DataGridViewTextBoxColumn,
            this.売単価DataGridViewTextBoxColumn,
            this.単品重量DataGridViewTextBoxColumn,
            this.単位DataGridViewTextBoxColumn,
            this.pT単位かDataGridViewTextBoxColumn});
            this.productsDataGridView.ContextMenuStrip = this.productContextMenuStrip;
            this.productsDataGridView.DataSource = this.bindingSource1;
            this.productsDataGridView.Location = new System.Drawing.Point(16, 58);
            this.productsDataGridView.MultiSelect = false;
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.ReadOnly = true;
            this.productsDataGridView.RowHeadersVisible = false;
            this.productsDataGridView.RowTemplate.Height = 23;
            this.productsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsDataGridView.Size = new System.Drawing.Size(877, 367);
            this.productsDataGridView.TabIndex = 0;
            this.productsDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // 自社コードColumn1
            // 
            this.自社コードColumn1.DataPropertyName = "自社コード";
            this.自社コードColumn1.HeaderText = "自社コード";
            this.自社コードColumn1.Name = "自社コードColumn1";
            this.自社コードColumn1.ReadOnly = true;
            // 
            // 得意先Column1
            // 
            this.得意先Column1.DataPropertyName = "得意先";
            this.得意先Column1.HeaderText = "得意先";
            this.得意先Column1.Name = "得意先Column1";
            this.得意先Column1.ReadOnly = true;
            // 
            // ジャンルColumn1
            // 
            this.ジャンルColumn1.DataPropertyName = "ジャンル";
            this.ジャンルColumn1.HeaderText = "ジャンル";
            this.ジャンルColumn1.Name = "ジャンルColumn1";
            this.ジャンルColumn1.ReadOnly = true;
            // 
            // 商品名Column1
            // 
            this.商品名Column1.DataPropertyName = "商品名";
            this.商品名Column1.HeaderText = "商品名";
            this.商品名Column1.Name = "商品名Column1";
            this.商品名Column1.ReadOnly = true;
            this.商品名Column1.Width = 280;
            // 
            // 規格Column1
            // 
            this.規格Column1.DataPropertyName = "規格";
            this.規格Column1.HeaderText = "規格";
            this.規格Column1.Name = "規格Column1";
            this.規格Column1.ReadOnly = true;
            // 
            // PT入数Column1
            // 
            this.PT入数Column1.DataPropertyName = "PT入数";
            this.PT入数Column1.HeaderText = "PT入数";
            this.PT入数Column1.Name = "PT入数Column1";
            this.PT入数Column1.ReadOnly = true;
            // 
            // 商品コードColumn1
            // 
            this.商品コードColumn1.DataPropertyName = "商品コード";
            this.商品コードColumn1.HeaderText = "商品コード";
            this.商品コードColumn1.Name = "商品コードColumn1";
            this.商品コードColumn1.ReadOnly = true;
            // 
            // JANコードColumn1
            // 
            this.JANコードColumn1.DataPropertyName = "JANコード";
            this.JANコードColumn1.HeaderText = "JANコード";
            this.JANコードColumn1.Name = "JANコードColumn1";
            this.JANコードColumn1.ReadOnly = true;
            // 
            // インストアコードColumn1
            // 
            this.インストアコードColumn1.DataPropertyName = "インストアコード";
            this.インストアコードColumn1.HeaderText = "インストアコード";
            this.インストアコードColumn1.Name = "インストアコードColumn1";
            this.インストアコードColumn1.ReadOnly = true;
            this.インストアコードColumn1.Width = 140;
            // 
            // 単品重量Column1
            // 
            this.単品重量Column1.DataPropertyName = "単品重量";
            this.単品重量Column1.HeaderText = "単品重量";
            this.単品重量Column1.Name = "単品重量Column1";
            this.単品重量Column1.ReadOnly = true;
            // 
            // 単位Column1
            // 
            this.単位Column1.DataPropertyName = "単位";
            this.単位Column1.HeaderText = "単位";
            this.単位Column1.Name = "単位Column1";
            this.単位Column1.ReadOnly = true;
            // 
            // PT単位かColumn1
            // 
            this.PT単位かColumn1.DataPropertyName = "PT単位か";
            this.PT単位かColumn1.HeaderText = "PT単位か";
            this.PT単位かColumn1.Name = "PT単位かColumn1";
            this.PT単位かColumn1.ReadOnly = true;
            // 
            // btAddItem
            // 
            this.btAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddItem.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAddItem.Location = new System.Drawing.Point(787, 14);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(106, 32);
            this.btAddItem.TabIndex = 0;
            this.btAddItem.Text = "新規";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1005, 468);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.productsDataGridView);
            this.tabPage1.Controls.Add(this.btAddItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(997, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "商品情報";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.countyComboBox);
            this.tabPage2.Controls.Add(this.pricesDataGridView);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(997, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pricesDataGridView
            // 
            this.pricesDataGridView.AllowUserToAddRows = false;
            this.pricesDataGridView.AllowUserToDeleteRows = false;
            this.pricesDataGridView.AllowUserToResizeRows = false;
            this.pricesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pricesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pricesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.自社コードColumn2,
            this.商品名Column2,
            this.規格Column2,
            this.店番Column2,
            this.店名Column2,
            this.県別Column2,
            this.仕入原価Column2,
            this.通常原単価Column2,
            this.広告原単価Column2,
            this.特売原単価Column2,
            this.売単価Column2});
            this.pricesDataGridView.ContextMenuStrip = this.priceContextMenuStrip;
            this.pricesDataGridView.Location = new System.Drawing.Point(15, 92);
            this.pricesDataGridView.Name = "pricesDataGridView";
            this.pricesDataGridView.RowHeadersVisible = false;
            this.pricesDataGridView.RowTemplate.Height = 23;
            this.pricesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pricesDataGridView.Size = new System.Drawing.Size(966, 332);
            this.pricesDataGridView.TabIndex = 0;
            // 
            // 自社コードColumn2
            // 
            this.自社コードColumn2.DataPropertyName = "自社コード";
            this.自社コードColumn2.HeaderText = "自社コード";
            this.自社コードColumn2.Name = "自社コードColumn2";
            // 
            // 商品名Column2
            // 
            this.商品名Column2.DataPropertyName = "商品名";
            this.商品名Column2.HeaderText = "商品名";
            this.商品名Column2.Name = "商品名Column2";
            this.商品名Column2.Width = 200;
            // 
            // 規格Column2
            // 
            this.規格Column2.DataPropertyName = "規格";
            this.規格Column2.HeaderText = "規格";
            this.規格Column2.Name = "規格Column2";
            this.規格Column2.Width = 180;
            // 
            // 店番Column2
            // 
            this.店番Column2.DataPropertyName = "店番";
            this.店番Column2.HeaderText = "店番";
            this.店番Column2.Name = "店番Column2";
            // 
            // 店名Column2
            // 
            this.店名Column2.DataPropertyName = "店名";
            this.店名Column2.HeaderText = "店名";
            this.店名Column2.Name = "店名Column2";
            // 
            // 県別Column2
            // 
            this.県別Column2.DataPropertyName = "県別";
            this.県別Column2.HeaderText = "県別";
            this.県別Column2.Name = "県別Column2";
            // 
            // 仕入原価Column2
            // 
            this.仕入原価Column2.DataPropertyName = "仕入原価";
            this.仕入原価Column2.HeaderText = "仕入原価";
            this.仕入原価Column2.Name = "仕入原価Column2";
            // 
            // 通常原単価Column2
            // 
            this.通常原単価Column2.DataPropertyName = "原単価";
            this.通常原単価Column2.HeaderText = "通常原単価";
            this.通常原単価Column2.Name = "通常原単価Column2";
            // 
            // 広告原単価Column2
            // 
            this.広告原単価Column2.DataPropertyName = "広告原単価";
            this.広告原単価Column2.HeaderText = "広告原単価";
            this.広告原単価Column2.Name = "広告原単価Column2";
            // 
            // 特売原単価Column2
            // 
            this.特売原単価Column2.DataPropertyName = "特売原単価";
            this.特売原単価Column2.HeaderText = "特売原単価";
            this.特売原単価Column2.Name = "特売原単価Column2";
            // 
            // 売単価Column2
            // 
            this.売単価Column2.DataPropertyName = "売単価";
            this.売単価Column2.HeaderText = "売単価";
            this.売単価Column2.Name = "売単価Column2";
            // 
            // priceContextMenuStrip
            // 
            this.priceContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPriceToolStripMenuItem});
            this.priceContextMenuStrip.Name = "priceContextMenuStrip";
            this.priceContextMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // editPriceToolStripMenuItem
            // 
            this.editPriceToolStripMenuItem.Name = "editPriceToolStripMenuItem";
            this.editPriceToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editPriceToolStripMenuItem.Text = "編集";
            this.editPriceToolStripMenuItem.Click += new System.EventHandler(this.editPriceToolStripMenuItem_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchButton.Location = new System.Drawing.Point(434, 17);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(102, 36);
            this.searchButton.TabIndex = 35;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(212, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 33;
            this.label14.Text = "商品";
            // 
            // storesComboBox
            // 
            this.storesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storesComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storesComboBox.FormattingEnabled = true;
            this.storesComboBox.Location = new System.Drawing.Point(253, 46);
            this.storesComboBox.Name = "storesComboBox";
            this.storesComboBox.Size = new System.Drawing.Size(155, 22);
            this.storesComboBox.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(212, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "店舗";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(24, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 39;
            this.label6.Text = "県別";
            // 
            // countyComboBox
            // 
            this.countyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countyComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.countyComboBox.FormattingEnabled = true;
            this.countyComboBox.Location = new System.Drawing.Point(65, 51);
            this.countyComboBox.Name = "countyComboBox";
            this.countyComboBox.Size = new System.Drawing.Size(155, 22);
            this.countyComboBox.TabIndex = 38;
            this.countyComboBox.SelectedIndexChanged += new System.EventHandler(this.countyComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.storesComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.genresComboBox);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.productsComboBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 77);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updateButton);
            this.groupBox2.Controls.Add(this.costTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(587, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 77);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(171, 15);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(102, 36);
            this.updateButton.TabIndex = 11;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(65, 17);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(100, 21);
            this.costTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "成本价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 44;
            this.label3.Text = "分类";
            // 
            // genresComboBox
            // 
            this.genresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genresComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.genresComboBox.FormattingEnabled = true;
            this.genresComboBox.Location = new System.Drawing.Point(49, 18);
            this.genresComboBox.Name = "genresComboBox";
            this.genresComboBox.Size = new System.Drawing.Size(155, 22);
            this.genresComboBox.TabIndex = 42;
            this.genresComboBox.SelectedIndexChanged += new System.EventHandler(this.genresComboBox_SelectedIndexChanged);
            // 
            // productsComboBox
            // 
            this.productsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productsComboBox.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(253, 18);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(155, 22);
            this.productsComboBox.TabIndex = 43;
            // 
            // 自社コードDataGridViewTextBoxColumn
            // 
            this.自社コードDataGridViewTextBoxColumn.DataPropertyName = "自社コード";
            this.自社コードDataGridViewTextBoxColumn.HeaderText = "自社コード";
            this.自社コードDataGridViewTextBoxColumn.Name = "自社コードDataGridViewTextBoxColumn";
            this.自社コードDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 得意先DataGridViewTextBoxColumn
            // 
            this.得意先DataGridViewTextBoxColumn.DataPropertyName = "得意先";
            this.得意先DataGridViewTextBoxColumn.HeaderText = "得意先";
            this.得意先DataGridViewTextBoxColumn.Name = "得意先DataGridViewTextBoxColumn";
            this.得意先DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ジャンルDataGridViewTextBoxColumn
            // 
            this.ジャンルDataGridViewTextBoxColumn.DataPropertyName = "ジャンル";
            this.ジャンルDataGridViewTextBoxColumn.HeaderText = "ジャンル";
            this.ジャンルDataGridViewTextBoxColumn.Name = "ジャンルDataGridViewTextBoxColumn";
            this.ジャンルDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 商品名DataGridViewTextBoxColumn
            // 
            this.商品名DataGridViewTextBoxColumn.DataPropertyName = "商品名";
            this.商品名DataGridViewTextBoxColumn.HeaderText = "商品名";
            this.商品名DataGridViewTextBoxColumn.Name = "商品名DataGridViewTextBoxColumn";
            this.商品名DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 規格DataGridViewTextBoxColumn
            // 
            this.規格DataGridViewTextBoxColumn.DataPropertyName = "規格";
            this.規格DataGridViewTextBoxColumn.HeaderText = "規格";
            this.規格DataGridViewTextBoxColumn.Name = "規格DataGridViewTextBoxColumn";
            this.規格DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pT入数DataGridViewTextBoxColumn
            // 
            this.pT入数DataGridViewTextBoxColumn.DataPropertyName = "PT入数";
            this.pT入数DataGridViewTextBoxColumn.HeaderText = "PT入数";
            this.pT入数DataGridViewTextBoxColumn.Name = "pT入数DataGridViewTextBoxColumn";
            this.pT入数DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 商品コードDataGridViewTextBoxColumn
            // 
            this.商品コードDataGridViewTextBoxColumn.DataPropertyName = "商品コード";
            this.商品コードDataGridViewTextBoxColumn.HeaderText = "商品コード";
            this.商品コードDataGridViewTextBoxColumn.Name = "商品コードDataGridViewTextBoxColumn";
            this.商品コードDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jANコードDataGridViewTextBoxColumn
            // 
            this.jANコードDataGridViewTextBoxColumn.DataPropertyName = "JANコード";
            this.jANコードDataGridViewTextBoxColumn.HeaderText = "JANコード";
            this.jANコードDataGridViewTextBoxColumn.Name = "jANコードDataGridViewTextBoxColumn";
            this.jANコードDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // インストアコードDataGridViewTextBoxColumn
            // 
            this.インストアコードDataGridViewTextBoxColumn.DataPropertyName = "インストアコード";
            this.インストアコードDataGridViewTextBoxColumn.HeaderText = "インストアコード";
            this.インストアコードDataGridViewTextBoxColumn.Name = "インストアコードDataGridViewTextBoxColumn";
            this.インストアコードDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 通常原単価DataGridViewTextBoxColumn
            // 
            this.通常原単価DataGridViewTextBoxColumn.DataPropertyName = "通常原単価";
            this.通常原単価DataGridViewTextBoxColumn.HeaderText = "通常原単価";
            this.通常原単価DataGridViewTextBoxColumn.Name = "通常原単価DataGridViewTextBoxColumn";
            this.通常原単価DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 売単価DataGridViewTextBoxColumn
            // 
            this.売単価DataGridViewTextBoxColumn.DataPropertyName = "売単価";
            this.売単価DataGridViewTextBoxColumn.HeaderText = "売単価";
            this.売単価DataGridViewTextBoxColumn.Name = "売単価DataGridViewTextBoxColumn";
            this.売単価DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 単品重量DataGridViewTextBoxColumn
            // 
            this.単品重量DataGridViewTextBoxColumn.DataPropertyName = "単品重量";
            this.単品重量DataGridViewTextBoxColumn.HeaderText = "単品重量";
            this.単品重量DataGridViewTextBoxColumn.Name = "単品重量DataGridViewTextBoxColumn";
            this.単品重量DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 単位DataGridViewTextBoxColumn
            // 
            this.単位DataGridViewTextBoxColumn.DataPropertyName = "単位";
            this.単位DataGridViewTextBoxColumn.HeaderText = "単位";
            this.単位DataGridViewTextBoxColumn.Name = "単位DataGridViewTextBoxColumn";
            this.単位DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pT単位かDataGridViewTextBoxColumn
            // 
            this.pT単位かDataGridViewTextBoxColumn.DataPropertyName = "PT単位か";
            this.pT単位かDataGridViewTextBoxColumn.HeaderText = "PT単位か";
            this.pT単位かDataGridViewTextBoxColumn.Name = "pT単位かDataGridViewTextBoxColumn";
            this.pT単位かDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "t_itemlist";
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // ProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(1005, 468);
            this.productContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pricesDataGridView)).EndInit();
            this.priceContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productsDataGridView;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 価格発動日DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入原価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単価DataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip productContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView pricesDataGridView;
        private System.Windows.Forms.BindingSource pricesBindingSource;
        private System.Windows.Forms.ContextMenuStrip priceContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editPriceToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コードColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店番Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入原価Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 通常原単価Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 広告原単価Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 特売原単価Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コードColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 得意先Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PT入数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コードColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn JANコードColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn インストアコードColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単品重量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単位Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PT単位かColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 得意先DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pT入数DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jANコードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn インストアコードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 通常原単価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単品重量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単位DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pT単位かDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox storesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox countyComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox genresComboBox;
        private System.Windows.Forms.ComboBox productsComboBox;
    }
}
