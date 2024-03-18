using CleanArchitecture.Application.Features.Commands.Role.CreateRole;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.Role;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(validator => validator.Name)
            .NotNull().WithMessage("Lütfen ad alanını boş bırakmayın.")
            .NotEmpty().WithMessage("Lütfen ad alanını boş bırakmayın.")
            .MinimumLength(2).WithMessage("Ad alanı için minimum uzunluk 2 karakterdir.")
            .MaximumLength(100).WithMessage("Ad alanı için maksimum uzunluk 100 karakterdir.")
            .Matches(@"^[\p{L}0-9\s]+$").WithMessage("Ad alanı yalnızca harfler, rakamlar ve boşluklar içerebilir.");
    }
}
