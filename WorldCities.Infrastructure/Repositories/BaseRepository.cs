using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorldCities.Core.Domain.RepositoryContracts;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public virtual async Task<T> add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<List<T>?> all()
        {
            List<T>? allEntities = await _dbSet.ToListAsync();

            return allEntities;
        }

        public virtual async Task delete(T entity)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<T?> getByGuid(Guid? guid)
        {
            T? entity = await _dbSet.FindAsync(guid);

            return entity;
        }

        public virtual async Task<List<T>?> getWhere(Expression<Func<T, bool>> predicate)
        {
            List<T>? entities = await _dbSet.Where(predicate).ToListAsync();

            return entities;
        }

        public Task<T> update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
