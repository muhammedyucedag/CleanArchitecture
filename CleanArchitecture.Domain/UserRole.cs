using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Entites.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain;

public sealed class UserRole : BaseEntity
{
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Role")]
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}
