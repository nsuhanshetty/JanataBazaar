﻿using JanataBazaar.Builders;
using JanataBazaar.Model;
using JanataBazaar.Models;
using JanataBazaar.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winform_VendorDetails : JanataBazaar.View.Details.Winform_Details
    {
        Vendor _vendor;

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
            //cmbBankName.Text = _vendor.BankName;

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
            List<string> exceptionList = new List<string> { "txtCST", "txtPLP", "txtTin", "txtPhoneNo", "txtMobNo", "txtBankUserName", "txtIfscCode", "txtAccNo", "cmbBankName" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, exceptionList)) return;

            UpdateStatus("fetching Vendor Details..", 33);

            if (this._vendor == null)
                this._vendor = new Vendor();
            _vendor.BankUserName = txtBankUserName.Text;

            if (!IsNullOrEmpty(cmbBankName.Text) && !PeoplePracticeBuilder.IfBankExits(cmbBankName.Text))
                this._vendor.Bank = new Bank(cmbBankName.Text);
            else if (!string.IsNullOrEmpty(cmbBankName.Text))
                this._vendor.Bank = PeoplePracticeBuilder.GetBankNames(cmbBankName.Text);

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
            {
                UpdateStatus("Saved.", 100);
                this.Close();
            }
            else
                UpdateStatus("Error Saving Vendor Details.", 100);

            //Winform_VendorsRegister addSaleReg = Application.OpenForms["Winform_VendorsRegister"] as Winform_VendorsRegister;
            //if (addSaleReg != null)
            //    addSaleReg.LoadDgv();


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
            if (String.IsNullOrEmpty(txtMobNo.Text)) return;

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
            txtName.Text = Utilities.Validation.ToTitleCase(txtName.Text.ToLower());
        }
        #endregion Validation

        private void Winform_VendorDetails_Load(object sender, EventArgs e)
        {
            //todo: Load the bank names
            List<Bank> BankList = PeoplePracticeBuilder.GetBankNames();
            cmbBankName.DataSource = BankList;
            cmbBankName.DisplayMember = "Name";
            cmbBankName.ValueMember = "ID";

            string[] bankNames = BankList.Select(x => x.Name).ToArray();
            var nameCollection = new AutoCompleteStringCollection();
            nameCollection.AddRange(bankNames);

            cmbBankName.AutoCompleteCustomSource = nameCollection;
            cmbBankName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBankName.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbBankName.Text = "";
            if (this._vendor != null && this._vendor.Bank != null)
                cmbBankName.SelectedText = this._vendor.Bank.Name;
        }
    }
}
