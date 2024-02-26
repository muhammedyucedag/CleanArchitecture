using CleanArchitecture.Domain.Dtos.Car;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.Car.CreateCar;

public sealed record CreateCarCommand(
    string Name,
    string Model,
    int EnginePower) : IRequest<CreateCarDto>;


