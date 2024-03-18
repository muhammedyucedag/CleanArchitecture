using CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.Role;

public sealed class AssignRoleToUserCommandValidator : AbstractValidator<AssignRoleToUserCommand>
{
    public AssignRoleToUserCommandValidator()
    {
        RuleFor(x => x.RoleId).NotEmpty().WithMessage("Rol kimliği boş olmamalıdır.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı kimliği boş olmamalıdır.");
    }
}
