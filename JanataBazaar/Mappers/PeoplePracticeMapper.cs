using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanataBazaar.Model;
using FluentNHibernate.Mapping;

namespace JanataBazaar.Mappers
{
    class PeoplePracticeMapper
    { }

    class VendorMapper : ClassMap<Vendor>
    {
       public VendorMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.TIN);
            Map(x => x.PLP);
            Map(x => x.CST);

            Map(x => x.Name);
            Map(x => x.MobileNo);
            Map(x => x.PhoneNo);
            Map(x => x.Address);

            Map(x => x.BankName);
            Map(x => x.IFSCCode);
            Map(x => x.BankUserName);
            Map(x => x.AccNo);

            Map(x => x.DurationTerm);
            Map(x => x.DurationCount);
        }
    }
}
