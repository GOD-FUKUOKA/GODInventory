namespace GODInventoryWinForm.Controls
{
    partial class OrderHistoryForm
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
            this.entityDataSource1 = new GODInventory.ViewModel.EntityDataSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.filterButton = new System.Windows.Forms.Button();
            this.storeCodeFilterTextBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ordersTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btFindShop = new System.Windows.Forms.Button();
            this.storeCodeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pager1 = new GODInventoryWinForm.Controls.Pager();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OrderReceivedAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCodeColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.場所 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNOColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンルColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiNameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKanjiSpecificationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOQColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQuantityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipperColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品指示Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreDistrictColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPendingColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.社内伝番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最大行数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ダブリ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.在庫状態 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.キャンセル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.キャンセル時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ジャンル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＪＡＮコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際出荷数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.口数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品口数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.単位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価税抜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額税抜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品原価金額 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価税抜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.一旦保留 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.実際配送担当 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送担当受信 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.専務受信 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.専務受信時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品指示 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品場所コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品場所名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.週目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領確認 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領金額 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領差異数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受領差異金額 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.法人コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.法人名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.法人名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.店舗名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入先コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入先名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仕入先名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷業務仕入先コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品予定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注データ有効期限 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDI発注区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注形態区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注形態名称漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予備数値 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.本部発注区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部門コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部門名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部門名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ラインコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.クラスコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品コード区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ロケーションコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.オプション使用欄 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＧＴＩＮ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.規格名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最小発注単位数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注単位名称漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発注単位名称カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.総額取引区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原単価税込 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価金額税込 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.税額 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.税区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.税率 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売単価税込 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.特価区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PB区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原価区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用度品区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納期回答区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.回答納期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.色名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.柄名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.サイズ名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.広告コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.伝票出力単位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品先店舗コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品先店舗名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.納品場所名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.便区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.センター経由区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.センター名漢字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.センター名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASN管理連番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受注管理連番 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出荷No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自社コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.県別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToShipperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.id受注データDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.ordersTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pager1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(GODInventory.MyLinq.GODDbContext);
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Location = new System.Drawing.Point(392, 45);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(100, 35);
            this.filterButton.TabIndex = 24;
            this.filterButton.Text = "Find";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // storeCodeFilterTextBox3
            // 
            this.storeCodeFilterTextBox3.Location = new System.Drawing.Point(138, 18);
            this.storeCodeFilterTextBox3.Name = "storeCodeFilterTextBox3";
            this.storeCodeFilterTextBox3.Size = new System.Drawing.Size(100, 20);
            this.storeCodeFilterTextBox3.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "订单编号或者社内伝番";
            // 
            // ordersTabPage
            // 
            this.ordersTabPage.Controls.Add(this.groupBox3);
            this.ordersTabPage.Controls.Add(this.groupBox2);
            this.ordersTabPage.Controls.Add(this.groupBox1);
            this.ordersTabPage.Controls.Add(this.pager1);
            this.ordersTabPage.Controls.Add(this.dataGridView1);
            this.ordersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ordersTabPage.Name = "ordersTabPage";
            this.ordersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ordersTabPage.Size = new System.Drawing.Size(921, 527);
            this.ordersTabPage.TabIndex = 0;
            this.ordersTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.endDateTimePicker);
            this.groupBox3.Controls.Add(this.startDateTimePicker);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.filterButton);
            this.groupBox3.Location = new System.Drawing.Point(17, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 91);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "日期类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "县别";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "发货日",
            "交货日"});
            this.comboBox2.Location = new System.Drawing.Point(234, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(95, 21);
            this.comboBox2.TabIndex = 97;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 96;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(198, 19);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.endDateTimePicker.TabIndex = 90;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(47, 21);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.startDateTimePicker.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "期日";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "～";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.storeComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btFindShop);
            this.groupBox2.Controls.Add(this.storeCodeTextBox);
            this.groupBox2.Location = new System.Drawing.Point(17, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 58);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(150, 19);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(95, 21);
            this.storeComboBox.TabIndex = 95;
            this.storeComboBox.SelectedIndexChanged += new System.EventHandler(this.storeComboBox_SelectedIndexChanged);
            this.storeComboBox.SelectedValueChanged += new System.EventHandler(this.storeComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 93;
            this.label2.Text = "店舗コード";
            // 
            // btFindShop
            // 
            this.btFindShop.Location = new System.Drawing.Point(265, 19);
            this.btFindShop.Name = "btFindShop";
            this.btFindShop.Size = new System.Drawing.Size(58, 21);
            this.btFindShop.TabIndex = 97;
            this.btFindShop.Text = "Find";
            this.btFindShop.UseVisualStyleBackColor = true;
            this.btFindShop.Click += new System.EventHandler(this.btFindShop_Click);
            // 
            // storeCodeTextBox
            // 
            this.storeCodeTextBox.Location = new System.Drawing.Point(86, 19);
            this.storeCodeTextBox.MaxLength = 8;
            this.storeCodeTextBox.Name = "storeCodeTextBox";
            this.storeCodeTextBox.Size = new System.Drawing.Size(58, 20);
            this.storeCodeTextBox.TabIndex = 94;
            this.storeCodeTextBox.TextChanged += new System.EventHandler(this.storeCodeTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.storeCodeFilterTextBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(566, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 66);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 20);
            this.button1.TabIndex = 96;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Controls.Add(this.bindingNavigator1);
            this.pager1.Location = new System.Drawing.Point(3, 457);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 0;
            this.pager1.PageSize = 50;
            this.pager1.Size = new System.Drawing.Size(915, 68);
            this.pager1.TabIndex = 25;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 34);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(915, 34);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            this.OrderReceivedAtColumn1,
            this.StoreCodeColumn1,
            this.StoreNameColumn1,
            this.場所,
            this.InvoiceNOColumn1,
            this.ジャンルColumn,
            this.ProductKanjiNameColumn1,
            this.ProductKanjiSpecificationColumn1,
            this.MOQColumn1,
            this.OrderQuantityColumn1,
            this.ShipperColumn1,
            this.Column2,
            this.納品指示Column1,
            this.備考Column1,
            this.StoreDistrictColumn1,
            this.IsPendingColumn1,
            this.Column3,
            this.Column4,
            this.受注日,
            this.出荷日,
            this.納品日,
            this.店舗コード,
            this.店舗名漢字,
            this.社内伝番,
            this.行数,
            this.最大行数,
            this.伝票番号,
            this.ダブリ,
            this.在庫状態,
            this.キャンセル,
            this.キャンセル時刻,
            this.ジャンル,
            this.ＪＡＮコード,
            this.商品コード,
            this.品名漢字,
            this.規格名漢字,
            this.発注数量,
            this.実際出荷数量,
            this.口数,
            this.納品口数,
            this.重量,
            this.単位,
            this.原単価税抜,
            this.原価金額税抜,
            this.納品原価金額,
            this.売単価税抜,
            this.一旦保留,
            this.実際配送担当,
            this.配送担当受信,
            this.専務受信,
            this.専務受信時刻,
            this.納品指示,
            this.納品場所コード,
            this.納品場所名漢字,
            this.受領,
            this.備考,
            this.週目,
            this.受領確認,
            this.受領数量,
            this.受領金額,
            this.受領差異数量,
            this.受領差異金額,
            this.受注時刻,
            this.法人コード,
            this.法人名漢字,
            this.法人名カナ,
            this.店舗名カナ,
            this.仕入先コード,
            this.仕入先名漢字,
            this.仕入先名カナ,
            this.出荷業務仕入先コード,
            this.伝票区分,
            this.行番号,
            this.納品予定日,
            this.発注データ有効期限,
            this.EDI発注区分,
            this.発注形態区分,
            this.発注形態名称漢字,
            this.予備数値,
            this.本部発注区分,
            this.部門コード,
            this.部門名漢字,
            this.部門名カナ,
            this.ラインコード,
            this.クラスコード,
            this.商品コード区分,
            this.ロケーションコード,
            this.オプション使用欄,
            this.ＧＴＩＮ,
            this.品名カナ,
            this.規格名カナ,
            this.最小発注単位数量,
            this.発注単位名称漢字,
            this.発注単位名称カナ,
            this.総額取引区分,
            this.原単価税込,
            this.原価金額税込,
            this.税額,
            this.税区分,
            this.税率,
            this.売単価税込,
            this.特価区分,
            this.PB区分,
            this.原価区分,
            this.用度品区分,
            this.納期回答区分,
            this.回答納期,
            this.色名カナ,
            this.柄名カナ,
            this.サイズ名カナ,
            this.広告コード,
            this.伝票出力単位,
            this.納品先店舗コード,
            this.納品先店舗名漢字,
            this.納品場所名カナ,
            this.便区分,
            this.センター経由区分,
            this.センター名漢字,
            this.センター名カナ,
            this.ASN管理連番,
            this.受注管理連番,
            this.出荷No,
            this.自社コード,
            this.Status,
            this.県別,
            this.ShipNO});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(915, 326);
            this.dataGridView1.TabIndex = 11;
            // 
            // OrderReceivedAtColumn1
            // 
            this.OrderReceivedAtColumn1.DataPropertyName = "受注日";
            this.OrderReceivedAtColumn1.HeaderText = "受注日";
            this.OrderReceivedAtColumn1.Name = "OrderReceivedAtColumn1";
            this.OrderReceivedAtColumn1.ReadOnly = true;
            // 
            // StoreCodeColumn1
            // 
            this.StoreCodeColumn1.DataPropertyName = "店舗コード";
            this.StoreCodeColumn1.HeaderText = "店番";
            this.StoreCodeColumn1.Name = "StoreCodeColumn1";
            this.StoreCodeColumn1.ReadOnly = true;
            this.StoreCodeColumn1.Width = 60;
            // 
            // StoreNameColumn1
            // 
            this.StoreNameColumn1.DataPropertyName = "店名";
            this.StoreNameColumn1.HeaderText = "店名";
            this.StoreNameColumn1.Name = "StoreNameColumn1";
            this.StoreNameColumn1.ReadOnly = true;
            // 
            // 場所
            // 
            this.場所.DataPropertyName = "納品場所名漢字";
            this.場所.HeaderText = "場所";
            this.場所.Name = "場所";
            this.場所.ReadOnly = true;
            // 
            // InvoiceNOColumn1
            // 
            this.InvoiceNOColumn1.DataPropertyName = "伝票番号";
            this.InvoiceNOColumn1.HeaderText = "伝票番号";
            this.InvoiceNOColumn1.Name = "InvoiceNOColumn1";
            this.InvoiceNOColumn1.ReadOnly = true;
            // 
            // ジャンルColumn
            // 
            this.ジャンルColumn.DataPropertyName = "GenreName";
            this.ジャンルColumn.HeaderText = "ジャンル";
            this.ジャンルColumn.Name = "ジャンルColumn";
            this.ジャンルColumn.ReadOnly = true;
            this.ジャンルColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ProductKanjiNameColumn1
            // 
            this.ProductKanjiNameColumn1.DataPropertyName = "品名漢字";
            this.ProductKanjiNameColumn1.HeaderText = "品名漢字";
            this.ProductKanjiNameColumn1.Name = "ProductKanjiNameColumn1";
            this.ProductKanjiNameColumn1.ReadOnly = true;
            // 
            // ProductKanjiSpecificationColumn1
            // 
            this.ProductKanjiSpecificationColumn1.DataPropertyName = "規格名漢字";
            this.ProductKanjiSpecificationColumn1.HeaderText = "規格名漢字";
            this.ProductKanjiSpecificationColumn1.Name = "ProductKanjiSpecificationColumn1";
            this.ProductKanjiSpecificationColumn1.ReadOnly = true;
            // 
            // MOQColumn1
            // 
            this.MOQColumn1.DataPropertyName = "口数";
            this.MOQColumn1.HeaderText = "口数";
            this.MOQColumn1.Name = "MOQColumn1";
            this.MOQColumn1.Width = 60;
            // 
            // OrderQuantityColumn1
            // 
            this.OrderQuantityColumn1.DataPropertyName = "発注数量";
            this.OrderQuantityColumn1.HeaderText = "発注数量";
            this.OrderQuantityColumn1.Name = "OrderQuantityColumn1";
            // 
            // ShipperColumn1
            // 
            this.ShipperColumn1.DataPropertyName = "実際配送担当";
            this.ShipperColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShipperColumn1.HeaderText = "担当";
            this.ShipperColumn1.Items.AddRange(new object[] {
            "丸健",
            "MKL",
            "マツモト産業"});
            this.ShipperColumn1.Name = "ShipperColumn1";
            this.ShipperColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipperColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "発注形態名称漢字";
            this.Column2.HeaderText = "形態";
            this.Column2.Name = "Column2";
            // 
            // 納品指示Column1
            // 
            this.納品指示Column1.HeaderText = "納品指示";
            this.納品指示Column1.Name = "納品指示Column1";
            // 
            // 備考Column1
            // 
            this.備考Column1.HeaderText = "備考";
            this.備考Column1.Name = "備考Column1";
            // 
            // StoreDistrictColumn1
            // 
            this.StoreDistrictColumn1.DataPropertyName = "県別";
            this.StoreDistrictColumn1.HeaderText = "県別";
            this.StoreDistrictColumn1.Name = "StoreDistrictColumn1";
            this.StoreDistrictColumn1.ReadOnly = true;
            // 
            // IsPendingColumn1
            // 
            this.IsPendingColumn1.DataPropertyName = "一旦保留";
            this.IsPendingColumn1.HeaderText = "一旦保留";
            this.IsPendingColumn1.Name = "IsPendingColumn1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "在庫状態";
            this.Column3.HeaderText = "在庫状態";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "在庫数";
            this.Column4.HeaderText = "在庫数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // 受注日
            // 
            this.受注日.DataPropertyName = "受注日";
            this.受注日.HeaderText = "受注日";
            this.受注日.Name = "受注日";
            // 
            // 出荷日
            // 
            this.出荷日.DataPropertyName = "出荷日";
            this.出荷日.HeaderText = "出荷日";
            this.出荷日.Name = "出荷日";
            // 
            // 納品日
            // 
            this.納品日.DataPropertyName = "納品日";
            this.納品日.HeaderText = "納品日";
            this.納品日.Name = "納品日";
            // 
            // 店舗コード
            // 
            this.店舗コード.DataPropertyName = "店舗コード";
            this.店舗コード.HeaderText = "店舗コード";
            this.店舗コード.Name = "店舗コード";
            // 
            // 店舗名漢字
            // 
            this.店舗名漢字.DataPropertyName = "店舗名漢字";
            this.店舗名漢字.HeaderText = "店舗名漢字";
            this.店舗名漢字.Name = "店舗名漢字";
            // 
            // 社内伝番
            // 
            this.社内伝番.DataPropertyName = "社内伝番";
            this.社内伝番.HeaderText = "社内伝番";
            this.社内伝番.Name = "社内伝番";
            // 
            // 行数
            // 
            this.行数.DataPropertyName = "行数";
            this.行数.HeaderText = "行数";
            this.行数.Name = "行数";
            // 
            // 最大行数
            // 
            this.最大行数.DataPropertyName = "最大行数";
            this.最大行数.HeaderText = "最大行数";
            this.最大行数.Name = "最大行数";
            // 
            // 伝票番号
            // 
            this.伝票番号.DataPropertyName = "伝票番号";
            this.伝票番号.HeaderText = "伝票番号";
            this.伝票番号.Name = "伝票番号";
            // 
            // ダブリ
            // 
            this.ダブリ.DataPropertyName = "ダブリ";
            this.ダブリ.HeaderText = "ダブリ";
            this.ダブリ.Name = "ダブリ";
            // 
            // 在庫状態
            // 
            this.在庫状態.DataPropertyName = "在庫状態";
            this.在庫状態.HeaderText = "在庫状態";
            this.在庫状態.Name = "在庫状態";
            // 
            // キャンセル
            // 
            this.キャンセル.DataPropertyName = "キャンセル";
            this.キャンセル.HeaderText = "キャンセル";
            this.キャンセル.Name = "キャンセル";
            // 
            // キャンセル時刻
            // 
            this.キャンセル時刻.DataPropertyName = "キャンセル時刻";
            this.キャンセル時刻.HeaderText = "キャンセル時刻";
            this.キャンセル時刻.Name = "キャンセル時刻";
            // 
            // ジャンル
            // 
            this.ジャンル.DataPropertyName = "ジャンル";
            this.ジャンル.HeaderText = "ジャンル";
            this.ジャンル.Name = "ジャンル";
            // 
            // ＪＡＮコード
            // 
            this.ＪＡＮコード.DataPropertyName = "ＪＡＮコード";
            this.ＪＡＮコード.HeaderText = "ＪＡＮコード";
            this.ＪＡＮコード.Name = "ＪＡＮコード";
            // 
            // 商品コード
            // 
            this.商品コード.DataPropertyName = "商品コード";
            this.商品コード.HeaderText = "商品コード";
            this.商品コード.Name = "商品コード";
            // 
            // 品名漢字
            // 
            this.品名漢字.DataPropertyName = "品名漢字";
            this.品名漢字.HeaderText = "品名漢字";
            this.品名漢字.Name = "品名漢字";
            // 
            // 規格名漢字
            // 
            this.規格名漢字.DataPropertyName = "規格名漢字";
            this.規格名漢字.HeaderText = "規格名漢字";
            this.規格名漢字.Name = "規格名漢字";
            // 
            // 発注数量
            // 
            this.発注数量.DataPropertyName = "発注数量";
            this.発注数量.HeaderText = "発注数量";
            this.発注数量.Name = "発注数量";
            // 
            // 実際出荷数量
            // 
            this.実際出荷数量.DataPropertyName = "実際出荷数量";
            this.実際出荷数量.HeaderText = "実際出荷数量";
            this.実際出荷数量.Name = "実際出荷数量";
            // 
            // 口数
            // 
            this.口数.DataPropertyName = "口数";
            this.口数.HeaderText = "口数";
            this.口数.Name = "口数";
            // 
            // 納品口数
            // 
            this.納品口数.DataPropertyName = "納品口数";
            this.納品口数.HeaderText = "納品口数";
            this.納品口数.Name = "納品口数";
            // 
            // 重量
            // 
            this.重量.DataPropertyName = "重量";
            this.重量.HeaderText = "重量";
            this.重量.Name = "重量";
            // 
            // 単位
            // 
            this.単位.DataPropertyName = "単位";
            this.単位.HeaderText = "単位";
            this.単位.Name = "単位";
            // 
            // 原単価税抜
            // 
            this.原単価税抜.DataPropertyName = "原単価(税抜)";
            this.原単価税抜.HeaderText = "原単価(税抜)";
            this.原単価税抜.Name = "原単価税抜";
            // 
            // 原価金額税抜
            // 
            this.原価金額税抜.DataPropertyName = "原価金額(税抜)";
            this.原価金額税抜.HeaderText = "原価金額(税抜)";
            this.原価金額税抜.Name = "原価金額税抜";
            // 
            // 納品原価金額
            // 
            this.納品原価金額.DataPropertyName = "納品原価金額";
            this.納品原価金額.HeaderText = "納品原価金額";
            this.納品原価金額.Name = "納品原価金額";
            // 
            // 売単価税抜
            // 
            this.売単価税抜.DataPropertyName = "売単価（税抜）";
            this.売単価税抜.HeaderText = "売単価（税抜）";
            this.売単価税抜.Name = "売単価税抜";
            // 
            // 一旦保留
            // 
            this.一旦保留.DataPropertyName = "一旦保留";
            this.一旦保留.HeaderText = "一旦保留";
            this.一旦保留.Name = "一旦保留";
            // 
            // 実際配送担当
            // 
            this.実際配送担当.DataPropertyName = "実際配送担当";
            this.実際配送担当.HeaderText = "実際配送担当";
            this.実際配送担当.Name = "実際配送担当";
            // 
            // 配送担当受信
            // 
            this.配送担当受信.DataPropertyName = "配送担当受信";
            this.配送担当受信.HeaderText = "配送担当受信";
            this.配送担当受信.Name = "配送担当受信";
            // 
            // 専務受信
            // 
            this.専務受信.DataPropertyName = "専務受信";
            this.専務受信.HeaderText = "専務受信";
            this.専務受信.Name = "専務受信";
            // 
            // 専務受信時刻
            // 
            this.専務受信時刻.DataPropertyName = "専務受信時刻";
            this.専務受信時刻.HeaderText = "専務受信時刻";
            this.専務受信時刻.Name = "専務受信時刻";
            // 
            // 納品指示
            // 
            this.納品指示.DataPropertyName = "納品指示";
            this.納品指示.HeaderText = "納品指示";
            this.納品指示.Name = "納品指示";
            // 
            // 納品場所コード
            // 
            this.納品場所コード.DataPropertyName = "納品場所コード";
            this.納品場所コード.HeaderText = "納品場所コード";
            this.納品場所コード.Name = "納品場所コード";
            // 
            // 納品場所名漢字
            // 
            this.納品場所名漢字.DataPropertyName = "納品場所名漢字";
            this.納品場所名漢字.HeaderText = "納品場所名漢字";
            this.納品場所名漢字.Name = "納品場所名漢字";
            // 
            // 受領
            // 
            this.受領.DataPropertyName = "受領";
            this.受領.HeaderText = "受領";
            this.受領.Name = "受領";
            // 
            // 備考
            // 
            this.備考.DataPropertyName = "備考";
            this.備考.HeaderText = "備考";
            this.備考.Name = "備考";
            // 
            // 週目
            // 
            this.週目.DataPropertyName = "週目";
            this.週目.HeaderText = "週目";
            this.週目.Name = "週目";
            // 
            // 受領確認
            // 
            this.受領確認.DataPropertyName = "受領確認";
            this.受領確認.HeaderText = "受領確認";
            this.受領確認.Name = "受領確認";
            // 
            // 受領数量
            // 
            this.受領数量.DataPropertyName = "受領数量";
            this.受領数量.HeaderText = "受領数量";
            this.受領数量.Name = "受領数量";
            // 
            // 受領金額
            // 
            this.受領金額.DataPropertyName = "受領金額";
            this.受領金額.HeaderText = "受領金額";
            this.受領金額.Name = "受領金額";
            // 
            // 受領差異数量
            // 
            this.受領差異数量.DataPropertyName = "受領差異数量";
            this.受領差異数量.HeaderText = "受領差異数量";
            this.受領差異数量.Name = "受領差異数量";
            // 
            // 受領差異金額
            // 
            this.受領差異金額.DataPropertyName = "受領差異金額";
            this.受領差異金額.HeaderText = "受領差異金額";
            this.受領差異金額.Name = "受領差異金額";
            // 
            // 受注時刻
            // 
            this.受注時刻.DataPropertyName = "受注時刻";
            this.受注時刻.HeaderText = "受注時刻";
            this.受注時刻.Name = "受注時刻";
            // 
            // 法人コード
            // 
            this.法人コード.DataPropertyName = "法人コード";
            this.法人コード.HeaderText = "法人コード";
            this.法人コード.Name = "法人コード";
            // 
            // 法人名漢字
            // 
            this.法人名漢字.DataPropertyName = "法人名漢字";
            this.法人名漢字.HeaderText = "法人名漢字";
            this.法人名漢字.Name = "法人名漢字";
            // 
            // 法人名カナ
            // 
            this.法人名カナ.DataPropertyName = "法人名カナ";
            this.法人名カナ.HeaderText = "法人名カナ";
            this.法人名カナ.Name = "法人名カナ";
            // 
            // 店舗名カナ
            // 
            this.店舗名カナ.DataPropertyName = "店舗名カナ";
            this.店舗名カナ.HeaderText = "店舗名カナ";
            this.店舗名カナ.Name = "店舗名カナ";
            // 
            // 仕入先コード
            // 
            this.仕入先コード.DataPropertyName = "仕入先コード";
            this.仕入先コード.HeaderText = "仕入先コード";
            this.仕入先コード.Name = "仕入先コード";
            // 
            // 仕入先名漢字
            // 
            this.仕入先名漢字.DataPropertyName = "仕入先名漢字";
            this.仕入先名漢字.HeaderText = "仕入先名漢字";
            this.仕入先名漢字.Name = "仕入先名漢字";
            // 
            // 仕入先名カナ
            // 
            this.仕入先名カナ.DataPropertyName = "仕入先名カナ";
            this.仕入先名カナ.HeaderText = "仕入先名カナ";
            this.仕入先名カナ.Name = "仕入先名カナ";
            // 
            // 出荷業務仕入先コード
            // 
            this.出荷業務仕入先コード.DataPropertyName = "出荷業務仕入先コード";
            this.出荷業務仕入先コード.HeaderText = "出荷業務仕入先コード";
            this.出荷業務仕入先コード.Name = "出荷業務仕入先コード";
            // 
            // 伝票区分
            // 
            this.伝票区分.DataPropertyName = "伝票区分";
            this.伝票区分.HeaderText = "伝票区分";
            this.伝票区分.Name = "伝票区分";
            // 
            // 行番号
            // 
            this.行番号.DataPropertyName = "行番号";
            this.行番号.HeaderText = "行番号";
            this.行番号.Name = "行番号";
            // 
            // 納品予定日
            // 
            this.納品予定日.DataPropertyName = "納品予定日";
            this.納品予定日.HeaderText = "納品予定日";
            this.納品予定日.Name = "納品予定日";
            // 
            // 発注データ有効期限
            // 
            this.発注データ有効期限.DataPropertyName = "発注データ有効期限";
            this.発注データ有効期限.HeaderText = "発注データ有効期限";
            this.発注データ有効期限.Name = "発注データ有効期限";
            // 
            // EDI発注区分
            // 
            this.EDI発注区分.DataPropertyName = "EDI発注区分";
            this.EDI発注区分.HeaderText = "EDI発注区分";
            this.EDI発注区分.Name = "EDI発注区分";
            // 
            // 発注形態区分
            // 
            this.発注形態区分.DataPropertyName = "発注形態区分";
            this.発注形態区分.HeaderText = "発注形態区分";
            this.発注形態区分.Name = "発注形態区分";
            // 
            // 発注形態名称漢字
            // 
            this.発注形態名称漢字.DataPropertyName = "発注形態名称漢字";
            this.発注形態名称漢字.HeaderText = "発注形態名称漢字";
            this.発注形態名称漢字.Name = "発注形態名称漢字";
            // 
            // 予備数値
            // 
            this.予備数値.DataPropertyName = "予備数値";
            this.予備数値.HeaderText = "予備（数値）";
            this.予備数値.Name = "予備数値";
            // 
            // 本部発注区分
            // 
            this.本部発注区分.DataPropertyName = "本部発注区分";
            this.本部発注区分.HeaderText = "本部発注区分";
            this.本部発注区分.Name = "本部発注区分";
            // 
            // 部門コード
            // 
            this.部門コード.DataPropertyName = "部門コード";
            this.部門コード.HeaderText = "部門コード";
            this.部門コード.Name = "部門コード";
            // 
            // 部門名漢字
            // 
            this.部門名漢字.DataPropertyName = "部門名漢字";
            this.部門名漢字.HeaderText = "部門名漢字";
            this.部門名漢字.Name = "部門名漢字";
            // 
            // 部門名カナ
            // 
            this.部門名カナ.DataPropertyName = "部門名カナ";
            this.部門名カナ.HeaderText = "部門名カナ";
            this.部門名カナ.Name = "部門名カナ";
            // 
            // ラインコード
            // 
            this.ラインコード.DataPropertyName = "ラインコード";
            this.ラインコード.HeaderText = "ラインコード";
            this.ラインコード.Name = "ラインコード";
            // 
            // クラスコード
            // 
            this.クラスコード.DataPropertyName = "クラスコード";
            this.クラスコード.HeaderText = "クラスコード";
            this.クラスコード.Name = "クラスコード";
            // 
            // 商品コード区分
            // 
            this.商品コード区分.DataPropertyName = "商品コード区分";
            this.商品コード区分.HeaderText = "商品コード区分";
            this.商品コード区分.Name = "商品コード区分";
            // 
            // ロケーションコード
            // 
            this.ロケーションコード.DataPropertyName = "ロケーションコード";
            this.ロケーションコード.HeaderText = "ロケーションコード";
            this.ロケーションコード.Name = "ロケーションコード";
            // 
            // オプション使用欄
            // 
            this.オプション使用欄.DataPropertyName = "オプション使用欄";
            this.オプション使用欄.HeaderText = "オプション使用欄";
            this.オプション使用欄.Name = "オプション使用欄";
            // 
            // ＧＴＩＮ
            // 
            this.ＧＴＩＮ.DataPropertyName = "ＧＴＩＮ";
            this.ＧＴＩＮ.HeaderText = "ＧＴＩＮ";
            this.ＧＴＩＮ.Name = "ＧＴＩＮ";
            // 
            // 品名カナ
            // 
            this.品名カナ.DataPropertyName = "品名カナ";
            this.品名カナ.HeaderText = "品名カナ";
            this.品名カナ.Name = "品名カナ";
            // 
            // 規格名カナ
            // 
            this.規格名カナ.DataPropertyName = "規格名カナ";
            this.規格名カナ.HeaderText = "規格名カナ";
            this.規格名カナ.Name = "規格名カナ";
            // 
            // 最小発注単位数量
            // 
            this.最小発注単位数量.DataPropertyName = "最小発注単位数量";
            this.最小発注単位数量.HeaderText = "最小発注単位数量";
            this.最小発注単位数量.Name = "最小発注単位数量";
            // 
            // 発注単位名称漢字
            // 
            this.発注単位名称漢字.DataPropertyName = "発注単位名称漢字";
            this.発注単位名称漢字.HeaderText = "発注単位名称漢字";
            this.発注単位名称漢字.Name = "発注単位名称漢字";
            // 
            // 発注単位名称カナ
            // 
            this.発注単位名称カナ.DataPropertyName = "発注単位名称カナ";
            this.発注単位名称カナ.HeaderText = "発注単位名称カナ";
            this.発注単位名称カナ.Name = "発注単位名称カナ";
            // 
            // 総額取引区分
            // 
            this.総額取引区分.DataPropertyName = "総額取引区分";
            this.総額取引区分.HeaderText = "総額取引区分";
            this.総額取引区分.Name = "総額取引区分";
            // 
            // 原単価税込
            // 
            this.原単価税込.DataPropertyName = "原単価税込";
            this.原単価税込.HeaderText = "原単価(税込)";
            this.原単価税込.Name = "原単価税込";
            // 
            // 原価金額税込
            // 
            this.原価金額税込.DataPropertyName = "原価金額税込";
            this.原価金額税込.HeaderText = "原価金額(税込)";
            this.原価金額税込.Name = "原価金額税込";
            // 
            // 税額
            // 
            this.税額.DataPropertyName = "税額";
            this.税額.HeaderText = "税額";
            this.税額.Name = "税額";
            // 
            // 税区分
            // 
            this.税区分.DataPropertyName = "税区分";
            this.税区分.HeaderText = "税区分";
            this.税区分.Name = "税区分";
            // 
            // 税率
            // 
            this.税率.DataPropertyName = "税率";
            this.税率.HeaderText = "税率";
            this.税率.Name = "税率";
            // 
            // 売単価税込
            // 
            this.売単価税込.DataPropertyName = "売単価税込";
            this.売単価税込.HeaderText = "売単価（税込）";
            this.売単価税込.Name = "売単価税込";
            // 
            // 特価区分
            // 
            this.特価区分.DataPropertyName = "特価区分";
            this.特価区分.HeaderText = "特価区分";
            this.特価区分.Name = "特価区分";
            // 
            // PB区分
            // 
            this.PB区分.DataPropertyName = "PB区分";
            this.PB区分.HeaderText = "PB区分";
            this.PB区分.Name = "PB区分";
            // 
            // 原価区分
            // 
            this.原価区分.DataPropertyName = "原価区分";
            this.原価区分.HeaderText = "原価区分";
            this.原価区分.Name = "原価区分";
            // 
            // 用度品区分
            // 
            this.用度品区分.DataPropertyName = "用度品区分";
            this.用度品区分.HeaderText = "用度品区分";
            this.用度品区分.Name = "用度品区分";
            // 
            // 納期回答区分
            // 
            this.納期回答区分.DataPropertyName = "納期回答区分";
            this.納期回答区分.HeaderText = "納期回答区分";
            this.納期回答区分.Name = "納期回答区分";
            // 
            // 回答納期
            // 
            this.回答納期.DataPropertyName = "回答納期";
            this.回答納期.HeaderText = "回答納期";
            this.回答納期.Name = "回答納期";
            // 
            // 色名カナ
            // 
            this.色名カナ.DataPropertyName = "色名カナ";
            this.色名カナ.HeaderText = "色名カナ";
            this.色名カナ.Name = "色名カナ";
            // 
            // 柄名カナ
            // 
            this.柄名カナ.DataPropertyName = "柄名カナ";
            this.柄名カナ.HeaderText = "柄名カナ";
            this.柄名カナ.Name = "柄名カナ";
            // 
            // サイズ名カナ
            // 
            this.サイズ名カナ.DataPropertyName = "サイズ名カナ";
            this.サイズ名カナ.HeaderText = "サイズ名カナ";
            this.サイズ名カナ.Name = "サイズ名カナ";
            // 
            // 広告コード
            // 
            this.広告コード.DataPropertyName = "広告コード";
            this.広告コード.HeaderText = "広告コード";
            this.広告コード.Name = "広告コード";
            // 
            // 伝票出力単位
            // 
            this.伝票出力単位.DataPropertyName = "伝票出力単位";
            this.伝票出力単位.HeaderText = "伝票出力単位";
            this.伝票出力単位.Name = "伝票出力単位";
            // 
            // 納品先店舗コード
            // 
            this.納品先店舗コード.DataPropertyName = "納品先店舗コード";
            this.納品先店舗コード.HeaderText = "納品先店舗コード";
            this.納品先店舗コード.Name = "納品先店舗コード";
            // 
            // 納品先店舗名漢字
            // 
            this.納品先店舗名漢字.DataPropertyName = "納品先店舗名漢字";
            this.納品先店舗名漢字.HeaderText = "納品先店舗名漢字";
            this.納品先店舗名漢字.Name = "納品先店舗名漢字";
            // 
            // 納品場所名カナ
            // 
            this.納品場所名カナ.DataPropertyName = "納品場所名カナ";
            this.納品場所名カナ.HeaderText = "納品場所名カナ";
            this.納品場所名カナ.Name = "納品場所名カナ";
            // 
            // 便区分
            // 
            this.便区分.DataPropertyName = "便区分";
            this.便区分.HeaderText = "便区分";
            this.便区分.Name = "便区分";
            // 
            // センター経由区分
            // 
            this.センター経由区分.DataPropertyName = "センター経由区分";
            this.センター経由区分.HeaderText = "センター経由区分";
            this.センター経由区分.Name = "センター経由区分";
            // 
            // センター名漢字
            // 
            this.センター名漢字.DataPropertyName = "センター名漢字";
            this.センター名漢字.HeaderText = "センター名漢字";
            this.センター名漢字.Name = "センター名漢字";
            // 
            // センター名カナ
            // 
            this.センター名カナ.DataPropertyName = "センター名カナ";
            this.センター名カナ.HeaderText = "センター名カナ";
            this.センター名カナ.Name = "センター名カナ";
            // 
            // ASN管理連番
            // 
            this.ASN管理連番.DataPropertyName = "ASN管理連番";
            this.ASN管理連番.HeaderText = "ASN管理連番";
            this.ASN管理連番.Name = "ASN管理連番";
            // 
            // 受注管理連番
            // 
            this.受注管理連番.DataPropertyName = "受注管理連番";
            this.受注管理連番.HeaderText = "受注管理連番";
            this.受注管理連番.Name = "受注管理連番";
            // 
            // 出荷No
            // 
            this.出荷No.DataPropertyName = "出荷No";
            this.出荷No.HeaderText = "出荷No";
            this.出荷No.Name = "出荷No";
            // 
            // 自社コード
            // 
            this.自社コード.DataPropertyName = "自社コード";
            this.自社コード.HeaderText = "自社コード";
            this.自社コード.Name = "自社コード";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // 県別
            // 
            this.県別.DataPropertyName = "県別";
            this.県別.HeaderText = "県別";
            this.県別.Name = "県別";
            // 
            // ShipNO
            // 
            this.ShipNO.DataPropertyName = "ShipNO";
            this.ShipNO.HeaderText = "ShipNO";
            this.ShipNO.Name = "ShipNO";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToShipperToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // sendToShipperToolStripMenuItem
            // 
            this.sendToShipperToolStripMenuItem.Name = "sendToShipperToolStripMenuItem";
            this.sendToShipperToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendToShipperToolStripMenuItem.Text = "SendToShipper";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ordersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(929, 553);
            this.tabControl1.TabIndex = 2;
            // 
            // id受注データDataGridViewTextBoxColumn
            // 
            this.id受注データDataGridViewTextBoxColumn.DataPropertyName = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.HeaderText = "id受注データ";
            this.id受注データDataGridViewTextBoxColumn.Name = "id受注データDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // OrderHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 553);
            this.Controls.Add(this.tabControl1);
            this.Name = "OrderHistoryForm";
            this.Text = "OrderHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ordersTabPage.ResumeLayout(false);
            this.ordersTabPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pager1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GODInventory.ViewModel.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource3;
        private Pager pager1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox storeCodeFilterTextBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage ordersTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToShipperToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id受注データDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.TextBox storeCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btFindShop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderReceivedAtColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCodeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 場所;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNOColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンルColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiNameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKanjiSpecificationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOQColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantityColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipperColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品指示Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreDistrictColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPendingColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 社内伝番;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最大行数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn ダブリ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 在庫状態;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル;
        private System.Windows.Forms.DataGridViewTextBoxColumn キャンセル時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn ジャンル;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＪＡＮコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際出荷数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 口数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品口数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 単位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価税抜;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額税抜;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品原価金額;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価税抜;
        private System.Windows.Forms.DataGridViewTextBoxColumn 一旦保留;
        private System.Windows.Forms.DataGridViewTextBoxColumn 実際配送担当;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送担当受信;
        private System.Windows.Forms.DataGridViewTextBoxColumn 専務受信;
        private System.Windows.Forms.DataGridViewTextBoxColumn 専務受信時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品指示;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品場所コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品場所名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
        private System.Windows.Forms.DataGridViewTextBoxColumn 週目;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領確認;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領金額;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領差異数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受領差異金額;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn 法人コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 法人名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 法人名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 店舗名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入先コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入先名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仕入先名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷業務仕入先コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品予定日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注データ有効期限;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDI発注区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注形態区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注形態名称漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予備数値;
        private System.Windows.Forms.DataGridViewTextBoxColumn 本部発注区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部門コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部門名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部門名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ラインコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn クラスコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品コード区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn ロケーションコード;
        private System.Windows.Forms.DataGridViewTextBoxColumn オプション使用欄;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＧＴＩＮ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最小発注単位数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注単位名称漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発注単位名称カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 総額取引区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原単価税込;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価金額税込;
        private System.Windows.Forms.DataGridViewTextBoxColumn 税額;
        private System.Windows.Forms.DataGridViewTextBoxColumn 税区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 税率;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売単価税込;
        private System.Windows.Forms.DataGridViewTextBoxColumn 特価区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn PB区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原価区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用度品区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納期回答区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 回答納期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 色名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 柄名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn サイズ名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 広告コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 伝票出力単位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品先店舗コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品先店舗名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 納品場所名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 便区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn センター経由区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn センター名漢字;
        private System.Windows.Forms.DataGridViewTextBoxColumn センター名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASN管理連番;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受注管理連番;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出荷No;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自社コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn 県別;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipNO;
    }
}