using Bussines.Data.Enums;

namespace Bussines.Data.Responses.Usuario
{
    public record UsuarioResponse(Guid UsuarioId, string NomeCompleto, string Telefone, string CPF, string Email, TipoPermissao TipoPermissao);

}
