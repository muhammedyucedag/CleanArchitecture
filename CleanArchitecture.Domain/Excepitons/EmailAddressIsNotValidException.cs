namespace CleanArchitecture.Domain.Exceptions;

public class EmailAddressIsNotValidException : BaseException
{
    public EmailAddressIsNotValidException() : base("Invalid email address.")
    { }
}
