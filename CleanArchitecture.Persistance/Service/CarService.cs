using AutoMapper;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Exceptions.Car;
using EntityFrameworkCorePagination.Nuget.Pagination;
using CleanArchitecture.Application.Features.Queries.GetAllCar;

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

    public async Task CreateAsync(Car car, CancellationToken cancellationToken)
    {
        await _carWriteRepository.AddAsync(car);
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        var cars = await _carReadRepository.GetAll().ToListAsync();

        if (cars is null)
            throw new NotFoundCarFailedException();

        return cars;
    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars =
            await _carReadRepository
            .GetWhere(p => p.Name.ToLower().Contains(request.Search.ToLower()))
            .OrderBy(p => p.Name)
            .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return cars;
    }
}
