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
            if(test is not null)
            {
                Console.WriteLine(test.ToString());
            }
        }
    }
}