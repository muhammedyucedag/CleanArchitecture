using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entites;

public sealed class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.NewGuid();
    }

    public string FullName { get; set; }
}
