using AutoMapper;
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Persistance.Mapping;

public class AppUserMappingProfile : Profile
{
    public AppUserMappingProfile()
    {
        CreateMap<CreateUserDto, AppUser>().ReverseMap();

    }
}
