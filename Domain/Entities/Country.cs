namespace Domain.Entities;



public class Country : ObjectBase

{

    public string? NameA { get; set; }
    public string? NameE { get; set; }


    public int CountryId { get; set; }

    public Country Countries { get; set; }

}