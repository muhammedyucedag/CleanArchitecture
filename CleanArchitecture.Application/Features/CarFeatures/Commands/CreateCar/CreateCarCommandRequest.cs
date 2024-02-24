using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed record CreateCarCommandRequest(
    string Name,
    string Model,
    int EnginePower): IRequest<CreateCarCommandResponse>;

