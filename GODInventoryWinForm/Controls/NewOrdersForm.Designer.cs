namespace GODInventoryWinForm.Controls
{
    partial class NewOrdersForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ordersTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.countyComboBox = new System.Windows.Forms.ComboBox();
            this.clearSelectButton = new System.Windows.Forms.Button();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shipperComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OrderReceivedAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店番Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNOColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ダブリColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.キャンセルColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiSpecificationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際出荷数量Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipperColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreDistrictColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncancleOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unduplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id受注データDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.tabControl1.SuspendLayout();
            this.ordersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ordersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(981, 400);
            this.tabControl1.TabIndex = 2;
            // 
            // ordersTabPage
            // 
            this.ordersTabPage.Controls.Add(this.label4);
            this.ordersTabPage.Controls.Add(this.countyComboBox);
            this.ordersTabPage.Controls.Add(this.clearSelectButton);
            this.ordersTabPage.Controls.Add(this.genreComboBox);
            this.ordersTabPage.Controls.Add(this.label3);
            this.ordersTabPage.Controls.Add(this.productComboBox);
            this.ordersTabPage.Controls.Add(this.label2);
            this.ordersTabPage.Controls.Add(this.shipperComboBox);
            this.ordersTabPage.Controls.Add(this.label1);
            this.ordersTabPage.Controls.Add(this.saveButton);
            this.ordersTabPage.Controls.Add(this.dataGridView1);
            this.ordersTabPage.Location = new System.Drawing.Point(4, 21);
            this.ordersTabPage.Name = "ordersTabPage";
            this.ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ordersTabPage.Size = new System.Drawing.Size(973, 375);
            this.ordersTabPage.TabIndex = 0;
            this.ordersTabPage.Text = "ダブリ確認";
            this.ordersTabPage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 11);
            this.label4.TabIndex = 100;
            this.label4.Text = "县别";
            // 
            // countyComboBox
            // 
            this.countyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countyComboBox.FormattingEnabled = true;
            this.countyComboBox.Location = new System.Drawing.Point(261, 8);
            this.countyComboBox.Name = "countyComboBox";
            this.countyComboBox.Size = new System.Drawing.Size(120, 19);
            this.countyComboBox.TabIndex = 99;
            this.countyComboBox.SelectedIndexChanged += new System.EventHandler(this.countyComboBox1_SelectedIndexChanged);
            // 
            // clearSelectButton
            // 
            this.clearSelectButton.Location = new System.Drawing.Point(396, 8);
            this.clearSelectButton.Name = "clearSelectButton";
            this.clearSelectButton.Size = new System.Drawing.Size(100, 41);
            this.clearSelectButton.TabIndex = 92;
            this.clearSelectButton.Text = "フィルターをリセット";
            this.clearSelectButton.UseVisualStyleBackColor = true;
            this.clearSelectButton.Click += new System.EventHandler(this.clearSelectButton_Click);
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(67, 30);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(120, 19);
            this.genreComboBox.TabIndex = 91;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.GenreNamecomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 11);
            this.label3.TabIndex = 90;
            this.label3.Text = "ｼﾞｬﾝﾙ";
            // 
            // productComboBox
            // 
            this.productComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(261, 30);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(120, 19);
            this.productComboBox.TabIndex = 89;
            this.productComboBox.SelectedIndexChanged += new System.EventHandler(this.productCombox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 11);
            this.label2.TabIndex = 88;
            this.label2.Text = "商品名";
            // 
            // shipperComboBox
            // 
            this.shipperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shipperComboBox.FormattingEnabled = true;
            this.shipperComboBox.Location = new System.Drawing.Point(67, 8);
            this.shipperComboBox.Name = "shipperComboBox";
            this.shipperComboBox.Size = new System.Drawing.Size(120, 19);
            this.shipperComboBox.TabIndex = 87;
            this.shipperComboBox.SelectedIndexChanged += new System.EventHandler(this.shipperComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 11);
            this.label1.TabIndex = 86;
            this.label1.Text = "配送担当";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(860, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "登録";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderReceivedAtColumn1,
            this.出荷日,
            this.納品日,
            this.店番Column1,
            this.StoreNameColumn1,
            this.InvoiceNOColumn1,
            this.ダブリColumn,
            this.キャンセルColumn,
            this.ジャンルColumn,
            this.ProductKanjiNameColumn1,
            this.ProductKanjiSpecificationColumn1,
            this.口数Column,
            this.実際出荷数量Column,
            this.ShipperColumn1,
            this.StoreDistrictColumn1,
            this.Column2});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 28;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(967, 320);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // OrderReceivedAtColumn1
            // 
            this.OrderReceivedAtColumn1.DataPropertyName = "受注日";
            this.OrderReceivedAtColumn1.HeaderText = "受注日";
            this.OrderReceivedAtColumn1.Name = "OrderReceivedAtColumn1";
            this.OrderReceivedAtColumn1.ReadOnly = true;
            this.OrderReceivedAtColumn1.Width = 90;
            // 
            // 出荷日
            // 
            this.出荷日.DataPropertyName = "出荷日";
            this.出荷日.HeaderText = "出荷日";
            this.出荷日.Name = "出荷日";
            this.出荷日.ReadOnly = true;
            this.出荷日.Width = 90;
            // 
            // 納品日
            // 
            this.納品日.DataPropertyName = "納品日";
            this.納品日.HeaderText = "納品日";
            this.納品日.Name = "納品日";
            this.納品日.ReadOnly = true;
            this.納品日.Width = 90;
            // 
            // 店番Column1
            // 
            this.店番Column1.DataPropertyName = "店舗コード";
            this.店番Column1.HeaderText = "店番";
            this.店番Column1.Name = "店番Column1";
            this.店番Column1.ReadOnly = true;
            this.店番Column1.Width = 80;
            // 
            // StoreNameColumn1
            // 
            this.StoreNameColumn1.DataPropertyName = "店舗名漢字";
            this.StoreNameColumn1.HeaderText = "店名";
            this.StoreNameColumn1.Name = "StoreNameColumn1";
            this.StoreNameColumn1.ReadOnly = true;
            // 
            // InvoiceNOColumn1
            // 
            this.InvoiceNOColumn1.DataPropertyName = "伝票番号";
            this.InvoiceNOColumn1.HeaderText = "伝票番号";
            this.InvoiceNOColumn1.Name = "InvoiceNOColumn1";
            this.InvoiceNOColumn1.ReadOnly = true;
            this.InvoiceNOColumn1.Width = 80;
            // 
            // ダブリColumn
            // 
            this.ダブリColumn.DataPropertyName = "ダブリ";
            this.ダブリColumn.HeaderText = "ダブリ";
            this.ダブリColumn.Name = "ダブリColumn";
            this.ダブリColumn.ReadOnly = true;
            this.ダブリColumn.Width = 60;
            // 
            // キャンセルColumn
            // 
            this.キャンセルColumn.DataPropertyName = "キャンセル";
            this.キャンセルColumn.HeaderText = "キャンセル";
            this.キャンセルColumn.Name = "キャンセルColumn";
            this.キャンセルColumn.ReadOnly = true;
            this.キャンセルColumn.Width = 80;
            // 
            // ジャンルColumn
            // 
            this.ジャンルColumn.DataPropertyName = "ジャンル";
            this.ジャンルColumn.HeaderText = "ジャンル";
            this.ジャンルColumn.Name = "ジャンルColumn";
            this.ジャンルColumn.ReadOnly = true;
            this.ジャンルColumn.Width = 80;
            // 
            // ProductKanjiNameColumn1
            // 
            this.ProductKanjiNameColumn1.DataPropertyName = "品名漢字";
            this.ProductKanjiNameColumn1.HeaderText = "品名漢字";
            this.ProductKanjiNameColumn1.Name = "ProductKanjiNameColumn1";
            this.ProductKanjiNameColumn1.ReadOnly = true;
            this.ProductKanjiNameColumn1.Width = 120;
            // 
            // ProductKanjiSpecificationColumn1
            // 
            this.ProductKanjiSpecificationColumn1.DataPropertyName = "規格名漢字";
            this.ProductKanjiSpecificationColumn1.HeaderText = "規格名漢字";
            this.ProductKanjiSpecificationColumn1.Name = "ProductKanjiSpecificationColumn1";
            this.ProductKanjiSpecificationColumn1.ReadOnly = true;
            // 
            // 口数Column
            // 
            this.口数Column.DataPropertyName = "納品口数";
            this.口数Column.HeaderText = "口数";
            this.口数Column.Name = "口数Column";
            this.口数Column.ReadOnly = true;
            this.口数Column.Width = 60;
            // 
            // 実際出荷数量Column
            // 
            this.実際出荷数量Column.DataPropertyName = "実際出荷数量";
            this.実際出荷数量Column.HeaderText = "発注数量";
            this.実際出荷数量Column.Name = "実際出荷数量Column";
            this.実際出荷数量Column.ReadOnly = true;
            this.実際出荷数量Column.Width = 80;
            // 
            // ShipperColumn1
            // 
            this.ShipperColumn1.DataPropertyName = "実際配送担当";
            this.ShipperColumn1.HeaderText = "担当";
            this.ShipperColumn1.Name = "ShipperColumn1";
            this.ShipperColumn1.ReadOnly = true;
            this.ShipperColumn1.Width = 80;
            // 
            // StoreDistrictColumn1
            // 
            this.StoreDistrictColumn1.DataPropertyName = "県別";
            this.StoreDistrictColumn1.HeaderText = "県別";
            this.StoreDistrictColumn1.Name = "StoreDistrictColumn1";
            this.StoreDistrictColumn1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "発注形態名称漢字";
            this.Column2.HeaderText = "形態";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelOrderToolStripMenuItem,
            this.uncancleOrderToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.unduplicateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 92);
            // 
            // cancelOrderToolStripMenuItem
            // 
            this.cancelOrderToolStripMenuItem.Name = "cancelOrderToolStripMenuItem";
            this.cancelOrderToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.cancelOrderToolStripMenuItem.Text = "キャンセル確認";
            this.cancelOrderToolStripMenuItem.Click += new System.EventHandler(this.cancelOrderToolStripMenuItem_Click);
            // 
            // uncancleOrderToolStripMenuItem
            // 
            this.uncancleOrderToolStripMenuItem.Name = "uncancleOrderToolStripMenuItem";
            this.uncancleOrderToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.uncancleOrderToolStripMenuItem.Text = "キャンセル解除";
            this.uncancleOrderToolStripMenuItem.Click += new System.EventHandler(this.uncancleOrderToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.duplicateToolStripMenuItem.Text = "ダブり確認";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // unduplicateToolStripMenuItem
            // 
            this.unduplicateToolStripMenuItem.Name = "unduplicateToolStripMenuItem";
            this.unduplicateToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.unduplicateToolStripMenuItem.Text = "ダブリ解除";
            this.unduplicateToolStripMenuItem.Click += new System.EventHandler(this.unduplicateToolStripMenuItem_Click);
            // 
            // id受注データDataGridViewTextBoxColumn
            // 
            this.id受注データDataGridViewTextBoxColumn.DataPropertyName = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.HeaderText = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.Name = "id受注データDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // NewOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 400);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ダブリ確認";
            this.tabControl1.ResumeLayout(false);
            this.ordersTabPage.ResumeLayout(false);
            this.ordersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ordersTabPage;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem unduplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncancleOrderToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id受注データDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderReceivedAtColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店番Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNOColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ダブリColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセルColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiSpecificationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際出荷数量Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipperColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreDistrictColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button clearSelectButton;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox shipperComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox countyComboBox;
    }
}