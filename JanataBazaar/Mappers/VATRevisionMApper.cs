using FluentNHibernate.Mapping;
using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Mappers
{
    class VATRevisionMapper : ClassMap<VATRevision>
    {
        public VATRevisionMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.DateOfRevision);
            HasMany(x => x.VATList).KeyColumn("VATRevisionID")
                                    .Inverse()
                                    .Cascade.All();
        }
    }

    class VATPercentMapper : ClassMap<VATPercent>
    {
        public VATPercentMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Percent);
            References(x => x.VATRevision).Class<VATRevision>()
                                            .Columns("VATRevisionID")
                                            .Cascade.None();
        }
    }
}
