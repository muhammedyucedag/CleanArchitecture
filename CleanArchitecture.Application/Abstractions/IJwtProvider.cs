using CleanArchitecture.Application.Features.Commands.User.Login;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(User user);
}
