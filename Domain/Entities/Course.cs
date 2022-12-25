namespace Domain.Entities;


public class Course : ObjectBase<int>

{

    public string Name;

    public int CreditHours;

    public int CourseCategoryId;

    public CourseCategory CourseCategory;




}