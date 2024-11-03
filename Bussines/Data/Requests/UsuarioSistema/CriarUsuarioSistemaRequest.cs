using Bussines.Data.Enums;

namespace Bussines.Data.Requests.UsuarioSistema
{
    public record CriarUsuarioSistemaRequest(Guid UsuarioId, Guid SistemaId);
}
