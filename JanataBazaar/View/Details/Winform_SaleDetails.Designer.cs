namespace JanataBazaar.View.Details
{
    partial class Winform_SaleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_SaleDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.grpBxSearch = new System.Windows.Forms.GroupBox();
            this.cmbSrcSection = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSrcBrand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrcName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSaleItem = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoxCustomer = new System.Windows.Forms.GroupBox();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.grpbxPayDet = new System.Windows.Forms.GroupBox();
            this.txtBalanceAmnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmntPaid = new System.Windows.Forms.TextBox();
            this.txtTotAmnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddCustomerToolStrip = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.grpBxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItem)).BeginInit();
            this.grpBoxCustomer.SuspendLayout();
            this.grpbxPayDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSearch);
            this.panel1.Controls.Add(this.grpBxSearch);
            this.panel1.Location = new System.Drawing.Point(2, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 373);
            this.panel1.TabIndex = 125;
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(5, 121);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(459, 252);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellDoubleClick);
            // 
            // grpBxSearch
            // 
            this.grpBxSearch.Controls.Add(this.cmbSrcSection);
            this.grpBxSearch.Controls.Add(this.label10);
            this.grpBxSearch.Controls.Add(this.txtSrcBrand);
            this.grpBxSearch.Controls.Add(this.label1);
            this.grpBxSearch.Controls.Add(this.txtSrcName);
            this.grpBxSearch.Controls.Add(this.label4);
            this.grpBxSearch.Location = new System.Drawing.Point(4, 0);
            this.grpBxSearch.Name = "grpBxSearch";
            this.grpBxSearch.Size = new System.Drawing.Size(460, 115);
            this.grpBxSearch.TabIndex = 0;
            this.grpBxSearch.TabStop = false;
            this.grpBxSearch.Text = "Search Details";
            // 
            // cmbSrcSection
            // 
            this.cmbSrcSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrcSection.FormattingEnabled = true;
            this.cmbSrcSection.Location = new System.Drawing.Point(70, 81);
            this.cmbSrcSection.Name = "cmbSrcSection";
            this.cmbSrcSection.Size = new System.Drawing.Size(147, 21);
            this.cmbSrcSection.TabIndex = 141;
            this.cmbSrcSection.SelectedIndexChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 138;
            this.label10.Text = "Section";
            // 
            // txtSrcBrand
            // 
            this.txtSrcBrand.Location = new System.Drawing.Point(70, 53);
            this.txtSrcBrand.Name = "txtSrcBrand";
            this.txtSrcBrand.Size = new System.Drawing.Size(147, 20);
            this.txtSrcBrand.TabIndex = 1;
            this.txtSrcBrand.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 139;
            this.label1.Text = "Name ";
            // 
            // txtSrcName
            // 
            this.txtSrcName.Location = new System.Drawing.Point(70, 24);
            this.txtSrcName.Name = "txtSrcName";
            this.txtSrcName.Size = new System.Drawing.Size(147, 20);
            this.txtSrcName.TabIndex = 0;
            this.txtSrcName.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 140;
            this.label4.Text = "Brand";
            // 
            // dgvSaleItem
            // 
            this.dgvSaleItem.AllowUserToAddRows = false;
            this.dgvSaleItem.AllowUserToDeleteRows = false;
            this.dgvSaleItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colItemName,
            this.colBrand,
            this.colQuantity,
            this.colPrice,
            this.colTotalPrice});
            this.dgvSaleItem.Location = new System.Drawing.Point(475, 178);
            this.dgvSaleItem.Name = "dgvSaleItem";
            this.dgvSaleItem.ReadOnly = true;
            this.dgvSaleItem.Size = new System.Drawing.Size(447, 252);
            this.dgvSaleItem.TabIndex = 139;
            this.dgvSaleItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_CellDoubleClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "Commodity";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.HeaderText = "Total Price";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.ReadOnly = true;
            // 
            // grpBoxCustomer
            // 
            this.grpBoxCustomer.Controls.Add(this.txtMobNo);
            this.grpBoxCustomer.Controls.Add(this.lblName);
            this.grpBoxCustomer.Controls.Add(this.txtName);
            this.grpBoxCustomer.Controls.Add(this.lblMobile);
            this.grpBoxCustomer.Controls.Add(this.label5);
            this.grpBoxCustomer.Controls.Add(this.txtPhoneNo);
            this.grpBoxCustomer.Location = new System.Drawing.Point(475, 57);
            this.grpBoxCustomer.Name = "grpBoxCustomer";
            this.grpBoxCustomer.Size = new System.Drawing.Size(253, 115);
            this.grpBoxCustomer.TabIndex = 138;
            this.grpBoxCustomer.TabStop = false;
            this.grpBoxCustomer.Text = "Customer Details";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Enabled = false;
            this.txtMobNo.Location = new System.Drawing.Point(76, 55);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(146, 20);
            this.txtMobNo.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(18, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 121;
            this.lblName.Text = "Name ";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(76, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Enabled = false;
            this.lblMobile.Location = new System.Drawing.Point(18, 58);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 122;
            this.lblMobile.Text = "Mobile No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(18, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Phone No.";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Enabled = false;
            this.txtPhoneNo.Location = new System.Drawing.Point(76, 81);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(146, 20);
            this.txtPhoneNo.TabIndex = 2;
            // 
            // grpbxPayDet
            // 
            this.grpbxPayDet.Controls.Add(this.txtBalanceAmnt);
            this.grpbxPayDet.Controls.Add(this.label2);
            this.grpbxPayDet.Controls.Add(this.label7);
            this.grpbxPayDet.Controls.Add(this.txtAmntPaid);
            this.grpbxPayDet.Controls.Add(this.txtTotAmnt);
            this.grpbxPayDet.Controls.Add(this.label3);
            this.grpbxPayDet.Location = new System.Drawing.Point(732, 57);
            this.grpbxPayDet.Name = "grpbxPayDet";
            this.grpbxPayDet.Size = new System.Drawing.Size(190, 115);
            this.grpbxPayDet.TabIndex = 140;
            this.grpbxPayDet.TabStop = false;
            this.grpbxPayDet.Text = "Payment Details";
            // 
            // txtBalanceAmnt
            // 
            this.txtBalanceAmnt.Enabled = false;
            this.txtBalanceAmnt.Location = new System.Drawing.Point(92, 55);
            this.txtBalanceAmnt.MaxLength = 10;
            this.txtBalanceAmnt.Name = "txtBalanceAmnt";
            this.txtBalanceAmnt.Size = new System.Drawing.Size(84, 20);
            this.txtBalanceAmnt.TabIndex = 142;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 144;
            this.label2.Text = "Paid Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 146;
            this.label7.Text = "Balance Amount";
            // 
            // txtAmntPaid
            // 
            this.txtAmntPaid.Location = new System.Drawing.Point(92, 30);
            this.txtAmntPaid.MaxLength = 10;
            this.txtAmntPaid.Name = "txtAmntPaid";
            this.txtAmntPaid.Size = new System.Drawing.Size(84, 20);
            this.txtAmntPaid.TabIndex = 141;
            this.txtAmntPaid.Text = "0";
            this.txtAmntPaid.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmntPaid_Validating);
            // 
            // txtTotAmnt
            // 
            this.txtTotAmnt.Enabled = false;
            this.txtTotAmnt.Location = new System.Drawing.Point(92, 80);
            this.txtTotAmnt.MaxLength = 10;
            this.txtTotAmnt.Name = "txtTotAmnt";
            this.txtTotAmnt.Size = new System.Drawing.Size(84, 20);
            this.txtTotAmnt.TabIndex = 143;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 145;
            this.label3.Text = "Total Amount";
            // 
            // AddCustomerToolStrip
            // 
            this.AddCustomerToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddCustomerToolStrip.Image")));
            this.AddCustomerToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddCustomerToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCustomerToolStrip.Name = "AddCustomerToolStrip";
            this.AddCustomerToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddCustomerToolStrip.Text = "&Add Customer";
            this.AddCustomerToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCustomerToolStrip.Click += new System.EventHandler(this.AddCustomerToolStrip_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Winform_SaleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 455);
            this.Controls.Add(this.dgvSaleItem);
            this.Controls.Add(this.grpBoxCustomer);
            this.Controls.Add(this.grpbxPayDet);
            this.Controls.Add(this.panel1);
            this.Name = "Winform_SaleDetails";
            this.Text = "Add Sale Details";
            this.Load += new System.EventHandler(this.Winform_SaleDetails_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grpbxPayDet, 0);
            this.Controls.SetChildIndex(this.grpBoxCustomer, 0);
            this.Controls.SetChildIndex(this.dgvSaleItem, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.grpBxSearch.ResumeLayout(false);
            this.grpBxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItem)).EndInit();
            this.grpBoxCustomer.ResumeLayout(false);
            this.grpBoxCustomer.PerformLayout();
            this.grpbxPayDet.ResumeLayout(false);
            this.grpbxPayDet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.GroupBox grpBxSearch;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtSrcBrand;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtSrcName;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSrcSection;
        private System.Windows.Forms.DataGridView dgvSaleItem;
        private System.Windows.Forms.GroupBox grpBoxCustomer;
        internal System.Windows.Forms.TextBox txtMobNo;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.GroupBox grpbxPayDet;
        internal System.Windows.Forms.TextBox txtBalanceAmnt;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtAmntPaid;
        internal System.Windows.Forms.TextBox txtTotAmnt;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;

        private System.Windows.Forms.ToolStripButton AddCustomerToolStrip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}