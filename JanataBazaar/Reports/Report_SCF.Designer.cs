namespace JanataBazaar.Reports
{
    partial class Report_SCF
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
            this.dataSet_SCF = new JanataBazaar.Datasets.DataSet_SCF();
            this.dataSetSCFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableSCFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable_SCFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_SCF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSCFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSCFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable_SCFBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableSCFBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JanataBazaar.Reports.ReportSFC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1195, 370);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_SCF
            // 
            this.dataSet_SCF.DataSetName = "DataSet_SCF";
            this.dataSet_SCF.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetSCFBindingSource
            // 
            this.dataSetSCFBindingSource.DataSource = this.dataSet_SCF;
            this.dataSetSCFBindingSource.Position = 0;
            // 
            // dataTableSCFBindingSource
            // 
            this.dataTableSCFBindingSource.DataMember = "DataTable_SCF";
            this.dataTableSCFBindingSource.DataSource = this.dataSetSCFBindingSource;
            // 
            // DataTable_SCFBindingSource
            // 
            this.DataTable_SCFBindingSource.DataMember = "DataTable_SCF";
            this.DataTable_SCFBindingSource.DataSource = this.dataSet_SCF;
            // 
            // Report_SCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 370);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_SCF";
            this.Text = "Report_SCF";
            this.Load += new System.EventHandler(this.Report_SCF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_SCF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSCFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSCFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable_SCFBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTableSCFBindingSource;
        private System.Windows.Forms.BindingSource dataSetSCFBindingSource;
        private Datasets.DataSet_SCF dataSet_SCF;
        private System.Windows.Forms.BindingSource DataTable_SCFBindingSource;
    }
}