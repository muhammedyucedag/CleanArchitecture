using CleanArchitecture.Application.Features.Commands.User.RegisterUser;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.User;

public sealed class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(validate => validate.FullName)
            .NotNull().WithMessage("Ad ve soyad alanı zorunludur.")
            .NotEmpty().WithMessage("Ad ve soyad alanı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Ad ve soyad en az 2 karakter uzunluğunda olmalıdır.")
            .MaximumLength(50).WithMessage("Ad ve soyad en fazla 50 karakter uzunluğunda olmalıdır.")
            .Matches(@"^[\p{L}0-9\s]+$").WithMessage("Ad ve soyad yalnızca harf, rakam ve boşluk içerebilir.");

        RuleFor(validate => validate.Username)
            .NotNull().WithMessage("Lütfen kullanıcı adı alanını boş bırakmayın.")
            .NotEmpty().WithMessage("Lütfen kullanıcı adı alanını boş bırakmayın.")
            .MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakter uzunluğunda olmalıdır.")
            .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter uzunluğunda olmalıdır.")
            .Matches(@"^[\p{L}0-9\s]+$").WithMessage("Kullanıcı adı yalnızca harf, rakam ve boşluk içerebilir.");

        RuleFor(validate => validate.Password)
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalıdır.")
            .MaximumLength(20).WithMessage("Şifre en fazla 20 karakter uzunluğunda olmalıdır.")
            .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
            .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Şifre özel karakterler içermelidir.")
            .Must(BeDifferentFromFirstAndLastCharacter).WithMessage("İlk ve son karakterler farklı olmalıdır.")
            .WithMessage("Şifre zayıf.");

        RuleFor(validate => validate.Email)
            .NotNull().WithMessage("Lütfen e-posta alanını boş bırakmayın.")
            .NotEmpty().WithMessage("Lütfen e-posta alanını boş bırakmayın.")
            .MinimumLength(6).WithMessage("E-posta en az 6 karakter uzunluğunda olmalıdır.")
            .MaximumLength(50).WithMessage("E-posta en fazla 50 karakter uzunluğunda olmalıdır.")
            .EmailAddress().WithMessage("Geçersiz e-posta formatı.");
    }

    private bool BeDifferentFromFirstAndLastCharacter(string password)
    {
        // Eğer parola uzunluğu 2'den küçükse, bu kuralı geçerli kabul et.
        if (password.Length < 2)
            return true;

        // İlk karakteri ve son karakteri al.
        char firstChar = password[0];
        char lastChar = password[password.Length - 1];

        // İlk karakter ile son karakterin aynı olup olmadığını kontrol et,
        // büyük-küçük harf duyarlılığı olmadan.
        return char.ToLower(firstChar) != char.ToLower(lastChar);
    }

}
