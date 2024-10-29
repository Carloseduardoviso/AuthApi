using Bussines.Data.Responses.Usuario;

namespace Bussines.Data.Responses
{
    public record AuthResponse(string Token, UsuarioResponse UsuarioResponse);
}
