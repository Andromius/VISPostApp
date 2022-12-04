namespace DomainObjects.DomainObjects
{
    public interface IPackage
    {
        Address? Address { get; }
        int AddressID { get; }
        Courier? Courier { get; set; }
        DateOnly? DateDispatched { get; }
        DateOnly DateImported { get; }
        EDispatchStatus? DispatchStatus { get; }
        int PackageCode { get; }
        List<SpecialFeature>? SpecialFeatures { get; }
        double Weight { get; }

        bool AddSpecialFeature(SpecialFeature specialFeature);
        void GetAddress();
        bool RemoveSpecialFeature(SpecialFeature specialFeature);
        void SetDateDispatched();
        void SetDateImported();
        void SetDelivered();
        void SetDispatched();
        void SetNotDelivered();
        void SetReturned();
        string ToString();
    }
}