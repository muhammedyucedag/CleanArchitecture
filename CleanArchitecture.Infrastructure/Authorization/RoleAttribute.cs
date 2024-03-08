using CleanArchitecture.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization
{
    public sealed class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;
        private readonly IUserRoleReadRepository _userRoleReadRepository;

        public RoleAttribute(string role, IUserRoleReadRepository userRoleReadRepository)
        {
            _role = role;
            _userRoleReadRepository = userRoleReadRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim is null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userHasRole = _userRoleReadRepository
                .GetWhere(p => p.UserId.ToString() == userIdClaim.Value)
                .Include(p => p.Role)
                .Any(p => p.Role.Name == _role);

            if (!userHasRole)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

    }
}
