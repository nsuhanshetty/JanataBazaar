using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using JanataBazaar.Models;

namespace JanataBazaar.Mappers
{
    class ItemTypeMapping : ClassMap<Section>
    {
        public ItemTypeMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
        }
    }

    class ItemMapping : ClassMap<Item>
    {
        public ItemMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            References(x => x.Section).Class<Section>()
                                    .Columns("SectionID")
                                    .Cascade.None();
            Map(x => x.QuantityUnit);
            Map(x => x.Brand);
            Map(x => x.IsVatExempted);
            Map(x => x.VatPercent);
            Map(x => x.ReserveStock);
            Map(x => x.InReserve);
        }
    }

    class SKUMapping : ClassMap<ItemSKU>
    {
        public SKUMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.Purchase).Class<PurchaseOrder>()
                                     .Columns("PurchaseID")
                                     .Cascade.None();
            References(x => x.Package).Class<Package>()
                                     .Columns("PackageID")
                                     .Cascade.None();
            References(x => x.Item).Class<Item>()
                                    .Columns("ItemID")
                                    .Cascade.None();

            Map(x => x.ManufacturedDate);
            Map(x => x.ExpiredDate);
            Map(x => x.Basic);
            Map(x => x.TransportPercent);
            Map(x => x.Transport);
            Map(x => x.MiscPercent);
            Map(x => x.Misc);
            Map(x => x.VATPercent);
            Map(x => x.VAT);
            Map(x => x.DiscountPercent);
            Map(x => x.Discount);
            Map(x => x.WholesaleMargin);
            Map(x => x.Wholesale);
            Map(x => x.RetailMargin);
            Map(x => x.Retail);

            Map(x => x.StockQuantity);

            Map(x => x.PurchaseValue);
            Map(x => x.QuantityPerPack);
            Map(x => x.PackageQuantity);

            Map(x => x.NetWeight);
            Map(x => x.GrossWeight);

            Map(x => x.TotalPurchaseValue);
            Map(x => x.TotalWholesaleValue);
            Map(x => x.TotalResaleValue);
        }
    }

    class PackageMapping : ClassMap<Package>
    {
        public PackageMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Weight);
            Map(x => x.IsStocked);
        }
    }

    class ItemPricingMapping : ClassMap<ItemPricing>
    {
        public ItemPricingMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.Purchase).Class<PurchaseOrder>()
                                       .Columns("PurchaseID")
                                       .Cascade.None();
            References(x => x.Item).Class<Item>()
                                   .Columns("ItemID")
                                   .Cascade.None();

            Map(x => x.Basic);
            Map(x => x.TransportPercent);
            Map(x => x.Transport);
            Map(x => x.MiscPercent);
            Map(x => x.Misc);
            Map(x => x.VATPercent);
            Map(x => x.VAT);
            Map(x => x.DiscountPercent);
            Map(x => x.Discount);
            Map(x => x.WholesaleMargin);
            Map(x => x.Wholesale);
            Map(x => x.RetailMargin);
            Map(x => x.Retail);

            Map(x => x.PurchaseValue);

        }
    }
}
