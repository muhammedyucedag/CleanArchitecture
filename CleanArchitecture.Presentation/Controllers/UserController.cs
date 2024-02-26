using CleanArchitecture.Application.Features.Commands.AppUser.RegisterUser;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitecture.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class UserController : ApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        {}

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommandRequest)
        {
            RegisterUserCommandResponse response = await Mediator.Send(registerUserCommandRequest);
            return Ok(response);
        }
    }
}
