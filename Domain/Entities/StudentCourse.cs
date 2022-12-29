namespace Domain.Entities;


public class StudentCourse : ObjectBase
{
    public long CourseId { get; set; }

    public Course? Course { get; set; }

    public long StudentId { get; set; }

    public Student? Student { get; set; }

}