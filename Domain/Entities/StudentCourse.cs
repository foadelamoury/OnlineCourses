namespace Domain.Entities;


public class StudentCourse : ObjectBase<int>
{
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    public int StudentId { get; set; }

    public Student? student { get; set; }

}