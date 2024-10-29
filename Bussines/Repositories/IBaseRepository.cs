using Bussines.Data.Models;
using System.Linq.Expressions;

namespace Bussines.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entityes);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Remove(TEntity entity);
        Task<Pagination<TEntity>> GetAllPaginationAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<TEntity, object>>[]? includes);
        Task<TEntity?> GetEntityObjectAsync(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<TEntity, object>>[]? includes);
        Task<IEnumerable<TEntity>> GetEntityObjectsAsync(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<TEntity, object>>[]? includes);
    }
}
