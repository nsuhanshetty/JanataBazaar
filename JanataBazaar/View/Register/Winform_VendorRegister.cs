using JanataBazaar.Builders;
using System;
using System.Linq;
using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class Winform_VendorRegister : WinformRegister
    {
        public Winform_VendorRegister()
        {
            InitializeComponent();
        }

        protected override void NewToolStrip_Click(object sender, EventArgs e)
        {
            new Details.Winform_VendorDetails().ShowDialog();
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Vendor " +
                                        Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells[1].Value),
                                        "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            Model.Vendor _vendor = PeoplePracticeBuilder.GetVendorInfo(_ID);

            new Details.Winform_VendorDetails(_vendor).ShowDialog();
            txtName_TextChanged(this, new EventArgs());
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtMobNo.Text == "") return;
            LoadDgv();
        }

        public void LoadDgv()
        {
            UpdateStatus("Searching", 50);
            dgvRegister.DataSource = (from vend in (PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text))
                                      select new { vend.ID, vend.Name, vend.MobileNo }).ToList();
            if (dgvRegister.RowCount == 0)
                UpdateStatus("No Results found.", 100);
            else
                UpdateStatus(dgvRegister.RowCount + " Results found.", 100);
        }
    }
}
