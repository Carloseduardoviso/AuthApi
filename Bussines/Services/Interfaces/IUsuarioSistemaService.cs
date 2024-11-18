using Bussines.Data.Models;
using Bussines.Data.Requests.UsuarioSistema;
using System.Linq.Expressions;

namespace Bussines.Services.Interfaces
{
    public interface IUsuarioSistemaService
    {
        Task<UsuarioSistemaVm> AddUsuarioAsync(CriarUsuarioSistemaRequest criarUsuarioSistemaRequest);
        IEnumerable<UsuarioSistemaVm> AddUsuariosRange(IEnumerable<UsuarioSistemaVm> usuarios);
        Task<UsuarioSistemaVm> UpdateUsuario(EditeUsuarioSistemaRequest editeUsuarioSistemaRequest);
        Task<UsuarioSistemaVm> RemoveUsuario(RemoverUsuarioSistemaRequest removerUsuarioSistemaRequest);
        Task<Pagination<UsuarioSistemaVm>> GetAllUsuarioPaginationAsync(Expression<Func<UsuarioSistemaVm, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<UsuarioSistemaVm, object>>[]? includes);
        Task<UsuarioSistemaVm?> GetUsuarioAsync(Expression<Func<UsuarioSistemaVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioSistemaVm, object>>[]? includes);
        Task<IEnumerable<UsuarioSistemaVm>> GetUsuariosAsync(Expression<Func<UsuarioSistemaVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioSistemaVm, object>>[]? includes);
    }
}
