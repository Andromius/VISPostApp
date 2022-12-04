using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface IAreaDataMapper
    {
        public Area FindByID(int id);
    }
}
