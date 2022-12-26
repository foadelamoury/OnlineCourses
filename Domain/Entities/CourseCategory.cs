using System.Collections.ObjectModel;

namespace Domain.Entities;



public class CourseCategory : ObjectBase<int>
{
    private Collection<Course>? courses;

    public string? NameA { get; set; }
    public string? NameE { get; set; }
    private Collection<Course>? Courses { get => courses; set => courses = value; }

}