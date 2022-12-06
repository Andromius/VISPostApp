using DomainObjects.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public class City
    {
        public int? CityID { get; set; }
        public int? AreaID { get; set; }
        public Area? Area { get; set; }
        public string Name { get; set; }

        public City(int cityID, string name, int areaID)
        {
            CityID = cityID;
            Name = name;
            AreaID = areaID;
            Area = null;
        }
        public City(string name)
        {
            CityID = null;
            Name = name;
            AreaID = null;
            Area = null;
        }

        public Area GetArea(IAreaDataMapper areaDataMapper)
        {
            if (Area is null)
                return Area = areaDataMapper.FindByID(AreaID.Value);
            return Area;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n\tID: {CityID}").Append("\n\tName: " + Name);
            return stringBuilder.ToString();
        }
    }
}
