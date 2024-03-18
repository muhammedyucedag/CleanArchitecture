using MediatR;

namespace CleanArchitecture.Application.Features.Commands.User.Login
{
    public sealed record LoginCommand(
        string userNameOrEmail,
        string Password) : IRequest<LoginCommandResponse>;
}
