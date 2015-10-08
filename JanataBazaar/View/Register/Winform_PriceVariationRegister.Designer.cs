namespace JanataBazaar.View.Register
{
    partial class Winform_PriceVariationRegister
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStockPriceDetails = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPriceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Size = new System.Drawing.Size(517, 158);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvStockPriceDetails);
            this.groupBox2.Location = new System.Drawing.Point(15, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 158);
            this.groupBox2.TabIndex = 128;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock\\Price Details";
            // 
            // dgvStockPriceDetails
            // 
            this.dgvStockPriceDetails.AllowUserToAddRows = false;
            this.dgvStockPriceDetails.AllowUserToDeleteRows = false;
            this.dgvStockPriceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockPriceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockPriceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockPriceDetails.Location = new System.Drawing.Point(3, 16);
            this.dgvStockPriceDetails.Name = "dgvStockPriceDetails";
            this.dgvStockPriceDetails.ReadOnly = true;
            this.dgvStockPriceDetails.Size = new System.Drawing.Size(511, 139);
            this.dgvStockPriceDetails.TabIndex = 0;
            // 
            // Winform_PriceVariationRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 403);
            this.Controls.Add(this.groupBox2);
            this.Name = "Winform_PriceVariationRegister";
            this.Text = "Price Variation Register";
            this.Load += new System.EventHandler(this.Winform_PriceVariationRegister_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockPriceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStockPriceDetails;
    }
}