using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public class SpecialFeature
    {
        public int SpecialFeatureID { get; set; }
        public string Name { get; set; }

        public SpecialFeature(int specialFeatureID, string name) 
        {
            SpecialFeatureID = specialFeatureID;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
