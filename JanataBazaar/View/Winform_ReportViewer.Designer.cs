namespace JanataBazaar.View
{
    partial class Winform_ReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsRebateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRebate = new JanataBazaar.Datasets.dsRebate();
            this.dtRebateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsRebateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRebate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRebateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsRebate";
            reportDataSource1.Value = this.dsRebateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JanataBazaar.Reports.Report_Rebate.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(988, 457);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsRebateBindingSource
            // 
            this.dsRebateBindingSource.DataMember = "dtRebate";
            this.dsRebateBindingSource.DataSource = this.dsRebate;
            // 
            // dsRebate
            // 
            this.dsRebate.DataSetName = "dsRebate";
            this.dsRebate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtRebateBindingSource
            // 
            this.dtRebateBindingSource.DataMember = "dtRebate";
            this.dtRebateBindingSource.DataSource = this.dsRebate;
            // 
            // Winform_ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 457);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Winform_ReportViewer";
            this.Load += new System.EventHandler(this.Winform_ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsRebateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRebate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRebateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsRebateBindingSource;
        private Datasets.dsRebate dsRebate;
        private System.Windows.Forms.BindingSource dtRebateBindingSource;
    }
}