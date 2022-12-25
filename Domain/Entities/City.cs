namespace Domain.Entities;


public class City : ObjectBase<int>
{

    public string Name { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; }


}