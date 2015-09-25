using JanataBazaar.Models;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class SaleItemBuilder
    {
        public static IList GetSaleItem(string _name = null, string _brand = null, string _section=null)
        {
            IList saleItemList;
            ItemSKU itemSKUAlias = null;
            Item itemAlias = null;
            Section sectionAlias = null;

            using ( var session = NHibernateHelper.OpenSession())
            {   //name - InStock Package- items/pack - Wholesaleprice/item

                saleItemList = (from itm in (session.QueryOver<ItemSKU>(() => itemSKUAlias)
                                            .JoinAlias(() => itemSKUAlias.Item, () => itemAlias)
                                            .JoinAlias(() => itemAlias.Section, () => sectionAlias)
                                            .Where(() => itemAlias.Name.IsLike(_name + "%"))
                                            .Where(() => itemAlias.Brand.IsLike(_brand + "%"))
                                            .Where(() => sectionAlias.Name.IsLike(_section + "%"))
                                            .Take(15)
                                            .List())
                                select new
                                {
                                    itm.ID,
                                    itm.Item.Name,
                                    itm.Item.Brand,
                                    PackageType = itm.Package.Name,
                                    itm.PackageQuantity,
                                    itm.QuantityPerPack,
                                    itm.Wholesale                                   
                                })
                              .ToList();
                return saleItemList;
            }
        }
    }
}
