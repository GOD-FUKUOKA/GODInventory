namespace GODInventoryWinForm.Controls
{
    partial class StoresControl
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
            this.storesDataGridView = new System.Windows.Forms.DataGridView();
            this.CustomerColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.店番DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名カナDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売上ランク = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送担当DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.郵便番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県内エリアDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.住所DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.電話番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fAX番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.営業担当 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
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
            this.storesComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.storesDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pricesDataGridView)).BeginInit();
            this.priceContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // storesDataGridView
            // 
            this.storesDataGridView.AllowUserToAddRows = false;
            this.storesDataGridView.AllowUserToDeleteRows = false;
            this.storesDataGridView.AllowUserToResizeRows = false;
            this.storesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storesDataGridView.AutoGenerateColumns = false;
            this.storesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerColumn1,
            this.店番DataGridViewTextBoxColumn,
            this.店名DataGridViewTextBoxColumn,
            this.店名カナDataGridViewTextBoxColumn,
            this.売上ランク,
            this.配送担当DataGridViewTextBoxColumn,
            this.郵便番号DataGridViewTextBoxColumn,
            this.県別DataGridViewTextBoxColumn,
            this.県内エリアDataGridViewTextBoxColumn,
            this.住所DataGridViewTextBoxColumn,
            this.電話番号DataGridViewTextBoxColumn,
            this.fAX番号DataGridViewTextBoxColumn,
            this.営業担当});
            this.storesDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.storesDataGridView.DataSource = this.bindingSource1;
            this.storesDataGridView.Location = new System.Drawing.Point(15, 61);
            this.storesDataGridView.MultiSelect = false;
            this.storesDataGridView.Name = "storesDataGridView";
            this.storesDataGridView.ReadOnly = true;
            this.storesDataGridView.RowHeadersVisible = false;
            this.storesDataGridView.RowTemplate.Height = 23;
            this.storesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.storesDataGridView.Size = new System.Drawing.Size(766, 351);
            this.storesDataGridView.TabIndex = 0;
            this.storesDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // CustomerColumn1
            // 
            this.CustomerColumn1.DataPropertyName = "customerId";
            this.CustomerColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CustomerColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomerColumn1.HeaderText = "法人名";
            this.CustomerColumn1.Name = "CustomerColumn1";
            this.CustomerColumn1.ReadOnly = true;
            // 
            // 店番DataGridViewTextBoxColumn
            // 
            this.店番DataGridViewTextBoxColumn.DataPropertyName = "店番";
            this.店番DataGridViewTextBoxColumn.HeaderText = "店番";
            this.店番DataGridViewTextBoxColumn.Name = "店番DataGridViewTextBoxColumn";
            this.店番DataGridViewTextBoxColumn.ReadOnly = true;
            this.店番DataGridViewTextBoxColumn.Width = 60;
            // 
            // 店名DataGridViewTextBoxColumn
            // 
            this.店名DataGridViewTextBoxColumn.DataPropertyName = "店名";
            this.店名DataGridViewTextBoxColumn.HeaderText = "店名";
            this.店名DataGridViewTextBoxColumn.Name = "店名DataGridViewTextBoxColumn";
            this.店名DataGridViewTextBoxColumn.ReadOnly = true;
            this.店名DataGridViewTextBoxColumn.Width = 180;
            // 
            // 店名カナDataGridViewTextBoxColumn
            // 
            this.店名カナDataGridViewTextBoxColumn.DataPropertyName = "店名カナ";
            this.店名カナDataGridViewTextBoxColumn.HeaderText = "店名カナ";
            this.店名カナDataGridViewTextBoxColumn.Name = "店名カナDataGridViewTextBoxColumn";
            this.店名カナDataGridViewTextBoxColumn.ReadOnly = true;
            this.店名カナDataGridViewTextBoxColumn.Width = 180;
            // 
            // 売上ランク
            // 
            this.売上ランク.DataPropertyName = "売上ランク";
            this.売上ランク.HeaderText = "売上ランク";
            this.売上ランク.Name = "売上ランク";
            this.売上ランク.ReadOnly = true;
            this.売上ランク.Width = 90;
            // 
            // 配送担当DataGridViewTextBoxColumn
            // 
            this.配送担当DataGridViewTextBoxColumn.DataPropertyName = "配送担当";
            this.配送担当DataGridViewTextBoxColumn.HeaderText = "配送担当";
            this.配送担当DataGridViewTextBoxColumn.Name = "配送担当DataGridViewTextBoxColumn";
            this.配送担当DataGridViewTextBoxColumn.ReadOnly = true;
            this.配送担当DataGridViewTextBoxColumn.Width = 80;
            // 
            // 郵便番号DataGridViewTextBoxColumn
            // 
            this.郵便番号DataGridViewTextBoxColumn.DataPropertyName = "郵便番号";
            this.郵便番号DataGridViewTextBoxColumn.HeaderText = "郵便番号";
            this.郵便番号DataGridViewTextBoxColumn.Name = "郵便番号DataGridViewTextBoxColumn";
            this.郵便番号DataGridViewTextBoxColumn.ReadOnly = true;
            this.郵便番号DataGridViewTextBoxColumn.Width = 80;
            // 
            // 県別DataGridViewTextBoxColumn
            // 
            this.県別DataGridViewTextBoxColumn.DataPropertyName = "県別";
            this.県別DataGridViewTextBoxColumn.HeaderText = "県別";
            this.県別DataGridViewTextBoxColumn.Name = "県別DataGridViewTextBoxColumn";
            this.県別DataGridViewTextBoxColumn.ReadOnly = true;
            this.県別DataGridViewTextBoxColumn.Width = 80;
            // 
            // 県内エリアDataGridViewTextBoxColumn
            // 
            this.県内エリアDataGridViewTextBoxColumn.DataPropertyName = "県内エリア";
            this.県内エリアDataGridViewTextBoxColumn.HeaderText = "県内エリア";
            this.県内エリアDataGridViewTextBoxColumn.Name = "県内エリアDataGridViewTextBoxColumn";
            this.県内エリアDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 住所DataGridViewTextBoxColumn
            // 
            this.住所DataGridViewTextBoxColumn.DataPropertyName = "住所";
            this.住所DataGridViewTextBoxColumn.HeaderText = "住所";
            this.住所DataGridViewTextBoxColumn.Name = "住所DataGridViewTextBoxColumn";
            this.住所DataGridViewTextBoxColumn.ReadOnly = true;
            this.住所DataGridViewTextBoxColumn.Width = 260;
            // 
            // 電話番号DataGridViewTextBoxColumn
            // 
            this.電話番号DataGridViewTextBoxColumn.DataPropertyName = "電話番号";
            this.電話番号DataGridViewTextBoxColumn.HeaderText = "電話番号";
            this.電話番号DataGridViewTextBoxColumn.Name = "電話番号DataGridViewTextBoxColumn";
            this.電話番号DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fAX番号DataGridViewTextBoxColumn
            // 
            this.fAX番号DataGridViewTextBoxColumn.DataPropertyName = "FAX番号";
            this.fAX番号DataGridViewTextBoxColumn.HeaderText = "FAX番号";
            this.fAX番号DataGridViewTextBoxColumn.Name = "fAX番号DataGridViewTextBoxColumn";
            this.fAX番号DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 営業担当
            // 
            this.営業担当.DataPropertyName = "営業担当";
            this.営業担当.HeaderText = "営業担当";
            this.営業担当.Name = "営業担当";
            this.営業担当.ReadOnly = true;
            this.営業担当.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeItem,
            this.addItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // ChangeItem
            // 
            this.ChangeItem.Name = "ChangeItem";
            this.ChangeItem.Size = new System.Drawing.Size(100, 22);
            this.ChangeItem.Text = "編集";
            this.ChangeItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.addItemToolStripMenuItem.Text = "新規";
            this.addItemToolStripMenuItem.Visible = false;
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "t_shoplist";
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Filter = "";
            this.bindingSource1.Position = 0;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // btAddItem
            // 
            this.btAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddItem.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAddItem.Location = new System.Drawing.Point(674, 15);
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
            this.tabControl1.Size = new System.Drawing.Size(804, 454);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.storesDataGridView);
            this.tabPage1.Controls.Add(this.btAddItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "店舗情報";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.searchButton);
            this.tabPage2.Controls.Add(this.storesComboBox);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.pricesDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 428);
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
            this.pricesDataGridView.Location = new System.Drawing.Point(15, 61);
            this.pricesDataGridView.Name = "pricesDataGridView";
            this.pricesDataGridView.RowHeadersVisible = false;
            this.pricesDataGridView.RowTemplate.Height = 23;
            this.pricesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pricesDataGridView.Size = new System.Drawing.Size(766, 353);
            this.pricesDataGridView.TabIndex = 1;
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
            // storesComboBox
            // 
            this.storesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storesComboBox.FormattingEnabled = true;
            this.storesComboBox.Location = new System.Drawing.Point(55, 23);
            this.storesComboBox.Name = "storesComboBox";
            this.storesComboBox.Size = new System.Drawing.Size(169, 20);
            this.storesComboBox.TabIndex = 31;
            this.storesComboBox.SelectedIndexChanged += new System.EventHandler(this.storesComboBox_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(14, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 30;
            this.label14.Text = "店舗";
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchButton.Location = new System.Drawing.Point(237, 23);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(106, 32);
            this.searchButton.TabIndex = 32;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // StoresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "StoresControl";
            this.Size = new System.Drawing.Size(804, 454);
            ((System.ComponentModel.ISupportInitialize)(this.storesDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pricesDataGridView)).EndInit();
            this.priceContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pricesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView storesDataGridView;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ChangeItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店番DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名カナDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売上ランク;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 郵便番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県内エリアDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 住所DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 電話番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fAX番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 営業担当;
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
        private System.Windows.Forms.ComboBox storesComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button searchButton;
    }
}
