using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository
{
    public class UserRoleReadRepository : ReadRepository<UserRole>, IUserRoleReadRepository
    {
        public UserRoleReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
