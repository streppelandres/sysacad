using Application.Features.Schedule.Commands.CreateScheduleCommand;
using Application.Features.Schedule.Commands.DeleteScheduleCommand;
using Application.Features.Schedule.Commands.UpdateScheduleCommand;
using Application.Features.Schedule.Queries.GetAllSchedulesByCourseIdQuery;
using Application.Features.Schedule.Queries.GetScheduleByIdQuery;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ScheduleController : BaseApiController
    {
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a schedule by id", Description = "")]
        public async Task<IActionResult> GetById(int id) => Ok(await Mediator.Send(new GetScheduleByIdQuery { Id = id }));

        [HttpGet("course/{courseId}")]
        [SwaggerOperation(Summary = "Gets all schedules from a course", Description = "")]
        public async Task<IActionResult> GetByCourseId(int courseId)
            => Ok(await Mediator.Send(new GetAllSchedulesByCourseIdQuery { CourseId = courseId }));

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a schedule", Description = "")]
        public async Task<IActionResult> Post(CreateScheduleCommand createSchedule) => Ok(await Mediator.Send(createSchedule));

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates a schedule", Description = "")]
        public async Task<IActionResult> Put(int id, UpdateScheduleCommand updateSchedule)
            => id != updateSchedule.Id ? BadRequest() : Ok(await Mediator.Send(updateSchedule));

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a schedule", Description = "")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteScheduleCommand { Id = id }));
    }
}
