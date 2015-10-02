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
    public partial class WinForm_MemberRegister : WinformRegister
    {
        public WinForm_MemberRegister()
        {
            InitializeComponent();
        }

        private void WinForm_MemberRegister_Load(object sender, EventArgs e)
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
                DialogResult _dialogResult = MessageBox.Show("Do you want to Add Member " +
                                           Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells["Name"].Value),
                                           "Add Member Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button2);
                int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                Person _member = PeoplePracticeBuilder.GetMemberInfo(_ID);
                saleDetail.UpdateCustomerControls(_member);
                this.Close();
            }
            else
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Member " +
                                             Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells["Name"].Value),
                                             "Modify Member Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                             MessageBoxDefaultButton.Button2);

                if (_dialogResult == DialogResult.No) return;

                int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                Member _member = PeoplePracticeBuilder.GetMemberInfo(_ID);
                new Winform_MemberDetails(_member).ShowDialog();

                txtName_TextChanged(this, new EventArgs());
            }
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvRegister.Columns["colDelete"].Index == e.ColumnIndex)
            {
                int memtID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                DialogResult dr = MessageBox.Show("Do you want to delete Member " + memtID, "Delete Member", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool success = Savers.PeoplePracticeSaver.DeleteMember(memtID);

                if (success)
                {
                    txtName_TextChanged(this, new EventArgs());
                    UpdateStatus("Member Deleted.", 100);

                }
                else
                {
                    UpdateStatus("Error deleting Member. ", 100);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvRegister.DataSource = null;
            dgvRegister.Columns["colDelete"].Visible = false;

            if (string.IsNullOrEmpty(txtMemNo.Text) && string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text))
                return;

            UpdateStatus("Searching", 50);

            List<Member> membList = new List<Member>();
            membList = PeoplePracticeBuilder.GetMemberList(txtName.Text, txtMobNo.Text, txtMemNo.Text);

            if (membList != null && membList.Count != 0)
            {
                dgvRegister.DataSource = (from memb in membList
                                          select new
                                          {
                                              memb.ID,
                                              memb.Name,
                                              MobileNo = memb.Mobile_No,
                                              memb.MemberNo
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
