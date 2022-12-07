using DomainObjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
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
        private int AddressID { get; set; }
        private Address? Address { get; set; }
        public int? CourierID { get; set; }
        public Courier? Courier { private get; set; }

        public Package(int packageCode, double weight, DateOnly dateImported, Address address)
        {
            PackageCode = packageCode;
            Weight = weight;
            DateImported = dateImported;
            AddressID = address.AddressID;
            Address = address;
            SpecialFeatures = new List<SpecialFeature>();
        }

        public Package(int packageCode, double weight, DateOnly dateImported, DateOnly? dateDispatched, EDispatchStatus? dispatchStatus, int addressID, int? courierID = null, List<SpecialFeature>? specialFeatures = null, Address? address = null, Courier? courier = null)
        {
            PackageCode = packageCode;
            Weight = weight;
            DateImported = dateImported;
            DateDispatched = dateDispatched;
            DispatchStatus = dispatchStatus;
            SpecialFeatures = specialFeatures;
            AddressID = addressID;
            Address = address;
            CourierID = courierID;
            Courier = courier;
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

        public Address GetAddress(IAddressDataMapper addressDataMapper)
        {
            if (Address is null)
                return Address = addressDataMapper.FindByID(AddressID);
            return Address;
        }

        public List<SpecialFeature> GetSpecialFeatures(ISpecialFeaturesDataMapper specialFeaturesDataMapper)
        {
            if(SpecialFeatures is null)
                return SpecialFeatures = specialFeaturesDataMapper.FindByPackageCode(PackageCode);
            return SpecialFeatures;
        }

        public Courier GetCourier(ICourierDataMapper courierDataMapper)
        {
            if (Courier is null && CourierID is not null)
                return Courier = courierDataMapper.FindByCourierID(CourierID.Value);
            return Courier;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\nPackage: {PackageCode} ").Append($"\n\tWeight: {Weight} ").Append($"\n\tDate Imported: {DateImported} ");
            stringBuilder.Append("\n\tDate Dispatched: ").Append(DateDispatched.HasValue ? $"{DateDispatched} " : "null ");
            stringBuilder.Append("\n\tDispatch Status: ").Append(DispatchStatus.HasValue ? $"{DispatchStatus} " : "null ");
            stringBuilder.Append("\n\tSpecial Features: ");
            if (SpecialFeatures == null || SpecialFeatures.Count < 1)
                stringBuilder.Append("null ");
            else
            {
                foreach (var item in SpecialFeatures)
                {
                    stringBuilder.Append(item.Name).Append(" ");
                }
            }
            stringBuilder.Append(Address is null ? $"\n\tAddress ID: {AddressID}" : $"\n\tAddress: {Address}").Append("\n\tCourier ID: ").Append(Courier is not null ? Courier.FirstName : CourierID);
            return stringBuilder.ToString();
        }
    }
}
