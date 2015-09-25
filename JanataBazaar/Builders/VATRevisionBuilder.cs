using JanataBazaar.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class VATRevisionBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(VATRevisionBuilder));
        public static List<VATRevision> GetVATRevisionList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<VATRevision> revList = (from rev in session.QueryOver<VATRevision>()
                                             select new { rev.DateOfRevision }).List() as List<VATRevision>;
                return revList;
            }
        }
    }
}
