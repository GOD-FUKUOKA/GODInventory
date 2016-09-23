namespace GODInventoryWinForm.Controls
{
    partial class ShippingOrderForm
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uploadForEDIButton = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.GenerateASNButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pendingTabPage = new System.Windows.Forms.TabPage();
            this.shipNODataGridView = new System.Windows.Forms.DataGridView();
            this.ShipNOColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivedAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.districtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipperColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asnTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.データIDColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.管理連番Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.レコード件数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printForEDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shippedTabPage = new System.Windows.Forms.TabPage();
            this.pager3 = new GODInventoryWinForm.Controls.Pager();
            this.shippedDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedTabPage = new System.Windows.Forms.TabPage();
            this.finishOrderButton1 = new System.Windows.Forms.Button();
            this.receivedDataGridView = new System.Windows.Forms.DataGridView();
            this.納品日Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注日Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際出荷数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際配送担当Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領金額Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領差異数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領差異金額Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pendingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipNODataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.asnTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.shippedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shippedDataGridView)).BeginInit();
            this.receivedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receivedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadForEDIButton
            // 
            this.uploadForEDIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadForEDIButton.Location = new System.Drawing.Point(794, 14);
            this.uploadForEDIButton.Name = "uploadForEDIButton";
            this.uploadForEDIButton.Size = new System.Drawing.Size(100, 32);
            this.uploadForEDIButton.TabIndex = 2;
            this.uploadForEDIButton.Text = "ASNｱｯﾌﾟﾛｰﾄﾞ";
            this.uploadForEDIButton.UseVisualStyleBackColor = true;
            this.uploadForEDIButton.Click += new System.EventHandler(this.uploadForEDIButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // GenerateASNButton
            // 
            this.GenerateASNButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateASNButton.Location = new System.Drawing.Point(796, 14);
            this.GenerateASNButton.Name = "GenerateASNButton";
            this.GenerateASNButton.Size = new System.Drawing.Size(100, 32);
            this.GenerateASNButton.TabIndex = 3;
            this.GenerateASNButton.Text = "ASN生成";
            this.GenerateASNButton.UseVisualStyleBackColor = true;
            this.GenerateASNButton.Click += new System.EventHandler(this.generateASNButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pendingTabPage);
            this.tabControl1.Controls.Add(this.asnTabPage);
            this.tabControl1.Controls.Add(this.shippedTabPage);
            this.tabControl1.Controls.Add(this.receivedTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 369);
            this.tabControl1.TabIndex = 5;
            // 
            // pendingTabPage
            // 
            this.pendingTabPage.Controls.Add(this.shipNODataGridView);
            this.pendingTabPage.Controls.Add(this.GenerateASNButton);
            this.pendingTabPage.Location = new System.Drawing.Point(4, 22);
            this.pendingTabPage.Name = "pendingTabPage";
            this.pendingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pendingTabPage.Size = new System.Drawing.Size(909, 343);
            this.pendingTabPage.TabIndex = 0;
            this.pendingTabPage.Text = "Pending Shipment";
            this.pendingTabPage.UseVisualStyleBackColor = true;
            // 
            // shipNODataGridView
            // 
            this.shipNODataGridView.AllowUserToAddRows = false;
            this.shipNODataGridView.AllowUserToDeleteRows = false;
            this.shipNODataGridView.AllowUserToResizeColumns = false;
            this.shipNODataGridView.AllowUserToResizeRows = false;
            this.shipNODataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shipNODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipNODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShipNOColumn1,
            this.shipAtColumn,
            this.arrivedAtColumn,
            this.storeNameColumn,
            this.districtColumn,
            this.shipperColumn,
            this.weightColumn,
            this.totalPrice});
            this.shipNODataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.shipNODataGridView.Location = new System.Drawing.Point(3, 60);
            this.shipNODataGridView.MultiSelect = false;
            this.shipNODataGridView.Name = "shipNODataGridView";
            this.shipNODataGridView.ReadOnly = true;
            this.shipNODataGridView.RowHeadersVisible = false;
            this.shipNODataGridView.RowTemplate.Height = 23;
            this.shipNODataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shipNODataGridView.Size = new System.Drawing.Size(903, 279);
            this.shipNODataGridView.TabIndex = 5;
            this.shipNODataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.shipNODataGridView_CellFormatting);
            this.shipNODataGridView.CurrentCellChanged += new System.EventHandler(this.shipNODataGridView_CurrentCellChanged);
            this.shipNODataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.shipNODataGridView_RowPrePaint);
            // 
            // ShipNOColumn1
            // 
            this.ShipNOColumn1.DataPropertyName = "ShipNO";
            this.ShipNOColumn1.HeaderText = "配车单单号";
            this.ShipNOColumn1.Name = "ShipNOColumn1";
            this.ShipNOColumn1.ReadOnly = true;
            // 
            // shipAtColumn
            // 
            this.shipAtColumn.DataPropertyName = "出荷日";
            this.shipAtColumn.HeaderText = "出荷日";
            this.shipAtColumn.Name = "shipAtColumn";
            this.shipAtColumn.ReadOnly = true;
            // 
            // arrivedAtColumn
            // 
            this.arrivedAtColumn.DataPropertyName = "納品日";
            this.arrivedAtColumn.HeaderText = "納品日";
            this.arrivedAtColumn.Name = "arrivedAtColumn";
            this.arrivedAtColumn.ReadOnly = true;
            // 
            // storeNameColumn
            // 
            this.storeNameColumn.DataPropertyName = "店名";
            this.storeNameColumn.HeaderText = "店名";
            this.storeNameColumn.Name = "storeNameColumn";
            this.storeNameColumn.ReadOnly = true;
            // 
            // districtColumn
            // 
            this.districtColumn.DataPropertyName = "県別";
            this.districtColumn.HeaderText = "県別";
            this.districtColumn.Name = "districtColumn";
            this.districtColumn.ReadOnly = true;
            // 
            // shipperColumn
            // 
            this.shipperColumn.DataPropertyName = "実際配送担当";
            this.shipperColumn.HeaderText = "担当";
            this.shipperColumn.Name = "shipperColumn";
            this.shipperColumn.ReadOnly = true;
            // 
            // weightColumn
            // 
            this.weightColumn.DataPropertyName = "TotalWeight";
            this.weightColumn.HeaderText = "重量";
            this.weightColumn.Name = "weightColumn";
            this.weightColumn.ReadOnly = true;
            // 
            // totalPrice
            // 
            this.totalPrice.DataPropertyName = "TotalPrice";
            this.totalPrice.HeaderText = "原価金額(税抜)";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockToolStripMenuItem,
            this.unlockToolStripMenuItem,
            this.editToolStripMenuItem,
            this.printToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.lockToolStripMenuItem.Text = "配車表ﾛｯｸ";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.unlockToolStripMenuItem.Text = "ﾛｯｸ解消";
            this.unlockToolStripMenuItem.Click += new System.EventHandler(this.unlockToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.editToolStripMenuItem.Text = "編集";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.printToolStripMenuItem.Text = "配車表印刷";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // asnTabPage
            // 
            this.asnTabPage.Controls.Add(this.dataGridView2);
            this.asnTabPage.Controls.Add(this.uploadForEDIButton);
            this.asnTabPage.Location = new System.Drawing.Point(4, 22);
            this.asnTabPage.Name = "asnTabPage";
            this.asnTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.asnTabPage.Size = new System.Drawing.Size(909, 343);
            this.asnTabPage.TabIndex = 1;
            this.asnTabPage.Text = "ASN";
            this.asnTabPage.UseVisualStyleBackColor = true;
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
            this.データIDColumn1,
            this.管理連番Column1,
            this.レコード件数Column1,
            this.createdAtColumn1});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView2.Location = new System.Drawing.Point(3, 60);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(903, 280);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // データIDColumn1
            // 
            this.データIDColumn1.DataPropertyName = "データID";
            this.データIDColumn1.HeaderText = "データID";
            this.データIDColumn1.Name = "データIDColumn1";
            this.データIDColumn1.ReadOnly = true;
            // 
            // 管理連番Column1
            // 
            this.管理連番Column1.DataPropertyName = "管理連番";
            this.管理連番Column1.HeaderText = "管理連番";
            this.管理連番Column1.Name = "管理連番Column1";
            this.管理連番Column1.ReadOnly = true;
            // 
            // レコード件数Column1
            // 
            this.レコード件数Column1.DataPropertyName = "レコード件数";
            this.レコード件数Column1.HeaderText = "レコード件数";
            this.レコード件数Column1.Name = "レコード件数Column1";
            this.レコード件数Column1.ReadOnly = true;
            this.レコード件数Column1.Width = 120;
            // 
            // createdAtColumn1
            // 
            this.createdAtColumn1.DataPropertyName = "created_at";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.createdAtColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.createdAtColumn1.HeaderText = "作成時間";
            this.createdAtColumn1.Name = "createdAtColumn1";
            this.createdAtColumn1.ReadOnly = true;
            this.createdAtColumn1.Width = 120;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printForEDIToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // printForEDIToolStripMenuItem
            // 
            this.printForEDIToolStripMenuItem.Name = "printForEDIToolStripMenuItem";
            this.printForEDIToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.printForEDIToolStripMenuItem.Text = "印刷";
            this.printForEDIToolStripMenuItem.Click += new System.EventHandler(this.printForEDIToolStripMenuItem_Click);
            // 
            // shippedTabPage
            // 
            this.shippedTabPage.Controls.Add(this.pager3);
            this.shippedTabPage.Controls.Add(this.shippedDataGridView);
            this.shippedTabPage.Location = new System.Drawing.Point(4, 22);
            this.shippedTabPage.Name = "shippedTabPage";
            this.shippedTabPage.Size = new System.Drawing.Size(909, 343);
            this.shippedTabPage.TabIndex = 3;
            this.shippedTabPage.Text = "Shipped";
            this.shippedTabPage.UseVisualStyleBackColor = true;
            // 
            // pager3
            // 
            this.pager3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager3.AutoSize = true;
            this.pager3.Location = new System.Drawing.Point(3, 307);
            this.pager3.Name = "pager3";
            this.pager3.NMax = 0;
            this.pager3.PageCount = 0;
            this.pager3.PageCurrent = 1;
            this.pager3.PageSize = 5000;
            this.pager3.Size = new System.Drawing.Size(903, 34);
            this.pager3.TabIndex = 2;
            this.pager3.EventPaging += new GODInventoryWinForm.Controls.EventPagingHandler(this.pager3_EventPaging);
            // 
            // shippedDataGridView
            // 
            this.shippedDataGridView.AllowUserToAddRows = false;
            this.shippedDataGridView.AllowUserToDeleteRows = false;
            this.shippedDataGridView.AllowUserToResizeColumns = false;
            this.shippedDataGridView.AllowUserToResizeRows = false;
            this.shippedDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shippedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shippedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.shippedDataGridView.Location = new System.Drawing.Point(3, 29);
            this.shippedDataGridView.Name = "shippedDataGridView";
            this.shippedDataGridView.ReadOnly = true;
            this.shippedDataGridView.RowHeadersVisible = false;
            this.shippedDataGridView.RowTemplate.Height = 23;
            this.shippedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shippedDataGridView.Size = new System.Drawing.Size(903, 280);
            this.shippedDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "納品日";
            this.dataGridViewTextBoxColumn1.HeaderText = "納品日";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "受注日";
            this.dataGridViewTextBoxColumn2.HeaderText = "受注日";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "出荷日";
            this.dataGridViewTextBoxColumn3.HeaderText = "出荷日";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "店舗名漢字";
            this.dataGridViewTextBoxColumn4.HeaderText = "店舗名漢字";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "伝票番号";
            this.dataGridViewTextBoxColumn5.HeaderText = "伝票番号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "品名漢字";
            this.dataGridViewTextBoxColumn6.HeaderText = "品名漢字";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "規格名漢字";
            this.dataGridViewTextBoxColumn7.HeaderText = "規格名漢字";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "実際出荷数量";
            this.dataGridViewTextBoxColumn8.HeaderText = "実際出荷数量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "実際配送担当";
            this.dataGridViewTextBoxColumn9.HeaderText = "実際配送担当";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "受領";
            this.dataGridViewTextBoxColumn10.HeaderText = "受領";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "受領数量";
            this.dataGridViewTextBoxColumn11.HeaderText = "受領数量";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "受領金額";
            this.dataGridViewTextBoxColumn12.HeaderText = "受領金額";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "受領差異数量";
            this.dataGridViewTextBoxColumn13.HeaderText = "受領差異数量";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "受領差異金額";
            this.dataGridViewTextBoxColumn14.HeaderText = "受領差異金額";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // receivedTabPage
            // 
            this.receivedTabPage.Controls.Add(this.finishOrderButton1);
            this.receivedTabPage.Controls.Add(this.receivedDataGridView);
            this.receivedTabPage.Location = new System.Drawing.Point(4, 22);
            this.receivedTabPage.Name = "receivedTabPage";
            this.receivedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.receivedTabPage.Size = new System.Drawing.Size(909, 343);
            this.receivedTabPage.TabIndex = 2;
            this.receivedTabPage.Text = "Received confirm";
            this.receivedTabPage.UseVisualStyleBackColor = true;
            // 
            // finishOrderButton1
            // 
            this.finishOrderButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.finishOrderButton1.Location = new System.Drawing.Point(796, 14);
            this.finishOrderButton1.Name = "finishOrderButton1";
            this.finishOrderButton1.Size = new System.Drawing.Size(100, 32);
            this.finishOrderButton1.TabIndex = 1;
            this.finishOrderButton1.Text = "ｵｰﾀﾞｰ確認済み";
            this.finishOrderButton1.UseVisualStyleBackColor = true;
            this.finishOrderButton1.Click += new System.EventHandler(this.finishOrderButton1_Click);
            // 
            // receivedDataGridView
            // 
            this.receivedDataGridView.AllowUserToAddRows = false;
            this.receivedDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receivedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receivedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.納品日Column21,
            this.受注日Column21,
            this.出荷日Column21,
            this.店舗名漢字Column1,
            this.伝票番号Column21,
            this.品名漢字Column21,
            this.規格名漢字Column21,
            this.実際出荷数量Column1,
            this.実際配送担当Column21,
            this.受領Column1,
            this.受領数量Column1,
            this.受領金額Column1,
            this.受領差異数量Column1,
            this.受領差異金額Column1});
            this.receivedDataGridView.Location = new System.Drawing.Point(3, 60);
            this.receivedDataGridView.Name = "receivedDataGridView";
            this.receivedDataGridView.RowHeadersVisible = false;
            this.receivedDataGridView.RowTemplate.Height = 23;
            this.receivedDataGridView.Size = new System.Drawing.Size(903, 280);
            this.receivedDataGridView.TabIndex = 0;
            // 
            // 納品日Column21
            // 
            this.納品日Column21.DataPropertyName = "納品日";
            this.納品日Column21.HeaderText = "納品日";
            this.納品日Column21.Name = "納品日Column21";
            // 
            // 受注日Column21
            // 
            this.受注日Column21.DataPropertyName = "受注日";
            this.受注日Column21.HeaderText = "受注日";
            this.受注日Column21.Name = "受注日Column21";
            // 
            // 出荷日Column21
            // 
            this.出荷日Column21.DataPropertyName = "出荷日";
            this.出荷日Column21.HeaderText = "出荷日";
            this.出荷日Column21.Name = "出荷日Column21";
            // 
            // 店舗名漢字Column1
            // 
            this.店舗名漢字Column1.DataPropertyName = "店舗名漢字";
            this.店舗名漢字Column1.HeaderText = "店舗名漢字";
            this.店舗名漢字Column1.Name = "店舗名漢字Column1";
            this.店舗名漢字Column1.ReadOnly = true;
            // 
            // 伝票番号Column21
            // 
            this.伝票番号Column21.DataPropertyName = "伝票番号";
            this.伝票番号Column21.HeaderText = "伝票番号";
            this.伝票番号Column21.Name = "伝票番号Column21";
            this.伝票番号Column21.ReadOnly = true;
            // 
            // 品名漢字Column21
            // 
            this.品名漢字Column21.DataPropertyName = "品名漢字";
            this.品名漢字Column21.HeaderText = "品名漢字";
            this.品名漢字Column21.Name = "品名漢字Column21";
            this.品名漢字Column21.ReadOnly = true;
            // 
            // 規格名漢字Column21
            // 
            this.規格名漢字Column21.DataPropertyName = "規格名漢字";
            this.規格名漢字Column21.HeaderText = "規格名漢字";
            this.規格名漢字Column21.Name = "規格名漢字Column21";
            this.規格名漢字Column21.ReadOnly = true;
            // 
            // 実際出荷数量Column1
            // 
            this.実際出荷数量Column1.DataPropertyName = "実際出荷数量";
            this.実際出荷数量Column1.HeaderText = "実際出荷数量";
            this.実際出荷数量Column1.Name = "実際出荷数量Column1";
            this.実際出荷数量Column1.ReadOnly = true;
            // 
            // 実際配送担当Column21
            // 
            this.実際配送担当Column21.DataPropertyName = "実際配送担当";
            this.実際配送担当Column21.HeaderText = "実際配送担当";
            this.実際配送担当Column21.Name = "実際配送担当Column21";
            this.実際配送担当Column21.ReadOnly = true;
            // 
            // 受領Column1
            // 
            this.受領Column1.DataPropertyName = "受領";
            this.受領Column1.HeaderText = "受領";
            this.受領Column1.Name = "受領Column1";
            this.受領Column1.ReadOnly = true;
            // 
            // 受領数量Column1
            // 
            this.受領数量Column1.DataPropertyName = "受領数量";
            this.受領数量Column1.HeaderText = "受領数量";
            this.受領数量Column1.Name = "受領数量Column1";
            this.受領数量Column1.ReadOnly = true;
            // 
            // 受領金額Column1
            // 
            this.受領金額Column1.DataPropertyName = "受領金額";
            this.受領金額Column1.HeaderText = "受領金額";
            this.受領金額Column1.Name = "受領金額Column1";
            this.受領金額Column1.ReadOnly = true;
            // 
            // 受領差異数量Column1
            // 
            this.受領差異数量Column1.DataPropertyName = "受領差異数量";
            this.受領差異数量Column1.HeaderText = "受領差異数量";
            this.受領差異数量Column1.Name = "受領差異数量Column1";
            this.受領差異数量Column1.ReadOnly = true;
            // 
            // 受領差異金額Column1
            // 
            this.受領差異金額Column1.DataPropertyName = "受領差異金額";
            this.受領差異金額Column1.HeaderText = "受領差異金額";
            this.受領差異金額Column1.Name = "受領差異金額Column1";
            this.受領差異金額Column1.ReadOnly = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // ShippingOrderForm
            // 
            this.ClientSize = new System.Drawing.Size(917, 369);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShippingOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShippingOrdersForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShippingOrderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shipNODataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.asnTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.shippedTabPage.ResumeLayout(false);
            this.shippedTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shippedDataGridView)).EndInit();
            this.receivedTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.receivedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button uploadForEDIButton;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button GenerateASNButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pendingTabPage;
        private System.Windows.Forms.TabPage asnTabPage;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.TabPage receivedTabPage;
        private System.Windows.Forms.DataGridView receivedDataGridView;
        private System.Windows.Forms.Button finishOrderButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注日Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際出荷数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際配送担当Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領金額Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領差異数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領差異金額Column1;
        private System.Windows.Forms.BindingSource bindingSource4;
        private System.Windows.Forms.DataGridView shipNODataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipNOColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivedAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn districtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipperColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn データIDColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 管理連番Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn レコード件数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtColumn1;
        private System.Windows.Forms.TabPage shippedTabPage;
        private Pager pager3;
        private System.Windows.Forms.DataGridView shippedDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem printForEDIToolStripMenuItem;
    }
}