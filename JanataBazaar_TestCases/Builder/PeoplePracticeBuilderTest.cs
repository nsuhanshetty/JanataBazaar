using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JanataBazaar.Builders;
using JanataBazaar.Model;

namespace JanataBazaar_TestCases.Builder
{
    public class PeoplePracticeBuilderTest
    {
        [TestCase("", "")]
        public void GetVendorsList(string name, string mobileno)
        {
            IList<Vendor> vendList = PeoplePracticeBuilder.GetVendorsList(name, mobileno);
            Assert.IsTrue(vendList.Count != 0);
        }
    }
}
