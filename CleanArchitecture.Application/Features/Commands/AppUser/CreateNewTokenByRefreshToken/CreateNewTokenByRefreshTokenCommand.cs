using CleanArchitecture.Application.Features.Commands.User.Login;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.User.CreateNewTokenByRefreshToken;

public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken): IRequest<LoginCommandResponse>;

