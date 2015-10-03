using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    public class Section
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }

        public Section() { }
        public Section(string _name)
        {
            this.Name = _name;
        }

    }

    public class Item
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }
        public virtual Section Section { get; set; }
        public virtual string QuantityUnit { get; set; }
        public virtual string Brand { get; set; }
        public virtual bool InReserve { get; set; }
        public virtual int ReserveStock { get; set; }

        public Item() { }
        public Item(string _name, string _quantityUnit, Section _section, string _brand, int _ReserveStock)
        {
            this.Name = _name;
            this.QuantityUnit = _quantityUnit;
            this.Section = _section;
            this.Brand = _brand;
            this.ReserveStock = _ReserveStock;
        }
    }

    public class ItemPricing
    {
        public virtual int ID { get; set; }
        public virtual PurchaseOrder Purchase { get; set; }
        public virtual Item Item { get; set; }
        public virtual DateTime ManufacturedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }

        public virtual decimal Basic { get; set; }
        public virtual decimal TransportPercent { get; set; }
        public virtual decimal Transport { get; set; }
        public virtual decimal MiscPercent { get; set; }
        public virtual decimal Misc { get; set; }
        public virtual decimal VATPercent { get; set; }
        public virtual decimal VAT { get; set; }
        public virtual decimal DiscountPercent { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual decimal WholesaleMargin { get; set; }
        public virtual decimal Wholesale { get; set; }
        public virtual decimal RetailMargin { get; set; }
        public virtual decimal Retail { get; set; }
        public virtual decimal PurchaseValue { get; set; }

        public virtual Package Package { get; set; }
        public virtual int QuantityPerPack { get; set; }
        public virtual int PackageQuantity { get; set; }

        public virtual int NetWeight { get; set; }
        public virtual int GrossWeight { get; set; }

        //public virtual int StockQuantity { get; set; }

        public virtual decimal TotalPurchaseValue { get; set; }
        public virtual decimal TotalWholesaleValue { get; set; }
        public virtual decimal TotalResaleValue { get; set; }

        public ItemPricing() { }
        public ItemPricing(decimal _basic, decimal _transportPercent, decimal _transport,
                          decimal _miscPercent, decimal _misc,
                          decimal _vatPercent, decimal _vat,
                          decimal _discountPercent, decimal _discount,
                          decimal _wholesaleMargin, decimal _wholesale,
                          decimal _retailMargin, decimal _retail,
                          decimal _purchaseValue, PurchaseOrder _purchase, Item item,
                          int _netWeight, int _grossWeight,
                          DateTime _manufactureDate, DateTime _expiredDate)
        {
            this.Basic = _basic;

            this.TransportPercent = _transportPercent;
            this.Transport = _transport;

            this.MiscPercent = _miscPercent;
            this.Misc = _misc;

            this.VAT = _vat;
            this.VATPercent = _vatPercent;

            this.DiscountPercent = _discountPercent;
            this.Discount = Discount;

            this.WholesaleMargin = _wholesaleMargin;
            this.Wholesale = _wholesale;

            this.Retail = _retail;
            this.RetailMargin = _retailMargin;

            this.Purchase = _purchase;
            this.PurchaseValue = _purchaseValue;

            this.Item = item;

            this.NetWeight = _netWeight;
            this.GrossWeight = _grossWeight;

            this.ManufacturedDate = _manufactureDate;
            this.ExpiredDate = _expiredDate;
        }
    }

    public class ItemSKU
    {
        public virtual int ID { get; set; }
        public virtual Item Item { get; set; }

        public virtual int StockQuantity { get; set; }
        public virtual decimal WholesalePrice { get; set; }
        public virtual decimal ResalePrice { get; set; }

        public ItemSKU() { }
        public ItemSKU(Item item, int _stockQuantity, decimal _resalePrice, decimal _wholesalePrice)
        {
            this.Item = item;

            this.StockQuantity = _stockQuantity;
            this.ResalePrice = _resalePrice;
            this.WholesalePrice = _wholesalePrice;
        }
    }

    public class Package
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Weight { get; set; }
        public virtual bool IsStocked { get; set; }

        public Package() { }
        public Package(string _name, int _weight, bool _isStocked)
        {
            this.Name = _name;
            this.Weight = _weight;
            this.IsStocked = _isStocked;
        }
    }
}
