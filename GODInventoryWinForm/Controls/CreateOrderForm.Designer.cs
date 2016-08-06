﻿namespace GODInventoryWinForm.Controls
{
    partial class CreateOrderForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.orderQuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.invoiceNOTextBox = new System.Windows.Forms.TextBox();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.二次製品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.クリア = new System.Windows.Forms.DataGridViewButtonColumn();
            this.伝票番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注形態 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＪＡＮコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入先コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入先名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷業務仕入先コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.法人コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.法人名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部門コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品場所コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品先店舗名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品予定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityUpDown)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Lime;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(712, 464);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 35);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(809, 464);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 35);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(745, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "発注日 :";
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(805, 44);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(160, 20);
            this.orderCreatedAtDateTimePicker.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.クリア,
            this.伝票番号,
            this.発注形態,
            this.ＪＡＮコード,
            this.商品コード,
            this.品名漢字,
            this.規格名漢字,
            this.原単価,
            this.売単価,
            this.受領数量,
            this.発注日,
            this.店舗コード,
            this.店舗名漢字,
            this.発注数量,
            this.仕入先コード,
            this.仕入先名カナ,
            this.出荷業務仕入先コード,
            this.法人コード,
            this.法人名漢字,
            this.部門コード,
            this.納品場所コード,
            this.納品先店舗名漢字,
            this.納品予定日});
            this.dataGridView1.Location = new System.Drawing.Point(5, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(960, 256);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "店舗コード:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "商品コード :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "発注数量 :";
            // 
            // orderQuantityUpDown
            // 
            this.orderQuantityUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderQuantityUpDown.Location = new System.Drawing.Point(418, 119);
            this.orderQuantityUpDown.Name = "orderQuantityUpDown";
            this.orderQuantityUpDown.Size = new System.Drawing.Size(160, 20);
            this.orderQuantityUpDown.TabIndex = 10;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.Color.Crimson;
            this.addButton.Image = global::GODInventoryWinForm.Properties.Resources.add___副本;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.Location = new System.Drawing.Point(829, 150);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 46);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Add to list";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "伝票番号 :";
            // 
            // invoiceNOTextBox
            // 
            this.invoiceNOTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoiceNOTextBox.Location = new System.Drawing.Point(111, 114);
            this.invoiceNOTextBox.Name = "invoiceNOTextBox";
            this.invoiceNOTextBox.Size = new System.Drawing.Size(160, 20);
            this.invoiceNOTextBox.TabIndex = 17;
            this.invoiceNOTextBox.Tag = "すべてが数字";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storeCodeTextBox.Location = new System.Drawing.Point(112, 42);
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(58, 20);
            this.storeCodeTextBox.TabIndex = 18;
            this.storeCodeTextBox.Click += new System.EventHandler(this.storeCodeTextBox_Click);
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productCodeTextBox.Location = new System.Drawing.Point(417, 84);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.Size = new System.Drawing.Size(160, 20);
            this.productCodeTextBox.TabIndex = 19;
            this.productCodeTextBox.Tag = "すべてが数字";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(15, 464);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(306, 35);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.二次製品ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::GODInventoryWinForm.Properties.Resources._16_on_black;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 32);
            this.toolStripDropDownButton1.Text = "MORE";
            // 
            // 二次製品ToolStripMenuItem
            // 
            this.二次製品ToolStripMenuItem.Name = "二次製品ToolStripMenuItem";
            this.二次製品ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.二次製品ToolStripMenuItem.Text = "二次製品";
            this.二次製品ToolStripMenuItem.Click += new System.EventHandler(this.二次製品ToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "仕入先コード :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(456, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(274, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "出荷業務仕入先コード :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(701, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(264, 20);
            this.textBox3.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(583, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "仕入先名カナ :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(176, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(343, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "法人コード:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(483, 44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(95, 21);
            this.comboBox2.TabIndex = 30;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(425, 46);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(52, 20);
            this.textBox4.TabIndex = 29;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(600, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "部門コード:";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Location = new System.Drawing.Point(683, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(52, 20);
            this.textBox5.TabIndex = 32;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(805, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(724, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "納品予定日 :";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(176, 78);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(95, 21);
            this.comboBox3.TabIndex = 37;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Location = new System.Drawing.Point(112, 79);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(58, 20);
            this.textBox6.TabIndex = 36;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Silver;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(2, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "納品場所コード:";
            // 
            // クリア
            // 
            this.クリア.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.クリア.FillWeight = 30F;
            this.クリア.HeaderText = "";
            this.クリア.Name = "クリア";
            this.クリア.Text = "クリア";
            this.クリア.ToolTipText = "クリア";
            this.クリア.Width = 40;
            // 
            // 伝票番号
            // 
            this.伝票番号.DataPropertyName = "伝票番号";
            this.伝票番号.HeaderText = "伝票番号";
            this.伝票番号.Name = "伝票番号";
            // 
            // 発注形態
            // 
            this.発注形態.DataPropertyName = "発注形態";
            this.発注形態.HeaderText = "発注形態";
            this.発注形態.Name = "発注形態";
            // 
            // ＪＡＮコード
            // 
            this.ＪＡＮコード.DataPropertyName = "ＪＡＮコード";
            this.ＪＡＮコード.HeaderText = "ＪＡＮコード";
            this.ＪＡＮコード.Name = "ＪＡＮコード";
            this.ＪＡＮコード.Visible = false;
            // 
            // 商品コード
            // 
            this.商品コード.DataPropertyName = "商品コード";
            this.商品コード.HeaderText = "商品コード";
            this.商品コード.Name = "商品コード";
            // 
            // 品名漢字
            // 
            this.品名漢字.DataPropertyName = "品名漢字";
            this.品名漢字.HeaderText = "品名漢字";
            this.品名漢字.Name = "品名漢字";
            this.品名漢字.Visible = false;
            // 
            // 規格名漢字
            // 
            this.規格名漢字.DataPropertyName = "規格名漢字";
            this.規格名漢字.HeaderText = "規格名漢字";
            this.規格名漢字.Name = "規格名漢字";
            this.規格名漢字.Visible = false;
            // 
            // 原単価
            // 
            this.原単価.DataPropertyName = "原単価";
            this.原単価.HeaderText = "原単価";
            this.原単価.Name = "原単価";
            this.原単価.Visible = false;
            // 
            // 売単価
            // 
            this.売単価.DataPropertyName = "売単価";
            this.売単価.HeaderText = "売単価";
            this.売単価.Name = "売単価";
            this.売単価.Visible = false;
            // 
            // 受領数量
            // 
            this.受領数量.DataPropertyName = "受領数量";
            this.受領数量.HeaderText = "受領数量";
            this.受領数量.Name = "受領数量";
            this.受領数量.Visible = false;
            // 
            // 発注日
            // 
            this.発注日.DataPropertyName = "発注日";
            this.発注日.HeaderText = "発注日";
            this.発注日.Name = "発注日";
            // 
            // 店舗コード
            // 
            this.店舗コード.DataPropertyName = "店舗コード";
            this.店舗コード.HeaderText = "店舗コード";
            this.店舗コード.Name = "店舗コード";
            // 
            // 店舗名漢字
            // 
            this.店舗名漢字.DataPropertyName = "店舗名漢字";
            this.店舗名漢字.HeaderText = "店舗名漢字";
            this.店舗名漢字.Name = "店舗名漢字";
            // 
            // 発注数量
            // 
            this.発注数量.DataPropertyName = "発注数量";
            this.発注数量.HeaderText = "発注数量";
            this.発注数量.Name = "発注数量";
            // 
            // 仕入先コード
            // 
            this.仕入先コード.HeaderText = "仕入先コード";
            this.仕入先コード.Name = "仕入先コード";
            // 
            // 仕入先名カナ
            // 
            this.仕入先名カナ.DataPropertyName = "仕入先名カナ";
            this.仕入先名カナ.HeaderText = "仕入先名カナ";
            this.仕入先名カナ.Name = "仕入先名カナ";
            // 
            // 出荷業務仕入先コード
            // 
            this.出荷業務仕入先コード.DataPropertyName = "出荷業務仕入先コード";
            this.出荷業務仕入先コード.HeaderText = "出荷業務仕入先コード";
            this.出荷業務仕入先コード.Name = "出荷業務仕入先コード";
            // 
            // 法人コード
            // 
            this.法人コード.DataPropertyName = "法人コード";
            this.法人コード.HeaderText = "法人コード";
            this.法人コード.Name = "法人コード";
            // 
            // 法人名漢字
            // 
            this.法人名漢字.DataPropertyName = "法人名漢字";
            this.法人名漢字.HeaderText = "法人名漢字";
            this.法人名漢字.Name = "法人名漢字";
            // 
            // 部門コード
            // 
            this.部門コード.DataPropertyName = "部門コード";
            this.部門コード.HeaderText = "部門コード";
            this.部門コード.Name = "部門コード";
            // 
            // 納品場所コード
            // 
            this.納品場所コード.DataPropertyName = "納品場所コード";
            this.納品場所コード.HeaderText = "納品場所コード";
            this.納品場所コード.Name = "納品場所コード";
            // 
            // 納品先店舗名漢字
            // 
            this.納品先店舗名漢字.DataPropertyName = "納品先店舗名漢字";
            this.納品先店舗名漢字.HeaderText = "納品先店舗名漢字";
            this.納品先店舗名漢字.Name = "納品先店舗名漢字";
            // 
            // 納品予定日
            // 
            this.納品予定日.DataPropertyName = "納品予定日";
            this.納品予定日.HeaderText = "納品予定日";
            this.納品予定日.Name = "納品予定日";
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 515);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.productCodeTextBox);
            this.Controls.Add(this.storeCodeTextBox);
            this.Controls.Add(this.invoiceNOTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.orderQuantityUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.orderCreatedAtDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Name = "CreateOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewOrdersForm";
            this.Load += new System.EventHandler(this.NewOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityUpDown)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker orderCreatedAtDateTimePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown orderQuantityUpDown;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox invoiceNOTextBox;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 二次製品ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewButtonColumn クリア;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注形態;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＪＡＮコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入先コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入先名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷業務仕入先コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 法人コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 法人名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部門コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品場所コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品先店舗名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品予定日;
    }
}