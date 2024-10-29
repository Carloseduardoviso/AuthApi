using Bussines.Data.Entityes;
using Bussines.Repositories;
using Data.Context;

namespace Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext db) : base(db)
        {
        }
    }
}
