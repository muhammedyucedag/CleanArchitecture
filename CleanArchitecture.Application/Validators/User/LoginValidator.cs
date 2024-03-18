using CleanArchitecture.Application.Features.Commands.User.Login;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Application.Validators.User;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(validate => validate.userNameOrEmail)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Lütfen kullanıcı adı veya e-posta alanını boş bırakmayınız.")
            .NotEmpty().WithMessage("Lütfen kullanıcı adı veya e-posta alanını boş bırakmayınız.")
            .MinimumLength(6).WithMessage("Bir kullanıcı adı veya e-posta için minimum uzunluk 6 karakterdir.")
            .MaximumLength(50).WithMessage("Bir kullanıcı adı veya e-posta için maksimum uzunluk 50 karakterdir.")
            .Must(input => IsEmail(input) || IsUserName(input))
            .WithMessage("Kullanıcı yanlızca harf, sayı içerebilir. E-posta yalnızca harf, sayı ve geçerli karakterleri içerebilir.");


        RuleFor(validate => validate.Password)
            .NotNull().WithMessage("Lütfen şifre alanını boş bırakmayınız.")
            .NotEmpty().WithMessage("Lütfen şifre alanını boş bırakmayınız.")
            .MinimumLength(8).WithMessage("Bir şifrenin minimum uzunluğu 8 karakterdir.")
            .MaximumLength(20).WithMessage("Bir şifrenin maksimum uzunluğu 20 karakterdir.")
            .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
            .Matches(new Regex("[!@#$%^&*(),.?\":{}|<>]")).WithMessage("Şifre özel karakterler içermelidir.")
            .Must(BeDifferentFromFirstAndLastCharacter).WithMessage("İlk ve son karakterler farklı olmalıdır.")
            .WithMessage("Şifre çok zayıf.");

    }

    private bool IsEmail(string input)
    {
        return new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(input);
    }

    private bool IsUserName(string input)
    {
        return new Regex(@"^[\p{L}0-9]+$").IsMatch(input);
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
