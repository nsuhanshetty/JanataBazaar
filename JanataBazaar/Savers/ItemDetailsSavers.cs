using JanataBazaar.Models;
using NHibernate.Linq;
using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Savers
{
    class ItemDetailsSavers
    {
        static ILog log = LogManager.GetLogger(typeof(ItemDetailsSavers));

        public static int SaveSection(Section section)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                    try
                    {
                        session.SaveOrUpdate(section);
                        tx.Commit();
                        log.Info("Section Saved");
                        return section.ID;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return 0;
                    }
            }
        }

        public static int SaveItem(Item _item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                    try
                    {
                        session.SaveOrUpdate(_item);
                        tx.Commit();
                        log.Info("Item Saved");
                        return _item.ID;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return 0;
                    }
            }
        }

        public static bool IsItemBilled(int itemID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        bool isBilled = session.Query<ItemPricing>().Any(i => i.Item.ID == itemID);
                        return isBilled;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return true;
                    }
                }
            }
        }

        public static bool DeleteItem(int itemID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        var _item = session.Get<Item>(itemID);
                        session.Delete(_item);
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

    class PackageDetailsSavers
    {
        static ILog log = LogManager.GetLogger(typeof(ItemDetailsSavers));

        public static int SavePackage(Package _pack)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_pack);
                        tx.Commit();
                        log.Info("Package type Saved");
                        return _pack.ID;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        log.Error(ex);
                        return 0;
                    }
                }
            }
        }
    }
}



