using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommandRequest request, CancellationToken cancellationToken);
    Task<IEnumerable<Car>> GetAllAsync();

}
