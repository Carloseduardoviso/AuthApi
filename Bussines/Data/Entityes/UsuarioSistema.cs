using Bussines.Data.Entityes.Gerenciamento;

namespace Bussines.Data.Entityes
{
    public class UsuarioSistema
    {
        public Guid SistemaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Sistema Sistema { get; set; }
        public Usuario Usuario { get; set; }
    }
}
