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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToShipperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView1.DataMember = "t_itemlist";
            this.dataGridView1.DataSource = this.entityDataSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(754, 421);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // 自社コードDataGridViewTextBoxColumn
            // 
            this.自社コードDataGridViewTextBoxColumn.DataPropertyName = "自社コード";
            this.自社コードDataGridViewTextBoxColumn.HeaderText = "自社コード";
            this.自社コードDataGridViewTextBoxColumn.Name = "自社コードDataGridViewTextBoxColumn";
            // 
            // 得意先DataGridViewTextBoxColumn
            // 
            this.得意先DataGridViewTextBoxColumn.DataPropertyName = "得意先";
            this.得意先DataGridViewTextBoxColumn.HeaderText = "得意先";
            this.得意先DataGridViewTextBoxColumn.Name = "得意先DataGridViewTextBoxColumn";
            // 
            // ジャンルDataGridViewTextBoxColumn
            // 
            this.ジャンルDataGridViewTextBoxColumn.DataPropertyName = "ジャンル";
            this.ジャンルDataGridViewTextBoxColumn.HeaderText = "ジャンル";
            this.ジャンルDataGridViewTextBoxColumn.Name = "ジャンルDataGridViewTextBoxColumn";
            // 
            // 商品名DataGridViewTextBoxColumn
            // 
            this.商品名DataGridViewTextBoxColumn.DataPropertyName = "商品名";
            this.商品名DataGridViewTextBoxColumn.HeaderText = "商品名";
            this.商品名DataGridViewTextBoxColumn.Name = "商品名DataGridViewTextBoxColumn";
            // 
            // 規格DataGridViewTextBoxColumn
            // 
            this.規格DataGridViewTextBoxColumn.DataPropertyName = "規格";
            this.規格DataGridViewTextBoxColumn.HeaderText = "規格";
            this.規格DataGridViewTextBoxColumn.Name = "規格DataGridViewTextBoxColumn";
            // 
            // pT入数DataGridViewTextBoxColumn
            // 
            this.pT入数DataGridViewTextBoxColumn.DataPropertyName = "PT入数";
            this.pT入数DataGridViewTextBoxColumn.HeaderText = "PT入数";
            this.pT入数DataGridViewTextBoxColumn.Name = "pT入数DataGridViewTextBoxColumn";
            // 
            // 商品コードDataGridViewTextBoxColumn
            // 
            this.商品コードDataGridViewTextBoxColumn.DataPropertyName = "商品コード";
            this.商品コードDataGridViewTextBoxColumn.HeaderText = "商品コード";
            this.商品コードDataGridViewTextBoxColumn.Name = "商品コードDataGridViewTextBoxColumn";
            // 
            // jANコードDataGridViewTextBoxColumn
            // 
            this.jANコードDataGridViewTextBoxColumn.DataPropertyName = "JANコード";
            this.jANコードDataGridViewTextBoxColumn.HeaderText = "JANコード";
            this.jANコードDataGridViewTextBoxColumn.Name = "jANコードDataGridViewTextBoxColumn";
            // 
            // インストアコードDataGridViewTextBoxColumn
            // 
            this.インストアコードDataGridViewTextBoxColumn.DataPropertyName = "インストアコード";
            this.インストアコードDataGridViewTextBoxColumn.HeaderText = "インストアコード";
            this.インストアコードDataGridViewTextBoxColumn.Name = "インストアコードDataGridViewTextBoxColumn";
            // 
            // 単品重量DataGridViewTextBoxColumn
            // 
            this.単品重量DataGridViewTextBoxColumn.DataPropertyName = "単品重量";
            this.単品重量DataGridViewTextBoxColumn.HeaderText = "単品重量";
            this.単品重量DataGridViewTextBoxColumn.Name = "単品重量DataGridViewTextBoxColumn";
            // 
            // 単位DataGridViewTextBoxColumn
            // 
            this.単位DataGridViewTextBoxColumn.DataPropertyName = "単位";
            this.単位DataGridViewTextBoxColumn.HeaderText = "単位";
            this.単位DataGridViewTextBoxColumn.Name = "単位DataGridViewTextBoxColumn";
            // 
            // pT単位かDataGridViewTextBoxColumn
            // 
            this.pT単位かDataGridViewTextBoxColumn.DataPropertyName = "PT単位か";
            this.pT単位かDataGridViewTextBoxColumn.HeaderText = "PT単位か";
            this.pT単位かDataGridViewTextBoxColumn.Name = "pT単位かDataGridViewTextBoxColumn";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 421);
            this.panel1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeToolStripMenuItem,
            this.addItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // ChangeToolStripMenuItem
            // 
            this.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            this.ChangeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ChangeToolStripMenuItem.Text = "Change Item";
            this.ChangeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToShipperToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(155, 26);
            // 
            // sendToShipperToolStripMenuItem
            // 
            this.sendToShipperToolStripMenuItem.Name = "sendToShipperToolStripMenuItem";
            this.sendToShipperToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendToShipperToolStripMenuItem.Text = "SendToShipper";
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addItemToolStripMenuItem.Text = "Add Item";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // ProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.panel1);
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(754, 475);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売価DataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 得意先DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 価格発動日DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pT入数DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入原価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単価DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jANコードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn インストアコードDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単品重量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単位DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pT単位かDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ChangeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem sendToShipperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
    }
}
