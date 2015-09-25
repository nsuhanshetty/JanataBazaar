using JanataBazaar.Model;
using JanataBazaar.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    public class PeoplePracticeBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(PeoplePracticeBuilder));

        #region Vendor
        public static Vendor GetVendorInfo(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.Get<Vendor>(_ID);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        public static List<Vendor> GetVendorsList(string name = "", string mobileno = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Vendor vend= null;
                List<Vendor> vendorList = session.QueryOver<Vendor>(() => vend)
                    .Where(NHibernate.Criterion.Restrictions.On(() => vend.Name).IsLike(name + "%"))
                    .Where(NHibernate.Criterion.Restrictions.On(() => vend.MobileNo).IsLike(mobileno + "%"))
                    .List() as List<Vendor>;

                return vendorList;
            }
        }
        #endregion Vendor

        #region Customer
        public static Customer GetCustomerInfo(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.Get<Customer>(_ID);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        public static List<Customer> GetCustomerList(string name = "", string mobileno = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Customer cust= null;
                List<Customer> custList = session.QueryOver<Customer>(() => cust)
                    .Where(NHibernate.Criterion.Restrictions.On(() => cust.Name).IsLike(name + "%"))
                    .Where(NHibernate.Criterion.Restrictions.On(() => cust.Mobile_No).IsLike(mobileno + "%"))
                    .List() as List<Customer>;

                return custList;
            }
        }
        #endregion Customer
    }
}
