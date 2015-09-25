using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Threading.Tasks;
using JanataBazaar.Model;
using log4net;
using JanataBazaar.Models;

namespace JanataBazaar.Savers
{
    public class PeoplePracticeSaver
    {
        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeSaver));

        #region Vendor
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
        #endregion Vendor

        #region Customer
        public static bool SaveCustomerInfo(Customer _customer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_customer);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }
        #endregion Customer
    }
}
