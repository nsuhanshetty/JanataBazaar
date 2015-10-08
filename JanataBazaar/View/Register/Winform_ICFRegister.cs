using JanataBazaar.Builders;
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
    public partial class Winform_ICFRegister : WinformRegister
    {
        List<ItemPricing> itemlist;

        public Winform_ICFRegister()
        {
            InitializeComponent();
        }

        private void Winform_ICFRegister_Load(object sender, EventArgs e)
        {
            List<Section> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";

            cmbDuration.SelectedIndex = 0;
            this.toolStrip1.Items.Add(this.SearchToolStrip);
        }

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isActive = (cmbDuration.Text == "Custom") ? true : false;

            dtpTo.Enabled = isActive;
            dtpFrom.Enabled = isActive;

            nudDuration.Enabled = !isActive;
        }

        protected void SearchToolStrip_Click(object sender, System.EventArgs e)
        {
            DateTime toDate = new DateTime();
            DateTime fromDate = new DateTime();

            bool isCredit = rdbCredit.Checked;

            int duration;
            int.TryParse(nudDuration.Value.ToString(), out duration);
            duration = duration == 0 ? 1 : duration;

            #region SetDuration
            if (cmbDuration.Text == "Custom")
            {
                if (DateTime.Compare(dtpFrom.Value.Date, dtpTo.Value.Date) > 0)
                {
                    MessageBox.Show("From date cannot be greater than To date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                toDate = dtpTo.Value.Date;
                fromDate = dtpFrom.Value.Date;
            }
            else if (cmbDuration.Text == "Month")
            {
                toDate = DateTime.Today.Date;
                fromDate = DateTime.Today.Date.AddMonths(-duration);
            }
            else if (cmbDuration.Text == "Week")
            {
                toDate = DateTime.Today.Date;
                fromDate = DateTime.Today.Date.AddDays(-7 * duration);
            }
            else if (cmbDuration.Text == "Day")
            {
                toDate = DateTime.Today.Date;
                fromDate = DateTime.Today.Date.AddDays(-duration);
            }
            #endregion SetDuration

            itemlist = (ReportsBuilder.GetICFReport(rdbCredit.Checked, txtICF.Text, txtVendorName.Text, toDate, fromDate, txtName.Text, txtBrand.Text, cmbSection.Text));
            dgvRegister.DataSource = (from itm in itemlist
                                      select new
                                      {
                                          ICF_No = itm.Purchase.IRNNo,
                                          Supplier = itm.Purchase.Vendor.Name,
                                          Supplier_BillNo = itm.Purchase.BillNo,
                                          itm.Purchase.DateOfInvoice,
                                          itm.Purchase.TotalPurchasePrice,
                                          itm.Purchase.TotalWholesalePrice,
                                          itm.Purchase.TotalResalePrice
                                      }).ToList();

            if (itemlist == null)
                UpdateStatus("No Results Found");
            else
                UpdateStatus(itemlist.Count + " Results Found", 100);
        }
    }
}
