using MediatR;

namespace CleanArchitecture.Application.Features.Commands.AppUser.Login
{
    public sealed record LoginCommand(
        string userNameOrEmail,
        string Password) : IRequest<LoginCommandResponse>;
    
}
