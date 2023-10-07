using Application.Features.Course.Commands.CreateCourseCommand;
using Microsoft.AspNetCore.Mvc;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CourseController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCourseCommand createCourse) => Ok(await Mediator.Send(createCourse));
    }
}
