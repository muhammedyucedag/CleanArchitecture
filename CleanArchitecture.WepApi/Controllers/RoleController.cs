using CleanArchitecture.Application.Features.Commands.Role.CreateRole;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WepApi.Controllers;

public class RoleController : ApiController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
