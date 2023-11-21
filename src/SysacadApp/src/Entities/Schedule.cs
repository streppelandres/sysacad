
namespace Entities
{
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public Day Day { get; set; }
        public DateTime StartTime { get; set; } // TimeOnly
        public DateTime EndTime { get; set; } // TimeOnly
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
