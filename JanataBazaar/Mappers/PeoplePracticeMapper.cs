﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanataBazaar.Model;
using FluentNHibernate.Mapping;
using JanataBazaar.Models;

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

            References(x => x.Bank).Class<Bank>()
                                   .Columns("BankID")
                                   .Cascade.None(); ;
            Map(x => x.IFSCCode);
            Map(x => x.BankUserName);
            Map(x => x.AccNo);

            Map(x => x.DurationTerm);
            Map(x => x.DurationCount);
        }
    }

    class BankMapping : ClassMap<Bank>
    {
        public BankMapping()
        {
            Id(x => x.ID);
            Map(x => x.Name);
        }
    }

    class CustomerMapper : ClassMap<Customer>
    {
        public CustomerMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Mobile_No);
            Map(x => x.Phone_No);
            Map(x => x.Email);
            Map(x => x.Address);

            Map(x => x.AccountNo);
            Map(x => x.PLFNo);
        }
    }

    class MemberMapper : ClassMap<Member>
    {
        public MemberMapper()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Mobile_No);
            Map(x => x.Phone_No);
            Map(x => x.Email);
            Map(x => x.Address);

            Map(x => x.MemberNo);
            Map(x => x.PLFNo);
        }
    }
}
