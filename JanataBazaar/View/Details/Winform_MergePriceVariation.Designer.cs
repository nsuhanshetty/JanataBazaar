namespace JanataBazaar.View.Details
{
    partial class Winform_MergePriceVariation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_MergePriceVariation));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMergerLeft = new System.Windows.Forms.Button();
            this.btnMergeRight = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLowerPrice = new System.Windows.Forms.DataGridView();
            this.lcolSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lcolStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lcolWholePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lcolResalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvHigherPrice = new System.Windows.Forms.DataGridView();
            this.hcolSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hcolStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hcolWholePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hcolResalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowerPrice)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHigherPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMergerLeft);
            this.panel3.Controls.Add(this.btnMergeRight);
            this.panel3.Location = new System.Drawing.Point(433, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(82, 256);
            this.panel3.TabIndex = 2;
            // 
            // btnMergerLeft
            // 
            this.btnMergerLeft.Location = new System.Drawing.Point(10, 137);
            this.btnMergerLeft.Name = "btnMergerLeft";
            this.btnMergerLeft.Size = new System.Drawing.Size(62, 32);
            this.btnMergerLeft.TabIndex = 1;
            this.btnMergerLeft.Text = "<<";
            this.btnMergerLeft.UseVisualStyleBackColor = true;
            this.btnMergerLeft.Click += new System.EventHandler(this.btnMergerLeft_Click);
            // 
            // btnMergeRight
            // 
            this.btnMergeRight.Location = new System.Drawing.Point(10, 99);
            this.btnMergeRight.Name = "btnMergeRight";
            this.btnMergeRight.Size = new System.Drawing.Size(62, 32);
            this.btnMergeRight.TabIndex = 0;
            this.btnMergeRight.Text = ">>";
            this.btnMergeRight.UseVisualStyleBackColor = true;
            this.btnMergeRight.Click += new System.EventHandler(this.btnMergeRight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLowerPrice);
            this.groupBox1.Location = new System.Drawing.Point(21, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 275);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stocks With Lower Prices";
            // 
            // dgvLowerPrice
            // 
            this.dgvLowerPrice.AllowUserToAddRows = false;
            this.dgvLowerPrice.AllowUserToDeleteRows = false;
            this.dgvLowerPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowerPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowerPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lcolSelect,
            this.lID,
            this.lcolStock,
            this.lcolWholePrice,
            this.lcolResalePrice});
            this.dgvLowerPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLowerPrice.Location = new System.Drawing.Point(3, 16);
            this.dgvLowerPrice.Name = "dgvLowerPrice";
            this.dgvLowerPrice.ReadOnly = true;
            this.dgvLowerPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowerPrice.Size = new System.Drawing.Size(406, 256);
            this.dgvLowerPrice.TabIndex = 0;
            this.dgvLowerPrice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLowerPrice_CellClick);
            // 
            // lcolSelect
            // 
            this.lcolSelect.HeaderText = "Select";
            this.lcolSelect.Name = "lcolSelect";
            this.lcolSelect.ReadOnly = true;
            // 
            // lID
            // 
            this.lID.HeaderText = "lID";
            this.lID.Name = "lID";
            this.lID.ReadOnly = true;
            this.lID.Visible = false;
            // 
            // lcolStock
            // 
            this.lcolStock.HeaderText = "StockQuantity";
            this.lcolStock.Name = "lcolStock";
            this.lcolStock.ReadOnly = true;
            // 
            // lcolWholePrice
            // 
            this.lcolWholePrice.HeaderText = "Wholesale Price";
            this.lcolWholePrice.Name = "lcolWholePrice";
            this.lcolWholePrice.ReadOnly = true;
            // 
            // lcolResalePrice
            // 
            this.lcolResalePrice.HeaderText = "Resale Price";
            this.lcolResalePrice.Name = "lcolResalePrice";
            this.lcolResalePrice.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvHigherPrice);
            this.groupBox2.Location = new System.Drawing.Point(523, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 275);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stocks With Higher Prices";
            // 
            // dgvHigherPrice
            // 
            this.dgvHigherPrice.AllowUserToAddRows = false;
            this.dgvHigherPrice.AllowUserToDeleteRows = false;
            this.dgvHigherPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHigherPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHigherPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hcolSelect,
            this.hid,
            this.hcolStock,
            this.hcolWholePrice,
            this.hcolResalePrice});
            this.dgvHigherPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHigherPrice.Location = new System.Drawing.Point(3, 16);
            this.dgvHigherPrice.Name = "dgvHigherPrice";
            this.dgvHigherPrice.ReadOnly = true;
            this.dgvHigherPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHigherPrice.Size = new System.Drawing.Size(406, 256);
            this.dgvHigherPrice.TabIndex = 9;
            this.dgvHigherPrice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLowerPrice_CellClick);
            // 
            // hcolSelect
            // 
            this.hcolSelect.HeaderText = "Select";
            this.hcolSelect.Name = "hcolSelect";
            this.hcolSelect.ReadOnly = true;
            // 
            // hid
            // 
            this.hid.HeaderText = "hud";
            this.hid.Name = "hid";
            this.hid.ReadOnly = true;
            this.hid.Visible = false;
            // 
            // hcolStock
            // 
            this.hcolStock.HeaderText = "StockQuantity";
            this.hcolStock.Name = "hcolStock";
            this.hcolStock.ReadOnly = true;
            // 
            // hcolWholePrice
            // 
            this.hcolWholePrice.HeaderText = "Wholesale Price";
            this.hcolWholePrice.Name = "hcolWholePrice";
            this.hcolWholePrice.ReadOnly = true;
            // 
            // hcolResalePrice
            // 
            this.hcolResalePrice.HeaderText = "Resale Price";
            this.hcolResalePrice.Name = "hcolResalePrice";
            this.hcolResalePrice.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(394, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBrand);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.txtUnit);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 76);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Item Details";
            // 
            // txtBrand
            // 
            this.txtBrand.Enabled = false;
            this.txtBrand.Location = new System.Drawing.Point(259, 44);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(113, 20);
            this.txtBrand.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(218, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 13);
            this.label29.TabIndex = 126;
            this.label29.Text = "Brand";
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(88, 44);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(113, 20);
            this.txtUnit.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(88, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(113, 20);
            this.txtName.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(72, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(72, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Quantity Unit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(941, 311);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(908, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 23);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Winform_MergePriceVariation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 395);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "Winform_MergePriceVariation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merge Price Variations";
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowerPrice)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHigherPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvLowerPrice;
        private System.Windows.Forms.Button btnMergerLeft;
        private System.Windows.Forms.Button btnMergeRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvHigherPrice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lcolSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn lID;
        private System.Windows.Forms.DataGridViewTextBoxColumn lcolStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn lcolWholePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn lcolResalePrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hcolSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn hid;
        private System.Windows.Forms.DataGridViewTextBoxColumn hcolStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn hcolWholePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn hcolResalePrice;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}