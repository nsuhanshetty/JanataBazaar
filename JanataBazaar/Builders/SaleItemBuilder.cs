using JanataBazaar.Model;
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
        public static IList GetSaleItem(string _name = null, string _brand = null, string _section = null)
        {
            IList saleItemList;
            ItemSKU itemSKUAlias = null;
            Item itemAlias = null;
            Section sectionAlias = null;

            using (var session = NHibernateHelper.OpenSession())
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
                                    itm.StockQuantity,
                                    itm.WholesalePrice
                                })
                              .ToList();
                return saleItemList;
            }
        }

        public static List<Sale> GetSalesSummary(bool isCredit, DateTime fromDate, DateTime toDate, string _consumerName, string _consumerID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Sale saleAlias = null;
                List<Sale> salesSummaryList;

                if (isCredit)
                {
                    Customer customerAlias = null;
                    salesSummaryList = session.QueryOver<Sale>(() => saleAlias)
                                        .JoinAlias(() => saleAlias.Customer, () => customerAlias)
                                        .Where(() => saleAlias.IsCredit == isCredit)
                                        .Where(s => s.DateOfSale.Date >= fromDate.Date && s.DateOfSale.Date <= toDate.Date)
                                        //.Where(Restrictions.Between("DateOfSale", fromDate, toDate))
                                        .Where(Restrictions.On(() => customerAlias.Name).IsLike(_consumerName + "%"))
                                        .Where(Restrictions.On(() => customerAlias.AccountNo).IsLike(_consumerID + "%"))
                                        .List() as List<Sale>;
                }
                else
                {
                    Member memberAlias = null;
                    salesSummaryList = session.QueryOver<Sale>(() => saleAlias)
                                       .JoinAlias(() => saleAlias.Member, () => memberAlias)
                                       .Where(() => saleAlias.IsCredit == isCredit)
                                       .Where(s => s.DateOfSale.Date >= fromDate.Date && s.DateOfSale.Date <= toDate.Date)
                                       .Where(Restrictions.On(() => memberAlias.Name).IsLike(_consumerName + "%"))
                                       .Where(Restrictions.On(() => memberAlias.MemberNo).IsLike(_consumerID + "%"))
                                       .List() as List<Sale>;
                }
                return salesSummaryList;
            }
        }
    }
}
