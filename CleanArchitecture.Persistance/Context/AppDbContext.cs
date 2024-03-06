using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Entites.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Context;

public sealed class AppDbContext : IdentityDbContext<AppUser, Role, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
        modelBuilder.Ignore<IdentityUserRole<Guid>>();
        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityRole<Guid>>();

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Property(p => p.CreatedDate)
                    .CurrentValue = DateTime.Now; 

            if (entry.State == EntityState.Modified)
                entry.Property(p => p.UpdateDate)
                    .CurrentValue = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
