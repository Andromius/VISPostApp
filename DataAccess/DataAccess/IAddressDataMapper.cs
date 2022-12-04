using DomainObjects.DomainObjects;

namespace DataAccess.DataAccess
{
    public interface IAddressDataMapper
    {
        Address FindByID(int id);
    }
}