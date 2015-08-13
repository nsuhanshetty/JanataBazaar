using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winfrom_ItemDetails : Winform_Details
    {
        Item item;
        public Winfrom_ItemDetails()
        {
            InitializeComponent();
        }

        public Winfrom_ItemDetails(Item _item)
        {
            InitializeComponent();

            this.item = _item;
            txtName.Text = item.Name;
            cmbSection.SelectedIndex = item.Section.ID;
            cmbUnit.Text = item.QuantityUnit;
        }

        private void Winfrom_ItemDetails_Load(object sender, EventArgs e)
        {
            List<Section> sectList = Builders.ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";

            List<string> unitList = Builders.ItemDetailsBuilder.GetUnitList();
            cmbUnit.DataSource = unitList;
        }

        //private void txtName_Validating(object sender, CancelEventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    Match _match = Regex.Match(txt.Text, "^[a-zA-Z\\s]+$");
        //    string errorMsg = _match.Success ? "" : "Invalid Input\n" +
        //                                            "For example 'ABCabc'";
        //    errorProvider1.SetError(txt, errorMsg);

        //    if (errorMsg != "")
        //    {
        //        e.Cancel = true;
        //        txt.Select(0, txt.TextLength);
        //    }
        //}

        //private void cmbUnit_Validating(object sender, CancelEventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;
        //    Match _match = Regex.Match(cmb.Text, "^[a-zA-Z\\s]+$");
        //    string errorMsg = _match.Success ? "" : "Invalid Input\n" +
        //                                            "For example 'ABCabc'";
        //    errorProvider1.SetError(cmb, errorMsg);

        //    if (errorMsg != "")
        //    {
        //        e.Cancel = true;
        //        cmb.Select(0, cmb.Text.Length);
        //    }
        //}

        //private void txtName_Validated(object sender, EventArgs e)
        //{
        //    var control = (Control)sender;
        //    control.Text = Utilities.Validation.ToTitleCase(control.Text);
        //}

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            UpdateStatus("Saving", 25);
            if (Builders.ItemDetailsBuilder.ItemExists(txtName.Text, cmbUnit.Text, cmbSection.Text))
            {
                errorProvider1.SetError(txtName, "Item is a Duplicate as it already exists");
                txtName.Select(0, txtName.TextLength);
                UpdateStatus("Error in Saving Item", 100);
                return;
            }

            UpdateStatus("Saving", 50);
            if (Utilities.Validation.IsNullOrEmpty(this, false)) return;

            Section sect = Builders.ItemDetailsBuilder.GetSection(cmbSection.Text);
            item = new Item(txtName.Text, cmbUnit.Text, sect);

            if (Savers.ItemDetailsSavers.SaveItem(item) == 0)
            {
                UpdateStatus("Error in Saving Item", 100);
                return;
            }

            UpdateStatus("Item Saved", 100);
            this.Close();
        }

    }
}
