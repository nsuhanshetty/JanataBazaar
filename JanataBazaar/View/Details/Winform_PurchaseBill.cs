
using JanataBazaar.Views.Details;
using System;

namespace JanataBazaar.View.Details
{
    public partial class Winform_PurchaseBill : Winform_Details
    {
        public Winform_PurchaseBill()
        {
            InitializeComponent();
        }

        private void Winform_PurchaseBill_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddItemToolStrip);
            this.toolStripParent.Items.Add(this.AddVendorToolStrip);
        }

        private void AddVendorToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails().ShowDialog();
        }

        private void AddItemToolStrip_Click(object sender, EventArgs e)
        {
           // new Winform_VendorDetails().ShowDialog();
        }
    }
}
