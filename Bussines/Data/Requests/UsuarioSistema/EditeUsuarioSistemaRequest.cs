using Bussines.Data.Enums;

namespace Bussines.Data.Requests.UsuarioSistema
{
    public record EditeUsuarioSistemaRequest(Guid UsuarioId, Guid SistemaId);
}
