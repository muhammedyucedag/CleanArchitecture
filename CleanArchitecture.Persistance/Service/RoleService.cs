using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Exceptions.Role;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Service
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;

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
}
