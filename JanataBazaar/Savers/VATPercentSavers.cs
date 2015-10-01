using JanataBazaar.Models;
using log4net;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Savers
{
    class VATPercentSavers
    {
        static ILog log = LogManager.GetLogger(typeof(VATPercentSavers));
        public static bool SaveVATRevision(VATRevision vatRevision)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in vatRevision.VATList)
                        {
                            item.VATRevision = vatRevision;
                        }
                        session.SaveOrUpdate(vatRevision);
                        tx.Commit();
                        log.Info("VAT Revisied");
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        return false;
                    }
                    return true;
                }
            }
        }

        public static bool DeletePercentItems(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        var percentItem = session.Get<VATPercent>(_ID);
                        session.Delete(percentItem);
                        tx.Commit();
                        log.Info("VAT Percent Deleted");
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        return false;
                    }
                    return true;
                }
            }
        }

        public static bool IsUniqueRevisionDate(DateTime revisionDate, int _ID = 0)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    // VATRevision vatRevision = null;
                    var exists = session.Query<VATRevision>()
                          .Count(x => (x.DateOfRevision.Date == revisionDate.Date) && (x.ID != _ID)) > 0;
                    // .And(x => x.ID == _ID)
                    //   .SingleOrDefault();
                    return exists;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
