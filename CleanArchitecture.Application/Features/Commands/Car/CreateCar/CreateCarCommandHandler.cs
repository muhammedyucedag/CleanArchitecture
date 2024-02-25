using CleanArchitecture.Application.Abstractions.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.Car.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CreateCarCommandResponse>
{

    private readonly ICarService _carService;

    public CreateCarCommandHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<CreateCarCommandResponse> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
    {
        await _carService.CreateAsync(request, cancellationToken);
        return new();
    }
}
