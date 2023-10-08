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
    }
}
