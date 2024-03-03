using CleanArchitecture.Application.Features.Commands.AppUser.Login;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.AppUser.CreateNewTokenByRefreshToken;

public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken): IRequest<LoginCommandResponse>;

