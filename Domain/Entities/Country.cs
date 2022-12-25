using System.Collections.ObjectModel;

namespace Domain.Entities;



public class Country : ObjectBase<int>

{

    public string Name;

    public Collection<City> cities;
}