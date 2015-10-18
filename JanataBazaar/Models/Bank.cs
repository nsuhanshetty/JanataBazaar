using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    public class Bank
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }

        public Bank() { }
        public Bank(string name)
        {
            this.Name = name;
        }
    }
}
