using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository
{
    public class UserRoleWriteRepository : WriteRepository<UserRole>, IUserRoleWriteRepository
    {
        public UserRoleWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
