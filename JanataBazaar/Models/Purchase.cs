using JanataBazaar.Model;
using System;
using System.Collections.Generic;

namespace JanataBazaar.Models
{
    public class PurchaseOrder
    {
        public virtual int ID { get; set; }
        public virtual DateTime DateOfPurchase { get; set; }
        public virtual DateTime DateOfInvoice { get; set; }
        public virtual bool BillType { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual float TotalPurchasePrice { get; set; }
        public virtual float TotalWholesalePrice { get; set; }
        public virtual float TotalResalePrice { get; set; }
        public virtual IList<ItemSKU> SKUItems { get; set; }

        public PurchaseOrder() { }

        public PurchaseOrder(bool _billType, Vendor _vendor, DateTime _dop, DateTime _doi, float totPurchase, float totWholesale,float totResale)
        {
            this.BillType = _billType;
            this.Vendor = _vendor;
            this.DateOfPurchase = _dop;
            this.DateOfInvoice = _doi;
            this.TotalPurchasePrice = totPurchase;
            this.TotalWholesalePrice = totWholesale;
            this.TotalResalePrice = totResale;
        }
    }
}
