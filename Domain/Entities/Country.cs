using System.Collections.ObjectModel;

namespace Domain.Entities;



public class Country : ObjectBase<int>

{

    public string? NameA { get; set; }
    public string? NameE { get; set; }


    public int ParentId;

  public Country? Parent;

}