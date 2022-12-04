using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface ICourierDataMapper
    {
        public Courier FindByUserID(Courier c);
        public Courier FindByCourierID(int id);
    }
}
