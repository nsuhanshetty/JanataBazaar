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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_PurchaseBill));
            this.rdbSales = new System.Windows.Forms.RadioButton();
            this.rdbPurchase = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.ColProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColBag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPurchaseValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResaleVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AddVendorToolStrip = new System.Windows.Forms.ToolStripButton();
            this.AddItemToolStrip = new System.Windows.Forms.ToolStripButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbSales
            // 
            this.rdbSales.AutoSize = true;
            this.rdbSales.Location = new System.Drawing.Point(84, 13);
            this.rdbSales.Name = "rdbSales";
            this.rdbSales.Size = new System.Drawing.Size(49, 17);
            this.rdbSales.TabIndex = 124;
            this.rdbSales.Text = "Cash";
            this.rdbSales.UseVisualStyleBackColor = true;
            // 
            // rdbPurchase
            // 
            this.rdbPurchase.AutoSize = true;
            this.rdbPurchase.Checked = true;
            this.rdbPurchase.Location = new System.Drawing.Point(15, 13);
            this.rdbPurchase.Name = "rdbPurchase";
            this.rdbPurchase.Size = new System.Drawing.Size(52, 17);
            this.rdbPurchase.TabIndex = 123;
            this.rdbPurchase.TabStop = true;
            this.rdbPurchase.Text = "Credit";
            this.rdbPurchase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSales);
            this.groupBox1.Controls.Add(this.rdbPurchase);
            this.groupBox1.Location = new System.Drawing.Point(117, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 35);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Type Of Bill";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Location = new System.Drawing.Point(388, 66);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(149, 20);
            this.dtpPurchaseDate.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Date Of Purchase";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Date Of Invoice";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(388, 96);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 20);
            this.dateTimePicker1.TabIndex = 129;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Name Of Supplier";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetails);
            this.groupBox2.Location = new System.Drawing.Point(16, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 225);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Details";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProduct,
            this.ColBag,
            this.ColQuantity,
            this.ColPurchaseValue,
            this.ColResaleVal,
            this.ColDel});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(3, 16);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(514, 206);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_RowLeave);
            // 
            // ColProduct
            // 
            this.ColProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColProduct.HeaderText = "Add Product";
            this.ColProduct.Name = "ColProduct";
            this.ColProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColBag
            // 
            this.ColBag.HeaderText = "Bags";
            this.ColBag.Name = "ColBag";
            // 
            // ColQuantity
            // 
            this.ColQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColQuantity.HeaderText = "Quantity";
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.Width = 71;
            // 
            // ColPurchaseValue
            // 
            this.ColPurchaseValue.HeaderText = "Purchase Value";
            this.ColPurchaseValue.Name = "ColPurchaseValue";
            // 
            // ColResaleVal
            // 
            this.ColResaleVal.HeaderText = "Resale Value";
            this.ColResaleVal.Name = "ColResaleVal";
            // 
            // ColDel
            // 
            this.ColDel.HeaderText = "Click To Delete";
            this.ColDel.Name = "ColDel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 134;
            this.label5.Text = "Total Purchase Price";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(425, 358);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 20);
            this.textBox1.TabIndex = 135;
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
            // AddItemToolStrip
            // 
            this.AddItemToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddItemToolStrip.Image")));
            this.AddItemToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddItemToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddItemToolStrip.Name = "AddItemToolStrip";
            this.AddItemToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddItemToolStrip.Text = "New Item";
            this.AddItemToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddItemToolStrip.Click += new System.EventHandler(this.AddItemToolStrip_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(425, 385);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 20);
            this.textBox2.TabIndex = 137;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 136;
            this.label6.Text = "Total Resale Price";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Enabled = false;
            this.txtVendorName.Location = new System.Drawing.Point(117, 96);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(149, 20);
            this.txtVendorName.TabIndex = 138;
            // 
            // Winform_PurchaseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 441);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Winform_PurchaseBill";
            this.Text = "Add Purchase Bill";
            this.Load += new System.EventHandler(this.Winform_PurchaseBill_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpPurchaseDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.txtVendorName, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton AddItemToolStrip;
        private System.Windows.Forms.ToolStripButton AddVendorToolStrip;
        private System.Windows.Forms.RadioButton rdbSales;
        private System.Windows.Forms.RadioButton rdbPurchase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.DataGridViewButtonColumn ColProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPurchaseValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColResaleVal;
        private System.Windows.Forms.DataGridViewButtonColumn ColDel;
    }
}