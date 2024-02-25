using MediatR;

namespace CleanArchitecture.Application.Features.Queries.Car.GetAllCar;

public sealed record GetAllCarQueryRequest : IRequest<GetAllCarQueryResponse>
{
}