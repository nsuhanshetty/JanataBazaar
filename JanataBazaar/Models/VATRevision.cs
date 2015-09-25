﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    class VATRevision
    {
        public virtual int ID { get; set; }
        public virtual DateTime DateOfRevision { get; set; }
        public virtual IList<VATPercent> VATList { get; set; }

        public VATRevision() {}
        public VATRevision(DateTime dateOfRevision, List<VATPercent> vatList)
        {
            this.VATList = vatList;
            this.DateOfRevision = dateOfRevision;
        }
    }

    class VATPercent
    {
        public virtual int ID { get; set; }
        public virtual VATRevision VATRevision { get; set; }
        public virtual decimal Percent { get; set; }
    }
}
