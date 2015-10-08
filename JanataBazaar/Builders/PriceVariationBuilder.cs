using JanataBazaar.Models;
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
    class PriceVariationBuilder
    {
        public static List<object[]> GetPriceVariationItems()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                ItemSKU itemSKUAlias = null;
                Item itemAlias = null;

                var results = session.QueryOver(() => itemSKUAlias)
                                     .JoinAlias(() => itemSKUAlias.Item, () => itemAlias)
                                     .SelectList(list => list
                                                         .SelectGroup(() => itemAlias.ID)
                                                         .Select(() => itemAlias.Name)
                                                         .Select(() => itemAlias.Brand)
                                                         .Select(() => itemAlias.QuantityUnit))
                                     .Where(Restrictions.Gt(Projections.Count(Projections.Property(() => itemAlias.ID)), 1))
                                     .List<object[]>();
                return results.ToList();
            }
        }

        public static List<ItemSKU> GetPriceVariation(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var itemSKUList = (from itemsku in
                                        (session.Query<ItemSKU>()
                                        .Where(itemsku => itemsku.Item.ID == _ID)
                                        .Fetch(x => x.Item))
                                   select itemsku)
                                   .ToList();
                return itemSKUList;
            }
        }
    }
}
