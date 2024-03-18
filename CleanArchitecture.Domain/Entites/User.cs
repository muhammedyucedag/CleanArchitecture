using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entites;

public sealed class User : IdentityUser<Guid>
{
    public User()
    {
        Id = Guid.NewGuid();
    }

    public string FullName { get; set; }
    public string Language { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }

}
