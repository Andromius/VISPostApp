using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface ICityDataMapper
    {
        public City FindByID(int id);
        public City FindByName(string name);
        public List<City> FindByAreaID(int areaId);
        public bool Update(City city);
        public bool Create(City city);

    }
}
