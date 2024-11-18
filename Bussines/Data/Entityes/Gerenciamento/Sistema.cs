namespace Bussines.Data.Entityes.Gerenciamento
{
    public class Sistema
    {
        public Guid SistemaId { get; set; }
        public string ControllerProtocoloHttp { get; set; }
        public string UrlController { get; set; }
        public string UrlAction { get; set; }

        #region Relacionamentos

        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; }
        public ICollection<ConsumidorAgrupado> ConsumidorAgrupados { get; set; }

        #endregion Relacionamentos
    }
}
