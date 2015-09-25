using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    public class Customer
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Mobile_No { get; set; }
        public virtual string Phone_No { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }

        public Customer() { }
        public Customer(string _name, string _mobileNo, string _phoneNo, string _address = "", string _email = "")
        {
            this.Name = _name;
            this.Mobile_No = _mobileNo;
            this.Phone_No = _phoneNo;
            this.Address = _address;
            this.Email = _email;
        }
    }
}
