using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.Role;

public class RoleCreationException : BaseException
{
    public RoleCreationException() : base("Rol oluşturma başarısız oldu.")
    {
    }
}
