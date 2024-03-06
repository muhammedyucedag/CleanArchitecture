using CleanArchitecture.Application.Abstractions.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.Role.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _roleService.CreateAsync(request.Name);
        return new(request.Name)
        {
            Succeeded = result,
        };
    }
}
