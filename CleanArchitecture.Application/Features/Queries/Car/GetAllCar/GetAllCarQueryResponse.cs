using CleanArchitecture.Domain.Dtos.Car;

namespace CleanArchitecture.Application.Features.Queries.Car.GetAllCar;

public sealed record GetAllCarQueryResponse
{
    public ICollection<CarListDto> CarLists { get; set; }

    public GetAllCarQueryResponse(ICollection<CarListDto> carLists)
    {
        CarLists = carLists;
    }
}