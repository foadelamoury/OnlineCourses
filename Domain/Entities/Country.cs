namespace Domain.Entities;



public class Country : ObjectBase

{

    public string? NameA { get; set; }
    public string? NameE { get; set; }


    public int ParentId { get; set; }

    public Country? Parent { get; set; }

}