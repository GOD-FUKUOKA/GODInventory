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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.printForEDIButton = new System.Windows.Forms.Button();
            this.uploadForEDIButton = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.generateASNButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.データIDColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.管理連番Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.レコード件数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryTabPage3 = new System.Windows.Forms.TabPage();
            this.finishOrderButton1 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
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
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipNODataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.deliveryTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // printForEDIButton
            // 
            this.printForEDIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printForEDIButton.Location = new System.Drawing.Point(688, 14);
            this.printForEDIButton.Name = "printForEDIButton";
            this.printForEDIButton.Size = new System.Drawing.Size(100, 32);
            this.printForEDIButton.TabIndex = 1;
            this.printForEDIButton.Text = "Print for EDI";
            this.printForEDIButton.UseVisualStyleBackColor = true;
            this.printForEDIButton.Click += new System.EventHandler(this.printForEDIButton_Click);
            // 
            // uploadForEDIButton
            // 
            this.uploadForEDIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadForEDIButton.Location = new System.Drawing.Point(794, 14);
            this.uploadForEDIButton.Name = "uploadForEDIButton";
            this.uploadForEDIButton.Size = new System.Drawing.Size(100, 32);
            this.uploadForEDIButton.TabIndex = 2;
            this.uploadForEDIButton.Text = "Upload for EDI";
            this.uploadForEDIButton.UseVisualStyleBackColor = true;
            this.uploadForEDIButton.Click += new System.EventHandler(this.uploadForEDIButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // generateASNButton
            // 
            this.generateASNButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateASNButton.Location = new System.Drawing.Point(796, 14);
            this.generateASNButton.Name = "generateASNButton";
            this.generateASNButton.Size = new System.Drawing.Size(100, 32);
            this.generateASNButton.TabIndex = 3;
            this.generateASNButton.Text = "GenerateASN";
            this.generateASNButton.UseVisualStyleBackColor = true;
            this.generateASNButton.Click += new System.EventHandler(this.generateASNButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.deliveryTabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 369);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.shipNODataGridView);
            this.tabPage1.Controls.Add(this.generateASNButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(909, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pending Shipment";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 92);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.unlockToolStripMenuItem.Text = "Unlock";
            this.unlockToolStripMenuItem.Click += new System.EventHandler(this.unlockToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.uploadForEDIButton);
            this.tabPage2.Controls.Add(this.printForEDIButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(909, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ASN";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // 
            // createdAtColumn1
            // 
            this.createdAtColumn1.DataPropertyName = "created_at";
            this.createdAtColumn1.HeaderText = "created_at";
            this.createdAtColumn1.Name = "createdAtColumn1";
            this.createdAtColumn1.ReadOnly = true;
            // 
            // deliveryTabPage3
            // 
            this.deliveryTabPage3.Controls.Add(this.finishOrderButton1);
            this.deliveryTabPage3.Controls.Add(this.dataGridView3);
            this.deliveryTabPage3.Location = new System.Drawing.Point(4, 22);
            this.deliveryTabPage3.Name = "deliveryTabPage3";
            this.deliveryTabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.deliveryTabPage3.Size = new System.Drawing.Size(909, 343);
            this.deliveryTabPage3.TabIndex = 2;
            this.deliveryTabPage3.Text = "Receiving confirm";
            this.deliveryTabPage3.UseVisualStyleBackColor = true;
            // 
            // finishOrderButton1
            // 
            this.finishOrderButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.finishOrderButton1.Location = new System.Drawing.Point(796, 14);
            this.finishOrderButton1.Name = "finishOrderButton1";
            this.finishOrderButton1.Size = new System.Drawing.Size(100, 32);
            this.finishOrderButton1.TabIndex = 1;
            this.finishOrderButton1.Text = "FinishOrder";
            this.finishOrderButton1.UseVisualStyleBackColor = true;
            this.finishOrderButton1.Click += new System.EventHandler(this.finishOrderButton1_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView3.Location = new System.Drawing.Point(3, 60);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(903, 280);
            this.dataGridView3.TabIndex = 0;
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
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shipNODataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.deliveryTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button printForEDIButton;
        private System.Windows.Forms.Button uploadForEDIButton;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button generateASNButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn データIDColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 管理連番Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn レコード件数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtColumn1;
        private System.Windows.Forms.TabPage deliveryTabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
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
        private System.Windows.Forms.BindingSource bindingSource3;
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
    }
}