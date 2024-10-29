using Bussines.Data.Enums;

namespace Bussines.Data.Requests.Usuario
{
    public record EditeUsuarioRequest(Guid UsuarioId, string NomeCompleto, string Telefone, string CPF, string Email, string Senha, TipoPermissao TipoPermissao);
}
