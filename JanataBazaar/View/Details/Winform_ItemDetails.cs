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
            txtName.Text = item.Name;
            cmbSection.SelectedIndex = item.Section.ID;
            cmbUnit.Text = item.QuantityUnit;
        }

        private void Winfrom_ItemDetails_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddSectionToolStrip);

            List<Section> sectList = Builders.ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";

            List<string> unitList = Builders.ItemDetailsBuilder.GetUnitList();
            cmbUnit.DataSource = unitList;
        }

        private void AddSectionToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddSection().ShowDialog();

        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            ProcessTabKey(true);

            List<string> except = new List<string> { "cmbBrand" };
            if (chkIsExempted.Checked)
                except.Add("txtVATPerc");
            else
                except.Remove("txtVATPerc");

            if (Utilities.Validation.IsNullOrEmpty(this, true, except))
                return;

            UpdateStatus("Saving", 25);
            if (Builders.ItemDetailsBuilder.ItemExists(txtName.Text, cmbBrand.Text, cmbUnit.Text, cmbSection.Text))
            {
                errorProvider1.SetError(txtName, "Item is a Duplicate as it already exists");
                txtName.Select(0, txtName.TextLength);
                UpdateStatus("Error in Saving Item", 100);
                return;
            }

            UpdateStatus("Saving..", 50);
            if (Utilities.Validation.IsNullOrEmpty(this, false)) return;

            Section sect = Builders.ItemDetailsBuilder.GetSection(cmbSection.Text);

            float _vatPerc;
            if (!chkIsExempted.Checked && !IsNullOrEmpty(txtVATPerc.Text))
                float.TryParse(txtVATPerc.Text, out _vatPerc);
            else
                _vatPerc = 0;

            item = new Item(txtName.Text, cmbUnit.Text, sect, cmbBrand.Text, chkIsExempted.Checked, _vatPerc, int.Parse(txtReserve.Text));

            if (Savers.ItemDetailsSavers.SaveItem(item) == 0)
            {
                UpdateStatus("Error in Saving Item", 100);
                return;
            }

            UpdateStatus("Item Saved.", 100);
            this.Close();
        }

        private void chkIsExempted_CheckedChanged(object sender, EventArgs e)
        {
            txtVATPerc.Enabled = !chkIsExempted.Checked;

            if (txtVATPerc.Enabled)
                txtVATPerc.Validating += new CancelEventHandler(this.txtBox_Validating);
            else
                txtVATPerc.Validating += null;
        }

        private void cmbVATPerc_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            string _errorMsg;

            Match _match = Regex.Match(txtBox.Text, "^[0-9]*\\.?[0-9]*$");
            _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '2.2'" : "";

            errorProvider1.SetError(txtBox, _errorMsg);

            if (_errorMsg != "")
            {
                e.Cancel = true;
                txtBox.Select(0, txtBox.Text.Length);
            }
        }

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


        //todo: Check if BrandName, Name must be converted to uppercase. Must be done during userbased tests.
    }
}
