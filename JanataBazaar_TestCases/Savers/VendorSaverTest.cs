using NUnit.Framework;
using JanataBazaar.Model;
using JanataBazaar.Savers;

namespace JanataBazaar_Test
{
    public class VendorSaverTest
    {
        [TestCase("VendorNo1", "9999999999", "9999999999", "Address_UserName1", "Bankusername1", "AccnoUserNo1", "Bankname_UserName", "IFSCNo_User1", 7, true, "TIN_user1", "PLP_user1", "CST_user1")]
        [TestCase("VendorNo2", "8888888888", "7777777777", "Address_UserName2", "Bankusername2", "AccnoUserNo2", "Bank Of VendorNo2", "IFSCNo_User2", 7, true, "", "", "")]
        public static void SaveVendorsList_Test(string name, string mobno, string phoneno, string address, string bankusername, string accno, string bankname, string IfscNo, int dCount, bool inDays, string tin = "", string plp = "", string cst = "")
        {
            Vendor vendor = new Vendor(name, mobno, phoneno, address, bankname, accno, bankname, IfscNo, dCount, inDays, tin, plp, cst);
            bool response = PeoplePracticeSaver.SaveVendorInfo(vendor);
            Assert.AreEqual(true, response);
        }
    }
}
