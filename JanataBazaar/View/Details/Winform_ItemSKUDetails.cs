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
        int Index;

        #region Properties
        public float Basic { get; set; }

        private float _trans;
        public float Trans
        {
            get; set;
        }

        public float TransPercent
        {
            get
            {
                txtTrans.Text = _trans.ToString();
                return _trans;
            }
            set
            {
                if (value != 0)
                {
                    Trans = Basic * (value / 100);
                }
            }
        }

        private float _misc;
        public float Misc
        {
            get; set;
        }

        public float MiscPercent
        {
            get
            {
                txtMisc.Text = _misc.ToString();
                return _misc;
            }
            set
            {
                if (value != 0)
                {
                    Misc = Basic * (value / 100);
                }
            }
        }

        private float _vat;
        public float VAT
        {
            get; set;
        }

        public float VATPercent
        {
            get
            {
                txtVAT.Text = _vat.ToString();
                return _vat;
            }
            set
            {
                if (value != 0)
                {
                    VAT = Basic * (value / 100);
                }
            }
        }

        private float _disc;
        public float Discount
        {
            get; set;
        }

        public float DiscountPercent
        {
            get
            {
                txtDisc.Text = _disc.ToString();
                return _disc;
            }
            set
            {
                if (value != 0)
                {
                    Discount = Basic * (value / 100);
                }
            }
        }

        private float _wRate;
        public float WRate
        {
            get; set;
        }

        public float WRatePercent
        {
            get
            {
                return _wRate;
            }
            set
            {
                WRate = (PurchaseValue * (value / 100)) + PurchaseValue;
            }
        }

        private float _rRate;
        public float RRate
        {
            get; set;
        }
        public float RRatePercent
        {
            get
            {

                return _rRate;
            }
            set
            {
                RRate = (WRate * (value / 100)) + WRate;
            }
        }


        public float PurchaseValue
        {
            get
            {
                return ((Basic + Trans + Misc + VAT) - Discount);
            }
        }

        #endregion

        public Winform_ItemSKUDetails()
        {
            InitializeComponent();
        }

        public Winform_ItemSKUDetails(int index, ItemSKU itemsku=null)
        {
            InitializeComponent();
            this.Index = index;

            //todo: load controls
        }

        private void Winform_Item_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddSectionToolStrip);
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

        private void cmbVATPercent_Validating(object sender, CancelEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string _errorMsg;

            if (string.IsNullOrEmpty(cmb.Text))
            {
                _errorMsg = "Invalid Amount input data type.\nExample: '2.2'";
            }
            else
            {
                Match _match = Regex.Match(cmb.Text, "^[0-9]*\\.?[0-9]*$");
                _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            }
            errorProvider1.SetError(cmb, _errorMsg);

            if (_errorMsg != "")
            {
                e.Cancel = true;
                cmb.Select(0, cmb.Text.Length);
            }
        }

        //private void cmbValue_Validated(object sender, EventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;
        //    cmb.Text = Utilities.Validation.ToTitleCase(cmb.Text);
        //}

        private void txtBasic_Validated(object sender, EventArgs e)
        {
            float _basic;
            Basic = float.TryParse(txtBasic.Text, out _basic) ? _basic : 0;
            UpdateRates();
        }

        private void txtTransPercent_Validated(object sender, EventArgs e)
        {
            TransPercent = (float.TryParse(txtTransPercent.Text, out _trans) ? _trans : 0);
            txtTrans.Text = Trans.ToString();
            UpdateRates();
        }

        private void txtMiscPercent_Validated(object sender, EventArgs e)
        {
            MiscPercent = (float.TryParse(txtMiscPercent.Text, out _misc) ? _misc : 0);
            txtMisc.Text = Misc.ToString();
            UpdateRates();
        }

        private void cmbVATPercent_Validated(object sender, EventArgs e)
        {
            VATPercent = (float.TryParse(cmbVATPercent.Text, out _vat) ? _vat : 0);
            txtVAT.Text = VAT.ToString();
            UpdateRates();
        }

        private void txtDiscPercent_Validated(object sender, EventArgs e)
        {
            DiscountPercent = (float.TryParse(txtDiscPercent.Text, out _disc) ? _disc : 0);
            txtDisc.Text = Discount.ToString();
            UpdateRates();
        }

        private void txtWholePercent_Validated(object sender, EventArgs e)
        {
            WRatePercent = (float.TryParse(txtWholePercent.Text, out _wRate) ? _wRate : 0);
            txtWholeRate.Text = WRate.ToString();
        }

        private void txtRetailPercent_Validated(object sender, EventArgs e)
        {
            RRatePercent = (float.TryParse(txtRetailPercent.Text, out _rRate) ? _rRate : 0);
            txtRetailRate.Text = RRate.ToString();
        }

        private void txtValues_Validated(object sender, EventArgs e)
        {
            Trans = (float.TryParse(txtTrans.Text, out _trans) ? _trans : 0);
            Misc = (float.TryParse(txtMisc.Text, out _misc) ? _misc : 0);
            VAT = (float.TryParse(txtVAT.Text, out _vat) ? _vat : 0);
            Discount = (float.TryParse(txtDisc.Text, out _disc) ? _disc : 0);
            UpdateRates();
        }
        #endregion

        private void AddSectionToolStrip_Click(object sender, EventArgs e)
        {
            new Register.Winform_AddItemRegistry().ShowDialog();

        }

        private void UpdateRates()
        {
            txtWholePercent_Validated(this, new EventArgs());
            txtRetailPercent_Validated(this, new EventArgs());
        }

        public void UpdateItemDetailControls(Item _item)
        {
            this.item = _item;

            txtName.Text = item.Name;
            txtUnit.Text = item.QuantityUnit;
            txtSection.Text = item.Section.Name;
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            List<string> exceptList = new List<string>() { "txtDisc", "txtDiscPercent", "txtMisc", "txtMiscPercent", "txtTrans",
                                                           "txtTransPercent", "txtVAT", "cmbVATPercent", };
            if (Utilities.Validation.IsNullOrEmpty(this, true, exceptList)) return;

            ItemSKU _itemSKU = new ItemSKU();

            _itemSKU.ItemID = item.ID;
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

            Winform_PurchaseBill purchaseBill = Application.OpenForms["Winform_PurchaseBill"] as Winform_PurchaseBill;
            if (purchaseBill != null)
                purchaseBill.UpdateSKUItemList(this.Index,_itemSKU);

            UpdateStatus("ItemSKU Saved", 100);
            this.Close();
        }
    }
}
