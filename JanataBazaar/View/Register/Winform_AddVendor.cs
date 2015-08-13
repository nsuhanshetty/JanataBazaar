using JanataBazaar.Builders;
using JanataBazaar.Model;
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
    public partial class Winform_AddVendor : WinformRegister
    {
        public Winform_AddVendor()
        {
            InitializeComponent();
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Details.Winform_VendorDetails().ShowDialog();
        }

        private void txtName_TextChanged(object sender, System.EventArgs e)
        {
            UpdateStatus("Searching", 50);
            LoadRegisterDgv();
        }

        public void LoadRegisterDgv()
        {
            dgvRegister.DataSource = (from vend in (PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text))
                                      select new { vend.ID, vend.Name, vend.MobileNo }).ToList();
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

            Vendor _vend = new Vendor();
            var ID = dgvRegister.Rows[e.RowIndex].Cells["ID"].Value;
            _vend = PeoplePracticeBuilder.GetVendorInfo(int.Parse(ID.ToString()));

            Winform_PurchaseBill purchaseBill = Application.OpenForms["Winform_PurchaseBill"] as Winform_PurchaseBill;
            if (purchaseBill != null)
                purchaseBill.UpdateVendorControls(_vend);

            this.Close();
        }
    }
}
