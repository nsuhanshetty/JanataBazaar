using JanataBazaar.Model;
using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JanataBazaar.View.Details
{
    public partial class Winform_PurchaseBill : Winform_Details
    {
        Vendor vend = new Vendor();
        List<ItemPricing> ItemPriceList = new List<ItemPricing>();
        PurchaseOrder purchaseOrder = new PurchaseOrder();
        int RevisionID;

        public Winform_PurchaseBill()
        {
            InitializeComponent();
        }

        private void Winform_PurchaseBill_Load(object sender, EventArgs e)
        {
            //get the revision date based on Invoice date
            RevisionID = Builders.VATRevisionBuilder.GetRevisionDate(dtpInvoiceDate.Value.Date);
            this.toolStripParent.Items.Add(this.AddVendorToolStrip);
        }

        public void UpdateVendorControls(Vendor _vend)
        {
            this.vend = _vend;
            txtVendorName.Text = _vend.Name;
            errorProvider1.SetError(txtVendorName, "");
        }

        private void AddVendorToolStrip_Click(object sender, EventArgs e)
        {
            new Register.Winform_AddVendor().ShowDialog();
        }

        private void AddPackageToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_PackageDetails().ShowDialog();
        }

        private void dgvDetails_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvProdDetails.Columns["ColProduct"].Index == e.ColumnIndex)
            {
                if (e.RowIndex < ItemPriceList.Count)
                {
                    new Winform_ItemSKUDetails(e.RowIndex, RevisionID,ItemPriceList[e.RowIndex]).ShowDialog();
                }
                else
                {
                    new Winform_ItemSKUDetails(e.RowIndex, RevisionID).ShowDialog();
                }
            }
            else if (dgvProdDetails.Columns["ColDel"].Index == e.ColumnIndex)
            {
                if (dgvProdDetails.Rows[e.RowIndex].IsNewRow) return;
                else
                    ItemPriceList.RemoveAt(e.RowIndex);
            }
        }

        internal void UpdateSKUItemList(int index, ItemPricing _itemsku)
        {
            if (ItemPriceList.Count == 0 || ItemPriceList.Count <= index)
                ItemPriceList.Add(_itemsku);
            else
                ItemPriceList[index] = _itemsku;

            var _row = dgvProdDetails.Rows[index];
            _row.Cells["ColProduct"].Value = _itemsku.Item.Name;
            _row.Cells["ColPurchaseValue"].Value = _itemsku.PurchaseValue;
            _row.Cells["ColWholesaleValue"].Value = _itemsku.Wholesale;
            _row.Cells["ColResaleVal"].Value = _itemsku.Retail;
            _row.Cells["colItemUnit"].Value = _itemsku.Item.QuantityUnit;

            if (_itemsku.Package != null)
                _row.Cells["ColPackageType"].Value = _itemsku.Package.Name;
            _row.Cells["ColPackQuantity"].Value = _itemsku.PackageQuantity;
            _row.Cells["colItemPerPack"].Value = _itemsku.QuantityPerPack;

            _itemsku.TotalPurchaseValue = (_itemsku.PackageQuantity * (_itemsku.QuantityPerPack * _itemsku.PurchaseValue));
            _itemsku.TotalWholesaleValue = (_itemsku.PackageQuantity * (_itemsku.QuantityPerPack * _itemsku.Wholesale));
            _itemsku.TotalResaleValue = (_itemsku.PackageQuantity * (_itemsku.QuantityPerPack * _itemsku.Retail));

            _row.Cells["ColTotPurchaseVal"].Value = _itemsku.TotalPurchaseValue;
            _row.Cells["ColTotWholesaleVal"].Value = _itemsku.TotalWholesaleValue;
            _row.Cells["ColTotResaleVal"].Value = _itemsku.TotalResaleValue;

            //_itemsku.StockQuantity = _itemsku.PackageQuantity * _itemsku.QuantityPerPack;

            if (ItemPriceList.Count == 0 || ItemPriceList.Count <= index)
                ItemPriceList.Add(_itemsku);
            else
                ItemPriceList[index] = _itemsku;

            purchaseOrder.TotalPurchasePrice = 0;
            purchaseOrder.TotalWholesalePrice = 0;
            purchaseOrder.TotalResalePrice = 0;

            foreach (var item in ItemPriceList)
            {
                purchaseOrder.TotalPurchasePrice += item.TotalPurchaseValue;
                purchaseOrder.TotalWholesalePrice += item.TotalWholesaleValue;
                purchaseOrder.TotalResalePrice += item.TotalResaleValue;
            }

            txtTotalPurchasePrice.Text = purchaseOrder.TotalPurchasePrice.ToString();
            txtTotalWholesalePrice.Text = purchaseOrder.TotalWholesalePrice.ToString();
            txtTotalResalePrice.Text = purchaseOrder.TotalResalePrice.ToString();

            dgvProdDetails.NotifyCurrentCellDirty(true);
            dgvProdDetails.NotifyCurrentCellDirty(false);

        }

        //private void dgvDetails_RowLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvProdDetails.Rows[e.RowIndex].IsNewRow) return;

        //    if (IsNullOrEmpty(dgvProdDetails.Rows[e.RowIndex].Cells["colItemPerPack"].Value))
        //    {
        //        dgvProdDetails.Rows[e.RowIndex].Cells["colItemPerPack"].ErrorText = "Quantity Cannot be Empty";
        //        return;
        //    }

        //    //calculate total
        //    foreach (System.Windows.Forms.DataGridViewRow row in dgvProdDetails.Rows)
        //    {

        //    }
        //}

        //private void dgvDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (!ValidateQuantities(e)) return;

        //    if (skuList.Count > e.RowIndex)
        //    {
        //        var _itemSKU = skuList[e.RowIndex];
        //        var _row = dgvProdDetails.Rows[e.RowIndex];

        //        _row.Cells["ColPackQuantity"].Value = _itemSKU.PackageQuantity = GetCellValue(_row.Cells["ColPackQuantity"]);
        //        _row.Cells["colItemPerPack"].Value = _itemSKU.QuantityPerPack = GetCellValue(_row.Cells["colItemPerPack"]);

        //        _itemSKU.TotalPurchaseValue = (_itemSKU.PackageQuantity * (_itemSKU.QuantityPerPack * _itemSKU.PurchaseValue));
        //        _itemSKU.TotalWholesaleValue = (_itemSKU.PackageQuantity * (_itemSKU.QuantityPerPack * _itemSKU.Wholesale));
        //        _itemSKU.TotalResaleValue = (_itemSKU.PackageQuantity * (_itemSKU.QuantityPerPack * _itemSKU.Retail));

        //        _row.Cells["ColTotPurchaseVal"].Value = _itemSKU.TotalPurchaseValue;
        //        _row.Cells["ColTotWholesaleVal"].Value = _itemSKU.TotalWholesaleValue;
        //        _row.Cells["ColTotResaleVal"].Value = _itemSKU.TotalResaleValue;

        //        skuList[e.RowIndex] = _itemSKU;
        //    }

        //}

        private bool ValidateQuantities(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProdDetails.Columns["ColPackQuantity"].Index ||
                            e.ColumnIndex == dgvProdDetails.Columns["colItemPerPack"].Index)
            {
                string _errorMsg;
                var cell = dgvProdDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value == null)
                {
                    return false;
                }

                Match _match = Regex.Match(cell.Value.ToString(), "^[0-9]*\\.?[0-9]*$");
                _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";

                if (_errorMsg != "")
                {
                    cell.ErrorText = _errorMsg;
                    return false;
                }
                else
                    cell.ErrorText = "";
            }
            return true;
        }

        private int GetCellValue(DataGridViewCell cell)
        {
            var cellVal = cell.Value;
            if (IsNullOrEmpty(cellVal) || int.Parse(cellVal.ToString()) == 0)
                return 1;
            else
                return int.Parse(cellVal.ToString());
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            #region validate
            if (DateTime.Compare(dtpPurchaseDate.Value.Date, dtpInvoiceDate.Value.Date) > 0)
            {
                MessageBox.Show("Date of Purchase cannot be greater than Date of Invoice.", "Invalid Date Of Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(txtVendorName.Text))
            {
                errorProvider1.SetError(txtVendorName, "Supplier Details Is Mandatory");
                return;
            }
            else if (ItemPriceList == null || ItemPriceList.Count == 0)
            {
                MessageBox.Show("Add items to Purchase Grid.", "Purchase Grid Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Utilities.Validation.IsNullOrEmpty(this, true))
                return;
            #endregion validate

            DialogResult dr = MessageBox.Show("Purchase Order once placed cannot be altered. Do you want to Continue?","Save Purchase Order",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
                return;

            purchaseOrder.IsCredit = rdbCredit.Checked ? true : false;
            purchaseOrder.SCFNo = txtSCF.Text;
            purchaseOrder.IRNNo = txtInvoiceNo.Text;
            purchaseOrder.BillNo = txtBillNo.Text;
            purchaseOrder.Revision = Builders.VATRevisionBuilder.GetVATRevisionInfo(RevisionID);

            purchaseOrder.Vendor = vend;
            purchaseOrder.DateOfPurchase = dtpPurchaseDate.Value;
            purchaseOrder.DateOfInvoice = dtpInvoiceDate.Value;
            purchaseOrder.TotalPurchasePrice = decimal.Parse(txtTotalPurchasePrice.Text);
            purchaseOrder.TotalWholesalePrice = decimal.Parse(txtTotalWholesalePrice.Text);
            purchaseOrder.TotalResalePrice = decimal.Parse(txtTotalResalePrice.Text);
            purchaseOrder.ItemPriceList = ItemPriceList;

            bool success = Savers.PurchaseOrderSaver.SaverPurchaseOrder(purchaseOrder);
            if (success)
            {
                UpdateStatus("Saved", 100);
                this.Close();
            }
            else
                UpdateStatus("Error saving Purchase Bill",100);
        }

        private void dtpInvoiceDate_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Changing Invoice dates will effect the item pricing ");
            RevisionID = Builders.VATRevisionBuilder.GetRevisionDate(dtpInvoiceDate.Value.Date);
        }
    }
}
