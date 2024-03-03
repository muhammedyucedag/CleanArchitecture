using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.Token;

public class InvalidRefreshTokenError : BaseException
{
    public InvalidRefreshTokenError() : base("Geçersiz yenileme tokenı hatası")
    {
    }
}
