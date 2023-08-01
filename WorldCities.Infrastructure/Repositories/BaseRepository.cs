using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public virtual IQueryable<T> Get() => _dbSet;

        public virtual IQueryable<T> Get(Guid id) => _dbSet.Where(e => e.Id == id);

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate) =>
            _dbSet.Where(predicate);

        public async Task<T> Add(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
