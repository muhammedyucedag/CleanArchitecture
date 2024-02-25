using MediatR;

namespace CleanArchitecture.Application.Features.Commands.Car.CreateCar;

public sealed record CreateCarCommandRequest(
    string Name,
    string Model,
    int EnginePower) : IRequest<CreateCarCommandResponse>;


