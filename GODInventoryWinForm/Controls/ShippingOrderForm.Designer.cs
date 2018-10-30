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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.districtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipperColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printForShipperToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asnTabPage = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ediDataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printForShipperToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.printForEDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canceledTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.uploadAsnButton = new System.Windows.Forms.Button();
            this.canceledDataGridView = new System.Windows.Forms.DataGridView();
            this.キャンセルColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.キャンセル時刻Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際配送担当Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂正理由区分Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.備考Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canceledContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelConfirmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shippedTabPage = new System.Windows.Forms.TabPage();
            this.shippedDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品場所名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.canceledBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.pager3 = new GODInventoryWinForm.Controls.Pager();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.printStateColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.配车单单号Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際配送担当Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額_税抜_Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pendingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipNODataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.asnTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ediDataGridView)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.canceledTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canceledDataGridView)).BeginInit();
            this.canceledContextMenuStrip.SuspendLayout();
            this.shippedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shippedDataGridView)).BeginInit();
            this.receivedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receivedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canceledBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource6)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadForEDIButton
            // 
            this.uploadForEDIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadForEDIButton.Location = new System.Drawing.Point(794, 14);
            this.uploadForEDIButton.Name = "uploadForEDIButton";
            this.uploadForEDIButton.Size = new System.Drawing.Size(106, 32);
            this.uploadForEDIButton.TabIndex = 0;
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
            this.GenerateASNButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GenerateASNButton.Location = new System.Drawing.Point(796, 14);
            this.GenerateASNButton.Name = "GenerateASNButton";
            this.GenerateASNButton.Size = new System.Drawing.Size(106, 32);
            this.GenerateASNButton.TabIndex = 0;
            this.GenerateASNButton.Text = "ASNデータ作成";
            this.GenerateASNButton.UseVisualStyleBackColor = true;
            this.GenerateASNButton.Click += new System.EventHandler(this.generateASNButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pendingTabPage);
            this.tabControl1.Controls.Add(this.asnTabPage);
            this.tabControl1.Controls.Add(this.canceledTabPage);
            this.tabControl1.Controls.Add(this.shippedTabPage);
            this.tabControl1.Controls.Add(this.receivedTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.pendingTabPage.Text = "出荷内容確認";
            this.pendingTabPage.UseVisualStyleBackColor = true;
            this.pendingTabPage.Click += new System.EventHandler(this.pendingTabPage_Click);
            // 
            // shipNODataGridView
            // 
            this.shipNODataGridView.AllowUserToAddRows = false;
            this.shipNODataGridView.AllowUserToDeleteRows = false;
            this.shipNODataGridView.AllowUserToResizeRows = false;
            this.shipNODataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shipNODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.shipNODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipNODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShipNOColumn1,
            this.shipAtColumn,
            this.arrivedAtColumn,
            this.districtColumn,
            this.shipperColumn,
            this.weightColumn,
            this.totalPrice});
            this.shipNODataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.shipNODataGridView.Location = new System.Drawing.Point(3, 60);
            this.shipNODataGridView.MultiSelect = false;
            this.shipNODataGridView.Name = "shipNODataGridView";
            this.shipNODataGridView.ReadOnly = true;
            this.shipNODataGridView.RowHeadersWidth = 28;
            this.shipNODataGridView.RowTemplate.Height = 23;
            this.shipNODataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shipNODataGridView.Size = new System.Drawing.Size(903, 280);
            this.shipNODataGridView.TabIndex = 5;
            this.shipNODataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.shipNODataGridView_CellFormatting);
            this.shipNODataGridView.CurrentCellChanged += new System.EventHandler(this.shipNODataGridView_CurrentCellChanged);
            this.shipNODataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.shipNODataGridView_RowPrePaint);
            // 
            // ShipNOColumn1
            // 
            this.ShipNOColumn1.DataPropertyName = "ShipNO";
            this.ShipNOColumn1.HeaderText = "出荷指示書番号";
            this.ShipNOColumn1.Name = "ShipNOColumn1";
            this.ShipNOColumn1.ReadOnly = true;
            this.ShipNOColumn1.Width = 280;
            // 
            // shipAtColumn
            // 
            this.shipAtColumn.DataPropertyName = "出荷日";
            this.shipAtColumn.HeaderText = "出荷日";
            this.shipAtColumn.Name = "shipAtColumn";
            this.shipAtColumn.ReadOnly = true;
            this.shipAtColumn.Width = 160;
            // 
            // arrivedAtColumn
            // 
            this.arrivedAtColumn.DataPropertyName = "納品日";
            this.arrivedAtColumn.HeaderText = "納品日";
            this.arrivedAtColumn.Name = "arrivedAtColumn";
            this.arrivedAtColumn.ReadOnly = true;
            this.arrivedAtColumn.Width = 160;
            // 
            // districtColumn
            // 
            this.districtColumn.DataPropertyName = "県別";
            this.districtColumn.HeaderText = "県別";
            this.districtColumn.Name = "districtColumn";
            this.districtColumn.ReadOnly = true;
            this.districtColumn.Width = 120;
            // 
            // shipperColumn
            // 
            this.shipperColumn.DataPropertyName = "実際配送担当";
            this.shipperColumn.HeaderText = "担当";
            this.shipperColumn.Name = "shipperColumn";
            this.shipperColumn.ReadOnly = true;
            this.shipperColumn.Width = 120;
            // 
            // weightColumn
            // 
            this.weightColumn.DataPropertyName = "TotalWeight";
            this.weightColumn.HeaderText = "重量";
            this.weightColumn.Name = "weightColumn";
            this.weightColumn.ReadOnly = true;
            this.weightColumn.Width = 120;
            // 
            // totalPrice
            // 
            this.totalPrice.DataPropertyName = "TotalPrice";
            this.totalPrice.HeaderText = "原価金額(税抜)";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            this.totalPrice.Width = 160;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockToolStripMenuItem,
            this.unlockToolStripMenuItem,
            this.editToolStripMenuItem,
            this.printForShipperToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.lockToolStripMenuItem.Text = "配車表ﾛｯｸ";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.unlockToolStripMenuItem.Text = "ﾛｯｸ解消";
            this.unlockToolStripMenuItem.Click += new System.EventHandler(this.unlockToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.editToolStripMenuItem.Text = "編集";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // printForShipperToolStripMenuItem1
            // 
            this.printForShipperToolStripMenuItem1.Name = "printForShipperToolStripMenuItem1";
            this.printForShipperToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.printForShipperToolStripMenuItem1.Text = "ピッキングリスト印刷";
            this.printForShipperToolStripMenuItem1.Click += new System.EventHandler(this.printForShipperToolStripMenuItem1_Click);
            // 
            // asnTabPage
            // 
            this.asnTabPage.Controls.Add(this.button2);
            this.asnTabPage.Controls.Add(this.button1);
            this.asnTabPage.Controls.Add(this.ediDataGridView);
            this.asnTabPage.Controls.Add(this.uploadForEDIButton);
            this.asnTabPage.Location = new System.Drawing.Point(4, 22);
            this.asnTabPage.Name = "asnTabPage";
            this.asnTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.asnTabPage.Size = new System.Drawing.Size(909, 343);
            this.asnTabPage.TabIndex = 1;
            this.asnTabPage.Text = "納品書印刷";
            this.asnTabPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(686, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "変更を取消す";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(578, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "変更を保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ediDataGridView
            // 
            this.ediDataGridView.AllowUserToAddRows = false;
            this.ediDataGridView.AllowUserToDeleteRows = false;
            this.ediDataGridView.AllowUserToResizeRows = false;
            this.ediDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ediDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ediDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ediDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.printStateColumn,
            this.配车单单号Column1,
            this.出荷日Column1,
            this.納品日Column1,
            this.県別Column1,
            this.実際配送担当Column1,
            this.重量Column1,
            this.原価金額_税抜_Column1});
            this.ediDataGridView.ContextMenuStrip = this.contextMenuStrip2;
            this.ediDataGridView.Location = new System.Drawing.Point(3, 60);
            this.ediDataGridView.Name = "ediDataGridView";
            this.ediDataGridView.RowTemplate.Height = 23;
            this.ediDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ediDataGridView.Size = new System.Drawing.Size(903, 280);
            this.ediDataGridView.TabIndex = 3;
            this.ediDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ediDataGridView_CellBeginEdit);
            this.ediDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ediDataGridView_CellEndEdit);
            this.ediDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ediDataGridView_CellFormatting);
            this.ediDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.ediDataGridView_RowPrePaint);
            this.ediDataGridView.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printForShipperToolStripMenuItem2,
            this.printForEDIToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(197, 48);
            // 
            // printForShipperToolStripMenuItem2
            // 
            this.printForShipperToolStripMenuItem2.Name = "printForShipperToolStripMenuItem2";
            this.printForShipperToolStripMenuItem2.Size = new System.Drawing.Size(196, 22);
            this.printForShipperToolStripMenuItem2.Text = "ピッキングリスト印刷";
            this.printForShipperToolStripMenuItem2.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printForEDIToolStripMenuItem
            // 
            this.printForEDIToolStripMenuItem.Name = "printForEDIToolStripMenuItem";
            this.printForEDIToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.printForEDIToolStripMenuItem.Text = "納品書印刷";
            this.printForEDIToolStripMenuItem.Click += new System.EventHandler(this.printForEDIToolStripMenuItem_Click);
            // 
            // canceledTabPage
            // 
            this.canceledTabPage.Controls.Add(this.saveButton);
            this.canceledTabPage.Controls.Add(this.cancelButton);
            this.canceledTabPage.Controls.Add(this.uploadAsnButton);
            this.canceledTabPage.Controls.Add(this.canceledDataGridView);
            this.canceledTabPage.Location = new System.Drawing.Point(4, 22);
            this.canceledTabPage.Name = "canceledTabPage";
            this.canceledTabPage.Size = new System.Drawing.Size(909, 343);
            this.canceledTabPage.TabIndex = 4;
            this.canceledTabPage.Text = "Canceled";
            this.canceledTabPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.saveButton.Location = new System.Drawing.Point(579, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(106, 32);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "変更を保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelButton.Location = new System.Drawing.Point(687, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(106, 32);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "変更を取消す";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // uploadAsnButton
            // 
            this.uploadAsnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadAsnButton.Location = new System.Drawing.Point(795, 13);
            this.uploadAsnButton.Name = "uploadAsnButton";
            this.uploadAsnButton.Size = new System.Drawing.Size(106, 32);
            this.uploadAsnButton.TabIndex = 1;
            this.uploadAsnButton.Text = "ASNｱｯﾌﾟﾛｰﾄﾞ";
            this.uploadAsnButton.UseVisualStyleBackColor = true;
            this.uploadAsnButton.Click += new System.EventHandler(this.canceledButton1_Click);
            // 
            // canceledDataGridView
            // 
            this.canceledDataGridView.AllowUserToAddRows = false;
            this.canceledDataGridView.AllowUserToDeleteRows = false;
            this.canceledDataGridView.AllowUserToResizeColumns = false;
            this.canceledDataGridView.AllowUserToResizeRows = false;
            this.canceledDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canceledDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.canceledDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.キャンセルColumn1,
            this.キャンセル時刻Column1,
            this.発注日Column1,
            this.受注日Column1,
            this.出荷日Column2,
            this.納品日Column2,
            this.店舗名漢字Column2,
            this.県別Column2,
            this.伝票番号Column1,
            this.品名漢字Column1,
            this.規格名漢字Column1,
            this.発注数量Column1,
            this.実際配送担当Column2,
            this.訂正理由区分Column1,
            this.備考Column1});
            this.canceledDataGridView.ContextMenuStrip = this.canceledContextMenuStrip;
            this.canceledDataGridView.Location = new System.Drawing.Point(3, 61);
            this.canceledDataGridView.Name = "canceledDataGridView";
            this.canceledDataGridView.RowHeadersVisible = false;
            this.canceledDataGridView.RowTemplate.Height = 23;
            this.canceledDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.canceledDataGridView.Size = new System.Drawing.Size(903, 279);
            this.canceledDataGridView.TabIndex = 0;
            this.canceledDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.canceledDataGridView_CellBeginEdit);
            this.canceledDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.canceledDataGridView_CellEndEdit);
            this.canceledDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.canceledDataGridView_CellFormatting);
            this.canceledDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.canceledDataGridView_RowPrePaint);
            // 
            // キャンセルColumn1
            // 
            this.キャンセルColumn1.DataPropertyName = "キャンセル";
            this.キャンセルColumn1.HeaderText = "キャンセル";
            this.キャンセルColumn1.Name = "キャンセルColumn1";
            // 
            // キャンセル時刻Column1
            // 
            this.キャンセル時刻Column1.DataPropertyName = "キャンセル時刻";
            this.キャンセル時刻Column1.HeaderText = "キャンセル時刻";
            this.キャンセル時刻Column1.Name = "キャンセル時刻Column1";
            this.キャンセル時刻Column1.Width = 120;
            // 
            // 発注日Column1
            // 
            this.発注日Column1.DataPropertyName = "発注日";
            this.発注日Column1.HeaderText = "発注日";
            this.発注日Column1.Name = "発注日Column1";
            // 
            // 受注日Column1
            // 
            this.受注日Column1.DataPropertyName = "受注日";
            this.受注日Column1.HeaderText = "受注日";
            this.受注日Column1.Name = "受注日Column1";
            // 
            // 出荷日Column2
            // 
            this.出荷日Column2.DataPropertyName = "出荷日";
            this.出荷日Column2.HeaderText = "出荷日";
            this.出荷日Column2.Name = "出荷日Column2";
            // 
            // 納品日Column2
            // 
            this.納品日Column2.DataPropertyName = "納品日";
            this.納品日Column2.HeaderText = "納品日";
            this.納品日Column2.Name = "納品日Column2";
            // 
            // 店舗名漢字Column2
            // 
            this.店舗名漢字Column2.DataPropertyName = "店舗名漢字";
            this.店舗名漢字Column2.HeaderText = "店名";
            this.店舗名漢字Column2.Name = "店舗名漢字Column2";
            // 
            // 県別Column2
            // 
            this.県別Column2.DataPropertyName = "県別";
            this.県別Column2.HeaderText = "県別";
            this.県別Column2.Name = "県別Column2";
            // 
            // 伝票番号Column1
            // 
            this.伝票番号Column1.DataPropertyName = "伝票番号";
            this.伝票番号Column1.HeaderText = "伝票番号";
            this.伝票番号Column1.Name = "伝票番号Column1";
            // 
            // 品名漢字Column1
            // 
            this.品名漢字Column1.DataPropertyName = "品名漢字";
            this.品名漢字Column1.HeaderText = "品名";
            this.品名漢字Column1.Name = "品名漢字Column1";
            this.品名漢字Column1.Width = 200;
            // 
            // 規格名漢字Column1
            // 
            this.規格名漢字Column1.DataPropertyName = "規格名漢字";
            this.規格名漢字Column1.HeaderText = "規格名";
            this.規格名漢字Column1.Name = "規格名漢字Column1";
            this.規格名漢字Column1.Width = 200;
            // 
            // 発注数量Column1
            // 
            this.発注数量Column1.DataPropertyName = "発注数量";
            this.発注数量Column1.HeaderText = "発注数量";
            this.発注数量Column1.Name = "発注数量Column1";
            // 
            // 実際配送担当Column2
            // 
            this.実際配送担当Column2.DataPropertyName = "実際配送担当";
            this.実際配送担当Column2.HeaderText = "実際配送担当";
            this.実際配送担当Column2.Name = "実際配送担当Column2";
            this.実際配送担当Column2.Width = 120;
            // 
            // 訂正理由区分Column1
            // 
            this.訂正理由区分Column1.DataPropertyName = "訂正理由区分";
            this.訂正理由区分Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.訂正理由区分Column1.HeaderText = "訂正理由区分";
            this.訂正理由区分Column1.Name = "訂正理由区分Column1";
            this.訂正理由区分Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 備考Column1
            // 
            this.備考Column1.DataPropertyName = "備考";
            this.備考Column1.HeaderText = "備考";
            this.備考Column1.Name = "備考Column1";
            this.備考Column1.Width = 180;
            // 
            // canceledContextMenuStrip
            // 
            this.canceledContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelConfirmToolStripMenuItem});
            this.canceledContextMenuStrip.Name = "canceledContextMenuStrip";
            this.canceledContextMenuStrip.Size = new System.Drawing.Size(161, 26);
            // 
            // cancelConfirmToolStripMenuItem
            // 
            this.cancelConfirmToolStripMenuItem.Name = "cancelConfirmToolStripMenuItem";
            this.cancelConfirmToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelConfirmToolStripMenuItem.Text = "キャンセル確定";
            this.cancelConfirmToolStripMenuItem.Click += new System.EventHandler(this.cancelConfirmToolStripMenuItem_Click);
            // 
            // shippedTabPage
            // 
            this.shippedTabPage.Controls.Add(this.pager3);
            this.shippedTabPage.Controls.Add(this.shippedDataGridView);
            this.shippedTabPage.Location = new System.Drawing.Point(4, 22);
            this.shippedTabPage.Name = "shippedTabPage";
            this.shippedTabPage.Size = new System.Drawing.Size(909, 343);
            this.shippedTabPage.TabIndex = 3;
            this.shippedTabPage.Text = "出荷済み伝票";
            this.shippedTabPage.UseVisualStyleBackColor = true;
            // 
            // shippedDataGridView
            // 
            this.shippedDataGridView.AllowUserToAddRows = false;
            this.shippedDataGridView.AllowUserToDeleteRows = false;
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
            this.納品場所名漢字Column1,
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
            this.shippedDataGridView.Location = new System.Drawing.Point(3, 28);
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
            this.dataGridViewTextBoxColumn4.HeaderText = "店名";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 140;
            // 
            // 納品場所名漢字Column1
            // 
            this.納品場所名漢字Column1.DataPropertyName = "納品場所名漢字";
            this.納品場所名漢字Column1.HeaderText = "場所";
            this.納品場所名漢字Column1.Name = "納品場所名漢字Column1";
            this.納品場所名漢字Column1.ReadOnly = true;
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
            this.dataGridViewTextBoxColumn6.HeaderText = "品名";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 280;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "規格名漢字";
            this.dataGridViewTextBoxColumn7.HeaderText = "規格名";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 140;
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
            this.dataGridViewTextBoxColumn10.DataPropertyName = "受領確認";
            this.dataGridViewTextBoxColumn10.HeaderText = "受領確認";
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
            this.receivedTabPage.Text = "受領確認";
            this.receivedTabPage.UseVisualStyleBackColor = true;
            // 
            // finishOrderButton1
            // 
            this.finishOrderButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.finishOrderButton1.Location = new System.Drawing.Point(796, 14);
            this.finishOrderButton1.Name = "finishOrderButton1";
            this.finishOrderButton1.Size = new System.Drawing.Size(106, 32);
            this.finishOrderButton1.TabIndex = 0;
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
            this.receivedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            this.受領Column1.DataPropertyName = "受領確認";
            this.受領Column1.HeaderText = "受領確認";
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
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // printStateColumn
            // 
            this.printStateColumn.DataPropertyName = "reportState";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.printStateColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.printStateColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.printStateColumn.HeaderText = "印刷";
            this.printStateColumn.Name = "printStateColumn";
            this.printStateColumn.ReadOnly = true;
            this.printStateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.printStateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.printStateColumn.Width = 60;
            // 
            // 配车单单号Column1
            // 
            this.配车单单号Column1.DataPropertyName = "ShipNO";
            this.配车单单号Column1.HeaderText = "出荷指示書番号";
            this.配车单单号Column1.Name = "配车单单号Column1";
            this.配车单单号Column1.ReadOnly = true;
            this.配车单单号Column1.Width = 280;
            // 
            // 出荷日Column1
            // 
            this.出荷日Column1.DataPropertyName = "出荷日";
            this.出荷日Column1.HeaderText = "出荷日";
            this.出荷日Column1.Name = "出荷日Column1";
            this.出荷日Column1.Width = 160;
            // 
            // 納品日Column1
            // 
            this.納品日Column1.DataPropertyName = "納品日";
            this.納品日Column1.HeaderText = "納品日";
            this.納品日Column1.Name = "納品日Column1";
            this.納品日Column1.Width = 160;
            // 
            // 県別Column1
            // 
            this.県別Column1.DataPropertyName = "県別";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.県別Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.県別Column1.HeaderText = "県別";
            this.県別Column1.Name = "県別Column1";
            this.県別Column1.ReadOnly = true;
            this.県別Column1.Width = 120;
            // 
            // 実際配送担当Column1
            // 
            this.実際配送担当Column1.DataPropertyName = "実際配送担当";
            this.実際配送担当Column1.HeaderText = "実際配送担当";
            this.実際配送担当Column1.Name = "実際配送担当Column1";
            this.実際配送担当Column1.ReadOnly = true;
            this.実際配送担当Column1.Width = 120;
            // 
            // 重量Column1
            // 
            this.重量Column1.DataPropertyName = "TotalWeight";
            this.重量Column1.HeaderText = "重量";
            this.重量Column1.Name = "重量Column1";
            this.重量Column1.ReadOnly = true;
            this.重量Column1.Width = 120;
            // 
            // 原価金額_税抜_Column1
            // 
            this.原価金額_税抜_Column1.DataPropertyName = "TotalPrice";
            this.原価金額_税抜_Column1.HeaderText = "原価金額(税抜)";
            this.原価金額_税抜_Column1.Name = "原価金額_税抜_Column1";
            this.原価金額_税抜_Column1.ReadOnly = true;
            this.原価金額_税抜_Column1.Width = 140;
            // 
            // ShippingOrderForm
            // 
            this.ClientSize = new System.Drawing.Size(917, 369);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShippingOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出荷伝票処理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShippingOrderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.pendingTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shipNODataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.asnTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ediDataGridView)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.canceledTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canceledDataGridView)).EndInit();
            this.canceledContextMenuStrip.ResumeLayout(false);
            this.shippedTabPage.ResumeLayout(false);
            this.shippedTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shippedDataGridView)).EndInit();
            this.receivedTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.receivedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canceledBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource6)).EndInit();
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
        private System.Windows.Forms.DataGridView ediDataGridView;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.TabPage receivedTabPage;
        private System.Windows.Forms.DataGridView receivedDataGridView;
        private System.Windows.Forms.Button finishOrderButton1;
        private System.Windows.Forms.BindingSource bindingSource4;
        private System.Windows.Forms.DataGridView shipNODataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TabPage shippedTabPage;
        private Pager pager3;
        private System.Windows.Forms.DataGridView shippedDataGridView;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem printForEDIToolStripMenuItem;
        private System.Windows.Forms.TabPage canceledTabPage;
        private System.Windows.Forms.DataGridView canceledDataGridView;
        private System.Windows.Forms.Button uploadAsnButton;
        private System.Windows.Forms.BindingSource canceledBindingSource;
        private System.Windows.Forms.ToolStripMenuItem printForShipperToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem printForShipperToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip canceledContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cancelConfirmToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipNOColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivedAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn districtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipperColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品場所名漢字Column1;
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
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.BindingSource bindingSource6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセルColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル時刻Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際配送担当Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn 訂正理由区分Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考Column1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewComboBoxColumn printStateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配车单单号Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際配送担当Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額_税抜_Column1;
    }
}