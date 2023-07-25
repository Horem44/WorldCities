using System.Linq.Expressions;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Add(T entity, CancellationToken cancellationToken);

        Task Delete(T entity, CancellationToken cancellationToken);

        Task<List<T>?> All(CancellationToken cancellationToken);

        Task<List<T>> GetWhere(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken
        );

        Task<T?> GetByGuid(Guid guid, CancellationToken cancellationToken);
    }
}
