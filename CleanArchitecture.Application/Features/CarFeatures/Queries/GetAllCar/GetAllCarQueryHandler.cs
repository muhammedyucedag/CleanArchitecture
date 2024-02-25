using AutoMapper;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos.Car;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed record GetAllCarQueryHandler : IRequestHandler<GetAllCarQueryRequest, GetAllCarQueryResponse>
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public GetAllCarQueryHandler(IMapper mapper, ICarService carService)
    {
        _mapper = mapper;
        _carService = carService;
    }

    public async Task<GetAllCarQueryResponse> Handle(GetAllCarQueryRequest request, CancellationToken cancellationToken)
    {
        var cars = await _carService.GetAllAsync();
        var carsDtos = _mapper.Map<CarListDto[]>(cars);

        return new GetAllCarQueryResponse(carsDtos)
        {
            CarLists = carsDtos
        };

    }
}
