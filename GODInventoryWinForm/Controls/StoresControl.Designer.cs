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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAddItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.店番DataGridViewTextBoxColumn,
            this.店名DataGridViewTextBoxColumn,
            this.店名カナDataGridViewTextBoxColumn,
            this.配送担当DataGridViewTextBoxColumn,
            this.郵便番号DataGridViewTextBoxColumn,
            this.県別DataGridViewTextBoxColumn,
            this.県内エリアDataGridViewTextBoxColumn,
            this.住所DataGridViewTextBoxColumn,
            this.電話番号DataGridViewTextBoxColumn,
            this.fAX番号DataGridViewTextBoxColumn});
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
            this.dataGridView1.Size = new System.Drawing.Size(632, 283);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeItem,
            this.addItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // ChangeItem
            // 
            this.ChangeItem.Name = "ChangeItem";
            this.ChangeItem.Size = new System.Drawing.Size(98, 22);
            this.ChangeItem.Text = "編集";
            this.ChangeItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 283);
            this.panel1.TabIndex = 1;
            // 
            // btAddItem
            // 
            this.btAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddItem.Location = new System.Drawing.Point(532, 9);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(100, 30);
            this.btAddItem.TabIndex = 2;
            this.btAddItem.Text = "新規";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // StoresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StoresControl";
            this.Size = new System.Drawing.Size(635, 327);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ChangeItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.Button btAddItem;
    }
}
