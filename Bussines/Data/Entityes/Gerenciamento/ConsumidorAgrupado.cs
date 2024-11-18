namespace Bussines.Data.Entityes.Gerenciamento
{
    public class ConsumidorAgrupado
    {
        public Guid ConsumidorAgrupadoId { get; set; }

        #region Relacionamentos

        public Guid ConsumidorId { get; set; }
        public Consumidor Consumidor { get; set; }
        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; }
        public Guid SistemaId { get; set; }
        public Sistema Sistema { get; set; }

        #endregion Relacionamentos
    }
}
