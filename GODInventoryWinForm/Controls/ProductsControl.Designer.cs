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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.自社コードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.得意先DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pT入数DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jANコードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.インストアコードDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単品重量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単位DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pT単位かDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeToolStripMenuItem,
            this.addItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 388);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.単品重量DataGridViewTextBoxColumn,
            this.単位DataGridViewTextBoxColumn,
            this.pT単位かDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(754, 388);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
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
            this.btAddItem.Location = new System.Drawing.Point(645, 8);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(106, 32);
            this.btAddItem.TabIndex = 0;
            this.btAddItem.Text = "新規";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
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
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(754, 439);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売価DataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 価格発動日DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入原価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単価DataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.BindingSource bindingSource1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 単品重量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単位DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pT単位かDataGridViewTextBoxColumn;
    }
}
