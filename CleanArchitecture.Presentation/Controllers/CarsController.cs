using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCarCommandRequest request, CancellationToken cancellationToken)
    {
        CreateCarCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
