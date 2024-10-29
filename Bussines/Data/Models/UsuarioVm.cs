using Bussines.Data.Enums;

namespace Bussines.Data.Models
{
    public class UsuarioVm
    {
        public Guid UsuarioId { get; set; }
        public string NomeCompleto { get;  set; }
        public string Telefone { get;  set; } 
        public string CPF { get;  set; } 
        public string Email { get;  set; } 
        public string Senha { get;  set; }
        public TipoPermissao TipoPermissao { get; set; }
    }
}
