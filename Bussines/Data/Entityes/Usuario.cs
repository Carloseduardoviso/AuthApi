using Bussines.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussines.Data.Entityes
{
    [Table(name: "tb_usuario")]
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }
        public string NomeCompleto { get; private set; }
        public string Telefone { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public TipoPermissao TipoPermissao { get; set; }

    }
}
