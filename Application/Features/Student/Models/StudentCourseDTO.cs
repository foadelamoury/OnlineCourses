using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Student.Models
{
    public class StudentCourseDTO
    {
        public long? Id { get; set; }
        public long[]? CourseIds { get; set; }
        
    }
}
