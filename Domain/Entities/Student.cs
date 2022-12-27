using System.Collections.ObjectModel;

namespace Domain.Entities;


public class Student : ObjectBase
{
    public string? NameA { get; set; }
    public string? NameE { get; set; }
    public int CountryId { get; set; }

    public int CityId { get; set; }

   
  public string? PhotoName { get; set; }


}