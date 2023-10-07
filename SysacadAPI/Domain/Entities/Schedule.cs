

namespace Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; } // TODO: Type
        public string EndTime { get; set; } // TODO: Type
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
