namespace JanataBazaar.View.Register
{
    partial class Winform_SCFRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_SCFRegister));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbCredit = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSCF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchToolStrip = new System.Windows.Forms.ToolStripButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvItemRegister = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 178);
            this.groupBox1.Size = new System.Drawing.Size(1029, 206);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVendorName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSCF);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(3, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 118);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Items";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(106, 83);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(149, 20);
            this.txtVendorName.TabIndex = 158;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 159;
            this.label6.Text = "Name Of Supplier";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbCash);
            this.groupBox3.Controls.Add(this.rdbCredit);
            this.groupBox3.Location = new System.Drawing.Point(106, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 33);
            this.groupBox3.TabIndex = 156;
            this.groupBox3.TabStop = false;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Location = new System.Drawing.Point(84, 12);
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
            this.rdbCredit.Location = new System.Drawing.Point(15, 12);
            this.rdbCredit.Name = "rdbCredit";
            this.rdbCredit.Size = new System.Drawing.Size(52, 17);
            this.rdbCredit.TabIndex = 123;
            this.rdbCredit.TabStop = true;
            this.rdbCredit.Text = "Credit";
            this.rdbCredit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Type Of Bill";
            // 
            // txtSCF
            // 
            this.txtSCF.Location = new System.Drawing.Point(106, 58);
            this.txtSCF.MaxLength = 15;
            this.txtSCF.Name = "txtSCF";
            this.txtSCF.Size = new System.Drawing.Size(149, 20);
            this.txtSCF.TabIndex = 154;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 155;
            this.label10.Text = "SCF No.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudDuration);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cmbDuration);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtpTo);
            this.groupBox4.Controls.Add(this.dtpFrom);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(279, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 102);
            this.groupBox4.TabIndex = 153;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Duration Details (Date Of Invoice)";
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(245, 23);
            this.nudDuration.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(59, 20);
            this.nudDuration.TabIndex = 127;
            this.nudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(13, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "Format";
            // 
            // cmbDuration
            // 
            this.cmbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuration.FormattingEnabled = true;
            this.cmbDuration.Items.AddRange(new object[] {
            "Month",
            "Week",
            "Day",
            "Custom"});
            this.cmbDuration.Location = new System.Drawing.Point(59, 22);
            this.cmbDuration.Name = "cmbDuration";
            this.cmbDuration.Size = new System.Drawing.Size(126, 21);
            this.cmbDuration.TabIndex = 125;
            this.cmbDuration.SelectedIndexChanged += new System.EventHandler(this.cmbDuration_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(191, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 124;
            this.label3.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(32, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Enabled = false;
            this.dtpTo.Location = new System.Drawing.Point(59, 73);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(126, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Location = new System.Drawing.Point(59, 47);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(126, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(22, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 122;
            this.label7.Text = "From";
            // 
            // SearchToolStrip
            // 
            this.SearchToolStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SearchToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SearchToolStrip.Image")));
            this.SearchToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchToolStrip.Name = "SearchToolStrip";
            this.SearchToolStrip.Size = new System.Drawing.Size(46, 51);
            this.SearchToolStrip.Text = "&Search";
            this.SearchToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SearchToolStrip.Click += new System.EventHandler(this.SearchToolStrip_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvItemRegister);
            this.groupBox5.Location = new System.Drawing.Point(4, 390);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1026, 170);
            this.groupBox5.TabIndex = 128;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Item Details";
            // 
            // dgvItemRegister
            // 
            this.dgvItemRegister.AllowUserToAddRows = false;
            this.dgvItemRegister.AllowUserToDeleteRows = false;
            this.dgvItemRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemRegister.Location = new System.Drawing.Point(3, 16);
            this.dgvItemRegister.Name = "dgvItemRegister";
            this.dgvItemRegister.ReadOnly = true;
            this.dgvItemRegister.Size = new System.Drawing.Size(1020, 151);
            this.dgvItemRegister.TabIndex = 0;
            // 
            // Winform_SCFRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 585);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Name = "Winform_SCFRegister";
            this.Text = "Stock Control Form Register";
            this.Load += new System.EventHandler(this.Winform_SCFRegister_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbCredit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSCF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudDuration;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDuration;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        internal System.Windows.Forms.Label label7;

        //Custom
        private System.Windows.Forms.ToolStripButton SearchToolStrip;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvItemRegister;
    }
}