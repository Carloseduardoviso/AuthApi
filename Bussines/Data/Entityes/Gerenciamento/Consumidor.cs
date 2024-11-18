using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Data.Entityes.Gerenciamento
{
    public class Consumidor
    {
        public Guid ConsumidorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? Hash { get; set; }

        #region Relacionamentos

        public ICollection<ConsumidorAgrupado> ConsumidorAgrupados { get; set; }

        #endregion Relacionamentos
    }
}
