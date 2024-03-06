using AutoMapper;
using CleanArchitecture.Domain.Dtos.Role;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Persistance.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
