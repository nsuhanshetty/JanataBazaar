using JanataBazaar.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Savers
{
    class ItemSKUSavers
    {
        static ILog log = LogManager.GetLogger(typeof(ItemSKUSavers));

        public static bool SaveSKUInfo(ItemSKU  skuItem)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(skuItem);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }

        public static bool UpdateSKUList(ItemSKU _skuItem, List<ItemSKU> toDeleteSKUItemList)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_skuItem);

                        //Delete SKU
                        foreach (var skuItem in toDeleteSKUItemList)
                        {
                            /*
                            skuItem.StockQuantity = 0;
                            session.SaveOrUpdate(skuItem);
                            */
                            session.Delete(skuItem);
                        }
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }
    }
}
