using Bussines.Data.Entityes;
using Bussines.Data.Models;
using LinqKit;
using System.Linq.Expressions;

namespace Bussines.Helpers.Filters
{
    public static class UsuarioSistemaFilter
    {
        public static Expression<Func<UsuarioSistema, bool>> ConUsuario(UsuarioSistemaVm? usuarioSistema = null)
        {
            Expression<Func<UsuarioSistema, bool>> expression = x => true;

            if (usuarioSistema != null)
            {
                if (!usuarioSistema.UsuarioId.Equals(Guid.Empty))
                {
                    expression = expression.And(x => x.UsuarioId == usuarioSistema.UsuarioId);
                }
                if (!usuarioSistema.SistemaId.Equals(Guid.Empty))
                {
                    expression = expression.And(x => x.SistemaId == usuarioSistema.SistemaId);
                }

                if (usuarioSistema.Usuario is not null)
                {
                    if (!string.IsNullOrEmpty(usuarioSistema.Usuario.NomeCompleto))
                    {
                        expression = expression.And(x => x.Usuario.NomeCompleto.Contains(usuarioSistema.Usuario.NomeCompleto));
                    }
                    if (!string.IsNullOrEmpty(usuarioSistema.Usuario.Telefone))
                    {
                        expression = expression.And(x => x.Usuario.Telefone.Contains(usuarioSistema.Usuario.Telefone));
                    }
                    if (!string.IsNullOrEmpty(usuarioSistema.Usuario.CPF))
                    {
                        expression = expression.And(x => x.Usuario.CPF.Contains(usuarioSistema.Usuario.CPF));
                    }
                    if (!string.IsNullOrEmpty(usuarioSistema.Usuario.Email))
                    {
                        expression = expression.And(x => x.Usuario.Email.Contains(usuarioSistema.Usuario.Email));
                    }
                    if (!string.IsNullOrEmpty(usuarioSistema.Usuario.Senha))
                    {
                        expression = expression.And(x => x.Usuario.Senha.Contains(usuarioSistema.Usuario.Senha));
                    }

                    if (!usuarioSistema.Usuario .TipoPermissao.Equals(0))
                    {
                        expression = expression.And(x => x.Usuario.TipoPermissao.Equals(usuarioSistema.Usuario.TipoPermissao));
                    }
                }
                if (usuarioSistema.Sistema is not null)
                {
                    if (!string.IsNullOrEmpty(usuarioSistema.Sistema.ControllerProtocoloHttp))
                    {
                        expression = expression.And(x => x.Sistema.ControllerProtocoloHttp.Contains(usuarioSistema.Sistema.ControllerProtocoloHttp));
                    }
                    if (!string.IsNullOrEmpty(usuarioSistema.Sistema.UrlController))
                    {
                        expression = expression.And(x => x.Sistema.UrlController.Contains(usuarioSistema.Sistema.UrlController));
                    }
                    if (!string.IsNullOrEmpty(usuarioSistema.Sistema.UrlAction))
                    {
                        expression = expression.And(x => x.Sistema.UrlAction.Contains(usuarioSistema.Sistema.UrlAction));
                    }
                }
            }

            return expression;
        }
    }
}
