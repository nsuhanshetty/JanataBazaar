using JanataBazaar.Models;
using log4net;
using NHibernate.Util;
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

        public static bool SaveSaleDetails(Sale sale, List<ItemSKU> skuList)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        sale.Items.ForEach(x => x.Sale = sale);

                        foreach (SaleItem saleitem in sale.Items)
                        {
                            int index = sale.Items.IndexOf(saleitem);

                            ItemSKU skuitem = skuList[index];
                            skuitem.StockQuantity -= saleitem.Quantity;
                            skuitem.Item.InReserve = (skuitem.Item.ReserveStock > skuitem.StockQuantity) ? true : false;

                            session.SaveOrUpdate(skuitem);
                        }
                        session.SaveOrUpdate(sale);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Info("Purchase Order Failed.");
                        log.Error(ex);
                        return false;
                    }
                    return true;
                }
            }
        }


    }
}
