using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface IPackageDataMapper
    {
        public Package FindByCode(int code);
        public List<Package> FindByCourierID(int id);
        public void Update(Package p);
    }
}
