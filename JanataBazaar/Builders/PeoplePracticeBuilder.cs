using JanataBazaar.Model;
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
                    .Where(NHibernate.Criterion.Restrictions.On(() => vend.Name).IsLike(mobileno + "%"))
                    .List() as List<Vendor>;

                return vendorList;
            }
        }
    }
}
