using AutoMapper;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Domain.Dtos.Car;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.Car.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarDto>
{

    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CreateCarCommandHandler(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    public async Task<CreateCarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var carEntity = _mapper.Map<Domain.Entites.Car>(request);

        await _carService.CreateAsync(carEntity, cancellationToken);

        var createCarDto = _mapper.Map<CreateCarDto>(carEntity);

        return createCarDto;
    }
}
