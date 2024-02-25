﻿using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Application.Features.Queries.Car.GetAllCar;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAsync(CreateCarCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCarsAsync([FromQuery] GetAllCarQueryRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
