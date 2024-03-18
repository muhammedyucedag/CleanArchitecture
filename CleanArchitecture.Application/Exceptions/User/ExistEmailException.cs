using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class ExistEmailException : BaseException
{
    public ExistEmailException() : base("Bu Email adresi sisteme kayıtlıdır. Lütfen başka bir E-posta girin.")
    {}
}
