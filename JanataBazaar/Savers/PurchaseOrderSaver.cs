using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NHibernate.Util;

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
                        //update itemprice and also check if  item is inReserve
                        foreach (var itemprice in order.ItemPriceList)
                        {
                            itemprice.Purchase = order;
                            if (itemprice.Item.InReserve && itemprice.Item.ReserveStock < (itemprice.PackageQuantity * itemprice.QuantityPerPack))
                                itemprice.Item.InReserve = false;
                        }

                        // update/create  skuItem.
                        foreach (var priceItem in order.ItemPriceList)
                        {
                            ItemSKU skuItem;

                            skuItem = Builders.ItemSKUBuilder.GetItemSKUBasedOnPrice(priceItem.Item.ID, priceItem.Retail, priceItem.Wholesale);
                            if (skuItem != null)
                                skuItem.StockQuantity += priceItem.QuantityPerPack * priceItem.PackageQuantity;
                            else
                                skuItem = new ItemSKU(priceItem.Item, priceItem.QuantityPerPack * priceItem.PackageQuantity, priceItem.Retail, priceItem.Wholesale);
                            session.SaveOrUpdate(skuItem);
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
