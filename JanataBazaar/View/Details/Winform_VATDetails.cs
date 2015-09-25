using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winform_VATDetails : Winform_Details
    {
        List<decimal> vatList = new List<decimal>();
        VATRevision vatRevision;
        List<VATPercent> vatPercentList;

        public Winform_VATDetails()
        {
            InitializeComponent();
        }

        public Winform_VATDetails(int _ID)
        {
            InitializeComponent();

            //get VAT Percentages based on the _ID
            //load the controls
        }

        private void Winform_VATDetails_Load(object sender, EventArgs e)
        {
            // dtpToYear.Value = dtpFromYear.Value.AddYears(1);

            //fetch the VAT values from the previous term table
            //            else 
            vatList.Add(0);
            LoadDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtVatPercent, "");
            if (string.IsNullOrEmpty(txtVatPercent.Text))
            {
                errorProvider1.SetError(txtVatPercent, "VAT Percent cannot be empty.");
                return;
            }

            decimal percentValue = decimal.Parse(txtVatPercent.Text);
            if (vatList.IndexOf(percentValue) != -1)
            {
                MessageBox.Show("VAT Percentage of the entered value already exists in the list", "Duplicate VAT value", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                vatList.Add(percentValue);
                LoadDGV();
            }
        }

        private void LoadDGV()
        {
            dgvPercentList.Rows.Clear();
            if (vatList.Count == 0)
            {
                dgvPercentList.Columns["colDelete"].Visible = true;
                return;
            }

            foreach (var per in vatList)
            {
                var index = dgvPercentList.Rows.Add();
                dgvPercentList.Rows[index].Cells["colPercent"].Value = per;
            }
            dgvPercentList.Columns["colDelete"].DisplayIndex = dgvPercentList.Columns.Count - 1;
            dgvPercentList.Columns["colDelete"].Visible = true;
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpFromYear, "");

            if (vatList.Count == 0)
                MessageBox.Show("VAT percentage List cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //todo: Verfiy what can be the constraints on RevisionDate
            else if (DateTime.Compare(dtpFromYear.Value.Date, DateTime.Today.Date) < 0)
            {
                errorProvider1.SetError(dtpFromYear, "Revision Date cannot be less than today");
                return;
            }

            if (vatRevision == null && vatPercentList == null)
            {

                vatPercentList = new List<VATPercent>();
                foreach (var item in vatList)
                {
                    VATPercent per = new VATPercent();
                    per.Percent = item;
                    vatPercentList.Add(per);
                }

                vatRevision = new VATRevision(dtpFromYear.Value.Date, vatPercentList);

                //todo: save the vatrevision
                bool success = Savers.VATPercentSavers.SaveVATRevision(vatRevision);

                if (success)
                {
                    UpdateStatus("VAT Revision added successfully",100);
                    this.Close();
                }
                else
                {
                    UpdateStatus("Error saving VAT Revision", 100);
                }
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPercentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvPercentList.Columns["colDelete"].Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete the VAT percentage?", "Delete VAT Percentage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                //todo:Delete from db

                vatList.RemoveAt(e.RowIndex);
                LoadDGV();
            }
        }

        private void txtVatPercent_Validating(object sender, CancelEventArgs e)
        {

            TextBox txtBox = (TextBox)sender;
            string _errorMsg;

            //Check if txt is empty
            errorProvider1.SetError(txtVatPercent, "");
            if (string.IsNullOrEmpty(txtVatPercent.Text))
            {
                _errorMsg = "VAT Percent cannot be empty.";
                return;
            }

            //check if the txt has the right datatype
            Match _match = Regex.Match(txtBox.Text, "^[0-9]*\\.?[0-9]*$");
            _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '2.2'" : "";

            errorProvider1.SetError(txtBox, _errorMsg);
            if (_errorMsg != "")
            {
                e.Cancel = true;
                txtBox.Select(0, txtBox.Text.Length);
            }
        }

        private void dtpFromYear_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpFromYear, "");

            if (DateTime.Compare(dtpFromYear.Value.Date, DateTime.Today.Date) < 0)
            {
                errorProvider1.SetError(dtpFromYear, "Revision Date cannot be less than today");
                return;
            }
        }
    }
}
