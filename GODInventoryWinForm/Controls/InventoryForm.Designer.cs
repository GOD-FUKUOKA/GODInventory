namespace GODInventoryWinForm.Controls
{
    partial class InventoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btconfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btclear_zero = new System.Windows.Forms.Button();
            this.btfind = new System.Windows.Forms.Button();
            this.warehouseComboBox = new System.Windows.Forms.ComboBox();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.btprint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.endDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自社コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yingYouKuCunShuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daiFaHuoShuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiJiKuCunShuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jiHuaRuCunShuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qingDianColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaZhiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "仓库";
            // 
            // btconfirm
            // 
            this.btconfirm.Location = new System.Drawing.Point(646, 501);
            this.btconfirm.Name = "btconfirm";
            this.btconfirm.Size = new System.Drawing.Size(139, 26);
            this.btconfirm.TabIndex = 34;
            this.btconfirm.Text = "确定并调整库存";
            this.btconfirm.UseVisualStyleBackColor = true;
            this.btconfirm.Click += new System.EventHandler(this.btconfirm_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(675, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "日期";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "工厂";
            // 
            // btclear_zero
            // 
            this.btclear_zero.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btclear_zero.Location = new System.Drawing.Point(791, 501);
            this.btclear_zero.Name = "btclear_zero";
            this.btclear_zero.Size = new System.Drawing.Size(139, 26);
            this.btclear_zero.TabIndex = 36;
            this.btclear_zero.Text = "清点数量清零";
            this.btclear_zero.UseVisualStyleBackColor = true;
            this.btclear_zero.Click += new System.EventHandler(this.btclear_zero_Click);
            // 
            // btfind
            // 
            this.btfind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btfind.Location = new System.Drawing.Point(776, 73);
            this.btfind.Name = "btfind";
            this.btfind.Size = new System.Drawing.Size(75, 28);
            this.btfind.TabIndex = 35;
            this.btfind.Text = "查询";
            this.btfind.UseVisualStyleBackColor = true;
            this.btfind.Click += new System.EventHandler(this.btfind_Click);
            // 
            // warehouseComboBox
            // 
            this.warehouseComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.warehouseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseComboBox.FormattingEnabled = true;
            this.warehouseComboBox.Location = new System.Drawing.Point(55, 29);
            this.warehouseComboBox.Name = "warehouseComboBox";
            this.warehouseComboBox.Size = new System.Drawing.Size(141, 20);
            this.warehouseComboBox.TabIndex = 42;
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(492, 29);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(141, 20);
            this.manufacturerComboBox.TabIndex = 43;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.自社コード,
            this.商品名,
            this.規格,
            this.yingYouKuCunShuColumn,
            this.daiFaHuoShuColumn,
            this.shiJiKuCunShuColumn,
            this.jiHuaRuCunShuColumn,
            this.qingDianColumn,
            this.chaZhiColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(918, 368);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // genreComboBox
            // 
            this.genreComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(284, 29);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(141, 20);
            this.genreComboBox.TabIndex = 44;
            // 
            // btprint
            // 
            this.btprint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btprint.Location = new System.Drawing.Point(12, 501);
            this.btprint.Name = "btprint";
            this.btprint.Size = new System.Drawing.Size(139, 26);
            this.btprint.TabIndex = 33;
            this.btprint.Text = "打印清点用表格";
            this.btprint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "商品分类";
            // 
            // endDateTimePicker1
            // 
            this.endDateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.endDateTimePicker1.Location = new System.Drawing.Point(710, 29);
            this.endDateTimePicker1.Name = "endDateTimePicker1";
            this.endDateTimePicker1.Size = new System.Drawing.Size(141, 21);
            this.endDateTimePicker1.TabIndex = 41;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "Id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idColumn.HeaderText = "序号";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idColumn.Width = 60;
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
            this.商品名.Width = 200;
            // 
            // 規格
            // 
            this.規格.DataPropertyName = "規格";
            this.規格.HeaderText = "規格";
            this.規格.Name = "規格";
            this.規格.ReadOnly = true;
            this.規格.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.規格.Width = 120;
            // 
            // yingYouKuCunShuColumn
            // 
            this.yingYouKuCunShuColumn.DataPropertyName = "yingYouKuCunShu";
            this.yingYouKuCunShuColumn.HeaderText = "应有库存数量";
            this.yingYouKuCunShuColumn.Name = "yingYouKuCunShuColumn";
            this.yingYouKuCunShuColumn.ReadOnly = true;
            this.yingYouKuCunShuColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.yingYouKuCunShuColumn.Width = 70;
            // 
            // daiFaHuoShuColumn
            // 
            this.daiFaHuoShuColumn.DataPropertyName = "daiFaHuoShu";
            this.daiFaHuoShuColumn.HeaderText = "待发货数量";
            this.daiFaHuoShuColumn.Name = "daiFaHuoShuColumn";
            this.daiFaHuoShuColumn.ReadOnly = true;
            this.daiFaHuoShuColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.daiFaHuoShuColumn.Width = 70;
            // 
            // shiJiKuCunShuColumn
            // 
            this.shiJiKuCunShuColumn.DataPropertyName = "shiJiKuCunShu";
            this.shiJiKuCunShuColumn.HeaderText = "实际应有数量";
            this.shiJiKuCunShuColumn.Name = "shiJiKuCunShuColumn";
            this.shiJiKuCunShuColumn.ReadOnly = true;
            this.shiJiKuCunShuColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.shiJiKuCunShuColumn.Width = 70;
            // 
            // jiHuaRuCunShuColumn
            // 
            this.jiHuaRuCunShuColumn.DataPropertyName = "jiHuaRuCunShu";
            this.jiHuaRuCunShuColumn.HeaderText = "计划入库数量";
            this.jiHuaRuCunShuColumn.Name = "jiHuaRuCunShuColumn";
            this.jiHuaRuCunShuColumn.ReadOnly = true;
            this.jiHuaRuCunShuColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.jiHuaRuCunShuColumn.Width = 70;
            // 
            // qingDianColumn
            // 
            this.qingDianColumn.DataPropertyName = "qingDianShu";
            this.qingDianColumn.HeaderText = "清点数量";
            this.qingDianColumn.Name = "qingDianColumn";
            this.qingDianColumn.Width = 80;
            // 
            // chaZhiColumn
            // 
            this.chaZhiColumn.DataPropertyName = "chaZhi";
            this.chaZhiColumn.HeaderText = "差値";
            this.chaZhiColumn.Name = "chaZhiColumn";
            this.chaZhiColumn.ReadOnly = true;
            this.chaZhiColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chaZhiColumn.Width = 70;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 538);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btconfirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btclear_zero);
            this.Controls.Add(this.btfind);
            this.Controls.Add(this.warehouseComboBox);
            this.Controls.Add(this.manufacturerComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.btprint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDateTimePicker1);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryForm";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btconfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btclear_zero;
        private System.Windows.Forms.Button btfind;
        private System.Windows.Forms.ComboBox warehouseComboBox;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Button btprint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格;
        private System.Windows.Forms.DataGridViewTextBoxColumn yingYouKuCunShuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daiFaHuoShuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiJiKuCunShuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jiHuaRuCunShuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qingDianColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaZhiColumn;
    }
}