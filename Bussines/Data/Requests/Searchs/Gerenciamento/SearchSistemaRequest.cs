using Bussines.Data.Requests.Gerenciamento.Sistema;

namespace Bussines.Data.Requests.Searchs.Gerenciamento
{
    public record SearchSistemaRequest(SistemaRequest? SistemaRequest = null, List<string>? Includes = null);
}
