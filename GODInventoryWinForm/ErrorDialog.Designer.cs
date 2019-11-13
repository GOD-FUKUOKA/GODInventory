namespace GODInventoryWinForm
{
    partial class ErrorDialog
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
            this.yesButton1 = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderCountlabel = new System.Windows.Forms.Label();
            this.importedOrderLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.updatedAtLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesButton1
            // 
            this.yesButton1.Location = new System.Drawing.Point(148, 203);
            this.yesButton1.Name = "yesButton1";
            this.yesButton1.Size = new System.Drawing.Size(106, 32);
            this.yesButton1.TabIndex = 0;
            this.yesButton1.Text = "再導入";
            this.yesButton1.UseVisualStyleBackColor = true;
            this.yesButton1.Click += new System.EventHandler(this.yesButton1_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(260, 203);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(106, 32);
            this.noButton.TabIndex = 0;
            this.noButton.Text = "そのまま終了";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "枚数は一致しませんが、再度導入しますか？";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "導入された枚数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "伝票枚数：";
            // 
            // orderCountlabel
            // 
            this.orderCountlabel.AutoSize = true;
            this.orderCountlabel.Font = new System.Drawing.Font("MS PGothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderCountlabel.ForeColor = System.Drawing.Color.Blue;
            this.orderCountlabel.Location = new System.Drawing.Point(165, 47);
            this.orderCountlabel.Name = "orderCountlabel";
            this.orderCountlabel.Size = new System.Drawing.Size(29, 29);
            this.orderCountlabel.TabIndex = 4;
            this.orderCountlabel.Text = "1";
            // 
            // importedOrderLabel
            // 
            this.importedOrderLabel.AutoSize = true;
            this.importedOrderLabel.Font = new System.Drawing.Font("MS PGothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importedOrderLabel.ForeColor = System.Drawing.Color.Red;
            this.importedOrderLabel.Location = new System.Drawing.Point(219, 107);
            this.importedOrderLabel.Name = "importedOrderLabel";
            this.importedOrderLabel.Size = new System.Drawing.Size(29, 29);
            this.importedOrderLabel.TabIndex = 4;
            this.importedOrderLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(58, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "受信時刻：";
            // 
            // updatedAtLabel
            // 
            this.updatedAtLabel.AutoSize = true;
            this.updatedAtLabel.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.updatedAtLabel.Location = new System.Drawing.Point(166, 87);
            this.updatedAtLabel.Name = "updatedAtLabel";
            this.updatedAtLabel.Size = new System.Drawing.Size(202, 19);
            this.updatedAtLabel.TabIndex = 6;
            this.updatedAtLabel.Text = "2019-08-08 12:00:00";
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 279);
            this.Controls.Add(this.updatedAtLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.importedOrderLabel);
            this.Controls.Add(this.orderCountlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton1);
            this.Font = new System.Drawing.Font("MS PGothic", 10.5F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "誤った";
            this.Load += new System.EventHandler(this.ErrorDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton1;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label orderCountlabel;
        private System.Windows.Forms.Label importedOrderLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label updatedAtLabel;
    }
}