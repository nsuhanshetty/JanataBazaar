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
        List<string> exceptList = new List<string> { "txtBasic", "txtWholePercent", "txtRetailPercent", "txtTotalBasic" };
        Item item;
        Package pack;
        int Index;
        int revisionID;

        #region Properties
        public decimal Basic { get; set; }

        private decimal _trans;
        public decimal Trans
        {
            get
            {
                txtTrans.Text = _trans.ToString();
                return _trans;
            }
            set
            {
                _trans = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
            }
        }

        private decimal _transpercent;
        public decimal TransPercent
        {
            get
            {
                //txtTransPercent.Text = _transpercent.ToString();
                return _transpercent;
            }
            set
            {
                _transpercent = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
                txtTransPercent.Text = _transpercent.ToString("#.##");
            }
        }

        private decimal _totalTrans;
        public decimal TotalTrans
        {
            get
            {
                return _totalTrans;
            }
            set
            {
                _totalTrans = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
                txtTotalTrans.Text = _totalTrans.ToString();
            }
        }

        private decimal _misc;
        public decimal Misc
        {
            get
            {
                txtMisc.Text = _misc.ToString();
                return _misc;
            }
            set
            {
                _misc = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
            }
        }

        private decimal _miscpercent;
        public decimal MiscPercent
        {
            get
            {
                return _miscpercent;
            }
            set
            {
                _miscpercent = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
                txtMiscPercent.Text = _miscpercent.ToString();
            }
        }

        private decimal _totalMisc;
        public decimal TotalMisc
        {
            get
            {
                return _totalMisc;
            }
            set
            {
                _totalMisc = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
                txtTotalMisc.Text = _totalMisc.ToString();
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
                //txtVAT.Text = _vat.ToString();
                return _vatpercent;
            }
            set
            {
                _vatpercent = value;
            }
        }

        private decimal _disc;
        public decimal Discount
        {
            get
            {
                txtDisc.Text = _disc.ToString();
                return _disc;
            }
            set
            {
                _disc = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
            }
        }

        private decimal _discpercent;
        public decimal DiscountPercent
        {
            get
            {
                return _discpercent;
            }
            set
            {
                _discpercent = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
                txtDiscPercent.Text = _discpercent.ToString();
            }
        }

        private decimal _totalDisc;
        public decimal TotalDiscount
        {
            get
            {
                return _totalDisc;
            }
            set
            {
                _totalDisc = value == 0 ? 0 : decimal.Parse(value.ToString("#.##"));
                txtTotalDiscount.Text = _totalDisc.ToString();
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
                txtTotalPurcPrice.Text = (_purchaseRate * nudItemsPerPack.Value * nudNoPacks.Value).ToString("#.##");
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
                //WRate = (value != 0 ? (PurchaseRate * (value / 100)) : 0) + PurchaseRate;
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
                // RRate = (value != 0 ? (WRate * (value / 100)) : 0) + WRate;
                _rRatepercent = value;
            }
        }
        #endregion 

        private void UpdateTransSet(decimal _percent, decimal _value, decimal _total)
        {
            if (_percent != 0)
            {
                TransPercent = _percent;
                Trans = Basic * (TransPercent / 100);
                TotalTrans = (Trans * (nudItemsPerPack.Value * nudNoPacks.Value));
            }
            else if (_value != 0)
            {
                Trans = _value;
                TransPercent = (Trans * 100) / Basic;
                TotalTrans = (Trans * (nudItemsPerPack.Value * nudNoPacks.Value));
            }
            else if (_total != 0)
            {
                TotalTrans = _total;
                Trans = (_total / (nudItemsPerPack.Value * nudNoPacks.Value));
                TransPercent = (Trans * 100) / Basic;
            }
        }

        private void UpdateVATSet(decimal _value)
        {
            txtTotalVAT.Text = _value == 0 ? "0" : (_value * (nudItemsPerPack.Value * nudNoPacks.Value)).ToString("#.##");
            lblVATRdOff.Text = (_value - decimal.Parse(txtVATMarginPrice.Text)).ToString("#.##");
        }

        private void UpdateMiscSet(decimal _percent, decimal _value, decimal _total)
        {
            if (_percent != 0)
            {
                MiscPercent = _percent;
                Misc = Basic * (MiscPercent / 100);
                TotalMisc = (Misc * (nudItemsPerPack.Value * nudNoPacks.Value));
            }
            else if (_value != 0)
            {
                Misc = _value;
                MiscPercent = (Misc * 100) / Basic;
                TotalMisc = (Misc * (nudItemsPerPack.Value * nudNoPacks.Value));
            }
            else if (_total != 0)
            {
                TotalMisc = _total;
                Misc = (_total / (nudItemsPerPack.Value * nudNoPacks.Value));
                MiscPercent = (Misc * 100) / Basic;
            }
        }

        private void UpdateDiscSet(decimal _percent, decimal _value, decimal _total)
        {
            if (_percent != 0)
            {
                DiscountPercent = _percent;
                Discount = Basic * (DiscountPercent / 100);
                TotalDiscount = (Discount * (nudItemsPerPack.Value * nudNoPacks.Value));
            }
            else if (_value != 0)
            {
                Discount = _value;
                DiscountPercent = (Discount * 100) / Basic;
                TotalDiscount = (Discount * (nudItemsPerPack.Value * nudNoPacks.Value));
            }
            else if (_total != 0)
            {
                TotalDiscount = _total;
                Discount = (_total / (nudItemsPerPack.Value * nudNoPacks.Value));
                DiscountPercent = (Discount * 100) / Basic;
            }
        }

        public Winform_ItemSKUDetails(int index = 0, int revisionID = 0)
        {
            InitializeComponent();
            var packageTypes = Builders.PurchaseBillBuilder.GetPackageTypes();
            cmbPackType.DataSource = packageTypes;

            //string[] packAutoCol = packageTypes.ToArray();
            //AutoCompleteStringCollection packAuto = new AutoCompleteStringCollection();
            //packAuto.AddRange(packAutoCol);
            //cmbPackType.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbPackType.AutoCompleteMode = AutoCompleteMode.Suggest;

            this.Index = index;

            this.revisionID = revisionID;
            if (revisionID != 0)
            {
                cmbVATPercent.DataSource = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);
                //cmbVATPercent.DisplayMember = "Percent";
            }
        }

        public Winform_ItemSKUDetails(int index, int revisionID, ItemPricing itemsku = null)
        {
            InitializeComponent();
            this.Index = index;

            this.revisionID = revisionID;

            //set combobox is set to default.
            if (revisionID != 0)
            {
                cmbVATPercent.DataSource = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);
                //cmbVATPercent.DisplayMember = "Percent";
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


            this.pack = itemsku.Package;
            if (this.pack != null)
                cmbPackType.SelectedIndex = cmbPackType.Items.IndexOf(this.pack.Name);
            nudNoPacks.Value = itemsku.PackageQuantity;
            nudItemsPerPack.Value = itemsku.QuantityPerPack;

            txtNetWght.Text = itemsku.NetWeight.ToString();
            txtGrossWght.Text = itemsku.GrossWeight.ToString();

            txtBasic.Text = itemsku.Basic.ToString();
            this.Basic = itemsku.Basic;
            txtTotalBasic.Text = (this.Basic * (nudNoPacks.Value * nudItemsPerPack.Value)).ToString("#.##");

            txtTransPercent.Text = itemsku.TransportPercent.ToString();
            //txtTrans.Text = itemsku.Transport.ToString();
            UpdateTransSet(itemsku.TransportPercent, 0, 0);

            txtMiscPercent.Text = itemsku.MiscPercent.ToString();
            //txtMisc.Text = itemsku.Misc.ToString();
            UpdateMiscSet(itemsku.MiscPercent, 0, 0);

            txtDiscPercent.Text = itemsku.DiscountPercent.ToString();
            ///txtDisc.Text = itemsku.Discount.ToString();
            UpdateDiscSet(itemsku.DiscountPercent, 0, 0);

            cmbVATPercent.SelectedIndex = cmbVATPercent.Items.IndexOf(itemsku.VATPercent);
            txtVAT.Text = itemsku.VAT.ToString("#.##");
            txtTotalVAT.Text = (itemsku.VAT * nudItemsPerPack.Value * nudNoPacks.Value).ToString("#.##");



            //this.VATPercent = itemsku.VATPercent;
            //this.MiscPercent = itemsku.MiscPercent;
            //this.DiscountPercent = itemsku.DiscountPercent;
            //this.TransPercent = itemsku.TransportPercent;

            //this.VAT = itemsku.VAT;
            //this.Misc = itemsku.Misc;
            //this.Discount = itemsku.Discount;
            //this.Trans = itemsku.Transport;

            //UpdateRates();
            UpdateRates();

            this.PurchaseRate = itemsku.PurchaseValue;

            this.WRatePercent = itemsku.WholesaleMargin;
            this.WRate = itemsku.Wholesale;

            this.RRatePercent = itemsku.RetailMargin;
            this.RRate = itemsku.Retail;

            txtPurchaseRate.Text = itemsku.PurchaseValue.ToString();
            //PurchaseRate = itemsku.PurchaseValue;

            txtWholePercent.Text = itemsku.WholesaleMargin.ToString();
            txtWholeMarginPrice.Text = ((WRatePercent != 0 ? (PurchaseRate * (WRatePercent / 100)) : 0) + PurchaseRate).ToString("#.##");
            txtWholeRate.Text = itemsku.Wholesale.ToString();
            UpdateWSaleSet();

            txtRetailPercent.Text = itemsku.RetailMargin.ToString();
            txtRetailMarginPrice.Text = ((RRatePercent != 0 ? (WRate * (RRatePercent / 100)) : 0) + WRate).ToString("#.##");
            txtRetailRate.Text = itemsku.Retail.ToString();
            UpdateRSaleSet();
        }

        private void Winform_Item_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddSectionToolStrip);
            this.toolStripParent.Items.Add(this.AddPackageToolStrip);

            //if (revisionID != 0)
            //{
            //    cmbVATPercent.DataSource = Builders.VATRevisionBuilder.GetVATRevisionPercentageList(revisionID);
            //    cmbVATPercent.DisplayMember = "Percent";
            //}
        }

        private void AddPackageToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_PackageDetails().ShowDialog();
            cmbPackType.DataSource = Builders.PurchaseBillBuilder.GetPackageTypes();
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
        private void txtValueDecimal_Validating(object sender, CancelEventArgs e)
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
            string _errorMsg = "";
            TextBox txt = (TextBox)sender;

            if (string.IsNullOrEmpty(txt.Text))
            {
                if (!exceptList.Contains(txt.Name)) return;
                _errorMsg = "Invalid Amount input data value.\nExample: '10'";
            }
            else
            {
                Match _match = Regex.Match(txt.Text, "^[0-9]*$");
                _errorMsg = !_match.Success ? "Invalid input data type.\nExample: '10'" : "";
            }
            errorProvider1.SetError(txt, _errorMsg);

            if (_errorMsg != "")
            {
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);
            }
        }

        #region PercentValidated
        //on validated update only the property
        //updating control must be done seprately to encourage "Sepration Of Concerns."
        private void txtTransPercent_Validated(object sender, EventArgs e)
        {
            TransPercent = (decimal.TryParse(txtTransPercent.Text, out _trans) ? _trans : 0);
            //Trans = TransPercent == 0 ? 0 : Basic * (TransPercent / 100);
            //TotalTrans = (Trans * (nudItemsPerPack.Value * nudNoPacks.Value));

            UpdateTransSet(TransPercent, 0, 0);

            UpdateRates();
        }

        private void txtMiscPercent_Validated(object sender, EventArgs e)
        {
            MiscPercent = (decimal.TryParse(txtMiscPercent.Text, out _misc) ? _misc : 0);
            //Misc = MiscPercent != 0 ? Basic * (MiscPercent / 100) : 0;
            //TotalMisc = (Misc * (nudItemsPerPack.Value * nudNoPacks.Value));
            UpdateMiscSet(MiscPercent, 0, 0);

            UpdateRates();
        }

        private void txtDiscPercent_Validated(object sender, EventArgs e)
        {
            DiscountPercent = (decimal.TryParse(txtDiscPercent.Text, out _disc) ? _disc : 0);
            //Discount = DiscountPercent != 0 ? Basic * (DiscountPercent / 100) : 0;
            //TotalDiscount = (Discount * (nudItemsPerPack.Value * nudNoPacks.Value));
            UpdateDiscSet(DiscountPercent, 0, 0);

            UpdateRates();
        }

        private void txtWholePercent_Validated(object sender, EventArgs e)
        {
            WRatePercent = (decimal.TryParse(txtWholePercent.Text, out _wRate) ? _wRate : 0);

            WRate = (WRatePercent != 0 ? (PurchaseRate * (WRatePercent / 100)) : 0) + PurchaseRate;
            txtWholeRate.Text = txtWholeMarginPrice.Text = WRate.ToString("#.##");
            txtTotalWSalePrice.Text = (WRate * (nudItemsPerPack.Value * nudNoPacks.Value)).ToString("#.##");
        }

        private void txtRetailPercent_Validated(object sender, EventArgs e)
        {
            RRatePercent = (decimal.TryParse(txtRetailPercent.Text, out _rRate) ? _rRate : 0);

            RRate = (RRatePercent != 0 ? (WRate * (RRatePercent / 100)) : 0) + WRate;
            txtRetailRate.Text = txtRetailMarginPrice.Text = RRate.ToString("#.##");
            txtTotalRSalePrice.Text = (RRate * (nudItemsPerPack.Value * nudItemsPerPack.Value)).ToString("#.##");
        }
        #endregion PercentValidated

        #region ratesValidated
        private void txtBasic_Validated(object sender, EventArgs e)
        {
            decimal _basic;
            Basic = decimal.TryParse(txtBasic.Text, out _basic) ? _basic : 0;
            var totalItem = nudItemsPerPack.Value * nudNoPacks.Value;

            txtTotalBasic.Text = (Basic * totalItem).ToString("#.##");

            if (!string.IsNullOrEmpty(cmbVATPercent.Text))
            {
                VATPercent = decimal.Parse(cmbVATPercent.Text);
                txtVAT.Text = VAT.ToString("#.##");
            }

            txtValues_Validated(this, new EventArgs());
            UpdateRates();
        }

        private void txtTotalBasic_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotalBasic.Text)) return;

            var totalItem = nudItemsPerPack.Value * nudNoPacks.Value;
            txtBasic.Text = (decimal.Parse(txtTotalBasic.Text) / totalItem).ToString("#.#####");
            txtBasic_Validated(this, new EventArgs());
        }

        private void txtValues_Validated(object sender, EventArgs e)
        {
            Trans = (decimal.TryParse(txtTrans.Text, out _trans) ? _trans : 0);
            UpdateTransSet(0, Trans, 0);

            Misc = (decimal.TryParse(txtMisc.Text, out _misc) ? _misc : 0);
            UpdateMiscSet(0, Misc, 0);

            VAT = (decimal.TryParse(txtVAT.Text, out _vat) ? _vat : 0);
            UpdateVATSet(VAT);

            Discount = (decimal.TryParse(txtDisc.Text, out _disc) ? _disc : 0);
            UpdateDiscSet(0, Discount, 0);

            UpdateRates();
        }

        private void txtPurchaseRate_Validated(object sender, EventArgs e)
        {
            PurchaseRate = decimal.Parse(txtPurchaseRate.Text);

            txtWholePercent_Validated(this, new EventArgs());
            txtRetailPercent_Validated(this, new EventArgs());
        }

        private void txtWholeRate_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWholeRate.Text)) return;

            WRate = decimal.Parse(txtWholeRate.Text);
            txtRetailPercent_Validated(this, new EventArgs());
            UpdateWSaleSet();
        }

        private void UpdateWSaleSet()
        {
            decimal wsaleMargin = !string.IsNullOrEmpty(txtWholeMarginPrice.Text) && decimal.TryParse(txtWholeMarginPrice.Text, out wsaleMargin) ? wsaleMargin : 0;
            lblWRateRdOff.Text = (WRate - wsaleMargin).ToString("#.##");

            txtTotalWSalePrice.Text = (WRate * (nudItemsPerPack.Value * nudNoPacks.Value)).ToString("#.##");
        }

        private void txtRetailRate_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRetailRate.Text)) return;

            RRate = decimal.Parse(txtRetailRate.Text);
            UpdateRSaleSet();
        }

        private void UpdateRSaleSet()
        {
            decimal rsaleMargin = !string.IsNullOrEmpty(txtRetailMarginPrice.Text) && decimal.TryParse(txtRetailMarginPrice.Text, out rsaleMargin) ? rsaleMargin : 0;
            lblRRateRdOff.Text = (RRate - rsaleMargin).ToString("##.##");

            txtTotalRSalePrice.Text = (RRate * (nudItemsPerPack.Value * nudNoPacks.Value)).ToString("#.##");
        }
        #endregion ratesValidated

        #endregion

        private void AddSectionToolStrip_Click(object sender, EventArgs e)
        {
            new Register.Winform_ItemRegistry().ShowDialog();

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

            //VATPercent = _item.VatPercent;
            //txtVAT.Text = VAT.ToString();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            this.ProcessTabKey(true);
            List<string> exceptList = new List<string>() { "txtDisc", "txtDiscPercent","txtTotalDiscount" ,"txtMisc", "txtMiscPercent","txtTotalMisc" ,"txtTrans",
                                                           "txtTransPercent","txtTotalTrans" ,"txtVAT", "cmbVATPercent","txtTotalVAT", "txtBrand","cmbPackType","txtNoPacks","txtNetWght","txtGrossWght" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, exceptList)) return;

            ItemPricing _itemPrice = new ItemPricing();

            _itemPrice.Item = item;
            _itemPrice.Basic = Basic;

            _itemPrice.Discount = Discount;
            _itemPrice.DiscountPercent = DiscountPercent;

            if (chkDOM.Checked == true)
                _itemPrice.ManufacturedDate = dtpDOM.Value;

            if (chkDOE.Checked == true)
                _itemPrice.ExpiredDate = dtpDOE.Value;

            _itemPrice.Transport = Trans;
            _itemPrice.TransportPercent = TransPercent;

            _itemPrice.Misc = Misc;
            _itemPrice.MiscPercent = MiscPercent;

            _itemPrice.VAT = chkIsExempted.Checked == true ? 0 : VAT;
            _itemPrice.VATPercent = chkIsExempted.Checked == true ? 0 : VATPercent;

            _itemPrice.Discount = Discount;
            _itemPrice.DiscountPercent = DiscountPercent;

            _itemPrice.Wholesale = WRate;
            _itemPrice.WholesaleMargin = WRatePercent;

            _itemPrice.Retail = RRate;
            _itemPrice.RetailMargin = RRatePercent;

            _itemPrice.PurchaseValue = PurchaseRate;

            if (this.pack != null)
                _itemPrice.Package = this.pack;
            _itemPrice.PackageQuantity = int.Parse(nudNoPacks.Value.ToString());
            _itemPrice.QuantityPerPack = int.Parse(nudItemsPerPack.Value.ToString());

            _itemPrice.NetWeight = string.IsNullOrEmpty(txtNetWght.Text) ? 0 : int.Parse(txtNetWght.Text);
            _itemPrice.GrossWeight = string.IsNullOrEmpty(txtGrossWght.Text) ? 0 : int.Parse(txtGrossWght.Text);

            Winform_PurchaseBill purchaseBill = Application.OpenForms["Winform_PurchaseBill"] as Winform_PurchaseBill;
            if (purchaseBill != null)
                purchaseBill.UpdateSKUItemList(this.Index, _itemPrice);

            UpdateStatus("ItemSKU Saved", 100);
            this.Close();
        }

        private void txtNetWght_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPackType.Text))
                this.pack = Builders.PackageDetailsBuilder.GetPackage(cmbPackType.Text);

            if (string.IsNullOrEmpty(txtNetWght.Text)) return;
            txtGrossWght.Text = (int.Parse(txtNetWght.Text) + (this.pack != null ? this.pack.Weight : 0)).ToString();
        }

        private void chkIsExempted_CheckedChanged(object sender, EventArgs e)
        {
            cmbVATPercent.Enabled = !chkIsExempted.Checked;
            cmbVATPercent.SelectedIndex = 0;

            //txtVAT.Enabled = false;
            //if (txtVATPerc.Enabled)
            //    txtVATPerc.Validating += new CancelEventHandler(this.txtBox_Validating);
            //else
            //    txtVATPerc.Validating += null;
        }

        private void cmbVATPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            VATPercent = decimal.Parse(cmbVATPercent.Text);
            VAT = VATPercent != 0 ? Basic * (VATPercent / 100) : 0;

            lblVATRdOff.Text = "0";
            txtVAT.Text = txtVATMarginPrice.Text = VAT == 0 ? "0" : VAT.ToString("#.##");
            txtTotalVAT.Text = VAT == 0 ? "0" : (VAT * nudItemsPerPack.Value * nudNoPacks.Value).ToString("#.##");

            UpdateRates();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.IsInEdit(this, true))
            {
                DialogResult dr = MessageBox.Show("Continue to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    this.Close();
            }

        }

        private void txtTotalTrans_Validated(object sender, EventArgs e)
        {
            TotalTrans = (decimal.TryParse(txtTotalTrans.Text, out _totalTrans) ? _totalTrans : 0);
            UpdateTransSet(0, 0, TotalTrans);

            TotalMisc = (decimal.TryParse(txtTotalMisc.Text, out _totalMisc) ? _totalMisc : 0);
            UpdateMiscSet(0, 0, TotalMisc);

            TotalDiscount = (decimal.TryParse(txtTotalDiscount.Text, out _totalDisc) ? _totalDisc : 0);
            UpdateDiscSet(0, 0, TotalDiscount);

            UpdateRates();
        }
    }
}
