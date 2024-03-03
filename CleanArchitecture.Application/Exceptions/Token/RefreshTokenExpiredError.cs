using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.Token;

public class RefreshTokenExpiredError : BaseException
{
    public RefreshTokenExpiredError() : base("Yenileme tokeninin süresi dolmuştur.")
    {
    }
}
