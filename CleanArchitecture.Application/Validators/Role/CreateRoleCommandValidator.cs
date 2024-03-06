using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Features.Commands.Role.CreateRole;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.Role
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(validator => validator.Name)
                .NotNull()
                .WithMessage("Lütfen ad alanını boş bırakmayın.")
                .WithErrorCode(ValidatorErrorCodes.ERR_NAME_REQUIRED.ToDescriptionString())
                .NotEmpty()
                .WithMessage("Lütfen ad alanını boş bırakmayın.")
                .WithErrorCode(ValidatorErrorCodes.ERR_NAME_REQUIRED.ToDescriptionString())
                .MinimumLength(2)
                .WithMessage("Ad alanı için minimum uzunluk 2 karakterdir.")
                .WithErrorCode(ValidatorErrorCodes.ERR_NAME_MIN_LENGTH.ToDescriptionString())
                .MaximumLength(100)
                .WithMessage("Ad alanı için maksimum uzunluk 100 karakterdir.")
                .WithErrorCode(ValidatorErrorCodes.ERR_NAME_MAX_LENGTH.ToDescriptionString())
                .Matches(@"^[\p{L}0-9\s]+$")
                .WithMessage("Ad alanı yalnızca harfler, rakamlar ve boşluklar içerebilir.")
                .WithErrorCode(ValidatorErrorCodes.ERR_INVALID_NAME_FORMAT.ToDescriptionString());

        }
    }
}
