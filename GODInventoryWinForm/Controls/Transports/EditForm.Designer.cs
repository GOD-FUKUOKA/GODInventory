namespace GODInventoryWinForm.Controls.Transports
{
    partial class EditForm
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
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.shortNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.faxTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.memoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(94, 89);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(466, 19);
            this.fullNameTextBox.TabIndex = 0;
            this.fullNameTextBox.TextChanged += new System.EventHandler(this.fullNameTextBox12_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(55, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 17;
            this.label13.Text = "全称";
            // 
            // shortNameTextBox
            // 
            this.shortNameTextBox.Location = new System.Drawing.Point(94, 119);
            this.shortNameTextBox.Name = "shortNameTextBox";
            this.shortNameTextBox.Size = new System.Drawing.Size(466, 19);
            this.shortNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(27, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "英字記号";
            // 
            // submitFormButton
            // 
            this.submitFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.submitFormButton.Location = new System.Drawing.Point(340, 349);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(106, 32);
            this.submitFormButton.TabIndex = 6;
            this.submitFormButton.Text = "保存";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelFormButton.Location = new System.Drawing.Point(452, 349);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(106, 32);
            this.cancelFormButton.TabIndex = 7;
            this.cancelFormButton.Text = "キャンセル";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            this.cancelFormButton.Click += new System.EventHandler(this.cancelFormButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("MS PGothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(598, 45);
            this.label3.TabIndex = 10000029;
            this.label3.Text = "新規配送担当";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(94, 149);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(466, 51);
            this.addressTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(55, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 10000031;
            this.label4.Text = "住所";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(94, 209);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(466, 19);
            this.phoneTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(55, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 10000033;
            this.label5.Text = "電話";
            // 
            // faxTextBox
            // 
            this.faxTextBox.Location = new System.Drawing.Point(94, 239);
            this.faxTextBox.Name = "faxTextBox";
            this.faxTextBox.Size = new System.Drawing.Size(466, 19);
            this.faxTextBox.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(58, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 10000035;
            this.label6.Text = "FAX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(55, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10000031;
            this.label7.Text = "備考";
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(94, 269);
            this.memoTextBox.Multiline = true;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(466, 60);
            this.memoTextBox.TabIndex = 5;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 407);
            this.Controls.Add(this.faxTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.memoTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.Controls.Add(this.shortNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新規配送担当";
            this.Shown += new System.EventHandler(this.EditForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox shortNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox faxTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.Label label7;
    }
}