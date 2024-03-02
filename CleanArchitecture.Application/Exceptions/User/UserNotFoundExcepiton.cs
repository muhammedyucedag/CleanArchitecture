using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class UserNotFoundExcepiton : BaseException
{
    public UserNotFoundExcepiton() : base("Kullanıcı Bulunamadı")
    {
    }
}
