using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services.CountServices
{
    public class CountService
    {

        public CountService()
        {
        }

        public double CountWeight(List<Package> packages)
        {
            double weight = 0;
            foreach (Package item in packages)
            {
                weight += item.Weight;
            }
            return Math.Round(weight*10)/10;
        }

        public int CountSpFt(List<Package> packages, ISpecialFeaturesDataMapper specialFeaturesDataMapper)
        {
            int count = 0;
            foreach (Package item in packages)
            {
                count += item.GetSpecialFeatures(specialFeaturesDataMapper).Count == 0 ? 0 : 1;
            }
            return count;
        }
    }
}
