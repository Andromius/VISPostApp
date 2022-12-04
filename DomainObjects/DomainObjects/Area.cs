using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public class Area
    {
        public int AreaID { get; set; }
        public string Name { get; set; }
        public Area(int areaID, string name)
        {
            AreaID = areaID;
            Name = name;
        }
    }
}
