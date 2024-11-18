using Bussines.Data.Entityes;
using Bussines.Repositories;
using Data.Context;

namespace Data.Repositories
{
    public class UsuarioSistemaRepository : BaseRepository<UsuarioSistema>, IUsuarioSistemaRepository
    {
        public UsuarioSistemaRepository(DataContext db) : base(db)
        {
        }
    }
}
