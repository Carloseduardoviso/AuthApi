using Bussines.Data.Requests.Usuario;

namespace Bussines.Data.Requests.Searchs
{
    public record SearchUsuarioRequest(UsuarioRequest UsuarioRequest, List<string>? Includes = null);
}
