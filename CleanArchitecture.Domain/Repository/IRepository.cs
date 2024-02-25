using CleanArchitecture.Domain.Entites.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domain.Repository;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
