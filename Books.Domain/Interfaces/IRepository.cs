using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    IQueryable<T> Find(Expression<Func<T, bool>>? expression = null);
    Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default);
}