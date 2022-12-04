using DataAccess.DataAccess;
using DomainObjects.DomainObjects;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Package p = new PackageDataMapper().FindByCode(10566576);
            p.GetCourier(new CourierDataMapper());
            Console.WriteLine(p);
            //p.GetSpecialFeatures(new SpecialFeaturesDataMapper());
            //Console.WriteLine(p);
            //p.Address
        }
    }
}