using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface ISpecialFeaturesDataMapper
    {
        public List<SpecialFeature> FindByPackageCode(int code);
    }
}
