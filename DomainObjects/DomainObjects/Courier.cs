using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DomainObjects
{
    public class Courier : User
    {
        public int CourierID { get; }
        public Area AssignedArea { get; private set; }
        public List<Package> Packages { get; private set; }

        public void AddPackage(Package p)
        {
            p.Courier = this;
            Packages.Add(p);
        }
    }
}
