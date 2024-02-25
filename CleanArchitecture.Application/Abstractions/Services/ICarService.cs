using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommandRequest request, CancellationToken cancellationToken);
    Task<IEnumerable<Car>> GetAllAsync();
}
