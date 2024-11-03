namespace Bussines.Data.Models.Gerenciamento
{
    public class SistemaVm
    {
        public Guid SistemaId { get; set; }
        public string ControllerProtocoloHttp { get; set; }
        public string UrlController { get; set; }
        public string UrlAction { get; set; }

        #region Relacionamentos

        public Guid ServicoId { get; set; }
        public ServicoVm Servico { get; set; }
        public ICollection<ConsumidorAgrupadoVm> ConsumidorAgrupados { get; set; }

        #endregion Relacionamentos
    }
}
