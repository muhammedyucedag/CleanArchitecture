using CleanArchitecture.Domain.Entites.Common;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArchitecture.Persistance.Repository;

public abstract class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public Task<bool> AddRangeAsync(List<T> datas)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool RemoveRange(List<T> datas)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public bool Update(T model)
    {
        throw new NotImplementedException();
    }
}
