using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.User;

public class CreateUserFailedException : BaseException
{
    public CreateUserFailedException(string? message) : base(message)
    { }

    public CreateUserFailedException() : base("")
    { }

}
