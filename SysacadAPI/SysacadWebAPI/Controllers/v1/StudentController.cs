using Application.Features.Student.Commands.EnrollStudentCourseCommand;
using Application.Features.Student.Commands.RegisterStudentCommand;
using Application.Features.Student.Queries.GetStudentScheduleQuery;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StudentController : BaseApiController
    {
        [HttpPost("{userId}")]
        [SwaggerOperation(Summary = "Register a student", Description = "")]
        public async Task<IActionResult> RegisterStudent(int userId) => Ok(await Mediator.Send(new RegisterStudentCommand { UserId = userId }));

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get student schedules", Description = "")]
        public async Task<IActionResult> GetSchedule(int id) => Ok(await Mediator.Send(new GetStudentScheduleQuery { StudentId = id }));

        [HttpPut("{studentId}/course/{courseId}")]
        [SwaggerOperation(Summary = "Enrolls a student in a Course", Description = "")]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
            => Ok(await Mediator.Send(new EnrollStudentCourseCommand { StudentId = studentId, CourseId = courseId }));
    }
}
