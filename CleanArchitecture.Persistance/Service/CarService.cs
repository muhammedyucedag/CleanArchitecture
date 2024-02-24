using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Service;

public sealed class CarService : ICarService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CarService(AppDbContext appDbContext, IMapper mapper)
    {
        _context = appDbContext;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCarCommandRequest request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
     
        await _context.Set<Car>().AddAsync(car, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
