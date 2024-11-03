namespace Bussines.Data.Models.Gerenciamento
{
    public class ConsumidorAgrupadoVm
    {
        public Guid ConsumidorAgrupadoId { get; set; }

        #region Relacionamentos

        public Guid ConsumidorId { get; set; }
        public ConsumidorVm Consumidor { get; set; }
        public Guid ServicoId { get; set; }
        public ServicoVm Servico { get; set; }
        public Guid SistemaId { get; set; }
        public SistemaVm Sistema { get; set; }

        #endregion Relacionamentos
    }
}
