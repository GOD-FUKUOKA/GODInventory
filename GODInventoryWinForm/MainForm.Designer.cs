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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.orderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.warehouseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.productToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.storesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importOrderTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importReceivedOrderTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importReceivedCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
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
            this.settingToolStripButton,
            this.toolStripDropDownButton1});
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
            this.toolStripButton3.Text = "Dashboard";
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
            this.orderToolStripButton.Text = "Orders";
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
            this.warehouseToolStripButton.Text = "Warehouse";
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
            this.productToolStripButton.Text = "Products";
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
            this.storesToolStripButton.Text = "Stores";
            this.storesToolStripButton.Click += new System.EventHandler(this.customerToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // settingToolStripButton
            // 
            this.settingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingToolStripButton.Image = global::GODInventoryWinForm.Properties.Resources.setting;
            this.settingToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingToolStripButton.Name = "settingToolStripButton";
            this.settingToolStripButton.Size = new System.Drawing.Size(54, 54);
            this.settingToolStripButton.Text = "Setting";
            this.settingToolStripButton.Click += new System.EventHandler(this.settingToolStripButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importOrderTextToolStripMenuItem,
            this.importReceivedOrderTextToolStripMenuItem,
            this.importCSVToolStripMenuItem,
            this.importReceivedCSVToolStripMenuItem,
            this.importFaxToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::GODInventoryWinForm.Properties.Resources.tool;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(63, 54);
            this.toolStripDropDownButton1.Text = "ImportTxt";
            // 
            // importOrderTextToolStripMenuItem
            // 
            this.importOrderTextToolStripMenuItem.Name = "importOrderTextToolStripMenuItem";
            this.importOrderTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importOrderTextToolStripMenuItem.Text = "导入受注数据";
            this.importOrderTextToolStripMenuItem.Click += new System.EventHandler(this.importOrderTextToolStripMenuItem_Click);
            // 
            // importReceivedOrderTextToolStripMenuItem
            // 
            this.importReceivedOrderTextToolStripMenuItem.Name = "importReceivedOrderTextToolStripMenuItem";
            this.importReceivedOrderTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importReceivedOrderTextToolStripMenuItem.Text = "导入受領数据";
            this.importReceivedOrderTextToolStripMenuItem.Click += new System.EventHandler(this.importReceivedOrderTextToolStripMenuItem_Click);
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importCSVToolStripMenuItem.Text = "导入受注CSV";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVToolStripMenuItem_Click);
            // 
            // importReceivedCSVToolStripMenuItem
            // 
            this.importReceivedCSVToolStripMenuItem.Name = "importReceivedCSVToolStripMenuItem";
            this.importReceivedCSVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importReceivedCSVToolStripMenuItem.Text = "导入受領CSV";
            this.importReceivedCSVToolStripMenuItem.Click += new System.EventHandler(this.importReceivedCSVToolStripMenuItem_Click);
            // 
            // importFaxToolStripMenuItem
            // 
            this.importFaxToolStripMenuItem.Name = "importFaxToolStripMenuItem";
            this.importFaxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importFaxToolStripMenuItem.Text = "导入FaxCSV";
            this.importFaxToolStripMenuItem.Click += new System.EventHandler(this.importFaxToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 372);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 449);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "G.O.D在庫管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton orderToolStripButton;
        private System.Windows.Forms.ToolStripButton productToolStripButton;
        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton warehouseToolStripButton;
        private System.Windows.Forms.ToolStripButton storesToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importOrderTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importReceivedOrderTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importReceivedCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFaxToolStripMenuItem;
    }
}

