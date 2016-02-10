using JanataBazaar.Model;
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
        public static List<PurchaseOrder> GetSCFReport(bool isCredit, string SCFNo, string nameOfSupplier, DateTime toDate, DateTime fromDate)
        {
            //ItemPricing itemPricingAlias = null;
            //Item itemAlias = null;
            //Section sectionAlias = null;
            PurchaseOrder purchaseOrderAlias = null;
            Vendor vendorAlias = null;

            using (var session = NHibernateHelper.OpenSession())
            {
                List<PurchaseOrder> list = (session.QueryOver<PurchaseOrder>(() => purchaseOrderAlias)
                                        //.JoinAlias(() => itemPricingAlias.Item, () => itemAlias)
                                        .JoinAlias(() => purchaseOrderAlias.Vendor, () => vendorAlias)
                                        //.JoinAlias(() => itemPricingAlias.Purchase, () => purchaseOrderAlias)

                                            //.JoinAlias(() => itemAlias.Section, () => sectionAlias)


                                            //.Fetch(i => i.Package).Eager
                                            //.Fetch(i => i.Purchase).Eager
                                            .Fetch(i => i.Revision).Eager

                                            .Where(() => purchaseOrderAlias.IsCredit == isCredit)
                                            .Where(() => purchaseOrderAlias.DateOfInvoice.Date >= fromDate.Date && purchaseOrderAlias.DateOfInvoice.Date <= toDate.Date)

                                            .Where(() => purchaseOrderAlias.SCFNo.IsLike(SCFNo + "%"))
                                            .Where(() => vendorAlias.Name.IsLike(nameOfSupplier + "%"))
                                            .Take(15)
                                            .List()).ToList<PurchaseOrder>();
                return list;
            }
        }

        public static List<ItemPricing> GetOrderList(int _ordNo)
        {
            PurchaseOrder purchaseOrderAlias = null;
            ItemPricing itemPricingAlias = null;
            Item itemAlias = null;

            using (var session = NHibernateHelper.OpenSession())
            {
                List<ItemPricing> _itemlist = (session.QueryOver<ItemPricing>(() => itemPricingAlias)
                                          .JoinAlias(() => itemPricingAlias.Purchase, () => purchaseOrderAlias)
                                          .JoinAlias(() => itemPricingAlias.Item, () => itemAlias)
                                          .Where(() => purchaseOrderAlias.ID == _ordNo).List()).Take(15).ToList<ItemPricing>();
                return _itemlist;
            }
        }

        /*Stock Control Form*/
        public static List<ItemPricing> GetICFReport(bool isCredit, string ICFNo, string nameOfSupplier,
                                                     DateTime toDate, DateTime fromDate, string name = "", string brand = "", string section = "")
        {
            ItemPricing itemPricingAlias = null;
            Item itemAlias = null;
            Section sectionAlias = null;
            PurchaseOrder purchaseOrderAlias = null;
            Vendor vendorAlias = null;

            using (var session = NHibernateHelper.OpenSession())
            {
                List<ItemPricing> list = (session.QueryOver(() => itemPricingAlias)
                                            .JoinAlias(() => itemPricingAlias.Item, () => itemAlias)
                                            .JoinAlias(() => itemPricingAlias.Purchase, () => purchaseOrderAlias)
                                            .JoinAlias(() => purchaseOrderAlias.Vendor, () => vendorAlias)
                                            .JoinAlias(() => itemAlias.Section, () => sectionAlias)


                                            .Fetch(i => i.Package).Eager
                                            //.Fetch(i => i.Purchase).Eager
                                            //.Fetch(i => i.Purchase.Vendor).Eager

                                            .Where(() => purchaseOrderAlias.IsCredit == isCredit)
                                            .Where(() => purchaseOrderAlias.DateOfInvoice.Date >= fromDate.Date && purchaseOrderAlias.DateOfInvoice.Date <= toDate.Date)

                                            .Where(() => purchaseOrderAlias.IRNNo.IsLike(ICFNo + "%"))
                                            .Where(() => vendorAlias.Name.IsLike(nameOfSupplier + "%"))

                                            .Where(() => itemAlias.Name.IsLike(name + "%"))
                                            .Where(() => itemAlias.Brand.IsLike(brand + "%"))
                                            .Where(() => sectionAlias.Name.IsLike(section + "%"))
                                            //.Select(() => purchaseOrderAlias.IRNNo)

                                            .List()).ToList();
                return list;
            }
        }

        /*Purchase Indent Form*/
        public static IList GetPIFReport()
        {
            Item itemAlias = null;
            Section sectionAlias = null;
            ItemPricing itemSKUAlias = null;
            using (var session = NHibernateHelper.OpenSession())
            {
                IList list = (from itm in (session.QueryOver<ItemPricing>(() => itemSKUAlias)
                           .JoinAlias(() => itemSKUAlias.Item, () => itemAlias)
                           .JoinAlias(() => itemAlias.Section, () => sectionAlias)
                           //.Where(() => sectionAlias.Name == section)
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