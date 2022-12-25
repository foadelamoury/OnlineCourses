using System.Collections.ObjectModel;

namespace Domain.Entities;


public class Student : ObjectBase<int>
{
    public string Name { get; set; }

    public int CountryId { get; set; }

    public int CityId { get; set; }

    public string PhoneNumberA { get; set; }

  public string PhoneNumberB { get; set; }

  public string PhotoName { get; set; }


}