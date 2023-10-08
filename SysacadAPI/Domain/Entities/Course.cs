
namespace Domain.Entities
{
    public class Course
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Division { get; set; }
        public string StartDate { get; set; } // TODO: Type and format % "18/07/2023", in db "20230718"
        public string EndDate { get; set; } // TODO: Type and format % "18/07/2023", in db "20230718"
        public short Quarter { get; set; } // TODO: type
        public string Shift { get; set; } // TODO: Type
        public string ClassRoom { get; set; }
        public int Code { get; set; }
        public short MaxStudents { get; set; }
        public string Status { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
