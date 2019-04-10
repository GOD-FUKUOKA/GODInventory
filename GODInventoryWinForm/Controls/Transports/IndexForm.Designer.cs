namespace GODInventoryWinForm.Controls.Transports
{
    partial class IndexForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btAddItem = new System.Windows.Forms.Button();
            this.shortname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shortname,
            this.fullnameColumn,
            this.addressColumn,
            this.phoneColumn,
            this.memoColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1035, 311);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editToolStripMenuItem.Text = "编辑";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // btAddItem
            // 
            this.btAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddItem.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAddItem.Location = new System.Drawing.Point(941, 34);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(106, 32);
            this.btAddItem.TabIndex = 1;
            this.btAddItem.Text = "新規";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // shortname
            // 
            this.shortname.DataPropertyName = "shortname";
            this.shortname.FillWeight = 10F;
            this.shortname.HeaderText = "英字記号";
            this.shortname.Name = "shortname";
            this.shortname.ReadOnly = true;
            // 
            // fullnameColumn
            // 
            this.fullnameColumn.DataPropertyName = "fullname";
            this.fullnameColumn.FillWeight = 15F;
            this.fullnameColumn.HeaderText = "全称";
            this.fullnameColumn.Name = "fullnameColumn";
            this.fullnameColumn.ReadOnly = true;
            // 
            // addressColumn
            // 
            this.addressColumn.DataPropertyName = "address";
            this.addressColumn.FillWeight = 35F;
            this.addressColumn.HeaderText = "住所";
            this.addressColumn.Name = "addressColumn";
            this.addressColumn.ReadOnly = true;
            // 
            // phoneColumn
            // 
            this.phoneColumn.DataPropertyName = "phone";
            this.phoneColumn.FillWeight = 10F;
            this.phoneColumn.HeaderText = "電話";
            this.phoneColumn.Name = "phoneColumn";
            this.phoneColumn.ReadOnly = true;
            // 
            // memoColumn
            // 
            this.memoColumn.DataPropertyName = "memo";
            this.memoColumn.FillWeight = 30F;
            this.memoColumn.HeaderText = "備考";
            this.memoColumn.Name = "memoColumn";
            this.memoColumn.ReadOnly = true;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 395);
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndexForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配送担当情報";
            this.Shown += new System.EventHandler(this.IndexForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoColumn;
    }
}