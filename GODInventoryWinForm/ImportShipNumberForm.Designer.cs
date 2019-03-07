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
            this.cancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressMsgLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "HACCYU";
            this.openFileDialog1.Filter = "Files (.xlsm)|*.xlsm|All Files (*.*)|*.*";
            // 
            // openFileBtton
            // 
            this.openFileBtton.BackColor = System.Drawing.SystemColors.Control;
            this.openFileBtton.Location = new System.Drawing.Point(787, 43);
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
            this.pathTextBox.Location = new System.Drawing.Point(125, 43);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(642, 21);
            this.pathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "ファイルを指定";
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.SystemColors.Control;
            this.importButton.Location = new System.Drawing.Point(493, 387);
            this.importButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(106, 32);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "導入";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(605, 387);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(106, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 352);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(809, 27);
            this.progressBar1.TabIndex = 5;
            // 
            // progressMsgLabel
            // 
            this.progressMsgLabel.AutoSize = true;
            this.progressMsgLabel.Location = new System.Drawing.Point(14, 334);
            this.progressMsgLabel.Name = "progressMsgLabel";
            this.progressMsgLabel.Size = new System.Drawing.Size(28, 14);
            this.progressMsgLabel.TabIndex = 6;
            this.progressMsgLabel.Text = "0/0";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("MS PGothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(121, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(534, 27);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "配车单导入";
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
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
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
            this.ClientSize = new System.Drawing.Size(844, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.progressMsgLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cancelButton);
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
            this.Text = "Update Order導入";
            this.Load += new System.EventHandler(this.ImportShipNumberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileBtton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressMsgLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
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