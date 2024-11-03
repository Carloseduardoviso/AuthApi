using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Data.Models.Gerenciamento
{
    public class ConsumidorVm
    {
        public Guid ConsumidorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? Hash { get; set; }

        #region Relacionamentos

        public ICollection<ConsumidorAgrupadoVm> ConsumidorAgrupados { get; set; }

        #endregion Relacionamentos
    }
}
