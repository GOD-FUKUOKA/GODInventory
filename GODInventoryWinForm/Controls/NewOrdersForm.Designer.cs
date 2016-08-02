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
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderCreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.発注日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Lime;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(712, 375);
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
            this.cancelButton.Location = new System.Drawing.Point(809, 375);
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
            this.label1.Location = new System.Drawing.Point(38, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "発注日 :";
            // 
            // orderCreatedAtDateTimePicker
            // 
            this.orderCreatedAtDateTimePicker.Location = new System.Drawing.Point(94, 13);
            this.orderCreatedAtDateTimePicker.Name = "orderCreatedAtDateTimePicker";
            this.orderCreatedAtDateTimePicker.Size = new System.Drawing.Size(160, 20);
            this.orderCreatedAtDateTimePicker.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.発注日,
            this.商品コード,
            this.店舗コード,
            this.伝票番号,
            this.発注数量});
            this.dataGridView1.Location = new System.Drawing.Point(15, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(869, 256);
            this.dataGridView1.TabIndex = 4;
            // 
            // 発注日
            // 
            this.発注日.DataPropertyName = "発注日";
            this.発注日.HeaderText = "発注日";
            this.発注日.Name = "発注日";
            // 
            // 商品コード
            // 
            this.商品コード.DataPropertyName = "商品コード";
            this.商品コード.HeaderText = "商品コード";
            this.商品コード.Name = "商品コード";
            // 
            // 店舗コード
            // 
            this.店舗コード.DataPropertyName = "店舗コード";
            this.店舗コード.HeaderText = "店舗コード";
            this.店舗コード.Name = "店舗コード";
            // 
            // 伝票番号
            // 
            this.伝票番号.DataPropertyName = "伝票番号";
            this.伝票番号.HeaderText = "伝票番号";
            this.伝票番号.Name = "伝票番号";
            // 
            // 発注数量
            // 
            this.発注数量.DataPropertyName = "発注数量";
            this.発注数量.HeaderText = "発注数量";
            this.発注数量.Name = "発注数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 46);
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
            this.label3.Location = new System.Drawing.Point(10, 74);
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
            this.label4.Location = new System.Drawing.Point(630, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "発注数量 :";
            // 
            // orderQuantityUpDown
            // 
            this.orderQuantityUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderQuantityUpDown.Location = new System.Drawing.Point(704, 69);
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
            this.addButton.Location = new System.Drawing.Point(409, 61);
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
            this.label7.Location = new System.Drawing.Point(630, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "伝票番号 :";
            // 
            // invoiceNOTextBox
            // 
            this.invoiceNOTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoiceNOTextBox.Location = new System.Drawing.Point(704, 41);
            this.invoiceNOTextBox.Name = "invoiceNOTextBox";
            this.invoiceNOTextBox.Size = new System.Drawing.Size(160, 20);
            this.invoiceNOTextBox.TabIndex = 17;
            this.invoiceNOTextBox.Tag = "すべてが数字";
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storeCodeTextBox.Location = new System.Drawing.Point(94, 41);
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(160, 20);
            this.storeCodeTextBox.TabIndex = 18;
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productCodeTextBox.Location = new System.Drawing.Point(94, 69);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.Size = new System.Drawing.Size(160, 20);
            this.productCodeTextBox.TabIndex = 19;
            this.productCodeTextBox.Tag = "すべてが数字";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 20;
            this.button1.Text = "Clear All";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 413);
            this.Controls.Add(this.button1);
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
            this.Name = "NewOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewOrdersForm";
            this.Load += new System.EventHandler(this.NewOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityUpDown)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量;
        private System.Windows.Forms.Button button1;
    }
}