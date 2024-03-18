namespace CleanArchitecture.Application.Features.Commands.User.Login;

public sealed record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    Guid UserId);

