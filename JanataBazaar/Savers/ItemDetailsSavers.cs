﻿using JanataBazaar.Models;
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
                        log.Info("Section Saved");
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

        //public static int SaveItemSku(ItemSKU _itemSKU)
        //{
        //    using (var session = NHibernateHelper.OpenSession())
        //    {
        //        using (var tx = session.BeginTransaction())
        //            try
        //            {
        //                session.SaveOrUpdate(_itemSKU);
        //                log.Info("Section Saved");
        //                return _item.ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                tx.Rollback();
        //                log.Error(ex);
        //                return 0;
        //            }
        //    }
        //}
    }
}



