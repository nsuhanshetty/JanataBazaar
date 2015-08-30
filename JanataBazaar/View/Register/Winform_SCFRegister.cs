﻿using JanataBazaar.Builders;
using JanataBazaar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class Winform_SCFRegister : WinformRegister
    {
        public Winform_SCFRegister()
        {
            InitializeComponent();
        }

        private void Winform_SCFRegister_Load(object sender, EventArgs e)
        {
            List<Section> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtBrand.Text))
            {
                dgvRegister.DataSource = "";
                return;
            }

            IList list = (ReportsBuilder.GetSCFReport(txtName.Text, txtBrand.Text, cmbSection.Text));
            dgvRegister.DataSource = list;

            if (list == null)
                UpdateStatus("No Results Found");
            else
                UpdateStatus(list.Count + " Results Found", 100);
        }
    }
}
