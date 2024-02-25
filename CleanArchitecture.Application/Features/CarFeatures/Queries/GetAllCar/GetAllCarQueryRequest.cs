using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed record GetAllCarQueryRequest : IRequest<GetAllCarQueryResponse>
{
}
