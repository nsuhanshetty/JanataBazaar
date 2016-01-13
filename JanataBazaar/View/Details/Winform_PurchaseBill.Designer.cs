namespace JanataBazaar.View.Details
{
    partial class Winform_PurchaseBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_PurchaseBill));
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbCredit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProdDetails = new System.Windows.Forms.DataGridView();
            this.ColProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColPackageType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPackQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemPerPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPurchaseValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWholesaleValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResaleVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotPurchaseVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotWholesaleVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotResaleVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPurchasePrice = new System.Windows.Forms.TextBox();
            this.AddVendorToolStrip = new System.Windows.Forms.ToolStripButton();
            this.AddPackageToolStrip = new System.Windows.Forms.ToolStripButton();
            this.txtTotalResalePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.txtTotalWholesalePrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSCF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalWholesalePrice_ROff = new System.Windows.Forms.TextBox();
            this.txtTotalResalePrice_ROff = new System.Windows.Forms.TextBox();
            this.txtTotalPurchasePrice_ROff = new System.Windows.Forms.TextBox();
            this.lblPPriceRdOff = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lblWPriceRdOff = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRPriceRdOff = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Location = new System.Drawing.Point(84, 13);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(49, 17);
            this.rdbCash.TabIndex = 124;
            this.rdbCash.Text = "Cash";
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // rdbCredit
            // 
            this.rdbCredit.AutoSize = true;
            this.rdbCredit.Checked = true;
            this.rdbCredit.Location = new System.Drawing.Point(15, 13);
            this.rdbCredit.Name = "rdbCredit";
            this.rdbCredit.Size = new System.Drawing.Size(52, 17);
            this.rdbCredit.TabIndex = 123;
            this.rdbCredit.TabStop = true;
            this.rdbCredit.Text = "Credit";
            this.rdbCredit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCash);
            this.groupBox1.Controls.Add(this.rdbCredit);
            this.groupBox1.Location = new System.Drawing.Point(90, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 35);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Type Of Bill";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Location = new System.Drawing.Point(573, 19);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(134, 20);
            this.dtpPurchaseDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Date Of Purchase";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Date Of Invoice";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Location = new System.Drawing.Point(573, 47);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(134, 20);
            this.dtpInvoiceDate.TabIndex = 4;
            this.dtpInvoiceDate.ValueChanged += new System.EventHandler(this.dtpInvoiceDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Supplier Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvProdDetails);
            this.groupBox2.Location = new System.Drawing.Point(12, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1023, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Details";
            // 
            // dgvProdDetails
            // 
            this.dgvProdDetails.AllowUserToDeleteRows = false;
            this.dgvProdDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProduct,
            this.ColPackageType,
            this.ColPackQuantity,
            this.colItemPerPack,
            this.colItemUnit,
            this.ColPurchaseValue,
            this.colWholesaleValue,
            this.ColResaleVal,
            this.colTotPurchaseVal,
            this.colTotWholesaleVal,
            this.colTotResaleVal,
            this.ColDel});
            this.dgvProdDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdDetails.Location = new System.Drawing.Point(3, 16);
            this.dgvProdDetails.Name = "dgvProdDetails";
            this.dgvProdDetails.ReadOnly = true;
            this.dgvProdDetails.Size = new System.Drawing.Size(1017, 206);
            this.dgvProdDetails.TabIndex = 0;
            this.dgvProdDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // ColProduct
            // 
            this.ColProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColProduct.HeaderText = "Add Commodity";
            this.ColProduct.Name = "ColProduct";
            this.ColProduct.ReadOnly = true;
            this.ColProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColPackageType
            // 
            this.ColPackageType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColPackageType.HeaderText = "Package Type";
            this.ColPackageType.Name = "ColPackageType";
            this.ColPackageType.ReadOnly = true;
            this.ColPackageType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPackageType.Width = 79;
            // 
            // ColPackQuantity
            // 
            this.ColPackQuantity.HeaderText = "Package Quantity";
            this.ColPackQuantity.Name = "ColPackQuantity";
            this.ColPackQuantity.ReadOnly = true;
            // 
            // colItemPerPack
            // 
            this.colItemPerPack.HeaderText = "Items/ Pack";
            this.colItemPerPack.Name = "colItemPerPack";
            this.colItemPerPack.ReadOnly = true;
            // 
            // colItemUnit
            // 
            this.colItemUnit.HeaderText = "Item Unit";
            this.colItemUnit.Name = "colItemUnit";
            this.colItemUnit.ReadOnly = true;
            // 
            // ColPurchaseValue
            // 
            this.ColPurchaseValue.HeaderText = "Purchase Value";
            this.ColPurchaseValue.Name = "ColPurchaseValue";
            this.ColPurchaseValue.ReadOnly = true;
            // 
            // colWholesaleValue
            // 
            this.colWholesaleValue.HeaderText = "Wholesale Value";
            this.colWholesaleValue.Name = "colWholesaleValue";
            this.colWholesaleValue.ReadOnly = true;
            // 
            // ColResaleVal
            // 
            this.ColResaleVal.HeaderText = "Resale Value";
            this.ColResaleVal.Name = "ColResaleVal";
            this.ColResaleVal.ReadOnly = true;
            // 
            // colTotPurchaseVal
            // 
            this.colTotPurchaseVal.HeaderText = "Total Purchase Value";
            this.colTotPurchaseVal.Name = "colTotPurchaseVal";
            this.colTotPurchaseVal.ReadOnly = true;
            // 
            // colTotWholesaleVal
            // 
            this.colTotWholesaleVal.HeaderText = "Total Wholesale Value";
            this.colTotWholesaleVal.Name = "colTotWholesaleVal";
            this.colTotWholesaleVal.ReadOnly = true;
            // 
            // colTotResaleVal
            // 
            this.colTotResaleVal.HeaderText = "Total Resale Value";
            this.colTotResaleVal.Name = "colTotResaleVal";
            this.colTotResaleVal.ReadOnly = true;
            // 
            // ColDel
            // 
            this.ColDel.HeaderText = "Click To Delete";
            this.ColDel.Name = "ColDel";
            this.ColDel.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(618, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 134;
            this.label5.Text = "Total Purchase Price";
            // 
            // txtTotalPurchasePrice
            // 
            this.txtTotalPurchasePrice.Enabled = false;
            this.txtTotalPurchasePrice.Location = new System.Drawing.Point(730, 362);
            this.txtTotalPurchasePrice.Name = "txtTotalPurchasePrice";
            this.txtTotalPurchasePrice.Size = new System.Drawing.Size(103, 20);
            this.txtTotalPurchasePrice.TabIndex = 135;
            // 
            // AddVendorToolStrip
            // 
            this.AddVendorToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddVendorToolStrip.Image")));
            this.AddVendorToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddVendorToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddVendorToolStrip.Name = "AddVendorToolStrip";
            this.AddVendorToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddVendorToolStrip.Text = "Add S&upplier";
            this.AddVendorToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddVendorToolStrip.Click += new System.EventHandler(this.AddVendorToolStrip_Click);
            // 
            // AddPackageToolStrip
            // 
            this.AddPackageToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddPackageToolStrip.Image")));
            this.AddPackageToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddPackageToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPackageToolStrip.Name = "AddPackageToolStrip";
            this.AddPackageToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddPackageToolStrip.Text = "New &Package Type";
            this.AddPackageToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddPackageToolStrip.Click += new System.EventHandler(this.AddPackageToolStrip_Click);
            // 
            // txtTotalResalePrice
            // 
            this.txtTotalResalePrice.Enabled = false;
            this.txtTotalResalePrice.Location = new System.Drawing.Point(730, 414);
            this.txtTotalResalePrice.Name = "txtTotalResalePrice";
            this.txtTotalResalePrice.Size = new System.Drawing.Size(103, 20);
            this.txtTotalResalePrice.TabIndex = 137;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(630, 417);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 136;
            this.label6.Text = "Total Resale Price";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Enabled = false;
            this.txtVendorName.Location = new System.Drawing.Point(90, 52);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(149, 20);
            this.txtVendorName.TabIndex = 2;
            // 
            // txtTotalWholesalePrice
            // 
            this.txtTotalWholesalePrice.Enabled = false;
            this.txtTotalWholesalePrice.Location = new System.Drawing.Point(730, 388);
            this.txtTotalWholesalePrice.Name = "txtTotalWholesalePrice";
            this.txtTotalWholesalePrice.Size = new System.Drawing.Size(103, 20);
            this.txtTotalWholesalePrice.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(613, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 139;
            this.label7.Text = "Total Wholesale Price";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(325, 19);
            this.txtInvoiceNo.MaxLength = 15;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(117, 20);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 141;
            this.label8.Text = "Invoice No.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSCF);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtInvoiceNo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtVendorName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtpPurchaseDate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpInvoiceDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 78);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill Details";
            // 
            // txtSCF
            // 
            this.txtSCF.Location = new System.Drawing.Point(325, 50);
            this.txtSCF.MaxLength = 15;
            this.txtSCF.Name = "txtSCF";
            this.txtSCF.Size = new System.Drawing.Size(117, 20);
            this.txtSCF.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 146;
            this.label10.Text = "SCF No.";
            // 
            // txtTotalWholesalePrice_ROff
            // 
            this.txtTotalWholesalePrice_ROff.Location = new System.Drawing.Point(926, 388);
            this.txtTotalWholesalePrice_ROff.Name = "txtTotalWholesalePrice_ROff";
            this.txtTotalWholesalePrice_ROff.Size = new System.Drawing.Size(103, 20);
            this.txtTotalWholesalePrice_ROff.TabIndex = 3;
            this.txtTotalWholesalePrice_ROff.Validating += new System.ComponentModel.CancelEventHandler(this.txtValueDecimal_Validating);
            this.txtTotalWholesalePrice_ROff.Validated += new System.EventHandler(this.txtTotalWholesalePrice_ROff_Validated);
            // 
            // txtTotalResalePrice_ROff
            // 
            this.txtTotalResalePrice_ROff.Location = new System.Drawing.Point(926, 414);
            this.txtTotalResalePrice_ROff.Name = "txtTotalResalePrice_ROff";
            this.txtTotalResalePrice_ROff.Size = new System.Drawing.Size(103, 20);
            this.txtTotalResalePrice_ROff.TabIndex = 4;
            this.txtTotalResalePrice_ROff.Validating += new System.ComponentModel.CancelEventHandler(this.txtValueDecimal_Validating);
            this.txtTotalResalePrice_ROff.Validated += new System.EventHandler(this.txtTotalResalePrice_ROff_Validated);
            // 
            // txtTotalPurchasePrice_ROff
            // 
            this.txtTotalPurchasePrice_ROff.Location = new System.Drawing.Point(926, 362);
            this.txtTotalPurchasePrice_ROff.Name = "txtTotalPurchasePrice_ROff";
            this.txtTotalPurchasePrice_ROff.Size = new System.Drawing.Size(103, 20);
            this.txtTotalPurchasePrice_ROff.TabIndex = 2;
            this.txtTotalPurchasePrice_ROff.Validating += new System.ComponentModel.CancelEventHandler(this.txtValueDecimal_Validating);
            this.txtTotalPurchasePrice_ROff.Validated += new System.EventHandler(this.txtTotalPurchasePrice_ROff_Validated);
            // 
            // lblPPriceRdOff
            // 
            this.lblPPriceRdOff.AutoSize = true;
            this.lblPPriceRdOff.ForeColor = System.Drawing.Color.Maroon;
            this.lblPPriceRdOff.Location = new System.Drawing.Point(894, 365);
            this.lblPPriceRdOff.Name = "lblPPriceRdOff";
            this.lblPPriceRdOff.Size = new System.Drawing.Size(13, 13);
            this.lblPPriceRdOff.TabIndex = 142;
            this.lblPPriceRdOff.Text = "0";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label44.Location = new System.Drawing.Point(839, 365);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 13);
            this.label44.TabIndex = 141;
            this.label44.Text = "RoundOff ";
            // 
            // lblWPriceRdOff
            // 
            this.lblWPriceRdOff.AutoSize = true;
            this.lblWPriceRdOff.ForeColor = System.Drawing.Color.Maroon;
            this.lblWPriceRdOff.Location = new System.Drawing.Point(894, 391);
            this.lblWPriceRdOff.Name = "lblWPriceRdOff";
            this.lblWPriceRdOff.Size = new System.Drawing.Size(13, 13);
            this.lblWPriceRdOff.TabIndex = 144;
            this.lblWPriceRdOff.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(839, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 143;
            this.label11.Text = "RoundOff ";
            // 
            // lblRPriceRdOff
            // 
            this.lblRPriceRdOff.AutoSize = true;
            this.lblRPriceRdOff.ForeColor = System.Drawing.Color.Maroon;
            this.lblRPriceRdOff.Location = new System.Drawing.Point(894, 417);
            this.lblRPriceRdOff.Name = "lblRPriceRdOff";
            this.lblRPriceRdOff.Size = new System.Drawing.Size(13, 13);
            this.lblRPriceRdOff.TabIndex = 146;
            this.lblRPriceRdOff.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label13.Location = new System.Drawing.Point(839, 417);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 145;
            this.label13.Text = "RoundOff ";
            // 
            // Winform_PurchaseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 461);
            this.Controls.Add(this.lblRPriceRdOff);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblWPriceRdOff);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPPriceRdOff);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.txtTotalWholesalePrice_ROff);
            this.Controls.Add(this.txtTotalResalePrice_ROff);
            this.Controls.Add(this.txtTotalPurchasePrice_ROff);
            this.Controls.Add(this.txtTotalWholesalePrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalResalePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalPurchasePrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Winform_PurchaseBill";
            this.Text = "Add Stock Control Form";
            this.Load += new System.EventHandler(this.Winform_PurchaseBill_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtTotalPurchasePrice, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTotalResalePrice, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtTotalWholesalePrice, 0);
            this.Controls.SetChildIndex(this.txtTotalPurchasePrice_ROff, 0);
            this.Controls.SetChildIndex(this.txtTotalResalePrice_ROff, 0);
            this.Controls.SetChildIndex(this.txtTotalWholesalePrice_ROff, 0);
            this.Controls.SetChildIndex(this.label44, 0);
            this.Controls.SetChildIndex(this.lblPPriceRdOff, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lblWPriceRdOff, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblRPriceRdOff, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton AddPackageToolStrip;
        private System.Windows.Forms.ToolStripButton AddVendorToolStrip;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbCredit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProdDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalPurchasePrice;
        private System.Windows.Forms.TextBox txtTotalResalePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.TextBox txtTotalWholesalePrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewButtonColumn ColProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPackageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPackQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemPerPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPurchaseValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWholesaleValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColResaleVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotPurchaseVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotWholesaleVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotResaleVal;
        private System.Windows.Forms.DataGridViewButtonColumn ColDel;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSCF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalWholesalePrice_ROff;
        private System.Windows.Forms.TextBox txtTotalResalePrice_ROff;
        private System.Windows.Forms.TextBox txtTotalPurchasePrice_ROff;
        private System.Windows.Forms.Label lblRPriceRdOff;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblWPriceRdOff;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPPriceRdOff;
        private System.Windows.Forms.Label label44;
    }
}