using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class ExistUsernameException : BaseException
{
    public ExistUsernameException() : base("Bu Kullanıcı Adı sisteme kayıtlıdır. Lütfen başka bir Kullanıcı Adı girin.")
    { }
}
