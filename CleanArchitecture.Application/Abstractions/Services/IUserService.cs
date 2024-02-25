
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IUserService
{
    Task<AppUser> RegisterAsync(CreateUserDto createUserDto);
}
