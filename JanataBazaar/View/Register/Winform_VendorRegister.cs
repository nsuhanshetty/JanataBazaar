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
            if (dgvRegister.Columns["colDelete"].Index == e.ColumnIndex)
            {
                var row = dgvRegister.Rows[e.RowIndex];
                int _vendID = int.Parse(row.Cells["ID"].Value.ToString());
                DialogResult dr = MessageBox.Show("Do you want to delete Vendor " + row.Cells["Name"].Value.ToString(), "Delete Vendor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool isBilled = Savers.PeoplePracticeSaver.IsVendorBilled(_vendID);
                if (isBilled)
                {
                    MessageBox.Show("Vendor is already billed and cannot be deleted", "Cannot delete Vendor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                bool success = Savers.PeoplePracticeSaver.DeleteVendor(_vendID);
                if (success)
                {
                    txtName_TextChanged(this, new EventArgs());
                    UpdateStatus("Vendor Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Vendor. ", 100);
                }
            }
            else
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
            {
                dgvRegister.Columns["colDelete"].Visible = false;
                UpdateStatus("No Results found.", 100);
            }
            else
            {
                UpdateStatus(dgvRegister.RowCount + " Results found.", 100);
                dgvRegister.Columns["colDelete"].Visible = true;
                dgvRegister.Columns["colDelete"].DisplayIndex = dgvRegister.Columns.Count - 1;
            }
        }
    }
}
