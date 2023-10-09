using Application.Features.Course.Commands.CreateCourseCommand;
using Application.Features.Course.Commands.DeleteCourseCommand;
using Application.Features.Course.Commands.UpdateCourseCommand;
using Application.Features.Course.Queries.GetAllCoursesAvailablesForEnrollmentQuery;
using Application.Features.Course.Queries.GetAllCoursesByStudentIdQuery;
using Application.Features.Course.Queries.GetAllCoursesByYearAndQuarterQuery;
using Application.Features.Course.Queries.GetCourseByIdQuery;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CourseController : BaseApiController
    {
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a Course", Description = "")]
        public async Task<IActionResult> Get(int id)
            => Ok(await Mediator.Send(new GetCourseByIdQuery { Id = id }));

        [HttpGet("avalibles")]
        [SwaggerOperation(Summary = "Gets all avalibles courses for inscription", Description = "")]
        public async Task<IActionResult> GetAvaliblesForEnrollment()
            => Ok(await Mediator.Send(new GetAllCoursesAvailablesForEnrollmentQuery()));

        [HttpGet("student/{studentId}")]
        [SwaggerOperation(Summary = "Gets all courses from a student", Description = "")]
        public async Task<IActionResult> GetByStudent(int studentId)
            => Ok(await Mediator.Send(new GetAllCoursesByStudentIdQuery { StudentId = studentId }));

        [HttpGet("year/{year}/quarter/{quarter}")]
        [SwaggerOperation(Summary = "Gets all courses by year and quarter", Description = "")]
        public async Task<IActionResult> GetByYearAndQuarter(string year, short quarter)
            => Ok(await Mediator.Send(new GetAllCoursesByYearAndQuarterQuery { Year = year, Quarter = quarter }));

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a Course", Description = "")]
        public async Task<IActionResult> Create(CreateCourseCommand createCourse) => Ok(await Mediator.Send(createCourse));

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates a Course", Description = "")]
        public async Task<IActionResult> Update(int id, UpdateCourseCommand updateCourse)
            => id == updateCourse.Id ? Ok(await Mediator.Send(updateCourse)) : BadRequest();


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a Course", Description = "")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteCourseCommand { Id = id }));
    }
}
