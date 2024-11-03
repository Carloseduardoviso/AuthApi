namespace Bussines.Data.Requests.Gerenciamento.Servico
{
    public record ServicoRequest(Guid? ServicoId = null, string? Nome = null, string? Descricao = null);
}
