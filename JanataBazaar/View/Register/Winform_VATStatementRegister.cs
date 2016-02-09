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
    public partial class Winform_VATStatementRegister : WinformRegister
    {
        List<PurchaseOrder> purchaseOrderList;
        int currRowIndex = -1;
        public Winform_VATStatementRegister()
        {
            InitializeComponent();
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

            dgvRegister.DataSource = null;
            purchaseOrderList = Builders.PurchaseBillBuilder.GetPurchaseOrderList(fromDate, toDate, isCredit);

            if (purchaseOrderList.Count != 0)
            {
                dgvRegister.DataSource = (from item in purchaseOrderList
                                          select new
                                          {
                                              SI_No = purchaseOrderList.IndexOf(item) + 1,
                                              //item.BillNo,
                                              BillDate = item.DateOfInvoice.Date.ToString("dd/MMM/yyyy"),
                                              SupplierName = item.Vendor.Name,
                                              item.SCFNo,
                                              TotalAmount = item.TotalPurchasePrice,
                                              item.Vendor.TIN,
                                              RevisionID = item.Revision.ID
                                          }).ToList();

                dgvRegister.Columns["RevisionID"].Visible = false;
            }
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || currRowIndex == e.RowIndex) return;

            currRowIndex = e.RowIndex;

            dgvVATDetails.Rows.Clear();
            dgvVATDetails.Columns.Clear();

            //get all the percentages for a particular revision
            int revisionID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["RevisionID"].Value.ToString());
            List<decimal> vatPercentList = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);

            PurchaseOrder order = purchaseOrderList[e.RowIndex];

            //create dictionary for each percentage with sum of all percenatage
            Dictionary<decimal, decimal> vatPercentageSum = new Dictionary<decimal, decimal>();
            foreach (decimal percent in vatPercentList)
            {
                if (percent == 0) continue;
                decimal sumVATPercent = order.ItemPriceList.Where(i => i.VATPercent == percent).Select(i => i.VAT).Sum();
                vatPercentageSum.Add(percent, sumVATPercent);
            }

            var rdOffList = new List<decimal>();
            foreach (var item in order.ItemPriceList)
            {
                rdOffList.Add(item.VAT - (item.Basic * (item.VATPercent / 100)));
            }

            //create dictionary for each percentage with sum of all basic
            Dictionary<decimal, decimal> vatPurchaseSum = new Dictionary<decimal, decimal>();
            foreach (decimal percent in vatPercentList)
            {
                decimal sumVATPercent = order.ItemPriceList.Where(i => i.VATPercent == percent).Select(i => i.PurchaseValue).Sum();
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

            //decimal totalPurchaseValue = 0;
            //foreach (var item in order.ItemPriceList)
            //{
            //    var _basic = item.Basic;
            //    totalPurchaseValue += (_basic * item.TransportPercent) + (_basic * item.MiscPercent) + (_basic * item.VATPercent) - (_basic * item.DiscountPercent);
            //}

            dgvVATDetails.Rows[0].Cells["colPosRodOff"].Value = rdOffList.Where(i => i > 0).Sum().ToString("#.##");
            dgvVATDetails.Rows[0].Cells["colNegRodOff"].Value = rdOffList.Where(i => i < 0).Sum().ToString("#.##");
            dgvVATDetails.Rows[0].Cells["colTotalAmount"].Value = order.TotalPurchasePrice;
        }

        private void Winform_VATStatementRegister_Load(object sender, EventArgs e)
        {
            cmbDuration.SelectedIndex = 0;
            this.toolStrip1.Items.Add(SearchToolStrip);
        }

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isActive = (cmbDuration.Text == "Custom") ? true : false;

            dtpTo.Enabled = isActive;
            dtpFrom.Enabled = isActive;

            nudDuration.Enabled = !isActive;
        }
    }
}
