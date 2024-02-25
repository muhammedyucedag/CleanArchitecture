using CleanArchitecture.Domain.Exceptions.Phone;
using CleanArchitecture.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Domain.ValueObjects;

public record Phone : IEqualityComparer<Phone>, IValueObjectBase
{
    public readonly static Regex PhoneRegex = new Regex(@"^\+?[1-9][0-9]{10,11}$");

    [MinLength(10), MaxLength(16)]
    public string Value { get; set; }

    public Phone() { }

    public Phone(string value)
    {
        if (!PhoneRegex.IsMatch(value))
            throw new PhoneIsNotValidException();

        Value = value;
    }

    public bool Equals(Phone? x, Phone? y)
    {
        return x.Value == y.Value;
    }

    public int GetHashCode(Phone obj)
    {
        return Value.GetHashCode();
    }
}
