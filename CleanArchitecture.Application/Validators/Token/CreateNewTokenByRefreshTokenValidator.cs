using CleanArchitecture.Application.Features.Commands.AppUser.CreateNewTokenByRefreshToken;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.Token;

public sealed class CreateNewTokenByRefreshTokenValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User bilgisi boş olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("User bilgisi boş olamaz!");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refresh token bilgisi boş olamaz!");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refresh token bilgisi boş olamaz!");
    }
}
