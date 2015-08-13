using JanataBazaar.Model;
using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JanataBazaar.View.Details
{
    public partial class Winform_PurchaseBill : Winform_Details
    {
        Vendor vend = new Vendor();
        List<ItemSKU> skuList = new List<ItemSKU>();

        public Winform_PurchaseBill()
        {
            InitializeComponent();
        }

        private void Winform_PurchaseBill_Load(object sender, EventArgs e)
        {
            //this.toolStripParent.Items.Add(this.AddItemToolStrip);
            this.toolStripParent.Items.Add(this.AddVendorToolStrip);
        }

        public void UpdateVendorControls(Vendor _vend)
        {
            this.vend = _vend;
            txtVendorName.Text = _vend.Name;
        }

        private void AddVendorToolStrip_Click(object sender, EventArgs e)
        {
            new Register.Winform_AddVendor().ShowDialog();
        }

        private void AddItemToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_ItemSKUDetails().ShowDialog();
        }

        private void dgvDetails_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Columns["ColProduct"].Index == e.ColumnIndex)
            {
                if (skuList.Count == 0 || e.RowIndex + 1 > skuList.Count)
                {
                    new Winform_ItemSKUDetails(e.RowIndex).ShowDialog();
                }
                else
                {
                    new Winform_ItemSKUDetails(e.RowIndex, skuList[e.RowIndex]).ShowDialog();
                }
            }
            //else if (dgvDetails.Columns["ColDelete"].Index == e.ColumnIndex)
            //{
            //    //todo: Delete Row
            //}
        }

        internal void UpdateSKUItemList(int index, ItemSKU _itemsku)
        {
            if (skuList.Count == 0 || skuList.Count <= index)
                skuList.Add(_itemsku);
            else
                skuList[index] = _itemsku;

            dgvDetails.Rows[index].Cells[3].Value = _itemsku.PurchaseValue;
            dgvDetails.Rows[index].Cells[4].Value = _itemsku.Retail;
        }

        private void dgvDetails_RowLeave(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Rows[e.RowIndex].IsNewRow) return;

            if (IsNullOrEmpty(dgvDetails.Rows[e.RowIndex].Cells[2].Value))
            {
                dgvDetails.Rows[e.RowIndex].Cells[1].ErrorText = "Quantity Cannot be Empty";
                return;
            }
            
            
        }
    }
}
