using System.Linq.Expressions;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Guid id);
        Task<T> Add(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
        Task SaveChanges();
    }
}
