using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Features.Commands.User.Login;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.User.CreateNewTokenByRefreshToken;

public sealed class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IUserService _userService;

    public CreateNewTokenByRefreshTokenCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _userService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
        return response;
    }
}
