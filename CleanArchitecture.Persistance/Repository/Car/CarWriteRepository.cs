using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository
{
    public sealed class CarWriteRepository : WriteRepository<Car>, ICarWriteRepository
    {
        public CarWriteRepository(AppDbContext context) : base(context)
        { }
    }
}
