using AutoMapper;
using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Domain.Dtos.Car;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Persistance.Mapping;

public sealed class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<CreateCarCommand, Car>().ReverseMap();
        CreateMap<Car, CreateCarDto>().ReverseMap(); 
        CreateMap<Car, CarListDto>();
    }
}
