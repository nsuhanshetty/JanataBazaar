using JanataBazaar.Builders;
using JanataBazaar.Model;
using JanataBazaar.Models;
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
    public partial class Winform_AddCustomer : WinformRegister
    {
        public Winform_AddCustomer()
        {
            InitializeComponent();
        }

        protected override void NewToolStrip_Click(object sender, EventArgs e)
        {
            new Details.Winform_CustomerDetails().ShowDialog();
        }

        private void txtName_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text))
            {
                dgvRegister.DataSource = null;
                return;
            }
            UpdateStatus("Searching", 50);
            LoadRegisterDgv();
        }

        public void LoadRegisterDgv()
        {
            dgvRegister.DataSource = (from cust in (PeoplePracticeBuilder.GetCustomerList(txtName.Text, txtMobNo.Text))
                                      select new { cust.ID, cust.Name, cust.Mobile_No }).ToList();
            if (dgvRegister.RowCount == 0)
                UpdateStatus("No Results found.", 100);
            else
                UpdateStatus(dgvRegister.RowCount + " Results found.", 100);
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Do you want to Add Customer " +
                                         Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells["Name"].Value),
                                         "Add Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            Customer _cust = new Customer();
            var ID = dgvRegister.Rows[e.RowIndex].Cells["ID"].Value;
            _cust = PeoplePracticeBuilder.GetCustomerInfo(int.Parse(ID.ToString()));

            Winform_SaleDetails saleDetail = Application.OpenForms["Winform_SaleDetails"] as Winform_SaleDetails;
            if (saleDetail != null)
                saleDetail.UpdateCustomerControls(_cust);

            this.Close();
        }
    }
}
