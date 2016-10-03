﻿namespace GODInventoryWinForm
{
    partial class ImportOrderCSVForm
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
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "HACCYU";
            this.openFileDialog1.Filter = "Text Files (.csv)|*.csv|All Files (*.*)|*.*";
            // 
            // openFileBtton
            // 
            this.openFileBtton.Location = new System.Drawing.Point(413, 83);
            this.openFileBtton.Name = "openFileBtton";
            this.openFileBtton.Size = new System.Drawing.Size(31, 23);
            this.openFileBtton.TabIndex = 0;
            this.openFileBtton.Text = "...";
            this.openFileBtton.UseVisualStyleBackColor = true;
            this.openFileBtton.Click += new System.EventHandler(this.openFileBtton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(130, 84);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(277, 21);
            this.pathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ファイルを指定";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(132, 185);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 32);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "導入";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(238, 185);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 32);
            this.cancelButton.TabIndex = 4;
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
            this.progressBar1.Location = new System.Drawing.Point(35, 137);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(409, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // progressMsgLabel
            // 
            this.progressMsgLabel.AutoSize = true;
            this.progressMsgLabel.Location = new System.Drawing.Point(35, 119);
            this.progressMsgLabel.Name = "progressMsgLabel";
            this.progressMsgLabel.Size = new System.Drawing.Size(23, 12);
            this.progressMsgLabel.TabIndex = 6;
            this.progressMsgLabel.Text = "0/0";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(12, 29);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(458, 23);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "SNAP受注ＣＳＶデータ導入";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(344, 185);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 32);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ImportOrderCSVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 242);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.progressMsgLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.openFileBtton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportOrderCSVForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SNAP受注ＣＳＶデータ導入";
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
    }
}