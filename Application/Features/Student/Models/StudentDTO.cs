using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Features.Student.Models
{
    public class StudentDTO : GlobalModels.GlobalModelWithName
    {

        public string? Name { get; set; }

        public int CountryId { get; set; }


        public string? PhotoName { get; set; }

        public IFormFile? photoFile { get; set; }

    }
}
