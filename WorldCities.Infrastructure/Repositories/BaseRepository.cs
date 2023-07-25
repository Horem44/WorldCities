using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public virtual async Task<T> Add(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<List<T>?> All(CancellationToken cancellationToken)
        {
            List<T>? allEntities = await _dbSet.ToListAsync(cancellationToken);

            return allEntities;
        }

        public virtual async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T?> GetByGuid(Guid id, CancellationToken cancellationToken)
        {
            T? entity = await _dbSet.FindAsync(id, cancellationToken);

            return entity;
        }

        public virtual async Task<List<T>> GetWhere(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken
        )
        {
            List<T> entities = await _dbSet.Where(predicate).ToListAsync(cancellationToken);

            return entities;
        }
    }
}
