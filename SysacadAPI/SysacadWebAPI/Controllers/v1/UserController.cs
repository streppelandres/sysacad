using Application.Features.User.Commands.CreateUserCommand;
using Microsoft.AspNetCore.Mvc;

namespace SysacadWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand createUserCommand) => Ok(await Mediator.Send(createUserCommand));
    }
}
