using CleanArchitecture.Application.Features.Commands.Role.CreateRole;
using CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IRoleService
{
    Task<bool> CreateAsync(string name);
    Task AssignRoleToUserAsync(AssignRoleToUserCommand request);
}
