using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository
{
    public sealed class CarReadRepository : ReadRepository<Car>, ICarReadRepository
    {
        public CarReadRepository(AppDbContext context) : base(context)
        { }
    }
}
