using AutoMapper;
using CleanArchitecture.Application.Exceptions.Car;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Service;

public sealed class CarService : ICarService
{
    private readonly ICarWriteRepository _carWriteRepository;
    private readonly ICarReadRepository _carReadRepository;
    private readonly IMapper _mapper;

    public CarService(IMapper mapper, ICarWriteRepository carWriteRepository, ICarReadRepository carReadRepository)
    {
        _mapper = mapper;
        _carWriteRepository = carWriteRepository;
        _carReadRepository = carReadRepository;
    }

    public async Task CreateAsync(CreateCarCommandRequest request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        await _carWriteRepository.AddAsync(car);
    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQueryRequest request)
    {
        PaginationResult<Car> cars = await _carReadRepository.GetWhere(p => p.Name.ToLower().Contains(request.Search.ToLower())).ToPagedListAsync(request.PageNumber, request.PageSize);

        if (cars is null)
            throw new NotFoundCarFailedException();

        return cars;
    }
}
