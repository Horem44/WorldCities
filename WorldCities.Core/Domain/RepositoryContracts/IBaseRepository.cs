using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Core.Domain.RepositoryContracts
{
    public interface IBaseRepository<T>
    {
        Task<T> add(T entity);

        Task<T> update(T entity);

        Task delete(T entity);

        Task<List<T>?> all();

        Task<List<T>?> getWhere(Expression<Func<T, bool>> predicate);

        Task<T?> getByGuid(Guid guid);
    }
}
