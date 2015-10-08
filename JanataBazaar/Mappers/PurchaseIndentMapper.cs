using FluentNHibernate.Mapping;
using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Mappers
{
    class PurchaseIndentMapper: ClassMap<PurchaseIndent>
    {
        public PurchaseIndentMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.DateOfIndent);
            HasMany<PurchaseItemIndent>(x=>x.IndentItemsList).KeyColumn("PurchaseIndentID")
                                                             .Inverse()
                                                             .Cascade.All();
        }
    }

    class PurchaseItemIndentMapper : ClassMap<PurchaseItemIndent>
    {
        public PurchaseItemIndentMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.InHandStock);
            Map(x => x.AvgConsumption);
            Map(x => x.Remark);
            Map(x => x.StockPeriod);
            References(x => x.Item).Class<Item>()
                                      .Columns("ItemID")
                                      .Cascade.None();
            References(x => x.PurchaseIndent).Class<PurchaseIndent>()
                                     .Columns("PurchaseIndentID")
                                     .Cascade.None();
        }
    }
}
