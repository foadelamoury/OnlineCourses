namespace Domain.Entities;


public class Course : ObjectBase

{

    public string? NameA { get; set; }
    public string? NameE { get; set; }

    public int CreditHours;

    public int CourseCategoryId;

    public CourseCategory? CourseCategory;




}