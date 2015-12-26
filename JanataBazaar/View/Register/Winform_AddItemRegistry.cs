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
    public partial class Winform_AddItemRegistry : WinformRegister
    {
        public Winform_AddItemRegistry()
        {
            InitializeComponent();
        }

        private void Winform_AddItemRegistry_Load(object sender, EventArgs e)
        {
            List<string> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            //cmbSection.ValueMember = "ID";

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
                UpdateStatus("No Results found.", 100);
            else
                UpdateStatus(dgvRegister.RowCount + " Results found.", 100);
        }

        protected override void NewToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_ItemDetails().ShowDialog();
            txtName_TextChanged(this, new EventArgs());
        }

        protected override void dgvRegister_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Winform_AddItemRegistry));
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
                itemDetail.UpdateItemDetailControls(_item);

            this.Close();
        }


    }
}
