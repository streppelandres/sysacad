using Application.Features.Course.Commands.CreateCourseCommand;
using Application.Features.Course.Commands.UpdateCourseCommand;
using Application.Features.Course.Queries.GetAllCoursesByStudentIdQuery;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CourseController : BaseApiController
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a Course", Description = "")]
        public async Task<IActionResult> Post(CreateCourseCommand createCourse) => Ok(await Mediator.Send(createCourse));

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates a Course", Description = "")]
        public async Task<IActionResult> Put(int id, UpdateCourseCommand updateCourse)
            => id == updateCourse.Id ? Ok(await Mediator.Send(updateCourse)) : BadRequest();

        [HttpGet("student/{studentId}")]
        [SwaggerOperation(Summary = "Gets all courses from a student", Description = "")]
        public async Task<IActionResult> Get(int studentId)
            => Ok(await Mediator.Send(new GetAllCoursesByStudentIdQuery { StudentId = studentId }));
    }
}
