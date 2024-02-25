namespace CleanArchitecture.Domain.Repository;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    bool IsCommit { get; }
    bool IsForce { get; }
    Task ForceAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
