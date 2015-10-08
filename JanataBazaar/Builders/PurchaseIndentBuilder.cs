using JanataBazaar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class PurchaseIndentBuilder
    {
        public static List<ItemSKU> GetItemsInReserve()
        {
            Item itemAlias = null;
            ItemSKU itemSKUAlias = null;
            using (var session = NHibernateHelper.OpenSession())
            {
                List<ItemSKU> list = session.QueryOver<ItemSKU>(() => itemSKUAlias)
                                     .JoinAlias(() => itemSKUAlias.Item, () => itemAlias)
                                     .Where(() => itemAlias.InReserve == true)
                                     .List().ToList();
                return list;
            }
        }

        public static List<PurchaseItemIndent> GetItemAvgConsumption(List<PurchaseItemIndent> indentList)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                foreach (var item in indentList)
                {
                    Sale saleAlias = null;
                    SaleItem saleItemAlias = null;
                    int consumPerYear = session.QueryOver(() => saleAlias)
                                          .JoinAlias(() => saleAlias.Items, () => saleItemAlias)
                                          .Where(() => saleItemAlias.Item == item.Item)
                                          .Where(s => s.DateOfSale <= DateTime.Today.Date.AddYears(-1) &&
                                                      s.DateOfSale <= DateTime.Today.Date)
                                          .RowCount();
                    item.AvgConsumption = consumPerYear == 0 ? 0 : consumPerYear / 12;
                }
            }
            return indentList;
        }

        public static List<PurchaseIndent> GetIndentList(DateTime fromDate, DateTime toDate)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<PurchaseIndent> list = session.QueryOver<PurchaseIndent>()
                                         .Where(p => p.DateOfIndent >= fromDate && p.DateOfIndent <= toDate)
                                         .List().ToList();
                return list;
            }
        }

        public static PurchaseIndent GetPurchaseIndent(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                PurchaseIndent indent = session.QueryOver<PurchaseIndent>()
                                        .Where(x => x.ID == _ID)
                                        .SingleOrDefault();

                indent.IndentItemsList = session.QueryOver<PurchaseItemIndent>()
                                        .Where(x => x.PurchaseIndent == indent)
                                        .Fetch(x => x.Item).Eager
                                        .Future()
                                        .ToList();

                return indent;
            }
        }
    }
}