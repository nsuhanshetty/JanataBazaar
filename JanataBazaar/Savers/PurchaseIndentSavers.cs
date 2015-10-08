using JanataBazaar.Models;
using log4net;
using System;
using System.Collections.Generic;
using NHibernate.Util;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Savers
{
    class PurchaseIndentSavers
    {
        static ILog log = LogManager.GetLogger(typeof(PurchaseIndentSavers));

        public static bool SavePurchaseIndent(PurchaseIndent indent)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        indent.IndentItemsList.ForEach(x => x.PurchaseIndent = indent);
                        session.SaveOrUpdate(indent);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Info("Saving Purchase Indent Failed.");
                        log.Error(ex);
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
