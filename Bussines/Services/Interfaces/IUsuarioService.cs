using Bussines.Data.Models;
using Bussines.Data.Requests.Usuario;
using Bussines.Data.Responses;
using System.Linq.Expressions;

namespace Bussines.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<AuthResponse> GetAuthAsync(Expression<Func<UsuarioVm, bool>>? expression = null, bool asNoTracking = false);

        Task<UsuarioVm> AddUsuarioAsync(CriarUsuarioRequest criarUsuarioRequest);

        IEnumerable<UsuarioVm> AddUsuariosRange(IEnumerable<UsuarioVm> usuarios);

        Task<UsuarioVm> UpdateUsuario(EditeUsuarioRequest editeUsuarioRequest);

        Task<UsuarioVm> RemoveUsuario(RemoverUsuarioRequest removerUsuarioRequest);

        Task<Pagination<UsuarioVm>> GetAllUsuarioPaginationAsync(Expression<Func<UsuarioVm, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<UsuarioVm, object>>[]? includes);

        Task<UsuarioVm?> GetUsuarioAsync(Expression<Func<UsuarioVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioVm, object>>[]? includes);

        Task<IEnumerable<UsuarioVm>> GetUsuariosAsync(Expression<Func<UsuarioVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioVm, object>>[]? includes);
    }
}
