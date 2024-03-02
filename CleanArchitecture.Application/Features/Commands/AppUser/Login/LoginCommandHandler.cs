using CleanArchitecture.Application.Abstractions.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.AppUser.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IUserService _userService;

    public LoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _userService.LoginAsync(request, cancellationToken);
        return response;
    }
}
