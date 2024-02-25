using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Dtos.User;

public class CreateUserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public EmailAddress Email { get; set; }
    public Phone PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Language { get; set; }
}
