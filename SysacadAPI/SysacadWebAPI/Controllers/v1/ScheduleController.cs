using Application.Features.Schedule.Commands.CreateScheduleCommand;
using Application.Features.Schedule.Commands.DeleteScheduleCommand;
using Application.Features.Schedule.Commands.UpdateScheduleCommand;
using Application.Features.Schedule.Queries.GetAllSchedulesByCourseIdQuery;
using Application.Features.Schedule.Queries.GetScheduleByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ScheduleController : BaseApiController
    {
        /// <summary>
        /// Get a schedule by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await Mediator.Send(new GetScheduleByIdQuery { Id = id }));

        /// <summary>
        /// Gets all schedules from a course
        /// </summary>
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
            => Ok(await Mediator.Send(new GetAllSchedulesByCourseIdQuery { CourseId = courseId }));

        /// <summary>
        /// Creates a schedule
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(CreateScheduleCommand createSchedule) => Ok(await Mediator.Send(createSchedule));

        /// <summary>
        /// Updates a schedule
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateScheduleCommand updateSchedule)
            => id != updateSchedule.Id ? BadRequest() : Ok(await Mediator.Send(updateSchedule));

        /// <summary>
        /// Deletes a schedule
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteScheduleCommand { Id = id }));
    }
}
