﻿using JanataBazaar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winform_CustomerDetails : Winform_Details
    {
        Customer _cust;
        public Winform_CustomerDetails()
        {
            InitializeComponent();
        }

        public Winform_CustomerDetails(Customer _cust)
        {
            InitializeComponent();

            this._cust = _cust;

            /*Load Controls*/
            txtAddress.Text = _cust.Address;
            txtEmailID.Text = _cust.Email;
            txtMobNo.Text = _cust.Mobile_No;
            txtName.Text = _cust.Name;
            txtPhoneNo.Text = _cust.Phone_No;

            txtAccountNo.Text = _cust.AccountNo;
            txtPLFNo.Text = _cust.PLFNo;
        }

        #region _Validations
        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmailID.Text == String.Empty)
                return;

            string errorMsg = "";
            Match _match = Regex.Match(txtEmailID.Text, "^[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+\\.[A-Za-z]{2,6}$");
            errorMsg = _match.Success ? "" : "e-mail address must be valid e-mail address format.\n" +
      "For example 'someone@example.com' ";
            errorProvider1.SetError(txtEmailID, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtEmailID.TextLength);
            }
        }

        private void txtMobNo_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtMobNo, errorMsg);

            //bool isUnique = PeoplePracticeBuilder.IsCustomerMobileNoUnique(txtMobNo.Text);
            //!isUnique?"Mobile Number entered is a Duplicate. Kindly Check again";

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtMobNo.Select(0, txtMobNo.TextLength);
            }

            //Check if mobile no is unique

        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
        }

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

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhoneNo.Text == String.Empty)
                return;

            Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Phone Number\n" +
  " For example '8012345678'";
            errorProvider1.SetError(txtPhoneNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPhoneNo.Select(0, txtPhoneNo.TextLength);
            }
        }
        #endregion _Validations

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            UpdateStatus("Saving Customer", 50);
            string[] input = { "txtPhoneNo", "txtAddress", "txtEmailID" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            if (_cust == null)
                _cust = new Customer(txtName.Text, txtMobNo.Text, txtPhoneNo.Text, txtAccountNo.Text, txtPLFNo.Text, txtAddress.Text, txtEmailID.Text);
            else
            {
                _cust.Name = txtName.Text;
                _cust.Mobile_No = txtMobNo.Text;
                _cust.Phone_No = txtPhoneNo.Text;
                _cust.AccountNo = txtAccountNo.Text;
                _cust.PLFNo = txtPLFNo.Text;
                _cust.Address = txtAddress.Text;
                _cust.Email = txtEmailID.Text;
            }

            bool success = Savers.PeoplePracticeSaver.SaveCustomerInfo(_cust);

            if (success)
            {
                UpdateStatus("Saved", 100);
                this.Close();
                return;
            }

            UpdateStatus("Error in saving Customer", 100);
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.IsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };
            this.Close();
        }
    }
}