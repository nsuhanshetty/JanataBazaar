using JanataBazaar.Builders;
using JanataBazaar.Models;
using JanataBazaar.View.Details;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class Winform_ItemRegistry : WinformRegister
    {
        public Winform_ItemRegistry()
        {
            InitializeComponent();
        }

        private void Winform_AddItemRegistry_Load(object sender, EventArgs e)
        {
            List<string> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";

            cmbSection.Text = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //todo : Enable textchange to combobox also.
            LoadRegisterDgv();
        }

        public void LoadRegisterDgv()
        {
            //todo: find reason for "JanataBazaar.Models.Section" in cmb
            if (cmbSection.Text == "JanataBazaar.Models.Section" ||
                (String.IsNullOrEmpty(txtName.Text) && String.IsNullOrEmpty(txtBrand.Text)))
            {
                dgvRegister.DataSource = "";
                return;
            }

            UpdateStatus("Searching", 50);
            dgvRegister.DataSource = (ItemDetailsBuilder.GetItemsList(txtName.Text, cmbSection.Text, txtBrand.Text));

            if (dgvRegister.RowCount == 0)
            {
                dgvRegister.Columns["colDelete"].Visible = false;
                UpdateStatus("No Results found.", 100);
            }
            else
            {
                Winform_ItemSKUDetails itemDetail = Application.OpenForms["Winform_ItemSKUDetails"] as Winform_ItemSKUDetails;
                if (itemDetail == null)
                {
                    dgvRegister.Columns["colDelete"].Visible = true;
                    dgvRegister.Columns["colDelete"].DisplayIndex = dgvRegister.Columns.Count - 1;
                }
                UpdateStatus(dgvRegister.RowCount + " Results found.", 100);
            }
        }

        protected override void NewToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_ItemDetails().ShowDialog();
            txtName_TextChanged(this, new EventArgs());
        }

        protected override void dgvRegister_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Winform_ItemRegistry));
            log.Error(e.Context);
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            Item _item = new Item();
            var ID = dgvRegister.Rows[e.RowIndex].Cells["ID"].Value;
            _item = ItemDetailsBuilder.GetItemInfo(int.Parse(ID.ToString()));

            Winform_ItemSKUDetails itemDetail = Application.OpenForms["Winform_ItemSKUDetails"] as Winform_ItemSKUDetails;
            if (itemDetail != null)
            {
                itemDetail.UpdateItemDetailControls(_item);
                this.Close();
            }
            else if (dgvRegister.Columns["colDelete"].Index == e.ColumnIndex)
            {
                var row = dgvRegister.Rows[e.RowIndex];
                int itemID = int.Parse(row.Cells["ID"].Value.ToString());
                DialogResult dr = MessageBox.Show("Do you want to delete Item " + row.Cells["Name"].Value.ToString(), "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool isBilled = Savers.ItemDetailsSavers.IsItemBilled(itemID);
                if (isBilled)
                {
                    MessageBox.Show("Item is already billed and cannot be deleted","Cannot delete Item",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }

                bool success = Savers.ItemDetailsSavers.DeleteItem(itemID);
                if (success)
                {
                    txtName_TextChanged(this, new EventArgs());
                    UpdateStatus("Item Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Item. ", 100);
                }
            }
            else
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Item " +
                                         Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells["Name"].Value),
                                         "Modify Item Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

                if (_dialogResult == DialogResult.No) return;

                new Winform_ItemDetails(_item).ShowDialog();
                txtName_TextChanged(this, new EventArgs());
            }
        }
    }
}
