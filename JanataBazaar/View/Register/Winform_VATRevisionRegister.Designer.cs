namespace JanataBazaar.View.Register
{
    partial class Winform_VATRevisionRegister
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPercentView = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercentView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Size = new System.Drawing.Size(239, 180);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPercentView);
            this.groupBox3.Location = new System.Drawing.Point(6, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 139);
            this.groupBox3.TabIndex = 131;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Percentage Details";
            // 
            // dgvPercentView
            // 
            this.dgvPercentView.AllowUserToAddRows = false;
            this.dgvPercentView.AllowUserToDeleteRows = false;
            this.dgvPercentView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPercentView.Location = new System.Drawing.Point(3, 16);
            this.dgvPercentView.Name = "dgvPercentView";
            this.dgvPercentView.ReadOnly = true;
            this.dgvPercentView.Size = new System.Drawing.Size(231, 120);
            this.dgvPercentView.TabIndex = 0;
            // 
            // Winform_VATRevisionRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 407);
            this.Controls.Add(this.groupBox3);
            this.Name = "Winform_VATRevisionRegister";
            this.Text = "VATRevisionRegister";
            this.Load += new System.EventHandler(this.VATRevisionRegister_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercentView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPercentView;
    }
}