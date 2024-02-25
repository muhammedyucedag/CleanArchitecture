using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class ExistUsernameException : BaseException
{
    public ExistUsernameException() : base("This Username is registered in the system. Please enter another Username.")
    { }
}
