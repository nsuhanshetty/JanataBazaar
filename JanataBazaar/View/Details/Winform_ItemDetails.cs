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
    public partial class Winform_ItemDetails : Winform_Details
    {
        Item item;
        public Winform_ItemDetails()
        {
            InitializeComponent();
        }

        public Winform_ItemDetails(Item _item)
        {
            InitializeComponent();

            this.item = _item;
            cmbName.Text = item.Name;
            cmbUnit.Text = item.QuantityUnit;
            cmbBrand.Text = item.Brand;
            txtReserve.Text = item.ReserveStock.ToString();
        }

        private void Winfrom_ItemDetails_Load(object sender, EventArgs e)
        {
            //todo : make the extraction faster
            this.toolStripParent.Items.Add(this.AddSectionToolStrip);

            AutoCompletionSource(Builders.ItemDetailsBuilder.GetNamesList(), cmbName);
            AutoCompletionSource(Builders.ItemDetailsBuilder.GetUnitList(), cmbUnit);

            List<string> sectList = Builders.ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";

            if (item != null)
            {
                cmbSection.SelectedIndex = sectList.IndexOf(item.Section.Name);//item.Section.ID;
            }
        }

        private void AutoCompletionSource(List<string> srcList, ComboBox cmb)
        {
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(srcList.ToArray());

            cmb.AutoCompleteCustomSource = autoCollection;
            cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AddSectionToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddSection().ShowDialog();

        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            ProcessTabKey(true);

            List<string> except = new List<string> { "cmbBrand" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, except))
                return;

            UpdateStatus("Saving", 25);
            if (Builders.ItemDetailsBuilder.ItemExists(cmbName.Text, cmbBrand.Text, cmbUnit.Text, cmbSection.Text) && item.ID == 0)
            {
                errorProvider1.SetError(cmbName, "Item is a Duplicate as it already exists");
                cmbName.Select(0, cmbName.Text.Length);
                UpdateStatus("Error in Saving Item", 100);
                return;
            }

            UpdateStatus("Saving..", 50);
            if (Utilities.Validation.IsNullOrEmpty(this, false)) return;

            Section sect = Builders.ItemDetailsBuilder.GetSection(cmbSection.Text);
            if (item ==null || item.ID == 0)
            item = new Item(cmbName.Text, cmbUnit.Text, sect, cmbBrand.Text, int.Parse(txtReserve.Text));
            else
            {
                item.Name = cmbName.Text;
                item.Brand = cmbBrand.Text;
                item.QuantityUnit = cmbUnit.Text;
                item.ReserveStock = string.IsNullOrEmpty(txtReserve.Text)? 0: int.Parse(txtReserve.Text);
            }

            if (Savers.ItemDetailsSavers.SaveItem(item) == 0)
            {
                UpdateStatus("Error in Saving Item", 100);
                return;
            }

            UpdateStatus("Item Saved.", 100);
            Close();
        }

        //private void chkIsExempted_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtVATPerc.Enabled = !chkIsExempted.Checked;

        //    if (txtVATPerc.Enabled)
        //        txtVATPerc.Validating += new CancelEventHandler(this.txtBox_Validating);
        //    else
        //        txtVATPerc.Validating += null;
        //}

        //private void cmbVATPerc_Validating(object sender, CancelEventArgs e)
        //{
        //    TextBox txtBox = (TextBox)sender;
        //    string _errorMsg;

        //    Match _match = Regex.Match(txtBox.Text, "^[0-9]*\\.?[0-9]*$");
        //    _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '2.2'" : "";

        //    errorProvider1.SetError(txtBox, _errorMsg);

        //    if (_errorMsg != "")
        //    {
        //        e.Cancel = true;
        //        txtBox.Select(0, txtBox.Text.Length);
        //    }
        //}

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            errorProvider1.SetError(ctrl, "");

            if (String.IsNullOrEmpty(ctrl.Text))
            {
                errorProvider1.SetError(ctrl, "Value cannot be null");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            cmbName.Text = Utilities.Validation.ToTitleCase(cmbName.Text.ToLower());
        }

        //todo:  Must be done during userbased tests.
    }
}
