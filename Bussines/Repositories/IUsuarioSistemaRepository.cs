﻿using Bussines.Data.Entityes;
using Bussines.Data.Models;
using System.Linq.Expressions;

namespace Bussines.Repositories
{
    public interface IUsuarioSistemaRepository : IBaseRepository<UsuarioSistema>
    {
        Task<UsuarioSistema> AddAsync(UsuarioSistema usuario);
        IEnumerable<UsuarioSistema> AddRange(IEnumerable<UsuarioSistema> usuarioes);
        Task<UsuarioSistema> Update(UsuarioSistema usuario);
        Task<UsuarioSistema> Remove(UsuarioSistema usuario);
        Task<Pagination<UsuarioSistema>> GetAllPaginationAsync(Expression<Func<UsuarioSistema, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<UsuarioSistema, object>>[]? includes);
        Task<UsuarioSistema?> GetEntityObjectAsync(Expression<Func<UsuarioSistema, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioSistema, object>>[]? includes);
        Task<IEnumerable<UsuarioSistema>> GetEntityObjectsAsync(Expression<Func<UsuarioSistema, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioSistema, object>>[]? includes);
    }
}
