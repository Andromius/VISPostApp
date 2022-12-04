using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public City City { get; set; }
        public Address(int id, string street, int zipCode, City city)
        {
            AddressID = id;
            Street = street;
            ZipCode = zipCode;
            City = city;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n\tID: {AddressID} ").Append("\n\tStreet: " + Street).Append($"\n\tZip code: {ZipCode}").Append($"\n\tCity: {City.ToString()}");
            return stringBuilder.ToString();
        }
    }
}
