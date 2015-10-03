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
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSCF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
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
            this.groupBox1.Location = new System.Drawing.Point(123, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 35);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Type Of Bill";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPurchaseDate.Location = new System.Drawing.Point(883, 19);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(130, 20);
            this.dtpPurchaseDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(785, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Date Of Purchase";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(795, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Date Of Invoice";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoiceDate.Location = new System.Drawing.Point(883, 47);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(130, 20);
            this.dtpInvoiceDate.TabIndex = 4;
            this.dtpInvoiceDate.ValueChanged += new System.EventHandler(this.dtpInvoiceDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Name Of Supplier";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvProdDetails);
            this.groupBox2.Location = new System.Drawing.Point(16, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1022, 225);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Details";
            // 
            // dgvProdDetails
            // 
            this.dgvProdDetails.AllowUserToDeleteRows = false;
            this.dgvProdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvProdDetails.Location = new System.Drawing.Point(3, 16);
            this.dgvProdDetails.Name = "dgvProdDetails";
            this.dgvProdDetails.Size = new System.Drawing.Size(1016, 206);
            this.dgvProdDetails.TabIndex = 0;
            this.dgvProdDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // ColProduct
            // 
            this.ColProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColProduct.HeaderText = "Add Commodity";
            this.ColProduct.Name = "ColProduct";
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
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(815, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 134;
            this.label5.Text = "Total Purchase Price";
            // 
            // txtTotalPurchasePrice
            // 
            this.txtTotalPurchasePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPurchasePrice.Enabled = false;
            this.txtTotalPurchasePrice.Location = new System.Drawing.Point(927, 380);
            this.txtTotalPurchasePrice.Name = "txtTotalPurchasePrice";
            this.txtTotalPurchasePrice.Size = new System.Drawing.Size(108, 20);
            this.txtTotalPurchasePrice.TabIndex = 135;
            // 
            // AddVendorToolStrip
            // 
            this.AddVendorToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddVendorToolStrip.Image")));
            this.AddVendorToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddVendorToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddVendorToolStrip.Name = "AddVendorToolStrip";
            this.AddVendorToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddVendorToolStrip.Text = "Add &Vendor";
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
            this.txtTotalResalePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalResalePrice.Enabled = false;
            this.txtTotalResalePrice.Location = new System.Drawing.Point(927, 432);
            this.txtTotalResalePrice.Name = "txtTotalResalePrice";
            this.txtTotalResalePrice.Size = new System.Drawing.Size(108, 20);
            this.txtTotalResalePrice.TabIndex = 137;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(827, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 136;
            this.label6.Text = "Total Resale Price";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Enabled = false;
            this.txtVendorName.Location = new System.Drawing.Point(123, 103);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(149, 20);
            this.txtVendorName.TabIndex = 2;
            // 
            // txtTotalWholesalePrice
            // 
            this.txtTotalWholesalePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalWholesalePrice.Enabled = false;
            this.txtTotalWholesalePrice.Location = new System.Drawing.Point(927, 406);
            this.txtTotalWholesalePrice.Name = "txtTotalWholesalePrice";
            this.txtTotalWholesalePrice.Size = new System.Drawing.Size(108, 20);
            this.txtTotalWholesalePrice.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(810, 409);
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
            this.txtInvoiceNo.Location = new System.Drawing.Point(635, 19);
            this.txtInvoiceNo.MaxLength = 15;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(117, 20);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 141;
            this.label8.Text = "ICR No.";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(635, 47);
            this.txtBillNo.MaxLength = 15;
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(117, 20);
            this.txtBillNo.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(548, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 143;
            this.label9.Text = "Supplier Bill No.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSCF);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtBillNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtInvoiceNo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtpPurchaseDate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpInvoiceDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(19, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1019, 78);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill Details";
            // 
            // txtSCF
            // 
            this.txtSCF.Location = new System.Drawing.Point(376, 19);
            this.txtSCF.MaxLength = 15;
            this.txtSCF.Name = "txtSCF";
            this.txtSCF.Size = new System.Drawing.Size(117, 20);
            this.txtSCF.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 146;
            this.label10.Text = "SCF No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(667, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(374, 13);
            this.label11.TabIndex = 147;
            this.label11.Text = "* Invoice date effects the Item pricing as it in turn effects the VAT percentage." +
    "";
            // 
            // Winform_PurchaseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 480);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalWholesalePrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.txtTotalResalePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalPurchasePrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Winform_PurchaseBill";
            this.Text = "Add Stock Control Form";
            this.Load += new System.EventHandler(this.Winform_PurchaseBill_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtTotalPurchasePrice, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTotalResalePrice, 0);
            this.Controls.SetChildIndex(this.txtVendorName, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtTotalWholesalePrice, 0);
            this.Controls.SetChildIndex(this.label11, 0);
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
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSCF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}