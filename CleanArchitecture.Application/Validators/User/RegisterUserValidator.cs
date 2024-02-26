using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Features.Commands.AppUser.RegisterUser;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.User;

public sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(validate => validate.FullName)
            .NotNull()
            .WithMessage("Fullname is required.")
            .WithErrorCode(ValidatorErrorCodes.ERR_FULLNAME_REQUIRED.ToDescriptionString())
            .NotEmpty()
            .WithMessage("Fullname is required.")
            .WithErrorCode(ValidatorErrorCodes.ERR_FULLNAME_REQUIRED.ToDescriptionString())
            .MinimumLength(2)
            .WithMessage("The minimum length for a FullName is 2 characters.")               
            .WithErrorCode(ValidatorErrorCodes.ERR_FULLNAME_MIN_LENGTH.ToDescriptionString())
            .MaximumLength(50)
            .WithMessage("The maximum length for a FullName is 50 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_FULLNAME_MAX_LENGTH.ToDescriptionString())
            .Matches(@"^[\p{L}0-9\s]+$")
            .WithMessage("Company name can only contain letters, numbers, and spaces.")
            .WithErrorCode(ValidatorErrorCodes.ERR_INVALID_NAME_FORMAT.ToDescriptionString());

        RuleFor(validate => validate.Username)
            .NotNull()
            .WithMessage("Please do not leave the username field blank.")
            .WithErrorCode(ValidatorErrorCodes.ERR_USERNAME_REQUIRED.ToDescriptionString())
            .NotEmpty()
            .WithMessage("Please do not leave the username field blank.")
            .WithErrorCode(ValidatorErrorCodes.ERR_USERNAME_REQUIRED.ToDescriptionString())
            .MinimumLength(6)
            .WithMessage("The minimum length for a username is 6 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_USERNAME_MIN_LENGTH.ToDescriptionString())
            .MaximumLength(20)
            .WithMessage("The maximum length for a username is 20 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_USERNAME_MAX_LENGTH.ToDescriptionString())
            .Matches(@"^[\p{L}0-9\s]+$")
            .WithMessage("User name can only contain letters, numbers, and spaces.")
            .WithErrorCode(ValidatorErrorCodes.ERR_INVALID_NAME_FORMAT.ToDescriptionString());


        RuleFor(validate => validate.Password)
            .MinimumLength(8)
            .WithMessage("The minimum length for a password is 8 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_MIN_LENGTH.ToDescriptionString())
            .MaximumLength(20)
            .WithMessage("The maximum length for a password is 20 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_MAX_LENGTH.ToDescriptionString())
            .Matches("[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_UPPERCASE.ToDescriptionString())
            .Matches("[a-z]")
            .WithMessage("Password must contain at least one lowercase letter.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_LOWERCASE.ToDescriptionString())
            .Matches("[0-9]")
            .WithMessage("Password must contain at least one digit.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_DIGIT.ToDescriptionString())
            .Matches("[!@#$%^&*(),.?\":{}|<>]")
            .WithMessage("The password must contain special characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_SPECIAL_CHARACTERS.ToDescriptionString())
            .Must(BeDifferentFromFirstAndLastCharacter)
            .WithMessage("First and last characters must be different.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_FIRST_LAST_DIFFERENT.ToDescriptionString())
            .WithMessage("Password is too weak.")
            .WithErrorCode(ValidatorErrorCodes.ERR_PASSWORD_WEAK.ToDescriptionString());


        RuleFor(validate => validate.Email)
            .NotNull()
            .WithMessage("Please do not leave the Email field blank.")
            .WithErrorCode(ValidatorErrorCodes.ERR_EMAIL_REQUIRED.ToDescriptionString())
            .NotEmpty()
            .WithMessage("Please do not leave the Email field blank.")
            .WithErrorCode(ValidatorErrorCodes.ERR_EMAIL_REQUIRED.ToDescriptionString())
            .MinimumLength(6)
            .WithMessage("The minimum length for a Email is 6 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_EMAIL_MIN_LENGTH.ToDescriptionString())
            .MaximumLength(50)
            .WithMessage("The maximum length for a Email is 50 characters.")
            .WithErrorCode(ValidatorErrorCodes.ERR_EMAIL_MAX_LENGTH.ToDescriptionString())
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .WithErrorCode(ValidatorErrorCodes.ERR_EMAIL_INVALID_FORMAT.ToDescriptionString());


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
