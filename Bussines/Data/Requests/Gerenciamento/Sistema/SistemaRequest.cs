using Bussines.Data.Requests.Gerenciamento.Servico;

namespace Bussines.Data.Requests.Gerenciamento.Sistema
{
    public record SistemaRequest(Guid? SistemaId = null, string? Nome = null, string? ControllerProtocoloHttp = null, string? UrlController = null, string? UrlAction = null, string? UrlParams = null, ServicoRequest? SearchServicoRequest = null);
}
