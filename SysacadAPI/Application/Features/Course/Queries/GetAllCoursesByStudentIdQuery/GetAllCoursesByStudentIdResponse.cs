using Application.DTOs;

namespace Application.Features.Course.Queries.GetAllCoursesByStudentIdQuery
{
    public class GetAllCoursesByStudentIdResponse
    {
        public string Name { get; set; }
        public string Division { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public short Quarter { get; set; }
        public string Shift { get; set; }
        public string ClassRoom { get; set; }
        public string Status { get; set; }
        public ICollection<ScheduleDto> Schedules { get; set; }
    }
}
