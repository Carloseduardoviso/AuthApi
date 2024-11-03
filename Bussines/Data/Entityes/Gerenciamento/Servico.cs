namespace Bussines.Data.Entityes.Gerenciamento
{
    public class Servico
    {
        public Guid ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos

        public ICollection<ConsumidorAgrupado> ConsumidorAgrupados { get; set; }
        public ICollection<Sistema> Sistemas { get; set; }

        #endregion Relacionamentos
    }
}
