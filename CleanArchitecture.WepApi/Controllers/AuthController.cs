using CleanArchitecture.Application.Features.Commands.User.Login;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WepApi.Controllers;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {}

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
