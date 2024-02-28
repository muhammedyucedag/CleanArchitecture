using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.Application.Abstractions;

public interface IJwtProvider
{
    string CreateToken(AppUser user);
}
