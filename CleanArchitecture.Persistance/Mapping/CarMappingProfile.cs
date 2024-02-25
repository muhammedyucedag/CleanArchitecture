﻿using AutoMapper;
using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Domain.Dtos.Car;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Persistance.Mapping;

public sealed class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<CreateCarCommandRequest, Car>().ReverseMap();
        CreateMap<Car, CarListDto>();
    }
}
