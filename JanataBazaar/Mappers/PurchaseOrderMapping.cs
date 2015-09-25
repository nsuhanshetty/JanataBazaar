using FluentNHibernate.Mapping;
using JanataBazaar.Model;
using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Mappers
{
    class PurchaseOrderMapping : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.SCFNo);
            Map(x => x.IRNNo);
            Map(x => x.BillNo);
            Map(x => x.DateOfPurchase);
            Map(x => x.DateOfInvoice);
            Map(x => x.BillType);
            References(x => x.Vendor).Class<Vendor>()
                            .Columns("VendorID")
                            .Cascade.None();
            Map(x => x.TotalPurchasePrice);
            Map(x => x.TotalWholesalePrice);
            Map(x => x.TotalResalePrice);
            HasMany(x => x.SKUItems).KeyColumn("PurchaseID")
                                    .Inverse()
                                    .Cascade.All();
            HasMany(x => x.Price).KeyColumn("PurchaseID")
                                   .Inverse()
                                   .Cascade.All();
        }
    }
}
