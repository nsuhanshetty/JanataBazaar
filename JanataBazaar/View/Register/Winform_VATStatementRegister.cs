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
        int currRowIndex=-1;
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
                                              SI_No = purchaseOrderList.IndexOf(item)+1,
                                              item.BillNo,
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
            dgvVATDetails.Rows.Clear();

            //get all the percentages for a particular revision
            int revisionID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["RevisionID"].Value.ToString());
            List<decimal> vatPercentList = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);

            PurchaseOrder order = purchaseOrderList[e.RowIndex];

            //create dictionary for each percentage with sum of all percenatage
            Dictionary<decimal, decimal> vatPercentageSum = new Dictionary<decimal, decimal>();
            foreach (decimal percent in vatPercentList)
            {
                decimal sumVATPercent = order.ItemPriceList.Where(i => i.VATPercent == percent).Select(i => i.VAT).Sum();
                vatPercentageSum.Add(percent, sumVATPercent);
            }

            //create dictionary for each percentage with sum of all basic
            Dictionary<decimal, decimal> vatBasicSum = new Dictionary<decimal, decimal>();
            foreach (decimal percent in vatPercentList)
            {
                decimal sumVATPercent = order.ItemPriceList.Where(i => i.VATPercent == percent).Select(i => i.Basic).Sum();
                vatBasicSum.Add(percent, sumVATPercent);
            }

            LoadDGVColumns(vatPercentList);
            LoadDGVValues(order, vatPercentageSum, vatBasicSum);
        }

        private void LoadDGVColumns(List<decimal> vatPercentList)
        {
            foreach (var percent in vatPercentList)
                dgvVATDetails.Columns.Add("col" + percent + "%", percent + "%");

            foreach (var percent in vatPercentList)
                dgvVATDetails.Columns.Add("col" + percent + "Value", percent + "%_Amount");

            dgvVATDetails.Columns.Add("colPosRodOff", "+");
            dgvVATDetails.Columns.Add("colNegRodOff", "-");

            dgvVATDetails.Columns.Add("colTotalAmount", "TotalAmount");
        }

        private void LoadDGVValues(PurchaseOrder order, Dictionary<decimal, decimal> vatPercentageSum, Dictionary<decimal, decimal> vatBasicSum)
        {
            dgvVATDetails.Rows.Add();
            foreach (var item in vatPercentageSum)
            {
                dgvVATDetails.Rows[0].Cells["col" + item.Key + "%"].Value = item.Value;
            }
            foreach (var item in vatBasicSum)
            {
                dgvVATDetails.Rows[0].Cells["col" + item.Key + "Value"].Value = item.Value;
            }
            dgvVATDetails.Rows[0].Cells["colPosRodOff"].Value = 0;
            dgvVATDetails.Rows[0].Cells["colNegRodOff"].Value = 0;
            dgvVATDetails.Rows[0].Cells["colTotalAmount"].Value = order.TotalPurchasePrice;
        }

        private void Winform_VATStatementRegister_Load(object sender, EventArgs e)
        {
            cmbDuration.SelectedIndex = 0;
            this.toolStrip1.Items.Add(SearchToolStrip);
        }
    }
}
