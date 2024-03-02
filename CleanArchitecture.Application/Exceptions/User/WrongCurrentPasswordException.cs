using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class WrongCurrentPasswordException : BaseException
{
    public WrongCurrentPasswordException() : base("Mevcut şifre yanlış girildi, tekrar deneyin.")
    {
    }
}
