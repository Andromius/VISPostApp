using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public enum SpecialFeature
    { 
        Fragile,
        Expensive,
        NStdShape
    }

    public enum EDispatchStatus
    { 
        Delivered,
        NDelivered,
        Returned,
        Dispatched
    }

    public class Package
    {
        public int PackageCode { get; }
        public double Weight { get; }
        public DateOnly DateImported { get; private set; }
        public DateOnly? DateDispatched { get; private set; }
        public EDispatchStatus? DispatchStatus { get; private set; }
        public List<SpecialFeature>? SpecialFeatures { get; private set; }
        public int AddressID { get; private set; }
        public Address? Address { get; private set; }
        public Courier? Courier { get; set; }

        public Package(int packageCode, double weight, DateOnly dateImported, int addressID)
        {
            PackageCode = packageCode;
            Weight = weight;
            DateImported = dateImported;
            AddressID = addressID;
            Address = null;
            SpecialFeatures = new List<SpecialFeature>();
        }

        public Package(int packageCode, double weight, DateOnly dateImported, Address address)
        {
            PackageCode = packageCode;
            Weight = weight;
            DateImported = dateImported;
            AddressID = address.AddressID;
            Address = address;
            SpecialFeatures = new List<SpecialFeature>();
        }

        public void SetDelivered()
        {
            DispatchStatus = EDispatchStatus.Delivered;
        }

        public void SetReturned()
        {
            DispatchStatus = EDispatchStatus.Returned;
        }

        public void SetNotDelivered()
        {
            DispatchStatus = EDispatchStatus.NDelivered;
        }

        public void SetDispatched()
        {
            DispatchStatus = EDispatchStatus.Dispatched;
        }

        public bool AddSpecialFeature(SpecialFeature specialFeature)
        {
            if (SpecialFeatures.Count > 0)
            {
                foreach (SpecialFeature sf in SpecialFeatures)
                {
                    if (specialFeature == sf)
                    {
                        return false;
                    }
                }
            }
            SpecialFeatures.Add(specialFeature);
            return true;
        }

        public bool RemoveSpecialFeature(SpecialFeature specialFeature)
        {
            if (SpecialFeatures.Count > 0)
            {
                return SpecialFeatures.Remove(specialFeature);
            }
            return false;
        }

        public void SetDateDispatched()
        {
            DateDispatched = DateOnly.FromDateTime(DateTime.Now);
        }

        public void SetDateImported()
        {
            DateImported = DateOnly.FromDateTime(DateTime.Now);
        }

        //public void GetAddress()
        //{
        //    if(Address is null)
        //        Address = new AddressDataMapper().FindByID(AddressID);
        //}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\nPackage: {PackageCode} ").Append($"\n\tWeight: {Weight} ").Append($"\n\tDate Imported: {DateImported} ");
            stringBuilder.Append("\n\tDate Dispatched: ").Append(DateDispatched.HasValue? $"{DateDispatched} " : "null ");
            stringBuilder.Append("\n\tDispatch Status: ").Append(DispatchStatus.HasValue? $"{DispatchStatus} " : "null ");
            stringBuilder.Append("\n\tSpecial Features: ").Append(SpecialFeatures == null ? "xyz " : "null ");
            stringBuilder.Append(Address is null ? $"\n\tAddress ID: {AddressID}" : $"\n\tAddress: {Address}").Append("\n\tCourier ID: ").Append(Courier is not null ? Courier.CourierID : "null ");
            return stringBuilder.ToString();
        }
    }
}
