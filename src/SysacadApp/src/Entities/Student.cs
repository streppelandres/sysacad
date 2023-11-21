using Entities.Relationships;

namespace Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
