

namespace Domain.Entities
{
    public class Student : User
    {
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
