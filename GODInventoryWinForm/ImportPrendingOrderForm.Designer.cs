namespace GODInventoryWinForm
{
    partial class ImportPrendingOrderForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileBtton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.県別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自社コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最小発注単位数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価税抜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額税抜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.totalRecordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Files (*.xlsm,*.xlsx)|*.xlsm;*.xlsx|All Files (*.*)|*.*";
            // 
            // openFileBtton
            // 
            this.openFileBtton.BackColor = System.Drawing.SystemColors.Control;
            this.openFileBtton.Location = new System.Drawing.Point(787, 58);
            this.openFileBtton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openFileBtton.Name = "openFileBtton";
            this.openFileBtton.Size = new System.Drawing.Size(36, 21);
            this.openFileBtton.TabIndex = 0;
            this.openFileBtton.Text = "...";
            this.openFileBtton.UseVisualStyleBackColor = false;
            this.openFileBtton.Click += new System.EventHandler(this.openFileBtton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(125, 58);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(656, 21);
            this.pathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "ファイルを指定";
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.SystemColors.Control;
            this.importButton.Location = new System.Drawing.Point(605, 387);
            this.importButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(106, 32);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "導入";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("MS PGothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(2, 17);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(840, 27);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "受注内容一括導入";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(717, 387);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(106, 32);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.県別,
            this.店舗コード,
            this.店舗名漢字,
            this.自社コード,
            this.品名漢字,
            this.最小発注単位数量,
            this.口数,
            this.発注数量,
            this.原単価税抜,
            this.原価金額税抜});
            this.dataGridView1.Location = new System.Drawing.Point(14, 94);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(809, 236);
            this.dataGridView1.TabIndex = 8;
            // 
            // 県別
            // 
            this.県別.DataPropertyName = "県別";
            this.県別.HeaderText = "県別";
            this.県別.Name = "県別";
            this.県別.ReadOnly = true;
            // 
            // 店舗コード
            // 
            this.店舗コード.DataPropertyName = "店舗コード";
            this.店舗コード.HeaderText = "店舗コード";
            this.店舗コード.Name = "店舗コード";
            this.店舗コード.ReadOnly = true;
            // 
            // 店舗名漢字
            // 
            this.店舗名漢字.DataPropertyName = "店舗名漢字";
            this.店舗名漢字.HeaderText = "店舗名漢字";
            this.店舗名漢字.Name = "店舗名漢字";
            this.店舗名漢字.ReadOnly = true;
            // 
            // 自社コード
            // 
            this.自社コード.DataPropertyName = "自社コード";
            this.自社コード.HeaderText = "自社コード";
            this.自社コード.Name = "自社コード";
            this.自社コード.ReadOnly = true;
            // 
            // 品名漢字
            // 
            this.品名漢字.DataPropertyName = "品名漢字";
            this.品名漢字.HeaderText = "品名漢字";
            this.品名漢字.Name = "品名漢字";
            this.品名漢字.ReadOnly = true;
            // 
            // 最小発注単位数量
            // 
            this.最小発注単位数量.DataPropertyName = "最小発注単位数量";
            this.最小発注単位数量.HeaderText = "最小発注単位数量";
            this.最小発注単位数量.Name = "最小発注単位数量";
            this.最小発注単位数量.ReadOnly = true;
            // 
            // 口数
            // 
            this.口数.DataPropertyName = "口数";
            this.口数.HeaderText = "口数";
            this.口数.Name = "口数";
            this.口数.ReadOnly = true;
            // 
            // 発注数量
            // 
            this.発注数量.DataPropertyName = "発注数量";
            this.発注数量.HeaderText = "発注数量";
            this.発注数量.Name = "発注数量";
            this.発注数量.ReadOnly = true;
            // 
            // 原単価税抜
            // 
            this.原単価税抜.DataPropertyName = "原単価税抜";
            this.原単価税抜.HeaderText = "原単価税抜";
            this.原単価税抜.Name = "原単価税抜";
            this.原単価税抜.ReadOnly = true;
            // 
            // 原価金額税抜
            // 
            this.原価金額税抜.DataPropertyName = "原価金額税抜";
            this.原価金額税抜.HeaderText = "原価金額税抜";
            this.原価金額税抜.Name = "原価金額税抜";
            this.原価金額税抜.ReadOnly = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // totalRecordLabel
            // 
            this.totalRecordLabel.AutoSize = true;
            this.totalRecordLabel.Location = new System.Drawing.Point(14, 338);
            this.totalRecordLabel.Name = "totalRecordLabel";
            this.totalRecordLabel.Size = new System.Drawing.Size(64, 14);
            this.totalRecordLabel.TabIndex = 9;
            this.totalRecordLabel.Text = "合計 0 行";
            // 
            // ImportPrendingOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 432);
            this.Controls.Add(this.totalRecordLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.openFileBtton);
            this.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportPrendingOrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "受注内容一括導入";
            this.Load += new System.EventHandler(this.ImportShipNumberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileBtton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最小発注単位数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価税抜;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額税抜;
        private System.Windows.Forms.Label totalRecordLabel;
    }
}