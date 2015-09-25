using JanataBazaar.Builders;
using JanataBazaar.Models;
using System;
using System.Collections;
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
    public partial class Winform_SCFRegister : WinformRegister
    {
        List<ItemSKU> itemlist;
        public Winform_SCFRegister()
        {
            InitializeComponent();
        }

        private void Winform_SCFRegister_Load(object sender, EventArgs e)
        {
            List<Section> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSection.DataSource = sectList;
            cmbSection.DisplayMember = "Name";
            cmbSection.ValueMember = "ID";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtBrand.Text))
            {
                dgvRegister.DataSource = "";
                return;
            }

            itemlist = (ReportsBuilder.GetSCFReport(txtName.Text, txtBrand.Text, cmbSection.Text));
            dgvRegister.DataSource = (from itm in itemlist
                                      select new
                                      {
                                          itm.Item.Name,
                                          itm.Item.Brand,
                                          PackageType = itm.Package.Name,
                                          itm.PackageQuantity,
                                          itm.QuantityPerPack,
                                          itm.PurchaseValue,
                                          TotalPurchase = itm.TotalPurchaseValue,
                                          itm.Wholesale,
                                          TotalWholesale = itm.TotalWholesaleValue,
                                          itm.Retail,
                                          TotalResale = itm.TotalResaleValue
                                      }).ToList();

            if (itemlist == null)
                UpdateStatus("No Results Found");
            else
                UpdateStatus(itemlist.Count + " Results Found", 100);
        }

        protected override void toolStripButtonPrint_Click(object sender, System.EventArgs e)
        {
            new Reports.Report_SCF(itemlist).ShowDialog();
        }
    }
}
