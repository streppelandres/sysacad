using Application.DTOs;

namespace Application.Features.Student.Queries.GetStudentScheduleQuery
{
    public class GetStudentScheduleQueryResponse
    {
        public string Name { get; set; }
        public string Division { get; set; }
        public List<ScheduleDto> Schedules { get; set; }
    }
}
