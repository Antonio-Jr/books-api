using Domain.Interfaces;

namespace Infrastructure;

public sealed class UnitOfWork(DataContext context) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default) =>
        await context.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) =>
        await context.Database.CommitTransactionAsync(cancellationToken);

    public async Task RollbackAsync(CancellationToken cancellationToken = default) =>
        await context.Database.RollbackTransactionAsync(cancellationToken);

    public async void Dispose() => await context.DisposeAsync();
}