namespace GODInventoryWinForm.Controls.Prices
{
    partial class MissingReportForm
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
            this.groupByShopDataGridView1 = new System.Windows.Forms.DataGridView();
            this.shipIdColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storenameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectTotalColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupByProductDataGridView2 = new System.Windows.Forms.DataGridView();
            this.productIdColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectTotalColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixButton1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupByShoplabel1 = new System.Windows.Forms.Label();
            this.groupProductLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupByShopDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupByProductDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupByShopDataGridView1
            // 
            this.groupByShopDataGridView1.AllowUserToAddRows = false;
            this.groupByShopDataGridView1.AllowUserToResizeRows = false;
            this.groupByShopDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupByShopDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.groupByShopDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupByShopDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shipIdColumn1,
            this.storenameColumn1,
            this.countColumn1,
            this.expectTotalColumn1});
            this.groupByShopDataGridView1.Location = new System.Drawing.Point(27, 65);
            this.groupByShopDataGridView1.Name = "groupByShopDataGridView1";
            this.groupByShopDataGridView1.RowHeadersVisible = false;
            this.groupByShopDataGridView1.RowTemplate.Height = 23;
            this.groupByShopDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.groupByShopDataGridView1.Size = new System.Drawing.Size(375, 228);
            this.groupByShopDataGridView1.TabIndex = 0;
            // 
            // shipIdColumn1
            // 
            this.shipIdColumn1.DataPropertyName = "id";
            this.shipIdColumn1.HeaderText = "店番";
            this.shipIdColumn1.Name = "shipIdColumn1";
            // 
            // storenameColumn1
            // 
            this.storenameColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.storenameColumn1.DataPropertyName = "name";
            this.storenameColumn1.HeaderText = "店名";
            this.storenameColumn1.Name = "storenameColumn1";
            // 
            // countColumn1
            // 
            this.countColumn1.DataPropertyName = "total";
            this.countColumn1.HeaderText = "当前记录数";
            this.countColumn1.Name = "countColumn1";
            // 
            // expectTotalColumn1
            // 
            this.expectTotalColumn1.DataPropertyName = "expectTotal";
            this.expectTotalColumn1.HeaderText = "应有记录数";
            this.expectTotalColumn1.Name = "expectTotalColumn1";
            // 
            // groupByProductDataGridView2
            // 
            this.groupByProductDataGridView2.AllowUserToAddRows = false;
            this.groupByProductDataGridView2.AllowUserToResizeRows = false;
            this.groupByProductDataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupByProductDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.groupByProductDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupByProductDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIdColumn2,
            this.productNameColumn2,
            this.totalColumn2,
            this.expectTotalColumn2});
            this.groupByProductDataGridView2.Location = new System.Drawing.Point(430, 65);
            this.groupByProductDataGridView2.Name = "groupByProductDataGridView2";
            this.groupByProductDataGridView2.RowHeadersVisible = false;
            this.groupByProductDataGridView2.RowTemplate.Height = 23;
            this.groupByProductDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.groupByProductDataGridView2.Size = new System.Drawing.Size(375, 228);
            this.groupByProductDataGridView2.TabIndex = 0;
            // 
            // productIdColumn2
            // 
            this.productIdColumn2.DataPropertyName = "id";
            this.productIdColumn2.HeaderText = "自社コード";
            this.productIdColumn2.Name = "productIdColumn2";
            // 
            // productNameColumn2
            // 
            this.productNameColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNameColumn2.DataPropertyName = "name";
            this.productNameColumn2.HeaderText = "商品名";
            this.productNameColumn2.Name = "productNameColumn2";
            // 
            // totalColumn2
            // 
            this.totalColumn2.DataPropertyName = "total";
            this.totalColumn2.HeaderText = "当前数量";
            this.totalColumn2.Name = "totalColumn2";
            // 
            // expectTotalColumn2
            // 
            this.expectTotalColumn2.DataPropertyName = "expectTotal";
            this.expectTotalColumn2.HeaderText = "应有数量";
            this.expectTotalColumn2.Name = "expectTotalColumn2";
            // 
            // fixButton1
            // 
            this.fixButton1.Location = new System.Drawing.Point(300, 24);
            this.fixButton1.Name = "fixButton1";
            this.fixButton1.Size = new System.Drawing.Size(102, 35);
            this.fixButton1.TabIndex = 1;
            this.fixButton1.Text = "填充缺失数据";
            this.fixButton1.UseVisualStyleBackColor = true;
            this.fixButton1.Click += new System.EventHandler(this.fixButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(703, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "填充缺失数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupByShoplabel1
            // 
            this.groupByShoplabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupByShoplabel1.Location = new System.Drawing.Point(27, 296);
            this.groupByShoplabel1.Name = "groupByShoplabel1";
            this.groupByShoplabel1.Size = new System.Drawing.Size(375, 23);
            this.groupByShoplabel1.TabIndex = 3;
            this.groupByShoplabel1.Text = "groupByShoplabel1";
            // 
            // groupProductLabel2
            // 
            this.groupProductLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupProductLabel2.Location = new System.Drawing.Point(430, 296);
            this.groupProductLabel2.Name = "groupProductLabel2";
            this.groupProductLabel2.Size = new System.Drawing.Size(375, 23);
            this.groupProductLabel2.TabIndex = 4;
            this.groupProductLabel2.Text = "label2";
            // 
            // MissingReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 325);
            this.Controls.Add(this.groupProductLabel2);
            this.Controls.Add(this.groupByShoplabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fixButton1);
            this.Controls.Add(this.groupByProductDataGridView2);
            this.Controls.Add(this.groupByShopDataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MissingReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MissingReportForm";
            this.Load += new System.EventHandler(this.MissingReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupByShopDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupByProductDataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView groupByShopDataGridView1;
        private System.Windows.Forms.DataGridView groupByProductDataGridView2;
        private System.Windows.Forms.Button fixButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label groupByShoplabel1;
        private System.Windows.Forms.Label groupProductLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipIdColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn storenameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn countColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectTotalColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectTotalColumn2;
    }
}