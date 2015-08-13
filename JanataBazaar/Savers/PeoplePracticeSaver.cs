using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Threading.Tasks;
using JanataBazaar.Model;
using log4net;

namespace JanataBazaar.Savers
{
    public class PeoplePracticeSaver
    {
        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeSaver));
        public static bool SaveVendorInfo(Vendor vendor)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(vendor);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }
    }
}
