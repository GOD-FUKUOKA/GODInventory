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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.btAddItem = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pricesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.売上ランク = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.営業担当 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店番DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名カナDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送担当DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.郵便番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県内エリアDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.住所DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.電話番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fAX番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.営業担当DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売上ランクDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参考店舗DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.transportidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.storesDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.売上ランク,
            this.営業担当,
            this.warehouse,
            this.transport,
            this.店番DataGridViewTextBoxColumn,
            this.店名DataGridViewTextBoxColumn,
            this.店名カナDataGridViewTextBoxColumn,
            this.配送担当DataGridViewTextBoxColumn,
            this.郵便番号DataGridViewTextBoxColumn,
            this.県別DataGridViewTextBoxColumn,
            this.県内エリアDataGridViewTextBoxColumn,
            this.住所DataGridViewTextBoxColumn,
            this.電話番号DataGridViewTextBoxColumn,
            this.fAX番号DataGridViewTextBoxColumn,
            this.営業担当DataGridViewTextBoxColumn,
            this.売上ランクDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.参考店舗DataGridViewTextBoxColumn,
            this.warehouseidDataGridViewTextBoxColumn,
            this.transportidDataGridViewTextBoxColumn});
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
            this.storesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.storesDataGridView_CellFormatting);
            this.storesDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
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
            // CustomerColumn1
            // 
            this.CustomerColumn1.DataPropertyName = "customerId";
            this.CustomerColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CustomerColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomerColumn1.HeaderText = "法人名";
            this.CustomerColumn1.Name = "CustomerColumn1";
            this.CustomerColumn1.ReadOnly = true;
            // 
            // 売上ランク
            // 
            this.売上ランク.DataPropertyName = "売上ランク";
            this.売上ランク.HeaderText = "売上ランク";
            this.売上ランク.Name = "売上ランク";
            this.売上ランク.ReadOnly = true;
            this.売上ランク.Width = 90;
            // 
            // 営業担当
            // 
            this.営業担当.DataPropertyName = "営業担当";
            this.営業担当.HeaderText = "営業担当";
            this.営業担当.Name = "営業担当";
            this.営業担当.ReadOnly = true;
            this.営業担当.Width = 80;
            // 
            // warehouse
            // 
            this.warehouse.DataPropertyName = "店番";
            this.warehouse.HeaderText = "仓库";
            this.warehouse.Name = "warehouse";
            this.warehouse.ReadOnly = true;
            // 
            // transport
            // 
            this.transport.DataPropertyName = "店番";
            this.transport.HeaderText = "运输公司";
            this.transport.Name = "transport";
            this.transport.ReadOnly = true;
            // 
            // 店番DataGridViewTextBoxColumn
            // 
            this.店番DataGridViewTextBoxColumn.DataPropertyName = "店番";
            this.店番DataGridViewTextBoxColumn.HeaderText = "店番";
            this.店番DataGridViewTextBoxColumn.Name = "店番DataGridViewTextBoxColumn";
            this.店番DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 店名DataGridViewTextBoxColumn
            // 
            this.店名DataGridViewTextBoxColumn.DataPropertyName = "店名";
            this.店名DataGridViewTextBoxColumn.HeaderText = "店名";
            this.店名DataGridViewTextBoxColumn.Name = "店名DataGridViewTextBoxColumn";
            this.店名DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 店名カナDataGridViewTextBoxColumn
            // 
            this.店名カナDataGridViewTextBoxColumn.DataPropertyName = "店名カナ";
            this.店名カナDataGridViewTextBoxColumn.HeaderText = "店名カナ";
            this.店名カナDataGridViewTextBoxColumn.Name = "店名カナDataGridViewTextBoxColumn";
            this.店名カナDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 配送担当DataGridViewTextBoxColumn
            // 
            this.配送担当DataGridViewTextBoxColumn.DataPropertyName = "配送担当";
            this.配送担当DataGridViewTextBoxColumn.HeaderText = "配送担当";
            this.配送担当DataGridViewTextBoxColumn.Name = "配送担当DataGridViewTextBoxColumn";
            this.配送担当DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 郵便番号DataGridViewTextBoxColumn
            // 
            this.郵便番号DataGridViewTextBoxColumn.DataPropertyName = "郵便番号";
            this.郵便番号DataGridViewTextBoxColumn.HeaderText = "郵便番号";
            this.郵便番号DataGridViewTextBoxColumn.Name = "郵便番号DataGridViewTextBoxColumn";
            this.郵便番号DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 県別DataGridViewTextBoxColumn
            // 
            this.県別DataGridViewTextBoxColumn.DataPropertyName = "県別";
            this.県別DataGridViewTextBoxColumn.HeaderText = "県別";
            this.県別DataGridViewTextBoxColumn.Name = "県別DataGridViewTextBoxColumn";
            this.県別DataGridViewTextBoxColumn.ReadOnly = true;
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
            // 営業担当DataGridViewTextBoxColumn
            // 
            this.営業担当DataGridViewTextBoxColumn.DataPropertyName = "営業担当";
            this.営業担当DataGridViewTextBoxColumn.HeaderText = "営業担当";
            this.営業担当DataGridViewTextBoxColumn.Name = "営業担当DataGridViewTextBoxColumn";
            this.営業担当DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 売上ランクDataGridViewTextBoxColumn
            // 
            this.売上ランクDataGridViewTextBoxColumn.DataPropertyName = "売上ランク";
            this.売上ランクDataGridViewTextBoxColumn.HeaderText = "売上ランク";
            this.売上ランクDataGridViewTextBoxColumn.Name = "売上ランクDataGridViewTextBoxColumn";
            this.売上ランクDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "customerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "customerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 参考店舗DataGridViewTextBoxColumn
            // 
            this.参考店舗DataGridViewTextBoxColumn.DataPropertyName = "参考店舗";
            this.参考店舗DataGridViewTextBoxColumn.HeaderText = "参考店舗";
            this.参考店舗DataGridViewTextBoxColumn.Name = "参考店舗DataGridViewTextBoxColumn";
            this.参考店舗DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // warehouseidDataGridViewTextBoxColumn
            // 
            this.warehouseidDataGridViewTextBoxColumn.DataPropertyName = "warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.warehouseidDataGridViewTextBoxColumn.HeaderText = "仓库";
            this.warehouseidDataGridViewTextBoxColumn.Name = "warehouseidDataGridViewTextBoxColumn";
            this.warehouseidDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.warehouseidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // transportidDataGridViewTextBoxColumn
            // 
            this.transportidDataGridViewTextBoxColumn.DataPropertyName = "transport_id";
            this.transportidDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.transportidDataGridViewTextBoxColumn.HeaderText = "运输公司";
            this.transportidDataGridViewTextBoxColumn.Name = "transportidDataGridViewTextBoxColumn";
            this.transportidDataGridViewTextBoxColumn.ReadOnly = true;
            this.transportidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.transportidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.BindingSource pricesBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売上ランク;
        private System.Windows.Forms.DataGridViewTextBoxColumn 営業担当;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn transport;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店番DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名カナDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 郵便番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県内エリアDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 住所DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 電話番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fAX番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 営業担当DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売上ランクDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参考店舗DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn warehouseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn transportidDataGridViewTextBoxColumn;
    }
}
