namespace Domain.Entities
{
    public class PhoneNumber : ObjectBase<int>
    {
        public string number;

        public int studentId;

        public Student Student;
    }
}
