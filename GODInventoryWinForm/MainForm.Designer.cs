namespace GODInventoryWinForm
{
    using GODInventoryWinForm.Controls;
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.orderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.warehouseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.productToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.storesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingToolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.generalSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importOrderTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importReceivedOrderTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importReceivedCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.branchLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.entityDataSource1 = new GODInventory.EntityDataSource(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.orderToolStripButton,
            this.warehouseToolStripButton,
            this.productToolStripButton,
            this.storesToolStripButton,
            this.toolStripSeparator1,
            this.settingToolStripDropDownButton2,
            this.importToolStripDropDownButton1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 57);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::GODInventoryWinForm.Properties.Resources.dashboard;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(54, 54);
            this.toolStripButton3.Text = "メイン画面";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // orderToolStripButton
            // 
            this.orderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.orderToolStripButton.Image = global::GODInventoryWinForm.Properties.Resources.order;
            this.orderToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.orderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orderToolStripButton.Name = "orderToolStripButton";
            this.orderToolStripButton.Size = new System.Drawing.Size(54, 54);
            this.orderToolStripButton.Text = "受注管理";
            this.orderToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // warehouseToolStripButton
            // 
            this.warehouseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.warehouseToolStripButton.Image = global::GODInventoryWinForm.Properties.Resources.warehouse;
            this.warehouseToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.warehouseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.warehouseToolStripButton.Name = "warehouseToolStripButton";
            this.warehouseToolStripButton.Size = new System.Drawing.Size(54, 54);
            this.warehouseToolStripButton.Text = "在庫管理";
            this.warehouseToolStripButton.Click += new System.EventHandler(this.warehouseToolStripButton_Click);
            // 
            // productToolStripButton
            // 
            this.productToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productToolStripButton.Image = global::GODInventoryWinForm.Properties.Resources.product;
            this.productToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.productToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.productToolStripButton.Name = "productToolStripButton";
            this.productToolStripButton.Size = new System.Drawing.Size(54, 54);
            this.productToolStripButton.Text = "商品リスト";
            this.productToolStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // storesToolStripButton
            // 
            this.storesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.storesToolStripButton.Image = global::GODInventoryWinForm.Properties.Resources.store;
            this.storesToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.storesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.storesToolStripButton.Name = "storesToolStripButton";
            this.storesToolStripButton.Size = new System.Drawing.Size(54, 54);
            this.storesToolStripButton.Text = "店舗リスト";
            this.storesToolStripButton.Click += new System.EventHandler(this.customerToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // settingToolStripDropDownButton2
            // 
            this.settingToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingToolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalSettingToolStripMenuItem,
            this.orderSettingToolStripMenuItem,
            this.branchToolStripMenuItem});
            this.settingToolStripDropDownButton2.Image = global::GODInventoryWinForm.Properties.Resources.setting;
            this.settingToolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingToolStripDropDownButton2.Name = "settingToolStripDropDownButton2";
            this.settingToolStripDropDownButton2.Size = new System.Drawing.Size(63, 54);
            this.settingToolStripDropDownButton2.Text = "設定";
            this.settingToolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // generalSettingToolStripMenuItem
            // 
            this.generalSettingToolStripMenuItem.Name = "generalSettingToolStripMenuItem";
            this.generalSettingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.generalSettingToolStripMenuItem.Text = "基本設定";
            this.generalSettingToolStripMenuItem.Click += new System.EventHandler(this.generalSettingToolStripMenuItem_Click);
            // 
            // orderSettingToolStripMenuItem
            // 
            this.orderSettingToolStripMenuItem.Name = "orderSettingToolStripMenuItem";
            this.orderSettingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.orderSettingToolStripMenuItem.Text = "商品仕入原価設定";
            this.orderSettingToolStripMenuItem.Click += new System.EventHandler(this.orderSettingToolStripMenuItem_Click);
            // 
            // branchToolStripMenuItem
            // 
            this.branchToolStripMenuItem.Name = "branchToolStripMenuItem";
            this.branchToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.branchToolStripMenuItem.Text = "组织机构管理";
            this.branchToolStripMenuItem.Click += new System.EventHandler(this.branchToolStripMenuItem_Click);
            // 
            // importToolStripDropDownButton1
            // 
            this.importToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importToolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importOrderTextToolStripMenuItem,
            this.importReceivedOrderTextToolStripMenuItem,
            this.importCSVToolStripMenuItem,
            this.importReceivedCSVToolStripMenuItem,
            this.importFaxToolStripMenuItem});
            this.importToolStripDropDownButton1.Image = global::GODInventoryWinForm.Properties.Resources.tool;
            this.importToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importToolStripDropDownButton1.Name = "importToolStripDropDownButton1";
            this.importToolStripDropDownButton1.Size = new System.Drawing.Size(63, 54);
            this.importToolStripDropDownButton1.Text = "データ導入";
            // 
            // importOrderTextToolStripMenuItem
            // 
            this.importOrderTextToolStripMenuItem.Name = "importOrderTextToolStripMenuItem";
            this.importOrderTextToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.importOrderTextToolStripMenuItem.Text = "受注データ導入";
            this.importOrderTextToolStripMenuItem.Click += new System.EventHandler(this.importOrderTextToolStripMenuItem_Click);
            // 
            // importReceivedOrderTextToolStripMenuItem
            // 
            this.importReceivedOrderTextToolStripMenuItem.Name = "importReceivedOrderTextToolStripMenuItem";
            this.importReceivedOrderTextToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.importReceivedOrderTextToolStripMenuItem.Text = "受領データ導入";
            this.importReceivedOrderTextToolStripMenuItem.Click += new System.EventHandler(this.importReceivedOrderTextToolStripMenuItem_Click);
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.importCSVToolStripMenuItem.Text = "SNAP受注ＣＳＶデータ導入";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVToolStripMenuItem_Click);
            // 
            // importReceivedCSVToolStripMenuItem
            // 
            this.importReceivedCSVToolStripMenuItem.Name = "importReceivedCSVToolStripMenuItem";
            this.importReceivedCSVToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.importReceivedCSVToolStripMenuItem.Text = "SNAP受領ＣＳＶデータ導入";
            this.importReceivedCSVToolStripMenuItem.Click += new System.EventHandler(this.importReceivedCSVToolStripMenuItem_Click);
            // 
            // importFaxToolStripMenuItem
            // 
            this.importFaxToolStripMenuItem.Name = "importFaxToolStripMenuItem";
            this.importFaxToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.importFaxToolStripMenuItem.Text = "ＦＲＩＭＯ受注ＣＳＶデータ導入";
            this.importFaxToolStripMenuItem.Click += new System.EventHandler(this.importFaxToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 341);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // branchLabel
            // 
            this.branchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.branchLabel.BackColor = System.Drawing.Color.Transparent;
            this.branchLabel.Font = new System.Drawing.Font("MS PGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchLabel.Location = new System.Drawing.Point(667, 7);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(162, 20);
            this.branchLabel.TabIndex = 2;
            this.branchLabel.Text = "branch";
            this.branchLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("MS PGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(667, 26);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(162, 20);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "fullname";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Yellow;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(144, 54);
            this.toolStripButton1.Text = "临时测试分公司员工店铺";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 411);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.branchLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "受注管理システム For ナフコ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton orderToolStripButton;
        private System.Windows.Forms.ToolStripButton productToolStripButton;
        private GODInventory.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton warehouseToolStripButton;
        private System.Windows.Forms.ToolStripButton storesToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton importToolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importOrderTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importReceivedOrderTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importReceivedCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton settingToolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem generalSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchToolStripMenuItem;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

