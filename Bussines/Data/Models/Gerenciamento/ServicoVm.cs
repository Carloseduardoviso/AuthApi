namespace Bussines.Data.Models.Gerenciamento
{
    public class ServicoVm
    {
        public Guid ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos

        public ICollection<ConsumidorAgrupadoVm> ConsumidorAgrupados { get; set; }
        public ICollection<SistemaVm> Sistemas { get; set; }

        #endregion Relacionamentos
    }
}
