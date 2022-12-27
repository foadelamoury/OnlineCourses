using System.Collections.ObjectModel;

namespace Domain.Entities;



public class CourseCategory : ObjectBase
{

    public string? NameA { get; set; }
    public string? NameE { get; set; }
    private Collection<Course>? Courses { get; set; }

}