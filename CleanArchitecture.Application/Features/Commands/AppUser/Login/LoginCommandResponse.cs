namespace CleanArchitecture.Application.Features.Commands.AppUser.Login;

public sealed record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    Guid UserId);

