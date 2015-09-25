using JanataBazaar.Models;
using log4net;
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
        public static bool SaveVATRevision(VATRevision vatRevision )
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
    }
}
