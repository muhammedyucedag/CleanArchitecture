using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Exceptions.Role;
using CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Service;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IUserRoleWriteRepository _userRoleWriteRepository;
    public RoleService(RoleManager<Role> roleManager, IUserRoleWriteRepository userRoleWriteRepository)
    {
        _roleManager = roleManager;
        _userRoleWriteRepository = userRoleWriteRepository;
    }

    public async Task AssignRoleToUserAsync(AssignRoleToUserCommand request)
    {
        UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId
        };

        await _userRoleWriteRepository.AddAsync(userRole);  
    }

    public async Task<bool> CreateAsync(string name)
    {
        var existingRole = await _roleManager.FindByNameAsync(name);
        if (existingRole != null)
            throw new RoleAlreadyExistsException();

        IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid(), Name = name });

        if (!result.Succeeded)
            throw new RoleCreationException();

        return result.Succeeded;
    }


}
