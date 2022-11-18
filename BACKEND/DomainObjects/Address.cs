using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DomainObjects
{
    public class Address
    {
        public int AddressID { get; set; }
        public Address(int id) 
        { 
            AddressID = id;
        }
    }
}
