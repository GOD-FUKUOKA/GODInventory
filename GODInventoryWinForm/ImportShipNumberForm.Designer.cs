namespace GODInventoryWinForm
{
    partial class ImportShipNumberForm
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalRecordLabel = new System.Windows.Forms.Label();
            this.selectedColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.配送担当 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.車番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.荷主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.処理済 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Files (*.xlsm,*.xlsx)|*.xlsm;*.xlsx|All Files (*.*)|*.*";
            // 
            // openFileBtton
            // 
            this.openFileBtton.BackColor = System.Drawing.SystemColors.Control;
            this.openFileBtton.Location = new System.Drawing.Point(620, 58);
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
            this.pathTextBox.Size = new System.Drawing.Size(488, 21);
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
            this.importButton.Location = new System.Drawing.Point(428, 363);
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
            this.titleLabel.Location = new System.Drawing.Point(43, 17);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1237, 27);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "配车单导入";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(550, 363);
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
            this.selectedColumn1,
            this.配送担当,
            this.車番,
            this.出荷日,
            this.納品日,
            this.荷主,
            this.品名,
            this.口数,
            this.数量,
            this.伝票番号,
            this.処理済});
            this.dataGridView1.Location = new System.Drawing.Point(15, 94);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(641, 261);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridView2.Location = new System.Drawing.Point(675, 94);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(641, 261);
            this.dataGridView2.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "配送担当";
            this.dataGridViewTextBoxColumn1.HeaderText = "配送担当";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "車番";
            this.dataGridViewTextBoxColumn2.HeaderText = "車番";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "出荷日";
            this.dataGridViewTextBoxColumn3.HeaderText = "出荷日";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "納品日";
            this.dataGridViewTextBoxColumn4.HeaderText = "納品日";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "荷主";
            this.dataGridViewTextBoxColumn5.HeaderText = "荷主";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "品名";
            this.dataGridViewTextBoxColumn6.HeaderText = "品名";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "口数";
            this.dataGridViewTextBoxColumn7.HeaderText = "口数";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "数量";
            this.dataGridViewTextBoxColumn8.HeaderText = "数量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "伝票番号";
            this.dataGridViewTextBoxColumn9.HeaderText = "伝票番号";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "処理済";
            this.dataGridViewTextBoxColumn10.HeaderText = "処理済";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // totalRecordLabel
            // 
            this.totalRecordLabel.AutoSize = true;
            this.totalRecordLabel.Location = new System.Drawing.Point(12, 363);
            this.totalRecordLabel.Name = "totalRecordLabel";
            this.totalRecordLabel.Size = new System.Drawing.Size(64, 14);
            this.totalRecordLabel.TabIndex = 10;
            this.totalRecordLabel.Text = "合計 0 行";
            // 
            // selectedColumn1
            // 
            this.selectedColumn1.DataPropertyName = "selected";
            this.selectedColumn1.FalseValue = "0";
            this.selectedColumn1.Frozen = true;
            this.selectedColumn1.HeaderText = "selected";
            this.selectedColumn1.Name = "selectedColumn1";
            this.selectedColumn1.ReadOnly = true;
            this.selectedColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectedColumn1.TrueValue = "1";
            this.selectedColumn1.Width = 50;
            // 
            // 配送担当
            // 
            this.配送担当.DataPropertyName = "配送担当";
            this.配送担当.HeaderText = "配送担当";
            this.配送担当.Name = "配送担当";
            this.配送担当.ReadOnly = true;
            // 
            // 車番
            // 
            this.車番.DataPropertyName = "車番";
            this.車番.HeaderText = "車番";
            this.車番.Name = "車番";
            this.車番.ReadOnly = true;
            this.車番.Width = 60;
            // 
            // 出荷日
            // 
            this.出荷日.DataPropertyName = "出荷日";
            this.出荷日.HeaderText = "出荷日";
            this.出荷日.Name = "出荷日";
            this.出荷日.ReadOnly = true;
            // 
            // 納品日
            // 
            this.納品日.DataPropertyName = "納品日";
            this.納品日.HeaderText = "納品日";
            this.納品日.Name = "納品日";
            this.納品日.ReadOnly = true;
            // 
            // 荷主
            // 
            this.荷主.DataPropertyName = "荷主";
            this.荷主.HeaderText = "荷主";
            this.荷主.Name = "荷主";
            this.荷主.ReadOnly = true;
            // 
            // 品名
            // 
            this.品名.DataPropertyName = "品名";
            this.品名.HeaderText = "品名";
            this.品名.Name = "品名";
            this.品名.ReadOnly = true;
            // 
            // 口数
            // 
            this.口数.DataPropertyName = "口数";
            this.口数.HeaderText = "口数";
            this.口数.Name = "口数";
            this.口数.ReadOnly = true;
            this.口数.Width = 60;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            this.数量.Width = 50;
            // 
            // 伝票番号
            // 
            this.伝票番号.DataPropertyName = "伝票番号";
            this.伝票番号.HeaderText = "伝票番号";
            this.伝票番号.Name = "伝票番号";
            this.伝票番号.ReadOnly = true;
            // 
            // 処理済
            // 
            this.処理済.DataPropertyName = "処理済";
            this.処理済.HeaderText = "処理済";
            this.処理済.Name = "処理済";
            this.処理済.ReadOnly = true;
            // 
            // ImportShipNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 432);
            this.Controls.Add(this.totalRecordLabel);
            this.Controls.Add(this.dataGridView2);
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
            this.Name = "ImportShipNumberForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ship number import";
            this.Load += new System.EventHandler(this.ImportShipNumberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label totalRecordLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当;
        private System.Windows.Forms.DataGridViewTextBoxColumn 車番;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 荷主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 処理済;
    }
}