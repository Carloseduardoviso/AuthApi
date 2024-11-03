using Bussines.Data.Models.Gerenciamento;

namespace Bussines.Data.Models
{
    public class UsuarioSistemaVm
    {
        public Guid SistemaId { get; set; }
        public Guid UsuarioId { get; set; }
        public SistemaVm Sistema { get; set; }
        public UsuarioVm Usuario { get; set; }
    }
}
