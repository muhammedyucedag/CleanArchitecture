using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entites;

public sealed class Role : IdentityRole<Guid>
{
    public Role()
    {
        Id = Guid.NewGuid();
    }
}
