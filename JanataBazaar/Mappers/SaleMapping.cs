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
    class SaleMapping : ClassMap<Sale>
    {
        public SaleMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.IsCredit);
            References(x => x.Customer).Class<Customer>()
                                       .Columns("CustomerID")
                                       .Cascade.None();
            References(x => x.Member).Class<Member>()
                                     .Columns("MemberID")
                                     .Cascade.None();
            Map(x => x.TotalRebate);
            Map(x => x.PaidAmount);
            Map(x => x.TransportCharge);
            Map(x => x.BalanceAmount);
            Map(x => x.TotalAmount);
            Map(x => x.DateOfSale);
            HasMany(x => x.Items).KeyColumn("SaleID")
                             .Inverse()
                             .Cascade.All();
        }
    }

    class SaleItemMapping : ClassMap<SaleItem>
    {
        public SaleItemMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            References(x => x.Sale).Class<Sale>()
                                   .Columns("SaleID")
                                   .Cascade.None();
            References(x => x.Item).Class<Item>()
                                   .Columns("ItemID")
                                   .Cascade.None();
            Map(x => x.Quantity);
            Map(x => x.Price);
            Map(x => x.TotalPrice);
            Map(x => x.StockCount);
        }
    }
}
