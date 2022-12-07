using DomainObjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public class Courier : User
    {
        public int? CourierID { get; set; }
        public int? AreaID { get; set; }
        private Area? AssignedArea { get; set; }
        public List<Package> Packages { get; private set; }

        public Courier(int userID, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork, int? courierID = null, int? areaID = null) : base(userID, firstName, lastName, dateHired, login, password, atWork)
        {
            CourierID = courierID;
            AreaID = areaID;
            AssignedArea = null;
            Packages = null;
        }
        public Courier(int userID, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork, int courierID, Area area) : base(userID, firstName, lastName, dateHired, login, password, atWork)
        {
            CourierID = courierID;
            AreaID = area.AreaID;
            AssignedArea = area;
            Packages = new List<Package>();
        }
        public void AddPackage(Package p, IPackageDataMapper packageDataMapper)
        {
            if (!Packages.Contains(p))
            {
                p.CourierID = CourierID;
                packageDataMapper.Update(p);
                Packages.Add(p);
            }
        }

        public List<Package> GetPackages(IPackageDataMapper packageDataMapper) 
        {
            if (Packages is null)
                return Packages = packageDataMapper.FindByCourierID(CourierID.Value);
            return Packages;
        }

        public Area GetArea(IAreaDataMapper areaDataMapper)
        {
            if (AssignedArea is null)
                return AssignedArea = areaDataMapper.FindByID(AreaID.Value);
            return AssignedArea;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Role: {nameof(Courier)}");
            stringBuilder.AppendLine($"CourierID: {CourierID}");
            stringBuilder.AppendLine($"Packages amm: {Packages.Count}");
            stringBuilder.AppendLine(AssignedArea is null ? $"Area: {AreaID}" : $"Area: {AssignedArea}");
            return base.ToString() + stringBuilder.ToString();
        }
    }
}
