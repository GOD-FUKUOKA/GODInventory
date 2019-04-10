namespace GODInventoryWinForm.Controls.Warehouse
{
    partial class NewForm
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
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.shortNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.faxTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.memoTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // submitFormButton
            // 
            this.submitFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.submitFormButton.Location = new System.Drawing.Point(339, 340);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(106, 32);
            this.submitFormButton.TabIndex = 10000042;
            this.submitFormButton.Text = "保存";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelFormButton.Location = new System.Drawing.Point(451, 340);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(106, 32);
            this.cancelFormButton.TabIndex = 10000043;
            this.cancelFormButton.Text = "キャンセル";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            this.cancelFormButton.Click += new System.EventHandler(this.cancelFormButton_Click);
            // 
            // shortNameTextBox
            // 
            this.shortNameTextBox.Location = new System.Drawing.Point(93, 110);
            this.shortNameTextBox.Name = "shortNameTextBox";
            this.shortNameTextBox.Size = new System.Drawing.Size(466, 19);
            this.shortNameTextBox.TabIndex = 10000037;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(26, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10000045;
            this.label1.Text = "英字記号";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(93, 80);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(466, 19);
            this.fullNameTextBox.TabIndex = 10000036;
            this.fullNameTextBox.TextChanged += new System.EventHandler(this.fullNameTextBox12_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(54, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 10000044;
            this.label13.Text = "全称";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // faxTextBox
            // 
            this.faxTextBox.Location = new System.Drawing.Point(93, 230);
            this.faxTextBox.Name = "faxTextBox";
            this.faxTextBox.Size = new System.Drawing.Size(466, 19);
            this.faxTextBox.TabIndex = 10000040;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(57, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 10000050;
            this.label6.Text = "FAX";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(93, 200);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(466, 19);
            this.phoneTextBox.TabIndex = 10000039;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(54, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 10000049;
            this.label5.Text = "電話";
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(93, 260);
            this.memoTextBox.Multiline = true;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(466, 60);
            this.memoTextBox.TabIndex = 10000041;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(54, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10000047;
            this.label7.Text = "備考";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(93, 140);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(466, 51);
            this.addressTextBox.TabIndex = 10000038;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(54, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 10000048;
            this.label4.Text = "住所";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("MS PGothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(2, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 37);
            this.label2.TabIndex = 10000051;
            this.label2.Text = "新規倉庫";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.Controls.Add(this.shortNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.faxTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.memoTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("MS PGothic", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新規倉庫";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private System.Windows.Forms.TextBox shortNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox faxTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}