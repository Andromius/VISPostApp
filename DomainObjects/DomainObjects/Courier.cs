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
        public int CourierID { get; }
        public int AreaID { get; }
        public Area? AssignedArea { get; private set; }
        public List<Package> Packages { get; private set; }

        public Courier(int userID, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork, int courierID, int areaID) : base(userID, firstName, lastName, dateHired, login, password, atWork)
        {
            CourierID = courierID;
            AreaID = areaID;
            AssignedArea = null;
            Packages = new List<Package>();
        }
        public Courier(int userID, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork, int courierID, Area area) : base(userID, firstName, lastName, dateHired, login, password, atWork)
        {
            CourierID = courierID;
            AreaID = area.AreaID;
            AssignedArea = area;
            Packages = new List<Package>();
        }
        public void AddPackage(Package p)
        {
            p.Courier = this;
            Packages.Add(p);
        }

        public void GetArea(IAreaDataMapper areaDataMapper)
        {
            AssignedArea = areaDataMapper.FindByID(AreaID);
        }
    }
}
