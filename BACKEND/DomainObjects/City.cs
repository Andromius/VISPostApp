using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DomainObjects
{
    public class City
    {
        public int CityID { get; set; }
        public Area? Area { get; set; }
        public string Name { get; set; }

        public City(int cityID, string name)
        {
            CityID = cityID;
            Name = name;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n\tID: {CityID}").Append("\n\tName: " + Name);
            return stringBuilder.ToString();
        }
    }
}
