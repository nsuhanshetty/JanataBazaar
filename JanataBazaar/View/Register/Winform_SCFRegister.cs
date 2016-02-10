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
        List<ItemPricing> itemlist = new List<ItemPricing>();
        List<PurchaseOrder> orderList = new List<PurchaseOrder>();

        public Winform_SCFRegister()
        {
            InitializeComponent();
        }

        private void Winform_SCFRegister_Load(object sender, EventArgs e)
        {
            //List<string> sectList = ItemDetailsBuilder.GetSectionsList();
            //sectList.Add("");
            //cmbSection.DataSource = sectList;
            //cmbSection.DisplayMember = "Name";
            ////cmbSection.ValueMember = "ID";

            //cmbSection.Text = "";

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
            //new Reports.Report_SCF(itemlist).ShowDialog();
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

            dgvItemRegister.DataSource = null;
            dgvVATDetails.Rows.Clear();
            dgvVATDetails.Columns.Clear();

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
           
            orderList = (ReportsBuilder.GetSCFReport(rdbCredit.Checked, txtSCF.Text, txtVendorName.Text, toDate, fromDate));
            if (orderList.Count == 0)
            {
                dgvRegister.DataSource = null;
                UpdateStatus("No Results Found");
            }
            else
            {
                dgvRegister.DataSource = (from ord in orderList
                                          select new
                                          {
                                              ord.ID,
                                              ord.SCFNo,
                                              PurchaseDate = ord.DateOfPurchase.ToString("dd/MMM/yyyy"),
                                              InvoiceDate = ord.DateOfInvoice.ToString("dd/MMM/yyyy"),
                                              SuppplierName = ord.Vendor.Name,
                                              ord.TotalPurchasePrice,
                                              ord.TotalWholesalePrice,
                                              ord.TotalResalePrice,
                                              RevisionID = ord.Revision.ID
                                          }).ToList();

                dgvRegister.Columns["ID"].Visible = false;
                dgvRegister.Columns["RevisionID"].Visible = false;
                dgvItemRegister.DataSource = null;
                UpdateStatus(orderList.Count + " Results Found", 100);
            }
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int _ordID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            itemlist = ReportsBuilder.GetOrderList(_ordID);
            dgvItemRegister.DataSource = (from itm in itemlist
                                          select new
                                          {
                                              //itm.Purchase.SCFNo,
                                              Particulars = itm.Item.Name,
                                              itm.Item.Brand,
                                              //PackageType = itm.Package.Name,
                                              itm.PackageQuantity,
                                              itm.QuantityPerPack,
                                              itm.VATPercent,
                                              VAT_Amount = itm.VAT,
                                              itm.PurchaseValue,
                                              TotalPurchase = itm.TotalPurchaseValue,
                                              itm.Wholesale,
                                              TotalWholesale = itm.TotalWholesaleValue,
                                              itm.Retail,
                                              TotalResale = itm.TotalResaleValue
                                          }).ToList();

            /*Vat Statement*/
            dgvVATDetails.Rows.Clear();
            dgvVATDetails.Columns.Clear();

            //get all the percentages for a particular revision
            int revisionID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["RevisionID"].Value.ToString());
            List<decimal> vatPercentList = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);

            PurchaseOrder order = orderList[e.RowIndex];

            //create dictionary for each percentage with sum of all percenatage
            Dictionary<decimal, decimal> vatPercentageSum = new Dictionary<decimal, decimal>();
            foreach (decimal percent in vatPercentList)
            {
                if (percent == 0) continue;
                decimal sumVATPercent = itemlist.Where(i => i.VATPercent == percent).Select(i => i.VAT).Sum();
                vatPercentageSum.Add(percent, sumVATPercent);
            }

            var rdOffList = new List<decimal>();
            foreach (var item in itemlist)
            {
                rdOffList.Add(item.VAT - (item.Basic * (item.VATPercent / 100)));
            }

            //create dictionary for each percentage with sum of all basic
            Dictionary<decimal, decimal> vatPurchaseSum = new Dictionary<decimal, decimal>();
            foreach (decimal percent in vatPercentList)
            {
                decimal sumVATPercent = itemlist.Where(i => i.VATPercent == percent).Select(i => i.PurchaseValue).Sum();
                vatPurchaseSum.Add(percent, sumVATPercent);
            }

            LoadDGVAddColumns(vatPercentList);
            LoadDGVAddValues(order, vatPercentageSum, vatPurchaseSum, rdOffList);
        }

        private void LoadDGVAddColumns(List<decimal> vatPercentList)
        {
            foreach (var percent in vatPercentList)
            {
                if (percent == 0) continue;
                dgvVATDetails.Columns.Add("col" + percent + "%", percent + "%");
            }

            foreach (var percent in vatPercentList)
            {
                if (percent == 0)
                {
                    dgvVATDetails.Columns.Add("colExempted", "Excempted");
                    continue;
                }
                dgvVATDetails.Columns.Add("col" + percent + "Value", percent + "%_Amount");
            }

            dgvVATDetails.Columns["colExempted"].DisplayIndex = dgvVATDetails.Columns.Count - 1;
            dgvVATDetails.Columns.Add("colPosRodOff", "+");
            dgvVATDetails.Columns.Add("colNegRodOff", "-");
            dgvVATDetails.Columns.Add("colTotalAmount", "TotalAmount");
        }

        private void LoadDGVAddValues(PurchaseOrder order, Dictionary<decimal, decimal> vatPercentageSum, Dictionary<decimal, decimal> vatBasicSum, List<decimal> rdOffList)
        {
            dgvVATDetails.Rows.Add();
            foreach (var item in vatPercentageSum)
            {
                dgvVATDetails.Rows[0].Cells["col" + item.Key + "%"].Value = item.Value;
            }
            foreach (var item in vatBasicSum)
            {
                if (item.Key == 0)
                {
                    dgvVATDetails.Rows[0].Cells["colExempted"].Value = item.Value;
                    continue;
                }
                dgvVATDetails.Rows[0].Cells["col" + item.Key + "Value"].Value = item.Value;
            }

            dgvVATDetails.Rows[0].Cells["colPosRodOff"].Value = rdOffList.Where(i => i > 0).Sum().ToString("#.##");
            dgvVATDetails.Rows[0].Cells["colNegRodOff"].Value = rdOffList.Where(i => i < 0).Sum().ToString("#.##");
            dgvVATDetails.Rows[0].Cells["colTotalAmount"].Value = order.TotalPurchasePrice;
        }
    }
}
