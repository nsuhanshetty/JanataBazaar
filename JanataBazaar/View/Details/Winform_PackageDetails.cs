using System;
using JanataBazaar.Models;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace JanataBazaar.View.Details
{
    public partial class Winform_PackageDetails : Winform_Details
    {
        Package package;

        public Winform_PackageDetails()
        {
            InitializeComponent();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.IsNullOrEmpty(this, true))
                return;

            txtPackageName_Validating(txtPackageName, new System.ComponentModel.CancelEventArgs());
            if (errorProvider1.GetError(txtPackageName) != "") return;

            txtPackageName.Text = Utilities.Validation.ToTitleCase(txtPackageName.Text);

            if (Builders.PackageDetailsBuilder.PackageExists(txtPackageName.Text))
            {
                errorProvider1.SetError(txtPackageName, "Package Type is a Duplicate as it already exists");
                txtPackageName.Select(0, txtPackageName.TextLength);
                UpdateStatus("Error in Saving Package Type", 100);
                return;
            }

            package = new Package(txtPackageName.Text,int.Parse(txtWeight.Text), chkIsStocked.Checked);

            if (Savers.PackageDetailsSavers.SavePackage(package) == 0)
            {
                UpdateStatus("Error in Saving Package.", 100);
                return;
            }

            UpdateStatus("Package Saved.", 100);
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.IsInEdit(txtPackageName, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Package Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        private void txtPackageName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errorMsg = "";

            if (string.IsNullOrEmpty(txt.Text))
                errorMsg = "Package type Cannot be Empty";
            else
            {
                Match _match = Regex.Match(txt.Text, "^[a-zA-Z\\s]+$");
                errorMsg = _match.Success ? "" : "Invalid Input\n" +
          "For example 'ABCabc'";
            }
            errorProvider1.SetError(txt, errorMsg);

            if (errorMsg != "")
            {
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);
                return;
            }
        }

        private void txtWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string _errorMsg;

            if (string.IsNullOrEmpty(txt.Text))
            {
              _errorMsg = "Invalid Amount input data type.\nExample: '5'";
            }
            else
            {
                Match _match = Regex.Match(txt.Text, "^[0-9]*\\.?[0-9]*$");
                _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '5'" : "";
            }
            errorProvider1.SetError(txt, _errorMsg);

            if (_errorMsg != "")
            {
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);
            }
        }
    }
}
