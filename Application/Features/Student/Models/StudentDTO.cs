using Microsoft.AspNetCore.Http;

namespace Application.Features.Student.Models
{
    public class StudentDTO : GlobalModels.GlobalModelWithName
    {

        public string? Name { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string? PhotoName { get; set; }

        public IFormFile? photoFile { get; set; }

    }
}
