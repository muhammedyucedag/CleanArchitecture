using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Abstraction;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class ApiController : ControllerBase
{
    protected readonly IMediator Mediator;

    protected ApiController(IMediator mediator)
    {
        Mediator = mediator;
    }
}
