namespace GODInventoryWinForm.Controls
{
    partial class ShipOrderListForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.出荷日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注日Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店名Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品口数Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際出荷数量Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際配送担当Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注形態名称漢字Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.shipNOLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.出荷日Column1,
            this.納品日Column1,
            this.受注日Column1,
            this.店名Column1,
            this.伝票番号Column1,
            this.品名漢字Column1,
            this.規格名漢字Column1,
            this.納品口数Column1,
            this.実際出荷数量Column1,
            this.重量Column2,
            this.実際配送担当Column1,
            this.県別Column1,
            this.発注形態名称漢字Column1});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 388);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // 出荷日Column1
            // 
            this.出荷日Column1.DataPropertyName = "出荷日";
            this.出荷日Column1.HeaderText = "出荷日";
            this.出荷日Column1.Name = "出荷日Column1";
            // 
            // 納品日Column1
            // 
            this.納品日Column1.DataPropertyName = "納品日";
            this.納品日Column1.HeaderText = "納品日";
            this.納品日Column1.Name = "納品日Column1";
            // 
            // 受注日Column1
            // 
            this.受注日Column1.DataPropertyName = "受注日";
            this.受注日Column1.HeaderText = "受注日";
            this.受注日Column1.Name = "受注日Column1";
            // 
            // 店名Column1
            // 
            this.店名Column1.DataPropertyName = "店舗名漢字";
            this.店名Column1.HeaderText = "店名";
            this.店名Column1.Name = "店名Column1";
            // 
            // 伝票番号Column1
            // 
            this.伝票番号Column1.DataPropertyName = "伝票番号";
            this.伝票番号Column1.HeaderText = "伝票番号";
            this.伝票番号Column1.Name = "伝票番号Column1";
            this.伝票番号Column1.ReadOnly = true;
            // 
            // 品名漢字Column1
            // 
            this.品名漢字Column1.DataPropertyName = "品名漢字";
            this.品名漢字Column1.HeaderText = "品名";
            this.品名漢字Column1.Name = "品名漢字Column1";
            // 
            // 規格名漢字Column1
            // 
            this.規格名漢字Column1.DataPropertyName = "規格名漢字";
            this.規格名漢字Column1.HeaderText = "規格名";
            this.規格名漢字Column1.Name = "規格名漢字Column1";
            // 
            // 納品口数Column1
            // 
            this.納品口数Column1.DataPropertyName = "納品口数";
            this.納品口数Column1.HeaderText = "口数";
            this.納品口数Column1.Name = "納品口数Column1";
            // 
            // 実際出荷数量Column1
            // 
            this.実際出荷数量Column1.DataPropertyName = "実際出荷数量";
            this.実際出荷数量Column1.HeaderText = "発注数量";
            this.実際出荷数量Column1.Name = "実際出荷数量Column1";
            // 
            // 重量Column2
            // 
            this.重量Column2.DataPropertyName = "重量";
            this.重量Column2.HeaderText = "重量";
            this.重量Column2.Name = "重量Column2";
            // 
            // 実際配送担当Column1
            // 
            this.実際配送担当Column1.DataPropertyName = "実際配送担当";
            this.実際配送担当Column1.HeaderText = "実際配送担当";
            this.実際配送担当Column1.Name = "実際配送担当Column1";
            // 
            // 県別Column1
            // 
            this.県別Column1.DataPropertyName = "県別";
            this.県別Column1.HeaderText = "県別";
            this.県別Column1.Name = "県別Column1";
            this.県別Column1.ReadOnly = true;
            // 
            // 発注形態名称漢字Column1
            // 
            this.発注形態名称漢字Column1.DataPropertyName = "発注形態名称漢字";
            this.発注形態名称漢字Column1.HeaderText = "発注形態名称漢字";
            this.発注形態名称漢字Column1.Name = "発注形態名称漢字Column1";
            this.発注形態名称漢字Column1.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.backToolStripMenuItem.Text = "退回待发货状态";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelButton.Location = new System.Drawing.Point(589, 20);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(106, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.saveButton.Location = new System.Drawing.Point(780, 20);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(106, 32);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // shipNOLabel
            // 
            this.shipNOLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shipNOLabel.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shipNOLabel.Location = new System.Drawing.Point(119, 20);
            this.shipNOLabel.Name = "shipNOLabel";
            this.shipNOLabel.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.shipNOLabel.Size = new System.Drawing.Size(117, 21);
            this.shipNOLabel.TabIndex = 4;
            this.shipNOLabel.Text = "label1";
            this.shipNOLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "出荷指示書番号";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.closeButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closeButton.Location = new System.Drawing.Point(892, 20);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(106, 32);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // ShipOrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 448);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shipNOLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShipOrderListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label shipNOLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注日Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店名Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品口数Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際出荷数量Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際配送担当Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注形態名称漢字Column1;
        private System.Windows.Forms.Button closeButton;
    }
}