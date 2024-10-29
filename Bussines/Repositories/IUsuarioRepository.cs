using Bussines.Data.Entityes;
using Bussines.Data.Models;
using System.Linq.Expressions;

namespace Bussines.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> AddAsync(Usuario usuario);
        IEnumerable<Usuario> AddRange(IEnumerable<Usuario> usuarioes);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Remove(Usuario usuario);
        Task<Pagination<Usuario>> GetAllPaginationAsync(Expression<Func<Usuario, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<Usuario, object>>[]? includes);
        Task<Usuario?> GetEntityObjectAsync(Expression<Func<Usuario, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<Usuario, object>>[]? includes);
        Task<IEnumerable<Usuario>> GetEntityObjectsAsync(Expression<Func<Usuario, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<Usuario, object>>[]? includes);
    }
}
