using Bussines.Data.Requests.Usuario;
using Bussines.Data.Requests.UsuarioSistema;

namespace Bussines.Data.Requests.Searchs.Paginations
{
    public record SearchUsuarioSistemaPaginationRequest(UsuarioSistemaRequest? UsuarioSistemaRequest = null, int PageNumber = 1, int PageSize = 10, List<string>? Includes = null);
}
