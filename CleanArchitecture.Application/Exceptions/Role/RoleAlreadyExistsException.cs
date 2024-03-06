using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.Role
{
    public class RoleAlreadyExistsException : BaseException
    {
        public RoleAlreadyExistsException() : base("Aynı ada sahip bir rol zaten mevcut.")
        {
        }
    }
}
