using JanataBazaar.Model;
using System;
using System.Collections.Generic;

namespace JanataBazaar.Models
{
    public class PurchaseOrder
    {
        public virtual int ID { get; set; }

        public virtual string SCFNo { get; set; }
        public virtual string IRNNo { get; set; }
        //public virtual string BillNo { get; set; }

        public virtual VATRevision Revision { get; set; }

        public virtual DateTime DateOfPurchase { get; set; }
        public virtual DateTime DateOfInvoice { get; set; }
        public virtual bool IsCredit { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual decimal TotalPurchasePrice { get; set; }
        public virtual decimal TotalWholesalePrice { get; set; }
        public virtual decimal TotalResalePrice { get; set; }
        public virtual IList<ItemPricing> ItemPriceList { get; set; }
        //public virtual IList<ItemPricing> Price { get; set; }

        public PurchaseOrder() { }

        public PurchaseOrder(bool _billType, string _SCFNo, string _IRNNo, string _billNo, VATRevision _revision, Vendor _vendor, DateTime _dop, DateTime _doi, decimal totPurchase, decimal totWholesale, decimal totResale)
        {
            this.IsCredit = _billType;

            this.SCFNo = SCFNo;
            this.IRNNo = IRNNo;
           //this.BillNo = _billNo;

            this.Revision = _revision;

            this.Vendor = _vendor;
            this.DateOfPurchase = _dop;
            this.DateOfInvoice = _doi;
            this.TotalPurchasePrice = totPurchase;
            this.TotalWholesalePrice = totWholesale;
            this.TotalResalePrice = totResale;
        }
    }
}
