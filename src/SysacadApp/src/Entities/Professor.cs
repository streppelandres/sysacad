namespace Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
