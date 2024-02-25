using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class ExistEmailException : BaseException
{
    public ExistEmailException() : base("This Email address is registered in the system. Please enter another Email.")
    {}
}
