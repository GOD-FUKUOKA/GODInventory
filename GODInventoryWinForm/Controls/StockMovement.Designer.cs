﻿namespace GODInventoryWinForm.Controls
{
    partial class StockMovement
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
            this.IdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自社コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btadd = new System.Windows.Forms.Button();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.btclearzero = new System.Windows.Forms.Button();
            this.btlogin = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.stockInNumTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stockOutNumTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toWarehouseComboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fromWarehouseComboBox = new System.Windows.Forms.ComboBox();
            this.stockInDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.stockOutDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fromStatusComboBox4 = new System.Windows.Forms.ComboBox();
            this.toStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fromBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBindingSource)).BeginInit();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDataGridViewTextBoxColumn,
            this.自社コード,
            this.商品名,
            this.規格,
            this.数量});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(37, 207);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(776, 301);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // IdDataGridViewTextBoxColumn
            // 
            this.IdDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.IdDataGridViewTextBoxColumn.HeaderText = "序号";
            this.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn";
            this.IdDataGridViewTextBoxColumn.ReadOnly = true;
            this.IdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdDataGridViewTextBoxColumn.Width = 80;
            // 
            // 自社コード
            // 
            this.自社コード.DataPropertyName = "自社コード";
            this.自社コード.HeaderText = "自社コード";
            this.自社コード.Name = "自社コード";
            this.自社コード.ReadOnly = true;
            this.自社コード.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // 商品名
            // 
            this.商品名.DataPropertyName = "商品名";
            this.商品名.HeaderText = "商品名";
            this.商品名.Name = "商品名";
            this.商品名.ReadOnly = true;
            this.商品名.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.商品名.Width = 280;
            // 
            // 規格
            // 
            this.規格.DataPropertyName = "規格";
            this.規格.HeaderText = "規格";
            this.規格.Name = "規格";
            this.規格.ReadOnly = true;
            this.規格.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.規格.Width = 180;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "qty";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.Width = 70;
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(679, 24);
            this.btadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(106, 32);
            this.btadd.TabIndex = 8;
            this.btadd.Text = "商品リスト表示";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(133, 24);
            this.genreComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(208, 22);
            this.genreComboBox.TabIndex = 0;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged);
            this.genreComboBox.SelectedValueChanged += new System.EventHandler(this.genreComboBox_SelectedValueChanged);
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(451, 24);
            this.manufacturerComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(208, 22);
            this.manufacturerComboBox.TabIndex = 1;
            // 
            // btclearzero
            // 
            this.btclearzero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btclearzero.Location = new System.Drawing.Point(837, 249);
            this.btclearzero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btclearzero.Name = "btclearzero";
            this.btclearzero.Size = new System.Drawing.Size(106, 32);
            this.btclearzero.TabIndex = 10;
            this.btclearzero.Text = "クリア";
            this.btclearzero.UseVisualStyleBackColor = true;
            this.btclearzero.Click += new System.EventHandler(this.btclearzero_Click);
            // 
            // btlogin
            // 
            this.btlogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btlogin.Location = new System.Drawing.Point(837, 207);
            this.btlogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(106, 32);
            this.btlogin.TabIndex = 9;
            this.btlogin.Text = "登録";
            this.btlogin.UseVisualStyleBackColor = true;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(355, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 55;
            this.label8.Text = "入庫記録番号";
            // 
            // stockInNumTextBox
            // 
            this.stockInNumTextBox.Enabled = false;
            this.stockInNumTextBox.Location = new System.Drawing.Point(451, 169);
            this.stockInNumTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stockInNumTextBox.Multiline = true;
            this.stockInNumTextBox.Name = "stockInNumTextBox";
            this.stockInNumTextBox.ReadOnly = true;
            this.stockInNumTextBox.Size = new System.Drawing.Size(208, 22);
            this.stockInNumTextBox.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 53;
            this.label7.Text = "出庫記録番号";
            // 
            // stockOutNumTextBox
            // 
            this.stockOutNumTextBox.Enabled = false;
            this.stockOutNumTextBox.Location = new System.Drawing.Point(133, 169);
            this.stockOutNumTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stockOutNumTextBox.Multiline = true;
            this.stockOutNumTextBox.Name = "stockOutNumTextBox";
            this.stockOutNumTextBox.ReadOnly = true;
            this.stockOutNumTextBox.Size = new System.Drawing.Size(208, 23);
            this.stockOutNumTextBox.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "------->";
            // 
            // toWarehouseComboBox1
            // 
            this.toWarehouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toWarehouseComboBox1.FormattingEnabled = true;
            this.toWarehouseComboBox1.Location = new System.Drawing.Point(451, 96);
            this.toWarehouseComboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toWarehouseComboBox1.Name = "toWarehouseComboBox1";
            this.toWarehouseComboBox1.Size = new System.Drawing.Size(208, 22);
            this.toWarehouseComboBox1.TabIndex = 5;
            this.toWarehouseComboBox1.SelectedIndexChanged += new System.EventHandler(this.toWarehouseComboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 14);
            this.label5.TabIndex = 49;
            this.label5.Visible = false;
            // 
            // fromWarehouseComboBox
            // 
            this.fromWarehouseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromWarehouseComboBox.FormattingEnabled = true;
            this.fromWarehouseComboBox.Location = new System.Drawing.Point(133, 96);
            this.fromWarehouseComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fromWarehouseComboBox.Name = "fromWarehouseComboBox";
            this.fromWarehouseComboBox.Size = new System.Drawing.Size(208, 22);
            this.fromWarehouseComboBox.TabIndex = 4;
            this.fromWarehouseComboBox.SelectedIndexChanged += new System.EventHandler(this.fromWarehouseComboBox_SelectedIndexChanged);
            // 
            // stockInDateTimePicker1
            // 
            this.stockInDateTimePicker1.Location = new System.Drawing.Point(451, 61);
            this.stockInDateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stockInDateTimePicker1.Name = "stockInDateTimePicker1";
            this.stockInDateTimePicker1.Size = new System.Drawing.Size(208, 21);
            this.stockInDateTimePicker1.TabIndex = 3;
            this.stockInDateTimePicker1.ValueChanged += new System.EventHandler(this.stockInDateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 47;
            this.label4.Text = "入库日期";
            // 
            // stockOutDateTimePicker
            // 
            this.stockOutDateTimePicker.Location = new System.Drawing.Point(133, 61);
            this.stockOutDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stockOutDateTimePicker.Name = "stockOutDateTimePicker";
            this.stockOutDateTimePicker.Size = new System.Drawing.Size(208, 21);
            this.stockOutDateTimePicker.TabIndex = 2;
            this.stockOutDateTimePicker.ValueChanged += new System.EventHandler(this.stockOutDateTimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 45;
            this.label3.Text = "出庫日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 44;
            this.label2.Text = "工場";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 42;
            this.label1.Text = "ジャンル";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(94, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 62;
            this.label9.Text = "状態";
            // 
            // fromStatusComboBox4
            // 
            this.fromStatusComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromStatusComboBox4.FormattingEnabled = true;
            this.fromStatusComboBox4.Items.AddRange(new object[] {
            "完了",
            "仮"});
            this.fromStatusComboBox4.Location = new System.Drawing.Point(133, 132);
            this.fromStatusComboBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fromStatusComboBox4.Name = "fromStatusComboBox4";
            this.fromStatusComboBox4.Size = new System.Drawing.Size(208, 22);
            this.fromStatusComboBox4.TabIndex = 6;
            // 
            // toStatusComboBox
            // 
            this.toStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toStatusComboBox.FormattingEnabled = true;
            this.toStatusComboBox.Items.AddRange(new object[] {
            "完了",
            "仮"});
            this.toStatusComboBox.Location = new System.Drawing.Point(451, 132);
            this.toStatusComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toStatusComboBox.Name = "toStatusComboBox";
            this.toStatusComboBox.Size = new System.Drawing.Size(208, 22);
            this.toStatusComboBox.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(411, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 64;
            this.label10.Text = "状態";
            // 
            // StockMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 539);
            this.Controls.Add(this.toStatusComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.fromStatusComboBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.manufacturerComboBox);
            this.Controls.Add(this.btclearzero);
            this.Controls.Add(this.btlogin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.stockInNumTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stockOutNumTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toWarehouseComboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fromWarehouseComboBox);
            this.Controls.Add(this.stockInDateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stockOutDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "倉庫間移動";
            this.Load += new System.EventHandler(this.StockMovement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.Button btclearzero;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox stockInNumTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox stockOutNumTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox toWarehouseComboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox fromWarehouseComboBox;
        private System.Windows.Forms.DateTimePicker stockInDateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker stockOutDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox fromStatusComboBox4;
        private System.Windows.Forms.ComboBox toStatusComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource fromBindingSource;
        private System.Windows.Forms.BindingSource toBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;

    }
}