using System.Linq.Expressions;

namespace OfficeInventorySystem.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>[]? include = null);
        Task<TEntity?> GetByIdAsync(int id, Expression<Func<TEntity, object>>? include = null);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int Id);
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>? include = null);
    }
}
