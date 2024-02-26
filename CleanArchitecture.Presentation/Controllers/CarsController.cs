using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Application.Features.Queries.GetAllCar;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAsync(CreateCarCommand request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> response = await Mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
