using CleanArchitecture.Domain.Entites.Common;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Persistance.Repository;

public abstract class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return query;
    }

    public Task<IEnumerable<T>?> GetAllDetailAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null, Expression<Func<T, T>>? selector = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAllDetailQueryable(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null, Expression<Func<T, T>>? selector = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(Guid id, bool tracking = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T?> GetFirst(Expression<Func<T, bool>> method)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetFirstAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        IQueryable<T> queryable = Table;

        if (!tracking)
            queryable = queryable.AsNoTracking();

        var query = Table.Where(method);
        return query;
    }
}
