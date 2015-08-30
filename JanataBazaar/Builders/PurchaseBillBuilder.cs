using JanataBazaar.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class PurchaseBillBuilder
    {
        public static List<string> GetPackageTypes()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<string> packageTypes=new List<string>();
                packageTypes.Add("");
                packageTypes.AddRange((from pack in session.Query<Package>()
                                       select pack.Name).Distinct().ToList());
                return packageTypes;
            }
        }
    }
}
