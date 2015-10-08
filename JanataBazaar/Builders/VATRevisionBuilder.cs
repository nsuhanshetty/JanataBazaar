using JanataBazaar.Models;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Builders
{
    class VATRevisionBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(VATRevisionBuilder));

        public static VATRevision GetVATRevisionInfo(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                VATRevision revAlias = null;
                VATRevision revision = session.QueryOver<VATRevision>(() => revAlias)
                                        .Where(() => revAlias.ID == _ID)
                                        .SingleOrDefault();

                VATPercent vatPercentAlias = null;
                revision.VATList = (session.QueryOver<VATPercent>(() => vatPercentAlias)
                                    .Fetch(o => o.VATRevision).Eager
                                    .Where(() => vatPercentAlias.VATRevision.ID == _ID).List());
                return revision;
            }
        }

        public static List<VATRevision> GetVATRevisionList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<VATRevision> revList = session.QueryOver<VATRevision>()
                                            .OrderBy(v => v.DateOfRevision).Desc
                                            .List() as List<VATRevision>;
                return revList;
            }
        }

        public static List<decimal> GetVATRevisionPercentageList(int _revisionID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                VATPercent vatPercentAlias = null;
                var percentList = (from rev in (session.QueryOver<VATPercent>(() => vatPercentAlias)
                                            .Fetch(o => o.VATRevision).Eager
                                            .Where(() => vatPercentAlias.VATRevision.ID == _revisionID)
                                            .OrderBy(()=> vatPercentAlias.Percent).Asc
                                            .List())
                                            select rev.Percent).ToList();
                //var percentList = (from rev in list
                //                   select new { rev.Percent }).ToList();
                return percentList;
            }
        }

        public static int GetRevisionDate(DateTime invoiceDate)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    var revision = session.QueryOver<VATRevision>()
                                            .Where(v => v.DateOfRevision.Date <= invoiceDate.Date)
                                            .OrderBy(v => v.DateOfRevision).Desc
                                            .Take(1).SingleOrDefault();
                    return revision.ID;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return 0;
                }
            }
        }
    }
}
