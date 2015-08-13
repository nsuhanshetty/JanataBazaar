﻿//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace JanataBazaar.Model
{
    #region Customer/Staff/Group
    //[JsonObject(MemberSerialization.OptIn)]
    //public class Customer
    //{
    //    //[JsonIgnore]
    //    public virtual int ID { get; set; }

    //    [JsonProperty(PropertyName = "name")]
    //    public virtual string Name { get; set; }

    //    [JsonProperty(PropertyName = "mobile_no")]
    //    public virtual string Mobile_No { get; set; }

    //    [JsonProperty(PropertyName = "phone_no")]
    //    public virtual string Phone_No { get; set; }

    //    [JsonProperty(PropertyName = "address")]
    //    public virtual string Address { get; set; }

    //    [JsonProperty(PropertyName = "email")]
    //    public virtual string Email { get; set; }

    //    //[JsonIgnore]
    //    public virtual Image Image { get; set; }

    //    public virtual int ReferralID { get; set; }

    //    //public object updated_at { get; set; }

    //    public Customer() { }

    //    public Customer(string _name, string _mobileNo, string _phoneNo, string _address, string _email)
    //    {
    //        //this.ID = _id;
    //        this.Name = _name;
    //        this.Mobile_No = _mobileNo;
    //        this.Phone_No = _phoneNo;
    //        this.Address = _address;
    //        this.Email = _email;
    //    }
    //}

    //public class CustomerList
    //{
    //    public List<Customer> Customers { get; set; }
    //}

    //public class Staff
    //{
    //    public virtual int ID { get; set; }

    //    public virtual string Name { get; set; }

    //    public virtual string Mobile_No { get; set; }

    //    public virtual string Phone_No { get; set; }

    //    public virtual string Address { get; set; }

    //    public virtual Image Image { get; set; }

    //    public virtual bool IsTemporary { get; set; }

    //    public Staff() { }

    //    public Staff(string name, string mobNo, string phNo, string address="", bool isTempo=true)
    //    {
    //        this.Name = name;
    //        this.Mobile_No = mobNo;
    //        this.Phone_No = phNo;
    //        this.Address = address;
    //        this.IsTemporary = isTempo;
    //    }
    //}

    //public class Group
    //{
    //    public int GroupID { get; set; }

    //    public string Name { get; set; }

    //    public List<Customer> CustomerList { get; set; }
    //}
    #endregion Customer/Staff/Group

    #region Vendor
    public class Vendor
    {
        public virtual int ID { get; set; }
        public virtual string TIN { get; set; }
        public virtual string PLP { get; set; }
        public virtual string CST { get; set; }

        public virtual string Name { get; set; }
        public virtual string MobileNo { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string Address { get; set; }

        public virtual string BankName { get; set; }
        public virtual string AccNo { get; set; }
        public virtual string IFSCCode { get; set; }
        public virtual string BankUserName { get; set; }

        public virtual int DurationCount { get; set; }
        public virtual bool DurationTerm { get; set; }

        public Vendor() { }

        public Vendor(string name, string mobno, string phoneno, string address, string bankusername, string accno, 
            string bankname, string IfscNo, int dCount, bool inDays, string tin = "", string plp = "", string cst = "")
        {
            this.TIN = tin;
            this.PLP = plp;
            this.CST = cst;

            this.Name = name;
            this.MobileNo = mobno;
            this.PhoneNo = phoneno;
            this.Address = address;

            this.BankUserName = bankusername;
            this.AccNo = accno;
            this.BankName = bankname;
            this.IFSCCode = IfscNo;

            this.DurationCount = dCount;
            this.DurationTerm = inDays;
        }
    #endregion Vendor
    }
}