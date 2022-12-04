namespace DomainObjects.DomainObjects
{
    public interface ICity
    {
        Area? Area { get; set; }
        int? AreaID { get; set; }
        int? CityID { get; set; }
        string Name { get; set; }

        string ToString();
    }
}