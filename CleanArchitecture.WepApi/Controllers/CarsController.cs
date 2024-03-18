using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Application.Features.Queries.GetAllCar;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WepApi.Controllers;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator) { }

    [RoleFilter("Admin")]
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAsync(CreateCarCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [RoleFilter("Moderatör")]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
