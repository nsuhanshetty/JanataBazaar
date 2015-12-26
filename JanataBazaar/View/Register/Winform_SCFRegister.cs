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
    public partial class Winform_SCFRegister : WinformRegister
    {
        List<ItemPricing> itemlist;
        public Winform_SCFRegister()
        {
            InitializeComponent();
        }

        private void Winform_SCFRegister_Load(object sender, EventArgs e)
        {
            List<string> sectList = ItemDetailsBuilder.GetSectionsList();
            sectList.Add("");
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            //cmbSection.ValueMember = "ID";

            cmbSection.Text = "";

            cmbDuration.SelectedIndex = 0;
            this.toolStrip1.Items.Add(this.SearchToolStrip);
        }

        //private void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtBrand.Text))
        //    {
        //        dgvRegister.DataSource = "";
        //        return;
        //    }

        //    itemlist = (ReportsBuilder.GetSCFReport(rdbCredit.Checked, txtSCF.Text,txtVendorName.Text, txtName.Text, txtBrand.Text, cmbSection.Text));
        //    dgvRegister.DataSource = (from itm in itemlist
        //                              select new
        //                              {
        //                                  itm.Item.Name,
        //                                  itm.Item.Brand,
        //                                  PackageType = itm.Package.Name,
        //                                  itm.PackageQuantity,
        //                                  itm.QuantityPerPack,
        //                                  itm.PurchaseValue,
        //                                  TotalPurchase = itm.TotalPurchaseValue,
        //                                  itm.Wholesale,
        //                                  TotalWholesale = itm.TotalWholesaleValue,
        //                                  itm.Retail,
        //                                  TotalResale = itm.TotalResaleValue
        //                              }).ToList();

        //    if (itemlist == null)
        //        UpdateStatus("No Results Found");
        //    else
        //        UpdateStatus(itemlist.Count + " Results Found", 100);
        //}

        protected override void toolStripButtonPrint_Click(object sender, System.EventArgs e)
        {
            new Reports.Report_SCF(itemlist).ShowDialog();
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
            
            itemlist = (ReportsBuilder.GetSCFReport(rdbCredit.Checked, txtSCF.Text, txtVendorName.Text, toDate, fromDate, txtName.Text, txtBrand.Text, cmbSection.Text));
            if (itemlist.Count == 0)
            {
                dgvRegister.DataSource = null;
                UpdateStatus("No Results Found");
            }
            else
            {
                dgvRegister.DataSource = (from itm in itemlist
                                          select new
                                          {
                                              itm.Purchase.SCFNo,
                                              itm.Item.Name,
                                              itm.Item.Brand,
                                              //PackageType = itm.Package.Name,
                                              itm.PackageQuantity,
                                              itm.QuantityPerPack,
                                              itm.PurchaseValue,
                                              TotalPurchase = itm.TotalPurchaseValue,
                                              itm.Wholesale,
                                              TotalWholesale = itm.TotalWholesaleValue,
                                              itm.Retail,
                                              TotalResale = itm.TotalResaleValue
                                          }).ToList();
                UpdateStatus(itemlist.Count + " Results Found", 100);
            }
        }
    }
}
