using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions.Services.Authentications;

public interface IInternalAuthentication
{
    Task<AppUser> LoginAsync(string usernameOrEmail, string password);
}
