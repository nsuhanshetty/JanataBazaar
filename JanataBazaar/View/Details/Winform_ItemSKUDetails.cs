using JanataBazaar.Models;
using JanataBazaar.View.Details;
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
    public partial class Winform_ItemSKUDetails : Winform_Details
    {
        List<string> exceptList = new List<string> { "txtBasic", "txtWholePercent", "txtRetailPercent" };
        Item item;
        Package pack;
        int Index;
        int revisionID;

        #region Properties
        public decimal Basic { get; set; }

        private decimal _trans;
        public decimal Trans
        {
            get; set;
        }

        private decimal _transpercent;
        public decimal TransPercent
        {
            get
            {
                txtTrans.Text = _trans.ToString();
                return _transpercent;
            }
            set
            {
                Trans = value != 0 ? Basic * (value / 100) : 0;
                _transpercent = value;
            }
        }

        private decimal _misc;
        public decimal Misc
        {
            get; set;
        }

        private decimal _miscpercent;
        public decimal MiscPercent
        {
            get
            {
                txtMisc.Text = _misc.ToString();
                return _miscpercent;
            }
            set
            {
                Misc = value != 0 ? Basic * (value / 100) : 0;
                _miscpercent = value;
            }
        }

        private decimal _vat;
        public decimal VAT
        {
            get; set;
        }

        private decimal _vatpercent;
        public decimal VATPercent
        {
            get
            {
                txtVAT.Text = _vat.ToString();
                return _vatpercent;
            }
            set
            {

                VAT = value != 0 ? Basic * (value / 100) : 0;
                _vatpercent = value;
            }
        }

        private decimal _disc;
        public decimal Discount
        {
            get; set;
        }

        private decimal _discpercent;
        public decimal DiscountPercent
        {
            get
            {
                txtDisc.Text = _disc.ToString();
                return _discpercent;
            }
            set
            {
                Discount = value != 0 ? Basic * (value / 100) : 0;
                _discpercent = value;
            }
        }

        private decimal _purchaseRate;
        public decimal PurchaseRate
        {
            get
            {
                return _purchaseRate;
            }
            set
            {
                _purchaseRate = value;
                txtPurchaseRate.Text = _purchaseRate.ToString();
            }
        }

        private decimal _purchaseValue;
        public decimal PurchaseValue
        {
            get
            {
                //decimal _purchaseValue = ((Basic + Trans + Misc + VAT) - Discount);
               
                return _purchaseValue;
            }
            set
            {
                _purchaseValue = value;
                PurchaseRate = _purchaseValue;
            }
        }
        private decimal _wRate;
        public decimal WRate
        {
            get; set;
        }

        private decimal _wRatepercent;
        public decimal WRatePercent
        {
            get
            {
                return _wRatepercent;
            }
            set
            {
                WRate = (value != 0 ? (PurchaseRate * (value / 100)) : 0) + PurchaseRate;
                _wRatepercent = value;
            }
        }

        private decimal _rRate;
        public decimal RRate
        {
            get; set;
        }

        private decimal _rRatepercent;
        public decimal RRatePercent
        {
            get
            {
                return _rRatepercent;
            }
            set
            {
                RRate = (value != 0 ? (WRate * (value / 100)) : 0) + WRate;
                _rRatepercent = value;
            }
        }

        #endregion 

        public Winform_ItemSKUDetails(int index = 0, int revisionID=0)
        {
            InitializeComponent();
            cmbPackType.DataSource = Builders.PurchaseBillBuilder.GetPackageTypes();
            this.Index = index;

            this.revisionID = revisionID;
            if (revisionID != 0)
            {
                cmbVATPercent.DataSource = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);
                cmbVATPercent.DisplayMember = "Percent";
            }
        }

        public Winform_ItemSKUDetails(int index,int revisionID, ItemSKU itemsku = null)
        {
            InitializeComponent();
            this.Index = index;

            this.revisionID = revisionID;
            if (revisionID != 0)
            {
                cmbVATPercent.DataSource = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);
                cmbVATPercent.DisplayMember = "Percent";
            }

            cmbPackType.DataSource = Builders.PurchaseBillBuilder.GetPackageTypes();

            //load controls
            this.item = itemsku.Item;
            UpdateItemDetailControls(this.item);

            if (itemsku.ManufacturedDate != DateTime.MinValue)
            {
                chkDOM.Checked = true;
                dtpDOM.Enabled = true;
                dtpDOM.Value = itemsku.ManufacturedDate;
            }

            if (itemsku.ExpiredDate != DateTime.MinValue)
            {
                chkDOE.Checked = true;
                dtpDOE.Enabled = true;
                dtpDOE.Value = itemsku.ExpiredDate;
            }

            txtBasic.Text = itemsku.Basic.ToString();

            txtTransPercent.Text = itemsku.TransportPercent.ToString();
            txtTrans.Text = itemsku.Transport.ToString();

            txtMiscPercent.Text = itemsku.MiscPercent.ToString();
            txtMisc.Text = itemsku.Misc.ToString();

            txtDiscPercent.Text = itemsku.DiscountPercent.ToString();
            txtDisc.Text = itemsku.Discount.ToString();

            cmbVATPercent.SelectedIndex = cmbVATPercent.Items.IndexOf(itemsku.VATPercent);
            txtVAT.Text = itemsku.VAT.ToString();

            txtWholePercent.Text = itemsku.WholesaleMargin.ToString();
            txtWholeRate.Text = itemsku.Wholesale.ToString();

            txtRetailPercent.Text = itemsku.RetailMargin.ToString();
            txtRetailRate.Text = itemsku.Retail.ToString();

            this.pack = itemsku.Package;
            cmbPackType.SelectedIndex = cmbPackType.Items.IndexOf(this.pack.Name);
            txtNoPacks.Text = itemsku.PackageQuantity.ToString();
            txtItemsPerPack.Text = itemsku.QuantityPerPack.ToString();

            txtNetWght.Text = itemsku.NetWeight.ToString();
            txtGrossWght.Text = itemsku.GrossWeight.ToString();
        }

        private void Winform_Item_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddSectionToolStrip);
            this.toolStripParent.Items.Add(this.AddPackageToolStrip);

            if (revisionID != 0)
            {
                cmbVATPercent.DataSource = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);
                cmbVATPercent.DisplayMember = "Percent";
            }
        }

        private void AddPackageToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_PackageDetails().ShowDialog();
        }

        private void chkDOM_CheckedChanged(object sender, EventArgs e)
        {
            dtpDOM.Enabled = chkDOM.Checked;
        }

        private void chkDOE_CheckedChanged(object sender, EventArgs e)
        {
            dtpDOE.Enabled = chkDOE.Checked;
        }

        #region Validation
        //  private void cmbName_Validating(object sender, CancelEventArgs e)
        //  {
        //      ComboBox cmb = (ComboBox)sender;
        //      Match _match = Regex.Match(cmb.Text, "^[a-zA-Z\\s]+$");
        //      string errorMsg = _match.Success ? "" : "Invalid Input\n" +
        //"For example 'ABCabc'";
        //      errorProvider1.SetError(cmb, errorMsg);

        //      if (errorMsg != "")
        //      {
        //          e.Cancel = true;
        //          cmb.Select(0, cmb.Text.Length);
        //      }
        //  }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string _errorMsg;

            if (string.IsNullOrEmpty(txt.Text))
            {
                if (!exceptList.Contains(txt.Name)) return;
                _errorMsg = "Invalid Amount input data type.\nExample: '1100'";
            }
            else
            {
                Match _match = Regex.Match(txt.Text, "^[0-9]*\\.?[0-9]*$");
                _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            }
            errorProvider1.SetError(txt, _errorMsg);

            if (_errorMsg != "")
            {
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);
            }
        }

        private void txtValueInt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string _errorMsg;

            if (string.IsNullOrEmpty(txt.Text))
            {
                if (!exceptList.Contains(txt.Name)) return;
                _errorMsg = "Invalid Amount input data type.\nExample: '10'";
            }
            else
            {
                Match _match = Regex.Match(txt.Text, "^[0-9]*$");
                _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '10'" : "";
            }
            errorProvider1.SetError(txt, _errorMsg);

            if (_errorMsg != "")
            {
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);
            }
        }

        private void cmbVATPercent_Validating(object sender, CancelEventArgs e)
        {
            //ComboBox cmb = (ComboBox)sender;
            //string _errorMsg;

            //if (string.IsNullOrEmpty(cmb.Text))
            //{
            //    _errorMsg = "Invalid Amount input data type.\nExample: '2.2'";
            //}
            //else
            //{
            //    Match _match = Regex.Match(cmb.Text, "^[0-9]*\\.?[0-9]*$");
            //    _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            //}
            //errorProvider1.SetError(cmb, _errorMsg);

            //if (_errorMsg != "")
            //{
            //    e.Cancel = true;
            //    cmb.Select(0, cmb.Text.Length);
            //}
        }

        //private void cmbValue_Validated(object sender, EventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;
        //    cmb.Text = Utilities.Validation.ToTitleCase(cmb.Text);
        //}

        private void txtBasic_Validated(object sender, EventArgs e)
        {
            decimal _basic;
            Basic = decimal.TryParse(txtBasic.Text, out _basic) ? _basic : 0;

            if (!string.IsNullOrEmpty(cmbVATPercent.Text))
            {
                VATPercent = decimal.Parse(cmbVATPercent.Text);
                txtVAT.Text = VAT.ToString();
            }
            UpdateRates();
        }

        private void txtTransPercent_Validated(object sender, EventArgs e)
        {
            TransPercent = (decimal.TryParse(txtTransPercent.Text, out _trans) ? _trans : 0);
            txtTrans.Text = Trans.ToString();
            UpdateRates();
        }

        private void txtMiscPercent_Validated(object sender, EventArgs e)
        {
            MiscPercent = (decimal.TryParse(txtMiscPercent.Text, out _misc) ? _misc : 0);
            txtMisc.Text = Misc.ToString();
            UpdateRates();
        }

        private void cmbVATPercent_Validated(object sender, EventArgs e)
        {
            //VATPercent = (decimal.TryParse(txtVATPercent.Text, out _vat) ? _vat : 0);
            //txtVAT.Text = VAT.ToString();
            //UpdateRates();
        }

        private void txtDiscPercent_Validated(object sender, EventArgs e)
        {
            DiscountPercent = (decimal.TryParse(txtDiscPercent.Text, out _disc) ? _disc : 0);
            txtDisc.Text = Discount.ToString();
            UpdateRates();
        }

        private void txtWholePercent_Validated(object sender, EventArgs e)
        {
            WRatePercent = (decimal.TryParse(txtWholePercent.Text, out _wRate) ? _wRate : 0);
            txtWholeRate.Text = WRate.ToString();
        }

        private void txtRetailPercent_Validated(object sender, EventArgs e)
        {
            RRatePercent = (decimal.TryParse(txtRetailPercent.Text, out _rRate) ? _rRate : 0);
            txtRetailRate.Text = RRate.ToString();
        }

        private void txtPurchaseRate_Validated(object sender, EventArgs e)
        {
            PurchaseRate = decimal.Parse(txtPurchaseRate.Text);
        }

        private void txtWholeRate_Validated(object sender, EventArgs e)
        {
            WRate = decimal.Parse(txtWholeRate.Text);
        }

        private void txtRetailRate_Validated(object sender, EventArgs e)
        {
            RRate = decimal.Parse(txtRetailRate.Text);
        }

        private void txtValues_Validated(object sender, EventArgs e)
        {
            Trans = (decimal.TryParse(txtTrans.Text, out _trans) ? _trans : 0);
            Misc = (decimal.TryParse(txtMisc.Text, out _misc) ? _misc : 0);
            VAT = (decimal.TryParse(txtVAT.Text, out _vat) ? _vat : 0);
            Discount = (decimal.TryParse(txtDisc.Text, out _disc) ? _disc : 0);
            UpdateRates();
        }
        #endregion

        private void AddSectionToolStrip_Click(object sender, EventArgs e)
        {
            new Register.Winform_AddItemRegistry().ShowDialog();

        }

        private void UpdateRates()
        {
            PurchaseValue = ((Basic + Trans + Misc + VAT) - Discount);
            txtWholePercent_Validated(this, new EventArgs());
            txtRetailPercent_Validated(this, new EventArgs());
        }

        public void UpdateItemDetailControls(Item _item)
        {
            this.item = _item;

            txtName.Text = item.Name;
            txtUnit.Text = item.QuantityUnit;
            txtSection.Text = item.Section.Name;
            txtBrand.Text = _item.Brand;

            //chkIsExempted.Checked = _item.IsVatExempted;
            //txtVATPercent.Text = _item.VatPercent.ToString();
            //txtVAT.Enabled = !chkIsExempted.Checked;

            VATPercent = _item.VatPercent;
            txtVAT.Text = VAT.ToString();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            this.ProcessTabKey(true);
            List<string> exceptList = new List<string>() { "txtDisc", "txtDiscPercent", "txtMisc", "txtMiscPercent", "txtTrans",
                                                           "txtTransPercent", "txtVAT", "cmbVATPercent","txtBrand","cmbPackType","txtNoPacks","txtNetWght","txtGrossWght" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, exceptList)) return;

            ItemSKU _itemSKU = new ItemSKU();

            _itemSKU.Item = item;
            _itemSKU.Basic = Basic;

            _itemSKU.Discount = Discount;
            _itemSKU.DiscountPercent = DiscountPercent;

            if (chkDOM.Checked == true)
                _itemSKU.ManufacturedDate = dtpDOM.Value;

            if (chkDOE.Checked == true)
                _itemSKU.ExpiredDate = dtpDOE.Value;

            _itemSKU.Transport = Trans;
            _itemSKU.TransportPercent = TransPercent;

            _itemSKU.Misc = Misc;
            _itemSKU.MiscPercent = MiscPercent;

            _itemSKU.VAT = VAT;
            _itemSKU.VATPercent = VATPercent;

            _itemSKU.Discount = Discount;
            _itemSKU.DiscountPercent = DiscountPercent;

            _itemSKU.Wholesale = WRate;
            _itemSKU.WholesaleMargin = WRatePercent;

            _itemSKU.Retail = RRate;
            _itemSKU.RetailMargin = RRatePercent;

            _itemSKU.PurchaseValue = PurchaseValue;

            _itemSKU.Package = this.pack;
            _itemSKU.PackageQuantity = string.IsNullOrEmpty(txtNoPacks.Text) ? 1 : int.Parse(txtNoPacks.Text);
            _itemSKU.QuantityPerPack = int.Parse(txtItemsPerPack.Text);

            _itemSKU.NetWeight = string.IsNullOrEmpty(txtNetWght.Text) ? 0 : int.Parse(txtNetWght.Text);
            _itemSKU.GrossWeight = string.IsNullOrEmpty(txtGrossWght.Text) ? 0 : int.Parse(txtGrossWght.Text);

            Winform_PurchaseBill purchaseBill = Application.OpenForms["Winform_PurchaseBill"] as Winform_PurchaseBill;
            if (purchaseBill != null)
                purchaseBill.UpdateSKUItemList(this.Index, _itemSKU);

            UpdateStatus("ItemSKU Saved", 100);
            this.Close();
        }

        private void txtNetWght_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPackType.Text))
                this.pack = Builders.PackageDetailsBuilder.GetPackage(cmbPackType.Text);

            if (string.IsNullOrEmpty(txtNetWght.Text)) return;
            txtGrossWght.Text = (int.Parse(txtNetWght.Text) + this.pack.Weight).ToString();
        }

        private void chkIsExempted_CheckedChanged(object sender, EventArgs e)
        {
            cmbVATPercent.Enabled = !chkIsExempted.Checked;
            txtVAT.Enabled = false;
            
            //if (txtVATPerc.Enabled)
            //    txtVATPerc.Validating += new CancelEventHandler(this.txtBox_Validating);
            //else
            //    txtVATPerc.Validating += null;
        }

        private void cmbVATPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            VATPercent = decimal.Parse(cmbVATPercent.Text);
            txtVAT.Text = VAT.ToString();
            UpdateRates();
        }
    }
}
