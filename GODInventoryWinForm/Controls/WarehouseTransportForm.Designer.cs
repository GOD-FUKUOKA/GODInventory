namespace GODInventoryWinForm.Controls
{
    partial class WarehouseTransportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.indexColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipperName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transport_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addtsButton = new System.Windows.Forms.Button();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btAddWarehouse = new System.Windows.Forms.Button();
            this.bteditwh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btloadTransport = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btaddtransportitem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btremovetransportItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(748, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 22);
            this.button1.TabIndex = 66;
            this.button1.Text = "编辑";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexColumn1,
            this.ShipperName,
            this.Transport_name,
            this.deleteButtonColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(281, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(324, 412);
            this.dataGridView1.TabIndex = 56;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // indexColumn1
            // 
            this.indexColumn1.HeaderText = "序号";
            this.indexColumn1.Name = "indexColumn1";
            // 
            // ShipperName
            // 
            this.ShipperName.DataPropertyName = "ShipperName";
            this.ShipperName.HeaderText = "仓库";
            this.ShipperName.Name = "ShipperName";
            // 
            // Transport_name
            // 
            this.Transport_name.DataPropertyName = "Transport_name";
            this.Transport_name.HeaderText = "运输公司";
            this.Transport_name.Name = "Transport_name";
            // 
            // deleteButtonColumn
            // 
            this.deleteButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteButtonColumn.FillWeight = 30F;
            this.deleteButtonColumn.HeaderText = "";
            this.deleteButtonColumn.Name = "deleteButtonColumn";
            this.deleteButtonColumn.Text = "クリア";
            this.deleteButtonColumn.ToolTipText = "クリア";
            this.deleteButtonColumn.UseColumnTextForButtonValue = true;
            this.deleteButtonColumn.Width = 40;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.productToolStripMenuItem.Text = "商品選択";
            // 
            // addtsButton
            // 
            this.addtsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addtsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addtsButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addtsButton.Location = new System.Drawing.Point(808, 435);
            this.addtsButton.Name = "addtsButton";
            this.addtsButton.Size = new System.Drawing.Size(54, 22);
            this.addtsButton.TabIndex = 52;
            this.addtsButton.Text = "新建";
            this.addtsButton.UseVisualStyleBackColor = true;
            this.addtsButton.Click += new System.EventHandler(this.addtsButton_Click);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // btAddWarehouse
            // 
            this.btAddWarehouse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btAddWarehouse.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAddWarehouse.Location = new System.Drawing.Point(165, 435);
            this.btAddWarehouse.Name = "btAddWarehouse";
            this.btAddWarehouse.Size = new System.Drawing.Size(54, 22);
            this.btAddWarehouse.TabIndex = 52;
            this.btAddWarehouse.Text = "新建";
            this.btAddWarehouse.UseVisualStyleBackColor = true;
            this.btAddWarehouse.Click += new System.EventHandler(this.btAddWarehouse_Click);
            // 
            // bteditwh
            // 
            this.bteditwh.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bteditwh.Location = new System.Drawing.Point(105, 435);
            this.bteditwh.Name = "bteditwh";
            this.bteditwh.Size = new System.Drawing.Size(54, 22);
            this.bteditwh.TabIndex = 66;
            this.bteditwh.Text = "编辑";
            this.bteditwh.UseVisualStyleBackColor = true;
            this.bteditwh.Click += new System.EventHandler(this.bteditwh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(243, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 70;
            this.label2.Text = ">>>";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "仓库1",
            "仓库2",
            "仓库3"});
            this.listBox1.Location = new System.Drawing.Point(21, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(216, 412);
            this.listBox1.TabIndex = 68;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btloadTransport
            // 
            this.btloadTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btloadTransport.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btloadTransport.Location = new System.Drawing.Point(640, 435);
            this.btloadTransport.Name = "btloadTransport";
            this.btloadTransport.Size = new System.Drawing.Size(102, 22);
            this.btloadTransport.TabIndex = 71;
            this.btloadTransport.Text = "绑定运输公司";
            this.btloadTransport.UseVisualStyleBackColor = true;
            this.btloadTransport.Click += new System.EventHandler(this.btloadTransport_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Items.AddRange(new object[] {
            "运输公司1",
            "运输公司2",
            "运输公司3"});
            this.listBox2.Location = new System.Drawing.Point(697, 17);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(165, 412);
            this.listBox2.TabIndex = 72;
            // 
            // btaddtransportitem
            // 
            this.btaddtransportitem.Location = new System.Drawing.Point(622, 183);
            this.btaddtransportitem.Name = "btaddtransportitem";
            this.btaddtransportitem.Size = new System.Drawing.Size(51, 23);
            this.btaddtransportitem.TabIndex = 73;
            this.btaddtransportitem.Text = "<--";
            this.btaddtransportitem.UseVisualStyleBackColor = true;
            this.btaddtransportitem.Click += new System.EventHandler(this.btaddtransportitem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 74;
            this.label1.Text = "考虑使用listbox代替datagridview";
            // 
            // btremovetransportItem
            // 
            this.btremovetransportItem.Location = new System.Drawing.Point(622, 222);
            this.btremovetransportItem.Name = "btremovetransportItem";
            this.btremovetransportItem.Size = new System.Drawing.Size(51, 23);
            this.btremovetransportItem.TabIndex = 75;
            this.btremovetransportItem.Text = "-->";
            this.btremovetransportItem.UseVisualStyleBackColor = true;
            this.btremovetransportItem.Click += new System.EventHandler(this.btremovetransportItem_Click);
            // 
            // WarehouseTransportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 489);
            this.Controls.Add(this.btremovetransportItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btaddtransportitem);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btloadTransport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bteditwh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btAddWarehouse);
            this.Controls.Add(this.addtsButton);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WarehouseTransportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库和物流公司管理";
            this.Load += new System.EventHandler(this.CreateTransportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.Button addtsButton;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button bteditwh;
        private System.Windows.Forms.Button btAddWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipperName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transport_name;
        private System.Windows.Forms.DataGridViewButtonColumn deleteButtonColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btloadTransport;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btaddtransportitem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btremovetransportItem;
    }
}