using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Service;

public sealed class CarService : ICarService
{
    private readonly AppDbContext _context;

    public CarService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task CreateAsync(CreateCarCommandRequest request, CancellationToken cancellationToken)
    {
        Car car = new() 
        {
            Name = request.Name,
            Model = request.Model,
            EnginePower = request.EnginePower,
        };

        await _context.Set<Car>().AddAsync(car, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
