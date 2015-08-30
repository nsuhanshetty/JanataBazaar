﻿using JanataBazaar.Models;
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
        public static IList GetSCFReport(string name = "", string brand = "", string section = "")
        {
            ItemSKU itemSKUAlias = null;
            Item itemAlias = null;
            Section sectionAlias = null;

            using (var session = NHibernateHelper.OpenSession())
            {
                IList list = (from itm in (session.QueryOver<ItemSKU>(() => itemSKUAlias)
                                            .JoinAlias(i => i.Item, () => itemAlias)
                                            .JoinAlias(() => itemAlias.Section, () => sectionAlias)
                                            .Where(() => itemAlias.Name.IsLike(name + "%"))
                                            .Where(() => itemAlias.Brand.IsLike(brand + "%"))
                                            .Where(() => sectionAlias.Name.IsLike(section + "%"))
                                            .Take(15)
                                            .List())
                              select new
                              {
                                  itm.Item.Name,
                                  itm.Item.Brand,
                                  PackageType = itm.Package.Name,
                                  itm.PackageQuantity,
                                  itm.QuantityPerPack,
                                  itm.PurchaseValue,
                                  TotalPurchase = itm.TotalPurchaseValue,
                                  itm.Wholesale,
                                  TotalWholesale = itm.TotalWholesaleValue,
                                  itm.Retail,
                                  TotalResale = itm.TotalResaleValue
                              })
                              .ToList();
                return list;
            }
        }
    }
}