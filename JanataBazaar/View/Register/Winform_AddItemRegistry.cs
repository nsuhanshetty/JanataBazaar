using JanataBazaar.Builders;
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
    public partial class Winform_AddItemRegistry : WinformRegister
    {
        public Winform_AddItemRegistry()
        {
            InitializeComponent();
        }

        private void Winform_AddItemRegistry_Load(object sender, EventArgs e)
        {
            List<Section> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //todo : Enable textchange to combobox also.
            UpdateStatus("Searching", 50);
            LoadRegisterDgv();
        }

        public void LoadRegisterDgv()
        {
            if (cmbSection.Text == "JanataBazaar.Models.Section") return;

            dgvRegister.DataSource = (from item in (ItemDetailsBuilder.GetItemsList(txtName.Text, cmbSection.Text))
                                      select new { item.ID, item.Name, item.QuantityUnit }).ToList();
            if (dgvRegister.RowCount == 0)
                UpdateStatus("No Results found.", 100);
            else
                UpdateStatus(dgvRegister.RowCount + " Results found.", 100);
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Details.Winfrom_ItemDetails().ShowDialog();
            txtName_TextChanged(this, new EventArgs());
        }

        protected override void dgvRegister_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Winform_AddItemRegistry));
            log.Error(e.Context);
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
