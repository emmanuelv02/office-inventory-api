using Microsoft.EntityFrameworkCore;
using OfficeInventorySystem.Domain.Interfaces;
using System.Linq.Expressions;

namespace OfficeInventorySystem.Persistence.Repositories
{
    public class GenericRepository<TEntity>(DbContext dbContext) : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public Task AddAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            return dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = false;
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? include = null) => 
            include != null ? await _dbSet.Include(include).ToListAsync() : await _dbSet.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id, Expression<Func<TEntity, object>>? include = null)
        {
            return include != null ?
             await _dbSet.Include(include).Where(x => x.Id == id).FirstOrDefaultAsync() :
             await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>? include = null)
        {
            if (include != null)
                return await _dbSet.Include(include).Where(predicate).ToListAsync();

            return await _dbSet.Where(predicate).ToListAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }
    }
}
