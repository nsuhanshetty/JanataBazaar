using JanataBazaar.Builders;
using JanataBazaar.Model;
using JanataBazaar.View.Details;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class WinForm_CustomerRegister : WinformRegister
    {
        public WinForm_CustomerRegister()
        {
            InitializeComponent();
        }

        private void WinForm_CustomerRegister_Load(object sender, EventArgs e)
        {
            txtName_TextChanged(this, new EventArgs());
        }

        #region Events
        protected override void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            Winform_SaleDetails saleDetail = Application.OpenForms["Winform_SaleDetails"] as Winform_SaleDetails;
            if (saleDetail != null)
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to Add Customer " +
                                           Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells["Name"].Value),
                                           "Add Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button2);
                int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                Person _customer = PeoplePracticeBuilder.GetCustomerInfo(_ID);
                saleDetail.UpdateCustomerControls(_customer);
                this.Close();
            }
            else
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Customer " +
                                         Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells["Name"].Value),
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

                if (_dialogResult == DialogResult.No) return;

                int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                Customer _customer = PeoplePracticeBuilder.GetCustomerInfo(_ID);
                new Winform_CustomerDetails(_customer).ShowDialog();

                txtName_TextChanged(this, new EventArgs());
            }
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvRegister.Columns["colDelete"].Index == e.ColumnIndex)
            {
                var row = dgvRegister.Rows[e.RowIndex];
                int custID = int.Parse(row.Cells["ID"].Value.ToString());
                DialogResult dr = MessageBox.Show("Do you want to delete Customer " + row.Cells["Name"].Value.ToString(), "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool success = Savers.PeoplePracticeSaver.DeleteCustomer(custID);

                if (success)
                {
                    txtName_TextChanged(this, new EventArgs());
                    UpdateStatus("Customer Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Customer. ", 100);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvRegister.DataSource = null;
            dgvRegister.Columns["colDelete"].Visible = false;

            if (string.IsNullOrEmpty(txtAccNo.Text) && string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text))
                return;

            UpdateStatus("Searching", 50);

            List<Customer> custList = new List<Customer>();
            custList = PeoplePracticeBuilder.GetCustomerList(txtName.Text, txtMobNo.Text, txtAccNo.Text);

            if (custList != null && custList.Count != 0)
            {
                dgvRegister.DataSource = (from cust in custList
                                          select new
                                          {
                                              cust.ID,
                                              cust.Name,
                                              cust.Mobile_No,
                                              cust.AccountNo
                                          }).ToList();

                dgvRegister.Columns["ID"].Visible = false;
                dgvRegister.Columns["colDelete"].Visible = true;
                dgvRegister.Columns["colDelete"].DisplayIndex = dgvRegister.Columns.Count - 1;
            }

            UpdateStatus((dgvRegister.RowCount == 0) ? "No Results Found" : dgvRegister.RowCount + " Results Found", 100);
        }
        #endregion Events
    }
}
