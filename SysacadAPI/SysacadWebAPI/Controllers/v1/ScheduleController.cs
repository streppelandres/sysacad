using Application.Features.Schedule.Commands.CreateScheduleCommand;
using Application.Features.Schedule.Commands.DeleteScheduleCommand;
using Application.Features.Schedule.Commands.UpdateScheduleCommand;
using Application.Features.Schedule.Queries.GetAllSchedulesByCourseId;
using Application.Features.Schedule.Queries.GetScheduleById;
using Microsoft.AspNetCore.Mvc;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ScheduleController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await Mediator.Send(new GetScheduleByIdQuery { Id = id }));

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
            => Ok(await Mediator.Send(new GetAllSchedulesByCourseIdQuery { CourseId = courseId }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateScheduleCommand createSchedule) => Ok(await Mediator.Send(createSchedule));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateScheduleCommand updateSchedule)
            => id != updateSchedule.Id ? BadRequest() : Ok(await Mediator.Send(updateSchedule));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteScheduleCommand { Id = id }));
    }
}
