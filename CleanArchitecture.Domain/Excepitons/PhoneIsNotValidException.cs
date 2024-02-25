namespace CleanArchitecture.Domain.Exceptions.Phone;

public class PhoneIsNotValidException : BaseException
{
    public PhoneIsNotValidException() : base("Invalid phone number.")
    { }
}
