using JanataBazaar.Models;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class ReportsBuilder
    {
        /*Stock Control Form*/
        public static List<ItemPricing> GetSCFReport(string name = "", string brand = "", string section = "")
        {
            ItemPricing itemSKUAlias = null;
            Item itemAlias = null;
            Section sectionAlias = null;

            using (var session = NHibernateHelper.OpenSession())
            {
                List<ItemPricing> list = (session.QueryOver<ItemPricing>(() => itemSKUAlias)
                                            .Fetch(i => i.Package).Eager
                                             .Fetch(i => i.Purchase).Eager
                                            .JoinAlias(() => itemSKUAlias.Item, () => itemAlias)
                                            .JoinAlias(() => itemAlias.Section, () => sectionAlias)
                                            .Where(() => itemAlias.Name.IsLike(name + "%"))
                                            .Where(() => itemAlias.Brand.IsLike(brand + "%"))
                                            .Where(() => sectionAlias.Name.IsLike(section + "%"))
                                            .Take(15)
                                            .List()).ToList<ItemPricing>();
                return list;
            }
        }

        /*Purchase Indent Form*/
        public static IList GetPIFReport(string section)
        {
            Item itemAlias = null;
            Section sectionAlias = null;
            ItemPricing itemSKUAlias = null;
            using (var session = NHibernateHelper.OpenSession())
            {
                IList list = (from itm in (session.QueryOver<ItemPricing>(() => itemSKUAlias)
                           .JoinAlias(() => itemSKUAlias.Item, () => itemAlias)
                           .JoinAlias(() => itemAlias.Section, () => sectionAlias)
                           .Where(() => sectionAlias.Name == section)
                           .Where(() => itemAlias.InReserve == true)
                           .List())
                              select new
                              {
                                  itm.Item.Name,
                                  itm.Item.Brand,
                                  itm.PackageQuantity,
                                  itm.QuantityPerPack,
                                  itm.Item.QuantityUnit,
                                  itm.Item.ReserveStock,
                                  itm.Item.InReserve
                              }).ToList(); ;

                return list;
            }
        }
    }
}