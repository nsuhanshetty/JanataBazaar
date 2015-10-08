using JanataBazaar.View.Details;
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
    public partial class Winform_SalesSummary : WinformRegister
    {
        public Winform_SalesSummary()
        {
            InitializeComponent();
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
            int.TryParse(nudDuration.Value.ToString(),out duration);
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
                fromDate = DateTime.Today.Date.AddMonths(- duration);
            }
            else if (cmbDuration.Text == "Week")
            {
                toDate = DateTime.Today.Date;
                fromDate = DateTime.Today.Date.AddDays(-7 * duration);
            }
            else if (cmbDuration.Text == "Day")
            {
                toDate = DateTime.Today.Date;
                fromDate = DateTime.Today.Date.AddDays(- duration);
            }
            #endregion SetDuration

            //int _billNo;
            //int.TryParse(txtBillNo.Text, out _billNo);

            dgvRegister.Rows.Clear();
            var saleSummaryList = Builders.SaleItemBuilder.GetSalesSummary(isCredit, fromDate, toDate, txtName.Text, txtConsumeID.Text);
            if (saleSummaryList.Count != 0)
            {
                dgvRegister.Rows.Clear();
                foreach (var item in saleSummaryList)
                {
                    int index = saleSummaryList.IndexOf(item);
                    dgvRegister.Rows.Add();

                    dgvRegister.Rows[index].Cells["colSINo"].Value = index + 1;
                    dgvRegister.Rows[index].Cells["colSaleNo"].Value = item.ID;
                    dgvRegister.Rows[index].Cells["colsaleAmount"].Value = item.TotalAmount;
                    dgvRegister.Rows[index].Cells["colRebateAmount"].Value = 0;
                    dgvRegister.Rows[index].Cells["colGrossAmount"].Value = item.TotalAmount;
                    dgvRegister.Rows[index].Cells["colbillAge"].Value = DateTime.Compare(DateTime.Today.Date, item.DateOfSale.Date);
                }
            }
        }

        protected override void NewToolStrip_Click(object sender, System.EventArgs e)
        {
            new Winform_SaleDetails().ShowDialog();
            SearchToolStrip_Click(this, new System.EventArgs());
        }

        private void Winform_SalesSummary_Load(object sender, EventArgs e)
        {
            cmbDuration.SelectedIndex = 0;
            this.toolStrip1.Items.Add(this.SearchToolStrip);

            LoadDGV();
        }

        private void LoadDGV()
        {
            dgvRegister.Columns.Add("colSINo", "SI.NO");
            dgvRegister.Columns.Add("colSaleNo", "Bill.NO");
            dgvRegister.Columns.Add("colsaleAmount", "Sale Amount");
            dgvRegister.Columns.Add("colRebateAmount", "Rebate Amount");
            dgvRegister.Columns.Add("colGrossAmount", "Gross Amount");
            dgvRegister.Columns.Add("colbillAge", "Age Of Bill");
        }
    }
}
