using Application.Features.User.Commands.CreateUserCommand;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a user", Description = "")]
        public async Task<IActionResult> Post(CreateUserCommand createUserCommand) => Ok(await Mediator.Send(createUserCommand));
    }
}
