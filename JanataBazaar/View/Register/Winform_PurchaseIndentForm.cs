using JanataBazaar.Builders;
using JanataBazaar.Models;
using System;
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
    public partial class Winform_PurchaseIndentForm : WinformRegister
    {
        public Winform_PurchaseIndentForm()
        {
            InitializeComponent();
        }

        private void Winform_PurchaseIndentForm_Load(object sender, EventArgs e)
        {
            List<Section> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get items where stock less their stock(packetquant * itemsperpack)
            if (string.IsNullOrEmpty(cmbSection.Text))
            {
                dgvRegister.DataSource = "";
                return;
            }

            //display Itemname, Brand, Quantity unit, current stock, Expected Reserve
            dgvRegister.DataSource = ReportsBuilder.GetPIFReport(cmbSection.Text);

            if (dgvRegister.Rows.Count == 0)
                UpdateStatus("No Results Found");
            else
                UpdateStatus(dgvRegister.Rows.Count + " Results Found");
        }
    }
}
