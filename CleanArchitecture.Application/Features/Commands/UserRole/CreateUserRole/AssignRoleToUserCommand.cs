using MediatR;

namespace CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;

public sealed record AssignRoleToUserCommand(
    Guid RoleId,
    Guid UserId) : IRequest<AssignRoleToUserCommandResponse>;

