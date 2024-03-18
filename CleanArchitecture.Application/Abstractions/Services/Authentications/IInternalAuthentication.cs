using CleanArchitecture.Application.Features.Commands.User.Login;

namespace CleanArchitecture.Application.Abstractions.Services.Authentications;

public interface IInternalAuthentication
{
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
}
