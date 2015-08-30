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

        public static bool SaversPurchaseOrder(PurchaseOrder order)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        foreach(var itemsku in order.SKUItems)
                        {
                            itemsku.Purchase = order;
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
