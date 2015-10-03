using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using NHibernate.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JanataBazaar.View.Details;

namespace JanataBazaar.View.Register
{
    public partial class Winform_VATRevisionRegister : WinformRegister
    {
        public Winform_VATRevisionRegister()
        {
            InitializeComponent();
        }

        private void VATRevisionRegister_Load(object sender, EventArgs e)
        {
            //get the vatrevision dates and laod the combobox.
            //var revisionList = Builders.VATRevisionBuilder.GetVATRevisionList();

            //var revisionDates = revisionList.Select(x => x.DateOfRevision.ToString("dd/MMM/yyyy"));

            dgvRegister.Columns.Add("colRevisionDate", "Date Of Revision");
            dgvRegister.Columns.Add("ID", "ID");

            //DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            //btnCol.Name = "colDelete";
            //btnCol.HeaderText = "Click To Delete";
            //dgvRegister.Columns.Add(btnCol);

            LoadDGV();
        }

        private void LoadDGV()
        {
            dgvRegister.DataSource = null;
            //dgvRegister.Columns.Clear();
            dgvRegister.Rows.Clear();

            //dgvRegister.Columns.Add("colRevisionDate", "Date Of Revision");
            //dgvRegister.Columns.Add("ID", "ID");
            dgvRegister.Columns["ID"].Visible = false;

            //DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            //btnCol.Name = "colDelete";
            //btnCol.HeaderText = "Click To Delete";
            //dgvRegister.Columns.Add(btnCol);
            dgvRegister.Columns["colDelete"].Visible = false;

            var revisionList = (from rev in Builders.VATRevisionBuilder.GetVATRevisionList()
                                select new { rev.DateOfRevision, rev.ID });

            if (revisionList != null && revisionList.Count() != 0)
            {
                foreach (var item in revisionList)
                {
                    var index = dgvRegister.Rows.Add();
                    dgvRegister.Rows[index].Cells["colRevisionDate"].Value = item.DateOfRevision.ToString("dd/MMM/yy");
                    dgvRegister.Rows[index].Cells["ID"].Value = item.ID.ToString();
                    dgvRegister.Columns["colDelete"].Visible = true;
                    dgvRegister.Columns["colDelete"].DisplayIndex = dgvRegister.Columns.Count - 1;
                }
            }

            UpdateStatus(revisionList.Count() + " results found.");
        }

        private void cmbRevisionDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //todo: Fetch the vat percents where date of Revision = cmb.text
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            //get the percentage details for the VAT Revision
            var percentageList = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString()));
            dgvPercentView.DataSource = percentageList.Count != 0 ? percentageList : null;

        }

        protected override void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            {
                new Winform_VATDetails(int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString())).ShowDialog();
                LoadDGV();
            }
        }
    }
}
