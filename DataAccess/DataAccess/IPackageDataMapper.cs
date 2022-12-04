using DomainObjects.DomainObjects;

namespace DataAccess.DataAccess
{
    public interface IPackageDataMapper
    {
        IPackage FindByCode(int code);
    }
}