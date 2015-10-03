using JanataBazaar.Builders;
using JanataBazaar.Model;
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
    public partial class Winform_SaleDetails : Winform_Details
    {
        List<SaleItem> saleItemList = new List<SaleItem>();
        List<ItemSKU> skuItemList = new List<ItemSKU>();

        Customer cust;
        Member memb;

        #region Property
        private decimal amntPaid = 0;
        private decimal balAmnt = 0;
        private decimal totalAmnt = 0;
        private decimal transCharge = 0;

        public decimal AmountPaid
        {
            get
            {
                return amntPaid;
            }
            set
            {
                amntPaid = value;
                txtAmntPaid.Text = amntPaid.ToString();
                BalanceAmount = TotalAmount - AmountPaid - TransportCharge;
            }
        }

        public decimal BalanceAmount
        {
            get
            {
                return balAmnt;
            }
            set
            {
                balAmnt = value;
                txtBalanceAmnt.Text = balAmnt.ToString();
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return totalAmnt;
            }
            set
            {
                totalAmnt = value;
                txtTotAmnt.Text = totalAmnt.ToString();
            }
        }

        public decimal TransportCharge
        {
            get
            {
                return transCharge;
            }
            set
            {
                transCharge = value;
            }
        }
        #endregion Property

        public Winform_SaleDetails()
        {
            InitializeComponent();
        }

        private void Winform_SaleDetails_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);

            List<Section> sectList = ItemDetailsBuilder.GetSectionsList();
            cmbSrcSection.DataSource = sectList;
            cmbSrcSection.DisplayMember = "Name";
            cmbSrcSection.ValueMember = "ID";
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            AddConsumerDetails();
        }

        private void AddConsumerDetails()
        {
            if (rdbMember.Checked)
                new Register.WinForm_MemberRegister().ShowDialog();
            else
                new Register.WinForm_CustomerRegister().ShowDialog();
        }

        private void txtSrcName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSrcBrand.Text) && string.IsNullOrEmpty(txtSrcName.Text))
            {
                dgvSearch.DataSource = null;
                return;
            }

            dgvSearch.DataSource = SaleItemBuilder.GetSaleItem(txtSrcName.Text, txtSrcBrand.Text, cmbSrcSection.Text);
            dgvSearch.Columns["ID"].Visible = false;
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Validation
            if (e.RowIndex == -1) return;
            int _ID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            /*Check if item is in stock*/
            bool inStock = ItemPricingBuilder.IsItemInStock(_ID);
            if (!inStock)
            {
                MessageBox.Show("Item cannot be added as its not in stock.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /*Get Selected Item Info*/
            ItemSKU itemsku = ItemSKUBuilder.GetItemSKUInfo(_ID);
            if (itemsku == null) return;

            /*If Item already exists*/
            bool itemExists = saleItemList.Any(i => i.ID == itemsku.ID);
            if (itemExists)
            {
                MessageBox.Show("Item selected already exists in the sale", "Item already Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion Validation

            skuItemList.Add(itemsku);

            SaleItem saleItem = new SaleItem(itemsku.Item, itemsku.WholesalePrice, itemsku.StockQuantity, 1, itemsku.WholesalePrice);
            saleItemList.Add(saleItem);

            dgvSaleItem.Rows.Add();
            var _index = dgvSaleItem.Rows.Count - 1;
            PopulateDgvSaleItem(saleItem, _index);
        }

        private void PopulateDgvSaleItem(SaleItem itemsku, int index)
        {
            /* sale item grid
             * name - Brand - quantity - price - total amount
            */
            dgvSaleItem.Rows[index].Cells["colItemName"].Value = itemsku.Item.Name;
            dgvSaleItem.Rows[index].Cells["colBrand"].Value = itemsku.Item.Brand;
            dgvSaleItem.Rows[index].Cells["colID"].Value = itemsku.ID;
            dgvSaleItem.Rows[index].Cells["colQuantity"].Value = itemsku.Quantity; //todo: Ask Minimum wholesale quantity
            dgvSaleItem.Rows[index].Cells["colPrice"].Value = itemsku.Price;
            dgvSaleItem.Rows[index].Cells["colTotalPrice"].Value = itemsku.TotalPrice;

            CalculatePaymentDetails();
        }

        private void CalculatePaymentDetails()
        {
            decimal total = 0;
            foreach (DataGridViewRow dr in dgvSaleItem.Rows)
            {
                if (dr.IsNewRow || dr.Cells["colPrice"].Value == null || dr.Cells["colQuantity"].Value == null) continue;

                total += (decimal.Parse(dr.Cells["colQuantity"].Value.ToString()) * decimal.Parse(dr.Cells["colPrice"].Value.ToString()));
            }

            decimal amntPaid = 0;
            decimal.TryParse(txtAmntPaid.Text, out amntPaid);
            AmountPaid = amntPaid;
            TotalAmount = total + TransportCharge;
            BalanceAmount = TotalAmount - AmountPaid;
        }

        internal void UpdateSaleItemList(SaleItem saleItem, int index)
        {
            saleItemList[index] = saleItem;

            PopulateDgvSaleItem(saleItem, index);
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            #region _validation
            if (this.cust == null && this.memb == null)
            {
                MessageBox.Show("Adding Consumer details is Mandatory.", "Add Consumer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (this.saleItemList.Count == 0)
            {
                MessageBox.Show("Sale Item cart cannot be empty.", "Add Items to Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion _validation

            UpdateStatus("Saving", 25);

            /*Prepare Model*/
            Sale sale = new Sale(this.saleItemList,AmountPaid,TotalAmount,this.cust,this.memb,TransportCharge,BalanceAmount);

            //deduct the total stock on save
            bool success = Savers.SaleDetailsSaver.SaveSaleDetails(sale, skuItemList);
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
        }

        private void dgvSaleItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            new Winform_SaleItemDetails(saleItemList[e.RowIndex], e.RowIndex).ShowDialog();
        }

        public void UpdateCustomerControls(Person _person)
        {
            if (rdbMember.Checked)
                this.memb = PeoplePracticeBuilder.GetMemberInfo(_person.ID);
            else
                this.cust = PeoplePracticeBuilder.GetCustomerInfo(_person.ID);

            txtName.Text = _person.Name;
            txtPhoneNo.Text = _person.Phone_No;
            txtMobNo.Text = _person.Mobile_No;
        }

        private void txtAmntPaid_Validating(object sender, CancelEventArgs e)
        {
            decimal amntPaid, totAmnt;
            decimal.TryParse(txtAmntPaid.Text, out amntPaid);
            decimal.TryParse(txtTotAmnt.Text, out totAmnt);

            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            if (_errorMsg == "" && amntPaid > totAmnt)
                _errorMsg = "Amount Paid cannot be greater than Total Amount";

            errorProvider1.SetError(txtAmntPaid, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtAmntPaid.Text = "";
                AmountPaid = 0;
                return;
            }
            else if (!string.IsNullOrEmpty(txtAmntPaid.Text))
            {
                //TotalAmount = totAmnt;
                AmountPaid = int.Parse(txtAmntPaid.Text);
            }
        }

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCash.Checked)
                rdbMember.Checked = true;
            else
                rdbCustomer.Checked = true;
        }

        private void rdbMember_CheckedChanged(object sender, EventArgs e)
        {
            bool _checked = rdbMember.Checked;
            rdbCash.Checked = _checked;
            rdbCredit.Checked = !_checked;

            if (!string.IsNullOrEmpty(txtName.Text))
                AddConsumerDetails();
        }

        private void txtTransCharge_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTransCharge.Text)) return;

            Match _match = Regex.Match(txtTransCharge.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            errorProvider1.SetError(txtTransCharge, _errorMsg);
            if (_errorMsg != "")
            {
                e.Cancel = true;
                txtTransCharge.Text = "";
                TransportCharge = 0;
                return;
            }

            TransportCharge = decimal.Parse(txtTransCharge.Text);
            CalculatePaymentDetails();
           
        }
    }
}
