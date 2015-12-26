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
        //private object dgvOrderItems;

        public Winform_VATDetails()
        {
            InitializeComponent();
        }

        public Winform_VATDetails(int _ID)
        {
            InitializeComponent();

            //get VAT Percentages based on the _ID
            VATRevision _vatRevision = Builders.VATRevisionBuilder.GetVATRevisionInfo(_ID);

            //load the controls
            this.vatRevision = _vatRevision;
            dtpFromYear.Value = vatRevision.DateOfRevision;
            this.vatPercentList = vatRevision.VATList.ToList();
        }

        private void Winform_VATDetails_Load(object sender, EventArgs e)
        {
            // dtpToYear.Value = dtpFromYear.Value.AddYears(1);

            //fetch the VAT values from the previous term table
            //            else 
            if (this.vatRevision == null)
            {
                vatPercentList = new List<VATPercent>();
                vatPercentList.Add(new VATPercent(0));
            }
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
            if (vatPercentList.Any(x => x.Percent == percentValue))
            {
                MessageBox.Show("VAT Percentage of the entered value already exists in the list", "Duplicate VAT value", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                //update the vatlist to add to 
                vatPercentList.Add(new VATPercent(percentValue));
                LoadDGV();
            }
            txtVatPercent.Text = "";
        }

        private void LoadDGV()
        {
            dgvPercentList.DataSource = (from vat in vatPercentList
                                         orderby vat.Percent ascending
                                         select new { vat.ID, VATPercentage = vat.Percent }).ToList();

            dgvPercentList.Columns["ID"].Visible = false;
            if (dgvPercentList.Rows.Count == 0)
            {
                dgvPercentList.Columns["colDelete"].Visible = false;
                return;
            }
            else
            {
                dgvPercentList.Columns["colDelete"].DisplayIndex = dgvPercentList.Columns.Count - 1;
                dgvPercentList.Columns["colDelete"].Visible = true;
            }

            //dgvPercentList.Rows.Clear();
            //if (vatList.Count == 0)
            //{
            //    dgvPercentList.Columns["colDelete"].Visible = true;
            //    return;
            //}

            //foreach (var per in vatPercentList)
            //{
            //    var index = dgvPercentList.Rows.Add();
            //    dgvPercentList.Rows[index].Cells["colPercent"].Value = per.Percent;
            //}
            //dgvPercentList.Columns["colDelete"].DisplayIndex = dgvPercentList.Columns.Count - 1;
            //dgvPercentList.Columns["colDelete"].Visible = true;
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpFromYear, "");

            int _ID = vatRevision == null ? 0 : vatRevision.ID;

            if (vatPercentList.Count == 0)
                MessageBox.Show("VAT percentage List cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //todo: Verfiy what can be the constraints on RevisionDate
            //else if (DateTime.Compare(dtpFromYear.Value.Date, DateTime.Today.Date) < 0)
            //{
            //    errorProvider1.SetError(dtpFromYear, "Revision Date cannot be less than today");
            //    return;
            //}
            else if (Savers.VATPercentSavers.IsUniqueRevisionDate(dtpFromYear.Value.Date, _ID))
            {
                MessageBox.Show("The Date of Revision already exists. Enter a different Date and try again", "Duplicate Revision Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*Add Or Updating Existing VAT Revisions.*/
            if (vatRevision == null)
            {
                vatRevision = new VATRevision(dtpFromYear.Value.Date, vatPercentList);
            }
            else
            {
                vatRevision.DateOfRevision = dtpFromYear.Value.Date;
                vatRevision.VATList = vatPercentList;
            }
            bool success = Savers.VATPercentSavers.SaveVATRevision(vatRevision);

            if (success)
            {
                UpdateStatus("VAT Revision added successfully", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error saving VAT Revision", 100);
            }
            //}
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
                bool success = false;
                if (vatPercentList.Count != 0 && e.RowIndex + 1 <= vatPercentList.Count)
                {
                    if (vatPercentList[e.RowIndex].ID != 0)
                        success = Savers.VATPercentSavers.DeletePercentItems(vatPercentList[e.RowIndex].ID);

                    if (success || vatPercentList[e.RowIndex].ID == 0) // "ID == 0" => Not yet Added to the db 
                    {
                        vatPercentList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                        return;
                    }
                }
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
    }
}
