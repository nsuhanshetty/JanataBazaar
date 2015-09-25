using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winform_SaleItemDetails : Winform_Details
    {
        int index=0;
        SaleItem saleItem;

        public Winform_SaleItemDetails()
        {
            InitializeComponent();
        }

        public Winform_SaleItemDetails(SaleItem _saleItem, int index)
        {
            InitializeComponent();

            this.index = index;
            saleItem = _saleItem;

            txtBrand.Text = _saleItem.Item.Brand;
            txtCommodity.Text = _saleItem.Item.Name;

            txtPrice.Text = _saleItem.Price.ToString();
            txtTotalPrice.Text = _saleItem.TotalPrice.ToString();

            nudQuantity.Maximum = _saleItem.StockCount;
            nudQuantity.Value = _saleItem.Quantity;
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            txtTotalPrice.Text = (decimal.Parse(nudQuantity.Value.ToString()) * decimal.Parse(txtPrice.Text)).ToString();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            saleItem.Quantity = int.Parse(nudQuantity.Value.ToString());
            saleItem.TotalPrice = decimal.Parse(txtTotalPrice.Text);

            Winform_SaleDetails saleDetails = Application.OpenForms["Winform_SaleDetails"] as Winform_SaleDetails;
            if (saleDetails != null)
                saleDetails.UpdateSaleItemList(saleItem, index);

            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
