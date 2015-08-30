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
        public virtual float VatPercent { get; set; }
        public virtual bool IsVatExempted { get; set; }
        public virtual int ReserveStock { get; set; }

        public Item() { }

        public Item(string _name, string _quantityUnit, Section _section, string _brand, bool _isExempted, float _VATPercent, int _ReserveStock)
        {
            this.Name = _name;
            this.QuantityUnit = _quantityUnit;  
            this.Section = _section;
            this.Brand = _brand;
            this.IsVatExempted = _isExempted;
            this.VatPercent = _VATPercent;
            this.ReserveStock = _ReserveStock;
        }
    }

    public class ItemSKU
    {
        public virtual int ID { get; set; }
        public virtual PurchaseOrder Purchase { get; set; }
        public virtual Item Item { get; set; }
        public virtual DateTime ManufacturedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual float Basic { get; set; }
        public virtual float TransportPercent { get; set; }
        public virtual float Transport { get; set; }
        public virtual float MiscPercent { get; set; }
        public virtual float Misc { get; set; }
        public virtual float VATPercent { get; set; }
        public virtual float VAT { get; set; }
        public virtual float DiscountPercent { get; set; }
        public virtual float Discount { get; set; }
        public virtual float WholesaleMargin { get; set; }
        public virtual float Wholesale { get; set; }
        public virtual float RetailMargin { get; set; }
        public virtual float Retail { get; set; }
        public virtual float PurchaseValue { get; set; }

        public virtual Package Package { get; set; }
        public virtual int QuantityPerPack { get; set; }
        public virtual int PackageQuantity { get; set; }

        public virtual int NetWeight { get; set; }
        public virtual int GrossWeight { get; set; }

        public virtual float TotalPurchaseValue { get; set; }
        public virtual float TotalWholesaleValue { get; set; }
        public virtual float TotalResaleValue { get; set; }
    }

    public class Package
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Weight { get; set; }
        public virtual bool IsStocked { get; set; }

        public Package()  { }

        public Package(string _name, int _weight, bool _isStocked)
        {
            this.Name = _name;
            this.Weight = _weight;
            this.IsStocked = _isStocked;
        }
    }
}
