namespace GODInventoryWinForm.Controls
{
    partial class WaitToShipForm
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.productReceivedAtDateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.shipNOTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productShippedAtDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shipperComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.受注日Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名カナColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.社内伝番Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送担当Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価_税抜_Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額_税抜_Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注区分Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品指示Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注日Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝番Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.社内伝番Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.担当Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注区分Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品指示Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveDownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 26);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.moveDownToolStripMenuItem.Text = "Move down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.Filter = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 442);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.saveButton);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.productReceivedAtDateTimePicker2);
            this.groupBox2.Controls.Add(this.shipNOTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.productShippedAtDateTimePicker1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1022, 215);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(723, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 32);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "登録";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.受注日Column2,
            this.店名Column2,
            this.伝番Column2,
            this.社内伝番Column2,
            this.ジャンルColumn2,
            this.品名Column2,
            this.規格Column2,
            this.口数Column2,
            this.発注数Column2,
            this.重量Column2,
            this.担当Column2,
            this.県別Column2,
            this.発注区分Column2,
            this.納品指示Column2});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView2.Location = new System.Drawing.Point(3, 58);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1016, 153);
            this.dataGridView2.TabIndex = 8;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(129, 26);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.moveUpToolStripMenuItem.Text = "Move up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "配车单单号";
            // 
            // productReceivedAtDateTimePicker2
            // 
            this.productReceivedAtDateTimePicker2.Location = new System.Drawing.Point(535, 20);
            this.productReceivedAtDateTimePicker2.Name = "productReceivedAtDateTimePicker2";
            this.productReceivedAtDateTimePicker2.Size = new System.Drawing.Size(153, 21);
            this.productReceivedAtDateTimePicker2.TabIndex = 7;
            // 
            // shipNOTextBox
            // 
            this.shipNOTextBox.Location = new System.Drawing.Point(79, 20);
            this.shipNOTextBox.Name = "shipNOTextBox";
            this.shipNOTextBox.Size = new System.Drawing.Size(153, 21);
            this.shipNOTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "交货日";
            // 
            // productShippedAtDateTimePicker1
            // 
            this.productShippedAtDateTimePicker1.Location = new System.Drawing.Point(307, 20);
            this.productShippedAtDateTimePicker1.Name = "productShippedAtDateTimePicker1";
            this.productShippedAtDateTimePicker1.Size = new System.Drawing.Size(153, 21);
            this.productShippedAtDateTimePicker1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "发货日";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.shipperComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1022, 215);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // shipperComboBox
            // 
            this.shipperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shipperComboBox.FormattingEnabled = true;
            this.shipperComboBox.Items.AddRange(new object[] {
            "All",
            "丸健",
            "マツモト産業",
            "MKL"});
            this.shipperComboBox.Location = new System.Drawing.Point(91, 20);
            this.shipperComboBox.Name = "shipperComboBox";
            this.shipperComboBox.Size = new System.Drawing.Size(121, 20);
            this.shipperComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "実際配送担当";
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.受注日Column,
            this.店名Column1,
            this.店名カナColumn1,
            this.伝票番号Column1,
            this.社内伝番Column1,
            this.ジャンルColumn1,
            this.品名Column1,
            this.規格Column1,
            this.口数Column1,
            this.発注数量Column1,
            this.重量Column1,
            this.配送担当Column1,
            this.県別Column1,
            this.原単価_税抜_Column1,
            this.原価金額_税抜_Column1,
            this.発注区分Column1,
            this.納品指示Column1});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // 受注日Column
            // 
            this.受注日Column.DataPropertyName = "受注日";
            this.受注日Column.HeaderText = "受注日";
            this.受注日Column.Name = "受注日Column";
            // 
            // 店名Column1
            // 
            this.店名Column1.DataPropertyName = "店名";
            this.店名Column1.HeaderText = "店名";
            this.店名Column1.Name = "店名Column1";
            // 
            // 店名カナColumn1
            // 
            this.店名カナColumn1.DataPropertyName = "店舗名カナ";
            this.店名カナColumn1.HeaderText = "店名カナ";
            this.店名カナColumn1.Name = "店名カナColumn1";
            this.店名カナColumn1.ReadOnly = true;
            this.店名カナColumn1.Visible = false;
            // 
            // 伝票番号Column1
            // 
            this.伝票番号Column1.DataPropertyName = "伝票番号";
            this.伝票番号Column1.HeaderText = "伝番";
            this.伝票番号Column1.Name = "伝票番号Column1";
            // 
            // 社内伝番Column1
            // 
            this.社内伝番Column1.DataPropertyName = "社内伝番";
            this.社内伝番Column1.HeaderText = "社内伝番";
            this.社内伝番Column1.Name = "社内伝番Column1";
            this.社内伝番Column1.ReadOnly = true;
            // 
            // ジャンルColumn1
            // 
            this.ジャンルColumn1.DataPropertyName = "ジャンル";
            this.ジャンルColumn1.HeaderText = "ジャンル";
            this.ジャンルColumn1.Name = "ジャンルColumn1";
            // 
            // 品名Column1
            // 
            this.品名Column1.DataPropertyName = "品名漢字";
            this.品名Column1.HeaderText = "品名";
            this.品名Column1.Name = "品名Column1";
            // 
            // 規格Column1
            // 
            this.規格Column1.DataPropertyName = "規格名漢字";
            this.規格Column1.HeaderText = "規格";
            this.規格Column1.Name = "規格Column1";
            // 
            // 口数Column1
            // 
            this.口数Column1.DataPropertyName = "口数";
            this.口数Column1.HeaderText = "口数";
            this.口数Column1.Name = "口数Column1";
            // 
            // 発注数量Column1
            // 
            this.発注数量Column1.DataPropertyName = "発注数量";
            this.発注数量Column1.HeaderText = "発注数量";
            this.発注数量Column1.Name = "発注数量Column1";
            // 
            // 重量Column1
            // 
            this.重量Column1.DataPropertyName = "重量";
            this.重量Column1.HeaderText = "重量";
            this.重量Column1.Name = "重量Column1";
            // 
            // 配送担当Column1
            // 
            this.配送担当Column1.DataPropertyName = "実際配送担当";
            this.配送担当Column1.HeaderText = "配送担当";
            this.配送担当Column1.Name = "配送担当Column1";
            // 
            // 県別Column1
            // 
            this.県別Column1.DataPropertyName = "県別";
            this.県別Column1.HeaderText = "県別";
            this.県別Column1.Name = "県別Column1";
            // 
            // 原単価_税抜_Column1
            // 
            this.原単価_税抜_Column1.DataPropertyName = "原単価_税抜_";
            this.原単価_税抜_Column1.HeaderText = "原単価(税抜)";
            this.原単価_税抜_Column1.Name = "原単価_税抜_Column1";
            this.原単価_税抜_Column1.ReadOnly = true;
            this.原単価_税抜_Column1.Visible = false;
            // 
            // 原価金額_税抜_Column1
            // 
            this.原価金額_税抜_Column1.DataPropertyName = "原価金額_税抜_";
            this.原価金額_税抜_Column1.HeaderText = "原価金額(税抜)";
            this.原価金額_税抜_Column1.Name = "原価金額_税抜_Column1";
            this.原価金額_税抜_Column1.ReadOnly = true;
            this.原価金額_税抜_Column1.Visible = false;
            // 
            // 発注区分Column1
            // 
            this.発注区分Column1.DataPropertyName = "発注区分";
            this.発注区分Column1.HeaderText = "発注区分";
            this.発注区分Column1.Name = "発注区分Column1";
            this.発注区分Column1.ReadOnly = true;
            // 
            // 納品指示Column1
            // 
            this.納品指示Column1.DataPropertyName = "納品指示";
            this.納品指示Column1.HeaderText = "納品指示";
            this.納品指示Column1.Name = "納品指示Column1";
            // 
            // 受注日Column2
            // 
            this.受注日Column2.DataPropertyName = "受注日";
            this.受注日Column2.HeaderText = "受注日";
            this.受注日Column2.Name = "受注日Column2";
            // 
            // 店名Column2
            // 
            this.店名Column2.DataPropertyName = "店名";
            this.店名Column2.HeaderText = "店名";
            this.店名Column2.Name = "店名Column2";
            // 
            // 伝番Column2
            // 
            this.伝番Column2.DataPropertyName = "伝票番号";
            this.伝番Column2.HeaderText = "伝番";
            this.伝番Column2.Name = "伝番Column2";
            // 
            // 社内伝番Column2
            // 
            this.社内伝番Column2.DataPropertyName = "社内伝番";
            this.社内伝番Column2.HeaderText = "社内伝番";
            this.社内伝番Column2.Name = "社内伝番Column2";
            // 
            // ジャンルColumn2
            // 
            this.ジャンルColumn2.DataPropertyName = "ジャンル";
            this.ジャンルColumn2.HeaderText = "ジャンル";
            this.ジャンルColumn2.Name = "ジャンルColumn2";
            // 
            // 品名Column2
            // 
            this.品名Column2.DataPropertyName = "品名漢字";
            this.品名Column2.HeaderText = "品名";
            this.品名Column2.Name = "品名Column2";
            // 
            // 規格Column2
            // 
            this.規格Column2.DataPropertyName = "規格名漢字";
            this.規格Column2.HeaderText = "規格";
            this.規格Column2.Name = "規格Column2";
            // 
            // 口数Column2
            // 
            this.口数Column2.DataPropertyName = "口数";
            this.口数Column2.HeaderText = "口数";
            this.口数Column2.Name = "口数Column2";
            // 
            // 発注数Column2
            // 
            this.発注数Column2.DataPropertyName = "発注数量";
            this.発注数Column2.HeaderText = "発注数";
            this.発注数Column2.Name = "発注数Column2";
            // 
            // 重量Column2
            // 
            this.重量Column2.DataPropertyName = "重量";
            this.重量Column2.HeaderText = "重量";
            this.重量Column2.Name = "重量Column2";
            // 
            // 担当Column2
            // 
            this.担当Column2.DataPropertyName = "実際配送担当";
            this.担当Column2.HeaderText = "担当";
            this.担当Column2.Name = "担当Column2";
            // 
            // 県別Column2
            // 
            this.県別Column2.HeaderText = "県別";
            this.県別Column2.Name = "県別Column2";
            // 
            // 発注区分Column2
            // 
            this.発注区分Column2.HeaderText = "発注区分";
            this.発注区分Column2.Name = "発注区分Column2";
            // 
            // 納品指示Column2
            // 
            this.納品指示Column2.HeaderText = "納品指示";
            this.納品指示Column2.Name = "納品指示Column2";
            // 
            // WaitToShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitToShipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaitToShipForm";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker productReceivedAtDateTimePicker2;
        private System.Windows.Forms.TextBox shipNOTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker productShippedAtDateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox shipperComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注日Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝番Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 社内伝番Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 担当Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注区分Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品指示Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注日Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名カナColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 社内伝番Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価_税抜_Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額_税抜_Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注区分Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品指示Column1;
    }
}