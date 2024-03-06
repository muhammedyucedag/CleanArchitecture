using CleanArchitecture.Application.Features.Commands.Role.CreateRole;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IRoleService
{
    Task<bool> CreateAsync(string name);
}
