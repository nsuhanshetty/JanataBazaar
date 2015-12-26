using JanataBazaar.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class PurchaseBillBuilder
    {
        public static List<string> GetPackageTypes()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<string> packageTypes=new List<string>();
                packageTypes.Add("");
                packageTypes.AddRange((from pack in session.Query<Package>()
                                       select pack.Name).Distinct().ToList());
                return packageTypes;
            }
        }

        //public static List<string> GetVatPerventages(DateTime vatRevisonDate)
        //{
        //    using (var session  = NHibernateHelper.OpenSession())
        //    {
        //        var percentageList = session.QueryOver<VATPercent>()
        //    }
        //}

        public static List<PurchaseOrder> GetPurchaseOrderList(DateTime fromDate, DateTime toDate, bool isCredit)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                PurchaseOrder purchaseOrderAlias = null;
                List<PurchaseOrder> purchaseOrderList = session.QueryOver<PurchaseOrder>(() => purchaseOrderAlias)
                                                        .Fetch(p => p.Vendor).Eager
                                                        .Fetch(p => p.Revision).Eager
                                                        .Where(() => purchaseOrderAlias.IsCredit == isCredit)
                                                        .Where(() => purchaseOrderAlias.DateOfInvoice.Date >= fromDate.Date && purchaseOrderAlias.DateOfInvoice.Date <= toDate.Date)
                                                        .List().ToList();
                foreach (var item in purchaseOrderList)
                {
                    var order = session.QueryOver<PurchaseOrder>()
                               .Fetch(o => o.ItemPriceList).Eager
                               .List().ToList();
                }

                return purchaseOrderList;
            }
        }

        public static PurchaseOrder GetPurchaseOrder(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var purchaseOrder = session.QueryOver<PurchaseOrder>()
                                        .Fetch(p=>p.ItemPriceList).Eager.Future()
                                        .Where(p => p.ID == _ID)
                                        .SingleOrDefault();
                purchaseOrder.ItemPriceList = session.QueryOver<ItemPricing>()
                                        .Fetch(p => p.Item).Eager.Future()
                                        .Where(p => p.ID == _ID)
                                        .ToList(); 
                return purchaseOrder;
            }
        }
    }
}
