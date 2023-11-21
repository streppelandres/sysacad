
using Entities.Relationships;

namespace Entities
{
    public enum Quarter { First = 1, Second = 2, Third = 3, Fourth = 4 }
    public enum Shift { Morning = 1, Late = 2, Night = 3 }
    public enum CourseStatus { New = 0, InProgress = 1, Completed = 2, Canceled = 3 }

    public class Course
    {
        public virtual int CourseId { get; set; }
        public CourseStatus Status { get; set; }
        public string Division { get; set; }
        public DateTime StartDate { get; set; } // DateOnly
        public DateTime EndDate { get; set; } // DateOnly
        public Quarter Quarter { get; set; }
        public Shift Shift { get; set; }
        public string Room { get; set; }
        public int Code { get; set; }
        public short Capacity { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; } = null!;
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
