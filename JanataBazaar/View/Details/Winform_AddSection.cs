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
    public partial class Winform_AddSection : Winform_Details
    {
        public Winform_AddSection()
        {
            InitializeComponent();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            UpdateStatus("Saving", 25);
            string errorMsg = "";
            if (string.IsNullOrEmpty(txtSectionName.Text))
            {
                errorMsg = "Section Name is Mandatory and Cannot be Empty.";
            }
            else
            {
                Match _match = Regex.Match(txtSectionName.Text, "^[a-zA-Z\\s]+$");
                errorMsg = _match.Success ? "" : "Invalid Input for Name\n" +
                                                 "For example 'ABCabc'";
            }

            if (errorMsg == "" && Builders.ItemDetailsBuilder.SectionExists(txtSectionName.Text))
            {
                errorMsg = "Section Name is a Duplicate as it already Exists.";
            }

            errorProvider1.SetError(txtSectionName, errorMsg);
            if (errorMsg != "")
            {
                txtSectionName.Select(0, txtSectionName.TextLength);
                UpdateStatus();
                return;
            }
            UpdateStatus("Saving", 50);

            if (Savers.ItemDetailsSavers.SaveSection(new Models.Section(Utilities.Validation.ToTitleCase(txtSectionName.Text))) == 0)
            {
                UpdateStatus("Error Saving Section", 100);
            }

            UpdateStatus("Section Saved", 100);
            this.Close();
        }
    }
}
