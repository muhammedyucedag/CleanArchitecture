
using CleanArchitecture.Application.Features.Commands.AppUser.Login;
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IUserService
{
    Task<AppUser> RegisterAsync(CreateUserDto createUserDto);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);

}
