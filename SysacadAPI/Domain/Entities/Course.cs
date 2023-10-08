using Domain.Common;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Division { get; set; }
        public short Quarter { get; set; }
        public string ClassRoom { get; set; }
        public int Code { get; set; }
        public short MaxStudents { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
