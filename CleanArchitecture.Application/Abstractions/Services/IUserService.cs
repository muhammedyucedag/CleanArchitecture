using CleanArchitecture.Application.Features.Commands.User.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.Commands.User.Login;
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IUserService
{
    Task<User> RegisterAsync(CreateUserDto createUserDto);
    Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);
}
