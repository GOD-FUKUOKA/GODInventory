namespace GODInventoryWinForm.Controls
{
    partial class OrdersControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pendingButton = new System.Windows.Forms.Button();
            this.receiveOrderButton = new System.Windows.Forms.Button();
            this.waitToShipButton = new System.Windows.Forms.Button();
            this.shippingOrderButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderConfirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pendingButton
            // 
            this.pendingButton.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pendingButton.Location = new System.Drawing.Point(222, 195);
            this.pendingButton.Name = "pendingButton";
            this.pendingButton.Size = new System.Drawing.Size(144, 58);
            this.pendingButton.TabIndex = 1;
            this.pendingButton.Text = "受注処理";
            this.pendingButton.UseVisualStyleBackColor = true;
            this.pendingButton.Click += new System.EventHandler(this.pendingButton_Click);
            // 
            // receiveOrderButton
            // 
            this.receiveOrderButton.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.receiveOrderButton.Location = new System.Drawing.Point(21, 68);
            this.receiveOrderButton.Name = "receiveOrderButton";
            this.receiveOrderButton.Size = new System.Drawing.Size(180, 58);
            this.receiveOrderButton.TabIndex = 4;
            this.receiveOrderButton.Text = "サーバーに接続し、新しい受注データをダウンロードします";
            this.receiveOrderButton.UseVisualStyleBackColor = true;
            this.receiveOrderButton.Click += new System.EventHandler(this.receiveOrderButton_Click);
            // 
            // waitToShipButton
            // 
            this.waitToShipButton.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waitToShipButton.Location = new System.Drawing.Point(423, 195);
            this.waitToShipButton.Name = "waitToShipButton";
            this.waitToShipButton.Size = new System.Drawing.Size(144, 58);
            this.waitToShipButton.TabIndex = 2;
            this.waitToShipButton.Text = "配車処理";
            this.waitToShipButton.UseVisualStyleBackColor = true;
            this.waitToShipButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // shippingOrderButton
            // 
            this.shippingOrderButton.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shippingOrderButton.Location = new System.Drawing.Point(624, 195);
            this.shippingOrderButton.Name = "shippingOrderButton";
            this.shippingOrderButton.Size = new System.Drawing.Size(144, 58);
            this.shippingOrderButton.TabIndex = 3;
            this.shippingOrderButton.Text = "出荷伝票処理";
            this.shippingOrderButton.UseVisualStyleBackColor = true;
            this.shippingOrderButton.Click += new System.EventHandler(this.shippedOrderButton_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(322, 316);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 58);
            this.button6.TabIndex = 4;
            this.button6.Text = "伝票検索";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(380, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(581, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "->";
            // 
            // orderConfirmButton
            // 
            this.orderConfirmButton.Enabled = false;
            this.orderConfirmButton.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.orderConfirmButton.Location = new System.Drawing.Point(588, 68);
            this.orderConfirmButton.Name = "orderConfirmButton";
            this.orderConfirmButton.Size = new System.Drawing.Size(180, 58);
            this.orderConfirmButton.TabIndex = 5;
            this.orderConfirmButton.Text = "サーバーに接続し、新しい受領データをダウンロードします";
            this.orderConfirmButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(84, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 57);
            this.label1.TabIndex = 11;
            this.label1.Text = "|\r\n|\r\nV";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(687, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 57);
            this.label4.TabIndex = 12;
            this.label4.Text = "|\r\n|\r\nV";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.contentPanel.Controls.Add(this.label5);
            this.contentPanel.Controls.Add(this.newButton);
            this.contentPanel.Controls.Add(this.button6);
            this.contentPanel.Controls.Add(this.orderConfirmButton);
            this.contentPanel.Controls.Add(this.label4);
            this.contentPanel.Controls.Add(this.pendingButton);
            this.contentPanel.Controls.Add(this.label1);
            this.contentPanel.Controls.Add(this.receiveOrderButton);
            this.contentPanel.Controls.Add(this.waitToShipButton);
            this.contentPanel.Controls.Add(this.label3);
            this.contentPanel.Controls.Add(this.shippingOrderButton);
            this.contentPanel.Controls.Add(this.label2);
            this.contentPanel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentPanel.Location = new System.Drawing.Point(3, 20);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(789, 377);
            this.contentPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(179, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "->";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newButton.Location = new System.Drawing.Point(21, 195);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(144, 58);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "ダブリ確認";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // OrdersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrdersControl";
            this.Size = new System.Drawing.Size(795, 413);
            this.Load += new System.EventHandler(this.OrdersControl_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.OrdersControl_ControlRemoved);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OrdersControl_Paint);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pendingButton;
        private System.Windows.Forms.Button receiveOrderButton;
        private System.Windows.Forms.Button waitToShipButton;
        private System.Windows.Forms.Button shippingOrderButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button orderConfirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button newButton;
    }
}
