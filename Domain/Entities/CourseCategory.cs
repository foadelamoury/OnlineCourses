using System.Collections.ObjectModel;

namespace Domain.Entities;



public class CourseCategory : ObjectBase<int>
{

    public string NameA { get; set; }
    public string NameE { get; set; }

    Collection<Course> courses;

}