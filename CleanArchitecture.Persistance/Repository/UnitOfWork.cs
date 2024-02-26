using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    private bool _isCommit = true;
    private bool _isForce;
    public bool IsCommit => _isCommit;

    public bool IsForce => _isForce;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        _isCommit = true;
    }

    public async Task ForceAsync(CancellationToken cancellationToken = default)
    {
        _isForce = true;
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        _isCommit = false;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {

    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}