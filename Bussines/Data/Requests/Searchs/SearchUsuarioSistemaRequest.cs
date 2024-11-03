using Bussines.Data.Requests.Usuario;
using Bussines.Data.Requests.UsuarioSistema;

namespace Bussines.Data.Requests.Searchs
{
    public record SearchUsuarioSistemaRequest(UsuarioSistemaRequest UsuarioSistemaRequest, List<string>? Includes = null);
}
