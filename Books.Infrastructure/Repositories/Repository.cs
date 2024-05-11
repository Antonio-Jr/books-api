using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T>(DataContext context) : IRepository<T> where T : class
{
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public IQueryable<T> Find(Expression<Func<T, bool>>? expression = null)
    {
        return expression is null ? context.Set<T>() : context.Set<T>().Where(expression);
    }


    public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        return true;
    }
}