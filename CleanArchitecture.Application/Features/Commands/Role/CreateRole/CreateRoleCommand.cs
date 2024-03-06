using CleanArchitecture.Application.Features.Commands.Response;
using CleanArchitecture.Domain.Dtos.Role;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.Role.CreateRole;

public sealed record CreateRoleCommand(
    string Name) : IRequest<CreateRoleCommandResponse>;


