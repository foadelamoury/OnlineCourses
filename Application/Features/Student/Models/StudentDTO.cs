namespace Application.Features.Student.Models
{
    public class StudentDTO : GlobalModels.GlobalModel
    {

        public string Name { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }
    }
}
