using CleanArchitecture.Application.Abstractions.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;

public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, AssignRoleToUserCommandResponse>
{
    private readonly IRoleService _roleService;

    public AssignRoleToUserCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<AssignRoleToUserCommandResponse> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
    {
        await _roleService.AssignRoleToUserAsync(request);
        return new(request.UserId, request.RoleId.ToString());
    }
}
