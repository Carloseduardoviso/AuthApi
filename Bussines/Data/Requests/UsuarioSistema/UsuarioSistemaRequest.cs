using Bussines.Data.Models;

namespace Bussines.Data.Requests.UsuarioSistema
{
    public record UsuarioSistemaRequest(Guid? UsuarioId = null, Guid? UsuarioSistemaId = null, UsuarioVm? Usuario = null, UsuarioSistemaVm? UsuarioSistema = null);
}
