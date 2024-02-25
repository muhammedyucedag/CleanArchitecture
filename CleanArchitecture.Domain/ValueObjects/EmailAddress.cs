using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace CleanArchitecture.Domain.ValueObjects;

public record EmailAddress : IEqualityComparer<EmailAddress>, IValueObjectBase
{
    public readonly static Regex EmailRegex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

    [MinLength(4), MaxLength(64)]
    public string Value { get; set; }

    public EmailAddress() { }

    public EmailAddress(string value)
    {
        if (!EmailRegex.IsMatch(value))
            throw new EmailAddressIsNotValidException();

        Value = value;
    }

    public bool Equals(EmailAddress? x, EmailAddress? y)
    {
        return x.Value == y.Value;
    }

    public int GetHashCode(EmailAddress obj)
    {
        return Value.GetHashCode();
    }
}
