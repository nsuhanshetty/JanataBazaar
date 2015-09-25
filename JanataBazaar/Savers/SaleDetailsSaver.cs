using JanataBazaar.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Savers
{
    class SaleDetailsSaver
    {
        static ILog log = LogManager.GetLogger(typeof(SaleDetailsSaver));

        public static bool SaveSaleDetails(Sale sale)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        //foreach (var item in sale.Items)
                        //{
                        //    item.Sale = sale;

                        //    //update item stock

                        //    //if stock less than reserve "InReserve" = true

                        //    if (itemsku.Item.ReserveStock > (itemsku.PackageQuantity * itemsku.QuantityPerPack))
                        //        itemsku.Item.InReserve = true;
                        //    else
                        //        itemsku.Item.InReserve = false;

                        //}
                        //session.SaveOrUpdate(order);
                        //tx.Commit();
                        //log.Info("Purchase Order Added.");
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
