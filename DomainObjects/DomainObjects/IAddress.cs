namespace DomainObjects.DomainObjects
{
    public interface IAddress
    {
        int AddressID { get; set; }
        City City { get; set; }
        string Street { get; set; }
        int ZipCode { get; set; }

        string ToString();
    }
}