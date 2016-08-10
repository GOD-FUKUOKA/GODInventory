namespace GODInventoryWinForm.Controls
{
    partial class StockOrderForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btSearchtrock = new System.Windows.Forms.Button();
            this.btexitstock = new System.Windows.Forms.Button();
            this.btRuku = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btSearchtrock, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btexitstock, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btRuku, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btSearchtrock
            // 
            this.btSearchtrock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSearchtrock.Location = new System.Drawing.Point(407, 281);
            this.btSearchtrock.Name = "btSearchtrock";
            this.btSearchtrock.Size = new System.Drawing.Size(102, 52);
            this.btSearchtrock.TabIndex = 2;
            this.btSearchtrock.Text = "照会倉庫";
            this.btSearchtrock.UseVisualStyleBackColor = true;
            this.btSearchtrock.Click += new System.EventHandler(this.btSearchtrock_Click);
            // 
            // btexitstock
            // 
            this.btexitstock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btexitstock.Location = new System.Drawing.Point(407, 59);
            this.btexitstock.Name = "btexitstock";
            this.btexitstock.Size = new System.Drawing.Size(102, 52);
            this.btexitstock.TabIndex = 1;
            this.btexitstock.Text = "出庫";
            this.btexitstock.UseVisualStyleBackColor = true;
            this.btexitstock.Click += new System.EventHandler(this.btexitstock_Click);
            // 
            // btRuku
            // 
            this.btRuku.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btRuku.Location = new System.Drawing.Point(101, 59);
            this.btRuku.Name = "btRuku";
            this.btRuku.Size = new System.Drawing.Size(102, 52);
            this.btRuku.TabIndex = 0;
            this.btRuku.Text = "入庫";
            this.btRuku.UseVisualStyleBackColor = true;
            this.btRuku.Click += new System.EventHandler(this.btRuku_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(101, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "倉庫の間移動";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btTransferStrock_Click);
            // 
            // StockOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StockOrderForm";
            this.Size = new System.Drawing.Size(611, 443);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btexitstock;
        private System.Windows.Forms.Button btRuku;
        private System.Windows.Forms.Button btSearchtrock;
        private System.Windows.Forms.Button button1;
    }
}