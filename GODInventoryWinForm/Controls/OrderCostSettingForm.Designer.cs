namespace GODInventoryWinForm.Controls
{
    partial class OrderCostSettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.startAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.genresComboBox = new System.Windows.Forms.ComboBox();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.countyComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.発注日Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店番Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入原価Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入金額Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.粗利金額Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価_税抜_Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額_税抜_Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pager1 = new GODInventoryWinForm.Controls.Pager();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "发注日";
            // 
            // startAtDateTimePicker
            // 
            this.startAtDateTimePicker.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startAtDateTimePicker.Location = new System.Drawing.Point(74, 25);
            this.startAtDateTimePicker.Name = "startAtDateTimePicker";
            this.startAtDateTimePicker.Size = new System.Drawing.Size(173, 21);
            this.startAtDateTimePicker.TabIndex = 3;
            // 
            // endAtDateTimePicker
            // 
            this.endAtDateTimePicker.Location = new System.Drawing.Point(265, 18);
            this.endAtDateTimePicker.Name = "endAtDateTimePicker";
            this.endAtDateTimePicker.Size = new System.Drawing.Size(173, 21);
            this.endAtDateTimePicker.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "-";
            // 
            // genresComboBox
            // 
            this.genresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genresComboBox.FormattingEnabled = true;
            this.genresComboBox.Location = new System.Drawing.Point(61, 45);
            this.genresComboBox.Name = "genresComboBox";
            this.genresComboBox.Size = new System.Drawing.Size(155, 22);
            this.genresComboBox.TabIndex = 6;
            this.genresComboBox.SelectedIndexChanged += new System.EventHandler(this.genresComboBox_SelectedIndexChanged);
            // 
            // productsComboBox
            // 
            this.productsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(265, 45);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(173, 22);
            this.productsComboBox.TabIndex = 7;
            // 
            // searchButton1
            // 
            this.searchButton1.Location = new System.Drawing.Point(619, 15);
            this.searchButton1.Name = "searchButton1";
            this.searchButton1.Size = new System.Drawing.Size(102, 36);
            this.searchButton1.TabIndex = 8;
            this.searchButton1.Text = "查询";
            this.searchButton1.UseVisualStyleBackColor = true;
            this.searchButton1.Click += new System.EventHandler(this.searchButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "分类";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "产品";
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(65, 17);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(100, 21);
            this.costTextBox.TabIndex = 10;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(171, 15);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(102, 36);
            this.updateButton.TabIndex = 11;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "成本价";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.countyComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.searchButton1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.endAtDateTimePicker);
            this.groupBox1.Controls.Add(this.genresComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.productsComboBox);
            this.groupBox1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 77);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "県別";
            // 
            // countyComboBox
            // 
            this.countyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countyComboBox.FormattingEnabled = true;
            this.countyComboBox.Location = new System.Drawing.Point(490, 17);
            this.countyComboBox.Name = "countyComboBox";
            this.countyComboBox.Size = new System.Drawing.Size(123, 22);
            this.countyComboBox.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updateButton);
            this.groupBox2.Controls.Add(this.costTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(766, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 77);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AllowUserToAddRows = false;
            this.ordersDataGridView.AllowUserToDeleteRows = false;
            this.ordersDataGridView.AllowUserToResizeRows = false;
            this.ordersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.発注日Column,
            this.店番Column1,
            this.店名Column1,
            this.県別Column1,
            this.伝票番号Column1,
            this.品名Column1,
            this.規格Column1,
            this.口数Column1,
            this.発注数量Column1,
            this.仕入原価Column1,
            this.仕入金額Column1,
            this.粗利金額Column1,
            this.原単価_税抜_Column1,
            this.原価金額_税抜_Column1});
            this.ordersDataGridView.Location = new System.Drawing.Point(12, 91);
            this.ordersDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.ReadOnly = true;
            this.ordersDataGridView.RowHeadersVisible = false;
            this.ordersDataGridView.RowTemplate.Height = 23;
            this.ordersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDataGridView.Size = new System.Drawing.Size(1062, 333);
            this.ordersDataGridView.TabIndex = 14;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // 発注日Column
            // 
            this.発注日Column.DataPropertyName = "発注日";
            this.発注日Column.HeaderText = "発注日";
            this.発注日Column.Name = "発注日Column";
            this.発注日Column.ReadOnly = true;
            // 
            // 店番Column1
            // 
            this.店番Column1.DataPropertyName = "店舗コード";
            this.店番Column1.HeaderText = "店番";
            this.店番Column1.Name = "店番Column1";
            this.店番Column1.ReadOnly = true;
            this.店番Column1.Width = 60;
            // 
            // 店名Column1
            // 
            this.店名Column1.DataPropertyName = "店舗名漢字";
            this.店名Column1.HeaderText = "店名";
            this.店名Column1.Name = "店名Column1";
            this.店名Column1.ReadOnly = true;
            this.店名Column1.Width = 120;
            // 
            // 県別Column1
            // 
            this.県別Column1.DataPropertyName = "県別";
            this.県別Column1.HeaderText = "県別";
            this.県別Column1.Name = "県別Column1";
            this.県別Column1.ReadOnly = true;
            this.県別Column1.Width = 80;
            // 
            // 伝票番号Column1
            // 
            this.伝票番号Column1.DataPropertyName = "伝票番号";
            this.伝票番号Column1.HeaderText = "伝番";
            this.伝票番号Column1.Name = "伝票番号Column1";
            this.伝票番号Column1.ReadOnly = true;
            this.伝票番号Column1.Width = 90;
            // 
            // 品名Column1
            // 
            this.品名Column1.DataPropertyName = "品名漢字";
            this.品名Column1.HeaderText = "品名";
            this.品名Column1.Name = "品名Column1";
            this.品名Column1.ReadOnly = true;
            this.品名Column1.Width = 180;
            // 
            // 規格Column1
            // 
            this.規格Column1.DataPropertyName = "規格名漢字";
            this.規格Column1.HeaderText = "規格";
            this.規格Column1.Name = "規格Column1";
            this.規格Column1.ReadOnly = true;
            this.規格Column1.Width = 120;
            // 
            // 口数Column1
            // 
            this.口数Column1.DataPropertyName = "納品口数";
            this.口数Column1.HeaderText = "口数";
            this.口数Column1.Name = "口数Column1";
            this.口数Column1.ReadOnly = true;
            this.口数Column1.Width = 80;
            // 
            // 発注数量Column1
            // 
            this.発注数量Column1.DataPropertyName = "実際出荷数量";
            this.発注数量Column1.HeaderText = "発注数";
            this.発注数量Column1.Name = "発注数量Column1";
            this.発注数量Column1.ReadOnly = true;
            this.発注数量Column1.Width = 90;
            // 
            // 仕入原価Column1
            // 
            this.仕入原価Column1.DataPropertyName = "仕入原価";
            this.仕入原価Column1.HeaderText = "仕入原価";
            this.仕入原価Column1.Name = "仕入原価Column1";
            this.仕入原価Column1.ReadOnly = true;
            // 
            // 仕入金額Column1
            // 
            this.仕入金額Column1.DataPropertyName = "仕入金額";
            this.仕入金額Column1.HeaderText = "仕入金額";
            this.仕入金額Column1.Name = "仕入金額Column1";
            this.仕入金額Column1.ReadOnly = true;
            // 
            // 粗利金額Column1
            // 
            this.粗利金額Column1.DataPropertyName = "粗利金額";
            this.粗利金額Column1.HeaderText = "粗利金額";
            this.粗利金額Column1.Name = "粗利金額Column1";
            this.粗利金額Column1.ReadOnly = true;
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
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Location = new System.Drawing.Point(12, 431);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 0;
            this.pager1.PageSize = 5000;
            this.pager1.Size = new System.Drawing.Size(1062, 31);
            this.pager1.TabIndex = 1;
            this.pager1.EventPaging += new GODInventoryWinForm.Controls.EventPagingHandler(this.pager1_EventPaging);
            // 
            // OrderCostSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 474);
            this.Controls.Add(this.ordersDataGridView);
            this.Controls.Add(this.startAtDateTimePicker);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderCostSettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderCostSettingForm";
            this.Load += new System.EventHandler(this.OrderCostSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startAtDateTimePicker;
        private System.Windows.Forms.DateTimePicker endAtDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox genresComboBox;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.Button searchButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label5;
        private Pager pager1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ordersDataGridView;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox countyComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注日Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店番Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入原価Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入金額Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 粗利金額Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価_税抜_Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額_税抜_Column1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}