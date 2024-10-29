using Data.Repositories.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Bussines.Data.Models;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DataContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);

            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entityes)
        {
            _db.AddRange(entityes);

            _db.SaveChanges();

            return entityes;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _db.Update(entity);
            return entity;
        }

        public async Task<Pagination<TEntity>> GetAllPaginationAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, Expression<Func<TEntity, object>>[]? includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            int totalModelos = query.Count();

            var totalPages = (int)Math.Ceiling((double)totalModelos / pageSize);

            if (asNoTracking)
            {
                query = _dbSet.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            else
            {
                query = _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {

                    query = query.Include(include);
                }
            }

            var items = expression == null
            ? await query.ToListAsync()
            : await query.Where(expression).ToListAsync();

            int totalItems = items.Count();
            int currentPage = pageNumber;

            return new Pagination<TEntity>(totalItems, currentPage, totalPages, items);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity?> GetEntityObjectAsync(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, Expression<Func<TEntity, object>>[]? includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return expression == null
            ? await query.FirstOrDefaultAsync()
            : await query.FirstOrDefaultAsync(expression);
        }


        public async Task<IEnumerable<TEntity>> GetEntityObjectsAsync(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, Expression<Func<TEntity, object>>[]? includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return expression == null
               ? await query.ToListAsync()
               : await query.Where(expression).ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db?.Dispose();
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            _db.Remove(entity);
            return entity;
        }

        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
