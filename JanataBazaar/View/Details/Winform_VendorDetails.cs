using JanataBazaar.Model;
using JanataBazaar.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winform_VendorDetails : JanataBazaar.View.Details.Winform_Details
    {
        Vendor _vendor = new Vendor();

        public Winform_VendorDetails(Vendor vendor)
        {
            InitializeComponent();
            this._vendor = vendor;

            txtName.Text = _vendor.Name;
            txtMobNo.Text = _vendor.MobileNo;
            txtPhoneNo.Text = _vendor.PhoneNo;
            txtAddress.Text = _vendor.Address;

            txtTin.Text = _vendor.TIN;
            txtPLP.Text = _vendor.PLP;
            txtCST.Text = _vendor.CST;

            txtBankUserName.Text = _vendor.BankUserName;
            txtIfscCode.Text = _vendor.IFSCCode;
            txtAccNo.Text = _vendor.AccNo;
            cmbBankName.Text = _vendor.BankName;

            udDuration.Value = _vendor.DurationCount;
            if (_vendor.DurationTerm)
                rdbDays.Checked = true;
            else
                rdbMonth.Checked = true;
        }

        public Winform_VendorDetails()
        {
            InitializeComponent();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            List<string> exceptionList = new List<string> { "txtCST", "txtPLP", "txtTin", "txtPhoneNo", "txtBankUserName", "txtIfscCode", "txtAccNo", "cmbBankName" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, exceptionList)) return;

            UpdateStatus("fetching Vendor Details..", 33);

            _vendor.BankUserName = txtBankUserName.Text;
            _vendor.BankName = cmbBankName.Text;
            _vendor.IFSCCode = txtIfscCode.Text;
            _vendor.AccNo = txtAccNo.Text;

            _vendor.Name = txtName.Text;
            _vendor.Address = txtAddress.Text;
            _vendor.MobileNo = txtMobNo.Text;
            _vendor.PhoneNo = txtPhoneNo.Text;

            _vendor.TIN = txtTin.Text;
            _vendor.PLP = txtPLP.Text;
            _vendor.CST = txtCST.Text;

            _vendor.DurationCount = int.Parse(udDuration.Value.ToString());
            _vendor.DurationTerm = rdbDays.Checked;

            UpdateStatus("Saving..", 66);
            bool response = PeoplePracticeSaver.SaveVendorInfo(this._vendor);

            if (response)
                UpdateStatus("Saved.", 100);
            else
                UpdateStatus("Error Saving Vendor Details.", 100);

            //Winform_VendorsRegister addSaleReg = Application.OpenForms["Winform_VendorsRegister"] as Winform_VendorsRegister;
            //if (addSaleReg != null)
            //    addSaleReg.LoadDgv();

            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (JanataBazaar.Utilities.Validation.IsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        #region Validation
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Name\n" +
      "For example 'Geeta Prasad'";
            errorProvider1.SetError(txtName, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtName.TextLength);
            }
        }

        private void txtMobNo_Validating(object sender, CancelEventArgs e)
        {
            var txtBox = (TextBox)sender;
            Match _match = Regex.Match(txtBox.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Contact Number\n" +
                                                    "For example '9880123456/08000000'";
            errorProvider1.SetError(txtBox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtBox.Select(0, txtBox.TextLength);
            }
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPhoneNo.Text)) return;
            txtMobNo_Validating(txtPhoneNo, new CancelEventArgs());
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text = Utilities.Validation.ToTitleCase(txtName.Text);
        }
        #endregion Validation

        private void Winform_VendorDetails_Load(object sender, EventArgs e)
        {
            //todo: Load the bank names
        }
    }
}
