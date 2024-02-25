using AutoMapper;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Exceptions.Car;

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

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        var cars = await _carReadRepository.GetAll().ToListAsync();

        if (cars is null)
            throw new NotFoundCarFailedException();

        return cars;
    }
}
