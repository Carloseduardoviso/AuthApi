using Bussines.Data.Entityes;
using Bussines.Data.Models;
using LinqKit;
using System.Linq.Expressions;

namespace Bussines.Helpers.Filters
{
    public static class AuthFilter
    {
        public static Expression<Func<Usuario, bool>> ConUsuario(UsuarioVm? usuario = null)
        {
            // Inicia com uma expressão que sempre retorna true
            Expression<Func<Usuario, bool>> expression = x => true;

            // Aplica os filtros para um único usuario
            if (usuario != null)
            {
                if (!usuario.UsuarioId.Equals(Guid.Empty))
                {
                    expression = expression.And(x => x.UsuarioId == usuario.UsuarioId);
                }
                if (!string.IsNullOrEmpty(usuario.NomeCompleto))
                {
                    expression = expression.And(x => x.NomeCompleto.Contains(usuario.NomeCompleto));
                }
                if (!string.IsNullOrEmpty(usuario.Telefone))
                {
                    expression = expression.And(x => x.Telefone.Contains(usuario.Telefone));
                }
                if (!string.IsNullOrEmpty(usuario.CPF))
                {
                    expression = expression.And(x => x.Telefone.Contains(usuario.CPF));
                }
                if (!string.IsNullOrEmpty(usuario.Email))
                {
                    expression = expression.And(x => x.Telefone.Contains(usuario.Email));
                }
                if (!string.IsNullOrEmpty(usuario.Senha))
                {
                    expression = expression.And(x => x.Telefone.Contains(usuario.Senha));
                }

                if (!usuario.TipoPermissao.Equals(0))
                {
                    expression = expression.And(x => x.TipoPermissao.Equals(usuario.TipoPermissao));
                }
            }

            return expression;
        }
    }
}
