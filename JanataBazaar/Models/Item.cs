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

        public Item() { }

        public Item(string _name, string _quantityUnit, Section _section)
        {
            this.Name = _name;
            this.QuantityUnit = _quantityUnit;
            this.Section = _section;
        }
    }

    public class ItemSKU
    {
        public virtual int ID { get; set; }
        public virtual int ItemID { get; set; }
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
    }
}
