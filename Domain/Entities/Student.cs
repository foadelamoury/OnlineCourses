namespace Domain.Entities;


public class Student : ObjectBase
{
    public string? NameA { get; set; }
    public string? NameE { get; set; }
    public long CountryId { get; set; }

    public long CityId { get; set; }


    public string? PhotoName { get; set; }


}