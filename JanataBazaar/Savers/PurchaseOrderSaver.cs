using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace JanataBazaar.Savers
{
    class PurchaseOrderSaver
    {
        static ILog log = LogManager.GetLogger(typeof(PurchaseOrderSaver));

        public static bool SaverPurchaseOrder(PurchaseOrder order)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var itemsku in order.SKUItems)
                        {
                            itemsku.Purchase = order;

                            if (itemsku.Item.InReserve && itemsku.Item.ReserveStock > (itemsku.PackageQuantity * itemsku.QuantityPerPack))
                                itemsku.Item.InReserve = true;
                            else
                                itemsku.Item.InReserve = false;
                        }

                        foreach (var price in order.Price)
                        {
                            price.Purchase = order;
                        }

                        session.SaveOrUpdate(order);
                        tx.Commit();
                        log.Info("Purchase Order Added.");
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return false;
                    }
                    return true;
                }
            }
        }
    }
}
