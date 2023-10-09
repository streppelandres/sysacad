using Application.Features.Student.Commands.EnrollStudentCourseCommand;
using Application.Features.Student.Commands.RegisterStudentCommand;
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

        [HttpPut("{studentId}/course/{courseId}")]
        [SwaggerOperation(Summary = "Enrolls a student in a Course", Description = "")]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
            => Ok(await Mediator.Send(new EnrollStudentCourseCommand { StudentId = studentId, CourseId = courseId }));
    }
}
