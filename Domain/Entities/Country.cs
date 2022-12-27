namespace Domain.Entities;



public class Country : ObjectBase

{

    public string? NameA { get; set; }
    public string? NameE { get; set; }


    public int ParentId;

    public Country? Parent;

}