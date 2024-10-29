using Bussines.Data.Requests.Usuario;

namespace Bussines.Data.Requests.Paginations
{
    public record SearchUsuarioPaginationRequest(UsuarioRequest? UsuarioRequest = null, int PageNumber = 1, int PageSize = 10, List<string>? Includes = null);
}
