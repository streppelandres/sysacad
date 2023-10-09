using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Student.Queries.GetStudentScheduleQuery
{
    public class GetStudentScheduleQuery : IRequest<ResponseWrapper<ICollection<GetStudentScheduleQueryResponse>>>
    {
        public int StudentId { get; set; }
    }

    public class GetStudentScheduleQueryHandler : IRequestHandler<GetStudentScheduleQuery, ResponseWrapper<ICollection<GetStudentScheduleQueryResponse>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Student> _studentRepositoryAsync;
        private readonly IRepositoryAsync<Domain.Entities.Course> _courseRepositoryAsync;

        public GetStudentScheduleQueryHandler(IRepositoryAsync<Domain.Entities.Student> studentRepositoryAsync,
            IRepositoryAsync<Domain.Entities.Course> courseRepositoryAsync)
        {
            _studentRepositoryAsync = studentRepositoryAsync;
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        public async Task<ResponseWrapper<ICollection<GetStudentScheduleQueryResponse>>> Handle(GetStudentScheduleQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepositoryAsync.GetByIdAsync(request.StudentId);
            if (student == null) throw new ApiException($"Student {request.StudentId} not found");

            // Creates other specification where filter status new or in progress
            var courses = await _courseRepositoryAsync.ListAsync(new CourseByStudentIdSpecification(request.StudentId));
            if (!courses.Any()) throw new ApiException($"Students courses not found");

            var response = courses.Select(course => new GetStudentScheduleQueryResponse
            {
                Name = course.Name,
                Division = course.Division,
                Schedules = course.Schedules.Select(schedule => new ScheduleDto
                {
                    DayOfWeek = schedule.DayOfWeek,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime
                }).ToList()
            }).ToList();

            return new ResponseWrapper<ICollection<GetStudentScheduleQueryResponse>>
            (
                data: response,
                message: $"Student {request.StudentId} schedule succesfully generated"
            );
        }
    }
}
