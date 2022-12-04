using DataAccess.DataAccess;
using DomainObjects.DomainObjects;
using Microsoft.AspNet.Identity;

namespace ConsoleApp1
{
    //M - abc123
    //W - JsemTheBet
    //C1 - borecJJ
    //C2 - martinbad
    //C3 - nejvicPOG
    internal class Program
    {
        static void Main(string[] args)
        {
            Package p = new PackageDataMapper().FindByCode(10566576);
            p.GetCourier(new CourierDataMapper());
            Console.WriteLine(p);
            IPasswordHasher passwordHasher = new PasswordHasher();
            Console.WriteLine(passwordHasher.HashPassword("nejvicPOG"));
            string hash = "AC91tuQ6qisjedewvBHEHjTQwJksMTqPwJl/KGt8WuSThPUpKt8Ioe1ZwgmGXhZTkw==";
            PasswordVerificationResult res = passwordHasher.VerifyHashedPassword(hash, "abc123");
            Console.WriteLine(res);
            Console.WriteLine(hash.Length);
            //p.GetSpecialFeatures(new SpecialFeaturesDataMapper());
            //Console.WriteLine(p);
            //p.Address
        }
    }
}