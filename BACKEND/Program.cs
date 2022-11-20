using BACKEND.DataAccess;
using BACKEND.DomainObjects;
using System.Data;
using System.Data.SqlClient;

namespace BACKEND
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Package test = new PackageDataMapper().FindByCode(12345678);
            if (test is not null)
            {
                Console.WriteLine(test.ToString());
            }
            //List<City> cityList = new CityDataMapper().FindByArea(1);
            //foreach (City c in cityList)
            //{
            //    Console.WriteLine(c);
            //}
            //Address addr = new AddressDataMapper().FindByID(5);
            //Console.WriteLine(addr);
        }
    }
}