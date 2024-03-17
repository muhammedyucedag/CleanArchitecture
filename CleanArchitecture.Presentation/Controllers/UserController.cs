using CleanArchitecture.Application.Features.Commands.AppUser.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.Commands.AppUser.Login;
using CleanArchitecture.Application.Features.Commands.AppUser.RegisterUser;
using CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class UserController : ApiController
{
    public UserController(IMediator mediator) : base(mediator)
    {}

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync(RegisterCommand request)
    {
        RegisterCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommand request)
    {
        AssignRoleToUserCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
