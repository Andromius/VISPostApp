using DataAccess.DataAccess;
using DomainObjects.DomainObjects;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Package p = new PackageDataMapper().FindByCode(10274908);
            Console.WriteLine(p);
            p.GetAddress(new AddressDataMapper());
            Console.WriteLine(p);
            p.GetSpecialFeatures(new SpecialFeaturesDataMapper());
            Console.WriteLine(p);
        }
    }
}