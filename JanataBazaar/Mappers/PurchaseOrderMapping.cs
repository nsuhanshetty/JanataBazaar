using FluentNHibernate.Mapping;
using JanataBazaar.Model;
using JanataBazaar.Models;

namespace JanataBazaar.Mappers
{
    class PurchaseOrderMapping : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.SCFNo);
            Map(x => x.IRNNo);
            //Map(x => x.BillNo);
            References<VATRevision>(x => x.Revision).Class<VATRevision>()
                                                    .Columns("RevisionID")
                                                    .Cascade.None();
            Map(x => x.DateOfPurchase);
            Map(x => x.DateOfInvoice);
            Map(x => x.IsCredit);
            References(x => x.Vendor).Class<Vendor>()
                                     .Columns("VendorID")
                                     .Cascade.None();
            Map(x => x.TotalPurchasePrice);
            Map(x => x.TotalWholesalePrice);
            Map(x => x.TotalResalePrice);
            HasMany(x => x.ItemPriceList).KeyColumn("PurchaseID")
                                         .Inverse()
                                         .Cascade.All();
        }
    }
}
