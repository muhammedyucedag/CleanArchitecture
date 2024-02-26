using CleanArchitecture.Application.Features.Queries.GetAllCar;
using CleanArchitecture.Domain.Entites;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Abstractions.Services;
public interface ICarService
{
    Task CreateAsync(Car car, CancellationToken cancellationToken);
    Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);

}
