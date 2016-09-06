﻿namespace GODInventoryWinForm.Controls
{
    partial class SearchStock
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
            this.warehouseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ioComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.IdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSpecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadItemListButton = new System.Windows.Forms.Button();
            this.qtyDataGridView = new System.Windows.Forms.DataGridView();
            this.btSave = new System.Windows.Forms.Button();
            this.btcanel = new System.Windows.Forms.Button();
            this.stockIoDataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockIoDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // warehouseComboBox
            // 
            this.warehouseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseComboBox.FormattingEnabled = true;
            this.warehouseComboBox.Location = new System.Drawing.Point(176, 26);
            this.warehouseComboBox.Name = "warehouseComboBox";
            this.warehouseComboBox.Size = new System.Drawing.Size(128, 21);
            this.warehouseComboBox.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "仓库";
            // 
            // ioComboBox
            // 
            this.ioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ioComboBox.FormattingEnabled = true;
            this.ioComboBox.Items.AddRange(new object[] {
            "全部",
            "入庫",
            "出庫"});
            this.ioComboBox.Location = new System.Drawing.Point(47, 26);
            this.ioComboBox.Name = "ioComboBox";
            this.ioComboBox.Size = new System.Drawing.Size(75, 21);
            this.ioComboBox.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "区分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "商品分类";
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(383, 26);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(128, 21);
            this.genreComboBox.TabIndex = 80;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "工厂";
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Items.AddRange(new object[] {
            "所有厂家"});
            this.manufacturerComboBox.Location = new System.Drawing.Point(571, 26);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(128, 21);
            this.manufacturerComboBox.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "期日";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(755, 26);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(112, 20);
            this.startDateTimePicker.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(871, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "～";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(892, 26);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(112, 20);
            this.endDateTimePicker.TabIndex = 86;
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.AllowUserToResizeColumns = false;
            this.productDataGridView.AllowUserToResizeRows = false;
            this.productDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.productDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.ColumnHeadersVisible = false;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDataGridViewTextBoxColumn,
            this.productCodeColumn,
            this.productNameColumn,
            this.productSpecColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.productDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.productDataGridView.Location = new System.Drawing.Point(18, 212);
            this.productDataGridView.MultiSelect = false;
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.ReadOnly = true;
            this.productDataGridView.RowHeadersVisible = false;
            this.productDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.productDataGridView.Size = new System.Drawing.Size(465, 243);
            this.productDataGridView.TabIndex = 87;
            // 
            // IdDataGridViewTextBoxColumn
            // 
            this.IdDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.IdDataGridViewTextBoxColumn.HeaderText = "序号";
            this.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn";
            this.IdDataGridViewTextBoxColumn.ReadOnly = true;
            this.IdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdDataGridViewTextBoxColumn.Width = 60;
            // 
            // productCodeColumn
            // 
            this.productCodeColumn.DataPropertyName = "自社コード";
            this.productCodeColumn.HeaderText = "自社コード";
            this.productCodeColumn.Name = "productCodeColumn";
            this.productCodeColumn.ReadOnly = true;
            this.productCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // productNameColumn
            // 
            this.productNameColumn.DataPropertyName = "商品名";
            this.productNameColumn.HeaderText = "商品名";
            this.productNameColumn.Name = "productNameColumn";
            this.productNameColumn.ReadOnly = true;
            this.productNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.productNameColumn.Width = 200;
            // 
            // productSpecColumn
            // 
            this.productSpecColumn.DataPropertyName = "規格";
            this.productSpecColumn.HeaderText = "規格";
            this.productSpecColumn.Name = "productSpecColumn";
            this.productSpecColumn.ReadOnly = true;
            this.productSpecColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.productSpecColumn.Width = 105;
            // 
            // loadItemListButton
            // 
            this.loadItemListButton.Location = new System.Drawing.Point(1022, 25);
            this.loadItemListButton.Name = "loadItemListButton";
            this.loadItemListButton.Size = new System.Drawing.Size(78, 25);
            this.loadItemListButton.TabIndex = 88;
            this.loadItemListButton.Text = "查询";
            this.loadItemListButton.UseVisualStyleBackColor = true;
            this.loadItemListButton.Click += new System.EventHandler(this.loadItemListButton_Click);
            // 
            // qtyDataGridView
            // 
            this.qtyDataGridView.AllowUserToAddRows = false;
            this.qtyDataGridView.AllowUserToDeleteRows = false;
            this.qtyDataGridView.AllowUserToResizeColumns = false;
            this.qtyDataGridView.AllowUserToResizeRows = false;
            this.qtyDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qtyDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.qtyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qtyDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.qtyDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtyDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.qtyDataGridView.Location = new System.Drawing.Point(483, 212);
            this.qtyDataGridView.MultiSelect = false;
            this.qtyDataGridView.Name = "qtyDataGridView";
            this.qtyDataGridView.RowHeadersVisible = false;
            this.qtyDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.qtyDataGridView.Size = new System.Drawing.Size(617, 243);
            this.qtyDataGridView.TabIndex = 89;
            this.qtyDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.qtyDataGridView_CellBeginEdit);
            this.qtyDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.qtyDataGridView_CellClick);
            this.qtyDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.qtyDataGridView_CellContentClick);
            this.qtyDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.qtyDataGridView_CellEndEdit);
            this.qtyDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.qtyDataGridView_CellFormatting);
            this.qtyDataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.qtyDataGridView_CellMouseEnter);
            this.qtyDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.qtyDataGridView_CellValueChanged);
            this.qtyDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.qtyDataGridView_RowPrePaint);
            this.qtyDataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.qtyDataGridView_Scroll);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(872, 480);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(105, 25);
            this.btSave.TabIndex = 90;
            this.btSave.Text = "保存修改内容";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btcanel
            // 
            this.btcanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btcanel.Location = new System.Drawing.Point(983, 480);
            this.btcanel.Name = "btcanel";
            this.btcanel.Size = new System.Drawing.Size(87, 25);
            this.btcanel.TabIndex = 91;
            this.btcanel.Text = "取消修改";
            this.btcanel.UseVisualStyleBackColor = true;
            this.btcanel.Click += new System.EventHandler(this.btcanel_Click);
            // 
            // stockIoDataGridView
            // 
            this.stockIoDataGridView.AllowUserToAddRows = false;
            this.stockIoDataGridView.AllowUserToDeleteRows = false;
            this.stockIoDataGridView.AllowUserToResizeColumns = false;
            this.stockIoDataGridView.AllowUserToResizeRows = false;
            this.stockIoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stockIoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stockIoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockIoDataGridView.ColumnHeadersVisible = false;
            this.stockIoDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockIoDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.stockIoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.stockIoDataGridView.Location = new System.Drawing.Point(483, 63);
            this.stockIoDataGridView.MultiSelect = false;
            this.stockIoDataGridView.Name = "stockIoDataGridView";
            this.stockIoDataGridView.RowHeadersVisible = false;
            this.stockIoDataGridView.RowTemplate.Height = 23;
            this.stockIoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stockIoDataGridView.Size = new System.Drawing.Size(617, 151);
            this.stockIoDataGridView.TabIndex = 92;
            this.stockIoDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.stockIoDataGridView_CellMouseDown);
            this.stockIoDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockIoDataGridView_CellValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "清除记录";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(1101, 212);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 243);
            this.vScrollBar1.TabIndex = 93;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(483, 455);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(617, 17);
            this.hScrollBar1.TabIndex = 94;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(18, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 51);
            this.label7.TabIndex = 0;
            this.label7.Text = "序号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(78, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 51);
            this.label8.TabIndex = 0;
            this.label8.Text = "自社コード";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(178, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 51);
            this.label9.TabIndex = 0;
            this.label9.Text = "商品名";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(378, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 51);
            this.label10.TabIndex = 0;
            this.label10.Text = "規格";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 517);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.stockIoDataGridView);
            this.Controls.Add(this.btcanel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.qtyDataGridView);
            this.Controls.Add(this.loadItemListButton);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manufacturerComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.ioComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.warehouseComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库出库记录查询";
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockIoDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox warehouseComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ioComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.Button loadItemListButton;
        private System.Windows.Forms.DataGridView qtyDataGridView;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btcanel;
        private System.Windows.Forms.DataGridView stockIoDataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSpecColumn;



    }
}