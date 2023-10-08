using Application.Features.Course.Commands.CreateCourseCommand;
using Application.Features.Course.Commands.UpdateCourseCommand;
using Microsoft.AspNetCore.Mvc;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CourseController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCourseCommand createCourse) => Ok(await Mediator.Send(createCourse));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCourseCommand updateCourse)
            => id == updateCourse.Id ? Ok(await Mediator.Send(updateCourse)) : BadRequest();
    }
}
