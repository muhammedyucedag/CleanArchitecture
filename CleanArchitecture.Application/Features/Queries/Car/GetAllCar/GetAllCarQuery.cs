using CleanArchitecture.Domain.Entites;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.Queries.GetAllCar;

public sealed record GetAllCarQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "") : IRequest<PaginationResult<Car>>;