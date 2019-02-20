namespace GODInventoryWinForm
{
    partial class Bind__Transports
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
            this.fullNameTextBox12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.shortNameTextBox12 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submitFormButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.tidComboBox3 = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.widextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // fullNameTextBox12
            // 
            this.fullNameTextBox12.Location = new System.Drawing.Point(91, 62);
            this.fullNameTextBox12.Name = "fullNameTextBox12";
            this.fullNameTextBox12.Size = new System.Drawing.Size(190, 21);
            this.fullNameTextBox12.TabIndex = 16;
            this.fullNameTextBox12.TextChanged += new System.EventHandler(this.fullNameTextBox12_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "运输公司";
            // 
            // shortNameTextBox12
            // 
            this.shortNameTextBox12.Location = new System.Drawing.Point(91, 103);
            this.shortNameTextBox12.Name = "shortNameTextBox12";
            this.shortNameTextBox12.Size = new System.Drawing.Size(190, 21);
            this.shortNameTextBox12.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "字母简称";
            // 
            // submitFormButton
            // 
            this.submitFormButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.submitFormButton.Location = new System.Drawing.Point(91, 145);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(106, 32);
            this.submitFormButton.TabIndex = 20;
            this.submitFormButton.Text = "更新";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitFormButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelFormButton.Font = new System.Drawing.Font("MS PGothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelFormButton.Location = new System.Drawing.Point(377, 145);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(106, 32);
            this.cancelFormButton.TabIndex = 21;
            this.cancelFormButton.Text = "キャンセル";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            this.cancelFormButton.Click += new System.EventHandler(this.cancelFormButton_Click);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // tidComboBox3
            // 
            this.tidComboBox3.FormattingEnabled = true;
            this.tidComboBox3.Items.AddRange(new object[] {
            "丸健",
            "MKL",
            "マツモト産業"});
            this.tidComboBox3.Location = new System.Drawing.Point(295, 63);
            this.tidComboBox3.Name = "tidComboBox3";
            this.tidComboBox3.Size = new System.Drawing.Size(190, 20);
            this.tidComboBox3.TabIndex = 10000025;
            this.tidComboBox3.SelectedIndexChanged += new System.EventHandler(this.tidComboBox3_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10000026;
            this.label4.Text = "仓库";
            // 
            // widextBox
            // 
            this.widextBox.Location = new System.Drawing.Point(91, 12);
            this.widextBox.Name = "widextBox";
            this.widextBox.ReadOnly = true;
            this.widextBox.Size = new System.Drawing.Size(190, 21);
            this.widextBox.TabIndex = 10000027;
            // 
            // Bind__Transports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 205);
            this.Controls.Add(this.widextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tidComboBox3);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.cancelFormButton);
            this.Controls.Add(this.shortNameTextBox12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullNameTextBox12);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Bind__Transports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit__Transports";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fullNameTextBox12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox shortNameTextBox12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button cancelFormButton;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ComboBox tidComboBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox widextBox;
        private System.Windows.Forms.Label label4;
    }
}