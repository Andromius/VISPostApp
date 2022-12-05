using DomainObjects.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IdentityMaps
{
    public class PackageIdentityMap
    {
        private static Dictionary<int, Package> IdentityMap = new Dictionary<int, Package>();
        public static void Insert(Package p)
        {
            IdentityMap.Add(p.PackageCode, p);
        }
        public static Package Get(int code)
        {
            return IdentityMap[code];
        }
        public static void Clear()
        {
            IdentityMap.Clear();
        }
    }
}
