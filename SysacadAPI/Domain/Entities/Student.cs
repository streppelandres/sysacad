

namespace Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Course> Courses { get; } = new();
    }
}
