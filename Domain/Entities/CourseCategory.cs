using System.Collections.ObjectModel;

namespace Domain.Entities;



public class CourseCategory : ObjectBase<int>
{

    public string Name;


    Collection<Course> courses;

}