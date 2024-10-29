using System.ComponentModel.DataAnnotations;

namespace Bussines.Data.Enums
{
    public enum TipoPermissao
    {
        [Display(Name = "Administrador")]
        Admin = 1,
        [Display(Name = "Coloborador")]
        Colaborador,
        [Display(Name = "Cliente")]
        Cliente,
    }
}
